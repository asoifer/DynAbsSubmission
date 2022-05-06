public class Value
{
public int value;

public Value left;

public Value right;

public static bool FORWARD ;

public static bool BACKWARD ;

private static int CONST_m1 ;

private static int CONST_b ;

public static int RANGE ;

public Value(int v)
		{
			try
{DynAbs.Tracing.TraceSender.TraceEnterConstructor(2,637,711);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,185,190);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,207,211);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,228,233);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,664,674);

value = v;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,678,690);

left = null;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,694,707);

right = null;
DynAbs.Tracing.TraceSender.TraceExitConstructor(2,637,711);
}catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(2,637,711);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(2,637,711);
}
		}

public static Value createTree(int size, int seed)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterStaticMethod(2,962,1303);

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1020,1299) || true) && (size > 1)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,1020,1299);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1042,1062);

seed = f_2_1049_1061(seed);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1067,1095);

int 
next_val = seed % RANGE
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1102,1137);

Value 
retval = f_2_1117_1136(next_val)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1142,1183);

retval.left = f_2_1156_1182(size / 2, seed);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1188,1250);

retval.right = f_2_1203_1249(size / 2, f_2_1224_1248(seed, size + 1));
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1255,1269);

return retval;
DynAbs.Tracing.TraceSender.TraceExitCondition(2,1020,1299);
}

else

{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,1020,1299);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1287,1299);

return null;
DynAbs.Tracing.TraceSender.TraceExitCondition(2,1020,1299);
}
DynAbs.Tracing.TraceSender.TraceExitStaticMethod(2,962,1303);

int
f_2_1049_1061(int
seed)
{
var return_v = random( seed);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 1049, 1061);
return return_v;
}


Value
f_2_1117_1136(int
v)
{
var return_v = new Value( v);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 1117, 1136);
return return_v;
}


Value
f_2_1156_1182(int
size,int
seed)
{
var return_v = createTree( size, seed);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 1156, 1182);
return return_v;
}


int
f_2_1224_1248(int
seed,int
n)
{
var return_v = skiprand( seed, n);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 1224, 1248);
return return_v;
}


Value
f_2_1203_1249(int
size,int
seed)
{
var return_v = createTree( size, seed);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 1203, 1249);
return return_v;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(2,962,1303);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(2,962,1303);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

public int bisort(int spr_val, bool direction)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(2,1563,1980);

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1617,1957) || true) && (left == null)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,1617,1957);

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1643,1758) || true) && ((value > spr_val) ^ direction)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,1643,1758);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1688,1709);

int 
tmpval = spr_val
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1715,1731);

spr_val = value;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1737,1752);

value = tmpval;
DynAbs.Tracing.TraceSender.TraceExitCondition(2,1643,1758);
}
DynAbs.Tracing.TraceSender.TraceExitCondition(2,1617,1957);
}

else

{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,1617,1957);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1781,1797);

int 
val = value
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1802,1838);

value = f_2_1810_1837(left, val, direction);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1843,1866);

bool 
ndir = !direction
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1871,1909);

spr_val = f_2_1881_1908(right, spr_val, ndir);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1914,1952);

spr_val = f_2_1924_1951(this, spr_val, direction);
DynAbs.Tracing.TraceSender.TraceExitCondition(2,1617,1957);
}
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1961,1976);

return spr_val;
DynAbs.Tracing.TraceSender.TraceExitMethod(2,1563,1980);

int
f_2_1810_1837(Value
this_param,int
spr_val,bool
direction)
{
var return_v = this_param.bisort( spr_val, direction);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 1810, 1837);
return return_v;
}


int
f_2_1881_1908(Value
this_param,int
spr_val,bool
direction)
{
var return_v = this_param.bisort( spr_val, direction);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 1881, 1908);
return return_v;
}


int
f_2_1924_1951(Value
this_param,int
spr_val,bool
direction)
{
var return_v = this_param.bimerge( spr_val, direction);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 1924, 1951);
return return_v;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(2,1563,1980);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(2,1563,1980);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

public int bimerge(int spr_val, bool direction)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(2,2256,3230);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2311,2326);

int 
rv = value
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2330,2346);

