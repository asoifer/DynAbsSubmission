
using System;
public class Voronoi
{
private static int points ;

private static bool printMsgs ;

private static bool printResults ;

public static void Main(string[] args)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterStaticMethod(6,1174,2535);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,1220,1239);

f_6_1220_1238(args);

if ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,1247,1328) || true) && (printMsgs)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(6,1247,1328);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,1266,1328);

f_6_1266_1327(f_6_1266_1284(), "Getting " + DynAbs.Tracing.TraceSender.TraceInvocationWrapper(() => (points).ToString(),6,1308,1314)+ " points");
DynAbs.Tracing.TraceSender.TraceExitCondition(6,1247,1328);
}
DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,1336,1369);

var 
start0 = f_6_1349_1368()
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,1373,1392);

Vertex.seed = 1023;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,1396,1461);

Vertex 
extra = f_6_1411_1460(1, f_6_1434_1451(1.0), points)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,1465,1549);

Vertex 
point = f_6_1480_1548(points - 1, f_6_1512_1535(f_6_1525_1534(extra)), points - 1)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,1553,1584);

var 
end0 = f_6_1564_1583()
;

if ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,1592,1681) || true) && (printMsgs)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(6,1592,1681);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,1611,1681);

f_6_1611_1680(f_6_1611_1629(), "Doing voronoi on " + DynAbs.Tracing.TraceSender.TraceInvocationWrapper(() => (points).ToString(),6,1662,1668)+ " nodes");
DynAbs.Tracing.TraceSender.TraceExitCondition(6,1592,1681);
}
DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,1689,1722);

var 
start1 = f_6_1702_1721()
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,1726,1778);

Edge 
edge = f_6_1738_1777(point, extra)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,1782,1813);

var 
end1 = f_6_1793_1812()
;

if ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,1821,1871) || true) && (printResults)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(6,1821,1871);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,1843,1871);

f_6_1843_1870(			edge);
DynAbs.Tracing.TraceSender.TraceExitCondition(6,1821,1871);
}

if ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,1879,2212) || true) && (printMsgs)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(6,1879,2212);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,1903,2000);

f_6_1903_1999(f_6_1903_1921(), "Build time " + DynAbs.Tracing.TraceSender.TraceInvocationWrapper(() => ((f_6_1949_1988(f_6_1949_1970(ref end0, start0))) / 1000.0).ToString(),6,1948,1998));
DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,2005,2105);

f_6_2005_2104(f_6_2005_2023(), "Compute  time " + DynAbs.Tracing.TraceSender.TraceInvocationWrapper(() => ((f_6_2054_2093(f_6_2054_2075(ref end1, start1))) / 1000.0).ToString(),6,2053,2103));
DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,2110,2207);

f_6_2110_2206(f_6_2110_2128(), "Total time " + DynAbs.Tracing.TraceSender.TraceInvocationWrapper(() => ((f_6_2156_2195(f_6_2156_2177(ref end1, start0))) / 1000.0).ToString(),6,2155,2205));
DynAbs.Tracing.TraceSender.TraceExitCondition(6,1879,2212);
}
DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,2224,2252);

var 
slicingVariable1 = edge
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,2262,2299);

var 
slicingVariable2 = edge.quadList
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,2309,2349);

var 
slicingVariable3 = edge.quadList[0]
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,2359,2395);

var 
slicingVariable4 = edge.listPos
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,2405,2440);

var 
slicingVariable5 = edge.vertex
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,2450,2483);

var 
slicingVariable6 = edge.next
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,2493,2531);

f_6_2493_2530(f_6_2493_2511(), "Done!");
DynAbs.Tracing.TraceSender.TraceExitStaticMethod(6,1174,2535);

int
f_6_1220_1238(string[]
args)
{
parseCmdLine( args);
DynAbs.Tracing.TraceSender.TraceEndInvocation(6, 1220, 1238);
return 0;
}


System.IO.TextWriter
f_6_1266_1284()
{
var return_v = 			System.Console.Out;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(6, 1266, 1284);
return return_v;
}


int
f_6_1266_1327(System.IO.TextWriter
this_param,string
value)
{
this_param.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(6, 1266, 1327);
return 0;
}


System.DateTime
f_6_1349_1368()
{
var return_v = System.DateTime.Now;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(6, 1349, 1368);
return return_v;
}


