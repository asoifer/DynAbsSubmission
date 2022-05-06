public class Vertex : Vec2
{
internal Vertex left;

internal Vertex right;

internal static int seed;

public Vertex()
		{
			try
{DynAbs.Tracing.TraceSender.TraceEnterConstructor(5,457,480);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,251,255);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,359,364);
DynAbs.Tracing.TraceSender.TraceExitConstructor(5,457,480);
}catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(5,457,480);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(5,457,480);
}
		}

public Vertex(double x, double y)
:base(f_5_529_530_C(x) ,y)
		{
			try
{DynAbs.Tracing.TraceSender.TraceEnterConstructor(5,485,575);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,251,255);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,359,364);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,542,554);

left = null;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,558,571);

right = null;
DynAbs.Tracing.TraceSender.TraceExitConstructor(5,485,575);
}catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(5,485,575);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(5,485,575);
}
		}

public virtual void setLeft(Vertex l)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(5,580,638);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,625,634);

left = l;
DynAbs.Tracing.TraceSender.TraceExitMethod(5,580,638);
	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(5,580,638);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(5,580,638);
}
		}

public virtual void setRight(Vertex r)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(5,643,703);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,689,699);

right = r;
DynAbs.Tracing.TraceSender.TraceExitMethod(5,643,703);
	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(5,643,703);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(5,643,703);
}
		}

public virtual Vertex getLeft()
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(5,708,763);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,747,759);

return left;
DynAbs.Tracing.TraceSender.TraceExitMethod(5,708,763);
	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(5,708,763);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(5,708,763);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

public virtual Vertex getRight()
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(5,768,825);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,808,821);

return right;
DynAbs.Tracing.TraceSender.TraceExitMethod(5,768,825);
	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(5,768,825);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(5,768,825);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

internal static Vertex createPoints(int n, MyDouble curmax, int i)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterStaticMethod(5,876,1401);

if ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,950,987) || true) && (n < 1)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(5,950,987);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,970,982);

return null;
DynAbs.Tracing.TraceSender.TraceExitCondition(5,950,987);
}
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,995,1021);

Vertex 
cur = f_5_1008_1020()
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,1029,1082);

Vertex 
right = f_5_1044_1081(n / 2, curmax, i)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,1086,1097);

i -= n / 2;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,1101,1177);

cur.x = curmax.value * f_5_1124_1176(f_5_1140_1171(f_5_1156_1170())/ i);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,1181,1204);

cur.y = f_5_1189_1203();
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,1208,1249);

cur.norm = cur.x * cur.x + cur.y * cur.y;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,1253,1271);

cur.right = right;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,1275,1298);

curmax.value = f_5_1290_1297(cur);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,1302,1358);

Vertex 
left = f_5_1316_1357(n / 2, curmax, i - 1)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,1366,1382);

cur.left = left;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,1386,1397);

return cur;
DynAbs.Tracing.TraceSender.TraceExitStaticMethod(5,876,1401);

Vertex
f_5_1008_1020()
{
var return_v = new Vertex();
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 1008, 1020);
return return_v;
}


Vertex
f_5_1044_1081(int
n,MyDouble
curmax,int
i)
{
var return_v = Vertex.createPoints( n, curmax, i);
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 1044, 1081);
return return_v;
}


double
f_5_1156_1170()
{
var return_v = Vertex.drand();
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 1156, 1170);
return return_v;
}


double
f_5_1140_1171(double
d)
{
var return_v = System.Math.Log( d);
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 1140, 1171);
return return_v;
}


double
f_5_1124_1176(double
d)
{
var return_v = System.Math.Exp( d);
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 1124, 1176);
return return_v;
}


double
f_5_1189_1203()
{
var return_v = Vertex.drand();
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 1189, 1203);
return return_v;
}


double
f_5_1290_1297(Vertex
this_param)
{
var return_v = this_param.X();
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 1290, 1297);
return return_v;
}


Vertex
f_5_1316_1357(int
n,MyDouble
curmax,int
i)
{
var return_v = Vertex.createPoints( n, curmax, i);
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 1316, 1357);
return return_v;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(5,876,1401);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(5,876,1401);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

internal virtual Edge buildDelaunayTriangulation(Vertex extra)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(5,1457,1598);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,1527,1566);

