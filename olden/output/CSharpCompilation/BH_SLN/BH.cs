using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
public class BH
{
private static int nbody ;

private static int nsteps ;

private static bool printMsgs ;

private static bool printResults ;

public static double DTIME ;

private static double TSTOP ;

public static void Main(string[] args)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterStaticMethod(1,612,2083);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,658,677);

f_1_658_676(args);

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,683,739) || true) && (printMsgs)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,683,739);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,701,739);

f_1_701_738("nbody = " + DynAbs.Tracing.TraceSender.TraceInvocationWrapper(() => (nbody).ToString(),1,732,737));
DynAbs.Tracing.TraceSender.TraceExitCondition(1,683,739);
}
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,745,778);

var 
start0 = f_1_758_777()
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,782,807);

BTree 
root = f_1_795_806()
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,811,838);

f_1_811_837(		root, nbody);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,842,873);

var 
end0 = f_1_853_872()
;

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,877,931) || true) && (printMsgs)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,877,931);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,895,931);

f_1_895_930("Bodies created");
DynAbs.Tracing.TraceSender.TraceExitCondition(1,877,931);
}
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,937,970);

var 
start1 = f_1_950_969()
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,974,992);

double 
tnow = 0.0
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,996,1006);

int 
i = 0
;
try {
while ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1010,1116) || true) && ((tnow < TSTOP + 0.1*DTIME) &&(DynAbs.Tracing.TraceSender.Expression_True(1, 1017, 1059)&&(i < nsteps)))
) 

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,1010,1116);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1071,1092);

f_1_1071_1091(			root, i++);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1097,1111);

tnow += DTIME;
DynAbs.Tracing.TraceSender.TraceExitCondition(1,1010,1116);
}
}catch(System.Exception) { DynAbs.Tracing.TraceSender.TraceExitLoopByException(1,1010,1116);
 throw; }finally{DynAbs.Tracing.TraceSender.TraceExitLoop(1,1010,1116);
}DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1120,1151);

var 
end1 = f_1_1131_1150()
;

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1159,1387) || true) && (printResults)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,1159,1387);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1185,1195);

int 
j = 0
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1200,1229);

Body 
current = f_1_1215_1228(root)
;
try {
while((DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1237,1382) || true) && (current != null)
) 

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,1237,1382);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1276,1332);

f_1_1276_1331("body " + DynAbs.Tracing.TraceSender.TraceInvocationWrapper(() => (j++).ToString(),1,1304,1307)+ " -- " + DynAbs.Tracing.TraceSender.TraceInvocationWrapper(() => (current.pos).ToString(),1,1319,1330));
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1339,1373);

current = (Body)f_1_1355_1372(current);
DynAbs.Tracing.TraceSender.TraceExitCondition(1,1237,1382);
}
}catch(System.Exception) { DynAbs.Tracing.TraceSender.TraceExitLoopByException(1,1237,1382);
 throw; }finally{DynAbs.Tracing.TraceSender.TraceExitLoop(1,1237,1382);
}DynAbs.Tracing.TraceSender.TraceExitCondition(1,1159,1387);
}

if ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1395,1716) || true) && (printMsgs)
) 

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,1395,1716);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1429,1513);

f_1_1429_1512("Build Time " + DynAbs.Tracing.TraceSender.TraceInvocationWrapper(() => ((f_1_1464_1503(f_1_1464_1485(ref end0, start0)))/1000.0).ToString(),1,1463,1511));
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1527,1613);

f_1_1527_1612("Compute Time " + DynAbs.Tracing.TraceSender.TraceInvocationWrapper(() => ((f_1_1564_1603(f_1_1564_1585(ref end1, start1)))/1000.0).ToString(),1,1563,1611));
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1627,1711);

f_1_1627_1710("Total Time " + DynAbs.Tracing.TraceSender.TraceInvocationWrapper(() => ((f_1_1662_1701(f_1_1662_1683(ref end1, start0)))/1000.0).ToString(),1,1661,1709));
DynAbs.Tracing.TraceSender.TraceExitCondition(1,1395,1716);
}
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1728,1768);

var 
slicingVariable1 = root.bodyTab.pos
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1778,1826);

