using System;
using System.Collections.Generic;
using System.Text;
public class Em3d
{
static int nodect ;

static int conn ;

static int numiter ;

private static bool printResult ;

private static bool printMsgs ;

public static void Main(String[] args)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterStaticMethod(2,1273,2562);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1319,1338);

f_2_1319_1337(args);

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1344,1417) || true) && (printMsgs)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,1344,1417);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1362,1417);

f_2_1362_1416("Initializing em3d random graph...");
DynAbs.Tracing.TraceSender.TraceExitCondition(2,1344,1417);
}
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1421,1447);

var 
start0 = f_2_1434_1446()
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1451,1509);

BiGraph 
graph = f_2_1467_1508(nodect, conn, printResult)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1513,1537);

var 
end0 = f_2_1524_1536()
;

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1610,1710) || true) && (printMsgs)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,1610,1710);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1628,1710);

f_2_1628_1709("Propagating field values for " + DynAbs.Tracing.TraceSender.TraceInvocationWrapper(() => (numiter).ToString(),2,1680,1687)+ " iteration(s)...");
DynAbs.Tracing.TraceSender.TraceExitCondition(2,1610,1710);
}
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1714,1740);

var 
start1 = f_2_1727_1739()
;
try {DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1752,1757);
		for(int 
i = 0
; (DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1744,1797) || true) && (i < numiter)
; DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1772,1775)
,i++,DynAbs.Tracing.TraceSender.TraceExitCondition(2,1744,1797))

{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,1744,1797);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1781,1797);

f_2_1781_1796(			graph);
}
}catch(System.Exception) { DynAbs.Tracing.TraceSender.TraceExitLoopByException(2,1,54);
 throw; }finally{DynAbs.Tracing.TraceSender.TraceExitLoop(2,1,54);
}DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1801,1825);

var 
end1 = f_2_1812_1824()
;

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1866,1929) || true) && (printResult)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,1866,1929);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1886,1929);

f_2_1886_1928(f_2_1911_1927(graph));
DynAbs.Tracing.TraceSender.TraceExitCondition(2,1866,1929);
}

if ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1935,2247) || true) && (printMsgs)
) 

{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,1935,2247);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1961,2050);

f_2_1961_2049("EM3D build time " + DynAbs.Tracing.TraceSender.TraceInvocationWrapper(() => ((f_2_2001_2040(f_2_2001_2022(ref end0, start0)))/1000.0).ToString(),2,2000,2048));
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2056,2147);

f_2_2056_2146("EM3D compute time " + DynAbs.Tracing.TraceSender.TraceInvocationWrapper(() => ((f_2_2098_2137(f_2_2098_2119(ref end1, start1)))/1000.0).ToString(),2,2097,2145));
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2153,2242);

f_2_2153_2241("EM3D total time " + DynAbs.Tracing.TraceSender.TraceInvocationWrapper(() => ((f_2_2193_2232(f_2_2193_2214(ref end1, start0)))/1000.0).ToString(),2,2192,2240));
DynAbs.Tracing.TraceSender.TraceExitCondition(2,1935,2247);
}
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2257,2299);

var 
slicingVariable1 = graph.eNodes.value
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2309,2352);

var 
slicingVariable2 = graph.eNodes.coeffs
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2362,2408);

var 
slicingVariable3 = graph.eNodes.coeffs[0]
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2418,2464);

var 
slicingVariable4 = graph.eNodes.fromCount
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2474,2521);

var 
slicingVariable5 = graph.eNodes.fromLength
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2531,2558);

f_2_2531_2557("Done!");
DynAbs.Tracing.TraceSender.TraceExitStaticMethod(2,1273,2562);

int
f_2_1319_1337(string[]
args)
{
parseCmdLine( args);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 1319, 1337);
return 0;
}


int
f_2_1362_1416(string
value)
{
Console.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 1362, 1416);
return 0;
}


System.DateTime
f_2_1434_1446()
{
var return_v = DateTime.Now;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(2, 1434, 1446);
return return_v;
}