EdgePair 
retVal = f_5_1545_1565(this, extra)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,1570,1594);

return f_5_1577_1593(retVal);
DynAbs.Tracing.TraceSender.TraceExitMethod(5,1457,1598);

EdgePair
f_5_1545_1565(Vertex
this_param,Vertex
extra)
{
var return_v = this_param.buildDelaunay( extra);
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 1545, 1565);
return return_v;
}


Edge
f_5_1577_1593(EdgePair
this_param)
{
var return_v = this_param.getLeft();
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 1577, 1593);
return return_v;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(5,1457,1598);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(5,1457,1598);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

internal virtual EdgePair buildDelaunay(Vertex extra)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(5,1727,3143);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,1788,1811);

EdgePair 
retval = null
;

if ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,1815,3121) || true) && (f_5_1819_1829(this)!= null &&(DynAbs.Tracing.TraceSender.Expression_True(5, 1819, 1858)&&f_5_1841_1850(this)!= null))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(5,1815,3121);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,1915,1938);

Vertex 
minx = f_5_1929_1937(this)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,1943,1963);

Vertex 
maxx = extra
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,1973,2025);

EdgePair 
delright = f_5_1993_2024(f_5_1993_2003(this), extra)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,2030,2079);

EdgePair 
delleft = f_5_2049_2078(f_5_2049_2058(this), this)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,2089,2191);

retval = f_5_2098_2190(f_5_2111_2128(delleft), f_5_2130_2148(delleft), f_5_2150_2168(delright), f_5_2170_2189(delright));
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,2201,2229);

Edge 
ldo = f_5_2212_2228(retval)
;
try {
while ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,2234,2296) || true) && (f_5_2241_2251(ldo)!= minx)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(5,2234,2296);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,2272,2290);

ldo = f_5_2278_2289(ldo);
DynAbs.Tracing.TraceSender.TraceExitCondition(5,2234,2296);
}
}catch(System.Exception) { DynAbs.Tracing.TraceSender.TraceExitLoopByException(5,2234,2296);
 throw; }finally{DynAbs.Tracing.TraceSender.TraceExitLoop(5,2234,2296);
}DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,2301,2330);

Edge 
rdo = f_5_2312_2329(retval)
;
try {
while ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,2335,2397) || true) && (f_5_2342_2352(rdo)!= maxx)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(5,2335,2397);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,2373,2391);

rdo = f_5_2379_2390(rdo);
DynAbs.Tracing.TraceSender.TraceExitCondition(5,2335,2397);
}
}catch(System.Exception) { DynAbs.Tracing.TraceSender.TraceExitLoopByException(5,2335,2397);
 throw; }finally{DynAbs.Tracing.TraceSender.TraceExitLoop(5,2335,2397);
}DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,2407,2439);

retval = f_5_2416_2438(ldo, rdo);
DynAbs.Tracing.TraceSender.TraceExitCondition(5,1815,3121);
}

else 
{DynAbs.Tracing.TraceSender.TraceEnterCondition(5,1815,3121);

if ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,2458,3121) || true) && (f_5_2462_2471(this)== null)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(5,2458,3121);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,2511,2547);

Edge 
a = f_5_2520_2546(this, extra)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,2552,2592);

retval = f_5_2561_2591(a, f_5_2577_2590(a));
DynAbs.Tracing.TraceSender.TraceExitCondition(5,2458,3121);
}

else

{DynAbs.Tracing.TraceSender.TraceEnterCondition(5,2458,3121);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,2721,2743);

Vertex 
s1 = f_5_2733_2742(this)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,2748,2765);

Vertex 
s2 = this
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,2770,2788);

Vertex 
s3 = extra
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,2793,2824);

Edge 
a = f_5_2802_2823(s1, s2)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,2829,2860);

Edge 
b = f_5_2838_2859(s2, s3)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,2865,2889);

f_5_2865_2888(f_5_2865_2878(			a), b);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,2894,2920);

Edge 
c = f_5_2903_2919(b, a)
;

if ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,2925,3116) || true) && (f_5_2929_2943(s1, s3, s2))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(5,2925,3116);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,2956,2996);

retval = f_5_2965_2995(f_5_2978_2991(c), c);
DynAbs.Tracing.TraceSender.TraceExitCondition(5,2925,3116);
}

