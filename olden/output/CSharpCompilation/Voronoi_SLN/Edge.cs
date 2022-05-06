using System;
using System.Collections;
public class Edge
{
public Edge[] quadList;

public int listPos;

public Vertex vertex;

public Edge next;

public Edge(Vertex v, Edge[] ql, int pos)
		{
			try
{DynAbs.Tracing.TraceSender.TraceEnterConstructor(1,1029,1129);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,688,696);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,786,793);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,876,882);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,972,976);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1078,1089);

vertex = v;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1093,1107);

quadList = ql;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1111,1125);

listPos = pos;
DynAbs.Tracing.TraceSender.TraceExitConstructor(1,1029,1129);
}catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(1,1029,1129);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(1,1029,1129);
}
		}

public Edge(Edge[] ql, int pos)
:this(f_1_1223_1227_C(null) ,ql,pos)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterConstructor(1,1181,1245);
DynAbs.Tracing.TraceSender.TraceExitConstructor(1,1181,1245);
	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(1,1181,1245);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(1,1181,1245);
}
		}

public override string ToString()
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(1,1315,1436);

if ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1356,1432) || true) && (vertex != null)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,1356,1432);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1380,1405);

return f_1_1387_1404(vertex);
DynAbs.Tracing.TraceSender.TraceExitCondition(1,1356,1432);
}

else

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,1356,1432);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1418,1432);

return "None";
DynAbs.Tracing.TraceSender.TraceExitCondition(1,1356,1432);
}
DynAbs.Tracing.TraceSender.TraceExitMethod(1,1315,1436);

string
f_1_1387_1404(Vertex
this_param)
{
var return_v = this_param.ToString();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 1387, 1404);
return return_v;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(1,1315,1436);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(1,1315,1436);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

public static Edge makeEdge(Vertex o, Vertex d)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterStaticMethod(1,1441,1818);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1496,1520);

Edge[] 
ql = new Edge[4]
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1524,1548);

ql[0] = f_1_1532_1547(ql, 0);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1552,1576);

ql[1] = f_1_1560_1575(ql, 1);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1580,1604);

ql[2] = f_1_1588_1603(ql, 2);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1608,1632);

ql[3] = f_1_1616_1631(ql, 3);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1640,1659);

ql[0].next = ql[0];
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1663,1682);

ql[1].next = ql[3];
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1686,1705);

ql[2].next = ql[2];
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1709,1728);

ql[3].next = ql[1];
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1736,1755);

Edge 
@base = ql[0]
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1759,1776);

f_1_1759_1775(		@base, o);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1780,1797);

f_1_1780_1796(		@base, d);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1801,1814);

return @base;
DynAbs.Tracing.TraceSender.TraceExitStaticMethod(1,1441,1818);

Edge
f_1_1532_1547(Edge[]
ql,int
pos)
{
var return_v = new Edge( ql, pos);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 1532, 1547);
return return_v;
}


Edge
f_1_1560_1575(Edge[]
ql,int
pos)
{
var return_v = new Edge( ql, pos);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 1560, 1575);
return return_v;
}


Edge
f_1_1588_1603(Edge[]
ql,int
pos)
{
var return_v = new Edge( ql, pos);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 1588, 1603);
return return_v;
}


Edge
f_1_1616_1631(Edge[]
ql,int
pos)
{
var return_v = new Edge( ql, pos);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 1616, 1631);
return return_v;
}


int
f_1_1759_1775(Edge
this_param,Vertex
o)
{
this_param.setOrig( o);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 1759, 1775);
return 0;
}


int
f_1_1780_1796(Edge
this_param,Vertex
d)
{
this_param.setDest( d);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 1780, 1796);
return 0;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(1,1441,1818);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(1,1441,1818);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

public virtual void setNext(Edge n)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(1,1823,1879);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1866,1875);

next = n;
DynAbs.Tracing.TraceSender.TraceExitMethod(1,1823,1879);
	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(1,1823,1879);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(1,1823,1879);
}
		}

public virtual void setOrig(Vertex o)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(1,1956,2016);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2001,2012);

vertex = o;
DynAbs.Tracing.TraceSender.TraceExitMethod(1,1956,2016);
	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(1,1956,2016);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(1,1956,2016);
}
		}

public virtual void setDest(Vertex d)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(1,2097,2169);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2142,2165);

f_1_2142_2164(f_1_2142_2153(this), d);
DynAbs.Tracing.TraceSender.TraceExitMethod(1,2097,2169);

Edge
f_1_2142_2153(Edge
this_param)
{
var return_v = this_param.symmetric();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 2142, 2153);
return return_v;
}


int
f_1_2142_2164(Edge
this_param,Vertex
o)
{
this_param.setOrig( o);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 2142, 2164);
return 0;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(1,2097,2169);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(1,2097,2169);
}
		}

internal virtual Edge oNext()
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(1,2174,2227);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2211,2223);

return next;
DynAbs.Tracing.TraceSender.TraceExitMethod(1,2174,2227);
	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(1,2174,2227);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(1,2174,2227);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

internal virtual Edge oPrev()
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(1,2232,2311);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2269,2307);

return f_1_2276_2306(f_1_2276_2297(f_1_2276_2289(this)));
DynAbs.Tracing.TraceSender.TraceExitMethod(1,2232,2311);

Edge
f_1_2276_2289(Edge
this_param)
{
var return_v = this_param.rotate();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 2276, 2289);
return return_v;
}


Edge
f_1_2276_2297(Edge
this_param)
{
var return_v = this_param.oNext();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 2276, 2297);
return return_v;
}


Edge
f_1_2276_2306(Edge
this_param)
{
var return_v = this_param.rotate();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 2276, 2306);
return return_v;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(1,2232,2311);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(1,2232,2311);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

internal virtual Edge lNext()
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(1,2316,2398);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2353,2394);

return f_1_2360_2393(f_1_2360_2384(f_1_2360_2376(this)));
DynAbs.Tracing.TraceSender.TraceExitMethod(1,2316,2398);

Edge
f_1_2360_2376(Edge
this_param)
{
var return_v = this_param.rotateInv();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 2360, 2376);
return return_v;
}


Edge
f_1_2360_2384(Edge
this_param)
{
var return_v = this_param.oNext();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 2360, 2384);
return return_v;
}


Edge
f_1_2360_2393(Edge
this_param)
{
var return_v = this_param.rotate();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 2360, 2393);
return return_v;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(1,2316,2398);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(1,2316,2398);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

internal virtual Edge lPrev()
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(1,2403,2476);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2440,2472);

return f_1_2447_2471(f_1_2447_2459(this));
DynAbs.Tracing.TraceSender.TraceExitMethod(1,2403,2476);

Edge
f_1_2447_2459(Edge
this_param)
{
var return_v = this_param.oNext();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 2447, 2459);
return return_v;
}


Edge
f_1_2447_2471(Edge
this_param)
{
var return_v = this_param.symmetric();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 2447, 2471);
return return_v;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(1,2403,2476);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(1,2403,2476);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

internal virtual Edge rNext()
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(1,2481,2563);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2518,2559);

return f_1_2525_2558(f_1_2525_2546(f_1_2525_2538(this)));
DynAbs.Tracing.TraceSender.TraceExitMethod(1,2481,2563);

Edge
f_1_2525_2538(Edge
this_param)
{
var return_v = this_param.rotate();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 2525, 2538);
return return_v;
}


