
using System;
public class Power
{
static bool printResults ;

static bool printMsgs ;

public static void Main(String[] args)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterStaticMethod(5,1288,2389);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,1406,1425);

f_5_1406_1424(args);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,1450,1483);

var 
start0 = f_5_1463_1482()
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,1487,1517);

Root 
r = f_5_1496_1516(2, 2, 2, 2)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,1521,1552);

var 
end0 = f_5_1532_1551()
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,1560,1593);

var 
start1 = f_5_1573_1592()
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,1597,1609);

f_5_1597_1608(		r);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,1613,1642);

f_5_1613_1641(		r, false, 0.7, 0.14);
try {
while((DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,1648,1817) || true) && (true)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(5,1648,1817);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,1669,1681);

f_5_1669_1680(			r);

if ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,1686,1741) || true) && (printResults)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(5,1686,1741);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,1709,1741);

f_5_1709_1740(f_5_1727_1739(r));
DynAbs.Tracing.TraceSender.TraceExitCondition(5,1686,1741);
}

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,1748,1780) || true) && (f_5_1751_1767(r))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(5,1748,1780);
DynAbs.Tracing.TraceSender.TraceBreak(5,1774,1780);

break;
DynAbs.Tracing.TraceSender.TraceExitCondition(5,1748,1780);
}
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,1787,1812);

f_5_1787_1811(
			r, printResults);
DynAbs.Tracing.TraceSender.TraceExitCondition(5,1648,1817);
}
}catch(System.Exception) { DynAbs.Tracing.TraceSender.TraceExitLoopByException(5,1648,1817);
 throw; }finally{DynAbs.Tracing.TraceSender.TraceExitLoop(5,1648,1817);
}DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,1823,1854);

var 
end1 = f_5_1834_1853()
;

if ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,1862,2177) || true) && (printMsgs)
) 

{DynAbs.Tracing.TraceSender.TraceEnterCondition(5,1862,2177);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,1888,1978);

f_5_1888_1977("Power build time " + DynAbs.Tracing.TraceSender.TraceInvocationWrapper(() => ((f_5_1929_1968(f_5_1929_1950(ref end0, start0)))/1000.0).ToString(),5,1928,1976));
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,1984,2076);

f_5_1984_2075("Power compute time " + DynAbs.Tracing.TraceSender.TraceInvocationWrapper(() => ((f_5_2027_2066(f_5_2027_2048(ref end1, start1)))/1000.0).ToString(),5,2026,2074));
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,2082,2172);

f_5_2082_2171("Power total time " + DynAbs.Tracing.TraceSender.TraceInvocationWrapper(() => ((f_5_2123_2162(f_5_2123_2144(ref end1, start0)))/1000.0).ToString(),5,2122,2170));
DynAbs.Tracing.TraceSender.TraceExitCondition(5,1862,2177);
}
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,2187,2216);

var 
slicingVariable1 = r.D.P
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,2226,2255);

var 
slicingVariable2 = r.D.Q
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,2265,2298);

var 
slicingVariable3 = r.theta_I
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,2308,2341);

var 
slicingVariable4 = r.theta_R
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,2351,2385);

f_5_2351_2384("Done!");
DynAbs.Tracing.TraceSender.TraceExitStaticMethod(5,1288,2389);

int
f_5_1406_1424(string[]
args)
{
parseCmdLine( args);
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 1406, 1424);
return 0;
}


System.DateTime
f_5_1463_1482()
{
var return_v = System.DateTime.Now;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(5, 1463, 1482);
return return_v;
}


Root
f_5_1496_1516(int
nfeeders,int
nlaterals,int
nbranches,int
nleaves)
{
var return_v = new Root( nfeeders, nlaterals, nbranches, nleaves);
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 1496, 1516);
return return_v;
}


System.DateTime
f_5_1532_1551()
{
var return_v = System.DateTime.Now;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(5, 1532, 1551);
return return_v;
}


System.DateTime
f_5_1573_1592()
{
var return_v = System.DateTime.Now;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(5, 1573, 1592);
return return_v;
}


int
f_5_1597_1608(Root
this_param)
{
this_param.compute();
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 1597, 1608);
return 0;
}


int
f_5_1613_1641(Root
this_param,bool
verbose,double
new_theta_R,double
new_theta_I)
{
this_param.nextIter( verbose, new_theta_R, new_theta_I);
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 1613, 1641);
return 0;
}


int
f_5_1669_1680(Root
this_param)
{
this_param.compute();
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 1669, 1680);
return 0;
}


string
f_5_1727_1739(Root
this_param)
{
var return_v = this_param.ToString();
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 1727, 1739);
return return_v;
}


int
f_5_1709_1740(string
value)
{
Console.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 1709, 1740);
return 0;
}


bool
f_5_1751_1767(Root
this_param)
{
var return_v = this_param.reachedLimit();
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 1751, 1767);
return return_v;
}


int
f_5_1787_1811(Root
this_param,bool
verbose)
{
this_param.nextIter( verbose);
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 1787, 1811);
return 0;
}


System.DateTime
f_5_1834_1853()
{
var return_v = System.DateTime.Now;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(5, 1834, 1853);
return return_v;
}


System.TimeSpan
f_5_1929_1950(ref System.DateTime
this_param,System.DateTime
value)
{
var return_v = this_param.Subtract( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 1929, 1950);
return return_v;
}


double
f_5_1929_1968(System.TimeSpan
this_param)
{
var return_v = this_param.TotalMilliseconds;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(5, 1929, 1968);
return return_v;
}


int
f_5_1888_1977(string
value)
{
Console.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 1888, 1977);
return 0;
}


