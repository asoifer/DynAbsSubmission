public class Vec2
{
internal double x;

internal double y;

internal double norm;

public Vec2()
		{
			try
{DynAbs.Tracing.TraceSender.TraceEnterConstructor(4,379,400);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(4,327,328);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(4,348,349);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(4,369,373);
DynAbs.Tracing.TraceSender.TraceExitConstructor(4,379,400);
}catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(4,379,400);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(4,379,400);
}
		}

public Vec2(double xx, double yy)
		{
			try
{DynAbs.Tracing.TraceSender.TraceEnterConstructor(4,405,493);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(4,327,328);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(4,348,349);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(4,369,373);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(4,446,453);

x = xx;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(4,457,464);

y = yy;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(4,468,489);

norm = x * x + y * y;
DynAbs.Tracing.TraceSender.TraceExitConstructor(4,405,493);
}catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(4,405,493);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(4,405,493);
}
		}

public virtual double X()
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(4,498,544);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(4,531,540);

return x;
DynAbs.Tracing.TraceSender.TraceExitMethod(4,498,544);
	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(4,498,544);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(4,498,544);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

public virtual double Y()
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(4,549,595);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(4,582,591);

return y;
DynAbs.Tracing.TraceSender.TraceExitMethod(4,549,595);
	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(4,549,595);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(4,549,595);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

public virtual double Norm()
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(4,600,652);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(4,636,648);

return norm;
DynAbs.Tracing.TraceSender.TraceExitMethod(4,600,652);
	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(4,600,652);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(4,600,652);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

public virtual void setNorm(double d)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(4,657,715);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(4,702,711);

norm = d;
DynAbs.Tracing.TraceSender.TraceExitMethod(4,657,715);
	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(4,657,715);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(4,657,715);
}
		}

public override string ToString()
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(4,720,784);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(4,761,780);

return DynAbs.Tracing.TraceSender.TraceInvocationWrapper(() => (x).ToString(),4,768,769)+ " " + DynAbs.Tracing.TraceSender.TraceInvocationWrapper(() => (y).ToString(),4,778,779);
DynAbs.Tracing.TraceSender.TraceExitMethod(4,720,784);
	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(4,720,784);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(4,720,784);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

internal virtual Vec2 circle_center(Vec2 b, Vec2 c)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(4,789,1318);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(4,848,868);

Vec2 
vv1 = f_4_859_867(b, c)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(4,872,895);

double 
d1 = f_4_884_894(vv1)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(4,899,912);

vv1 = f_4_905_911(this, b);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(4,916,942);

Vec2 
vv2 = f_4_927_941(vv1, 0.5)
;

if ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(4,946,1314) || true) && (d1 < 0.0)
) /*there is no intersection point, the bisectors coincide. */

{DynAbs.Tracing.TraceSender.TraceEnterCondition(4,946,1314);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(4,1025,1038);

return (vv2);
DynAbs.Tracing.TraceSender.TraceExitCondition(4,946,1314);
}

else

{DynAbs.Tracing.TraceSender.TraceEnterCondition(4,946,1314);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(4,1056,1079);

Vec2 
vv3 = f_4_1067_1078(b, this)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(4,1084,1107);

Vec2 
vv4 = f_4_1095_1106(c, this)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(4,1112,1139);

double 
d3 = f_4_1124_1138(vv3, vv4)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(4,1144,1166);

double 
d2 = -2.0 * d3
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(4,1171,1191);

Vec2 
vv5 = f_4_1182_1190(c, b)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(4,1196,1221);

double 
d4 = f_4_1208_1220(vv5, vv4)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(4,1226,1249);

Vec2 
vv6 = f_4_1237_1248(vv3)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(4,1254,1284);

Vec2 
vv7 = f_4_1265_1283(vv6, d4 / d2)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(4,1289,1309);

return f_4_1296_1308(vv2, vv7);
DynAbs.Tracing.TraceSender.TraceExitCondition(4,946,1314);
}
DynAbs.Tracing.TraceSender.TraceExitMethod(4,789,1318);

Vec2
f_4_859_867(Vec2
this_param,Vec2
v)
{
var return_v = this_param.sub( v);
DynAbs.Tracing.TraceSender.TraceEndInvocation(4, 859, 867);
return return_v;
}


double
f_4_884_894(Vec2
this_param)
{
var return_v = this_param.magn();
DynAbs.Tracing.TraceSender.TraceEndInvocation(4, 884, 894);
return return_v;
}


Vec2
f_4_905_911(Vec2
this_param,Vec2
v)
{
var return_v = this_param.sum( v);
DynAbs.Tracing.TraceSender.TraceEndInvocation(4, 905, 911);
return return_v;
}


Vec2
f_4_927_941(Vec2
this_param,double
c)
{
var return_v = this_param.times( c);
DynAbs.Tracing.TraceSender.TraceEndInvocation(4, 927, 941);
return return_v;
}


Vec2
f_4_1067_1078(Vec2
this_param,Vec2
v)
{
var return_v = this_param.sub( v);
DynAbs.Tracing.TraceSender.TraceEndInvocation(4, 1067, 1078);
return return_v;
}