Edge
f_1_2525_2546(Edge
this_param)
{
var return_v = this_param.oNext();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 2525, 2546);
return return_v;
}


Edge
f_1_2525_2558(Edge
this_param)
{
var return_v = this_param.rotateInv();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 2525, 2558);
return return_v;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(1,2481,2563);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(1,2481,2563);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

internal virtual Edge rPrev()
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(1,2568,2641);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2605,2637);

return f_1_2612_2636(f_1_2612_2628(this));
DynAbs.Tracing.TraceSender.TraceExitMethod(1,2568,2641);

Edge
f_1_2612_2628(Edge
this_param)
{
var return_v = this_param.symmetric();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 2612, 2628);
return return_v;
}


Edge
f_1_2612_2636(Edge
this_param)
{
var return_v = this_param.oNext();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 2612, 2636);
return return_v;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(1,2568,2641);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(1,2568,2641);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

internal virtual Edge dNext()
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(1,2646,2731);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2683,2727);

return f_1_2690_2726(f_1_2690_2714(f_1_2690_2706(this)));
DynAbs.Tracing.TraceSender.TraceExitMethod(1,2646,2731);

Edge
f_1_2690_2706(Edge
this_param)
{
var return_v = this_param.symmetric();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 2690, 2706);
return return_v;
}


Edge
f_1_2690_2714(Edge
this_param)
{
var return_v = this_param.oNext();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 2690, 2714);
return return_v;
}


Edge
f_1_2690_2726(Edge
this_param)
{
var return_v = this_param.symmetric();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 2690, 2726);
return return_v;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(1,2646,2731);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(1,2646,2731);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

internal virtual Edge dPrev()
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(1,2736,2821);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2773,2817);

return f_1_2780_2816(f_1_2780_2804(f_1_2780_2796(this)));
DynAbs.Tracing.TraceSender.TraceExitMethod(1,2736,2821);

Edge
f_1_2780_2796(Edge
this_param)
{
var return_v = this_param.rotateInv();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 2780, 2796);
return return_v;
}


Edge
f_1_2780_2804(Edge
this_param)
{
var return_v = this_param.oNext();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 2780, 2804);
return return_v;
}


Edge
f_1_2780_2816(Edge
this_param)
{
var return_v = this_param.rotateInv();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 2780, 2816);
return return_v;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(1,2736,2821);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(1,2736,2821);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

internal virtual Vertex orig()
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(1,2826,2882);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2864,2878);

return vertex;
DynAbs.Tracing.TraceSender.TraceExitMethod(1,2826,2882);
	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(1,2826,2882);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(1,2826,2882);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

internal virtual Vertex dest()
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(1,2887,2955);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2925,2951);

return f_1_2932_2950(f_1_2932_2943(this));
DynAbs.Tracing.TraceSender.TraceExitMethod(1,2887,2955);

Edge
f_1_2932_2943(Edge
this_param)
{
var return_v = this_param.symmetric();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 2932, 2943);
return return_v;
}


Vertex
f_1_2932_2950(Edge
this_param)
{
var return_v = this_param.orig();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 2932, 2950);
return return_v;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(1,2887,2955);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(1,2887,2955);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

internal virtual Edge symmetric()
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(1,3121,3201);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,3162,3197);

return quadList[(listPos + 2) % 4];
DynAbs.Tracing.TraceSender.TraceExitMethod(1,3121,3201);
	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(1,3121,3201);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(1,3121,3201);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

internal virtual Edge rotate()
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(1,3377,3454);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,3415,3450);

return quadList[(listPos + 1) % 4];
DynAbs.Tracing.TraceSender.TraceExitMethod(1,3377,3454);
	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(1,3377,3454);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(1,3377,3454);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

internal virtual Edge rotateInv()
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(1,3618,3698);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,3659,3694);

return quadList[(listPos + 3) % 4];
DynAbs.Tracing.TraceSender.TraceExitMethod(1,3618,3698);
	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(1,3618,3698);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(1,3618,3698);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

internal virtual Edge nextQuadEdge()
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(1,3703,3786);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,3747,3782);

return quadList[(listPos + 1) % 4];
DynAbs.Tracing.TraceSender.TraceExitMethod(1,3703,3786);
	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(1,3703,3786);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(1,3703,3786);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

internal virtual Edge connectLeft(Edge b)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(1,3791,4056);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,3840,3850);

Vertex 
t1
=default(Vertex);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,3854,3864);

Vertex 
t2
=default(Vertex);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,3868,3877);

Edge 
ans
=default(Edge);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,3881,3893);

Edge 
lnexta
=default(Edge);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,3901,3913);

t1 = f_1_3906_3912(this);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,3917,3934);

lnexta = f_1_3926_3933(this);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,3938,3952);

t2 = f_1_3943_3951(b);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,3956,3984);

ans = f_1_3962_3983(t1, t2);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,3988,4007);

f_1_3988_4006(		ans, lnexta);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,4011,4037);

f_1_4011_4036(f_1_4011_4026(		ans), b);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,4041,4052);

return ans;
DynAbs.Tracing.TraceSender.TraceExitMethod(1,3791,4056);

Vertex
f_1_3906_3912(Edge
this_param)
{
var return_v = this_param.dest();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 3906, 3912);
return return_v;
}


Edge
f_1_3926_3933(Edge
this_param)
{
var return_v = this_param.lNext();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 3926, 3933);
return return_v;
}


Vertex
f_1_3943_3951(Edge
this_param)
{
var return_v = this_param.orig();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 3943, 3951);
return return_v;
}


Edge
f_1_3962_3983(Vertex
o,Vertex
d)
{
var return_v = Edge.makeEdge( o, d);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 3962, 3983);
return return_v;
}


int
f_1_3988_4006(Edge
this_param,Edge
b)
{
this_param.splice( b);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 3988, 4006);
return 0;
}


Edge
f_1_4011_4026(Edge
this_param)
{
var return_v = this_param.symmetric();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 4011, 4026);
return return_v;
}


int
f_1_4011_4036(Edge
this_param,Edge
b)
{
this_param.splice( b);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 4011, 4036);
return 0;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(1,3791,4056);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(1,3791,4056);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

internal virtual Edge connectRight(Edge b)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(1,4061,4355);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,4111,4121);

Vertex 
t1
=default(Vertex);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,4125,4135);

Vertex 
t2
=default(Vertex);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,4139,4148);

Edge 
ans
=default(Edge);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,4152,4164);

Edge 
oprevb
=default(Edge);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,4168,4176);

Edge 
q1
=default(Edge);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,4184,4196);

t1 = f_1_4189_4195(this);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,4200,4214);

t2 = f_1_4205_4213(b);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,4218,4237);

oprevb = f_1_4227_4236(b);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,4245,4273);

ans = f_1_4251_4272(t1, t2);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,4277,4301);

f_1_4277_4300(		ans, f_1_4288_4299(this));
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,4305,4336);

f_1_4305_4335(f_1_4305_4320(		ans), oprevb);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,4340,4351);

return ans;
DynAbs.Tracing.TraceSender.TraceExitMethod(1,4061,4355);

Vertex
f_1_4189_4195(Edge
this_param)
{
var return_v = this_param.dest();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 4189, 4195);
return return_v;
}


Vertex
f_1_4205_4213(Edge
this_param)
{
var return_v = this_param.orig();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 4205, 4213);
return return_v;
}


Edge
f_1_4227_4236(Edge
this_param)
{
var return_v = this_param.oPrev();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 4227, 4236);
return return_v;
}


