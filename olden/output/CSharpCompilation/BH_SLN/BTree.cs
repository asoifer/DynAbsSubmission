using System;
using System.Collections.Generic;
public class BTree
{
public MathVector rmin;

public double rsize;

public Node root;

public Body bodyTab;

private Body bodyTabRev;

public BTree()
		{
			try
{DynAbs.Tracing.TraceSender.TraceEnterConstructor(3,607,821);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,225,229);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,247,252);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,313,317);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,400,407);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,504,514);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,629,653);

rmin = f_3_636_652();
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,657,677);

rsize = -2.0 * -2.0;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,681,693);

root = null;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,697,712);

bodyTab = null;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,716,734);

bodyTabRev = null;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,740,763);

f_3_740_762(
		rmin, 0, -2.0);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,767,790);

f_3_767_789(		rmin, 1, -2.0);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,794,817);

f_3_794_816(		rmin, 2, -2.0);
DynAbs.Tracing.TraceSender.TraceExitConstructor(3,607,821);
}catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(3,607,821);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(3,607,821);
}
		}

public Body bodies()
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(3,931,978);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,959,974);

return bodyTab;
DynAbs.Tracing.TraceSender.TraceExitMethod(3,931,978);
	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(3,931,978);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(3,931,978);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

public Body bodiesRev()
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(3,1119,1172);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,1150,1168);

return bodyTabRev;
DynAbs.Tracing.TraceSender.TraceExitMethod(3,1119,1172);
	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(3,1119,1172);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(3,1119,1172);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

public void createTestData(int nbody)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(3,1283,3263);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,1328,1362);

MathVector 
cmr = f_3_1345_1361()
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,1366,1400);

MathVector 
cmv = f_3_1383_1399()
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,1406,1429);

Body 
head = f_3_1418_1428()
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,1433,1450);

Body 
prev = head
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,1456,1489);

double 
rsc = 3.0 * 3.1415 / 16.0
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,1493,1527);

double 
vsc = f_3_1506_1526(1.0 / rsc)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,1531,1551);

double 
seed = 123.0
;
try {DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,1565,1570);

		for(int 
i = 0
; (DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,1557,2712) || true) && (i < nbody)
; DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,1583,1586)
,i++,DynAbs.Tracing.TraceSender.TraceExitCondition(3,1557,2712))

{DynAbs.Tracing.TraceSender.TraceEnterCondition(3,1557,2712);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,1597,1617);

Body 
p = f_3_1606_1616()
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,1622,1638);

f_3_1622_1637(			prev, p);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,1643,1652);

prev = p;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,1657,1686);

p.mass = 1.0 / (double)nbody;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,1693,1716);

seed = f_3_1700_1715(seed);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,1721,1760);

double 
t1 = f_3_1733_1759(0.0, 0.999, seed)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,1765,1803);

t1 = f_3_1770_1796(t1, (-2.0 / 3.0))- 1.0;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,1808,1839);

double 
r = 1.0 / f_3_1825_1838(t1)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,1846,1865);

double 
coeff = 4.0
;
try {DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,1878,1883);
			for(int 
k = 0
; (DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,1870,2023) || true) && (k < MathVector.NDIM)
; DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,1906,1909)
,k++,DynAbs.Tracing.TraceSender.TraceExitCondition(3,1870,2023))

{DynAbs.Tracing.TraceSender.TraceEnterCondition(3,1870,2023);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,1922,1945);

seed = f_3_1929_1944(seed);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,1951,1982);

r = f_3_1955_1981(0.0, 0.999, seed);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,1988,2017);

f_3_1988_2016(				p.pos, k, coeff * r);
}
}catch(System.Exception) { DynAbs.Tracing.TraceSender.TraceExitLoopByException(3,1,154);
 throw; }finally{DynAbs.Tracing.TraceSender.TraceExitLoop(3,1,154);
}DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,2030,2050);

f_3_2030_2049(
			cmr, p.pos);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,2057,2072);

double 
x = 0.0
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,2077,2092);

