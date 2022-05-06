using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
public class BiSort
{
private static int treesize ;

private static bool printMsgs ;

private static bool printResults ;

public static void Main(String[] args)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterStaticMethod(1,1066,2560);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1112,1131);

f_1_1112_1130(args);

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1137,1212) || true) && (printMsgs)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,1137,1212);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1155,1212);

f_1_1155_1211("Bisort with " + DynAbs.Tracing.TraceSender.TraceInvocationWrapper(() => (treesize).ToString(),1,1190,1198)+ " values");
DynAbs.Tracing.TraceSender.TraceExitCondition(1,1137,1212);
}
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1218,1251);

var 
start2 = f_1_1231_1250()
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1255,1305);

Value 
tree = f_1_1268_1304(treesize, 12345768)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1309,1340);

var 
end2 = f_1_1320_1339()
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1344,1390);

int 
sval = f_1_1355_1375(245867)% Value.RANGE
;

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1396,1467) || true) && (printResults)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,1396,1467);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1422,1437);

f_1_1422_1436(			tree);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1442,1462);

f_1_1442_1461(sval);
DynAbs.Tracing.TraceSender.TraceExitCondition(1,1396,1467);
}

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1473,1550) || true) && (printMsgs)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,1473,1550);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1491,1550);

f_1_1491_1549("BEGINNING BITONIC SORT ALGORITHM HERE");
DynAbs.Tracing.TraceSender.TraceExitCondition(1,1473,1550);
}
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1556,1589);

var 
start0 = f_1_1569_1588()
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1593,1633);

sval = f_1_1600_1632(tree, sval, Value.FORWARD);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1643,1674);

var 
end0 = f_1_1654_1673()
;

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1682,1753) || true) && (printResults)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,1682,1753);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1708,1723);

f_1_1708_1722(			tree);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1728,1748);

f_1_1728_1747(sval);
DynAbs.Tracing.TraceSender.TraceExitCondition(1,1682,1753);
}
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1765,1798);

var 
start1 = f_1_1778_1797()
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1802,1843);

sval = f_1_1809_1842(tree, sval, Value.BACKWARD);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1847,1878);

var 
end1 = f_1_1858_1877()
;

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1886,1957) || true) && (printResults)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,1886,1957);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1912,1927);

f_1_1912_1926(			tree);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1932,1952);

f_1_1932_1951(sval);
DynAbs.Tracing.TraceSender.TraceExitCondition(1,1886,1957);
}

if ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1963,2388) || true) && (printMsgs)
) 

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,1963,2388);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1989,2077);

f_1_1989_2076("Creation time: " + DynAbs.Tracing.TraceSender.TraceInvocationWrapper(() => ((f_1_2028_2067(f_1_2028_2049(ref end2, start2)))/1000.0).ToString(),1,2027,2075));
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2089,2186);

f_1_2089_2185("Time to sort forward = " + DynAbs.Tracing.TraceSender.TraceInvocationWrapper(() => ((f_1_2136_2175(f_1_2136_2157(ref end0, start0))) /1000.0).ToString(),1,2135,2184));
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2198,2296);

f_1_2198_2295("Time to sort backward = " + DynAbs.Tracing.TraceSender.TraceInvocationWrapper(() => ((f_1_2246_2285(f_1_2246_2267(ref end1, start1))) /1000.0).ToString(),1,2245,2294));
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2302,2383);

f_1_2302_2382("Total: " + DynAbs.Tracing.TraceSender.TraceInvocationWrapper(() => ((f_1_2333_2372(f_1_2333_2354(ref end1, start0))) /1000.0).ToString(),1,2332,2381));
DynAbs.Tracing.TraceSender.TraceExitCondition(1,1963,2388);
}
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2398,2426);

var 
slicingVariable1 = sval
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2436,2470);

var 
slicingVariable2 = tree.value
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2480,2519);

var 
slicingVariable3 = tree.left.value
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2529,2556);

f_1_2529_2555("Done!");
DynAbs.Tracing.TraceSender.TraceExitStaticMethod(1,1066,2560);

int
f_1_1112_1130(string[]
args)
{
parseCmdLine( args);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 1112, 1130);
return 0;
}


int
f_1_1155_1211(string
value)
{
Console.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 1155, 1211);
return 0;
}


System.DateTime
f_1_1231_1250()
{
var return_v = System.DateTime.Now;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(1, 1231, 1250);
return return_v;
}


Value
f_1_1268_1304(int
size,int
seed)
{
var return_v = Value.createTree( size, seed);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 1268, 1304);
return return_v;
}


System.DateTime
f_1_1320_1339()
{
var return_v = System.DateTime.Now;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(1, 1320, 1339);
return return_v;
}


int
f_1_1355_1375(int
seed)
{
var return_v = Value.random( seed);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 1355, 1375);
return return_v;
}


int
f_1_1422_1436(Value
this_param)
{
this_param.inOrder();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 1422, 1436);
return 0;
}