else

{DynAbs.Tracing.TraceSender.TraceEnterCondition(5,2925,3116);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,3023,3063);

retval = f_5_3032_3062(a, f_5_3048_3061(b));

if ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,3069,3110) || true) && (f_5_3073_3087(s1, s2, s3))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(5,3069,3110);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,3095,3110);

f_5_3095_3109(					c);
DynAbs.Tracing.TraceSender.TraceExitCondition(5,3069,3110);
}
DynAbs.Tracing.TraceSender.TraceExitCondition(5,2925,3116);
}
DynAbs.Tracing.TraceSender.TraceExitCondition(5,2458,3121);
}
DynAbs.Tracing.TraceSender.TraceExitCondition(5,1815,3121);
}
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,3125,3139);

return retval;
DynAbs.Tracing.TraceSender.TraceExitMethod(5,1727,3143);

Vertex
f_5_1819_1829(Vertex
this_param)
{
var return_v = this_param.getRight();
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 1819, 1829);
return return_v;
}


Vertex
f_5_1841_1850(Vertex
this_param)
{
var return_v = this_param.getLeft();
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 1841, 1850);
return return_v;
}


Vertex
f_5_1929_1937(Vertex
this_param)
{
var return_v = this_param.getLow();
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 1929, 1937);
return return_v;
}


Vertex
f_5_1993_2003(Vertex
this_param)
{
var return_v = this_param.getRight();
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 1993, 2003);
return return_v;
}


EdgePair
f_5_1993_2024(Vertex
this_param,Vertex
extra)
{
var return_v = this_param.buildDelaunay( extra);
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 1993, 2024);
return return_v;
}


Vertex
f_5_2049_2058(Vertex
this_param)
{
var return_v = this_param.getLeft();
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 2049, 2058);
return return_v;
}


EdgePair
f_5_2049_2078(Vertex
this_param,Vertex
extra)
{
var return_v = this_param.buildDelaunay( extra);
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 2049, 2078);
return return_v;
}


Edge
f_5_2111_2128(EdgePair
this_param)
{
var return_v = this_param.getLeft();
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 2111, 2128);
return return_v;
}


Edge
f_5_2130_2148(EdgePair
this_param)
{
var return_v = this_param.getRight();
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 2130, 2148);
return return_v;
}


Edge
f_5_2150_2168(EdgePair
this_param)
{
var return_v = this_param.getLeft();
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 2150, 2168);
return return_v;
}


Edge
f_5_2170_2189(EdgePair
this_param)
{
var return_v = this_param.getRight();
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 2170, 2189);
return return_v;
}


EdgePair
f_5_2098_2190(Edge
ldo,Edge
ldi,Edge
rdi,Edge
rdo)
{
var return_v = Edge.doMerge( ldo, ldi, rdi, rdo);
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 2098, 2190);
return return_v;
}


Edge
f_5_2212_2228(EdgePair
this_param)
{
var return_v = this_param.getLeft();
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 2212, 2228);
return return_v;
}


Vertex
f_5_2241_2251(Edge
this_param)
{
var return_v = this_param.orig();
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 2241, 2251);
return return_v;
}


Edge
f_5_2278_2289(Edge
this_param)
{
var return_v = this_param.rPrev();
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 2278, 2289);
return return_v;
}


Edge
f_5_2312_2329(EdgePair
this_param)
{
var return_v = this_param.getRight();
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 2312, 2329);
return return_v;
}


Vertex
f_5_2342_2352(Edge
this_param)
{
var return_v = this_param.orig();
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 2342, 2352);
return return_v;
}


Edge
f_5_2379_2390(Edge
this_param)
{
var return_v = this_param.lPrev();
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 2379, 2390);
return return_v;
}


EdgePair
f_5_2416_2438(Edge
l,Edge
r)
{
var return_v = new EdgePair( l, r);
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 2416, 2438);
return return_v;
}


Vertex
f_5_2462_2471(Vertex
this_param)
{
var return_v = this_param.getLeft();
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 2462, 2471);
return return_v;
}


Edge
f_5_2520_2546(Vertex
o,Vertex
d)
{
var return_v = Edge.makeEdge( o, d);
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 2520, 2546);
return return_v;
}


