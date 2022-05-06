using System;
using System.Linq;
using System.Xml.Linq;
using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using DynAbs.Summaries;

namespace DynAbs
{
    static class BasicAnnotationSchemes
    {
        public static Dictionary<string, string> Annotations = new Dictionary<string, string>()
        {
            // Incluye el global
            { "FullHavoc", "IsIn{R;R.*;P;P.*;G;G.*;RO}.{Many}.{R;R.?;R.*.?;P;P.?;P.*.?;G;G.?;G.*.?}.{R.?;R.*.?;P;P.?;P.*.?;G;G.?;G.*.?;RO.?}.{[R;R.*;P;P.*;G;G.*;RO, R;R.*;P;P.*;G;G.*;RO, ?]}" },
            // Any of these annotations contains global fields.
            { "Nothing", "Null.{}.{}.{}.{}" },
            { "BasicScalarSystemCall", "Null.{}.{R;P}.{}.{}" },
            { "BasicScalarSystemProperty", "Null.{}.{}.{}.{}" },
            { "BasicReferenceSystemCall", "Fresh.{}.{}.{P}.{}" },

            { "WriteThisReadParameters_Null_Null", "Null.{}.{R.?;R.*.?;P;P.?;P.*.?}.{R.?;R.*.?}.{}" },
            { "WriteThisReadAndConnectParameters_Null_Null", "Null.{}.{R.?;R.*.?;P;P.?;P.*.?}.{R.?;R.*.?}.{[R;R.*, P;P.*, ?]}" },
            { "WriteThisReadParameters_Fresh_Null", "Fresh.{}.{R.?;R.*.?;P;P.?;P.*.?}.{R.?;R.*.?;RV.?}.{[RV;R.*;R, RV;R.*;R;P;P.*, ?]}" },

            { "ReadAll_IsIn_Many", "IsIn{R;R.*;P;P.*;RO}.{Many}.{R;R.?;R.*.?;P;P.?;P.*.?}.{RO.?}.{[RO, R;R.*;P;P.*;RO, ?]}" },
            { "ReadAll", "Null.{}.{R;R.?;R.*.?;P;P.?;P.*.?}.{}.{}" },

            { "HavocWithoutGlobals_Null_Null", "Null.{}.{R;R.?;R.*.?;P;P.?;P.*.?}.{R.?;R.*.?;P;P.?;P.*.?}.{[R;R.*;P;P.*, R;R.*;P;P.*, ?]}" },
            { "HavocWithoutGlobals_IsIn_Many", "IsIn{R;R.*;P;P.*;RO}.{Many}.{R;R.?;R.*.?;P;P.?;P.*.?}.{R.?;R.*.?;P;P.?;P.*.?;RO.?}.{[R;R.*;P;P.*;RO, R;R.*;P;P.*;RO, ?]}" },
            
            // Autoproperties
            { "Autoproperty_Get", "IsIn{R.$}.{}.{}.{}.{}" }, // Se obtiene el last def
            { "Autoproperty_Set", "Null.{}.{P}.{R.$}.{[R, P, $]}" }, // Es un assign

            // TypeOf
            { "TypeOf", "Fresh.{}.{P}.{RV.?}.{}" },
            // Lambda
            { "Lambda", "Fresh.{}.{P}.{RV.?}.{[RV, P, ?]}" }, // El P es opcional para mi, porque se lee cuando se ejecuta no antes.
            // Queries // Por ahora dejo el IsInMany (XXX)
            { "Query", "IsIn{R;R.*;P;P.*;RO}.{Many}.{R;R.?;R.*.?;P;P.?;P.*.?}.{R.?;R.*.?;P;P.?;P.*.?;RO.?}.{[R;R.*;P;P.*;RO, R;R.*;P;P.*;RO, ?]}" },
            // Foreach:
            { "ForeachGetEnumerator", "Fresh.{}.{R}.{RV.?}.{[RV, R, list]}" },
            { "MoveNext", "Null.{}.{R.?;R.?.?}.{R.?}.{[R, R.*, Current]}" }, // TODO: Faltaría el OFTYPE
            { "Current", "IsIn{R.Current}.{}.{R.?}.{}.{}" }
        };
    }

    public enum SummaryAnnotationType
    {
        Predefined,
        Custom
    }

    public class SummaryAnnotation
    {
        public SummaryAnnotationType Type;
        public string Annotation;
        public SummaryAnnotation(SummaryAnnotationType Type, string Annotation)
        {
            this.Type = Type;
            this.Annotation = Annotation;
        }
    }

    public static class AnnotationsUtils
    {
        static XElement SummaryElement { get; set; }

        static AnnotationsUtils()
        {
            if (UserSliceConfiguration.CurrentUserConfiguration != null)
            {
                if (System.IO.File.Exists(UserSliceConfiguration.CurrentUserConfiguration.customization.summaries))
                    SummaryElement = XElement.Load(UserSliceConfiguration.CurrentUserConfiguration.customization.summaries);
            }
        }

