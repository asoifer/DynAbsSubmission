using System;
public class MathVector
{
public static readonly int NDIM ;

public double[] data;

public MathVector()
		{
			try
{DynAbs.Tracing.TraceSender.TraceEnterConstructor(6,554,661);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,456,460);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,581,605);

data = new double[NDIM];
try {DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,617,622);
		for(int 
i = 0
; (DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,609,657) || true) && (i < NDIM)
; DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,634,637)
,i++,DynAbs.Tracing.TraceSender.TraceExitCondition(6,609,657))

{DynAbs.Tracing.TraceSender.TraceEnterCondition(6,609,657);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,643,657);

data[i] = 0.0;
}
}catch(System.Exception) { DynAbs.Tracing.TraceSender.TraceExitLoopByException(6,1,49);
 throw; }finally{DynAbs.Tracing.TraceSender.TraceExitLoop(6,1,49);
}DynAbs.Tracing.TraceSender.TraceExitConstructor(6,554,661);
}catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(6,554,661);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(6,554,661);
}
		}

public MathVector cloneMathVector()
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(6,750,1067);
        try
        {
DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,827,859);

MathVector 
v = f_6_842_858()
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,867,893);

v.data = new double[NDIM];
try {DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,909,914);
		    for(int 
i = 0
; (DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,901,959) || true) && (i < NDIM)
; DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,926,929)
,i++,DynAbs.Tracing.TraceSender.TraceExitCondition(6,901,959))

{DynAbs.Tracing.TraceSender.TraceEnterCondition(6,901,959);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,939,959);

v.data[i] = data[i];
}
}catch(System.Exception) { DynAbs.Tracing.TraceSender.TraceExitLoopByException(6,1,59);
 throw; }finally{DynAbs.Tracing.TraceSender.TraceExitLoop(6,1,59);
}DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,973,982);

return v;
        }
        catch(Exception e)
        {
DynAbs.Tracing.TraceSender.TraceEnterCatch(6,1003,1063);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,1046,1052);

throw;
DynAbs.Tracing.TraceSender.TraceExitCatch(6,1003,1063);
        }
DynAbs.Tracing.TraceSender.TraceExitMethod(6,750,1067);

MathVector
f_6_842_858()
{
var return_v = new MathVector();
DynAbs.Tracing.TraceSender.TraceEndInvocation(6, 842, 858);
return return_v;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(6,750,1067);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(6,750,1067);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

public double value(int i)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(6,1224,1277);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,1258,1273);

return data[i];
DynAbs.Tracing.TraceSender.TraceExitMethod(6,1224,1277);
	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(6,1224,1277);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(6,1224,1277);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

public void setValue(int i, double v)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(6,1408,1469);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,1453,1465);

data[i] = v;
DynAbs.Tracing.TraceSender.TraceExitMethod(6,1408,1469);
	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(6,1408,1469);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(6,1408,1469);
}
		}

public void unit(int j)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(6,1571,1699);
try {DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,1610,1615);
		for(int 
i = 0
; (DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,1602,1695) || true) && (i < NDIM)
; DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,1627,1630)
,i++,DynAbs.Tracing.TraceSender.TraceExitCondition(6,1602,1695))

{DynAbs.Tracing.TraceSender.TraceEnterCondition(6,1602,1695);

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,1636,1695) || true) && (i == j)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(6,1636,1695);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,1652,1666);

data[i] = 1.0;
DynAbs.Tracing.TraceSender.TraceExitCondition(6,1636,1695);
}

else

{DynAbs.Tracing.TraceSender.TraceEnterCondition(6,1636,1695);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,1681,1695);

data[i] = 0.0;
DynAbs.Tracing.TraceSender.TraceExitCondition(6,1636,1695);
}
}
}catch(System.Exception) { DynAbs.Tracing.TraceSender.TraceExitLoopByException(6,1,94);
 throw; }finally{DynAbs.Tracing.TraceSender.TraceExitLoop(6,1,94);
}DynAbs.Tracing.TraceSender.TraceExitMethod(6,1571,1699);
	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(6,1571,1699);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(6,1571,1699);
}
		}