Value 
pl = left
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2350,2367);

Value 
pr = right
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2373,2421);

bool 
rightexchange = (rv > spr_val) ^ direction
;

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2425,2491) || true) && (rightexchange)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,2425,2491);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2452,2468);

value = spr_val;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2473,2486);

spr_val = rv;
DynAbs.Tracing.TraceSender.TraceExitCondition(2,2425,2491);
}
try {
while((DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2497,3082) || true) && (pl != null)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,2497,3082);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2524,2542);

int 
lv = pl.value
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2547,2567);

Value 
pll = pl.left
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2572,2593);

Value 
plr = pl.right
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2598,2612);

rv = pr.value;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2617,2637);

Value 
prl = pr.left
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2642,2663);

Value 
prr = pr.right
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2670,2715);

bool 
elementexchange = (lv > rv) ^ direction
;

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2720,3077) || true) && (rightexchange)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,2720,3077);

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2749,2897) || true) && (elementexchange)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,2749,2897);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2782,2802);

f_2_2782_2801(					pl, pr);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2809,2818);

pl = pll;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2825,2834);

pr = prl;
DynAbs.Tracing.TraceSender.TraceExitCondition(2,2749,2897);
}

else

{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,2749,2897);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2865,2874);

pl = plr;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2881,2890);

pr = prr;
DynAbs.Tracing.TraceSender.TraceExitCondition(2,2749,2897);
}
DynAbs.Tracing.TraceSender.TraceExitCondition(2,2720,3077);
}

else

{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,2720,3077);

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2924,3071) || true) && (elementexchange)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,2924,3071);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2957,2976);

f_2_2957_2975(					pl, pr);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2983,2992);

pl = plr;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2999,3008);

pr = prr;
DynAbs.Tracing.TraceSender.TraceExitCondition(2,2924,3071);
}

else

{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,2924,3071);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,3039,3048);

pl = pll;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,3055,3064);

pr = prl;
DynAbs.Tracing.TraceSender.TraceExitCondition(2,2924,3071);
}
DynAbs.Tracing.TraceSender.TraceExitCondition(2,2720,3077);
}
DynAbs.Tracing.TraceSender.TraceExitCondition(2,2497,3082);
}
}catch(System.Exception) { DynAbs.Tracing.TraceSender.TraceExitLoopByException(2,2497,3082);
 throw; }finally{DynAbs.Tracing.TraceSender.TraceExitLoop(2,2497,3082);
}
if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,3088,3207) || true) && (left != null)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,3088,3207);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,3114,3153);

value = f_2_3122_3152(left, value, direction);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,3158,3202);

spr_val = f_2_3168_3201(right, spr_val, direction);
DynAbs.Tracing.TraceSender.TraceExitCondition(2,3088,3207);
}
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,3211,3226);

return spr_val;
DynAbs.Tracing.TraceSender.TraceExitMethod(2,2256,3230);

int
f_2_2782_2801(Value
this_param,Value
n)
{
this_param.swapValRight( n);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 2782, 2801);
return 0;
}


int
f_2_2957_2975(Value
this_param,Value
n)
{
this_param.swapValLeft( n);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 2957, 2975);
return 0;
}


int
f_2_3122_3152(Value
this_param,int
spr_val,bool
direction)
{
var return_v = this_param.bimerge( spr_val, direction);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 3122, 3152);
return return_v;
}


int
f_2_3168_3201(Value
this_param,int
spr_val,bool
direction)
{
var return_v = this_param.bimerge( spr_val, direction);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 3168, 3201);
return return_v;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(2,2256,3230);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(2,2256,3230);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

public void swapValRight(Value n)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(2,3345,3512);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,3386,3405);

int 
tmpv = n.value
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,3409,3430);

Value 
tmpr = n.right
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,3436,3452);

n.value = value;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,3456,3472);

n.right = right;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,3478,3491);

value = tmpv;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,3495,3508);

right = tmpr;
DynAbs.Tracing.TraceSender.TraceExitMethod(2,3345,3512);
	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(2,3345,3512);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(2,3345,3512);
}
		}

public void swapValLeft(Value n)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(2,3626,3788);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,3666,3685);