var 
slicingVariable2 = root.bodyTab.pos.data[0]
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1836,1876);

var 
slicingVariable3 = root.bodyTab.vel
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1886,1934);

var 
slicingVariable4 = root.bodyTab.vel.data[0]
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1944,1984);

var 
slicingVariable5 = root.bodyTab.acc
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1994,2042);

var 
slicingVariable6 = root.bodyTab.acc.data[0]
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2052,2079);

f_1_2052_2078("Done!");
DynAbs.Tracing.TraceSender.TraceExitStaticMethod(1,612,2083);

int
f_1_658_676(string[]
args)
{
parseCmdLine( args);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 658, 676);
return 0;
}


int
f_1_701_738(string
value)
{
Console.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 701, 738);
return 0;
}


System.DateTime
f_1_758_777()
{
var return_v = System.DateTime.Now;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(1, 758, 777);
return return_v;
}


BTree
f_1_795_806()
{
var return_v = new BTree();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 795, 806);
return return_v;
}


int
f_1_811_837(BTree
this_param,int
nbody)
{
this_param.createTestData( nbody);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 811, 837);
return 0;
}


System.DateTime
f_1_853_872()
{
var return_v = System.DateTime.Now;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(1, 853, 872);
return return_v;
}


int
f_1_895_930(string
value)
{
Console.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 895, 930);
return 0;
}


System.DateTime
f_1_950_969()
{
var return_v = System.DateTime.Now;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(1, 950, 969);
return return_v;
}


int
f_1_1071_1091(BTree
this_param,int
nstep)
{
this_param.stepSystem( nstep);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 1071, 1091);
return 0;
}


System.DateTime
f_1_1131_1150()
{
var return_v = System.DateTime.Now;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(1, 1131, 1150);
return return_v;
}


Body
f_1_1215_1228(BTree
this_param)
{
var return_v = this_param.bodies();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 1215, 1228);
return return_v;
}


int
f_1_1276_1331(string
value)
{
Console.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 1276, 1331);
return 0;
}


Body
f_1_1355_1372(Body
this_param)
{
var return_v = this_param.getNext();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 1355, 1372);
return return_v;
}


System.TimeSpan
f_1_1464_1485(ref System.DateTime
this_param,System.DateTime
value)
{
var return_v = this_param.Subtract( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 1464, 1485);
return return_v;
}


double
f_1_1464_1503(System.TimeSpan
this_param)
{
var return_v = this_param.TotalMilliseconds;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(1, 1464, 1503);
return return_v;
}


int
f_1_1429_1512(string
value)
{
Console.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 1429, 1512);
return 0;
}


System.TimeSpan
f_1_1564_1585(ref System.DateTime
this_param,System.DateTime
value)
{
var return_v = this_param.Subtract( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 1564, 1585);
return return_v;
}


double
f_1_1564_1603(System.TimeSpan
this_param)
{
var return_v = this_param.TotalMilliseconds;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(1, 1564, 1603);
return return_v;
}


int
f_1_1527_1612(string
value)
{
Console.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 1527, 1612);
return 0;
}


System.TimeSpan
f_1_1662_1683(ref System.DateTime
this_param,System.DateTime
value)
{
var return_v = this_param.Subtract( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 1662, 1683);
return return_v;
}


double
f_1_1662_1701(System.TimeSpan
this_param)
{
var return_v = this_param.TotalMilliseconds;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(1, 1662, 1701);
return return_v;
}


int
f_1_1627_1710(string
value)
{
Console.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 1627, 1710);
return 0;
}


int
f_1_2052_2078(string
value)
{
Console.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 2052, 2078);
return 0;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(1,612,2083);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(1,612,2083);
}
		}

public static double myRand(double seed)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterStaticMethod(1,2233,2396);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2281,2313);

double 
t = 16807.0 * seed + 1.0
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2319,2376);

seed = t - (2147483647.0 * f_1_2346_2374(t / 2147483647.0));
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2380,2392);

return seed;
DynAbs.Tracing.TraceSender.TraceExitStaticMethod(1,2233,2396);

double
f_1_2346_2374(double
d)
{
var return_v = Math.Floor( d);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 2346, 2374);
return return_v;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(1,2233,2396);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(1,2233,2396);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