        public static IDictionary<ETType, ISlicerSymbol> GetMapping(InterpretedAnnotation annotation, Term receiver, List<Term> args, Term returnValue, ISymbol symbol, string methodName = null)
        {
            var dict = new Dictionary<ETType, ISlicerSymbol>();
            foreach (var etType in annotation.ToMatch)
            {
                if (etType.Kind == ETTypeKind.Element)
                {
                    if (etType.@base == BaseET.R)
                        dict.Add(etType, receiver.Last.Symbol);
                    if (etType.@base == BaseET.P)
                    {
                        if (!etType.ParamIndex.HasValue)
                            dict.Add(etType, args.Single().Last.Symbol);
                        else
                            dict.Add(etType, args[etType.ParamIndex.Value].Last.Symbol);
                    }
                    if (etType.@base == BaseET.RV)
                        dict.Add(etType, returnValue.Last.Symbol);
                }
                else if (etType.Kind == ETTypeKind.Parametric)
                {
                    if (symbol is IMethodSymbol)
                    {
                        var found = false;

                        // Receiver
                        var receiverType = ((IMethodSymbol)symbol).ReceiverType;
                        if (receiverType != null && ((INamedTypeSymbol)receiverType).TypeParameters.Length > 0)
                        {
                            for (var i = 0; i < ((INamedTypeSymbol)receiverType).TypeParameters.Length; i++)
                            {
                                if (((INamedTypeSymbol)receiverType).TypeParameters[i].Name == etType.Name)
                                {
                                    dict.Add(etType, ISlicerSymbol.Create(((INamedTypeSymbol)receiverType).TypeArguments[i]));
                                    found = true;
                                    break;
                                }
                            }
                        }

                        if (!found && !((IMethodSymbol)symbol).ReturnsVoid)
                        {
                            var returnType = ((IMethodSymbol)symbol).ReturnType;
                            if (returnValue != null && returnValue.Last.Symbol.Symbol != null &&
                                returnType != null && ((INamedTypeSymbol)returnType).TypeParameters.Length > 0)
                            {
                                for (var i = 0; i < ((INamedTypeSymbol)returnType).TypeParameters.Length; i++)
                                {
                                    if (((INamedTypeSymbol)returnType).TypeParameters[i].Name == etType.Name)
                                    {
                                        dict.Add(etType, ISlicerSymbol.Create(((INamedTypeSymbol)returnValue.Last.Symbol.Symbol).TypeArguments[i]));
                                        found = true;
                                        break;
                                    }
                                }
                            }
                        }

                        if (!found)
                        {
                            var parametersTypes = ((IMethodSymbol)symbol).TypeParameters;
                            for (var j = 0; j < parametersTypes.Length && !found; j++)
                            {
                                if (args[j] != null && args[j].Last.Symbol.Symbol != null &&
                                ((INamedTypeSymbol)parametersTypes[j]).TypeParameters.Length > 0)
                                {
                                    for (var i = 0; i < ((INamedTypeSymbol)parametersTypes[j]).TypeParameters.Length; i++)
                                    {
                                        if (((INamedTypeSymbol)parametersTypes[j]).TypeParameters[i].Name == etType.Name)
                                        {
                                            dict.Add(etType, ISlicerSymbol.Create(((INamedTypeSymbol)args[j].Last.Symbol.Symbol).TypeArguments[i]));
                                            found = true;
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else if (symbol is INamedTypeSymbol)
                    {
                        throw new NotImplementedException();
                    }
                    else
                        throw new SlicerException("Unexpected kind");
                }
            }
            return dict;
        }

        public static InterpretedAnnotation GetAnnotation(ISymbol symbol, string methodName = null)
        {
            if (!UserSliceConfiguration.UseAnnotations)
                return null;

            var summaryAnnotation = GetSummaryInformation(symbol, methodName);
            if (summaryAnnotation == null && UserSliceConfiguration.MixedModes)
                return null;
            if (summaryAnnotation == null)
                summaryAnnotation = new SummaryAnnotation(SummaryAnnotationType.Predefined, "HavocWithoutGlobals_IsIn_Many");

            if (summaryAnnotation.Type == SummaryAnnotationType.Predefined)
                return InterpretedAnnotation.Parse(BasicAnnotationSchemes.Annotations[summaryAnnotation.Annotation]);
            return InterpretedAnnotation.Parse(summaryAnnotation.Annotation);
        }

        public static InterpretedAnnotation GetPredefinedAnnotation(string annotationName)
        {
            return InterpretedAnnotation.Parse(BasicAnnotationSchemes.Annotations[annotationName]);
        }

        public static SummaryAnnotation GetSummaryInformation(ISymbol symbol, string methodName = null)
        {
            var node = GetNode(symbol, methodName);
            if (node == null)
                return null;

            XElement xelement = null;
            var importantName = (symbol is IPropertySymbol || symbol is IFieldSymbol) ? "Properties" : "Methods";

            do
            {
                xelement = node.Elements().Where(x => x.Name.LocalName.Equals("AnnotationType")).FirstOrDefault();
                if (node.Name.LocalName.Equals(importantName))
                {
                    node = node.Parent.Parent.Elements().Where(x => x.Name.LocalName
                        .Equals(importantName)).FirstOrDefault();

                    if (node != null)
                    {
                        var objectName = Utils.GetMethodName(symbol, methodName);
                        var maybe = node.Elements().FirstOrDefault(x => x.Name.LocalName.Equals(objectName));
                        node = maybe ?? node;
                    }
                }
                else if (node.Parent.Name.LocalName.Equals(importantName))
                    node = node.Parent;
                else
                    node = node.Parent.Elements().Where(x => x.Name.LocalName
                        .Equals(importantName)).FirstOrDefault();

            } while (xelement == null && node != null && node.Parent != null);

            if (xelement == null)
                return null;
            //throw new NotSupportedException();

            SummaryAnnotationType annotationType;
            if (Enum.TryParse(xelement.Value, out annotationType))
            {
                var xelementAnnotation = xelement.Parent.Elements().Where(x => x.Name.LocalName.Equals("Annotation")).FirstOrDefault();

                return new SummaryAnnotation(annotationType, xelementAnnotation.Value);
            }

            throw new Exception("Receiver type incorrecto. Name = " + xelement.Value);
        }

        static XElement GetNode(ISymbol symbol, string methodName = null)
        {
            if (SummaryElement == null || symbol == null)
                return null;

            var lastSymbol = symbol;
            var searchSymbol = symbol;
            XElement namespaceNode = null;

            do
            {
                var namespaceName = Utils.GetNamespaceName(searchSymbol);
                namespaceNode = SummaryElement.Elements().Where(x => x.Name.LocalName.Equals(namespaceName)).FirstOrDefault();
                lastSymbol = searchSymbol;
                searchSymbol = searchSymbol.ContainingType != null ? searchSymbol.ContainingType.BaseType : null;
            } while (searchSymbol != null && searchSymbol.ToString() != "object" && namespaceNode == null);

            if (namespaceNode == null)
                return null;

            var className = Utils.GetClassName(lastSymbol);
            var classNode = namespaceNode.Elements().Where(x => x.Name.LocalName.Equals(className)).FirstOrDefault();
            if (classNode == null)
            {
                if (symbol is IPropertySymbol || symbol is IFieldSymbol)
                {
                    var propertiesNode = namespaceNode.Elements().Where(x => x.Name.LocalName.Equals("Properties")).FirstOrDefault();
                    if (propertiesNode == null)
                        return namespaceNode;

                    var propertyName = Utils.GetMethodName(symbol);
                    var propertyNode = propertiesNode.Elements().Where(x => x.Name.LocalName.Equals(propertyName)).FirstOrDefault();
                    if (propertyNode == null)
                        return propertiesNode;

                    return propertyNode;
                }
                else
                {
                    // Nodo de metodos
                    var methodsNode = namespaceNode.Elements().Where(x => x.Name.LocalName.Equals("Methods")).FirstOrDefault();
                    if (methodsNode == null)
                        return namespaceNode;

                    var _methodName = Utils.GetMethodName(symbol, methodName);
                    var methodNode = methodsNode.Elements().Where(x => x.Name.LocalName.Equals(_methodName)).FirstOrDefault();
                    if (methodNode == null)
                        return methodsNode;

                    return methodNode;
                }
            }

            // Property o método
            if (symbol is IPropertySymbol || symbol is IFieldSymbol)
            {
                return null;

                //// Nodo de properties
                //var propertiesNode = classNode.Elements().Where(x => x.Name.LocalName.Equals("Properties")).FirstOrDefault();
                //if (propertiesNode == null)
                //    return classNode;

                //// Nodo de property
                //var propertyName = Utils.GetMethodName(symbol);
                //var propertyNode = propertiesNode.Elements().Where(x => x.Name.LocalName.Equals(propertyName)).FirstOrDefault();
                //if (propertyNode == null)
                //    return propertiesNode;

                //return propertyNode;
            }
            else
            {
                // Nodo de metodos
                var methodsNode = classNode.Elements().Where(x => x.Name.LocalName.Equals("Methods")).FirstOrDefault();
                if (methodsNode == null)
                    return classNode;

                // Nodo de método
                var _methodName = Utils.GetMethodName(symbol, methodName);
                var methodNode = methodsNode.Elements().Where(x => x.Name.LocalName.Equals(_methodName)).FirstOrDefault();
                if (methodNode == null)
                    return methodsNode;

                return methodNode;
            }
        }
    }

    public class AnnotationWithData
    {
        public InterpretedAnnotation Annotation;
        public IDictionary<ETType, ISlicerSymbol> Mapping;
        public IDictionary<string, string> FieldsParameters;

        public AnnotationWithData(InterpretedAnnotation annotation, IDictionary<ETType, ISlicerSymbol> mapping, IDictionary<string, string> fieldsParameters)
        {
            Annotation = annotation;
            Mapping = mapping;
            FieldsParameters = fieldsParameters;
        }
    }
}
