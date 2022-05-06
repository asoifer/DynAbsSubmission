
using System;
public class Perimeter
{
private static int levels ;

private static bool printResult ;

private static bool printMsgs ;

public static void Main(String[] args)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterStaticMethod(5,1070,2224);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,1116,1135);

f_5_1116_1134(args);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,1141,1164);

int 
size = 1 << levels
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,1168,1198);

int 
msize = 1 << (levels - 1)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,1202,1234);

QuadTreeNode.gcmp = size * 1024;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,1238,1271);

QuadTreeNode.lcmp = msize * 1024;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,1277,1310);

var 
start0 = f_5_1290_1309()
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,1314,1406);

QuadTreeNode 
tree = f_5_1334_1405(msize, 0, 0, null, Quadrant.cSouthEast, levels)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,1410,1441);

var 
end0 = f_5_1421_1440()
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,1449,1482);

var 
start1 = f_5_1462_1481()
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,1486,1516);

int 
leaves = f_5_1499_1515(tree)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,1520,1551);

var 
end1 = f_5_1531_1550()
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,1559,1592);

var 
start2 = f_5_1572_1591()
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,1596,1628);

int 
perm = f_5_1607_1627(tree, size)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,1632,1663);

var 
end2 = f_5_1643_1662()
;

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,1669,1794) || true) && (printResult)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(5,1669,1794);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,1694,1736);

f_5_1694_1735("Perimeter is " + DynAbs.Tracing.TraceSender.TraceInvocationWrapper(() => (perm).ToString(),5,1730,1734));
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,1741,1789);

f_5_1741_1788("Number of leaves " + DynAbs.Tracing.TraceSender.TraceInvocationWrapper(() => (leaves).ToString(),5,1781,1787));
DynAbs.Tracing.TraceSender.TraceExitCondition(5,1669,1794);
}

if ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,1800,2123) || true) && (printMsgs)
) 

{DynAbs.Tracing.TraceSender.TraceEnterCondition(5,1800,2123);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,1826,1919);

f_5_1826_1918("QuadTree alloc time " + DynAbs.Tracing.TraceSender.TraceInvocationWrapper(() => ((f_5_1870_1909(f_5_1870_1891(ref end0, start0)))/1000.0).ToString(),5,1869,1917));
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,1925,2016);

f_5_1925_2015("Count leaves time " + DynAbs.Tracing.TraceSender.TraceInvocationWrapper(() => ((f_5_1967_2006(f_5_1967_1988(ref end1, start1)))/1000.0).ToString(),5,1966,2014));
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,2022,2118);

f_5_2022_2117("Perimeter compute time " + DynAbs.Tracing.TraceSender.TraceInvocationWrapper(() => ((f_5_2069_2108(f_5_2069_2090(ref end2, start2)))/1000.0).ToString(),5,2068,2116));
DynAbs.Tracing.TraceSender.TraceExitCondition(5,1800,2123);
}
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,2127,2155);

var 
slicingVariable1 = perm
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,2159,2189);

var 
slicingVariable2 = leaves
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,2193,2220);

f_5_2193_2219("Done!");
DynAbs.Tracing.TraceSender.TraceExitStaticMethod(5,1070,2224);

int
f_5_1116_1134(string[]
args)
{
parseCmdLine( args);
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 1116, 1134);
return 0;
}


System.DateTime
f_5_1290_1309()
{
var return_v = System.DateTime.Now;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(5, 1290, 1309);
return return_v;
}


QuadTreeNode
f_5_1334_1405(int
size,int
center_x,int
center_y,QuadTreeNode
parent,Quadrant
quadrant,int
level)
{
var return_v = QuadTreeNode.createTree( size, center_x, center_y, parent, quadrant, level);
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 1334, 1405);
return return_v;
}


System.DateTime
f_5_1421_1440()
{
var return_v = System.DateTime.Now;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(5, 1421, 1440);
return return_v;
}


System.DateTime
f_5_1462_1481()
{
var return_v = System.DateTime.Now;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(5, 1462, 1481);
return return_v;
}


int
f_5_1499_1515(QuadTreeNode
this_param)
{
var return_v = this_param.countTree();
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 1499, 1515);
return return_v;
}


System.DateTime
f_5_1531_1550()
{
var return_v = System.DateTime.Now;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(5, 1531, 1550);
return return_v;
}


System.DateTime
f_5_1572_1591()
{
var return_v = System.DateTime.Now;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(5, 1572, 1591);
return return_v;
}


