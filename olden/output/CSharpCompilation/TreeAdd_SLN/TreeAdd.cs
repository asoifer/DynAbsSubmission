
using System;
public class TreeAdd
{
private static int levels ;

private static bool printResult ;

private static bool printMsgs ;

public static void Main(string[] args)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterStaticMethod(1,756,1576);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,802,821);

f_1_802_820(args);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,829,862);

var 
start0 = f_1_842_861()
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,866,903);

TreeNode 
root = f_1_882_902(levels)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,907,938);

var 
end0 = f_1_918_937()
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,946,979);

var 
start1 = f_1_959_978()
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,983,1011);

int 
result = f_1_996_1010(root)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1015,1046);

var 
end1 = f_1_1026_1045()
;

if ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1054,1146) || true) && (printResult ||(DynAbs.Tracing.TraceSender.Expression_False(1, 1058, 1082)||printMsgs))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,1054,1146);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1088,1146);

f_1_1088_1145("Received results of " + DynAbs.Tracing.TraceSender.TraceInvocationWrapper(() => (result).ToString(),1,1138,1144));
DynAbs.Tracing.TraceSender.TraceExitCondition(1,1054,1146);
}

if ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1154,1494) || true) && (printMsgs)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,1154,1494);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1178,1279);

f_1_1178_1278("Treeadd alloc time " + DynAbs.Tracing.TraceSender.TraceInvocationWrapper(() => ((f_1_1228_1267(f_1_1228_1249(ref end0, start0))) / 1000.0).ToString(),1,1227,1277));
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1284,1383);

f_1_1284_1382("Treeadd add time " + DynAbs.Tracing.TraceSender.TraceInvocationWrapper(() => ((f_1_1332_1371(f_1_1332_1353(ref end1, start1))) / 1000.0).ToString(),1,1331,1381));
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1388,1489);

f_1_1388_1488("Treeadd total time " + DynAbs.Tracing.TraceSender.TraceInvocationWrapper(() => ((f_1_1438_1477(f_1_1438_1459(ref end1, start0))) / 1000.0).ToString(),1,1437,1487));
DynAbs.Tracing.TraceSender.TraceExitCondition(1,1154,1494);
}
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1504,1534);

var 
slicingVariable1 = result
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1538,1572);

f_1_1538_1571("Done!");
DynAbs.Tracing.TraceSender.TraceExitStaticMethod(1,756,1576);

int
f_1_802_820(string[]
args)
{
parseCmdLine( args);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 802, 820);
return 0;
}


System.DateTime
f_1_842_861()
{
var return_v = System.DateTime.Now;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(1, 842, 861);
return return_v;
}


TreeNode
f_1_882_902(int
levels)
{
var return_v = new TreeNode( levels);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 882, 902);
return return_v;
}


System.DateTime
f_1_918_937()
{
var return_v = System.DateTime.Now;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(1, 918, 937);
return return_v;
}


System.DateTime
f_1_959_978()
{
var return_v = System.DateTime.Now;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(1, 959, 978);
return return_v;
}


int
f_1_996_1010(TreeNode
this_param)
{
var return_v = this_param.addTree();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 996, 1010);
return return_v;
}


System.DateTime
f_1_1026_1045()
{
var return_v = System.DateTime.Now;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(1, 1026, 1045);
return return_v;
}


int
f_1_1088_1145(string
value)
{
System.Console.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 1088, 1145);
return 0;
}


System.TimeSpan
f_1_1228_1249(ref System.DateTime
this_param,System.DateTime
value)
{
var return_v = this_param.Subtract( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 1228, 1249);
return return_v;
}


double
f_1_1228_1267(System.TimeSpan
this_param)
{
var return_v = this_param.TotalMilliseconds;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(1, 1228, 1267);
return return_v;
}


int
f_1_1178_1278(string
value)
{
System.Console.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 1178, 1278);
return 0;
}


System.TimeSpan
f_1_1332_1353(ref System.DateTime
this_param,System.DateTime
value)
{
var return_v = this_param.Subtract( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 1332, 1353);
return return_v;
}