BiGraph
f_2_1467_1508(int
numNodes,int
numDegree,bool
verbose)
{
var return_v = BiGraph.create( numNodes, numDegree, verbose);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 1467, 1508);
return return_v;
}


System.DateTime
f_2_1524_1536()
{
var return_v = DateTime.Now;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(2, 1524, 1536);
return return_v;
}


int
f_2_1628_1709(string
value)
{
Console.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 1628, 1709);
return 0;
}


System.DateTime
f_2_1727_1739()
{
var return_v = DateTime.Now;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(2, 1727, 1739);
return return_v;
}


int
f_2_1781_1796(BiGraph
this_param)
{
this_param.compute();
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 1781, 1796);
return 0;
}


System.DateTime
f_2_1812_1824()
{
var return_v = DateTime.Now;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(2, 1812, 1824);
return return_v;
}


string
f_2_1911_1927(BiGraph
this_param)
{
var return_v = this_param.toString();
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 1911, 1927);
return return_v;
}


int
f_2_1886_1928(string
value)
{
System.Console.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 1886, 1928);
return 0;
}


System.TimeSpan
f_2_2001_2022(ref System.DateTime
this_param,System.DateTime
value)
{
var return_v = this_param.Subtract( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 2001, 2022);
return return_v;
}


double
f_2_2001_2040(System.TimeSpan
this_param)
{
var return_v = this_param.TotalMilliseconds;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(2, 2001, 2040);
return return_v;
}


int
f_2_1961_2049(string
value)
{
Console.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 1961, 2049);
return 0;
}


System.TimeSpan
f_2_2098_2119(ref System.DateTime
this_param,System.DateTime
value)
{
var return_v = this_param.Subtract( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 2098, 2119);
return return_v;
}


double
f_2_2098_2137(System.TimeSpan
this_param)
{
var return_v = this_param.TotalMilliseconds;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(2, 2098, 2137);
return return_v;
}


int
f_2_2056_2146(string
value)
{
Console.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 2056, 2146);
return 0;
}


System.TimeSpan
f_2_2193_2214(ref System.DateTime
this_param,System.DateTime
value)
{
var return_v = this_param.Subtract( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 2193, 2214);
return return_v;
}


double
f_2_2193_2232(System.TimeSpan
this_param)
{
var return_v = this_param.TotalMilliseconds;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(2, 2193, 2232);
return return_v;
}


int
f_2_2153_2241(string
value)
{
Console.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 2153, 2241);
return 0;
}


int
f_2_2531_2557(string
value)
{
Console.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 2531, 2557);
return 0;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(2,1273,2562);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(2,1273,2562);
}
		}

private static void parseCmdLine(String[] args)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterStaticMethod(2,2666,3692);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2721,2731);

int 
i = 0
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2735,2746);

String 
arg
=default(String);
try {
while((DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2752,3643) || true) && (i < f_2_2762_2773(args)&&(DynAbs.Tracing.TraceSender.Expression_True(2, 2758, 2800)&&f_2_2777_2800(args[i], "-")))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,2752,3643);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2811,2827);

arg = args[i++];

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2882,3638) || true) && (f_2_2885_2901(arg, "-n"))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,2882,3638);

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2914,3059) || true) && (i < f_2_2921_2932(args))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,2914,3059);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2947,2979);

nodect = f_2_2956_2978(args[i++]);
DynAbs.Tracing.TraceSender.TraceExitCondition(2,2914,3059);
}

else 

{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,2914,3059);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,3004,3059);

throw f_2_3010_3058("-n requires the number of nodes");
DynAbs.Tracing.TraceSender.TraceExitCondition(2,2914,3059);
}
DynAbs.Tracing.TraceSender.TraceExitCondition(2,2882,3638);
}

else 
{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,2882,3638);

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,3075,3638) || true) && (f_2_3078_3094(arg, "-d"))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,3075,3638);

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,3107,3245) || true) && (i < f_2_3114_3125(args))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,3107,3245);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,3140,3170);

conn = f_2_3147_3169(args[i++]);
DynAbs.Tracing.TraceSender.TraceExitCondition(2,3107,3245);
}

