using DynAbs.Summaries;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynAbs
{
    public static class TypesUtils
    {
        static IDictionary<ISlicerSymbol, IDictionary<ISlicerSymbol, bool>> complexTypesCache = new Dictionary<ISlicerSymbol, IDictionary<ISlicerSymbol, bool>>();
        static IDictionary<string, ISlicerSymbol> associatedSymbol = new Dictionary<string, ISlicerSymbol>();
        public static int hit = 0;
        public static int miss = 0;

        public static double ttipes_get_min = 0;
        public static double ttipes_get_field_symbol = 0;
        public static double ttipes_compatibles = 0;

        public static bool Compatibles(ISlicerSymbol a, ISlicerSymbol b)
        {
            var initialTime = System.DateTime.Now;

            IDictionary<ISlicerSymbol, bool> firstEntry;
            if (complexTypesCache.TryGetValue(a, out firstEntry))
            {
                bool secondEntry;
                if (firstEntry.TryGetValue(b, out secondEntry))
                {
                    hit++;
                    return secondEntry;
                }
            }
            miss++;

            bool returnValue;
            if (a == b)
                returnValue = true;
            // Como a y b son distintos, a un anonymous o null no le podés asignar otra cosa
            else if (a.IsNullSymbol || a.IsAnonymous)
                returnValue = false;
            else if (b.IsAnonymous && a.Symbol != null && a.Symbol.IsAnonymousType)
                returnValue = true;
            else if (a.IsObject)
                returnValue = !(b.IsNullSymbol);
            else if (b.Symbol == null)
                returnValue = false;
            else
                returnValue = Compatibles(a.Symbol, b.Symbol);

            if (firstEntry == null)
                complexTypesCache[a] = new Dictionary<ISlicerSymbol, bool>();
            complexTypesCache[a][b] = returnValue;

            ttipes_compatibles += System.DateTime.Now.Subtract(initialTime).TotalMilliseconds;

            return returnValue;
        }

        public static bool Compatibles(ITypeSymbol type1, ITypeSymbol type2)
        {
            bool returnValue = false;

            if ((type1.BaseType == null && type1.TypeKind == TypeKind.Class) || // Medio trucho, si no tiene BaseType es porque es Object, y si el tipo del lhs es object todo lo tipa
                type1.TypeKind == TypeKind.TypeParameter ||
                //(type1.TypeKind == TypeKind.Interface && type2.AllInterfaces.Contains(type1))) // Si la derecha es del tipo T, asumimos que tipa.
                (type1.TypeKind == TypeKind.Interface && type2.AllInterfaces.Any(x => x.ToString() == type1.ToString()))) // Si la derecha es del tipo T, asumimos que tipa.
                returnValue = true;
            else
            {
                ITypeSymbol baseType = type2;
                while (baseType != null)
                {
                    // Si la clase tiene el mismo nombre o el tipo del rhs implementa la interfaz de la derecha
                    if (type1.Name == baseType.Name)
                    {
                        returnValue = true;
                        break;
                    }
                    baseType = baseType.BaseType;
                }

                // Me meto adentro si son listas
                if (returnValue && (type1 is INamedTypeSymbol && baseType is INamedTypeSymbol))
                {
                    var aTypeArguments = ((INamedTypeSymbol)type1).TypeArguments.ToList();
                    var bTypeArguments = ((INamedTypeSymbol)baseType).TypeArguments.ToList();

                    // XXX: La excepción salto con EventHandler<Error> = EventHandler... el de la izquierda tiene más parámetros, es más específicos, entonces no es compatible la asignación (chequear algún día)
                    if (aTypeArguments.Count > bTypeArguments.Count)
                        return false;

                    if (aTypeArguments.Count > 0) // && aTypeParameters.Count == bTypeParameters.Count)
                        for (var i = 0; i < aTypeArguments.Count; i++)
                            if (!Compatibles(aTypeArguments[i], bTypeArguments[i]))
                            {
                                returnValue = false;
                                break;
                            }
                }
            }

            return returnValue;
        }

        public static ISlicerSymbol GetFieldSymbol(ISlicerSymbol symbol, string name)
        {
            var initialTime = System.DateTime.Now;

            ISlicerSymbol returnValue = null;
            if (symbol.Symbol == null)
            {
                if (symbol.IsNullSymbol)
                    throw new SlicerException("No se le puede buscar un field a un NULL");
                returnValue = ISlicerSymbol.CreateObjectSymbol();
            }
            if (returnValue == null)
            {
                var lookupType = symbol.Symbol;
                ISymbol memberSymbol = null;
                while (lookupType != null)
                {
                    var members = lookupType.OriginalDefinition.GetMembers(name);
                    if (members.Count() > 0)
                    {
                        memberSymbol = members.First();
                        break;
                    }
                    else
                        lookupType = lookupType.BaseType;
                }
                if (memberSymbol == null)
                    //TODO
                    //throw new SlicerException("Este field no pertenece al tipo");
                    returnValue = ISlicerSymbol.CreateObjectSymbol();
                else
                {
                    if (memberSymbol.Kind == SymbolKind.Property)
                        returnValue = ISlicerSymbol.Create(((IPropertySymbol)memberSymbol).Type);
                    else if (memberSymbol.Kind == SymbolKind.Field)
                        returnValue = ISlicerSymbol.Create(((IFieldSymbol)memberSymbol).Type);

                    else //if (memberSymbol.Kind == SymbolKind.Method) TODO
                        returnValue = ISlicerSymbol.CreateObjectSymbol();
                    //throw new SlicerException("No sé que hacer");
                }
            }

            ttipes_get_field_symbol += System.DateTime.Now.Subtract(initialTime).TotalMilliseconds;
            return returnValue;
        }

        public static ISlicerSymbol GetMin(ISlicerSymbol a, ISlicerSymbol b)
        {
            var initialTime = System.DateTime.Now;
            ISlicerSymbol returnValue = null;

            if (a == b)
                returnValue = a;
            // Null, IsAnonymous y Query son los más específicos, los creamos nosotros
            else if (a.IsNullSymbol || a.IsAnonymous)
                returnValue = a;
            else if (b.IsNullSymbol || b.IsAnonymous)
                returnValue = b;
            else if (a.IsObject)
                returnValue = b;
            else if (b.IsObject)
                returnValue = a;
            // Si el baseType es null es object
            else if (a.Symbol.BaseType == null)
                returnValue = b;
            // Si el baseType es null es object
            else if (b.Symbol.BaseType == null)
                returnValue = a;
            else if (a.Symbol.TypeKind == TypeKind.Interface && b.Symbol.TypeKind == TypeKind.Class)
                returnValue = b;
            else if (b.Symbol.TypeKind == TypeKind.Interface && a.Symbol.TypeKind == TypeKind.Class)
                returnValue = a;
            // El más general no es el menor. Si uno no se puede asignar a otro es porque es más general.
            else if (!Compatibles(a, b))
                return a;
            else if (!Compatibles(b, a))
                return b;
            else
            {
                //if (a != b)
                //    throw new SlicerException("PEPE");

                // TODOTYPES me gusta más el B porque soy puto
                returnValue = b;
            }

            ttipes_get_min += System.DateTime.Now.Subtract(initialTime).TotalMilliseconds;
            return returnValue;
        }

        public static ISlicerSymbol GetTypeByETType(ETType type, IDictionary<ETType, ISlicerSymbol> mapping)
        {
            if (type.Kind == ETTypeKind.Default)
                return GetNamedTypeByName(type.Name);
            return mapping.Where(x => x.Key.Equals(type)).Single().Value;
        }
        
        public static ISlicerSymbol GetNamedTypeByName(string name)
        {
            if (associatedSymbol.ContainsKey(name))
                return associatedSymbol[name];

            var returnedSymbol = ISlicerSymbol.CreateNullTypeSymbol();
            var symbols = new HashSet<INamedTypeSymbol>();
            foreach (var project in Globals.UserSolution.Projects)
            {
                var results = Microsoft.CodeAnalysis.FindSymbols.SymbolFinder.FindDeclarationsAsync(project, name.Split('.').Last(), true).Result;
                symbols.UnionWith(results.OfType<INamedTypeSymbol>());
            }

            if (symbols.Count > 1)
            {
                if (name.Contains('.'))
                    symbols.RemoveWhere(x => x.ContainingNamespace.ToString() != name.Substring(0, name.LastIndexOf('.')));
                
                if (symbols.Count != 1)
                {
                    //throw new SlicerException("Ambiguous type name in annotation");
                    // System.Array tiró una excepción con un EFWinForms porque aparecía duplicado pero a simple vista era igual... XXX
                    symbols = new HashSet<INamedTypeSymbol>() { symbols.First() };
                }
            }
            
            if (symbols.Count > 0)
                returnedSymbol = ISlicerSymbol.Create(symbols.Single());
            associatedSymbol[name] = returnedSymbol;
            return returnedSymbol;
        }
    }
}