double
f_1_1332_1371(System.TimeSpan
this_param)
{
var return_v = this_param.TotalMilliseconds;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(1, 1332, 1371);
return return_v;
}


int
f_1_1284_1382(string
value)
{
System.Console.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 1284, 1382);
return 0;
}


System.TimeSpan
f_1_1438_1459(ref System.DateTime
this_param,System.DateTime
value)
{
var return_v = this_param.Subtract( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 1438, 1459);
return return_v;
}


double
f_1_1438_1477(System.TimeSpan
this_param)
{
var return_v = this_param.TotalMilliseconds;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(1, 1438, 1477);
return return_v;
}


int
f_1_1388_1488(string
value)
{
System.Console.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 1388, 1488);
return 0;
}


int
f_1_1538_1571(string
value)
{
System.Console.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 1538, 1571);
return 0;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(1,756,1576);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(1,756,1576);
}
		}

private static void parseCmdLine(string[] args)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterStaticMethod(1,1674,2279);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1729,1739);

int 
i = 0
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1743,1754);

string 
arg
=default(string);
try {
while ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1762,2242) || true) && (i < f_1_1773_1784(args)&&(DynAbs.Tracing.TraceSender.Expression_True(1, 1769, 1811)&&f_1_1788_1811(args[i], "-")))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,1762,2242);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1822,1838);

arg = args[i++];

if ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1843,2237) || true) && (f_1_1847_1863(arg, "-l"))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,1843,2237);

if ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1876,2040) || true) && (i < f_1_1884_1895(args))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,1876,2040);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1910,1953);

levels = f_1_1919_1952(args[i++]);
DynAbs.Tracing.TraceSender.TraceExitCondition(1,1876,2040);
}

else

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,1876,2040);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1977,2040);

throw f_1_1983_2039("-l requires the number of levels");
DynAbs.Tracing.TraceSender.TraceExitCondition(1,1876,2040);
}
DynAbs.Tracing.TraceSender.TraceExitCondition(1,1843,2237);
}

else 
{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,1843,2237);

if ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2056,2237) || true) && (f_1_2060_2076(arg, "-p"))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,2056,2237);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2089,2108);

printResult = true;
DynAbs.Tracing.TraceSender.TraceExitCondition(1,2056,2237);
}

else 
{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,2056,2237);

if ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2124,2237) || true) && (f_1_2128_2144(arg, "-m"))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,2124,2237);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2157,2174);

printMsgs = true;
DynAbs.Tracing.TraceSender.TraceExitCondition(1,2124,2237);
}

else 
{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,2124,2237);

if ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2190,2237) || true) && (f_1_2194_2210(arg, "-h"))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,2190,2237);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2223,2231);

f_1_2223_2230();
DynAbs.Tracing.TraceSender.TraceExitCondition(1,2190,2237);
}
DynAbs.Tracing.TraceSender.TraceExitCondition(1,2124,2237);
}
DynAbs.Tracing.TraceSender.TraceExitCondition(1,2056,2237);
}
DynAbs.Tracing.TraceSender.TraceExitCondition(1,1843,2237);
}
DynAbs.Tracing.TraceSender.TraceExitCondition(1,1762,2242);
}
}catch(System.Exception) { DynAbs.Tracing.TraceSender.TraceExitLoopByException(1,1762,2242);
 throw; }finally{DynAbs.Tracing.TraceSender.TraceExitLoop(1,1762,2242);
}
if ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2246,2275) || true) && (levels == 0)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,2246,2275);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2267,2275);

f_1_2267_2274();
DynAbs.Tracing.TraceSender.TraceExitCondition(1,2246,2275);
}
DynAbs.Tracing.TraceSender.TraceExitStaticMethod(1,1674,2279);

int
f_1_1773_1784(string[]
this_param)
{
var return_v = this_param.Length ;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(1, 1773, 1784);
return return_v;
}


bool
f_1_1788_1811(string
this_param,string
value)
{
var return_v = this_param.StartsWith( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 1788, 1811);
return return_v;
}


bool
f_1_1847_1863(string
this_param,string
value)
{
var return_v = this_param.Equals( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 1847, 1863);
return return_v;
}


int
f_1_1884_1895(string[]
this_param)
{
var return_v = this_param.Length;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(1, 1884, 1895);
return return_v;
}