MyDouble
f_6_1434_1451(double
d)
{
var return_v = new MyDouble( d);
DynAbs.Tracing.TraceSender.TraceEndInvocation(6, 1434, 1451);
return return_v;
}


Vertex
f_6_1411_1460(int
n,MyDouble
curmax,int
i)
{
var return_v = Vertex.createPoints( n, curmax, i);
DynAbs.Tracing.TraceSender.TraceEndInvocation(6, 1411, 1460);
return return_v;
}


double
f_6_1525_1534(Vertex
this_param)
{
var return_v = this_param.X();
DynAbs.Tracing.TraceSender.TraceEndInvocation(6, 1525, 1534);
return return_v;
}


MyDouble
f_6_1512_1535(double
d)
{
var return_v = new MyDouble( d);
DynAbs.Tracing.TraceSender.TraceEndInvocation(6, 1512, 1535);
return return_v;
}


Vertex
f_6_1480_1548(int
n,MyDouble
curmax,int
i)
{
var return_v = Vertex.createPoints( n, curmax, i);
DynAbs.Tracing.TraceSender.TraceEndInvocation(6, 1480, 1548);
return return_v;
}


System.DateTime
f_6_1564_1583()
{
var return_v = System.DateTime.Now;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(6, 1564, 1583);
return return_v;
}


System.IO.TextWriter
f_6_1611_1629()
{
var return_v = 			System.Console.Out;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(6, 1611, 1629);
return return_v;
}


int
f_6_1611_1680(System.IO.TextWriter
this_param,string
value)
{
this_param.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(6, 1611, 1680);
return 0;
}


System.DateTime
f_6_1702_1721()
{
var return_v = System.DateTime.Now;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(6, 1702, 1721);
return return_v;
}


Edge
f_6_1738_1777(Vertex
this_param,Vertex
extra)
{
var return_v = this_param.buildDelaunayTriangulation( extra);
DynAbs.Tracing.TraceSender.TraceEndInvocation(6, 1738, 1777);
return return_v;
}


System.DateTime
f_6_1793_1812()
{
var return_v = System.DateTime.Now;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(6, 1793, 1812);
return return_v;
}


int
f_6_1843_1870(Edge
this_param)
{
this_param.outputVoronoiDiagram();
DynAbs.Tracing.TraceSender.TraceEndInvocation(6, 1843, 1870);
return 0;
}


System.IO.TextWriter
f_6_1903_1921()
{
var return_v = 			System.Console.Out;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(6, 1903, 1921);
return return_v;
}


System.TimeSpan
f_6_1949_1970(ref System.DateTime
this_param,System.DateTime
value)
{
var return_v = this_param.Subtract( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(6, 1949, 1970);
return return_v;
}


double
f_6_1949_1988(System.TimeSpan
this_param)
{
var return_v = this_param.TotalMilliseconds;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(6, 1949, 1988);
return return_v;
}


int
f_6_1903_1999(System.IO.TextWriter
this_param,string
value)
{
this_param.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(6, 1903, 1999);
return 0;
}


System.IO.TextWriter
f_6_2005_2023()
{
var return_v = 			System.Console.Out;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(6, 2005, 2023);
return return_v;
}


System.TimeSpan
f_6_2054_2075(ref System.DateTime
this_param,System.DateTime
value)
{
var return_v = this_param.Subtract( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(6, 2054, 2075);
return return_v;
}


double
f_6_2054_2093(System.TimeSpan
this_param)
{
var return_v = this_param.TotalMilliseconds;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(6, 2054, 2093);
return return_v;
}


int
f_6_2005_2104(System.IO.TextWriter
this_param,string
value)
{
this_param.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(6, 2005, 2104);
return 0;
}


System.IO.TextWriter
f_6_2110_2128()
{
var return_v = 			System.Console.Out;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(6, 2110, 2128);
return return_v;
}


System.TimeSpan
f_6_2156_2177(ref System.DateTime
this_param,System.DateTime
value)
{
var return_v = this_param.Subtract( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(6, 2156, 2177);
return return_v;
}


double
f_6_2156_2195(System.TimeSpan
this_param)
{
var return_v = this_param.TotalMilliseconds;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(6, 2156, 2195);
return return_v;
}


int
f_6_2110_2206(System.IO.TextWriter
this_param,string
value)
{
this_param.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(6, 2110, 2206);
return 0;
}


System.IO.TextWriter
f_6_2493_2511()
{
var return_v =         System.Console.Out;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(6, 2493, 2511);
return return_v;
}


int
f_6_2493_2530(System.IO.TextWriter
this_param,string
value)
{
this_param.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(6, 2493, 2530);
return 0;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(6,1174,2535);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(6,1174,2535);
}
		}

private static void parseCmdLine(string[] args)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterStaticMethod(6,2637,3251);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,2692,2702);

int 
i = 0
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,2706,2717);