int
f_1_1442_1461(int
value)
{
Console.Write( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 1442, 1461);
return 0;
}


int
f_1_1491_1549(string
value)
{
Console.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 1491, 1549);
return 0;
}


System.DateTime
f_1_1569_1588()
{
var return_v = System.DateTime.Now;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(1, 1569, 1588);
return return_v;
}


int
f_1_1600_1632(Value
this_param,int
spr_val,bool
direction)
{
var return_v = this_param.bisort( spr_val, direction);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 1600, 1632);
return return_v;
}


System.DateTime
f_1_1654_1673()
{
var return_v = System.DateTime.Now;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(1, 1654, 1673);
return return_v;
}


int
f_1_1708_1722(Value
this_param)
{
this_param.inOrder();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 1708, 1722);
return 0;
}


int
f_1_1728_1747(int
value)
{
Console.Write( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 1728, 1747);
return 0;
}


System.DateTime
f_1_1778_1797()
{
var return_v = System.DateTime.Now;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(1, 1778, 1797);
return return_v;
}


int
f_1_1809_1842(Value
this_param,int
spr_val,bool
direction)
{
var return_v = this_param.bisort( spr_val, direction);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 1809, 1842);
return return_v;
}


System.DateTime
f_1_1858_1877()
{
var return_v = System.DateTime.Now;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(1, 1858, 1877);
return return_v;
}


int
f_1_1912_1926(Value
this_param)
{
this_param.inOrder();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 1912, 1926);
return 0;
}


int
f_1_1932_1951(int
value)
{
Console.Write( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 1932, 1951);
return 0;
}


System.TimeSpan
f_1_2028_2049(ref System.DateTime
this_param,System.DateTime
value)
{
var return_v = this_param.Subtract( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 2028, 2049);
return return_v;
}


double
f_1_2028_2067(System.TimeSpan
this_param)
{
var return_v = this_param.TotalMilliseconds;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(1, 2028, 2067);
return return_v;
}


int
f_1_1989_2076(string
value)
{
Console.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 1989, 2076);
return 0;
}


System.TimeSpan
f_1_2136_2157(ref System.DateTime
this_param,System.DateTime
value)
{
var return_v = this_param.Subtract( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 2136, 2157);
return return_v;
}


double
f_1_2136_2175(System.TimeSpan
this_param)
{
var return_v = this_param.TotalMilliseconds;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(1, 2136, 2175);
return return_v;
}


int
f_1_2089_2185(string
value)
{
Console.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 2089, 2185);
return 0;
}


System.TimeSpan
f_1_2246_2267(ref System.DateTime
this_param,System.DateTime
value)
{
var return_v = this_param.Subtract( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 2246, 2267);
return return_v;
}


double
f_1_2246_2285(System.TimeSpan
this_param)
{
var return_v = this_param.TotalMilliseconds;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(1, 2246, 2285);
return return_v;
}


int
f_1_2198_2295(string
value)
{
Console.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 2198, 2295);
return 0;
}


System.TimeSpan
f_1_2333_2354(ref System.DateTime
this_param,System.DateTime
value)
{
var return_v = this_param.Subtract( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 2333, 2354);
return return_v;
}


double
f_1_2333_2372(System.TimeSpan
this_param)
{
var return_v = this_param.TotalMilliseconds;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(1, 2333, 2372);
return return_v;
}


int
f_1_2302_2382(string
value)
{
Console.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 2302, 2382);
return 0;
}


int
f_1_2529_2555(string
value)
{
Console.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 2529, 2555);
return 0;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(1,1066,2560);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(1,1066,2560);
}
		}

private static void parseCmdLine(String[] args)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterStaticMethod(1,2664,3247);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2719,2729);

int 
i = 0
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2733,2744);

String 
arg
=default(String);
try {
while((DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2750,3209) || true) && (i < f_1_2760_2771(args)&&(DynAbs.Tracing.TraceSender.Expression_True(1, 2756, 2798)&&f_1_2775_2798(args[i], "-")))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,2750,3209);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2809,2825);

arg = args[i++];

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2880,3204) || true) && (f_1_2883_2899(arg, "-s"))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,2880,3204);

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2912,3045) || true) && (i < f_1_2919_2930(args))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,2912,3045);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2938,2972);

treesize = f_1_2949_2971(args[i++]);
DynAbs.Tracing.TraceSender.TraceExitCondition(1,2912,3045);
}

else

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,2912,3045);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2989,3045);

throw f_1_2995_3044("-l requires the number of levels");
DynAbs.Tracing.TraceSender.TraceExitCondition(1,2912,3045);
}
DynAbs.Tracing.TraceSender.TraceExitCondition(1,2880,3204);
}

else 
{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,2880,3204);

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,3061,3204) || true) && (f_1_3064_3080(arg, "-p"))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,3061,3204);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,3087,3107);

printResults = true;
DynAbs.Tracing.TraceSender.TraceExitCondition(1,3061,3204);
}