Edge
f_5_2577_2590(Edge
this_param)
{
var return_v = this_param.symmetric();
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 2577, 2590);
return return_v;
}


EdgePair
f_5_2561_2591(Edge
l,Edge
r)
{
var return_v = new EdgePair( l, r);
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 2561, 2591);
return return_v;
}


Vertex
f_5_2733_2742(Vertex
this_param)
{
var return_v = this_param.getLeft();
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 2733, 2742);
return return_v;
}


Edge
f_5_2802_2823(Vertex
o,Vertex
d)
{
var return_v = Edge.makeEdge( o, d);
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 2802, 2823);
return return_v;
}


Edge
f_5_2838_2859(Vertex
o,Vertex
d)
{
var return_v = Edge.makeEdge( o, d);
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 2838, 2859);
return return_v;
}


Edge
f_5_2865_2878(Edge
this_param)
{
var return_v = this_param.symmetric();
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 2865, 2878);
return return_v;
}


int
f_5_2865_2888(Edge
this_param,Edge
b)
{
this_param.splice( b);
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 2865, 2888);
return 0;
}


Edge
f_5_2903_2919(Edge
this_param,Edge
b)
{
var return_v = this_param.connectLeft( b);
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 2903, 2919);
return return_v;
}


bool
f_5_2929_2943(Vertex
this_param,Vertex
b,Vertex
c)
{
var return_v = this_param.ccw( b, c);
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 2929, 2943);
return return_v;
}


Edge
f_5_2978_2991(Edge
this_param)
{
var return_v = this_param.symmetric();
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 2978, 2991);
return return_v;
}


EdgePair
f_5_2965_2995(Edge
l,Edge
r)
{
var return_v = new EdgePair( l, r);
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 2965, 2995);
return return_v;
}


Edge
f_5_3048_3061(Edge
this_param)
{
var return_v = this_param.symmetric();
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 3048, 3061);
return return_v;
}


EdgePair
f_5_3032_3062(Edge
l,Edge
r)
{
var return_v = new EdgePair( l, r);
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 3032, 3062);
return return_v;
}


bool
f_5_3073_3087(Vertex
this_param,Vertex
b,Vertex
c)
{
var return_v = this_param.ccw( b, c);
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 3073, 3087);
return return_v;
}


int
f_5_3095_3109(Edge
this_param)
{
this_param.deleteEdge();
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 3095, 3109);
return 0;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(5,1727,3143);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(5,1727,3143);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

internal virtual void print()
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(5,3184,3487);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,3221,3234);

Vertex 
tleft
=default(Vertex);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,3238,3252);

Vertex 
tright
=default(Vertex);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,3260,3311);

f_5_3260_3310("X=" + DynAbs.Tracing.TraceSender.TraceInvocationWrapper(() => (f_5_3292_3295(this)).ToString(),5,3292,3295)+ " Y=" + DynAbs.Tracing.TraceSender.TraceInvocationWrapper(() => (f_5_3306_3309(this)).ToString(),5,3306,3309));

if ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,3315,3396) || true) && (left == null)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(5,3315,3396);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,3337,3370);

f_5_3337_3369("NULL");
DynAbs.Tracing.TraceSender.TraceExitCondition(5,3315,3396);
}

else

{DynAbs.Tracing.TraceSender.TraceEnterCondition(5,3315,3396);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,3383,3396);

f_5_3383_3395(			left);
DynAbs.Tracing.TraceSender.TraceExitCondition(5,3315,3396);
}

if ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,3400,3483) || true) && (right == null)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(5,3400,3483);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,3423,3456);

f_5_3423_3455("NULL");
DynAbs.Tracing.TraceSender.TraceExitCondition(5,3400,3483);
}

else

{DynAbs.Tracing.TraceSender.TraceEnterCondition(5,3400,3483);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,3469,3483);

f_5_3469_3482(			right);
DynAbs.Tracing.TraceSender.TraceExitCondition(5,3400,3483);
}
DynAbs.Tracing.TraceSender.TraceExitMethod(5,3184,3487);

double
f_5_3292_3295(Vertex
this_param)
{
var return_v = this_param.X();
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 3292, 3295);
return return_v;
}


double
f_5_3306_3309(Vertex
this_param)
{
var return_v = this_param.Y();
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 3306, 3309);
return return_v;
}