string 
arg
=default(string);
try {
while ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,2725,3214) || true) && (i < f_6_2736_2747(args)&&(DynAbs.Tracing.TraceSender.Expression_True(6, 2732, 2774)&&f_6_2751_2774(args[i], "-")))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(6,2725,3214);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,2785,2801);

arg = args[i++];

if ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,2811,3209) || true) && (f_6_2815_2831(arg, "-n"))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(6,2811,3209);

if ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,2844,3008) || true) && (i < f_6_2852_2863(args))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(6,2844,3008);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,2878,2921);

points = f_6_2887_2920(args[i++]);
DynAbs.Tracing.TraceSender.TraceExitCondition(6,2844,3008);
}

else

{DynAbs.Tracing.TraceSender.TraceEnterCondition(6,2844,3008);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,2945,3008);

throw f_6_2951_3007("-n requires the number of points");
DynAbs.Tracing.TraceSender.TraceExitCondition(6,2844,3008);
}
DynAbs.Tracing.TraceSender.TraceExitCondition(6,2811,3209);
}

else 
{DynAbs.Tracing.TraceSender.TraceEnterCondition(6,2811,3209);

if ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,3024,3209) || true) && (f_6_3028_3044(arg, "-p"))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(6,3024,3209);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,3057,3077);

printResults = true;
DynAbs.Tracing.TraceSender.TraceExitCondition(6,3024,3209);
}

else 
{DynAbs.Tracing.TraceSender.TraceEnterCondition(6,3024,3209);

if ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,3093,3209) || true) && (f_6_3097_3113(arg, "-m"))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(6,3093,3209);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,3126,3143);

printMsgs = true;
DynAbs.Tracing.TraceSender.TraceExitCondition(6,3093,3209);
}

else 
{DynAbs.Tracing.TraceSender.TraceEnterCondition(6,3093,3209);

if ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,3159,3209) || true) && (f_6_3163_3179(arg, "-h"))
)			

{DynAbs.Tracing.TraceSender.TraceEnterCondition(6,3159,3209);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,3195,3203);

f_6_3195_3202();
DynAbs.Tracing.TraceSender.TraceExitCondition(6,3159,3209);
}
DynAbs.Tracing.TraceSender.TraceExitCondition(6,3093,3209);
}
DynAbs.Tracing.TraceSender.TraceExitCondition(6,3024,3209);
}
DynAbs.Tracing.TraceSender.TraceExitCondition(6,2811,3209);
}
DynAbs.Tracing.TraceSender.TraceExitCondition(6,2725,3214);
}
}catch(System.Exception) { DynAbs.Tracing.TraceSender.TraceExitLoopByException(6,2725,3214);
 throw; }finally{DynAbs.Tracing.TraceSender.TraceExitLoop(6,2725,3214);
}
if ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,3218,3247) || true) && (points == 0)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(6,3218,3247);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,3239,3247);

f_6_3239_3246();
DynAbs.Tracing.TraceSender.TraceExitCondition(6,3218,3247);
}
DynAbs.Tracing.TraceSender.TraceExitStaticMethod(6,2637,3251);

int
f_6_2736_2747(string[]
this_param)
{
var return_v = this_param.Length ;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(6, 2736, 2747);
return return_v;
}