double 
y = 0.0
;
{try {
do

{DynAbs.Tracing.TraceSender.TraceEnterCondition(3,2097,2286);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,2111,2134);

seed = f_3_2118_2133(seed);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,2140,2169);

x = f_3_2144_2168(0.0, 1.0, seed);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,2175,2198);

seed = f_3_2182_2197(seed);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,2204,2233);

y = f_3_2208_2232(0.0, 0.1, seed);
DynAbs.Tracing.TraceSender.TraceExitCondition(3,2097,2286);
}
while((DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,2097,2286) || true) && (y > x * x * f_3_2258_2284(1.0 - x * x, 3.5))
);
}catch(System.Exception) { DynAbs.Tracing.TraceSender.TraceExitLoopByException(3,2097,2286);
 throw; }finally{DynAbs.Tracing.TraceSender.TraceExitLoop(3,2097,2286);
}}DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,2293,2353);

double 
v = f_3_2304_2318(2.0)* x / f_3_2325_2352(1.0 + r * r, 0.25)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,2360,2381);

double 
rad = vsc * v
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,2386,2403);

double 
rsq = 0.0
;
{try {
do

{DynAbs.Tracing.TraceSender.TraceEnterCondition(3,2408,2613);
try {DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,2430,2435);
				for(var 
k = 0
; (DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,2422,2558) || true) && (k < MathVector.NDIM)
; DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,2458,2461)
,k++,DynAbs.Tracing.TraceSender.TraceExitCondition(3,2422,2558))

{DynAbs.Tracing.TraceSender.TraceEnterCondition(3,2422,2558);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,2476,2499);

seed = f_3_2483_2498(seed);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,2506,2551);

f_3_2506_2550(					p.vel, k, f_3_2524_2549(-1.0, 1.0, seed));
}
}catch(System.Exception) { DynAbs.Tracing.TraceSender.TraceExitLoopByException(3,1,137);
 throw; }finally{DynAbs.Tracing.TraceSender.TraceExitLoop(3,1,137);
}DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,2564,2589);

rsq = f_3_2570_2588(p.vel);
DynAbs.Tracing.TraceSender.TraceExitCondition(3,2408,2613);
}
while((DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,2408,2613) || true) && (rsq > 1.0)
);
}catch(System.Exception) { DynAbs.Tracing.TraceSender.TraceExitLoopByException(3,2408,2613);
 throw; }finally{DynAbs.Tracing.TraceSender.TraceExitLoop(3,2408,2613);
}}DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,2618,2653);

double 
rsc1 = rad / f_3_2638_2652(rsq)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,2658,2682);

f_3_2658_2681(			p.vel, rsc1);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,2687,2707);

f_3_2687_2706(			cmv, p.vel);
}
}catch(System.Exception) { DynAbs.Tracing.TraceSender.TraceExitLoopByException(3,1,1156);
 throw; }finally{DynAbs.Tracing.TraceSender.TraceExitLoop(3,1,1156);
}DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,2741,2760);

f_3_2741_2759(
		// mark end of list
		prev, null);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,2848,2873);

bodyTab = f_3_2858_2872(head);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,2881,2910);

f_3_2881_2909(		
		cmr, nbody);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,2914,2943);

f_3_2914_2942(		cmv, nbody);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,2949,2961);

prev = null;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,2970,2993);

Body 
current = bodyTab
;
try {
while((DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,2997,3189) || true) && (current != null)
) 

{DynAbs.Tracing.TraceSender.TraceEnterCondition(3,2997,3189);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,3031,3061);

f_3_3031_3060(		  current.pos, cmr);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,3067,3097);

f_3_3067_3096(		  current.vel, cmv);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,3103,3129);

f_3_3103_3128(		  current, prev);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,3135,3150);

prev = current;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,3156,3184);

current = f_3_3166_3183(current);
DynAbs.Tracing.TraceSender.TraceExitCondition(3,2997,3189);
}
}catch(System.Exception) { DynAbs.Tracing.TraceSender.TraceExitLoopByException(3,2997,3189);
 throw; }finally{DynAbs.Tracing.TraceSender.TraceExitLoop(3,2997,3189);
}DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,3241,3259);

