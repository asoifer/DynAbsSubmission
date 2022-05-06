using System;
public class Demand
{
public double P;

public double Q;

private static double F_EPSILON ;

private static double G_EPSILON ;

private static double H_EPSILON ;

public Demand(double toP, double toQ)
		{
			try
{DynAbs.Tracing.TraceSender.TraceEnterConstructor(2,528,597);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,138,139);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,195,196);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,573,581);

P = toP;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,585,593);

Q = toQ;
DynAbs.Tracing.TraceSender.TraceExitConstructor(2,528,597);
}catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(2,528,597);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(2,528,597);
}
		}

public Demand()
		{
			try
{DynAbs.Tracing.TraceSender.TraceEnterConstructor(2,654,701);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,138,139);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,195,196);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,677,685);

P = 0.0;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,689,697);

Q = 0.0;
DynAbs.Tracing.TraceSender.TraceExitConstructor(2,654,701);
}catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(2,654,701);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(2,654,701);
}
		}

public void increment(Demand frm)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(2,793,864);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,834,845);

P += frm.P;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,849,860);

Q += frm.Q;
DynAbs.Tracing.TraceSender.TraceExitMethod(2,793,864);
	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(2,793,864);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(2,793,864);
}
		}

public void reset()
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(2,915,966);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,942,950);

P = 0.0;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,954,962);

Q = 0.0;
DynAbs.Tracing.TraceSender.TraceExitMethod(2,915,966);
	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(2,915,966);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(2,915,966);
}
		}

public void add(Demand a1, Demand a2)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(2,1121,1206);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1166,1182);

P = a1.P + a2.P;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1186,1202);

Q = a1.Q + a2.Q;
DynAbs.Tracing.TraceSender.TraceExitMethod(2,1121,1206);
	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(2,1121,1206);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(2,1121,1206);
}
		}

public void assign(Demand frm)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(2,1334,1400);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1372,1382);

P = frm.P;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1386,1396);

Q = frm.Q;
DynAbs.Tracing.TraceSender.TraceExitMethod(2,1334,1400);
	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(2,1334,1400);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(2,1334,1400);
}
		}

public void optimizeNode(double pi_R, double pi_I)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(2,1702,3396);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1760,1792);

double[] 
grad_f = new double[2]
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1796,1828);

double[] 
grad_g = new double[2]
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1832,1864);

double[] 
grad_h = new double[2]
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1868,1903);

double[] 
dd_grad_f = new double[2]
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1909,1922);

double 
g = 0
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1926,1939);

double 
h = 0
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1943,1960);

double 
total = 0
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1964,1985);

double 
magnitude = 0
;
{try {
do

{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,1991,3392);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2029,2041);

h = f_2_2033_2040(this);

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2046,2211) || true) && (f_2_2049_2060(h)> H_EPSILON)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,2046,2211);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2085,2119);

magnitude = f_2_2097_2118(this, grad_h);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2125,2147);

total = h / magnitude;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2153,2176);

P -= total * grad_h[0];
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2182,2205);

Q -= total * grad_h[1];
DynAbs.Tracing.TraceSender.TraceExitCondition(2,2046,2211);
}
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2253,2265);

g = f_2_2257_2264(this);

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2270,2503) || true) && (g > G_EPSILON)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,2270,2503);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2299,2333);

magnitude = f_2_2311_2332(this, grad_g);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2339,2361);

f_2_2339_2360(this, grad_h);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2367,2411);

magnitude *= f_2_2380_2410(this, grad_g, grad_h);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2417,2439);

total = g / magnitude;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2445,2468);

P -= total * grad_g[0];
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2474,2497);

Q -= total * grad_g[1];
DynAbs.Tracing.TraceSender.TraceExitCondition(2,2270,2503);
}
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2534,2580);

magnitude = f_2_2546_2579(this, pi_R, pi_I, grad_f);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2585,2620);

f_2_2585_2619(this, pi_R, pi_I, dd_grad_f);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2625,2637);

total = 0.0;
try {DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2650,2655);
			for(int 
i = 0
; (DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2642,2708) || true) && (i < 2)
; DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2664,2667)
,i++,DynAbs.Tracing.TraceSender.TraceExitCondition(2,2642,2708))