int
f_5_3260_3310(string
value)
{
System.Console.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 3260, 3310);
return 0;
}


int
f_5_3337_3369(string
value)
{
System.Console.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 3337, 3369);
return 0;
}


int
f_5_3383_3395(Vertex
this_param)
{
this_param.print();
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 3383, 3395);
return 0;
}


int
f_5_3423_3455(string
value)
{
System.Console.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 3423, 3455);
return 0;
}


int
f_5_3469_3482(Vertex
this_param)
{
this_param.print();
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 3469, 3482);
return 0;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(5,3184,3487);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(5,3184,3487);
}
		}

internal virtual Vertex getLow()
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(5,3553,3712);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,3593,3605);

Vertex 
temp
=default(Vertex);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,3609,3628);

Vertex 
tree = this
;
try {
while ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,3636,3692) || true) && ((temp = f_5_3651_3665(tree)) != null)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(5,3636,3692);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,3680,3692);

tree = temp;
DynAbs.Tracing.TraceSender.TraceExitCondition(5,3636,3692);
}
}catch(System.Exception) { DynAbs.Tracing.TraceSender.TraceExitLoopByException(5,3636,3692);
 throw; }finally{DynAbs.Tracing.TraceSender.TraceExitLoop(5,3636,3692);
}DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,3696,3708);

return tree;
DynAbs.Tracing.TraceSender.TraceExitMethod(5,3553,3712);

Vertex
f_5_3651_3665(Vertex
this_param)
{
var return_v = this_param.getLeft();
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 3651, 3665);
return return_v;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(5,3553,3712);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(5,3553,3712);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

internal virtual bool incircle(Vertex b, Vertex c, Vertex d)
		{
			try
	// incircle, as in the Guibas-Stolfi paper. */
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(5,3886,4874);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,4003,4014);

double 
adx
=default(double);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,4018,4029);

double 
ady
=default(double);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,4033,4044);

double 
bdx
=default(double);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,4048,4059);

double 
bdy
=default(double);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,4063,4074);

double 
cdx
=default(double);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,4078,4089);

double 
cdy
=default(double);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,4093,4103);

double 
dx
=default(double);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,4107,4117);

double 
dy
=default(double);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,4121,4134);

double 
anorm
=default(double);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,4138,4151);

double 
bnorm
=default(double);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,4155,4168);

double 
cnorm
=default(double);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,4172,4185);

double 
dnorm
=default(double);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,4189,4201);

double 
dret
=default(double);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,4205,4218);

Vertex 
loc_a
=default(Vertex);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,4222,4235);

Vertex 
loc_b
=default(Vertex);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,4239,4252);

Vertex 
loc_c
=default(Vertex);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,4256,4269);

Vertex 
loc_d
=default(Vertex);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,4277,4288);

int 
donedx
=default(int);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,4292,4303);

int 
donedy
=default(int);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,4307,4321);

int 
donednorm
=default(int);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,4325,4335);

loc_d = d;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,4339,4354);

dx = f_5_4344_4353(loc_d);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,4358,4373);

dy = f_5_4363_4372(loc_d);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,4377,4398);

dnorm = f_5_4385_4397(loc_d);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,4402,4415);

loc_a = this;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,4419,4440);

adx = f_5_4425_4434(loc_a)- dx;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,4444,4465);

ady = f_5_4450_4459(loc_a)- dy;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,4469,4490);

anorm = f_5_4477_4489(loc_a);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,4494,4504);

loc_b = b;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,4508,4529);

bdx = f_5_4514_4523(loc_b)- dx;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,4533,4554);

bdy = f_5_4539_4548(loc_b)- dy;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,4558,4579);

bnorm = f_5_4566_4578(loc_b);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,4583,4593);

loc_c = c;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,4597,4618);

cdx = f_5_4603_4612(loc_c)- dx;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,4622,4643);

cdy = f_5_4628_4637(loc_c)- dy;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,4647,4668);

cnorm = f_5_4655_4667(loc_c);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,4672,4721);

dret = (anorm - dnorm) * (bdx * cdy - bdy * cdx);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,4725,4775);

dret += (bnorm - dnorm) * (cdx * ady - cdy * adx);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,4779,4829);

dret += (cnorm - dnorm) * (adx * bdy - ady * bdx);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,4833,4870);

