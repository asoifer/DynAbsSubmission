
using System;
public class TSP
{
private static int cities;

private static bool printResult ;

private static bool printMsgs ;

public static void Main(String[] args)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterStaticMethod(3,775,1799);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,821,840);

f_3_821_839(args);

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,846,917) || true) && (printMsgs)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(3,846,917);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,864,917);

f_3_864_916("Building tree of size " + DynAbs.Tracing.TraceSender.TraceInvocationWrapper(() => (cities).ToString(),3,909,915));
DynAbs.Tracing.TraceSender.TraceExitCondition(3,846,917);
}
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,923,956);

var 
start0 = f_3_936_955()
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,960,1019);

Tree 
t = f_3_969_1018(cities, false, 0.0, 1.0, 0.0, 1.0)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,1023,1054);

var 
end0 = f_3_1034_1053()
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,1060,1093);

var 
start1 = f_3_1073_1092()
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,1097,1108);

f_3_1097_1107(		t, 150);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,1112,1143);

var 
end1 = f_3_1123_1142()
;

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,1149,1252) || true) && (printResult)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(3,1149,1252);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,1227,1247);

f_3_1227_1246(			// if the user specifies, print the final result
			t);
DynAbs.Tracing.TraceSender.TraceExitCondition(3,1149,1252);
}

if ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,1258,1560) || true) && (printMsgs)
) 

{DynAbs.Tracing.TraceSender.TraceEnterCondition(3,1258,1560);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,1284,1373);

f_3_1284_1372("Tsp build time  " + DynAbs.Tracing.TraceSender.TraceInvocationWrapper(() => ((f_3_1324_1363(f_3_1324_1345(ref end0, start0)))/1000.0).ToString(),3,1323,1371));
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,1379,1461);

f_3_1379_1460("Tsp time " + DynAbs.Tracing.TraceSender.TraceInvocationWrapper(() => ((f_3_1412_1451(f_3_1412_1433(ref end1, start1)))/1000.0).ToString(),3,1411,1459));
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,1467,1555);

f_3_1467_1554("Tsp total time " + DynAbs.Tracing.TraceSender.TraceInvocationWrapper(() => ((f_3_1506_1545(f_3_1506_1527(ref end1, start0)))/1000.0).ToString(),3,1505,1553));
DynAbs.Tracing.TraceSender.TraceExitCondition(3,1258,1560);
}
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,1570,1597);

var 
slicingVariable1 = t.x
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,1607,1634);

var 
slicingVariable2 = t.y
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,1644,1674);

var 
slicingVariable3 = t.next
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,1684,1716);

var 
slicingVariable4 = t.next.x
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,1726,1758);

var 
slicingVariable5 = t.next.y
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,1768,1795);

f_3_1768_1794("Done!");
DynAbs.Tracing.TraceSender.TraceExitStaticMethod(3,775,1799);

int
f_3_821_839(string[]
args)
{
parseCmdLine( args);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 821, 839);
return 0;
}


int
f_3_864_916(string
value)
{
Console.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 864, 916);
return 0;
}


System.DateTime
f_3_936_955()
{
var return_v = System.DateTime.Now;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(3, 936, 955);
return return_v;
}


Tree
f_3_969_1018(int
n,bool
dir,double
min_x,double
max_x,double
min_y,double
max_y)
{
var return_v = Tree.buildTree( n, dir, min_x, max_x, min_y, max_y);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 969, 1018);
return return_v;
}


System.DateTime
f_3_1034_1053()
{
var return_v = System.DateTime.Now;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(3, 1034, 1053);
return return_v;
}


System.DateTime
f_3_1073_1092()
{
var return_v = System.DateTime.Now;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(3, 1073, 1092);
return return_v;
}


Tree
f_3_1097_1107(Tree
this_param,int
sz)
{
var return_v = this_param.tsp( sz);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 1097, 1107);
return return_v;
}


System.DateTime
f_3_1123_1142()
{
var return_v = System.DateTime.Now;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(3, 1123, 1142);
return return_v;
}


int
f_3_1227_1246(Tree
this_param)
{
this_param.printVisitOrder();
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 1227, 1246);
return 0;
}