public static double xRand(double xl, double xh, double r)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterStaticMethod(1,2616,2748);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2682,2729);

double 
res = xl + (xh - xl) * r / 2147483647.0
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2733,2744);

return res;
DynAbs.Tracing.TraceSender.TraceExitStaticMethod(1,2616,2748);
	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(1,2616,2748);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(1,2616,2748);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

private static void parseCmdLine(String[] args)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterStaticMethod(1,2852,3700);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2907,2917);

int 
i = 0
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2921,2932);

string 
arg
=default(string);
try {
while((DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2938,3665) || true) && (i < f_1_2948_2959(args)&&(DynAbs.Tracing.TraceSender.Expression_True(1, 2944, 2986)&&f_1_2963_2986(args[i], "-")))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,2938,3665);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2997,3013);

arg = args[i++];

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,3068,3660) || true) && (f_1_3071_3087(arg, "-b"))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,3068,3660);

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,3100,3258) || true) && (i < f_1_3107_3118(args))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,3100,3258);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,3133,3164);

nbody = f_1_3141_3163(args[i++]);
DynAbs.Tracing.TraceSender.TraceExitCondition(1,3100,3258);
}

else

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,3100,3258);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,3195,3251);

throw f_1_3201_3250("-l requires the number of levels");
DynAbs.Tracing.TraceSender.TraceExitCondition(1,3100,3258);
}
DynAbs.Tracing.TraceSender.TraceExitCondition(1,3068,3660);
}

else 
{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,3068,3660);

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,3274,3660) || true) && (f_1_3277_3293(arg, "-s"))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,3274,3660);

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,3306,3465) || true) && (i < f_1_3313_3324(args))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,3306,3465);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,3339,3371);

nsteps = f_1_3348_3370(args[i++]);
DynAbs.Tracing.TraceSender.TraceExitCondition(1,3306,3465);
}

else

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,3306,3465);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,3402,3458);

throw f_1_3408_3457("-l requires the number of levels");
DynAbs.Tracing.TraceSender.TraceExitCondition(1,3306,3465);
}
DynAbs.Tracing.TraceSender.TraceExitCondition(1,3274,3660);
}

else 
{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,3274,3660);

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,3481,3660) || true) && (f_1_3484_3500(arg, "-m"))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,3481,3660);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,3513,3530);

printMsgs = true;
DynAbs.Tracing.TraceSender.TraceExitCondition(1,3481,3660);
}

else 
{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,3481,3660);

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,3546,3660) || true) && (f_1_3549_3565(arg, "-p"))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,3546,3660);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,3578,3598);

printResults = true;
DynAbs.Tracing.TraceSender.TraceExitCondition(1,3546,3660);
}

else 
{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,3546,3660);

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,3614,3660) || true) && (f_1_3617_3633(arg, "-h"))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,3614,3660);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,3646,3654);

f_1_3646_3653();
DynAbs.Tracing.TraceSender.TraceExitCondition(1,3614,3660);
}
DynAbs.Tracing.TraceSender.TraceExitCondition(1,3546,3660);
}
DynAbs.Tracing.TraceSender.TraceExitCondition(1,3481,3660);
}
DynAbs.Tracing.TraceSender.TraceExitCondition(1,3274,3660);
}
DynAbs.Tracing.TraceSender.TraceExitCondition(1,3068,3660);
}
DynAbs.Tracing.TraceSender.TraceExitCondition(1,2938,3665);
}
}catch(System.Exception) { DynAbs.Tracing.TraceSender.TraceExitLoopByException(1,2938,3665);
 throw; }finally{DynAbs.Tracing.TraceSender.TraceExitLoop(1,2938,3665);
}
if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,3669,3696) || true) && (nbody == 0)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,3669,3696);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,3688,3696);

f_1_3688_3695();
DynAbs.Tracing.TraceSender.TraceExitCondition(1,3669,3696);
}
DynAbs.Tracing.TraceSender.TraceExitStaticMethod(1,2852,3700);

int
f_1_2948_2959(string[]
this_param)
{
var return_v = this_param.Length ;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(1, 2948, 2959);
return return_v;
}


bool
f_1_2963_2986(string
this_param,string
value)
{
var return_v = this_param.StartsWith( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 2963, 2986);
return return_v;
}