bodyTabRev = prev;
DynAbs.Tracing.TraceSender.TraceExitMethod(3,1283,3263);

MathVector
f_3_1345_1361()
{
var return_v = new MathVector();
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 1345, 1361);
return return_v;
}


MathVector
f_3_1383_1399()
{
var return_v = new MathVector();
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 1383, 1399);
return return_v;
}


Body
f_3_1418_1428()
{
var return_v = new Body();
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 1418, 1428);
return return_v;
}


double
f_3_1506_1526(double
d)
{
var return_v = Math.Sqrt( d);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 1506, 1526);
return return_v;
}


Body
f_3_1606_1616()
{
var return_v = new Body();
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 1606, 1616);
return return_v;
}


int
f_3_1622_1637(Body
this_param,Body
n)
{
this_param.setNext( n);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 1622, 1637);
return 0;
}


double
f_3_1700_1715(double
seed)
{
var return_v = BH.myRand( seed);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 1700, 1715);
return return_v;
}


double
f_3_1733_1759(double
xl,double
xh,double
r)
{
var return_v = BH.xRand( xl, xh, r);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 1733, 1759);
return return_v;
}


double
f_3_1770_1796(double
x,double
y)
{
var return_v = Math.Pow( x, y);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 1770, 1796);
return return_v;
}


double
f_3_1825_1838(double
d)
{
var return_v = Math.Sqrt( d);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 1825, 1838);
return return_v;
}


double
f_3_1929_1944(double
seed)
{
var return_v = BH.myRand( seed);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 1929, 1944);
return return_v;
}


double
f_3_1955_1981(double
xl,double
xh,double
r)
{
var return_v = BH.xRand( xl, xh, r);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 1955, 1981);
return return_v;
}


int
f_3_1988_2016(MathVector
this_param,int
i,double
v)
{
this_param.setValue( i, v);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 1988, 2016);
return 0;
}


int
f_3_2030_2049(MathVector
this_param,MathVector
u)
{
this_param.addition( u);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 2030, 2049);
return 0;
}


double
f_3_2118_2133(double
seed)
{
var return_v = BH.myRand( seed);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 2118, 2133);
return return_v;
}


double
f_3_2144_2168(double
xl,double
xh,double
r)
{
var return_v = BH.xRand( xl, xh, r);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 2144, 2168);
return return_v;
}


double
f_3_2182_2197(double
seed)
{
var return_v = BH.myRand( seed);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 2182, 2197);
return return_v;
}


double
f_3_2208_2232(double
xl,double
xh,double
r)
{
var return_v = BH.xRand( xl, xh, r);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 2208, 2232);
return return_v;
}


double
f_3_2258_2284(double
x,double
y)
{
var return_v = Math.Pow( x, y);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 2258, 2284);
return return_v;
}


double
f_3_2304_2318(double
d)
{
var return_v = Math.Sqrt( d);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 2304, 2318);
return return_v;
}


double
f_3_2325_2352(double
x,double
y)
{
var return_v = Math.Pow( x, y);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 2325, 2352);
return return_v;
}


double
f_3_2483_2498(double
seed)
{
var return_v = BH.myRand( seed);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 2483, 2498);
return return_v;
}


double
f_3_2524_2549(double
xl,double
xh,double
r)
{
var return_v = BH.xRand( xl, xh, r);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 2524, 2549);
return return_v;
}


int
f_3_2506_2550(MathVector
this_param,int
i,double
v)
{
this_param.setValue( i, v);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 2506, 2550);
return 0;
}


double
f_3_2570_2588(MathVector
this_param)
{
var return_v = this_param.dotProduct();
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 2570, 2588);
return return_v;
}


double
f_3_2638_2652(double
d)
{
var return_v = Math.Sqrt( d);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 2638, 2652);
return return_v;
}


int
f_3_2658_2681(MathVector
this_param,double
s)
{
this_param.multScalar1( s);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 2658, 2681);
return 0;
}


int
f_3_2687_2706(MathVector
this_param,MathVector
u)
{
this_param.addition( u);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 2687, 2706);
return 0;
}


