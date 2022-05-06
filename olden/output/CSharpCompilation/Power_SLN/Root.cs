public class Root
{
public Demand D;

public double theta_R;

public double theta_I;

public Demand last;

public double last_theta_R;

public double last_theta_I;

public Lateral[] feeders;

private static double ROOT_EPSILON ;

private static double[] map_P ;

private static double MIN_THETA_R ;

private static double PER_INDEX_R ;

private static double MAX_THETA_R ;

private static double[] map_Q ;

private static double MIN_THETA_I ;

private static double PER_INDEX_I ;

private static double MAX_THETA_I ;

public Root(int nfeeders, int nlaterals, int nbranches, int nleaves)
		{
			try
{DynAbs.Tracing.TraceSender.TraceEnterConstructor(6,3247,3519);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,190,191);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,296,303);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,412,419);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,501,505);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,605,617);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,721,733);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,843,850);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,3323,3340);

D = f_6_3327_3339();
DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,3344,3364);

last = f_6_3351_3363();
DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,3370,3402);

feeders = new Lateral[nfeeders];
try {DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,3414,3419);
		for(int 
i = 0
; (DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,3406,3515) || true) && (i < nfeeders)
; DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,3435,3438)
,i++,DynAbs.Tracing.TraceSender.TraceExitCondition(6,3406,3515))

{DynAbs.Tracing.TraceSender.TraceEnterCondition(6,3406,3515);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,3449,3510);

this.feeders[i] = f_6_3467_3509(nlaterals, nbranches, nleaves);
}
}catch(System.Exception) { DynAbs.Tracing.TraceSender.TraceExitLoopByException(6,1,110);
 throw; }finally{DynAbs.Tracing.TraceSender.TraceExitLoop(6,1,110);
}DynAbs.Tracing.TraceSender.TraceExitConstructor(6,3247,3519);
}catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(6,3247,3519);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(6,3247,3519);
}
		}

public bool reachedLimit()
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(6,3620,3782);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,3654,3778);

return (f_6_3662_3702(D.P / 10000.0 - theta_R)< ROOT_EPSILON &&(DynAbs.Tracing.TraceSender.Expression_True(6, 3662, 3776)&&f_6_3721_3761(D.Q / 10000.0 - theta_I)< ROOT_EPSILON));
DynAbs.Tracing.TraceSender.TraceExitMethod(6,3620,3782);

double
f_6_3662_3702(double
value)
{
var return_v = System.Math.Abs( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(6, 3662, 3702);
return return_v;
}


double
f_6_3721_3761(double
value)
{
var return_v = System.Math.Abs( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(6, 3721, 3761);
return return_v;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(6,3620,3782);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(6,3620,3782);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

public void compute()
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(6,3860,4053);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,3889,3899);

D.P = 0.0;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,3903,3913);

D.Q = 0.0;
try {DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,3925,3930);
		for(int 
i = 0
; (DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,3917,4049) || true) && (i < f_6_3936_3955(this.feeders))
; DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,3957,3960)
,++i,DynAbs.Tracing.TraceSender.TraceExitCondition(6,3917,4049))

{DynAbs.Tracing.TraceSender.TraceEnterCondition(6,3917,4049);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,3971,4044);

f_6_3971_4043(			D, f_6_3983_4042(this.feeders[i], theta_R, theta_I, theta_R, theta_I));
}
}catch(System.Exception) { DynAbs.Tracing.TraceSender.TraceExitLoopByException(6,1,133);
 throw; }finally{DynAbs.Tracing.TraceSender.TraceExitLoop(6,1,133);
}DynAbs.Tracing.TraceSender.TraceExitMethod(6,3860,4053);

int
f_6_3936_3955(Lateral[]
this_param)
{
var return_v = this_param.Length;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(6, 3936, 3955);
return return_v;
}


Demand
f_6_3983_4042(Lateral
this_param,double
theta_R,double
theta_I,double
pi_R,double
pi_I)
{
var return_v = this_param.compute( theta_R, theta_I, pi_R, pi_I);
DynAbs.Tracing.TraceSender.TraceEndInvocation(6, 3983, 4042);
return return_v;
}


int
f_6_3971_4043(Demand
this_param,Demand
frm)
{
this_param.increment( frm);
DynAbs.Tracing.TraceSender.TraceEndInvocation(6, 3971, 4043);
return 0;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(6,3860,4053);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(6,3860,4053);
}
		}

public void nextIter(bool verbose, double new_theta_R, double new_theta_I)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(6,4126,4348);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,4208,4221);

last.P = D.P;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,4225,4238);

last.Q = D.Q;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,4242,4265);

last_theta_R = theta_R;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,4269,4292);

last_theta_I = theta_I;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,4296,4318);

theta_R = new_theta_R;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,4322,4344);

theta_I = new_theta_I;
DynAbs.Tracing.TraceSender.TraceExitMethod(6,4126,4348);
	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(6,4126,4348);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(6,4126,4348);
}
		}

public void nextIter(bool verbose)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(6,4491,5217);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,4533,4586);

int 
i = (int)((theta_R - MIN_THETA_R) / PER_INDEX_R)
;

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,4590,4610) || true) && (i < 0)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(6,4590,4610);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,4604,4610);

i = 0;
DynAbs.Tracing.TraceSender.TraceExitCondition(6,4590,4610);
}

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,4616,4638) || true) && (i > 35)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(6,4616,4638);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,4631,4638);

i = 35;
DynAbs.Tracing.TraceSender.TraceExitCondition(6,4616,4638);
}
DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,4644,4752);

double 
d_theta_R = -(theta_R - D.P / 10000.0) / (1.0 - (map_P[i + 1] - map_P[i]) / (PER_INDEX_R * 10000.0))
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,4758,4807);