int
f_5_1607_1627(QuadTreeNode
this_param,int
size)
{
var return_v = this_param.perimeter( size);
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 1607, 1627);
return return_v;
}


System.DateTime
f_5_1643_1662()
{
var return_v = System.DateTime.Now;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(5, 1643, 1662);
return return_v;
}


int
f_5_1694_1735(string
value)
{
Console.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 1694, 1735);
return 0;
}


int
f_5_1741_1788(string
value)
{
Console.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 1741, 1788);
return 0;
}


System.TimeSpan
f_5_1870_1891(ref System.DateTime
this_param,System.DateTime
value)
{
var return_v = this_param.Subtract( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 1870, 1891);
return return_v;
}


double
f_5_1870_1909(System.TimeSpan
this_param)
{
var return_v = this_param.TotalMilliseconds;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(5, 1870, 1909);
return return_v;
}


int
f_5_1826_1918(string
value)
{
Console.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 1826, 1918);
return 0;
}


System.TimeSpan
f_5_1967_1988(ref System.DateTime
this_param,System.DateTime
value)
{
var return_v = this_param.Subtract( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 1967, 1988);
return return_v;
}


double
f_5_1967_2006(System.TimeSpan
this_param)
{
var return_v = this_param.TotalMilliseconds;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(5, 1967, 2006);
return return_v;
}


int
f_5_1925_2015(string
value)
{
Console.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 1925, 2015);
return 0;
}


System.TimeSpan
f_5_2069_2090(ref System.DateTime
this_param,System.DateTime
value)
{
var return_v = this_param.Subtract( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 2069, 2090);
return return_v;
}


double
f_5_2069_2108(System.TimeSpan
this_param)
{
var return_v = this_param.TotalMilliseconds;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(5, 2069, 2108);
return return_v;
}


int
f_5_2022_2117(string
value)
{
Console.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 2022, 2117);
return 0;
}


int
f_5_2193_2219(string
value)
{
Console.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 2193, 2219);
return 0;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(5,1070,2224);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(5,1070,2224);
}
		}

private static void parseCmdLine(String[] args)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterStaticMethod(5,2328,2936);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,2383,2393);

int 
i = 0
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,2397,2408);

String 
arg
=default(String);
try {
while((DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,2414,2899) || true) && (i < f_5_2424_2435(args)&&(DynAbs.Tracing.TraceSender.Expression_True(5, 2420, 2462)&&f_5_2439_2462(args[i], "-")))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(5,2414,2899);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,2473,2489);

arg = args[i++];

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,2496,2894) || true) && (f_5_2499_2515(arg, "-l"))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(5,2496,2894);

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,2528,2694) || true) && (i < f_5_2535_2546(args))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(5,2528,2694);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,2561,2600);

levels = f_5_2570_2599(args[i++]);
DynAbs.Tracing.TraceSender.TraceExitCondition(5,2528,2694);
}

else

{DynAbs.Tracing.TraceSender.TraceEnterCondition(5,2528,2694);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,2631,2687);

throw f_5_2637_2686("-l requires the number of levels");
DynAbs.Tracing.TraceSender.TraceExitCondition(5,2528,2694);
}
DynAbs.Tracing.TraceSender.TraceExitCondition(5,2496,2894);
}

else 
{DynAbs.Tracing.TraceSender.TraceEnterCondition(5,2496,2894);

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,2710,2894) || true) && (f_5_2713_2729(arg, "-p"))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(5,2710,2894);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,2742,2761);

printResult = true;
DynAbs.Tracing.TraceSender.TraceExitCondition(5,2710,2894);
}

else 
{DynAbs.Tracing.TraceSender.TraceEnterCondition(5,2710,2894);

if ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,2777,2894) || true) && (f_5_2781_2797(arg, "-m"))
) 

{DynAbs.Tracing.TraceSender.TraceEnterCondition(5,2777,2894);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,2812,2829);

printMsgs = true;
DynAbs.Tracing.TraceSender.TraceExitCondition(5,2777,2894);
}

else 
{DynAbs.Tracing.TraceSender.TraceEnterCondition(5,2777,2894);

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,2848,2894) || true) && (f_5_2851_2867(arg, "-h"))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(5,2848,2894);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,2880,2888);