System.TimeSpan
f_5_2027_2048(ref System.DateTime
this_param,System.DateTime
value)
{
var return_v = this_param.Subtract( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 2027, 2048);
return return_v;
}


double
f_5_2027_2066(System.TimeSpan
this_param)
{
var return_v = this_param.TotalMilliseconds;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(5, 2027, 2066);
return return_v;
}


int
f_5_1984_2075(string
value)
{
Console.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 1984, 2075);
return 0;
}


System.TimeSpan
f_5_2123_2144(ref System.DateTime
this_param,System.DateTime
value)
{
var return_v = this_param.Subtract( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 2123, 2144);
return return_v;
}


double
f_5_2123_2162(System.TimeSpan
this_param)
{
var return_v = this_param.TotalMilliseconds;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(5, 2123, 2162);
return return_v;
}


int
f_5_2082_2171(string
value)
{
Console.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 2082, 2171);
return 0;
}


int
f_5_2351_2384(string
value)
{
System.Console.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 2351, 2384);
return 0;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(5,1288,2389);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(5,1288,2389);
}
		}

private static void parseCmdLine(String[] args)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterStaticMethod(5,2494,2856);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,2549,2559);

int 
i = 0
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,2563,2574);

String 
arg
=default(String);
try {
while((DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,2580,2852) || true) && (i < f_5_2590_2601(args)&&(DynAbs.Tracing.TraceSender.Expression_True(5, 2586, 2628)&&f_5_2605_2628(args[i], "-")))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(5,2580,2852);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,2639,2655);

arg = args[i++];

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,2660,2847) || true) && (f_5_2663_2679(arg, "-h"))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(5,2660,2847);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,2692,2700);

f_5_2692_2699();
DynAbs.Tracing.TraceSender.TraceExitCondition(5,2660,2847);
}

else 
{DynAbs.Tracing.TraceSender.TraceEnterCondition(5,2660,2847);

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,2716,2847) || true) && (f_5_2719_2735(arg, "-p"))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(5,2716,2847);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,2748,2768);

printResults = true;
DynAbs.Tracing.TraceSender.TraceExitCondition(5,2716,2847);
}

else 
{DynAbs.Tracing.TraceSender.TraceEnterCondition(5,2716,2847);

if ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,2784,2847) || true) && (f_5_2788_2804(arg, "-m"))
) 

{DynAbs.Tracing.TraceSender.TraceEnterCondition(5,2784,2847);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,2821,2838);

printMsgs = true;
DynAbs.Tracing.TraceSender.TraceExitCondition(5,2784,2847);
}
DynAbs.Tracing.TraceSender.TraceExitCondition(5,2716,2847);
}
DynAbs.Tracing.TraceSender.TraceExitCondition(5,2660,2847);
}
DynAbs.Tracing.TraceSender.TraceExitCondition(5,2580,2852);
}
}catch(System.Exception) { DynAbs.Tracing.TraceSender.TraceExitLoopByException(5,2580,2852);
 throw; }finally{DynAbs.Tracing.TraceSender.TraceExitLoop(5,2580,2852);
}DynAbs.Tracing.TraceSender.TraceExitStaticMethod(5,2494,2856);

int
f_5_2590_2601(string[]
this_param)
{
var return_v = this_param.Length ;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(5, 2590, 2601);
return return_v;
}


bool
f_5_2605_2628(string
this_param,string
value)
{
var return_v = this_param.StartsWith( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 2605, 2628);
return return_v;
}


bool
f_5_2663_2679(string
this_param,string
value)
{
var return_v = this_param.Equals( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 2663, 2679);
return return_v;
}


int
f_5_2692_2699()
{
usage();
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 2692, 2699);
return 0;
}


bool
f_5_2719_2735(string
this_param,string
value)
{
var return_v = this_param.Equals( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 2719, 2735);
return return_v;
}


bool
f_5_2788_2804(string
this_param,string
value)
{
var return_v = this_param.Equals( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 2788, 2804);
return return_v;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(5,2494,2856);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(5,2494,2856);
}
		}

private static void usage()
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterStaticMethod(5,2931,3211);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,2966,3020);

f_5_2966_3019("usage: java Power [-p] [-m] [-h]");
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,3024,3068);

f_5_3024_3067("    -p (print results)");
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,3072,3129);

f_5_3072_3128("    -m (print informative messages)");
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,3133,3176);

f_5_3133_3175("    -h (this message)");
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,3180,3207);

f_5_3180_3206(0);
DynAbs.Tracing.TraceSender.TraceExitStaticMethod(5,2931,3211);

int
f_5_2966_3019(string
value)
{
Console.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 2966, 3019);
return 0;
}


int
f_5_3024_3067(string
value)
{
Console.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 3024, 3067);
return 0;
}


int
f_5_3072_3128(string
value)
{
Console.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 3072, 3128);
return 0;
}


int
f_5_3133_3175(string
value)
{
Console.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 3133, 3175);
return 0;
}


int
f_5_3180_3206(int
exitCode)
{
System.Environment.Exit( exitCode);
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 3180, 3206);
return 0;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(5,2931,3211);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(5,2931,3211);
}
		}

public Power()
{
DynAbs.Tracing.TraceSender.TraceEnterConstructor(5,947,3214);
DynAbs.Tracing.TraceSender.TraceExitConstructor(5,947,3214);

DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(5,947,3214);
}


static Power()
{
DynAbs.Tracing.TraceSender.TraceEnterStaticConstructor(5,947,3214);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,1050,1070);
printResults = false;DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,1138,1155);
printMsgs = false;DynAbs.Tracing.TraceSender.TraceExitStaticConstructor(5,947,3214);

DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(5,947,3214);
}

		int ___ignore_me___=DynAbs.Tracing.TraceSender.TraceBeforeConstructor(5,947,3214);
}