Edge
f_1_4251_4272(Vertex
o,Vertex
d)
{
var return_v = Edge.makeEdge( o, d);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 4251, 4272);
return return_v;
}


Edge
f_1_4288_4299(Edge
this_param)
{
var return_v = this_param.symmetric();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 4288, 4299);
return return_v;
}


int
f_1_4277_4300(Edge
this_param,Edge
b)
{
this_param.splice( b);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 4277, 4300);
return 0;
}


Edge
f_1_4305_4320(Edge
this_param)
{
var return_v = this_param.symmetric();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 4305, 4320);
return return_v;
}


int
f_1_4305_4335(Edge
this_param,Edge
b)
{
this_param.splice( b);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 4305, 4335);
return 0;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(1,4061,4355);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(1,4061,4355);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

internal virtual void swapedge()
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(1,4542,4874);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,4582,4599);

Edge 
a = f_1_4591_4598(this)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,4603,4627);

Edge 
syme = f_1_4615_4626(this)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,4631,4653);

Edge 
b = f_1_4640_4652(syme)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,4657,4667);

f_1_4657_4666(this, a);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,4671,4686);

f_1_4671_4685(		syme, b);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,4690,4716);

Edge 
lnexttmp = f_1_4706_4715(a)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,4720,4737);

f_1_4720_4736(this, lnexttmp);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,4741,4762);

lnexttmp = f_1_4752_4761(b);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,4766,4788);

f_1_4766_4787(		syme, lnexttmp);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,4792,4813);

Vertex 
a1 = f_1_4804_4812(a)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,4817,4838);

Vertex 
b1 = f_1_4829_4837(b)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,4842,4854);

f_1_4842_4853(this, a1);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,4858,4870);

f_1_4858_4869(this, b1);
DynAbs.Tracing.TraceSender.TraceExitMethod(1,4542,4874);

Edge
f_1_4591_4598(Edge
this_param)
{
var return_v = this_param.oPrev();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 4591, 4598);
return return_v;
}


Edge
f_1_4615_4626(Edge
this_param)
{
var return_v = this_param.symmetric();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 4615, 4626);
return return_v;
}


Edge
f_1_4640_4652(Edge
this_param)
{
var return_v = this_param.oPrev();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 4640, 4652);
return return_v;
}


int
f_1_4657_4666(Edge
this_param,Edge
b)
{
this_param.splice( b);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 4657, 4666);
return 0;
}


int
f_1_4671_4685(Edge
this_param,Edge
b)
{
this_param.splice( b);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 4671, 4685);
return 0;
}


Edge
f_1_4706_4715(Edge
this_param)
{
var return_v = this_param.lNext();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 4706, 4715);
return return_v;
}


int
f_1_4720_4736(Edge
this_param,Edge
b)
{
this_param.splice( b);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 4720, 4736);
return 0;
}


Edge
f_1_4752_4761(Edge
this_param)
{
var return_v = this_param.lNext();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 4752, 4761);
return return_v;
}


int
f_1_4766_4787(Edge
this_param,Edge
b)
{
this_param.splice( b);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 4766, 4787);
return 0;
}


Vertex
f_1_4804_4812(Edge
this_param)
{
var return_v = this_param.dest();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 4804, 4812);
return return_v;
}


Vertex
f_1_4829_4837(Edge
this_param)
{
var return_v = this_param.dest();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 4829, 4837);
return return_v;
}


int
f_1_4842_4853(Edge
this_param,Vertex
o)
{
this_param.setOrig( o);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 4842, 4853);
return 0;
}


int
f_1_4858_4869(Edge
this_param,Vertex
d)
{
this_param.setDest( d);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 4858, 4869);
return 0;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(1,4542,4874);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(1,4542,4874);
}
		}

internal virtual void splice(Edge b)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(1,4879,5168);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,4923,4953);

Edge 
alpha = f_1_4936_4952(f_1_4936_4943(this))
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,4957,4988);

Edge 
beta = f_1_4969_4987(f_1_4969_4978(b))
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,4992,5015);

Edge 
t1 = f_1_5002_5014(beta)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,5019,5045);

Edge 
temp = f_1_5031_5044(alpha)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,5049,5067);

f_1_5049_5066(		alpha, t1);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,5071,5090);

f_1_5071_5089(		beta, temp);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,5094,5109);

temp = f_1_5101_5108(this);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,5113,5128);

t1 = f_1_5118_5127(b);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,5132,5148);

f_1_5132_5147(		b, temp);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,5152,5164);

f_1_5152_5163(this, t1);
DynAbs.Tracing.TraceSender.TraceExitMethod(1,4879,5168);

Edge
f_1_4936_4943(Edge
this_param)
{
var return_v = this_param.oNext();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 4936, 4943);
return return_v;
}


Edge
f_1_4936_4952(Edge
this_param)
{
var return_v = this_param.rotate();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 4936, 4952);
return return_v;
}


Edge
f_1_4969_4978(Edge
this_param)
{
var return_v = this_param.oNext();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 4969, 4978);
return return_v;
}


Edge
f_1_4969_4987(Edge
this_param)
{
var return_v = this_param.rotate();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 4969, 4987);
return return_v;
}


Edge
f_1_5002_5014(Edge
this_param)
{
var return_v = this_param.oNext();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 5002, 5014);
return return_v;
}


Edge
f_1_5031_5044(Edge
this_param)
{
var return_v = this_param.oNext();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 5031, 5044);
return return_v;
}


int
f_1_5049_5066(Edge
this_param,Edge
n)
{
this_param.setNext( n);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 5049, 5066);
return 0;
}


int
f_1_5071_5089(Edge
this_param,Edge
n)
{
this_param.setNext( n);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 5071, 5089);
return 0;
}


Edge
f_1_5101_5108(Edge
this_param)
{
var return_v = this_param.oNext();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 5101, 5108);
return return_v;
}


Edge
f_1_5118_5127(Edge
this_param)
{
var return_v = this_param.oNext();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 5118, 5127);
return return_v;
}


int
f_1_5132_5147(Edge
this_param,Edge
n)
{
this_param.setNext( n);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 5132, 5147);
return 0;
}


int
f_1_5152_5163(Edge
this_param,Edge
n)
{
this_param.setNext( n);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 5152, 5163);
return 0;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(1,4879,5168);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(1,4879,5168);
}
		}

internal virtual bool valid(Edge basel)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(1,5173,5327);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,5220,5245);

Vertex 
t1 = f_1_5232_5244(basel)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,5249,5274);

Vertex 
t3 = f_1_5261_5273(basel)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,5278,5297);

Vertex 
t2 = f_1_5290_5296(this)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,5301,5323);

return f_1_5308_5322(t1, t2, t3);
DynAbs.Tracing.TraceSender.TraceExitMethod(1,5173,5327);

Vertex
f_1_5232_5244(Edge
this_param)
{
var return_v = this_param.orig();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 5232, 5244);
return return_v;
}


Vertex
f_1_5261_5273(Edge
this_param)
{
var return_v = this_param.dest();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 5261, 5273);
return return_v;
}


Vertex
f_1_5290_5296(Edge
this_param)
{
var return_v = this_param.dest();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 5290, 5296);
return return_v;
}


bool
f_1_5308_5322(Vertex
this_param,Vertex
b,Vertex
c)
{
var return_v = this_param.ccw( b, c);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 5308, 5322);
return return_v;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(1,5173,5327);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(1,5173,5327);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

