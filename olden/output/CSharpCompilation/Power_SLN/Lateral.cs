using System;
public class Lateral
{
private Demand D;

private double alpha ;

private double beta ;

private double R ;

private double X ;

private Lateral next_lateral;

private Branch branch;

public Lateral(int num, int nbranches, int nleaves)
		{
			try
{DynAbs.Tracing.TraceSender.TraceEnterConstructor(3,1026,1344);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,438,439);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,458,469);
this.alpha = 0.0;DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,488,498);
this.beta = 0.0;DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,517,531);
this.R = 1/300000.0;DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,550,562);
this.X = 0.000001;DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,655,667);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,758,764);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,1085,1102);

D = f_3_1089_1101();

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,1158,1264) || true) && (num <= 1)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(3,1158,1264);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,1175,1195);

next_lateral = null;
DynAbs.Tracing.TraceSender.TraceExitCondition(3,1158,1264);
}

else

{DynAbs.Tracing.TraceSender.TraceEnterCondition(3,1158,1264);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,1208,1264);

next_lateral = f_3_1223_1263(num - 1, nbranches, nleaves);
DynAbs.Tracing.TraceSender.TraceExitCondition(3,1158,1264);
}
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,1300,1340);

branch = f_3_1309_1339(nbranches, nleaves);
DynAbs.Tracing.TraceSender.TraceExitConstructor(3,1026,1344);
}catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(3,1026,1344);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(3,1026,1344);
}
		}

public Demand compute(double theta_R, double theta_I, double pi_R, double pi_I)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(3,1690,2717);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,1843,1906);

double 
new_pi_R = pi_R + alpha * (theta_R + (theta_I * X) / R)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,1910,1972);

double 
new_pi_I = pi_I + beta * (theta_I + (theta_R * R) / X)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,1978,1988);

Demand 
a1
=default(Demand);

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,1992,2108) || true) && (next_lateral != null)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(3,1992,2108);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,2021,2085);

a1 = f_3_2026_2084(next_lateral, theta_R, theta_I, new_pi_R, new_pi_I);
DynAbs.Tracing.TraceSender.TraceExitCondition(3,1992,2108);
}

else

{DynAbs.Tracing.TraceSender.TraceEnterCondition(3,1992,2108);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,2098,2108);

a1 = null;
DynAbs.Tracing.TraceSender.TraceExitCondition(3,1992,2108);
}
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,2114,2179);

Demand 
a2 = f_3_2126_2178(branch, theta_R, theta_I, new_pi_R, new_pi_I)
;

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,2185,2254) || true) && (next_lateral != null)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(3,2185,2254);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,2214,2228);

f_3_2214_2227(			D, a1, a2);
DynAbs.Tracing.TraceSender.TraceExitCondition(3,2185,2254);
}

else

{DynAbs.Tracing.TraceSender.TraceEnterCondition(3,2185,2254);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,2241,2254);

f_3_2241_2253(			D, a2);
DynAbs.Tracing.TraceSender.TraceExitCondition(3,2185,2254);
}
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,2306,2331);

double 
a = R * R + X * X
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,2335,2388);

double 
b = 2.0 * R * X * D.Q - 2.0 * X * X * D.P - R
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,2392,2421);

double 
c = R * D.Q - X * D.P
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,2425,2445);

c = c * c + R * D.P;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,2449,2513);

double 
root = (-b - f_3_2469_2499(b * b - 4.0 * a * c)) / (2.0 * a)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,2517,2552);

D.Q = D.Q + ((root - D.P) * X) / R;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,2556,2567);

D.P = root;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,2599,2617);

a = 2.0 * R * D.P;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,2621,2639);

b = 2.0 * X * D.Q;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,2643,2669);

alpha = a / (1.0 - a - b);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,2673,2698);

beta = b / (1.0 - a - b);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,2704,2713);

return D;
DynAbs.Tracing.TraceSender.TraceExitMethod(3,1690,2717);

Demand
f_3_2026_2084(Lateral
this_param,double
theta_R,double
theta_I,double
pi_R,double
pi_I)
{
var return_v = this_param.compute( theta_R, theta_I, pi_R, pi_I);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 2026, 2084);
return return_v;
}


Demand
f_3_2126_2178(Branch
this_param,double
theta_R,double
theta_I,double
pi_R,double
pi_I)
{
var return_v = this_param.compute( theta_R, theta_I, pi_R, pi_I);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 2126, 2178);
return return_v;
}


int
f_3_2214_2227(Demand
this_param,Demand
a1,Demand
a2)
{
this_param.add( a1, a2);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 2214, 2227);
return 0;
}


int
f_3_2241_2253(Demand
this_param,Demand
frm)
{
this_param.assign( frm);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 2241, 2253);
return 0;
}


double
f_3_2469_2499(double
d)
{
var return_v = Math.Sqrt( d);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 2469, 2499);
return return_v;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(3,1690,2717);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(3,1690,2717);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

static Lateral()
{
DynAbs.Tracing.TraceSender.TraceEnterStaticConstructor(3,326,2720);
DynAbs.Tracing.TraceSender.TraceExitStaticConstructor(3,326,2720);

DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(3,326,2720);
}

		int ___ignore_me___=DynAbs.Tracing.TraceSender.TraceBeforeConstructor(3,326,2720);

static Demand
f_3_1089_1101()
{
var return_v = new Demand();
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 1089, 1101);
return return_v;
}


static Lateral
f_3_1223_1263(int
num,int
nbranches,int
nleaves)
{
var return_v = new Lateral( num, nbranches, nleaves);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 1223, 1263);
return return_v;
}


static Branch
f_3_1309_1339(int
num,int
nleaves)
{
var return_v = new Branch( num, nleaves);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 1309, 1339);
return return_v;
}

}
