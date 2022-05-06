using System;
public class Branch
{
private Demand D;

private double alpha ;

private double beta ;

private double R ;

private double X ;

private Branch nextBranch;

System.Collections.Generic.List<Leaf> leaves;

public Branch(int num, int nleaves)
		{
			try
{DynAbs.Tracing.TraceSender.TraceEnterConstructor(1,1088,1394);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,450,451);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,470,481);
this.alpha = 0.0;DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,500,510);
this.beta = 0.0;DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,529,539);
this.R = 0.0001;DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,558,569);
this.X = 0.00002;DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,675,685);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,790,796);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1131,1148);

D = f_1_1135_1147();

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1154,1244) || true) && (num <= 1)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,1154,1244);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1171,1189);

nextBranch = null;
DynAbs.Tracing.TraceSender.TraceExitCondition(1,1154,1244);
}

else

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,1154,1244);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1202,1244);

nextBranch = f_1_1215_1243(num - 1, nleaves);
DynAbs.Tracing.TraceSender.TraceExitCondition(1,1154,1244);
}
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1273,1326);

leaves = f_1_1282_1325();
try {DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1338,1343);
		for(int 
k = 0
; (DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1330,1390) || true) && (k < nleaves)
; DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1358,1361)
,k++,DynAbs.Tracing.TraceSender.TraceExitCondition(1,1330,1390))

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,1330,1390);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1367,1390);

f_1_1367_1389(			leaves, f_1_1378_1388());
}
}catch(System.Exception) { DynAbs.Tracing.TraceSender.TraceExitLoopByException(1,1,61);
 throw; }finally{DynAbs.Tracing.TraceSender.TraceExitLoop(1,1,61);
}DynAbs.Tracing.TraceSender.TraceExitConstructor(1,1088,1394);
}catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(1,1088,1394);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(1,1088,1394);
}
		}

public Demand compute(double theta_R, double theta_I, double pi_R, double pi_I)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(1,1721,2718);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1808,1871);

double 
new_pi_R = pi_R + alpha * (theta_R + (theta_I * X) / R)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1875,1937);

double 
new_pi_I = pi_I + beta * (theta_I + (theta_R * R) / X)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1943,1960);

Demand 
a1 = null
;

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1964,2053) || true) && (nextBranch != null)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,1964,2053);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1991,2053);

a1 = f_1_1996_2052(nextBranch, theta_R, theta_I, new_pi_R, new_pi_I);
DynAbs.Tracing.TraceSender.TraceExitCondition(1,1964,2053);
}
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2110,2120);

f_1_2110_2119(
		// Initialize and pass the prices down the tree
		D);
try {DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2132,2137);
		for(int 
i = 0
; (DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2124,2227) || true) && (i < f_1_2143_2160(this.leaves))
; DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2162,2165)
,++i,DynAbs.Tracing.TraceSender.TraceExitCondition(1,2124,2227))

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,2124,2227);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2171,2227);

f_1_2171_2226(			D, f_1_2183_2225(f_1_2183_2197(this.leaves, i), new_pi_R, new_pi_I));
}
}catch(System.Exception) { DynAbs.Tracing.TraceSender.TraceExitLoopByException(1,1,104);
 throw; }finally{DynAbs.Tracing.TraceSender.TraceExitLoop(1,1,104);
}
if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2233,2276) || true) && (nextBranch != null)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,2233,2276);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2260,2276);

f_1_2260_2275(			D, a1);
DynAbs.Tracing.TraceSender.TraceExitCondition(1,2233,2276);
}
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2309,2334);

double 
a = R * R + X * X
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2338,2391);

double 
b = 2.0 * R * X * D.Q - 2.0 * X * X * D.P - R
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2395,2424);

double 
c = R * D.Q - X * D.P
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2428,2448);

c = c * c + R * D.P;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2452,2516);

double 
root = (-b - f_1_2472_2502(b * b - 4.0 * a * c)) / (2.0 * a)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2520,2555);

D.Q = D.Q + ((root - D.P) * X) / R;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2559,2570);

D.P = root;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2600,2618);

a = 2.0 * R * D.P;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2622,2640);

b = 2.0 * X * D.Q;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2644,2670);

alpha = a / (1.0 - a - b);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2674,2699);

beta = b / (1.0 - a - b);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2705,2714);

return D;
DynAbs.Tracing.TraceSender.TraceExitMethod(1,1721,2718);

Demand
f_1_1996_2052(Branch
this_param,double
theta_R,double
theta_I,double
pi_R,double
pi_I)
{
var return_v = this_param.compute( theta_R, theta_I, pi_R, pi_I);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 1996, 2052);
return return_v;
}


int
f_1_2110_2119(Demand
this_param)
{
this_param.reset();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 2110, 2119);
return 0;
}


int
f_1_2143_2160(System.Collections.Generic.List<Leaf>
this_param)
{
var return_v = this_param.Count;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(1, 2143, 2160);
return return_v;
}


Leaf
f_1_2183_2197(System.Collections.Generic.List<Leaf>
this_param,int
i0)
{
var return_v = this_param[ i0];
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(1, 2183, 2197);
return return_v;
}


Demand
f_1_2183_2225(Leaf
this_param,double
pi_R,double
pi_I)
{
var return_v = this_param.compute( pi_R, pi_I);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 2183, 2225);
return return_v;
}


int
f_1_2171_2226(Demand
this_param,Demand
frm)
{
this_param.increment( frm);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 2171, 2226);
return 0;
}


int
f_1_2260_2275(Demand
this_param,Demand
frm)
{
this_param.increment( frm);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 2260, 2275);
return 0;
}


double
f_1_2472_2502(double
d)
{
var return_v = Math.Sqrt( d);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 2472, 2502);
return return_v;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(1,1721,2718);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(1,1721,2718);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

static Branch()
{
DynAbs.Tracing.TraceSender.TraceEnterStaticConstructor(1,340,2721);
DynAbs.Tracing.TraceSender.TraceExitStaticConstructor(1,340,2721);

DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(1,340,2721);
}

		int ___ignore_me___=DynAbs.Tracing.TraceSender.TraceBeforeConstructor(1,340,2721);

static Demand
f_1_1135_1147()
{
var return_v = new Demand();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 1135, 1147);
return return_v;
}


static Branch
f_1_1215_1243(int
num,int
nleaves)
{
var return_v = new Branch( num, nleaves);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 1215, 1243);
return return_v;
}


static System.Collections.Generic.List<Leaf>
f_1_1282_1325()
{
var return_v = new System.Collections.Generic.List<Leaf>();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 1282, 1325);
return return_v;
}


static Leaf
f_1_1378_1388()
{
var return_v = new Leaf();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 1378, 1388);
return return_v;
}


static int
f_1_1367_1389(System.Collections.Generic.List<Leaf>
this_param,Leaf
item)
{
this_param.Add( item);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 1367, 1389);
return 0;
}

}