int
f_3_2741_2759(Body
this_param,Body
n)
{
this_param.setNext( n);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 2741, 2759);
return 0;
}


Body
f_3_2858_2872(Body
this_param)
{
var return_v = this_param.getNext();
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 2858, 2872);
return return_v;
}


int
f_3_2881_2909(MathVector
this_param,int
s)
{
this_param.divScalar( (double)s);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 2881, 2909);
return 0;
}


int
f_3_2914_2942(MathVector
this_param,int
s)
{
this_param.divScalar( (double)s);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 2914, 2942);
return 0;
}


int
f_3_3031_3060(MathVector
this_param,MathVector
u)
{
this_param.subtraction1( u);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 3031, 3060);
return 0;
}


int
f_3_3067_3096(MathVector
this_param,MathVector
u)
{
this_param.subtraction1( u);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 3067, 3096);
return 0;
}


int
f_3_3103_3128(Body
this_param,Body
n)
{
this_param.setProcNext( n);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 3103, 3128);
return 0;
}


Body
f_3_3166_3183(Body
this_param)
{
var return_v = this_param.getNext();
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 3166, 3183);
return return_v;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(3,1283,3263);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(3,1283,3263);
}
		}

public void stepSystem(int nstep)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(3,3363,3684);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,3424,3436);

root = null;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,3442,3458);

f_3_3442_3457(this, nstep);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,3512,3538);

Body 
current = bodyTabRev
;
try {
while((DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,3542,3652) || true) && (current != null)
) 

{DynAbs.Tracing.TraceSender.TraceEnterCondition(3,3542,3652);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,3576,3609);

f_3_3576_3608(		  current, rsize, root);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,3615,3647);

current = f_3_3625_3646(current);
DynAbs.Tracing.TraceSender.TraceExitCondition(3,3542,3652);
}
}catch(System.Exception) { DynAbs.Tracing.TraceSender.TraceExitLoopByException(3,3542,3652);
 throw; }finally{DynAbs.Tracing.TraceSender.TraceExitLoop(3,3542,3652);
}DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,3658,3680);

f_3_3658_3679(bodyTabRev, nstep);
DynAbs.Tracing.TraceSender.TraceExitMethod(3,3363,3684);

int
f_3_3442_3457(BTree
this_param,int
nstep)
{
this_param.makeTree( nstep);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 3442, 3457);
return 0;
}


int
f_3_3576_3608(Body
this_param,double
rsize,Node
root)
{
this_param.hackGravity( rsize, root);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 3576, 3608);
return 0;
}


Body
f_3_3625_3646(Body
this_param)
{
var return_v = this_param.getProcNext();
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 3625, 3646);
return return_v;
}


int
f_3_3658_3679(Body
bv,int
nstep)
{
vp( bv, nstep);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 3658, 3679);
return 0;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(3,3363,3684);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(3,3363,3684);
}
		}

private void makeTree(int nstep)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(3,3802,4225);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,3842,3868);

Body 
current = bodyTabRev
;
try {
while((DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,3873,4200) || true) && (current != null)
) 

{DynAbs.Tracing.TraceSender.TraceEnterCondition(3,3873,4200);

if ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,3908,4156) || true) && (current.mass != 0.0)
) 

{DynAbs.Tracing.TraceSender.TraceEnterCondition(3,3908,4156);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,3947,3978);

f_3_3947_3977(			  current, this, nstep);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,3985,4025);

MathVector 
xqic = f_3_4003_4024(this, current.pos)
;

if ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,4032,4149) || true) && (root == null)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(3,4032,4149);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,4057,4072);

root = current;
DynAbs.Tracing.TraceSender.TraceExitCondition(3,4032,4149);
}

else

{DynAbs.Tracing.TraceSender.TraceEnterCondition(3,4032,4149);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,4091,4149);

root = f_3_4098_4148(root, current, xqic, Node.IMAX >> 1, this);
DynAbs.Tracing.TraceSender.TraceExitCondition(3,4032,4149);
}
DynAbs.Tracing.TraceSender.TraceExitCondition(3,3908,4156);
}
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,4162,4194);