else 

{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,3107,3245);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,3195,3245);

throw f_2_3201_3244("-d requires the out degree");
DynAbs.Tracing.TraceSender.TraceExitCondition(2,3107,3245);
}
DynAbs.Tracing.TraceSender.TraceExitCondition(2,3075,3638);
}

else 
{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,3075,3638);

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,3261,3638) || true) && (f_2_3264_3280(arg, "-i"))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,3261,3638);

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,3293,3444) || true) && (i < f_2_3300_3311(args))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,3293,3444);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,3326,3359);

numiter = f_2_3336_3358(args[i++]);
DynAbs.Tracing.TraceSender.TraceExitCondition(2,3293,3444);
}

else 

{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,3293,3444);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,3384,3444);

throw f_2_3390_3443("-i requires the number of iterations");
DynAbs.Tracing.TraceSender.TraceExitCondition(2,3293,3444);
}
DynAbs.Tracing.TraceSender.TraceExitCondition(2,3261,3638);
}

else 
{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,3261,3638);

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,3460,3638) || true) && (f_2_3463_3479(arg, "-p"))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,3460,3638);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,3492,3511);

printResult = true;
DynAbs.Tracing.TraceSender.TraceExitCondition(2,3460,3638);
}

else 
{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,3460,3638);

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,3527,3638) || true) && (f_2_3530_3546(arg, "-m"))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,3527,3638);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,3559,3576);

printMsgs = true;
DynAbs.Tracing.TraceSender.TraceExitCondition(2,3527,3638);
}

else 
{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,3527,3638);

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,3592,3638) || true) && (f_2_3595_3611(arg, "-h"))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,3592,3638);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,3624,3632);

f_2_3624_3631();
DynAbs.Tracing.TraceSender.TraceExitCondition(2,3592,3638);
}
DynAbs.Tracing.TraceSender.TraceExitCondition(2,3527,3638);
}
DynAbs.Tracing.TraceSender.TraceExitCondition(2,3460,3638);
}
DynAbs.Tracing.TraceSender.TraceExitCondition(2,3261,3638);
}
DynAbs.Tracing.TraceSender.TraceExitCondition(2,3075,3638);
}
DynAbs.Tracing.TraceSender.TraceExitCondition(2,2882,3638);
}
DynAbs.Tracing.TraceSender.TraceExitCondition(2,2752,3643);
}
}catch(System.Exception) { DynAbs.Tracing.TraceSender.TraceExitLoopByException(2,2752,3643);
 throw; }finally{DynAbs.Tracing.TraceSender.TraceExitLoop(2,2752,3643);
}
if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,3647,3688) || true) && (nodect == 0 ||(DynAbs.Tracing.TraceSender.Expression_False(2, 3650, 3674)||conn == 0))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,3647,3688);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,3680,3688);

f_2_3680_3687();
DynAbs.Tracing.TraceSender.TraceExitCondition(2,3647,3688);
}
DynAbs.Tracing.TraceSender.TraceExitStaticMethod(2,2666,3692);

int
f_2_2762_2773(string[]
this_param)
{
var return_v = this_param.Length ;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(2, 2762, 2773);
return return_v;
}


bool
f_2_2777_2800(string
this_param,string
value)
{
var return_v = this_param.StartsWith( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 2777, 2800);
return return_v;
}


bool
f_2_2885_2901(string
this_param,string
value)
{
var return_v = this_param.Equals( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 2885, 2901);
return return_v;
}


int
f_2_2921_2932(string[]
this_param)
{
var return_v = this_param.Length;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(2, 2921, 2932);
return return_v;
}


int
f_2_2956_2978(string
s)
{
var return_v = Int32.Parse( s);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 2956, 2978);
return return_v;
}


System.Exception
f_2_3010_3058(string
message)
{
var return_v = new System.Exception( message);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 3010, 3058);
return return_v;
}


bool
f_2_3078_3094(string
this_param,string
value)
{
var return_v = this_param.Equals( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 3078, 3094);
return return_v;
}