internal virtual void deleteEdge()
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(1,5332,5463);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,5374,5391);

Edge 
f = f_1_5383_5390(this)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,5395,5405);

f_1_5395_5404(this, f);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,5409,5433);

f = f_1_5413_5432(f_1_5413_5424(this));
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,5437,5459);

f_1_5437_5458(f_1_5437_5448(this), f);
DynAbs.Tracing.TraceSender.TraceExitMethod(1,5332,5463);

Edge
f_1_5383_5390(Edge
this_param)
{
var return_v = this_param.oPrev();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 5383, 5390);
return return_v;
}


int
f_1_5395_5404(Edge
this_param,Edge
b)
{
this_param.splice( b);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 5395, 5404);
return 0;
}


Edge
f_1_5413_5424(Edge
this_param)
{
var return_v = this_param.symmetric();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 5413, 5424);
return return_v;
}


Edge
f_1_5413_5432(Edge
this_param)
{
var return_v = this_param.oPrev();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 5413, 5432);
return return_v;
}


Edge
f_1_5437_5448(Edge
this_param)
{
var return_v = this_param.symmetric();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 5437, 5448);
return return_v;
}


int
f_1_5437_5458(Edge
this_param,Edge
b)
{
this_param.splice( b);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 5437, 5458);
return 0;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(1,5332,5463);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(1,5332,5463);
}
		}

internal static EdgePair doMerge(Edge ldo, Edge ldi, Edge rdi, Edge rdo)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterStaticMethod(1,5468,7532);
try {
while ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,5548,5884) || true) && (true)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,5548,5884);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,5570,5593);

Vertex 
t3 = f_1_5582_5592(rdi)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,5598,5621);

Vertex 
t1 = f_1_5610_5620(ldi)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,5626,5649);

Vertex 
t2 = f_1_5638_5648(ldi)
;
try {
while ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,5659,5767) || true) && (f_1_5666_5680(t1, t2, t3))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,5659,5767);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,5693,5711);

ldi = f_1_5699_5710(ldi);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,5723,5739);

t1 = f_1_5728_5738(ldi);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,5745,5761);

t2 = f_1_5750_5760(ldi);
DynAbs.Tracing.TraceSender.TraceExitCondition(1,5659,5767);
}
}catch(System.Exception) { DynAbs.Tracing.TraceSender.TraceExitLoopByException(1,5659,5767);
 throw; }finally{DynAbs.Tracing.TraceSender.TraceExitLoop(1,5659,5767);
}DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,5777,5793);

t2 = f_1_5782_5792(rdi);

if ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,5803,5879) || true) && (f_1_5807_5821(t2, t3, t1))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,5803,5879);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,5834,5852);

rdi = f_1_5840_5851(rdi);
DynAbs.Tracing.TraceSender.TraceExitCondition(1,5803,5879);
}

else

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,5803,5879);
DynAbs.Tracing.TraceSender.TraceBreak(1,5873,5879);

break;
DynAbs.Tracing.TraceSender.TraceExitCondition(1,5803,5879);
}
DynAbs.Tracing.TraceSender.TraceExitCondition(1,5548,5884);
}
}catch(System.Exception) { DynAbs.Tracing.TraceSender.TraceExitLoopByException(1,5548,5884);
 throw; }finally{DynAbs.Tracing.TraceSender.TraceExitLoop(1,5548,5884);
}DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,5892,5938);

Edge 
basel = f_1_5905_5937(f_1_5905_5920(rdi), ldi)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,5946,5973);

Edge 
lcand = f_1_5959_5972(basel)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,5977,6004);

Edge 
rcand = f_1_5990_6003(basel)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,6008,6035);

Vertex 
t1_1 = f_1_6022_6034(basel)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,6039,6066);

Vertex 
t2_1 = f_1_6053_6065(basel)
;

if ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,6074,6114) || true) && (t1_1 == f_1_6086_6096(rdo))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,6074,6114);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,6102,6114);

rdo = basel;
DynAbs.Tracing.TraceSender.TraceExitCondition(1,6074,6114);
}

if ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,6118,6170) || true) && (t2_1 == f_1_6130_6140(ldo))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,6118,6170);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,6146,6170);

ldo = f_1_6152_6169(basel);
DynAbs.Tracing.TraceSender.TraceExitCondition(1,6118,6170);
}
try {
while ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,6178,7528) || true) && (true)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,6178,7528);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,6200,6223);

Edge 
t = f_1_6209_6222(lcand)
;

if ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,6228,6582) || true) && (f_1_6232_6246(t, basel))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,6228,6582);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,6259,6284);

Vertex 
v4 = f_1_6271_6283(basel)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,6296,6321);

Vertex 
v1 = f_1_6308_6320(lcand)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,6327,6352);

Vertex 
v3 = f_1_6339_6351(lcand)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,6358,6379);

Vertex 
v2 = f_1_6370_6378(t)
;
try {
while ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,6385,6576) || true) && (f_1_6392_6415(v1, v2, v3, v4))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,6385,6576);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,6430,6449);

f_1_6430_6448(					lcand);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,6456,6466);

lcand = t;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,6480,6498);

t = f_1_6484_6497(lcand);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,6505,6523);

v1 = f_1_6510_6522(lcand);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,6530,6548);

v3 = f_1_6535_6547(lcand);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,6555,6569);

v2 = f_1_6560_6568(t);
DynAbs.Tracing.TraceSender.TraceExitCondition(1,6385,6576);
}
}catch(System.Exception) { DynAbs.Tracing.TraceSender.TraceExitLoopByException(1,6385,6576);
 throw; }finally{DynAbs.Tracing.TraceSender.TraceExitLoop(1,6385,6576);
}DynAbs.Tracing.TraceSender.TraceExitCondition(1,6228,6582);
}
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,6592,6610);

t = f_1_6596_6609(rcand);

if ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,6615,6956) || true) && (f_1_6619_6633(t, basel))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,6615,6956);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,6646,6671);

Vertex 
v4 = f_1_6658_6670(basel)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,6677,6698);

Vertex 
v1 = f_1_6689_6697(t)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,6704,6729);

Vertex 
v2 = f_1_6716_6728(rcand)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,6735,6760);

Vertex 
v3 = f_1_6747_6759(rcand)
;
try {
while ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,6766,6950) || true) && (f_1_6773_6796(v1, v2, v3, v4))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,6766,6950);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,6811,6830);

f_1_6811_6829(					rcand);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,6837,6847);

rcand = t;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,6854,6872);

t = f_1_6858_6871(rcand);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,6879,6897);

v2 = f_1_6884_6896(rcand);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,6904,6922);

v3 = f_1_6909_6921(rcand);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,6929,6943);

v1 = f_1_6934_6942(t);
DynAbs.Tracing.TraceSender.TraceExitCondition(1,6766,6950);
}
}catch(System.Exception) { DynAbs.Tracing.TraceSender.TraceExitLoopByException(1,6766,6950);
 throw; }finally{DynAbs.Tracing.TraceSender.TraceExitLoop(1,6766,6950);
}DynAbs.Tracing.TraceSender.TraceExitCondition(1,6615,6956);
}
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,6966,6999);

bool 
lvalid = f_1_6980_6998(lcand, basel)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,7009,7042);

bool 
rvalid = f_1_7023_7041(rcand, basel)
;

if ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,7047,7122) || true) && ((!lvalid) &&(DynAbs.Tracing.TraceSender.Expression_True(1, 7051, 7073)&&(!rvalid)))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,7047,7122);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,7086,7116);