return ((DynAbs.Tracing.TraceSender.Conditional_F1(5, 4841, 4853)||(((0.0 < dret) &&DynAbs.Tracing.TraceSender.Conditional_F2(5, 4856, 4860))||DynAbs.Tracing.TraceSender.Conditional_F3(5, 4863, 4868)))?true :false);
DynAbs.Tracing.TraceSender.TraceExitMethod(5,3886,4874);

double
f_5_4344_4353(Vertex
this_param)
{
var return_v = this_param.X();
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 4344, 4353);
return return_v;
}


double
f_5_4363_4372(Vertex
this_param)
{
var return_v = this_param.Y();
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 4363, 4372);
return return_v;
}


double
f_5_4385_4397(Vertex
this_param)
{
var return_v = this_param.Norm();
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 4385, 4397);
return return_v;
}


double
f_5_4425_4434(Vertex
this_param)
{
var return_v = this_param.X();
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 4425, 4434);
return return_v;
}


double
f_5_4450_4459(Vertex
this_param)
{
var return_v = this_param.Y();
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 4450, 4459);
return return_v;
}


double
f_5_4477_4489(Vertex
this_param)
{
var return_v = this_param.Norm();
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 4477, 4489);
return return_v;
}


double
f_5_4514_4523(Vertex
this_param)
{
var return_v = this_param.X();
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 4514, 4523);
return return_v;
}


double
f_5_4539_4548(Vertex
this_param)
{
var return_v = this_param.Y();
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 4539, 4548);
return return_v;
}


double
f_5_4566_4578(Vertex
this_param)
{
var return_v = this_param.Norm();
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 4566, 4578);
return return_v;
}


double
f_5_4603_4612(Vertex
this_param)
{
var return_v = this_param.X();
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 4603, 4612);
return return_v;
}


double
f_5_4628_4637(Vertex
this_param)
{
var return_v = this_param.Y();
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 4628, 4637);
return return_v;
}


double
f_5_4655_4667(Vertex
this_param)
{
var return_v = this_param.Norm();
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 4655, 4667);
return return_v;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(5,3886,4874);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(5,3886,4874);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

internal virtual bool ccw(Vertex b, Vertex c)
		{
			try
	// TRUE iff this, B, C form a counterclockwise oriented triangle */
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(5,4879,5508);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,5002,5014);

double 
dret
=default(double);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,5018,5028);

double 
xa
=default(double);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,5032,5042);

double 
ya
=default(double);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,5046,5056);

double 
xb
=default(double);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,5060,5070);

double 
yb
=default(double);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,5074,5084);

double 
xc
=default(double);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,5088,5098);

double 
yc
=default(double);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,5102,5115);

Vertex 
loc_a
=default(Vertex);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,5119,5132);

Vertex 
loc_b
=default(Vertex);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,5136,5149);

Vertex 
loc_c
=default(Vertex);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,5157,5168);

int 
donexa
=default(int);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,5172,5183);

int 
doneya
=default(int);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,5187,5198);

int 
donexb
=default(int);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,5202,5213);

int 
doneyb
=default(int);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,5217,5228);

int 
donexc
=default(int);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,5232,5243);

int 
doneyc
=default(int);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,5251,5264);

loc_a = this;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,5268,5283);

xa = f_5_5273_5282(loc_a);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,5287,5302);

ya = f_5_5292_5301(loc_a);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,5306,5316);

loc_b = b;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,5320,5335);

xb = f_5_5325_5334(loc_b);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,5339,5354);

yb = f_5_5344_5353(loc_b);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,5358,5368);

loc_c = c;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,5372,5387);

xc = f_5_5377_5386(loc_c);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,5391,5406);

yc = f_5_5396_5405(loc_c);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,5410,5463);

dret = (xa - xc) * (yb - yc) - (xb - xc) * (ya - yc);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,5467,5504);

return ((DynAbs.Tracing.TraceSender.Conditional_F1(5, 5475, 5487)||(((dret > 0.0) &&DynAbs.Tracing.TraceSender.Conditional_F2(5, 5490, 5494))||DynAbs.Tracing.TraceSender.Conditional_F3(5, 5497, 5502)))?true :false);
DynAbs.Tracing.TraceSender.TraceExitMethod(5,4879,5508);