int
f_2_3114_3125(string[]
this_param)
{
var return_v = this_param.Length;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(2, 3114, 3125);
return return_v;
}


int
f_2_3147_3169(string
s)
{
var return_v = Int32.Parse( s);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 3147, 3169);
return return_v;
}


System.Exception
f_2_3201_3244(string
message)
{
var return_v = new System.Exception( message);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 3201, 3244);
return return_v;
}


bool
f_2_3264_3280(string
this_param,string
value)
{
var return_v = this_param.Equals( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 3264, 3280);
return return_v;
}


int
f_2_3300_3311(string[]
this_param)
{
var return_v = this_param.Length;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(2, 3300, 3311);
return return_v;
}


int
f_2_3336_3358(string
s)
{
var return_v = Int32.Parse( s);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 3336, 3358);
return return_v;
}


System.Exception
f_2_3390_3443(string
message)
{
var return_v = new System.Exception( message);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 3390, 3443);
return return_v;
}


bool
f_2_3463_3479(string
this_param,string
value)
{
var return_v = this_param.Equals( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 3463, 3479);
return return_v;
}


bool
f_2_3530_3546(string
this_param,string
value)
{
var return_v = this_param.Equals( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 3530, 3546);
return return_v;
}


bool
f_2_3595_3611(string
this_param,string
value)
{
var return_v = this_param.Equals( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 3595, 3611);
return return_v;
}


int
f_2_3624_3631()
{
usage();
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 3624, 3631);
return 0;
}


int
f_2_3680_3687()
{
usage();
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 3680, 3687);
return 0;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(2,2666,3692);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(2,2666,3692);
}
		}

private static void usage()
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterStaticMethod(2,3767,4247);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,3802,3878);

f_2_3802_3877("usage: java Em3d -n <nodes> -d <degree> [-p] [-m] [-h]");
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,3882,3930);

f_2_3882_3929("    -n the number of nodes");
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,3934,3990);

f_2_3934_3989("    -d the out-degree of each node");
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,3994,4047);

f_2_3994_4046("    -i the number of iterations");
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,4051,4104);

f_2_4051_4103("    -p (print detailed results)");
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,4108,4165);

f_2_4108_4164("    -m (print informative messages)");
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,4169,4212);

f_2_4169_4211("    -h (this message)");
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,4216,4243);

f_2_4216_4242(0);
DynAbs.Tracing.TraceSender.TraceExitStaticMethod(2,3767,4247);

int
f_2_3802_3877(string
value)
{
Console.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 3802, 3877);
return 0;
}


int
f_2_3882_3929(string
value)
{
Console.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 3882, 3929);
return 0;
}


int
f_2_3934_3989(string
value)
{
Console.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 3934, 3989);
return 0;
}


int
f_2_3994_4046(string
value)
{
Console.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 3994, 4046);
return 0;
}


int
f_2_4051_4103(string
value)
{
Console.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 4051, 4103);
return 0;
}


int
f_2_4108_4164(string
value)
{
Console.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 4108, 4164);
return 0;
}


int
f_2_4169_4211(string
value)
{
Console.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 4169, 4211);
return 0;
}


int
f_2_4216_4242(int
exitCode)
{
System.Environment.Exit( exitCode);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 4216, 4242);
return 0;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(2,3767,4247);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(2,3767,4247);
}
		}

public Em3d()
{
DynAbs.Tracing.TraceSender.TraceEnterConstructor(2,592,4250);
DynAbs.Tracing.TraceSender.TraceExitConstructor(2,592,4250);

DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(2,592,4250);
}


static Em3d()
{
DynAbs.Tracing.TraceSender.TraceEnterStaticConstructor(2,592,4250);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,676,686);
nodect = 0;DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,749,757);
conn = 0;DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,824,835);
numiter = 0;DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,929,948);
printResult = false;DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1021,1038);
printMsgs = false;DynAbs.Tracing.TraceSender.TraceExitStaticConstructor(2,592,4250);

DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(2,592,4250);
}

		int ___ignore_me___=DynAbs.Tracing.TraceSender.TraceBeforeConstructor(2,592,4250);
}