{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,2642,2708);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2674,2708);

total += grad_f[i] * dd_grad_f[i];
}
}catch(System.Exception) { DynAbs.Tracing.TraceSender.TraceExitLoopByException(2,1,67);
 throw; }finally{DynAbs.Tracing.TraceSender.TraceExitLoop(2,1,67);
}DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2713,2753);

magnitude = magnitude / f_2_2737_2752(total);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2758,2780);

f_2_2758_2779(this, grad_h);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2785,2829);

magnitude *= f_2_2798_2828(this, grad_f, grad_h);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2834,2856);

f_2_2834_2855(this, grad_g);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2861,2873);

total = 0.0;
try {DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2886,2891);
			for(int 
i = 0
; (DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2878,2941) || true) && (i < 2)
; DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2900,2903)
,i++,DynAbs.Tracing.TraceSender.TraceExitCondition(2,2878,2941))

{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,2878,2941);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2910,2941);

total += grad_f[i] * grad_g[i];
}
}catch(System.Exception) { DynAbs.Tracing.TraceSender.TraceExitLoopByException(2,1,64);
 throw; }finally{DynAbs.Tracing.TraceSender.TraceExitLoop(2,1,64);
}
if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2946,3072) || true) && (total > 0.0)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,2946,3072);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2973,3008);

double 
max_dist = -f_2_2992_2999(this)/ total
;

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,3014,3066) || true) && (magnitude > max_dist)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,3014,3066);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,3045,3066);

magnitude = max_dist;
DynAbs.Tracing.TraceSender.TraceExitCondition(2,3014,3066);
}
DynAbs.Tracing.TraceSender.TraceExitCondition(2,2946,3072);
}
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,3077,3104);

P += magnitude * grad_f[0];
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,3109,3136);

Q += magnitude * grad_f[1];
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,3143,3155);

h = f_2_3147_3154(this);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,3160,3172);

g = f_2_3164_3171(this);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,3177,3211);

f_2_3177_3210(this, pi_R, pi_I, grad_f);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,3216,3238);

f_2_3216_3237(this, grad_h);
DynAbs.Tracing.TraceSender.TraceExitCondition(2,1991,3392);
}
while((DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1991,3392) || true) && (f_2_3250_3261(h)> H_EPSILON ||(DynAbs.Tracing.TraceSender.Expression_False(2, 3250, 3290)||g > G_EPSILON )||(DynAbs.Tracing.TraceSender.Expression_False(2, 3250, 3390)||(f_2_3295_3306(g)> G_EPSILON &&(DynAbs.Tracing.TraceSender.Expression_True(2, 3295, 3389)&&f_2_3322_3377(grad_f[0] * grad_h[1] - grad_f[1] * grad_h[0])> F_EPSILON))))
);
}catch(System.Exception) { DynAbs.Tracing.TraceSender.TraceExitLoopByException(2,1991,3392);
 throw; }finally{DynAbs.Tracing.TraceSender.TraceExitLoop(2,1991,3392);
}}DynAbs.Tracing.TraceSender.TraceExitMethod(2,1702,3396);

double
f_2_2033_2040(Demand
this_param)
{
var return_v = this_param.findH();
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 2033, 2040);
return return_v;
}


double
f_2_2049_2060(double
value)
{
var return_v = Math.Abs( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 2049, 2060);
return return_v;
}


double
f_2_2097_2118(Demand
this_param,double[]
gradient)
{
var return_v = this_param.findGradientH( gradient);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 2097, 2118);
return return_v;
}


double
f_2_2257_2264(Demand
this_param)
{
var return_v = this_param.findG();
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 2257, 2264);
return return_v;
}


double
f_2_2311_2332(Demand
this_param,double[]
gradient)
{
var return_v = this_param.findGradientG( gradient);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 2311, 2332);
return return_v;
}


double
f_2_2339_2360(Demand
this_param,double[]
gradient)
{
var return_v = this_param.findGradientH( gradient);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 2339, 2360);
return return_v;
}


double
f_2_2380_2410(Demand
this_param,double[]
v_mod,double[]
v_static)
{
var return_v = this_param.makeOrthogonal( v_mod, v_static);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 2380, 2410);
return return_v;
}