i = (int)((theta_I - MIN_THETA_I) / PER_INDEX_I);

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,4811,4831) || true) && (i < 0)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(6,4811,4831);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,4825,4831);

i = 0;
DynAbs.Tracing.TraceSender.TraceExitCondition(6,4811,4831);
}

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,4837,4859) || true) && (i > 35)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(6,4837,4859);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,4852,4859);

i = 35;
DynAbs.Tracing.TraceSender.TraceExitCondition(6,4837,4859);
}
DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,4863,4971);

double 
d_theta_I = -(theta_I - D.Q / 10000.0) / (1.0 - (map_Q[i + 1] - map_Q[i]) / (PER_INDEX_I * 10000.0))
;

if ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,4977,5071) || true) && (verbose)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(6,4977,5071);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,5003,5071);

f_6_5003_5070("D TR-" + DynAbs.Tracing.TraceSender.TraceInvocationWrapper(() => (d_theta_R).ToString(),6,5038,5047)+ ", TI=" + DynAbs.Tracing.TraceSender.TraceInvocationWrapper(() => (d_theta_I).ToString(),6,5060,5069));
DynAbs.Tracing.TraceSender.TraceExitCondition(6,4977,5071);
}
DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,5079,5092);

last.P = D.P;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,5096,5109);

last.Q = D.Q;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,5113,5136);

last_theta_R = theta_R;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,5140,5163);

last_theta_I = theta_I;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,5167,5188);

theta_R += d_theta_R;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,5192,5213);

theta_I += d_theta_I;
DynAbs.Tracing.TraceSender.TraceExitMethod(6,4491,5217);

int
f_6_5003_5070(string
value)
{
System.Console.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(6, 5003, 5070);
return 0;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(6,4491,5217);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(6,4491,5217);
}
		}

public override string ToString()
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(6,5288,5408);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,5329,5404);

return "TR=" + DynAbs.Tracing.TraceSender.TraceInvocationWrapper(() => (theta_R).ToString(),6,5344,5351)+ ", TI=" + DynAbs.Tracing.TraceSender.TraceInvocationWrapper(() => (theta_I).ToString(),6,5364,5371)+ ", P0=" + DynAbs.Tracing.TraceSender.TraceInvocationWrapper(() => (D.P).ToString(),6,5384,5387)+ ", Q0=" + DynAbs.Tracing.TraceSender.TraceInvocationWrapper(() => (D.Q).ToString(),6,5400,5403);
DynAbs.Tracing.TraceSender.TraceExitMethod(6,5288,5408);
	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(6,5288,5408);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(6,5288,5408);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

static Root()
{
DynAbs.Tracing.TraceSender.TraceEnterStaticConstructor(6,111,5411);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,928,950);
ROOT_EPSILON = 0.00001;DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,1053,1702);
map_P = new double[]{
    8752.218091048, 8446.106670416, 8107.990680283,
    7776.191574285, 7455.920518777, 7146.602181352,
    6847.709026813, 6558.734204024, 6279.213382291,
    6008.702199986, 5746.786181029, 5493.078256495,
    5247.206333097, 5008.828069358, 4777.615815166,
    4553.258735900, 4335.470002316, 4123.971545694,
    3918.501939675, 3718.817618538, 3524.683625800,
    3335.876573044, 3152.188635673, 2973.421417103,
    2799.382330486, 2629.892542617, 2464.782829705,
    2303.889031418, 2147.054385395, 1994.132771399,
    1844.985347313, 1699.475053321, 1557.474019598,
    1418.860479043, 1283.520126656, 1151.338004216
  };DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,1730,1748);
MIN_THETA_R = 0.65;DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,1774,1792);
PER_INDEX_R = 0.01;DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,1818,1837);
MAX_THETA_R = 0.995;DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,1944,2571);
map_Q = new double[]{
    1768.846590190, 1706.229490046, 1637.253873079,
    1569.637451623, 1504.419525242, 1441.477913810,
    1380.700660446, 1321.980440476, 1265.218982201,
    1210.322424636, 1157.203306183, 1105.780028163,
    1055.974296746, 1007.714103979, 960.930643875,
    915.558722782, 871.538200178, 828.810882006,
    787.322098340, 747.020941334, 707.858376214,
    669.787829741, 632.765987756, 596.751545633,
    561.704466609, 527.587580585, 494.365739051,
    462.004890691, 430.472546686, 399.738429196,
    369.773787595, 340.550287137, 312.041496095,
    284.222260660, 257.068973074, 230.557938283
  };DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,2599,2617);
MIN_THETA_I = 0.13;DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,2643,2662);
PER_INDEX_I = 0.002;DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,2688,2707);
MAX_THETA_I = 0.199;DynAbs.Tracing.TraceSender.TraceExitStaticConstructor(6,111,5411);

DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(6,111,5411);
}

		int ___ignore_me___=DynAbs.Tracing.TraceSender.TraceBeforeConstructor(6,111,5411);

static Demand
f_6_3327_3339()
{
var return_v = new Demand();
DynAbs.Tracing.TraceSender.TraceEndInvocation(6, 3327, 3339);
return return_v;
}


static Demand
f_6_3351_3363()
{
var return_v = new Demand();
DynAbs.Tracing.TraceSender.TraceEndInvocation(6, 3351, 3363);
return return_v;
}


static Lateral
f_6_3467_3509(int
num,int
nbranches,int
nleaves)
{
var return_v = new Lateral( num, nbranches, nleaves);
DynAbs.Tracing.TraceSender.TraceEndInvocation(6, 3467, 3509);
return return_v;
}

}