return f_1_7093_7115(ldo, rdo);
DynAbs.Tracing.TraceSender.TraceExitCondition(1,7047,7122);
}
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,7132,7159);

Vertex 
v1_1 = f_1_7146_7158(lcand)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,7164,7191);

Vertex 
v2_1 = f_1_7178_7190(lcand)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,7196,7223);

Vertex 
v3_1 = f_1_7210_7222(rcand)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,7228,7255);

Vertex 
v4_1 = f_1_7242_7254(rcand)
;

if ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,7260,7523) || true) && (!lvalid ||(DynAbs.Tracing.TraceSender.Expression_False(1, 7264, 7318)||(rvalid &&(DynAbs.Tracing.TraceSender.Expression_True(1, 7276, 7317)&&f_1_7286_7317(v1_1, v2_1, v3_1, v4_1)))))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,7260,7523);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,7331,7376);

basel = f_1_7339_7375(rcand, f_1_7357_7374(basel));
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,7382,7416);

rcand = f_1_7390_7415(f_1_7390_7407(basel));
DynAbs.Tracing.TraceSender.TraceExitCondition(1,7260,7523);
}

else

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,7260,7523);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,7443,7489);

basel = f_1_7451_7488(f_1_7451_7476(lcand, basel));
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,7495,7517);

lcand = f_1_7503_7516(basel);
DynAbs.Tracing.TraceSender.TraceExitCondition(1,7260,7523);
}
DynAbs.Tracing.TraceSender.TraceExitCondition(1,6178,7528);
}
}catch(System.Exception) { DynAbs.Tracing.TraceSender.TraceExitLoopByException(1,6178,7528);
 throw; }finally{DynAbs.Tracing.TraceSender.TraceExitLoop(1,6178,7528);
}DynAbs.Tracing.TraceSender.TraceExitStaticMethod(1,5468,7532);

Vertex
f_1_5582_5592(Edge
this_param)
{
var return_v = this_param.orig();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 5582, 5592);
return return_v;
}


Vertex
f_1_5610_5620(Edge
this_param)
{
var return_v = this_param.orig();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 5610, 5620);
return return_v;
}


Vertex
f_1_5638_5648(Edge
this_param)
{
var return_v = this_param.dest();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 5638, 5648);
return return_v;
}


bool
f_1_5666_5680(Vertex
this_param,Vertex
b,Vertex
c)
{
var return_v = this_param.ccw( b, c);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 5666, 5680);
return return_v;
}


Edge
f_1_5699_5710(Edge
this_param)
{
var return_v = this_param.lNext();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 5699, 5710);
return return_v;
}


Vertex
f_1_5728_5738(Edge
this_param)
{
var return_v = this_param.orig();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 5728, 5738);
return return_v;
}


Vertex
f_1_5750_5760(Edge
this_param)
{
var return_v = this_param.dest();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 5750, 5760);
return return_v;
}


Vertex
f_1_5782_5792(Edge
this_param)
{
var return_v = this_param.dest();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 5782, 5792);
return return_v;
}


bool
f_1_5807_5821(Vertex
this_param,Vertex
b,Vertex
c)
{
var return_v = this_param.ccw( b, c);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 5807, 5821);
return return_v;
}


Edge
f_1_5840_5851(Edge
this_param)
{
var return_v = this_param.rPrev();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 5840, 5851);
return return_v;
}


Edge
f_1_5905_5920(Edge
this_param)
{
var return_v = this_param.symmetric();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 5905, 5920);
return return_v;
}


Edge
f_1_5905_5937(Edge
this_param,Edge
b)
{
var return_v = this_param.connectLeft( b);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 5905, 5937);
return return_v;
}


Edge
f_1_5959_5972(Edge
this_param)
{
var return_v = this_param.rPrev();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 5959, 5972);
return return_v;
}


Edge
f_1_5990_6003(Edge
this_param)
{
var return_v = this_param.oPrev();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 5990, 6003);
return return_v;
}


Vertex
f_1_6022_6034(Edge
this_param)
{
var return_v = this_param.orig();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 6022, 6034);
return return_v;
}


Vertex
f_1_6053_6065(Edge
this_param)
{
var return_v = this_param.dest();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 6053, 6065);
return return_v;
}


Vertex
f_1_6086_6096(Edge
this_param)
{
var return_v = this_param.orig();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 6086, 6096);
return return_v;
}


Vertex
f_1_6130_6140(Edge
this_param)
{
var return_v = this_param.orig();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 6130, 6140);
return return_v;
}


Edge
f_1_6152_6169(Edge
this_param)
{
var return_v = this_param.symmetric();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 6152, 6169);
return return_v;
}


Edge
f_1_6209_6222(Edge
this_param)
{
var return_v = this_param.oNext();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 6209, 6222);
return return_v;
}


bool
f_1_6232_6246(Edge
this_param,Edge
basel)
{
var return_v = this_param.valid( basel);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 6232, 6246);
return return_v;
}


Vertex
f_1_6271_6283(Edge
this_param)
{
var return_v = this_param.orig();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 6271, 6283);
return return_v;
}


Vertex
f_1_6308_6320(Edge
this_param)
{
var return_v = this_param.dest();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 6308, 6320);
return return_v;
}


Vertex
f_1_6339_6351(Edge
this_param)
{
var return_v = this_param.orig();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 6339, 6351);
return return_v;
}


Vertex
f_1_6370_6378(Edge
this_param)
{
var return_v = this_param.dest();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 6370, 6378);
return return_v;
}


bool
f_1_6392_6415(Vertex
this_param,Vertex
b,Vertex
c,Vertex
d)
{
var return_v = this_param.incircle( b, c, d);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 6392, 6415);
return return_v;
}


int
f_1_6430_6448(Edge
this_param)
{
this_param.deleteEdge();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 6430, 6448);
return 0;
}


Edge
f_1_6484_6497(Edge
this_param)
{
var return_v = this_param.oNext();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 6484, 6497);
return return_v;
}


Vertex
f_1_6510_6522(Edge
this_param)
{
var return_v = this_param.dest();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 6510, 6522);
return return_v;
}


Vertex
f_1_6535_6547(Edge
this_param)
{
var return_v = this_param.orig();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 6535, 6547);
return return_v;
}


Vertex
f_1_6560_6568(Edge
this_param)
{
var return_v = this_param.dest();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 6560, 6568);
return return_v;
}


Edge
f_1_6596_6609(Edge
this_param)
{
var return_v = this_param.oPrev();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 6596, 6609);
return return_v;
}


bool
f_1_6619_6633(Edge
this_param,Edge
basel)
{
var return_v = this_param.valid( basel);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 6619, 6633);
return return_v;
}


Vertex
f_1_6658_6670(Edge
this_param)
{
var return_v = this_param.dest();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 6658, 6670);
return return_v;
}


Vertex
f_1_6689_6697(Edge
this_param)
{
var return_v = this_param.dest();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 6689, 6697);
return return_v;
}


Vertex
f_1_6716_6728(Edge
this_param)
{
var return_v = this_param.dest();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 6716, 6728);
return return_v;
}


Vertex
f_1_6747_6759(Edge
this_param)
{
var return_v = this_param.orig();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 6747, 6759);
return return_v;
}


bool
f_1_6773_6796(Vertex
this_param,Vertex
b,Vertex
c,Vertex
d)
{
var return_v = this_param.incircle( b, c, d);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 6773, 6796);
return return_v;
}