System.TimeSpan
f_3_1324_1345(ref System.DateTime
this_param,System.DateTime
value)
{
var return_v = this_param.Subtract( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 1324, 1345);
return return_v;
}


double
f_3_1324_1363(System.TimeSpan
this_param)
{
var return_v = this_param.TotalMilliseconds;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(3, 1324, 1363);
return return_v;
}


int
f_3_1284_1372(string
value)
{
Console.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 1284, 1372);
return 0;
}


System.TimeSpan
f_3_1412_1433(ref System.DateTime
this_param,System.DateTime
value)
{
var return_v = this_param.Subtract( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 1412, 1433);
return return_v;
}


double
f_3_1412_1451(System.TimeSpan
this_param)
{
var return_v = this_param.TotalMilliseconds;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(3, 1412, 1451);
return return_v;
}


int
f_3_1379_1460(string
value)
{
Console.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 1379, 1460);
return 0;
}


System.TimeSpan
f_3_1506_1527(ref System.DateTime
this_param,System.DateTime
value)
{
var return_v = this_param.Subtract( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 1506, 1527);
return return_v;
}


double
f_3_1506_1545(System.TimeSpan
this_param)
{
var return_v = this_param.TotalMilliseconds;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(3, 1506, 1545);
return return_v;
}


int
f_3_1467_1554(string
value)
{
Console.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 1467, 1554);
return 0;
}


int
f_3_1768_1794(string
value)
{
Console.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 1768, 1794);
return 0;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(3,775,1799);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(3,775,1799);
}
		}

private static void parseCmdLine(String[] args)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterStaticMethod(3,1903,2474);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,1958,1968);

int 
i = 0
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,1972,1983);

String 
arg
=default(String);
try {
while((DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,1989,2437) || true) && (i < f_3_1999_2010(args)&&(DynAbs.Tracing.TraceSender.Expression_True(3, 1995, 2037)&&f_3_2014_2037(args[i], "-")))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(3,1989,2437);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,2048,2064);

arg = args[i++];

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,2071,2432) || true) && (f_3_2074_2090(arg, "-c"))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(3,2071,2432);

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,2103,2238) || true) && (i < f_3_2110_2121(args))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(3,2103,2238);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,2129,2168);

cities = f_3_2138_2167(args[i++]);
DynAbs.Tracing.TraceSender.TraceExitCondition(3,2103,2238);
}

else 

{DynAbs.Tracing.TraceSender.TraceEnterCondition(3,2103,2238);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,2186,2238);

throw f_3_2192_2237("-c requires the size of tree");
DynAbs.Tracing.TraceSender.TraceExitCondition(3,2103,2238);
}
DynAbs.Tracing.TraceSender.TraceExitCondition(3,2071,2432);
}

else 
{DynAbs.Tracing.TraceSender.TraceEnterCondition(3,2071,2432);

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,2254,2432) || true) && (f_3_2257_2273(arg, "-p"))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(3,2254,2432);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,2286,2305);

printResult = true;
DynAbs.Tracing.TraceSender.TraceExitCondition(3,2254,2432);
}

else 
{DynAbs.Tracing.TraceSender.TraceEnterCondition(3,2254,2432);

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,2321,2432) || true) && (f_3_2324_2340(arg, "-m"))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(3,2321,2432);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,2353,2370);

printMsgs = true;
DynAbs.Tracing.TraceSender.TraceExitCondition(3,2321,2432);
}

else 
{DynAbs.Tracing.TraceSender.TraceEnterCondition(3,2321,2432);

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,2386,2432) || true) && (f_3_2389_2405(arg, "-h"))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(3,2386,2432);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,2418,2426);

f_3_2418_2425();
DynAbs.Tracing.TraceSender.TraceExitCondition(3,2386,2432);
}
DynAbs.Tracing.TraceSender.TraceExitCondition(3,2321,2432);
}
DynAbs.Tracing.TraceSender.TraceExitCondition(3,2254,2432);
}
DynAbs.Tracing.TraceSender.TraceExitCondition(3,2071,2432);
}
DynAbs.Tracing.TraceSender.TraceExitCondition(3,1989,2437);
}
}catch(System.Exception) { DynAbs.Tracing.TraceSender.TraceExitLoopByException(3,1989,2437);
 throw; }finally{DynAbs.Tracing.TraceSender.TraceExitLoop(3,1989,2437);
}
if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,2441,2470) || true) && (cities == 0)
) 