double
f_5_5273_5282(Vertex
this_param)
{
var return_v = this_param.X();
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 5273, 5282);
return return_v;
}


double
f_5_5292_5301(Vertex
this_param)
{
var return_v = this_param.Y();
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 5292, 5301);
return return_v;
}


double
f_5_5325_5334(Vertex
this_param)
{
var return_v = this_param.X();
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 5325, 5334);
return return_v;
}


double
f_5_5344_5353(Vertex
this_param)
{
var return_v = this_param.Y();
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 5344, 5353);
return return_v;
}


double
f_5_5377_5386(Vertex
this_param)
{
var return_v = this_param.X();
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 5377, 5386);
return return_v;
}


double
f_5_5396_5405(Vertex
this_param)
{
var return_v = this_param.Y();
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 5396, 5405);
return return_v;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(5,4879,5508);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(5,4879,5508);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

internal static int mult(int p, int q)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterStaticMethod(5,5580,5854);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,5626,5633);

int 
p1
=default(int);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,5637,5644);

int 
p0
=default(int);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,5648,5655);

int 
q1
=default(int);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,5659,5666);

int 
q0
=default(int);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,5670,5691);

int 
CONST_m1 = 10000
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,5699,5717);

p1 = p / CONST_m1;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,5721,5739);

p0 = p % CONST_m1;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,5743,5761);

q1 = q / CONST_m1;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,5765,5783);

q0 = q % CONST_m1;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,5787,5850);

return (((p0 * q1 + p1 * q0) % CONST_m1) * CONST_m1 + p0 * q0);
DynAbs.Tracing.TraceSender.TraceExitStaticMethod(5,5580,5854);
	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(5,5580,5854);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(5,5580,5854);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

internal static int skiprand(int seed, int n)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterStaticMethod(5,5911,6028);
try {		for (; (DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,5964,6008) || true) && (n != 0)
; DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,5979,5982)
,n--,DynAbs.Tracing.TraceSender.TraceExitCondition(5,5964,6008))

{DynAbs.Tracing.TraceSender.TraceEnterCondition(5,5964,6008);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,5988,6008);

seed = f_5_5995_6007(seed);
}
}catch(System.Exception) { DynAbs.Tracing.TraceSender.TraceExitLoopByException(5,1,45);
 throw; }finally{DynAbs.Tracing.TraceSender.TraceExitLoop(5,1,45);
}DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,6012,6024);

return seed;
DynAbs.Tracing.TraceSender.TraceExitStaticMethod(5,5911,6028);

int
f_5_5995_6007(int
seed)
{
var return_v = random( seed);
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 5995, 6007);
return return_v;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(5,5911,6028);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(5,5911,6028);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

internal static int random(int seed)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterStaticMethod(5,6033,6159);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,6077,6100);

int 
CONST_b = 31415821
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,6108,6139);

seed = f_5_6115_6134(seed, CONST_b)+ 1;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,6143,6155);

return seed;
DynAbs.Tracing.TraceSender.TraceExitStaticMethod(5,6033,6159);

int
f_5_6115_6134(int
p,int
q)
{
var return_v = mult( p, q);
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 6115, 6134);
return return_v;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(5,6033,6159);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(5,6033,6159);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

internal static double drand()
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterStaticMethod(5,6164,6314);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,6202,6292);

double 
retval = ((double)(Vertex.seed = f_5_6242_6268(Vertex.seed))) / (double)2147483647
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,6296,6310);

return retval;
DynAbs.Tracing.TraceSender.TraceExitStaticMethod(5,6164,6314);

int
f_5_6242_6268(int
seed)
{
var return_v = Vertex.random( seed);
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 6242, 6268);
return return_v;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(5,6164,6314);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(5,6164,6314);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

static Vertex()
{
DynAbs.Tracing.TraceSender.TraceEnterStaticConstructor(5,120,6317);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,447,451);
DynAbs.Tracing.TraceSender.TraceExitStaticConstructor(5,120,6317);

DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(5,120,6317);
}

		int ___ignore_me___=DynAbs.Tracing.TraceSender.TraceBeforeConstructor(5,120,6317);

static double
f_5_529_530_C(double
i)
{
var return_v = i;
DynAbs.Tracing.TraceSender.TraceBaseCall(5, 485, 575);
return return_v;
}

}