bool
f_6_2751_2774(string
this_param,string
value)
{
var return_v = this_param.StartsWith( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(6, 2751, 2774);
return return_v;
}


bool
f_6_2815_2831(string
this_param,string
value)
{
var return_v = this_param.Equals( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(6, 2815, 2831);
return return_v;
}


int
f_6_2852_2863(string[]
this_param)
{
var return_v = this_param.Length;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(6, 2852, 2863);
return return_v;
}


int
f_6_2887_2920(string
value)
{
var return_v = System.Convert.ToInt32( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(6, 2887, 2920);
return return_v;
}


System.Exception
f_6_2951_3007(string
message)
{
var return_v = new System.Exception( message);
DynAbs.Tracing.TraceSender.TraceEndInvocation(6, 2951, 3007);
return return_v;
}


bool
f_6_3028_3044(string
this_param,string
value)
{
var return_v = this_param.Equals( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(6, 3028, 3044);
return return_v;
}


bool
f_6_3097_3113(string
this_param,string
value)
{
var return_v = this_param.Equals( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(6, 3097, 3113);
return return_v;
}


bool
f_6_3163_3179(string
this_param,string
value)
{
var return_v = this_param.Equals( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(6, 3163, 3179);
return return_v;
}


int
f_6_3195_3202()
{
usage();
DynAbs.Tracing.TraceSender.TraceEndInvocation(6, 3195, 3202);
return 0;
}


int
f_6_3239_3246()
{
usage();
DynAbs.Tracing.TraceSender.TraceEndInvocation(6, 3239, 3246);
return 0;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(6,2637,3251);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(6,2637,3251);
}
		}

private static void usage()
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterStaticMethod(6,3331,3798);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,3366,3447);

f_6_3366_3446(f_6_3366_3386(), "usage: java Voronoi -n <points> [-p] [-m] [-h]");
DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,3451,3528);

f_6_3451_3527(f_6_3451_3471(), "    -n the number of points in the diagram");
DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,3532,3630);

f_6_3532_3629(f_6_3532_3552(), "    -p (print detailed results/messages - the voronoi diagram>)");
DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,3634,3703);

f_6_3634_3702(f_6_3634_3654(), "    -v (print informative message)");
DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,3707,3763);

f_6_3707_3762(f_6_3707_3727(), "    -h (this message)");
DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,3767,3794);

f_6_3767_3793(0);
DynAbs.Tracing.TraceSender.TraceExitStaticMethod(6,3331,3798);

System.IO.TextWriter
f_6_3366_3386()
{
var return_v = 		System.Console.Error;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(6, 3366, 3386);
return return_v;
}


int
f_6_3366_3446(System.IO.TextWriter
this_param,string
value)
{
this_param.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(6, 3366, 3446);
return 0;
}


System.IO.TextWriter
f_6_3451_3471()
{
var return_v = 		System.Console.Error;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(6, 3451, 3471);
return return_v;
}


int
f_6_3451_3527(System.IO.TextWriter
this_param,string
value)
{
this_param.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(6, 3451, 3527);
return 0;
}


System.IO.TextWriter
f_6_3532_3552()
{
var return_v = 		System.Console.Error;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(6, 3532, 3552);
return return_v;
}


int
f_6_3532_3629(System.IO.TextWriter
this_param,string
value)
{
this_param.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(6, 3532, 3629);
return 0;
}


System.IO.TextWriter
f_6_3634_3654()
{
var return_v = 		System.Console.Error;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(6, 3634, 3654);
return return_v;
}


int
f_6_3634_3702(System.IO.TextWriter
this_param,string
value)
{
this_param.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(6, 3634, 3702);
return 0;
}


System.IO.TextWriter
f_6_3707_3727()
{
var return_v = 		System.Console.Error;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(6, 3707, 3727);
return return_v;
}


int
f_6_3707_3762(System.IO.TextWriter
this_param,string
value)
{
this_param.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(6, 3707, 3762);
return 0;
}


int
f_6_3767_3793(int
exitCode)
{
System.Environment.Exit( exitCode);
DynAbs.Tracing.TraceSender.TraceEndInvocation(6, 3767, 3793);
return 0;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(6,3331,3798);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(6,3331,3798);
}
		}

public Voronoi()
{
DynAbs.Tracing.TraceSender.TraceEnterConstructor(6,643,3801);
DynAbs.Tracing.TraceSender.TraceExitConstructor(6,643,3801);

DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(6,643,3801);
}


static Voronoi()
{
DynAbs.Tracing.TraceSender.TraceEnterStaticConstructor(6,643,3801);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,744,754);
points = 0;DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,840,857);
printMsgs = false;DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,987,1007);
printResults = false;DynAbs.Tracing.TraceSender.TraceExitStaticConstructor(6,643,3801);

DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(6,643,3801);
}

		int ___ignore_me___=DynAbs.Tracing.TraceSender.TraceBeforeConstructor(6,643,3801);
}