double
f_2_2546_2579(Demand
this_param,double
pi_R,double
pi_I,double[]
gradient)
{
var return_v = this_param.findGradientF( pi_R, pi_I, gradient);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 2546, 2579);
return return_v;
}


int
f_2_2585_2619(Demand
this_param,double
pi_R,double
pi_I,double[]
dd_grad)
{
this_param.findDDGradF( pi_R, pi_I, dd_grad);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 2585, 2619);
return 0;
}


double
f_2_2737_2752(double
value)
{
var return_v = Math.Abs( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 2737, 2752);
return return_v;
}


double
f_2_2758_2779(Demand
this_param,double[]
gradient)
{
var return_v = this_param.findGradientH( gradient);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 2758, 2779);
return return_v;
}


double
f_2_2798_2828(Demand
this_param,double[]
v_mod,double[]
v_static)
{
var return_v = this_param.makeOrthogonal( v_mod, v_static);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 2798, 2828);
return return_v;
}


double
f_2_2834_2855(Demand
this_param,double[]
gradient)
{
var return_v = this_param.findGradientG( gradient);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 2834, 2855);
return return_v;
}


double
f_2_2992_2999(Demand
this_param)
{
var return_v = this_param.findG();
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 2992, 2999);
return return_v;
}


double
f_2_3147_3154(Demand
this_param)
{
var return_v = this_param.findH();
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 3147, 3154);
return return_v;
}


double
f_2_3164_3171(Demand
this_param)
{
var return_v = this_param.findG();
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 3164, 3171);
return return_v;
}


double
f_2_3177_3210(Demand
this_param,double
pi_R,double
pi_I,double[]
gradient)
{
var return_v = this_param.findGradientF( pi_R, pi_I, gradient);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 3177, 3210);
return return_v;
}


double
f_2_3216_3237(Demand
this_param,double[]
gradient)
{
var return_v = this_param.findGradientH( gradient);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 3216, 3237);
return return_v;
}


double
f_2_3250_3261(double
value)
{
var return_v = Math.Abs( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 3250, 3261);
return return_v;
}


double
f_2_3295_3306(double
value)
{
var return_v = Math.Abs( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 3295, 3306);
return return_v;
}


double
f_2_3322_3377(double
value)
{
var return_v = Math.Abs( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 3322, 3377);
return return_v;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(2,1702,3396);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(2,1702,3396);
}
		}

private double findG()
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(2,3401,3464);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,3431,3460);

return (P * P + Q * Q - 0.8);
DynAbs.Tracing.TraceSender.TraceExitMethod(2,3401,3464);
	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(2,3401,3464);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(2,3401,3464);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

private double findH()
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(2,3469,3524);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,3499,3520);

return (P - 5.0 * Q);
DynAbs.Tracing.TraceSender.TraceExitMethod(2,3469,3524);
	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(2,3469,3524);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(2,3469,3524);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

private double findGradientF(double pi_R, double pi_I, double[] gradient)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(2,3529,3932);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,3610,3647);

gradient[0] = 1.0 / (1.0 + P) - pi_R;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,3651,3688);

gradient[1] = 1.0 / (1.0 + Q) - pi_I;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,3694,3717);

double 
magnitude = 0.0
;
try {DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,3729,3734);
		for(int 
i = 0
; (DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,3721,3791) || true) && (i < 2)
; DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,3743,3746)
,i++,DynAbs.Tracing.TraceSender.TraceExitCondition(2,3721,3791))

{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,3721,3791);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,3752,3791);

magnitude += gradient[i] * gradient[i];
}
}catch(System.Exception) { DynAbs.Tracing.TraceSender.TraceExitLoopByException(2,1,71);
 throw; }finally{DynAbs.Tracing.TraceSender.TraceExitLoop(2,1,71);
}DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,3797,3830);

magnitude = f_2_3809_3829(magnitude);
try {DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,3844,3849);

		for(int 
i = 0
; (DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,3836,3905) || true) && (i < 2)
; DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,3858,3861)
,i++,DynAbs.Tracing.TraceSender.TraceExitCondition(2,3836,3905))

{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,3836,3905);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,3867,3905);