bool
f_1_3071_3087(string
this_param,string
value)
{
var return_v = this_param.Equals( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 3071, 3087);
return return_v;
}


int
f_1_3107_3118(string[]
this_param)
{
var return_v = this_param.Length;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(1, 3107, 3118);
return return_v;
}


int
f_1_3141_3163(string
s)
{
var return_v = Int32.Parse( s);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 3141, 3163);
return return_v;
}


System.Exception
f_1_3201_3250(string
message)
{
var return_v = new System.Exception( message);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 3201, 3250);
return return_v;
}


bool
f_1_3277_3293(string
this_param,string
value)
{
var return_v = this_param.Equals( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 3277, 3293);
return return_v;
}


int
f_1_3313_3324(string[]
this_param)
{
var return_v = this_param.Length;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(1, 3313, 3324);
return return_v;
}


int
f_1_3348_3370(string
s)
{
var return_v = Int32.Parse( s);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 3348, 3370);
return return_v;
}


System.Exception
f_1_3408_3457(string
message)
{
var return_v = new System.Exception( message);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 3408, 3457);
return return_v;
}


bool
f_1_3484_3500(string
this_param,string
value)
{
var return_v = this_param.Equals( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 3484, 3500);
return return_v;
}


bool
f_1_3549_3565(string
this_param,string
value)
{
var return_v = this_param.Equals( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 3549, 3565);
return return_v;
}


bool
f_1_3617_3633(string
this_param,string
value)
{
var return_v = this_param.Equals( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 3617, 3633);
return return_v;
}


int
f_1_3646_3653()
{
usage();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 3646, 3653);
return 0;
}


int
f_1_3688_3695()
{
usage();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 3688, 3695);
return 0;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(1,2852,3700);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(1,2852,3700);
}
		}

private static void usage()
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterStaticMethod(1,3775,4211);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,3810,3884);

f_1_3810_3883("usage: java BH -b <size> [-s <steps>] [-p] [-m] [-h]");
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,3888,3937);

f_1_3888_3936("    -b the number of bodies");
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,3941,4012);

f_1_3941_4011("    -s the max. number of time steps (default=10)");
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,4016,4069);

f_1_4016_4068("    -p (print detailed results)");
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,4073,4129);

f_1_4073_4128("    -m (print information messages");
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,4133,4176);

f_1_4133_4175("    -h (this message)");
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,4180,4207);

f_1_4180_4206(0);
DynAbs.Tracing.TraceSender.TraceExitStaticMethod(1,3775,4211);

int
f_1_3810_3883(string
value)
{
Console.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 3810, 3883);
return 0;
}


int
f_1_3888_3936(string
value)
{
Console.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 3888, 3936);
return 0;
}


int
f_1_3941_4011(string
value)
{
Console.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 3941, 4011);
return 0;
}


int
f_1_4016_4068(string
value)
{
Console.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 4016, 4068);
return 0;
}


int
f_1_4073_4128(string
value)
{
Console.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 4073, 4128);
return 0;
}


int
f_1_4133_4175(string
value)
{
Console.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 4133, 4175);
return 0;
}


int
f_1_4180_4206(int
exitCode)
{
System.Environment.Exit( exitCode);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 4180, 4206);
return 0;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(1,3775,4211);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(1,3775,4211);
}
		}

public BH()
{
DynAbs.Tracing.TraceSender.TraceEnterConstructor(1,114,4214);
DynAbs.Tracing.TraceSender.TraceExitConstructor(1,114,4214);

DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(1,114,4214);
}


static BH()
{
DynAbs.Tracing.TraceSender.TraceEnterStaticConstructor(1,114,4214);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,222,231);
nbody = 0;DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,330,340);
nsteps = 0;DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,419,436);
printMsgs = false;DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,508,528);
printResults = false;DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,555,569);
DTIME = 0.0125;DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,595,606);
TSTOP = 2.0;DynAbs.Tracing.TraceSender.TraceExitStaticConstructor(1,114,4214);

DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(1,114,4214);
}

		int ___ignore_me___=DynAbs.Tracing.TraceSender.TraceBeforeConstructor(1,114,4214);
}