current = f_3_4172_4193(current);
DynAbs.Tracing.TraceSender.TraceExitCondition(3,3873,4200);
}
}catch(System.Exception) { DynAbs.Tracing.TraceSender.TraceExitLoopByException(3,3873,4200);
 throw; }finally{DynAbs.Tracing.TraceSender.TraceExitLoop(3,3873,4200);
}DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,4205,4221);

f_3_4205_4220(	  root);
DynAbs.Tracing.TraceSender.TraceExitMethod(3,3802,4225);

int
f_3_3947_3977(Body
this_param,BTree
tree,int
nsteps)
{
this_param.expandBox( tree, nsteps);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 3947, 3977);
return 0;
}


MathVector
f_3_4003_4024(BTree
this_param,MathVector
vp)
{
var return_v = this_param.intcoord( vp);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 4003, 4024);
return return_v;
}


Cell
f_3_4098_4148(Node
this_param,Body
p,MathVector
xpic,int
l,BTree
root)
{
var return_v = this_param.loadTree( p, xpic, l, root);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 4098, 4148);
return return_v;
}


Body
f_3_4172_4193(Body
this_param)
{
var return_v = this_param.getProcNext();
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 4172, 4193);
return return_v;
}


double
f_3_4205_4220(Node
this_param)
{
var return_v = this_param.hackcofm();
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 4205, 4220);
return return_v;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(3,3802,4225);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(3,3802,4225);
}
		}

public MathVector intcoord(MathVector vp)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(3,4337,4909);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,4386,4419);

MathVector 
xp = f_3_4402_4418()
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,4425,4476);

double 
xsc = (f_3_4439_4450(vp, 0)- f_3_4453_4466(rmin, 0)) / rsize
;

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,4480,4581) || true) && (0.0 <= xsc &&(DynAbs.Tracing.TraceSender.Expression_True(3, 4483, 4506)&&xsc < 1.0))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(3,4480,4581);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,4512,4556);

f_3_4512_4555(			xp, 0, f_3_4527_4554(Node.IMAX * xsc));
DynAbs.Tracing.TraceSender.TraceExitCondition(3,4480,4581);
}

else

{DynAbs.Tracing.TraceSender.TraceEnterCondition(3,4480,4581);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,4569,4581);

return null;
DynAbs.Tracing.TraceSender.TraceExitCondition(3,4480,4581);
}
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,4587,4631);

xsc = (f_3_4594_4605(vp, 1)- f_3_4608_4621(rmin, 1)) / rsize;

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,4635,4736) || true) && (0.0 <= xsc &&(DynAbs.Tracing.TraceSender.Expression_True(3, 4638, 4661)&&xsc < 1.0))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(3,4635,4736);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,4667,4711);

f_3_4667_4710(			xp, 1, f_3_4682_4709(Node.IMAX * xsc));
DynAbs.Tracing.TraceSender.TraceExitCondition(3,4635,4736);
}

else

{DynAbs.Tracing.TraceSender.TraceEnterCondition(3,4635,4736);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,4724,4736);

return null;
DynAbs.Tracing.TraceSender.TraceExitCondition(3,4635,4736);
}
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,4742,4786);

xsc = (f_3_4749_4760(vp, 2)- f_3_4763_4776(rmin, 2)) / rsize;

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,4790,4891) || true) && (0.0 <= xsc &&(DynAbs.Tracing.TraceSender.Expression_True(3, 4793, 4816)&&xsc < 1.0))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(3,4790,4891);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,4822,4866);

f_3_4822_4865(			xp, 2, f_3_4837_4864(Node.IMAX * xsc));
DynAbs.Tracing.TraceSender.TraceExitCondition(3,4790,4891);
}

else

{DynAbs.Tracing.TraceSender.TraceEnterCondition(3,4790,4891);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,4879,4891);

return null;
DynAbs.Tracing.TraceSender.TraceExitCondition(3,4790,4891);
}
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,4895,4905);

return xp;
DynAbs.Tracing.TraceSender.TraceExitMethod(3,4337,4909);