public void addition(MathVector u)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(6,1824,1934);
try {DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,1874,1879);
		for(int 
i = 0
; (DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,1866,1930) || true) && (i < NDIM)
; DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,1891,1894)
,i++,DynAbs.Tracing.TraceSender.TraceExitCondition(6,1866,1930))

{DynAbs.Tracing.TraceSender.TraceEnterCondition(6,1866,1930);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,1900,1930);

data[i] = data[i] + u.data[i];
}
}catch(System.Exception) { DynAbs.Tracing.TraceSender.TraceExitLoopByException(6,1,65);
 throw; }finally{DynAbs.Tracing.TraceSender.TraceExitLoop(6,1,65);
}DynAbs.Tracing.TraceSender.TraceExitMethod(6,1824,1934);
	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(6,1824,1934);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(6,1824,1934);
}
		}

public void subtraction1(MathVector u)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(6,2112,2226);
try {DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,2166,2171);
		for(int 
i = 0
; (DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,2158,2222) || true) && (i < NDIM)
; DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,2183,2186)
,i++,DynAbs.Tracing.TraceSender.TraceExitCondition(6,2158,2222))

{DynAbs.Tracing.TraceSender.TraceEnterCondition(6,2158,2222);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,2192,2222);

data[i] = data[i] - u.data[i];
}
}catch(System.Exception) { DynAbs.Tracing.TraceSender.TraceExitLoopByException(6,1,65);
 throw; }finally{DynAbs.Tracing.TraceSender.TraceExitLoop(6,1,65);
}DynAbs.Tracing.TraceSender.TraceExitMethod(6,2112,2226);
	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(6,2112,2226);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(6,2112,2226);
}
		}

public void subtraction2(MathVector u, MathVector v)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(6,2411,2541);
try {DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,2479,2484);
		for(int 
i = 0
; (DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,2471,2537) || true) && (i < NDIM)
; DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,2496,2499)
,i++,DynAbs.Tracing.TraceSender.TraceExitCondition(6,2471,2537))

{DynAbs.Tracing.TraceSender.TraceEnterCondition(6,2471,2537);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,2505,2537);

data[i] = u.data[i] - v.data[i];
}
}catch(System.Exception) { DynAbs.Tracing.TraceSender.TraceExitLoopByException(6,1,67);
 throw; }finally{DynAbs.Tracing.TraceSender.TraceExitLoop(6,1,67);
}DynAbs.Tracing.TraceSender.TraceExitMethod(6,2411,2541);
	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(6,2411,2541);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(6,2411,2541);
}
		}

public void multScalar1(double s)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(6,2628,2729);
try {DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,2677,2682);
		for(int 
i = 0
; (DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,2669,2725) || true) && (i < NDIM)
; DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,2694,2697)
,i++,DynAbs.Tracing.TraceSender.TraceExitCondition(6,2669,2725))

{DynAbs.Tracing.TraceSender.TraceEnterCondition(6,2669,2725);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,2703,2725);

data[i] = data[i] * s;
}
}catch(System.Exception) { DynAbs.Tracing.TraceSender.TraceExitLoopByException(6,1,57);
 throw; }finally{DynAbs.Tracing.TraceSender.TraceExitLoop(6,1,57);
}DynAbs.Tracing.TraceSender.TraceExitMethod(6,2628,2729);
	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(6,2628,2729);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(6,2628,2729);
}
		}

public void multScalar2(MathVector u, double s)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(6,2877,2994);
try {DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,2940,2945);
		for(int 
i = 0
; (DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,2932,2990) || true) && (i < NDIM)
; DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,2957,2960)
,i++,DynAbs.Tracing.TraceSender.TraceExitCondition(6,2932,2990))