int
f_1_6811_6829(Edge
this_param)
{
this_param.deleteEdge();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 6811, 6829);
return 0;
}


Edge
f_1_6858_6871(Edge
this_param)
{
var return_v = this_param.oPrev();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 6858, 6871);
return return_v;
}


Vertex
f_1_6884_6896(Edge
this_param)
{
var return_v = this_param.dest();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 6884, 6896);
return return_v;
}


Vertex
f_1_6909_6921(Edge
this_param)
{
var return_v = this_param.orig();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 6909, 6921);
return return_v;
}


Vertex
f_1_6934_6942(Edge
this_param)
{
var return_v = this_param.dest();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 6934, 6942);
return return_v;
}


bool
f_1_6980_6998(Edge
this_param,Edge
basel)
{
var return_v = this_param.valid( basel);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 6980, 6998);
return return_v;
}


bool
f_1_7023_7041(Edge
this_param,Edge
basel)
{
var return_v = this_param.valid( basel);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 7023, 7041);
return return_v;
}


EdgePair
f_1_7093_7115(Edge
l,Edge
r)
{
var return_v = new EdgePair( l, r);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 7093, 7115);
return return_v;
}


Vertex
f_1_7146_7158(Edge
this_param)
{
var return_v = this_param.dest();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 7146, 7158);
return return_v;
}


Vertex
f_1_7178_7190(Edge
this_param)
{
var return_v = this_param.orig();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 7178, 7190);
return return_v;
}


Vertex
f_1_7210_7222(Edge
this_param)
{
var return_v = this_param.orig();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 7210, 7222);
return return_v;
}


Vertex
f_1_7242_7254(Edge
this_param)
{
var return_v = this_param.dest();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 7242, 7254);
return return_v;
}


bool
f_1_7286_7317(Vertex
this_param,Vertex
b,Vertex
c,Vertex
d)
{
var return_v = this_param.incircle( b, c, d);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 7286, 7317);
return return_v;
}


Edge
f_1_7357_7374(Edge
this_param)
{
var return_v = this_param.symmetric();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 7357, 7374);
return return_v;
}


Edge
f_1_7339_7375(Edge
this_param,Edge
b)
{
var return_v = this_param.connectLeft( b);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 7339, 7375);
return return_v;
}


Edge
f_1_7390_7407(Edge
this_param)
{
var return_v = this_param.symmetric();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 7390, 7407);
return return_v;
}


Edge
f_1_7390_7415(Edge
this_param)
{
var return_v = this_param.lNext();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 7390, 7415);
return return_v;
}


Edge
f_1_7451_7476(Edge
this_param,Edge
b)
{
var return_v = this_param.connectRight( b);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 7451, 7476);
return return_v;
}


Edge
f_1_7451_7488(Edge
this_param)
{
var return_v = this_param.symmetric();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 7451, 7488);
return return_v;
}


Edge
f_1_7503_7516(Edge
this_param)
{
var return_v = this_param.rPrev();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 7503, 7516);
return return_v;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(1,5468,7532);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(1,5468,7532);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

internal virtual void outputVoronoiDiagram()
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(1,7645,9843);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,7697,7713);

Edge 
nex = this
;
{try {
do

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,7717,8377);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,7795,7823);

Vec2 
v21 = (Vec2)f_1_7812_7822(nex)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,7828,7856);

Vec2 
v22 = (Vec2)f_1_7845_7855(nex)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,7861,7884);

Edge 
tmp = f_1_7872_7883(nex)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,7889,7917);

Vec2 
v23 = (Vec2)f_1_7906_7916(tmp)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,7922,7949);

Vec2 
cvxvec = f_1_7936_7948(v21, v22)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,7954,7996);

Vec2 
center = f_1_7968_7995(v22, v21, v23)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,8006,8030);

Vec2 
vv1 = f_1_8017_8029(v22, v22)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,8035,8061);

Vec2 
vv2 = f_1_8046_8060(vv1, 0.5)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,8066,8093);

Vec2 
vv3 = f_1_8077_8092(center, vv2)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,8098,8127);

double 
ln = 1.0 + f_1_8116_8126(vv3)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,8132,8163);

double 
d1 = ln / f_1_8149_8162(cvxvec)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,8168,8189);

vv1 = f_1_8174_8188(cvxvec);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,8194,8214);

vv2 = f_1_8200_8213(vv1, d1);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,8219,8241);

vv3 = f_1_8225_8240(center, vv2);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,8246,8328);

f_1_8246_8327(f_1_8246_8264(), "Vedge " + f_1_8286_8303(center)+ " " + f_1_8312_8326(vv3));
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,8333,8351);

nex = f_1_8339_8350(nex);
DynAbs.Tracing.TraceSender.TraceExitCondition(1,7717,8377);
}
while ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,7717,8377) || true) && (nex != this)
);
}catch(System.Exception) { DynAbs.Tracing.TraceSender.TraceExitLoopByException(1,7717,8377);
 throw; }finally{DynAbs.Tracing.TraceSender.TraceExitLoop(1,7717,8377);
}}DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,8441,8505);

System.Collections.Stack 
edges = f_1_8474_8504()
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,8509,8580);

System.Collections.Hashtable 
seen = f_1_8545_8579()
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,8584,8606);

f_1_8584_8605(this, edges, seen);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,8610,8672);

f_1_8610_8671(f_1_8610_8628(), "no. of edges = " + DynAbs.Tracing.TraceSender.TraceInvocationWrapper(() => (f_1_8659_8670(edges)).ToString(),1,8659,8670));
try {
while ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,8676,9839) || true) && (!(f_1_8685_8696(edges)== 0))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,8676,9839);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,8713,8743);

Edge 
edge = (Edge)f_1_8731_8742(edges)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,8748,8774);

bool 
b = (bool)f_1_8763_8773(seen, edge)
;

if ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,8779,9790) || true) && (b != null &&(DynAbs.Tracing.TraceSender.Expression_True(1, 8783, 8797)&&b))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,8779,9790);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,8810,8827);

Edge 
prev = edge
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,8833,8852);

nex = f_1_8839_8851(edge);
{try {
do

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,8858,9784);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,8874,8898);

Vertex 
v1 = f_1_8886_8897(prev)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,8905,8924);

double 
d1 = f_1_8917_8923(v1)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,8931,8955);

Vertex 
v2 = f_1_8943_8954(prev)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,8962,8981);

double 
d2 = f_1_8974_8980(v2)
;

if ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,8988,9686) || true) && (d1 >= d2)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,8988,9686);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,9017,9072);

f_1_9017_9071(f_1_9017_9035(), "Dedge " + DynAbs.Tracing.TraceSender.TraceInvocationWrapper(() => (v1).ToString(),1,9057,9059)+ " " + DynAbs.Tracing.TraceSender.TraceInvocationWrapper(() => (v2).ToString(),1,9068,9070));
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,9080,9110);

Edge 
sprev = f_1_9093_9109(prev)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,9118,9144);

Edge 
snex = f_1_9130_9143(sprev)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,9152,9169);

v1 = f_1_9157_9168(prev);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,9177,9194);

v2 = f_1_9182_9193(prev);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,9202,9225);

Vertex 
v3 = f_1_9214_9224(nex)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,9233,9257);

Vertex 
v4 = f_1_9245_9256(snex)
;

if ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,9265,9678) || true) && (f_1_9269_9283(v1, v2, v3)!= f_1_9287_9301(v1, v2, v4))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,9265,9678);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,9320,9343);