int 
tmpv = n.value
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,3689,3709);

Value 
tmpl = n.left
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,3715,3731);

n.value = value;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,3735,3749);

n.left = left;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,3755,3768);

value = tmpv;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,3772,3784);

left = tmpl;
DynAbs.Tracing.TraceSender.TraceExitMethod(2,3626,3788);
	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(2,3626,3788);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(2,3626,3788);
}
		}

public void inOrder()
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(2,3863,4012);

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,3892,3928) || true) && (left != null)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,3892,3928);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,3913,3928);

f_2_3913_3927(			left);
DynAbs.Tracing.TraceSender.TraceExitCondition(2,3892,3928);
}
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,3932,3966);

f_2_3932_3965(DynAbs.Tracing.TraceSender.TraceInvocationWrapper(() => (value).ToString(),2,3953,3958)+ " ");

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,3970,4008) || true) && (right != null)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,3970,4008);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,3992,4008);

f_2_3992_4007(			right);
DynAbs.Tracing.TraceSender.TraceExitCondition(2,3970,4008);
}
DynAbs.Tracing.TraceSender.TraceExitMethod(2,3863,4012);

int
f_2_3913_3927(Value
this_param)
{
this_param.inOrder();
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 3913, 3927);
return 0;
}


int
f_2_3932_3965(string
value)
{
System.Console.Write( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 3932, 3965);
return 0;
}


int
f_2_3992_4007(Value
this_param)
{
this_param.inOrder();
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 3992, 4007);
return 0;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(2,3863,4012);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(2,3863,4012);
}
		}

private static int mult(int p, int q)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterStaticMethod(2,4217,4433);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,4262,4284);

int 
p1 = p / CONST_m1
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,4288,4310);

int 
p0 = p % CONST_m1
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,4314,4336);

int 
q1 = q / CONST_m1
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,4340,4362);

int 
q0 = q % CONST_m1
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,4366,4429);

return (((p0 * q1 + p1 * q0) % CONST_m1) * CONST_m1 + p0 * q0);
DynAbs.Tracing.TraceSender.TraceExitStaticMethod(2,4217,4433);
	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(2,4217,4433);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(2,4217,4433);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

private static int skiprand(int seed, int n)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterStaticMethod(2,4597,4714);
try {		for (; (DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,4649,4694) || true) && (n != 0)
; DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,4664,4667)
,n--,DynAbs.Tracing.TraceSender.TraceExitCondition(2,4649,4694)) 

{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,4649,4694);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,4674,4694);

seed = f_2_4681_4693(seed);
}
}catch(System.Exception) { DynAbs.Tracing.TraceSender.TraceExitLoopByException(2,1,46);
 throw; }finally{DynAbs.Tracing.TraceSender.TraceExitLoop(2,1,46);
}DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,4698,4710);

return seed;
DynAbs.Tracing.TraceSender.TraceExitStaticMethod(2,4597,4714);

int
f_2_4681_4693(int
seed)
{
var return_v = random( seed);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 4681, 4693);
return return_v;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(2,4597,4714);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(2,4597,4714);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

public static int random(int seed)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterStaticMethod(2,4886,4981);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,4928,4962);

int 
tmp = f_2_4938_4957(seed, CONST_b)+ 1
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,4966,4977);

return tmp;
DynAbs.Tracing.TraceSender.TraceExitStaticMethod(2,4886,4981);

int
f_2_4938_4957(int
p,int
q)
{
var return_v = mult( p, q);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 4938, 4957);
return return_v;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(2,4886,4981);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(2,4886,4981);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

static Value()
{
DynAbs.Tracing.TraceSender.TraceEnterStaticConstructor(2,150,4984);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,258,273);
FORWARD = false;DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,296,311);
BACKWARD = true;DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,400,416);
CONST_m1 = 10000;DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,439,457);
CONST_b = 31415821;DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,479,490);
RANGE = 100;DynAbs.Tracing.TraceSender.TraceExitStaticConstructor(2,150,4984);

DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(2,150,4984);
}

		int ___ignore_me___=DynAbs.Tracing.TraceSender.TraceBeforeConstructor(2,150,4984);
}