{DynAbs.Tracing.TraceSender.TraceEnterCondition(6,2932,2990);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,2966,2990);

data[i] = u.data[i] * s;
}
}catch(System.Exception) { DynAbs.Tracing.TraceSender.TraceExitLoopByException(6,1,59);
 throw; }finally{DynAbs.Tracing.TraceSender.TraceExitLoop(6,1,59);
}DynAbs.Tracing.TraceSender.TraceExitMethod(6,2877,2994);
	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(6,2877,2994);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(6,2877,2994);
}
		}

public void divScalar(double s)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(6,3099,3198);
try {DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,3146,3151);
		for(int 
i = 0
; (DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,3138,3194) || true) && (i < NDIM)
; DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,3163,3166)
,i++,DynAbs.Tracing.TraceSender.TraceExitCondition(6,3138,3194))

{DynAbs.Tracing.TraceSender.TraceEnterCondition(6,3138,3194);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,3172,3194);

data[i] = data[i] / s;
}
}catch(System.Exception) { DynAbs.Tracing.TraceSender.TraceExitLoopByException(6,1,57);
 throw; }finally{DynAbs.Tracing.TraceSender.TraceExitLoop(6,1,57);
}DynAbs.Tracing.TraceSender.TraceExitMethod(6,3099,3198);
	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(6,3099,3198);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(6,3099,3198);
}
		}

public double dotProduct()
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(6,3296,3423);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,3330,3345);

double 
s = 0.0
;
try {DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,3357,3362);
		for(int 
i = 0
; (DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,3349,3406) || true) && (i < NDIM)
; DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,3374,3377)
,i++,DynAbs.Tracing.TraceSender.TraceExitCondition(6,3349,3406))

{DynAbs.Tracing.TraceSender.TraceEnterCondition(6,3349,3406);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,3383,3406);

s += data[i] * data[i];
}
}catch(System.Exception) { DynAbs.Tracing.TraceSender.TraceExitLoopByException(6,1,58);
 throw; }finally{DynAbs.Tracing.TraceSender.TraceExitLoop(6,1,58);
}DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,3410,3419);

return s;
DynAbs.Tracing.TraceSender.TraceExitMethod(6,3296,3423);
	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(6,3296,3423);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(6,3296,3423);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

public double absolute()
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(6,3428,3570);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,3460,3477);

double 
tmp = 0.0
;
try {DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,3489,3494);
		for(int 
i = 0
; (DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,3481,3540) || true) && (i < NDIM)
; DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,3506,3509)
,i++,DynAbs.Tracing.TraceSender.TraceExitCondition(6,3481,3540))

{DynAbs.Tracing.TraceSender.TraceEnterCondition(6,3481,3540);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,3515,3540);

tmp += data[i] * data[i];
}
}catch(System.Exception) { DynAbs.Tracing.TraceSender.TraceExitLoopByException(6,1,60);
 throw; }finally{DynAbs.Tracing.TraceSender.TraceExitLoop(6,1,60);
}DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,3544,3566);

return f_6_3551_3565(tmp);
DynAbs.Tracing.TraceSender.TraceExitMethod(6,3428,3570);

double
f_6_3551_3565(double
d)
{
var return_v = Math.Sqrt( d);
DynAbs.Tracing.TraceSender.TraceEndInvocation(6, 3551, 3565);
return return_v;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(6,3428,3570);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(6,3428,3570);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

public double distance(MathVector v)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(6,3575,3759);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,3619,3636);

double 
tmp = 0.0
;
try {DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,3648,3653);
		for(int 
i = 0
; (DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,3640,3729) || true) && (i < NDIM)
; DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,3665,3668)
,i++,DynAbs.Tracing.TraceSender.TraceExitCondition(6,3640,3729))

{DynAbs.Tracing.TraceSender.TraceEnterCondition(6,3640,3729);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,3674,3729);

