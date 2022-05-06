using Microsoft.CodeAnalysis.CSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynAbs
{
    public static class UserSliceConfiguration
    {
        // Agregar las invocaciones como dependencias de control
        public static bool IncludeCallDependencies { get; set; }
        // Agregar todos los usos de un término (el uso de a.b.c es el uso de a, el de b y el de c o solo el de c)
        public static bool IncludeAllReads { get; set; }
        // Agregar dependencias de control
        public static bool IncludeControlDependencies { get { return CurrentUserConfiguration.customization.includeControlDependencies; } }
        // Agregar dependencias de control
        public static bool UseAnnotations { get { return CurrentUserConfiguration.customization != null && (CurrentUserConfiguration.customization.memoryModel == UserConfiguration.MemoryModelKind.Annotations || CurrentUserConfiguration.customization.memoryModel == UserConfiguration.MemoryModelKind.Mixed || CurrentUserConfiguration.customization.memoryModel == UserConfiguration.MemoryModelKind.Clusters); } }
        public static bool MixedModes { get { return CurrentUserConfiguration.customization.memoryModel == UserConfiguration.MemoryModelKind.Mixed || CurrentUserConfiguration.customization.memoryModel == UserConfiguration.MemoryModelKind.Clusters; } }
        // Configuración actual
        static UserConfiguration _CurrentUserConfiguration;
        public static UserConfiguration CurrentUserConfiguration
        {
            get
            {
                return _CurrentUserConfiguration;
            }
            set
            {
                _CurrentUserConfiguration = value;
                Globals.static_mode_enabled = _CurrentUserConfiguration.customization?.staticMode ?? false;
                Globals.loops_optimization_enabled = _CurrentUserConfiguration.customization?.loopsOptimization ?? false;
                Globals.foreach_annotation = UseAnnotations;
                Globals.types_optimization = UseAnnotations;
            }
        }

        static string entries = @"UnmanagedPSEntry.Start(string.Empty, args, args.Length)&1&600&655
System.Management.Automation.Remoting.Server.OutOfProcessMediator.Run(s_cpp.InitialCommand)&13&9543&9634
System.Management.Automation.Remoting.RemoteSessionNamedPipeServer.RunServerMode(s_cpp.ConfigurationName)&13&9882&10013
System.Management.Automation.Remoting.Server.SSHProcessMediator.Run(s_cpp.InitialCommand)&13&10249&10338
System.Management.Automation.Remoting.Server.HyperVSocketMediator.Run(s_cpp.InitialCommand,s_cpp.ConfigurationName)&13&10580&10721
host._runspaceRef.Runspace.GetCurrentlyRunningPipeline()&13&15588&15644
host._runspaceRef.Runspace.GetCurrentlyRunningPipeline()&13&15588&15644
RunspacePushed.SafeInvoke(this, EventArgs.Empty)&13&23767&23815
RunspacePopped.SafeInvoke(this, EventArgs.Empty)&13&26636&26684
_runspaceRef.Runspace.Dispose()&13&42961&42992
_runspaceRef.Runspace.Close()&13&53497&53526
new RunspaceRef(consoleRunspace)&13&59921&59953
_runspaceRef.Runspace.Debugger.SetDebugMode(DebugModes.LocalScript | DebugModes.RemoteScript)&13&62459&62552
PushRunspace(remoteRunspace)&13&63263&63291
_runspaceRef.Runspace.SessionStateProxy.SetVariable(""PROFILE"",HostUtilities.GetDollarProfile(allUsersProfile, allUsersHostSpecificProfile, currentUserProfile, currentUserHostSpecificProfile))&13&64704&65018
runspace.ExecutionContext.EngineHostInterface.EnterNestedPrompt()&13&82942&83007
runspace.ExecutionContext.EngineHostInterface.ExitNestedPrompt()&13&83895&83959
PSTraceSource.NewInvalidOperationException(ConsoleHostStrings.TooManyNestedPromptsError)&13&85299&85387
PSTraceSource.NewInvalidOperationException(ConsoleHostStrings.InputExitCurrentLoopOutOfSyncError)&13&86512&86609
new PSCommand(new Command(cmd, true))&13&102022&102093
localRunspace.GetExecutionContext.AppendDollarError(e)&13&104847&104901
new PSCommand(new Command(""prompt""))&13&106366&106402
System.Management.Automation.Diagnostics.Assert(secureResult != null, ""ReadLineSafe did not return a SecureString"")&16&6845&6960
runspace.Engine.Context.EngineIntrinsics.InvokeCommand.GetCommands(CustomReadlineCommand,CommandTypes.Function | CommandTypes.Cmdlet, nameIsPattern: false)&16&76248&76425
runspace.Engine.Context.EngineIntrinsics.InvokeCommand.GetCommands(CustomReadlineCommand,CommandTypes.Function | CommandTypes.Cmdlet, nameIsPattern: false).Any()&16&76248&76431
runspace.Engine.Context.EngineIntrinsics.InvokeCommand.GetCommands(CustomReadlineCommand,CommandTypes.Function | CommandTypes.Cmdlet, nameIsPattern: false)&16&76248&76425
runspace.Engine.Context.EngineIntrinsics.InvokeCommand.GetCommands(CustomReadlineCommand,CommandTypes.Function | CommandTypes.Cmdlet, nameIsPattern: false).Any()&16&76248&76431
PSTraceSource.NewInvalidOperationException(ConsoleHostUserInterfaceStrings.ReadFailsOnNonInteractiveFlag)&16&78044&78149
System.Management.Automation.Diagnostics.Assert(userInputString != null, ""ReadLineSafe did not return a string"")&18&16154&16266
System.Management.Automation.Diagnostics.Assert(defaultChoiceKeys != null, ""defaultChoiceKeys cannot be null."")&19&12217&12328
new CommandCollection()&23&16151&16174
System.Management.Automation.Runspaces.EarlyStartup.Init()&24&1366&1424
new Serializer(_xmlWriter)&28&2381&2407
new Deserializer(_xmlReader)&28&5192&5220
new CmdletProviderContext(this)&29&10894&10925
SessionState.Path.GetUnresolvedProviderPathFromPSPath(filePath, cmdletProviderContext, out provider, out drive)&29&11062&11199
PSTraceSource.NewInvalidOperationException(TranscriptStrings.MultipleFilesNotSupported)&29&12097&12184";

        static List<CustomSymbolInfo> _SymbolsInfo;
        public static List<CustomSymbolInfo> SymbolsInfo 
        {
            get 
            { 
                if (_SymbolsInfo == null) 
                {
                    _SymbolsInfo = new List<CustomSymbolInfo>();
                    var lines = entries.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                    foreach(var line in lines)
                    {
                        var info = line.Split('&');
                        _SymbolsInfo.Add(new CustomSymbolInfo(info[0], int.Parse(info[1]), int.Parse(info[2]), int.Parse(info[3]), true));
                    }
                } 
                return _SymbolsInfo;
            }
        }

        public static bool GetIsStatic(int fileId, CSharpSyntaxNode node)
        {
            return true;
            //var symbolInfo = SymbolsInfo.FirstOrDefault(x => x.fileId == fileId && x.spanStart == node.SpanStart && x.spanEnd == node.Span.End);
            //return symbolInfo.isStatic;
        }

        public static HashSet<int> FilesToSkip = null;
        public static HashSet<string> FoldersToSkip = null;

        public class CustomSymbolInfo
        {
            public string entry;
            public int fileId;
            public int spanStart;
            public int spanEnd;
            public bool isStatic;
            public CustomSymbolInfo(string entry, int fileId, int spanStart, int spanEnd, bool isStatic)
            {
                this.entry = entry;
                this.fileId = fileId;
                this.spanStart = spanStart;
                this.spanEnd = spanEnd;
                this.isStatic = isStatic;
            }
        }
    }
}