Vec2
f_4_1095_1106(Vec2
this_param,Vec2
v)
{
var return_v = this_param.sub( v);
DynAbs.Tracing.TraceSender.TraceEndInvocation(4, 1095, 1106);
return return_v;
}


double
f_4_1124_1138(Vec2
this_param,Vec2
v)
{
var return_v = this_param.cprod( v);
DynAbs.Tracing.TraceSender.TraceEndInvocation(4, 1124, 1138);
return return_v;
}


Vec2
f_4_1182_1190(Vec2
this_param,Vec2
v)
{
var return_v = this_param.sub( v);
DynAbs.Tracing.TraceSender.TraceEndInvocation(4, 1182, 1190);
return return_v;
}


double
f_4_1208_1220(Vec2
this_param,Vec2
v)
{
var return_v = this_param.dot( v);
DynAbs.Tracing.TraceSender.TraceEndInvocation(4, 1208, 1220);
return return_v;
}


Vec2
f_4_1237_1248(Vec2
this_param)
{
var return_v = this_param.cross();
DynAbs.Tracing.TraceSender.TraceEndInvocation(4, 1237, 1248);
return return_v;
}


Vec2
f_4_1265_1283(Vec2
this_param,double
c)
{
var return_v = this_param.times( c);
DynAbs.Tracing.TraceSender.TraceEndInvocation(4, 1265, 1283);
return return_v;
}


Vec2
f_4_1296_1308(Vec2
this_param,Vec2
v)
{
var return_v = this_param.sum( v);
DynAbs.Tracing.TraceSender.TraceEndInvocation(4, 1296, 1308);
return return_v;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(4,789,1318);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(4,789,1318);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

internal virtual double cprod(Vec2 v)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(4,1466,1542);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(4,1511,1538);

return (x * v.y - y * v.x);
DynAbs.Tracing.TraceSender.TraceExitMethod(4,1466,1542);
	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(4,1466,1542);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(4,1466,1542);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

internal virtual double dot(Vec2 v)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(4,1585,1659);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(4,1628,1655);

return (x * v.x + y * v.y);
DynAbs.Tracing.TraceSender.TraceExitMethod(4,1585,1659);
	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(4,1585,1659);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(4,1585,1659);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

internal virtual Vec2 times(double c)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(4,1715,1796);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(4,1760,1792);

return (f_4_1768_1790(c * x, c * y));
DynAbs.Tracing.TraceSender.TraceExitMethod(4,1715,1796);

Vec2
f_4_1768_1790(double
xx,double
yy)
{
var return_v = new Vec2( xx, yy);
DynAbs.Tracing.TraceSender.TraceEndInvocation(4, 1768, 1790);
return return_v;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(4,1715,1796);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(4,1715,1796);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

internal virtual Vec2 sum(Vec2 v)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(4,1860,1941);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(4,1901,1937);

return (f_4_1909_1935(x + v.x, y + v.y));
DynAbs.Tracing.TraceSender.TraceExitMethod(4,1860,1941);

Vec2
f_4_1909_1935(double
xx,double
yy)
{
var return_v = new Vec2( xx, yy);
DynAbs.Tracing.TraceSender.TraceEndInvocation(4, 1909, 1935);
return return_v;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(4,1860,1941);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(4,1860,1941);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

internal virtual Vec2 sub(Vec2 v)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(4,1946,2027);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(4,1987,2023);

return (f_4_1995_2021(x - v.x, y - v.y));
DynAbs.Tracing.TraceSender.TraceExitMethod(4,1946,2027);

Vec2
f_4_1995_2021(double
xx,double
yy)
{
var return_v = new Vec2( xx, yy);
DynAbs.Tracing.TraceSender.TraceEndInvocation(4, 1995, 2021);
return return_v;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(4,1946,2027);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(4,1946,2027);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

internal virtual double magn()
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(4,2072,2155);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(4,2110,2151);

return (f_4_2118_2149(x * x + y * y));
DynAbs.Tracing.TraceSender.TraceExitMethod(4,2072,2155);

double
f_4_2118_2149(double
d)
{
var return_v = System.Math.Sqrt( d);
DynAbs.Tracing.TraceSender.TraceEndInvocation(4, 2118, 2149);
return return_v;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(4,2072,2155);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(4,2072,2155);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

internal virtual Vec2 cross()
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(4,2239,2305);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(4,2276,2301);

return (f_4_2284_2299(y, -x));
DynAbs.Tracing.TraceSender.TraceExitMethod(4,2239,2305);

Vec2
f_4_2284_2299(double
xx,double
yy)
{
var return_v = new Vec2( xx, yy);
DynAbs.Tracing.TraceSender.TraceEndInvocation(4, 2284, 2299);
return return_v;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(4,2239,2305);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(4,2239,2305);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

static Vec2()
{
DynAbs.Tracing.TraceSender.TraceEnterStaticConstructor(4,288,2308);
DynAbs.Tracing.TraceSender.TraceExitStaticConstructor(4,288,2308);

DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(4,288,2308);
}

		int ___ignore_me___=DynAbs.Tracing.TraceSender.TraceBeforeConstructor(4,288,2308);
}