int
f_1_1919_1952(string
value)
{
var return_v = System.Convert.ToInt32( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 1919, 1952);
return return_v;
}


System.Exception
f_1_1983_2039(string
message)
{
var return_v = new System.Exception( message);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 1983, 2039);
return return_v;
}


bool
f_1_2060_2076(string
this_param,string
value)
{
var return_v = this_param.Equals( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 2060, 2076);
return return_v;
}


bool
f_1_2128_2144(string
this_param,string
value)
{
var return_v = this_param.Equals( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 2128, 2144);
return return_v;
}


bool
f_1_2194_2210(string
this_param,string
value)
{
var return_v = this_param.Equals( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 2194, 2210);
return return_v;
}


int
f_1_2223_2230()
{
usage();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 2223, 2230);
return 0;
}


int
f_1_2267_2274()
{
usage();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 2267, 2274);
return 0;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(1,1674,2279);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(1,1674,2279);
}
		}

private static void usage()
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterStaticMethod(1,2358,2786);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2393,2474);

f_1_2393_2473(f_1_2393_2413(), "usage: java TreeAdd -l <levels> [-p] [-m] [-h]");
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2478,2552);

f_1_2478_2551(f_1_2478_2498(), "    -l the number of levels in the tree");
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2556,2626);

f_1_2556_2625(f_1_2556_2576(), "    -m (print informative messages)");
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2630,2691);

f_1_2630_2690(f_1_2630_2650(), "    -p (print the result>)");
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2695,2751);

f_1_2695_2750(f_1_2695_2715(), "    -h (this message)");
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2755,2782);

f_1_2755_2781(0);
DynAbs.Tracing.TraceSender.TraceExitStaticMethod(1,2358,2786);

System.IO.TextWriter
f_1_2393_2413()
{
var return_v = 		System.Console.Error;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(1, 2393, 2413);
return return_v;
}


int
f_1_2393_2473(System.IO.TextWriter
this_param,string
value)
{
this_param.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 2393, 2473);
return 0;
}


System.IO.TextWriter
f_1_2478_2498()
{
var return_v = 		System.Console.Error;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(1, 2478, 2498);
return return_v;
}


int
f_1_2478_2551(System.IO.TextWriter
this_param,string
value)
{
this_param.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 2478, 2551);
return 0;
}


System.IO.TextWriter
f_1_2556_2576()
{
var return_v = 		System.Console.Error;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(1, 2556, 2576);
return return_v;
}


int
f_1_2556_2625(System.IO.TextWriter
this_param,string
value)
{
this_param.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 2556, 2625);
return 0;
}


System.IO.TextWriter
f_1_2630_2650()
{
var return_v = 		System.Console.Error;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(1, 2630, 2650);
return return_v;
}


int
f_1_2630_2690(System.IO.TextWriter
this_param,string
value)
{
this_param.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 2630, 2690);
return 0;
}


System.IO.TextWriter
f_1_2695_2715()
{
var return_v = 		System.Console.Error;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(1, 2695, 2715);
return return_v;
}


int
f_1_2695_2750(System.IO.TextWriter
this_param,string
value)
{
this_param.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 2695, 2750);
return 0;
}


int
f_1_2755_2781(int
exitCode)
{
System.Environment.Exit( exitCode);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 2755, 2781);
return 0;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(1,2358,2786);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(1,2358,2786);
}
		}

public TreeAdd()
{
DynAbs.Tracing.TraceSender.TraceEnterConstructor(1,320,2789);
DynAbs.Tracing.TraceSender.TraceExitConstructor(1,320,2789);

DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(1,320,2789);
}


static TreeAdd()
{
DynAbs.Tracing.TraceSender.TraceEnterStaticConstructor(1,320,2789);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,416,426);
levels = 0;DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,508,527);
printResult = false;DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,612,629);
printMsgs = false;DynAbs.Tracing.TraceSender.TraceExitStaticConstructor(1,320,2789);

DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(1,320,2789);
}

		int ___ignore_me___=DynAbs.Tracing.TraceSender.TraceBeforeConstructor(1,320,2789);
}