Vec2 
v21 = f_1_9331_9342(prev)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,9352,9375);

Vec2 
v22 = f_1_9363_9374(prev)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,9384,9406);

Vec2 
v23 = f_1_9395_9405(nex)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,9415,9454);

Vec2 
vv1 = f_1_9426_9453(v21, v22, v23)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,9463,9482);

v21 = f_1_9469_9481(sprev);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,9491,9510);

v22 = f_1_9497_9509(sprev);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,9519,9537);

v23 = f_1_9525_9536(snex);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,9546,9585);

Vec2 
vv2 = f_1_9557_9584(v21, v22, v23)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,9594,9669);

f_1_9594_9668("Vedge " + f_1_9630_9644(vv1)+ " " + f_1_9653_9667(vv2));
DynAbs.Tracing.TraceSender.TraceExitCondition(1,9265,9678);
}
DynAbs.Tracing.TraceSender.TraceExitCondition(1,8988,9686);
}
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,9693,9712);

seen[prev] = false;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,9719,9730);

prev = nex;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,9737,9755);

nex = f_1_9743_9754(nex);
DynAbs.Tracing.TraceSender.TraceExitCondition(1,8858,9784);
}
while ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,8858,9784) || true) && (prev != edge)
);
}catch(System.Exception) { DynAbs.Tracing.TraceSender.TraceExitLoopByException(1,8858,9784);
 throw; }finally{DynAbs.Tracing.TraceSender.TraceExitLoop(1,8858,9784);
}}DynAbs.Tracing.TraceSender.TraceExitCondition(1,8779,9790);
}
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,9795,9834);

f_1_9795_9833(f_1_9795_9811(			edge), edges, seen);
DynAbs.Tracing.TraceSender.TraceExitCondition(1,8676,9839);
}
}catch(System.Exception) { DynAbs.Tracing.TraceSender.TraceExitLoopByException(1,8676,9839);
 throw; }finally{DynAbs.Tracing.TraceSender.TraceExitLoop(1,8676,9839);
}DynAbs.Tracing.TraceSender.TraceExitMethod(1,7645,9843);

Vertex
f_1_7812_7822(Edge
this_param)
{
var return_v = this_param.dest();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 7812, 7822);
return return_v;
}


Vertex
f_1_7845_7855(Edge
this_param)
{
var return_v = this_param.orig();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 7845, 7855);
return return_v;
}


Edge
f_1_7872_7883(Edge
this_param)
{
var return_v = this_param.oNext();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 7872, 7883);
return return_v;
}


Vertex
f_1_7906_7916(Edge
this_param)
{
var return_v = this_param.dest();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 7906, 7916);
return return_v;
}


Vec2
f_1_7936_7948(Vec2
this_param,Vec2
v)
{
var return_v = this_param.sub( v);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 7936, 7948);
return return_v;
}


Vec2
f_1_7968_7995(Vec2
this_param,Vec2
b,Vec2
c)
{
var return_v = this_param.circle_center( b, c);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 7968, 7995);
return return_v;
}


Vec2
f_1_8017_8029(Vec2
this_param,Vec2
v)
{
var return_v = this_param.sum( v);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 8017, 8029);
return return_v;
}


Vec2
f_1_8046_8060(Vec2
this_param,double
c)
{
var return_v = this_param.times( c);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 8046, 8060);
return return_v;
}


Vec2
f_1_8077_8092(Vec2
this_param,Vec2
v)
{
var return_v = this_param.sub( v);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 8077, 8092);
return return_v;
}


double
f_1_8116_8126(Vec2
this_param)
{
var return_v = this_param.magn();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 8116, 8126);
return return_v;
}


double
f_1_8149_8162(Vec2
this_param)
{
var return_v = this_param.magn();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 8149, 8162);
return return_v;
}


Vec2
f_1_8174_8188(Vec2
this_param)
{
var return_v = this_param.cross();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 8174, 8188);
return return_v;
}


Vec2
f_1_8200_8213(Vec2
this_param,double
c)
{
var return_v = this_param.times( c);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 8200, 8213);
return return_v;
}


Vec2
f_1_8225_8240(Vec2
this_param,Vec2
v)
{
var return_v = this_param.sum( v);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 8225, 8240);
return return_v;
}


System.IO.TextWriter
f_1_8246_8264()
{
var return_v = 			System.Console.Out;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(1, 8246, 8264);
return return_v;
}


string
f_1_8286_8303(Vec2
this_param)
{
var return_v = this_param.ToString();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 8286, 8303);
return return_v;
}


string
f_1_8312_8326(Vec2
this_param)
{
var return_v = this_param.ToString();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 8312, 8326);
return return_v;
}


int
f_1_8246_8327(System.IO.TextWriter
this_param,string
value)
{
this_param.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 8246, 8327);
return 0;
}


Edge
f_1_8339_8350(Edge
this_param)
{
var return_v = this_param.rNext();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 8339, 8350);
return return_v;
}


System.Collections.Stack
f_1_8474_8504()
{
var return_v = new System.Collections.Stack();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 8474, 8504);
return return_v;
}


System.Collections.Hashtable
f_1_8545_8579()
{
var return_v = new System.Collections.Hashtable();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 8545, 8579);
return return_v;
}


int
f_1_8584_8605(Edge
this_param,System.Collections.Stack
stack,System.Collections.Hashtable
seen)
{
this_param.pushRing( stack, seen);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 8584, 8605);
return 0;
}


System.IO.TextWriter
f_1_8610_8628()
{
var return_v = 		System.Console.Out;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(1, 8610, 8628);
return return_v;
}


int
f_1_8659_8670(System.Collections.Stack
this_param)
{
var return_v = this_param.Count;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(1, 8659, 8670);
return return_v;
}


int
f_1_8610_8671(System.IO.TextWriter
this_param,string
value)
{
this_param.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 8610, 8671);
return 0;
}


int
f_1_8685_8696(System.Collections.Stack
this_param)
{
var return_v = this_param.Count ;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(1, 8685, 8696);
return return_v;
}


object
f_1_8731_8742(System.Collections.Stack
this_param)
{
var return_v = this_param.Pop();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 8731, 8742);
return return_v;
}


object
f_1_8763_8773(System.Collections.Hashtable
this_param,object
i0)
{
var return_v = this_param[ i0];
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(1, 8763, 8773);
return return_v;
}


Edge
f_1_8839_8851(Edge
this_param)
{
var return_v = this_param.oNext();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 8839, 8851);
return return_v;
}


Vertex
f_1_8886_8897(Edge
this_param)
{
var return_v = this_param.orig();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 8886, 8897);
return return_v;
}


double
f_1_8917_8923(Vertex
this_param)
{
var return_v = this_param.X();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 8917, 8923);
return return_v;
}


Vertex
f_1_8943_8954(Edge
this_param)
{
var return_v = this_param.dest();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 8943, 8954);
return return_v;
}


double
f_1_8974_8980(Vertex
this_param)
{
var return_v = this_param.X();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 8974, 8980);
return return_v;
}


System.IO.TextWriter
f_1_9017_9035()
{
var return_v = 						System.Console.Out;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(1, 9017, 9035);
return return_v;
}


int
f_1_9017_9071(System.IO.TextWriter
this_param,string
value)
{
this_param.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 9017, 9071);
return 0;
}


Edge
f_1_9093_9109(Edge
this_param)
{
var return_v = this_param.symmetric();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 9093, 9109);
return return_v;
}