{DynAbs.Tracing.TraceSender.TraceEnterCondition(3,2441,2470);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,2462,2470);

f_3_2462_2469();
DynAbs.Tracing.TraceSender.TraceExitCondition(3,2441,2470);
}
DynAbs.Tracing.TraceSender.TraceExitStaticMethod(3,1903,2474);

int
f_3_1999_2010(string[]
this_param)
{
var return_v = this_param.Length ;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(3, 1999, 2010);
return return_v;
}


bool
f_3_2014_2037(string
this_param,string
value)
{
var return_v = this_param.StartsWith( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 2014, 2037);
return return_v;
}


bool
f_3_2074_2090(string
this_param,string
value)
{
var return_v = this_param.Equals( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 2074, 2090);
return return_v;
}


int
f_3_2110_2121(string[]
this_param)
{
var return_v = this_param.Length;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(3, 2110, 2121);
return return_v;
}


int
f_3_2138_2167(string
s)
{
var return_v = System.Int32.Parse( s);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 2138, 2167);
return return_v;
}


System.Exception
f_3_2192_2237(string
message)
{
var return_v = new System.Exception( message);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 2192, 2237);
return return_v;
}


bool
f_3_2257_2273(string
this_param,string
value)
{
var return_v = this_param.Equals( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 2257, 2273);
return return_v;
}


bool
f_3_2324_2340(string
this_param,string
value)
{
var return_v = this_param.Equals( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 2324, 2340);
return return_v;
}


bool
f_3_2389_2405(string
this_param,string
value)
{
var return_v = this_param.Equals( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 2389, 2405);
return return_v;
}


int
f_3_2418_2425()
{
usage();
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 2418, 2425);
return 0;
}


int
f_3_2462_2469()
{
usage();
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 2462, 2469);
return 0;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(3,1903,2474);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(3,1903,2474);
}
		}

private static void usage()
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterStaticMethod(3,2552,2946);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,2587,2648);

f_3_2587_2647("usage: java TSP -c <num> [-p] [-m] [-h]");
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,2652,2740);

f_3_2652_2739("    -c number of cities (rounds up to the next power of 2 minus 1)");
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,2744,2797);

f_3_2744_2796("    -p (print the final result)");
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,2801,2858);

f_3_2801_2857("    -m (print informative messages)");
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,2862,2911);

f_3_2862_2910("    -h (print this message)");
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,2915,2942);

f_3_2915_2941(0);
DynAbs.Tracing.TraceSender.TraceExitStaticMethod(3,2552,2946);

int
f_3_2587_2647(string
value)
{
Console.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 2587, 2647);
return 0;
}


int
f_3_2652_2739(string
value)
{
Console.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 2652, 2739);
return 0;
}


int
f_3_2744_2796(string
value)
{
Console.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 2744, 2796);
return 0;
}


int
f_3_2801_2857(string
value)
{
Console.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 2801, 2857);
return 0;
}


int
f_3_2862_2910(string
value)
{
Console.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 2862, 2910);
return 0;
}


int
f_3_2915_2941(int
exitCode)
{
System.Environment.Exit( exitCode);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 2915, 2941);
return 0;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(3,2552,2946);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(3,2552,2946);
}
		}

public TSP()
{
DynAbs.Tracing.TraceSender.TraceEnterConstructor(3,346,2949);
DynAbs.Tracing.TraceSender.TraceExitConstructor(3,346,2949);

DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(3,346,2949);
}


static TSP()
{
DynAbs.Tracing.TraceSender.TraceEnterStaticConstructor(3,346,2949);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,438,444);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,530,549);
printResult = false;DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,633,650);
printMsgs = false;DynAbs.Tracing.TraceSender.TraceExitStaticConstructor(3,346,2949);

DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(3,346,2949);
}

		int ___ignore_me___=DynAbs.Tracing.TraceSender.TraceBeforeConstructor(3,346,2949);
}