gradient[i] = gradient[i] / magnitude;
}
}catch(System.Exception) { DynAbs.Tracing.TraceSender.TraceExitLoopByException(2,1,70);
 throw; }finally{DynAbs.Tracing.TraceSender.TraceExitLoop(2,1,70);
}DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,3911,3928);

return magnitude;
DynAbs.Tracing.TraceSender.TraceExitMethod(2,3529,3932);

double
f_2_3809_3829(double
d)
{
var return_v = Math.Sqrt( d);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 3809, 3829);
return return_v;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(2,3529,3932);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(2,3529,3932);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

private double findGradientG(double[] gradient)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(2,3937,4282);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,3992,4014);

gradient[0] = 2.0 * P;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,4018,4040);

gradient[1] = 2.0 * Q;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,4044,4067);

double 
magnitude = 0.0
;
try {DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,4079,4084);
		for(int 
i = 0
; (DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,4071,4141) || true) && (i < 2)
; DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,4093,4096)
,i++,DynAbs.Tracing.TraceSender.TraceExitCondition(2,4071,4141))

{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,4071,4141);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,4102,4141);

magnitude += gradient[i] * gradient[i];
}
}catch(System.Exception) { DynAbs.Tracing.TraceSender.TraceExitLoopByException(2,1,71);
 throw; }finally{DynAbs.Tracing.TraceSender.TraceExitLoop(2,1,71);
}DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,4147,4180);

magnitude = f_2_4159_4179(magnitude);
try {DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,4194,4199);

		for(int 
i = 0
; (DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,4186,4255) || true) && (i < 2)
; DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,4208,4211)
,i++,DynAbs.Tracing.TraceSender.TraceExitCondition(2,4186,4255))

{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,4186,4255);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,4217,4255);

gradient[i] = gradient[i] / magnitude;
}
}catch(System.Exception) { DynAbs.Tracing.TraceSender.TraceExitLoopByException(2,1,70);
 throw; }finally{DynAbs.Tracing.TraceSender.TraceExitLoop(2,1,70);
}DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,4261,4278);

return magnitude;
DynAbs.Tracing.TraceSender.TraceExitMethod(2,3937,4282);

double
f_2_4159_4179(double
d)
{
var return_v = Math.Sqrt( d);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 4159, 4179);
return return_v;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(2,3937,4282);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(2,3937,4282);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

private double findGradientH(double[] gradient)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(2,4287,4621);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,4342,4360);

gradient[0] = 1.0;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,4364,4383);

gradient[1] = -5.0;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,4387,4410);

double 
magnitude = 0.0
;
try {DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,4422,4427);
		for(int 
i = 0
; (DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,4414,4484) || true) && (i < 2)
; DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,4436,4439)
,i++,DynAbs.Tracing.TraceSender.TraceExitCondition(2,4414,4484))

{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,4414,4484);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,4445,4484);

magnitude += gradient[i] * gradient[i];
}
}catch(System.Exception) { DynAbs.Tracing.TraceSender.TraceExitLoopByException(2,1,71);
 throw; }finally{DynAbs.Tracing.TraceSender.TraceExitLoop(2,1,71);
}DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,4488,4521);

magnitude = f_2_4500_4520(magnitude);
try {DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,4533,4538);
		for(int 
i = 0
; (DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,4525,4594) || true) && (i < 2)
; DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,4547,4550)
,i++,DynAbs.Tracing.TraceSender.TraceExitCondition(2,4525,4594))

{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,4525,4594);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,4556,4594);

gradient[i] = gradient[i] / magnitude;
}
}catch(System.Exception) { DynAbs.Tracing.TraceSender.TraceExitLoopByException(2,1,70);
 throw; }finally{DynAbs.Tracing.TraceSender.TraceExitLoop(2,1,70);
}DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,4600,4617);

return magnitude;
DynAbs.Tracing.TraceSender.TraceExitMethod(2,4287,4621);

double
f_2_4500_4520(double
d)
{
var return_v = Math.Sqrt( d);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 4500, 4520);
return return_v;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(2,4287,4621);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(2,4287,4621);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

private void findDDGradF(double pi_R, double pi_I, double[] dd_grad)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(2,4626,5109);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,4702,4740);

double 
P_plus_1_inv = 1.0 / (P + 1.0)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,4744,4782);