tmp += ((data[i] - v.data[i]) * (data[i] - v.data[i]));
}
}catch(System.Exception) { DynAbs.Tracing.TraceSender.TraceExitLoopByException(6,1,90);
 throw; }finally{DynAbs.Tracing.TraceSender.TraceExitLoop(6,1,90);
}DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,3733,3755);

return f_6_3740_3754(tmp);
DynAbs.Tracing.TraceSender.TraceExitMethod(6,3575,3759);

double
f_6_3740_3754(double
d)
{
var return_v = Math.Sqrt( d);
DynAbs.Tracing.TraceSender.TraceEndInvocation(6, 3740, 3754);
return return_v;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(6,3575,3759);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(6,3575,3759);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

public void crossProduct(MathVector u, MathVector w)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(6,3764,4004);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,3824,3880);

data[0] = u.data[1] * w.data[2] - u.data[2] * w.data[1];
DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,3884,3940);

data[1] = u.data[2] * w.data[0] - u.data[0] * w.data[2];
DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,3944,4000);

data[2] = u.data[0] * w.data[1] - u.data[1] * w.data[0];
DynAbs.Tracing.TraceSender.TraceExitMethod(6,3764,4004);
	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(6,3764,4004);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(6,3764,4004);
}
		}

public void incrementalAdd(MathVector u)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(6,4009,4125);
try {DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,4065,4070);
		for(int 
i = 0
; (DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,4057,4121) || true) && (i < NDIM)
; DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,4082,4085)
,i++,DynAbs.Tracing.TraceSender.TraceExitCondition(6,4057,4121))

{DynAbs.Tracing.TraceSender.TraceEnterCondition(6,4057,4121);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,4091,4121);

data[i] = data[i] + u.data[i];
}
}catch(System.Exception) { DynAbs.Tracing.TraceSender.TraceExitLoopByException(6,1,65);
 throw; }finally{DynAbs.Tracing.TraceSender.TraceExitLoop(6,1,65);
}DynAbs.Tracing.TraceSender.TraceExitMethod(6,4009,4125);
	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(6,4009,4125);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(6,4009,4125);
}
		}

public void incrementalSub(MathVector u)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(6,4130,4246);
try {DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,4186,4191);
		for(int 
i = 0
; (DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,4178,4242) || true) && (i < NDIM)
; DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,4203,4206)
,i++,DynAbs.Tracing.TraceSender.TraceExitCondition(6,4178,4242))

{DynAbs.Tracing.TraceSender.TraceEnterCondition(6,4178,4242);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,4212,4242);

data[i] = data[i] - u.data[i];
}
}catch(System.Exception) { DynAbs.Tracing.TraceSender.TraceExitLoopByException(6,1,65);
 throw; }finally{DynAbs.Tracing.TraceSender.TraceExitLoop(6,1,65);
}DynAbs.Tracing.TraceSender.TraceExitMethod(6,4130,4246);
	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(6,4130,4246);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(6,4130,4246);
}
		}

public void incrementalMultScalar(double s)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(6,4251,4362);
try {DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,4310,4315);
		for(int 
i = 0
; (DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,4302,4358) || true) && (i < NDIM)
; DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,4327,4330)
,i++,DynAbs.Tracing.TraceSender.TraceExitCondition(6,4302,4358))

{DynAbs.Tracing.TraceSender.TraceEnterCondition(6,4302,4358);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,4336,4358);

data[i] = data[i] * s;
}
}catch(System.Exception) { DynAbs.Tracing.TraceSender.TraceExitLoopByException(6,1,57);
 throw; }finally{DynAbs.Tracing.TraceSender.TraceExitLoop(6,1,57);
}DynAbs.Tracing.TraceSender.TraceExitMethod(6,4251,4362);
	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(6,4251,4362);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(6,4251,4362);
}
		}