Edge
f_1_9130_9143(Edge
this_param)
{
var return_v = this_param.oNext();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 9130, 9143);
return return_v;
}


Vertex
f_1_9157_9168(Edge
this_param)
{
var return_v = this_param.orig();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 9157, 9168);
return return_v;
}


Vertex
f_1_9182_9193(Edge
this_param)
{
var return_v = this_param.dest();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 9182, 9193);
return return_v;
}


Vertex
f_1_9214_9224(Edge
this_param)
{
var return_v = this_param.dest();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 9214, 9224);
return return_v;
}


Vertex
f_1_9245_9256(Edge
this_param)
{
var return_v = this_param.dest();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 9245, 9256);
return return_v;
}


bool
f_1_9269_9283(Vertex
this_param,Vertex
b,Vertex
c)
{
var return_v = this_param.ccw( b, c);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 9269, 9283);
return return_v;
}


bool
f_1_9287_9301(Vertex
this_param,Vertex
b,Vertex
c)
{
var return_v = this_param.ccw( b, c);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 9287, 9301);
return return_v;
}


Vertex
f_1_9331_9342(Edge
this_param)
{
var return_v = this_param.orig();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 9331, 9342);
return return_v;
}


Vertex
f_1_9363_9374(Edge
this_param)
{
var return_v = this_param.dest();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 9363, 9374);
return return_v;
}


Vertex
f_1_9395_9405(Edge
this_param)
{
var return_v = this_param.dest();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 9395, 9405);
return return_v;
}


Vec2
f_1_9426_9453(Vec2
this_param,Vec2
b,Vec2
c)
{
var return_v = this_param.circle_center( b, c);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 9426, 9453);
return return_v;
}


Vertex
f_1_9469_9481(Edge
this_param)
{
var return_v = this_param.orig();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 9469, 9481);
return return_v;
}


Vertex
f_1_9497_9509(Edge
this_param)
{
var return_v = this_param.dest();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 9497, 9509);
return return_v;
}


Vertex
f_1_9525_9536(Edge
this_param)
{
var return_v = this_param.dest();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 9525, 9536);
return return_v;
}


Vec2
f_1_9557_9584(Vec2
this_param,Vec2
b,Vec2
c)
{
var return_v = this_param.circle_center( b, c);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 9557, 9584);
return return_v;
}


string
f_1_9630_9644(Vec2
this_param)
{
var return_v = this_param.ToString();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 9630, 9644);
return return_v;
}


string
f_1_9653_9667(Vec2
this_param)
{
var return_v = this_param.ToString();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 9653, 9667);
return return_v;
}


int
f_1_9594_9668(string
value)
{
System.Console.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 9594, 9668);
return 0;
}


Edge
f_1_9743_9754(Edge
this_param)
{
var return_v = this_param.oNext();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 9743, 9754);
return return_v;
}


Edge
f_1_9795_9811(Edge
this_param)
{
var return_v = this_param.symmetric();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 9795, 9811);
return return_v;
}


int
f_1_9795_9833(Edge
this_param,System.Collections.Stack
stack,System.Collections.Hashtable
seen)
{
this_param.pushRing( stack, seen);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 9795, 9833);
return 0;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(1,7645,9843);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(1,7645,9843);
}
		}

internal virtual void pushRing(Stack stack, Hashtable seen)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(1,9848,10080);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,9915,9934);

Edge 
nex = f_1_9926_9933(this)
;
try {
while ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,9938,10076) || true) && (nex != this)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,9938,10076);

if ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,9967,10048) || true) && (!f_1_9972_9990(seen, nex))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,9967,10048);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,10003,10020);

seen[nex] = true;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,10026,10042);

f_1_10026_10041(				stack, nex);
DynAbs.Tracing.TraceSender.TraceExitCondition(1,9967,10048);
}
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,10053,10071);

nex = f_1_10059_10070(nex);
DynAbs.Tracing.TraceSender.TraceExitCondition(1,9938,10076);
}
}catch(System.Exception) { DynAbs.Tracing.TraceSender.TraceExitLoopByException(1,9938,10076);
 throw; }finally{DynAbs.Tracing.TraceSender.TraceExitLoop(1,9938,10076);
}DynAbs.Tracing.TraceSender.TraceExitMethod(1,9848,10080);

Edge
f_1_9926_9933(Edge
this_param)
{
var return_v = this_param.oNext();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 9926, 9933);
return return_v;
}


bool
f_1_9972_9990(System.Collections.Hashtable
this_param,Edge
key)
{
var return_v = this_param.Contains( (object)key);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 9972, 9990);
return return_v;
}


int
f_1_10026_10041(System.Collections.Stack
this_param,Edge
obj)
{
this_param.Push( (object)obj);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 10026, 10041);
return 0;
}


Edge
f_1_10059_10070(Edge
this_param)
{
var return_v = this_param.oNext();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 10059, 10070);
return return_v;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(1,9848,10080);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(1,9848,10080);
}
		}

internal virtual void pushNonezeroRing(Stack stack, Hashtable seen)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(1,10085,10324);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,10160,10179);

Edge 
nex = f_1_10171_10178(this)
;
try {
while ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,10183,10320) || true) && (nex != this)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,10183,10320);

if ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,10212,10292) || true) && (f_1_10216_10234(seen, nex))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,10212,10292);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,10247,10264);

f_1_10247_10263(				seen, nex);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,10270,10286);

f_1_10270_10285(				stack, nex);
DynAbs.Tracing.TraceSender.TraceExitCondition(1,10212,10292);
}
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,10297,10315);

nex = f_1_10303_10314(nex);
DynAbs.Tracing.TraceSender.TraceExitCondition(1,10183,10320);
}
}catch(System.Exception) { DynAbs.Tracing.TraceSender.TraceExitLoopByException(1,10183,10320);
 throw; }finally{DynAbs.Tracing.TraceSender.TraceExitLoop(1,10183,10320);
}DynAbs.Tracing.TraceSender.TraceExitMethod(1,10085,10324);

Edge
f_1_10171_10178(Edge
this_param)
{
var return_v = this_param.oNext();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 10171, 10178);
return return_v;
}


bool
f_1_10216_10234(System.Collections.Hashtable
this_param,Edge
key)
{
var return_v = this_param.Contains( (object)key);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 10216, 10234);
return return_v;
}


int
f_1_10247_10263(System.Collections.Hashtable
this_param,Edge
key)
{
this_param.Remove( (object)key);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 10247, 10263);
return 0;
}


int
f_1_10270_10285(System.Collections.Stack
this_param,Edge
obj)
{
this_param.Push( (object)obj);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 10270, 10285);
return 0;
}


Edge
f_1_10303_10314(Edge
this_param)
{
var return_v = this_param.oNext();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 10303, 10314);
return return_v;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(1,10085,10324);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(1,10085,10324);
}
		}

static Edge()
{
DynAbs.Tracing.TraceSender.TraceEnterStaticConstructor(1,588,10327);
DynAbs.Tracing.TraceSender.TraceExitStaticConstructor(1,588,10327);

DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(1,588,10327);
}

		int ___ignore_me___=DynAbs.Tracing.TraceSender.TraceBeforeConstructor(1,588,10327);

static Vertex
f_1_1223_1227_C(Vertex
i)
{
var return_v = i;
DynAbs.Tracing.TraceSender.TraceBaseCall(1, 1181, 1245);
return return_v;
}

}