double 
Q_plus_1_inv = 1.0 / (Q + 1.0)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,4786,4827);

double 
P_grad_term = P_plus_1_inv - pi_R
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,4831,4872);

double 
Q_grad_term = Q_plus_1_inv - pi_I
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,4878,4961);

double 
grad_mag = f_2_4896_4960(P_grad_term * P_grad_term + Q_grad_term * Q_grad_term)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,4967,5034);

dd_grad[0] = -P_plus_1_inv * P_plus_1_inv * P_grad_term / grad_mag;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,5038,5105);

dd_grad[1] = -Q_plus_1_inv * Q_plus_1_inv * Q_grad_term / grad_mag;
DynAbs.Tracing.TraceSender.TraceExitMethod(2,4626,5109);

double
f_2_4896_4960(double
d)
{
var return_v = Math.Sqrt( d);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 4896, 4960);
return return_v;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(2,4626,5109);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(2,4626,5109);
}
		}

private double makeOrthogonal(double[] v_mod, double[] v_static)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(2,5114,5639);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,5186,5205);

double 
total = 0.0
;
try {DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,5217,5222);
		for(int 
i = 0
; (DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,5209,5272) || true) && (i < 2)
; DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,5231,5234)
,i++,DynAbs.Tracing.TraceSender.TraceExitCondition(2,5209,5272))

{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,5209,5272);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,5240,5272);

total += v_mod[i] * v_static[i];
}
}catch(System.Exception) { DynAbs.Tracing.TraceSender.TraceExitLoopByException(2,1,64);
 throw; }finally{DynAbs.Tracing.TraceSender.TraceExitLoop(2,1,64);
}DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,5278,5298);

double 
length = 0.0
;
try {DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,5310,5315);
		for(int 
i = 0
; (DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,5302,5422) || true) && (i < 2)
; DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,5324,5327)
,i++,DynAbs.Tracing.TraceSender.TraceExitCondition(2,5302,5422))

{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,5302,5422);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,5338,5382);

v_mod[i] = v_mod[i] - (total * v_static[i]);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,5387,5417);

length += v_mod[i] * v_mod[i];
}
}catch(System.Exception) { DynAbs.Tracing.TraceSender.TraceExitLoopByException(2,1,121);
 throw; }finally{DynAbs.Tracing.TraceSender.TraceExitLoop(2,1,121);
}DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,5426,5453);

length = f_2_5435_5452(length);
try {DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,5467,5472);

		for(int 
i = 0
; (DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,5459,5519) || true) && (i < 2)
; DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,5481,5484)
,i++,DynAbs.Tracing.TraceSender.TraceExitCondition(2,5459,5519))

{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,5459,5519);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,5490,5519);

v_mod[i] = v_mod[i] / length;
}
}catch(System.Exception) { DynAbs.Tracing.TraceSender.TraceExitLoopByException(2,1,61);
 throw; }finally{DynAbs.Tracing.TraceSender.TraceExitLoop(2,1,61);
}
if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,5525,5591) || true) && (1.0 - total * total < 0.0)
)    // Roundoff error

{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,5525,5591);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,5580,5591);

return 0.0;
DynAbs.Tracing.TraceSender.TraceExitCondition(2,5525,5591);
}
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,5597,5635);

return f_2_5604_5634(1.0 - total * total);
DynAbs.Tracing.TraceSender.TraceExitMethod(2,5114,5639);

double
f_2_5435_5452(double
d)
{
var return_v = Math.Sqrt( d);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 5435, 5452);
return return_v;
}


double
f_2_5604_5634(double
d)
{
var return_v = Math.Sqrt( d);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 5604, 5634);
return return_v;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(2,5114,5639);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(2,5114,5639);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

static Demand()
{
DynAbs.Tracing.TraceSender.TraceEnterStaticConstructor(2,65,5642);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,224,244);
F_EPSILON = 0.000001;DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,270,290);
G_EPSILON = 0.000001;DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,316,336);
H_EPSILON = 0.000001;DynAbs.Tracing.TraceSender.TraceExitStaticConstructor(2,65,5642);

DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(2,65,5642);
}

		int ___ignore_me___=DynAbs.Tracing.TraceSender.TraceBeforeConstructor(2,65,5642);
}