public void incrementalDivScalar(double s)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(6,4367,4477);
try {DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,4425,4430);
		for(int 
i = 0
; (DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,4417,4473) || true) && (i < NDIM)
; DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,4442,4445)
,i++,DynAbs.Tracing.TraceSender.TraceExitCondition(6,4417,4473))

{DynAbs.Tracing.TraceSender.TraceEnterCondition(6,4417,4473);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,4451,4473);

data[i] = data[i] / s;
}
}catch(System.Exception) { DynAbs.Tracing.TraceSender.TraceExitLoopByException(6,1,57);
 throw; }finally{DynAbs.Tracing.TraceSender.TraceExitLoop(6,1,57);
}DynAbs.Tracing.TraceSender.TraceExitMethod(6,4367,4477);
	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(6,4367,4477);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(6,4367,4477);
}
		}

public void addScalar(MathVector u, double s)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(6,4649,4764);
try {DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,4710,4715);
		for(int 
i = 0
; (DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,4702,4760) || true) && (i < NDIM)
; DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,4727,4730)
,i++,DynAbs.Tracing.TraceSender.TraceExitCondition(6,4702,4760))

{DynAbs.Tracing.TraceSender.TraceEnterCondition(6,4702,4760);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,4736,4760);

data[i] = u.data[i] + s;
}
}catch(System.Exception) { DynAbs.Tracing.TraceSender.TraceExitLoopByException(6,1,59);
 throw; }finally{DynAbs.Tracing.TraceSender.TraceExitLoop(6,1,59);
}DynAbs.Tracing.TraceSender.TraceExitMethod(6,4649,4764);
	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(6,4649,4764);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(6,4649,4764);
}
		}

public override string ToString()
		{
			try
    {
DynAbs.Tracing.TraceSender.TraceEnterMethod(6,4841,5046);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,4891,4931);

var 
s = f_6_4899_4930()
;
try {DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,4950,4955);
        for (int 
i = 0
; (DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,4941,5009) || true) && (i < NDIM)
; DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,4967,4970)
,i++,DynAbs.Tracing.TraceSender.TraceExitCondition(6,4941,5009))

{DynAbs.Tracing.TraceSender.TraceEnterCondition(6,4941,5009);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,4985,5009);

f_6_4985_5008(            s, DynAbs.Tracing.TraceSender.TraceInvocationWrapper(() => (data[i]).ToString(),6,4994,5001)+ " ");
}
}catch(System.Exception) { DynAbs.Tracing.TraceSender.TraceExitLoopByException(6,1,69);
 throw; }finally{DynAbs.Tracing.TraceSender.TraceExitLoop(6,1,69);
}DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,5019,5039);

return f_6_5026_5038(s);
DynAbs.Tracing.TraceSender.TraceExitMethod(6,4841,5046);

System.Text.StringBuilder
f_6_4899_4930()
{
var return_v = new System.Text.StringBuilder();
DynAbs.Tracing.TraceSender.TraceEndInvocation(6, 4899, 4930);
return return_v;
}


System.Text.StringBuilder
f_6_4985_5008(System.Text.StringBuilder
this_param,string
value)
{
var return_v = this_param.Append( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(6, 4985, 5008);
return return_v;
}


string
f_6_5026_5038(System.Text.StringBuilder
this_param)
{
var return_v = this_param.ToString();
DynAbs.Tracing.TraceSender.TraceEndInvocation(6, 5026, 5038);
return return_v;
}

    }
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(6,4841,5046);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(6,4841,5046);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

static MathVector()
{
DynAbs.Tracing.TraceSender.TraceEnterStaticConstructor(6,257,5049);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,367,375);
NDIM = 3;DynAbs.Tracing.TraceSender.TraceExitStaticConstructor(6,257,5049);

DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(6,257,5049);
}

		int ___ignore_me___=DynAbs.Tracing.TraceSender.TraceBeforeConstructor(6,257,5049);
}