MathVector
f_3_4402_4418()
{
var return_v = new MathVector();
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 4402, 4418);
return return_v;
}


double
f_3_4439_4450(MathVector
this_param,int
i)
{
var return_v = this_param.value( i);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 4439, 4450);
return return_v;
}


double
f_3_4453_4466(MathVector
this_param,int
i)
{
var return_v = this_param.value( i);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 4453, 4466);
return return_v;
}


double
f_3_4527_4554(double
d)
{
var return_v = Math.Floor( d);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 4527, 4554);
return return_v;
}


int
f_3_4512_4555(MathVector
this_param,int
i,double
v)
{
this_param.setValue( i, v);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 4512, 4555);
return 0;
}


double
f_3_4594_4605(MathVector
this_param,int
i)
{
var return_v = this_param.value( i);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 4594, 4605);
return return_v;
}


double
f_3_4608_4621(MathVector
this_param,int
i)
{
var return_v = this_param.value( i);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 4608, 4621);
return return_v;
}


double
f_3_4682_4709(double
d)
{
var return_v = Math.Floor( d);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 4682, 4709);
return return_v;
}


int
f_3_4667_4710(MathVector
this_param,int
i,double
v)
{
this_param.setValue( i, v);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 4667, 4710);
return 0;
}


double
f_3_4749_4760(MathVector
this_param,int
i)
{
var return_v = this_param.value( i);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 4749, 4760);
return return_v;
}


double
f_3_4763_4776(MathVector
this_param,int
i)
{
var return_v = this_param.value( i);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 4763, 4776);
return return_v;
}


double
f_3_4837_4864(double
d)
{
var return_v = Math.Floor( d);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 4837, 4864);
return return_v;
}


int
f_3_4822_4865(MathVector
this_param,int
i,double
v)
{
this_param.setValue( i, v);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 4822, 4865);
return 0;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(3,4337,4909);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(3,4337,4909);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

static private void vp(Body bv, int nstep)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterStaticMethod(3,4914,5892);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,4964,4999);

MathVector 
dacc = f_3_4982_4998()
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,5003,5038);

MathVector 
dvel = f_3_5021_5037()
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,5042,5071);

double 
dthf = 0.5 * BH.DTIME
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,5077,5095);

Body 
current = bv
;
try {
while((DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,5099,5888) || true) && (current != null)
) 

{DynAbs.Tracing.TraceSender.TraceEnterCondition(3,5099,5888);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,5133,5196);

MathVector 
acc1 = (MathVector)f_3_5163_5195(current.newAcc)
;

if ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,5202,5393) || true) && (nstep > 0)
) 

{DynAbs.Tracing.TraceSender.TraceEnterCondition(3,5202,5393);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,5229,5266);

f_3_5229_5265(			dacc, acc1, current.acc);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,5271,5300);

f_3_5271_5299(			dvel, dacc, dthf);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,5305,5332);

f_3_5305_5331(			dvel, current.vel);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,5337,5386);

current.vel = (MathVector)f_3_5363_5385(dvel);
DynAbs.Tracing.TraceSender.TraceExitCondition(3,5202,5393);
}
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,5399,5448);

current.acc = (MathVector)f_3_5425_5447(acc1);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,5454,5490);

f_3_5454_5489(		  dvel, current.acc, dthf);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,5498,5558);

MathVector 
vel1 = (MathVector)f_3_5528_5557(current.vel)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,5564,5584);

f_3_5564_5583(		  vel1, dvel);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,5590,5643);

MathVector 
dpos = (MathVector)f_3_5620_5642(vel1)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,5649,5676);

f_3_5649_5675(		  dpos, BH.DTIME);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,5682,5709);

f_3_5682_5708(		  dpos, current.pos);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,5715,5764);

current.pos = (MathVector)f_3_5741_5763(dpos);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,5770,5790);

f_3_5770_5789(		  vel1, dvel);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,5796,5845);

current.vel = (MathVector)f_3_5822_5844(vel1);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,5851,5883);