f_5_2880_2887();
DynAbs.Tracing.TraceSender.TraceExitCondition(5,2848,2894);
}
DynAbs.Tracing.TraceSender.TraceExitCondition(5,2777,2894);
}
DynAbs.Tracing.TraceSender.TraceExitCondition(5,2710,2894);
}
DynAbs.Tracing.TraceSender.TraceExitCondition(5,2496,2894);
}
DynAbs.Tracing.TraceSender.TraceExitCondition(5,2414,2899);
}
}catch(System.Exception) { DynAbs.Tracing.TraceSender.TraceExitLoopByException(5,2414,2899);
 throw; }finally{DynAbs.Tracing.TraceSender.TraceExitLoop(5,2414,2899);
}
if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,2903,2932) || true) && (levels == 0)
) 

{DynAbs.Tracing.TraceSender.TraceEnterCondition(5,2903,2932);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,2924,2932);

f_5_2924_2931();
DynAbs.Tracing.TraceSender.TraceExitCondition(5,2903,2932);
}
DynAbs.Tracing.TraceSender.TraceExitStaticMethod(5,2328,2936);

int
f_5_2424_2435(string[]
this_param)
{
var return_v = this_param.Length ;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(5, 2424, 2435);
return return_v;
}


bool
f_5_2439_2462(string
this_param,string
value)
{
var return_v = this_param.StartsWith( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 2439, 2462);
return return_v;
}


bool
f_5_2499_2515(string
this_param,string
value)
{
var return_v = this_param.Equals( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 2499, 2515);
return return_v;
}


int
f_5_2535_2546(string[]
this_param)
{
var return_v = this_param.Length;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(5, 2535, 2546);
return return_v;
}


int
f_5_2570_2599(string
s)
{
var return_v = System.Int32.Parse( s);
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 2570, 2599);
return return_v;
}


System.Exception
f_5_2637_2686(string
message)
{
var return_v = new System.Exception( message);
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 2637, 2686);
return return_v;
}


bool
f_5_2713_2729(string
this_param,string
value)
{
var return_v = this_param.Equals( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 2713, 2729);
return return_v;
}


bool
f_5_2781_2797(string
this_param,string
value)
{
var return_v = this_param.Equals( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 2781, 2797);
return return_v;
}


bool
f_5_2851_2867(string
this_param,string
value)
{
var return_v = this_param.Equals( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 2851, 2867);
return return_v;
}


int
f_5_2880_2887()
{
usage();
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 2880, 2887);
return 0;
}


int
f_5_2924_2931()
{
usage();
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 2924, 2931);
return 0;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(5,2328,2936);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(5,2328,2936);
}
		}

private static void usage()
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterStaticMethod(5,3011,3392);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,3046,3113);

f_5_3046_3112("usage: java Perimeter -l <num> [-p] [-m] [-h]");
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,3117,3197);

f_5_3117_3196("    -l number of levels in the quadtree (image size = 2^l)");
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,3201,3249);

f_5_3201_3248("    -p (print the results)");
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,3253,3310);

f_5_3253_3309("    -m (print informative messages)");
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,3314,3357);

f_5_3314_3356("    -h (this message)");
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,3361,3388);

f_5_3361_3387(0);
DynAbs.Tracing.TraceSender.TraceExitStaticMethod(5,3011,3392);

int
f_5_3046_3112(string
value)
{
Console.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 3046, 3112);
return 0;
}


int
f_5_3117_3196(string
value)
{
Console.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 3117, 3196);
return 0;
}


int
f_5_3201_3248(string
value)
{
Console.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 3201, 3248);
return 0;
}


int
f_5_3253_3309(string
value)
{
Console.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 3253, 3309);
return 0;
}


int
f_5_3314_3356(string
value)
{
Console.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 3314, 3356);
return 0;
}


int
f_5_3361_3387(int
exitCode)
{
System.Environment.Exit( exitCode);
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 3361, 3387);
return 0;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(5,3011,3392);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(5,3011,3392);
}
		}

public Perimeter()
{
DynAbs.Tracing.TraceSender.TraceEnterConstructor(5,637,3395);
DynAbs.Tracing.TraceSender.TraceExitConstructor(5,637,3395);

DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(5,637,3395);
}


static Perimeter()
{
DynAbs.Tracing.TraceSender.TraceEnterStaticConstructor(5,637,3395);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,741,751);
levels = 0;DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,830,849);
printResult = false;DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,931,948);
printMsgs = false;DynAbs.Tracing.TraceSender.TraceExitStaticConstructor(5,637,3395);

DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(5,637,3395);
}

		int ___ignore_me___=DynAbs.Tracing.TraceSender.TraceBeforeConstructor(5,637,3395);
}