else 
{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,3061,3204);

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,3117,3204) || true) && (f_1_3120_3136(arg, "-m"))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,3117,3204);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,3143,3160);

printMsgs = true;
DynAbs.Tracing.TraceSender.TraceExitCondition(1,3117,3204);
}

else 
{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,3117,3204);

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,3170,3204) || true) && (f_1_3173_3189(arg, "-h"))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,3170,3204);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,3196,3204);

f_1_3196_3203();
DynAbs.Tracing.TraceSender.TraceExitCondition(1,3170,3204);
}
DynAbs.Tracing.TraceSender.TraceExitCondition(1,3117,3204);
}
DynAbs.Tracing.TraceSender.TraceExitCondition(1,3061,3204);
}
DynAbs.Tracing.TraceSender.TraceExitCondition(1,2880,3204);
}
DynAbs.Tracing.TraceSender.TraceExitCondition(1,2750,3209);
}
}catch(System.Exception) { DynAbs.Tracing.TraceSender.TraceExitLoopByException(1,2750,3209);
 throw; }finally{DynAbs.Tracing.TraceSender.TraceExitLoop(1,2750,3209);
}
if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,3213,3243) || true) && (treesize == 0)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,3213,3243);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,3235,3243);

f_1_3235_3242();
DynAbs.Tracing.TraceSender.TraceExitCondition(1,3213,3243);
}
DynAbs.Tracing.TraceSender.TraceExitStaticMethod(1,2664,3247);

int
f_1_2760_2771(string[]
this_param)
{
var return_v = this_param.Length ;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(1, 2760, 2771);
return return_v;
}


bool
f_1_2775_2798(string
this_param,string
value)
{
var return_v = this_param.StartsWith( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 2775, 2798);
return return_v;
}


bool
f_1_2883_2899(string
this_param,string
value)
{
var return_v = this_param.Equals( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 2883, 2899);
return return_v;
}


int
f_1_2919_2930(string[]
this_param)
{
var return_v = this_param.Length;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(1, 2919, 2930);
return return_v;
}


int
f_1_2949_2971(string
s)
{
var return_v = Int32.Parse( s);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 2949, 2971);
return return_v;
}


System.Exception
f_1_2995_3044(string
message)
{
var return_v = new System.Exception( message);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 2995, 3044);
return return_v;
}


bool
f_1_3064_3080(string
this_param,string
value)
{
var return_v = this_param.Equals( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 3064, 3080);
return return_v;
}


bool
f_1_3120_3136(string
this_param,string
value)
{
var return_v = this_param.Equals( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 3120, 3136);
return return_v;
}


bool
f_1_3173_3189(string
this_param,string
value)
{
var return_v = this_param.Equals( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 3173, 3189);
return return_v;
}


int
f_1_3196_3203()
{
usage();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 3196, 3203);
return 0;
}


int
f_1_3235_3242()
{
usage();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 3235, 3242);
return 0;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(1,2664,3247);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(1,2664,3247);
}
		}

private static void usage()
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterStaticMethod(1,3325,3707);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,3360,3425);

f_1_3360_3424("usage: java BiSort -s <size> [-p] [-i] [-h]");
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,3429,3486);

f_1_3429_3485("    -s the number of values to sort");
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,3490,3547);

f_1_3490_3546("    -m (print informative messages)");
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,3551,3619);

f_1_3551_3618("    -p (print the binary tree after each step)");
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,3623,3672);

f_1_3623_3671("    -h (print this message)");
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,3676,3703);

f_1_3676_3702(0);
DynAbs.Tracing.TraceSender.TraceExitStaticMethod(1,3325,3707);

int
f_1_3360_3424(string
value)
{
Console.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 3360, 3424);
return 0;
}


int
f_1_3429_3485(string
value)
{
Console.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 3429, 3485);
return 0;
}


int
f_1_3490_3546(string
value)
{
Console.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 3490, 3546);
return 0;
}


int
f_1_3551_3618(string
value)
{
Console.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 3551, 3618);
return 0;
}


int
f_1_3623_3671(string
value)
{
Console.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 3623, 3671);
return 0;
}


int
f_1_3676_3702(int
exitCode)
{
System.Environment.Exit( exitCode);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 3676, 3702);
return 0;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(1,3325,3707);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(1,3325,3707);
}
		}

public BiSort()
{
DynAbs.Tracing.TraceSender.TraceEnterConstructor(1,634,3710);
DynAbs.Tracing.TraceSender.TraceExitConstructor(1,634,3710);

DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(1,634,3710);
}


static BiSort()
{
DynAbs.Tracing.TraceSender.TraceEnterStaticConstructor(1,634,3710);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,729,741);
treesize = 0;DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,816,833);
printMsgs = false;DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,909,929);
printResults = false;DynAbs.Tracing.TraceSender.TraceExitStaticConstructor(1,634,3710);

DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(1,634,3710);
}

		int ___ignore_me___=DynAbs.Tracing.TraceSender.TraceBeforeConstructor(1,634,3710);
}