current = f_3_5861_5882(current);
DynAbs.Tracing.TraceSender.TraceExitCondition(3,5099,5888);
}
}catch(System.Exception) { DynAbs.Tracing.TraceSender.TraceExitLoopByException(3,5099,5888);
 throw; }finally{DynAbs.Tracing.TraceSender.TraceExitLoop(3,5099,5888);
}DynAbs.Tracing.TraceSender.TraceExitStaticMethod(3,4914,5892);

MathVector
f_3_4982_4998()
{
var return_v = new MathVector();
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 4982, 4998);
return return_v;
}


MathVector
f_3_5021_5037()
{
var return_v = new MathVector();
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 5021, 5037);
return return_v;
}


MathVector
f_3_5163_5195(MathVector
this_param)
{
var return_v = this_param.cloneMathVector();
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 5163, 5195);
return return_v;
}


int
f_3_5229_5265(MathVector
this_param,MathVector
u,MathVector
v)
{
this_param.subtraction2( u, v);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 5229, 5265);
return 0;
}


int
f_3_5271_5299(MathVector
this_param,MathVector
u,double
s)
{
this_param.multScalar2( u, s);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 5271, 5299);
return 0;
}


int
f_3_5305_5331(MathVector
this_param,MathVector
u)
{
this_param.addition( u);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 5305, 5331);
return 0;
}


MathVector
f_3_5363_5385(MathVector
this_param)
{
var return_v = this_param.cloneMathVector();
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 5363, 5385);
return return_v;
}


MathVector
f_3_5425_5447(MathVector
this_param)
{
var return_v = this_param.cloneMathVector();
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 5425, 5447);
return return_v;
}


int
f_3_5454_5489(MathVector
this_param,MathVector
u,double
s)
{
this_param.multScalar2( u, s);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 5454, 5489);
return 0;
}


MathVector
f_3_5528_5557(MathVector
this_param)
{
var return_v = this_param.cloneMathVector();
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 5528, 5557);
return return_v;
}


int
f_3_5564_5583(MathVector
this_param,MathVector
u)
{
this_param.addition( u);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 5564, 5583);
return 0;
}


MathVector
f_3_5620_5642(MathVector
this_param)
{
var return_v = this_param.cloneMathVector();
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 5620, 5642);
return return_v;
}


int
f_3_5649_5675(MathVector
this_param,double
s)
{
this_param.multScalar1( s);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 5649, 5675);
return 0;
}


int
f_3_5682_5708(MathVector
this_param,MathVector
u)
{
this_param.addition( u);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 5682, 5708);
return 0;
}


MathVector
f_3_5741_5763(MathVector
this_param)
{
var return_v = this_param.cloneMathVector();
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 5741, 5763);
return return_v;
}


int
f_3_5770_5789(MathVector
this_param,MathVector
u)
{
this_param.addition( u);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 5770, 5789);
return 0;
}


MathVector
f_3_5822_5844(MathVector
this_param)
{
var return_v = this_param.cloneMathVector();
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 5822, 5844);
return return_v;
}


Body
f_3_5861_5882(Body
this_param)
{
var return_v = this_param.getProcNext();
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 5861, 5882);
return return_v;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(3,4914,5892);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(3,4914,5892);
}
		}

static BTree()
{
DynAbs.Tracing.TraceSender.TraceEnterStaticConstructor(3,183,5895);
DynAbs.Tracing.TraceSender.TraceExitStaticConstructor(3,183,5895);

DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(3,183,5895);
}

		int ___ignore_me___=DynAbs.Tracing.TraceSender.TraceBeforeConstructor(3,183,5895);

static MathVector
f_3_636_652()
{
var return_v = new MathVector();
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 636, 652);
return return_v;
}


static int
f_3_740_762(MathVector
this_param,int
i,double
v)
{
this_param.setValue( i, v);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 740, 762);
return 0;
}


static int
f_3_767_789(MathVector
this_param,int
i,double
v)
{
this_param.setValue( i, v);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 767, 789);
return 0;
}


static int
f_3_794_816(MathVector
this_param,int
i,double
v)
{
this_param.setValue( i, v);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 794, 816);
return 0;
}

}
