using System;
public class Body : Node
{
public MathVector vel;

public MathVector acc;

public MathVector newAcc;

public double phi;

private Body next;

private Body procNext;

public Body() : base()
		{
			try
{DynAbs.Tracing.TraceSender.TraceEnterConstructor(2,310,498);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,142,145);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,167,170);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,192,198);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,216,219);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,238,242);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,259,267);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,340,368);

this.vel = f_2_351_367();
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,372,400);

this.acc = f_2_383_399();
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,404,435);

this.newAcc = f_2_418_434();
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,439,454);

this.phi = 0.0;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,458,474);

next     = null;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,478,494);

procNext = null;
DynAbs.Tracing.TraceSender.TraceExitConstructor(2,310,498);
}catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(2,310,498);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(2,310,498);
}
		}

public void setNext(Body n)
		{
			try
	  {
DynAbs.Tracing.TraceSender.TraceEnterMethod(2,582,634);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,619,628);

next = n;
DynAbs.Tracing.TraceSender.TraceExitMethod(2,582,634);
	  }
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(2,582,634);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(2,582,634);
}
		}

public Body getNext()
		{
			try
	  {
DynAbs.Tracing.TraceSender.TraceEnterMethod(2,727,776);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,758,770);

return next;
DynAbs.Tracing.TraceSender.TraceExitMethod(2,727,776);
	  }
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(2,727,776);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(2,727,776);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

public void setProcNext(Body n)
		{
			try
	  {
DynAbs.Tracing.TraceSender.TraceEnterMethod(2,875,935);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,916,929);

procNext = n;
DynAbs.Tracing.TraceSender.TraceExitMethod(2,875,935);
	  }
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(2,875,935);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(2,875,935);
}
		}

public Body getProcNext()
		{
			try
	  {
DynAbs.Tracing.TraceSender.TraceEnterMethod(2,1023,1080);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1058,1074);

return procNext;
DynAbs.Tracing.TraceSender.TraceExitMethod(2,1023,1080);
	  }
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(2,1023,1080);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(2,1023,1080);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

public void expandBox(BTree tree, int nsteps)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(2,1243,2009);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1296,1331);

MathVector 
rmid = f_2_1314_1330()
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1337,1363);

bool 
inbox = f_2_1350_1362(this, tree)
;
try {
while((DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1367,2005) || true) && (!inbox)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,1367,2005);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1390,1416);

double 
rsize = tree.rsize
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1421,1460);

f_2_1421_1459(			rmid, tree.rmin, 0.5 * rsize);
try {DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1475,1480);

			for(int 
k = 0
; (DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1467,1654) || true) && (k < MathVector.NDIM)
; DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1503,1506)
,k++,DynAbs.Tracing.TraceSender.TraceExitCondition(2,1467,1654))

{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,1467,1654);

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1519,1648) || true) && (f_2_1522_1534(pos, k)< f_2_1537_1550(rmid, k))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,1519,1648);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1565,1598);

double 
rmin = f_2_1579_1597(tree.rmin, k)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1605,1641);

f_2_1605_1640(					tree.rmin, k, rmin - rsize);
DynAbs.Tracing.TraceSender.TraceExitCondition(2,1519,1648);
}
}
}catch(System.Exception) { DynAbs.Tracing.TraceSender.TraceExitLoopByException(2,1,188);
 throw; }finally{DynAbs.Tracing.TraceSender.TraceExitLoop(2,1,188);
}DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1659,1684);

tree.rsize = 2.0 * rsize;

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1689,2000) || true) && (tree.root != null)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,1689,2000);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1722,1758);

MathVector 
ic = f_2_1738_1757(tree, rmid)
;

if ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1764,1833) || true) && (ic == null)
) 

{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,1764,1833);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1787,1833);

throw f_2_1793_1832("Value is out of bounds");
DynAbs.Tracing.TraceSender.TraceExitCondition(2,1764,1833);
}
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1839,1884);

int 
k = f_2_1847_1883(ic, Node.IMAX >> 1)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1890,1913);

Cell 
newt = f_2_1902_1912()
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1919,1944);

newt.subp[k] = tree.root;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1950,1967);

tree.root = newt;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1973,1994);

inbox = f_2_1981_1993(this, tree);
DynAbs.Tracing.TraceSender.TraceExitCondition(2,1689,2000);
}
DynAbs.Tracing.TraceSender.TraceExitCondition(2,1367,2005);
}
}catch(System.Exception) { DynAbs.Tracing.TraceSender.TraceExitLoopByException(2,1367,2005);
 throw; }finally{DynAbs.Tracing.TraceSender.TraceExitLoop(2,1367,2005);
}DynAbs.Tracing.TraceSender.TraceExitMethod(2,1243,2009);

MathVector
f_2_1314_1330()
{
var return_v = new MathVector();
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 1314, 1330);
return return_v;
}


bool
f_2_1350_1362(Body
this_param,BTree
tree)
{
var return_v = this_param.icTest( tree);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 1350, 1362);
return return_v;
}


int
f_2_1421_1459(MathVector
this_param,MathVector
u,double
s)
{
this_param.addScalar( u, s);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 1421, 1459);
return 0;
}


double
f_2_1522_1534(MathVector
this_param,int
i)
{
var return_v = this_param.value( i);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 1522, 1534);
return return_v;
}


double
f_2_1537_1550(MathVector
this_param,int
i)
{
var return_v = this_param.value( i);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 1537, 1550);
return return_v;
}


double
f_2_1579_1597(MathVector
this_param,int
i)
{
var return_v = this_param.value( i);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 1579, 1597);
return return_v;
}


int
f_2_1605_1640(MathVector
this_param,int
i,double
v)
{
this_param.setValue( i, v);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 1605, 1640);
return 0;
}


MathVector
f_2_1738_1757(BTree
this_param,MathVector
vp)
{
var return_v = this_param.intcoord( vp);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 1738, 1757);
return return_v;
}


System.Exception
f_2_1793_1832(string
message)
{
var return_v = new System.Exception( message);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 1793, 1832);
return return_v;
}


int
f_2_1847_1883(MathVector
ic,int
l)
{
var return_v = Node.oldSubindex( ic, l);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 1847, 1883);
return return_v;
}


Cell
f_2_1902_1912()
{
var return_v = new Cell();
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 1902, 1912);
return return_v;
}


bool
f_2_1981_1993(Body
this_param,BTree
tree)
{
var return_v = this_param.icTest( tree);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 1981, 1993);
return return_v;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(2,1243,2009);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(2,1243,2009);
}
		}

public bool icTest(BTree tree)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(2,2114,2649);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2152,2179);

double 
pos0 = f_2_2166_2178(pos, 0)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2183,2210);

double 
pos1 = f_2_2197_2209(pos, 1)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2214,2241);

double 
pos2 = f_2_2228_2240(pos, 2)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2281,2300);

bool 
result = true
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2306,2360);

double 
xsc = (pos0 - f_2_2327_2345(tree.rmin, 0)) / tree.rsize
;

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2364,2413) || true) && (!(0.0 < xsc &&(DynAbs.Tracing.TraceSender.Expression_True(2, 2369, 2391)&&xsc < 1.0)))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,2364,2413);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2398,2413);

result = false;
DynAbs.Tracing.TraceSender.TraceExitCondition(2,2364,2413);
}
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2419,2466);

xsc = (pos1 - f_2_2433_2451(tree.rmin, 1)) / tree.rsize;

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2470,2519) || true) && (!(0.0 < xsc &&(DynAbs.Tracing.TraceSender.Expression_True(2, 2475, 2497)&&xsc < 1.0)))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,2470,2519);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2504,2519);

result = false;
DynAbs.Tracing.TraceSender.TraceExitCondition(2,2470,2519);
}
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2525,2572);

xsc = (pos2 - f_2_2539_2557(tree.rmin, 2)) / tree.rsize;

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2576,2625) || true) && (!(0.0 < xsc &&(DynAbs.Tracing.TraceSender.Expression_True(2, 2581, 2603)&&xsc < 1.0)))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,2576,2625);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2610,2625);

result = false;
DynAbs.Tracing.TraceSender.TraceExitCondition(2,2576,2625);
}
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2631,2645);

return result;
DynAbs.Tracing.TraceSender.TraceExitMethod(2,2114,2649);

double
f_2_2166_2178(MathVector
this_param,int
i)
{
var return_v = this_param.value( i);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 2166, 2178);
return return_v;
}


double
f_2_2197_2209(MathVector
this_param,int
i)
{
var return_v = this_param.value( i);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 2197, 2209);
return return_v;
}


double
f_2_2228_2240(MathVector
this_param,int
i)
{
var return_v = this_param.value( i);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 2228, 2240);
return return_v;
}


double
f_2_2327_2345(MathVector
this_param,int
i)
{
var return_v = this_param.value( i);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 2327, 2345);
return return_v;
}


double
f_2_2433_2451(MathVector
this_param,int
i)
{
var return_v = this_param.value( i);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 2433, 2451);
return return_v;
}


double
f_2_2539_2557(MathVector
this_param,int
i)
{
var return_v = this_param.value( i);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 2539, 2557);
return return_v;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(2,2114,2649);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(2,2114,2649);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

public override Cell loadTree(Body p, MathVector xpic, int l, BTree tree)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(2,2954,3402);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,3055,3080);

Cell 
retval = f_2_3069_3079()
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,3084,3111);

int 
si = f_2_3093_3110(this, tree, l)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,3155,3178);

retval.subp[si] = this;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,3210,3241);

si = f_2_3215_3240(xpic, l);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,3245,3271);

Node 
rt = retval.subp[si]
;

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,3275,3380) || true) && (rt != null)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,3275,3380);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,3294,3347);

retval.subp[si] = f_2_3312_3346(rt, p, xpic, l >> 1, tree);
DynAbs.Tracing.TraceSender.TraceExitCondition(2,3275,3380);
}

else

{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,3275,3380);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,3360,3380);

retval.subp[si] = p;
DynAbs.Tracing.TraceSender.TraceExitCondition(2,3275,3380);
}
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,3384,3398);

return retval;
DynAbs.Tracing.TraceSender.TraceExitMethod(2,2954,3402);

Cell
f_2_3069_3079()
{
var return_v = new Cell();
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 3069, 3079);
return return_v;
}


int
f_2_3093_3110(Body
this_param,BTree
tree,int
l)
{
var return_v = this_param.subindex( tree, l);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 3093, 3110);
return return_v;
}


int
f_2_3215_3240(MathVector
ic,int
l)
{
var return_v = Node.oldSubindex( ic, l);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 3215, 3240);
return return_v;
}


Cell
f_2_3312_3346(Node
this_param,Body
p,MathVector
xpic,int
l,BTree
root)
{
var return_v = this_param.loadTree( p, xpic, l, root);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 3312, 3346);
return return_v;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(2,2954,3402);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(2,2954,3402);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

public override double hackcofm()
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(2,3505,3562);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,3546,3558);

return mass;
DynAbs.Tracing.TraceSender.TraceExitMethod(2,3505,3562);
	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(2,3505,3562);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(2,3505,3562);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

public int subindex(BTree tree, int l)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(2,3698,4311);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,3744,3777);

MathVector 
xp = f_2_3760_3776()
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,3783,3845);

double 
xsc = (f_2_3797_3809(pos, 0)- f_2_3812_3830(tree.rmin, 0)) / tree.rsize
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,3849,3888);

f_2_3849_3887(		xp, 0, f_2_3864_3886(IMAX * xsc));
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,3894,3949);

xsc = (f_2_3901_3913(pos, 1)- f_2_3916_3934(tree.rmin, 1)) / tree.rsize;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,3953,3992);

f_2_3953_3991(		xp, 1, f_2_3968_3990(IMAX * xsc));
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,3998,4053);

xsc = (f_2_4005_4017(pos, 2)- f_2_4020_4038(tree.rmin, 2)) / tree.rsize;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,4057,4096);

f_2_4057_4095(		xp, 2, f_2_4072_4094(IMAX * xsc));
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,4102,4112);

int 
i = 0
;
try {DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,4124,4129);
		for(int 
k = 0
; (DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,4116,4294) || true) && (k < MathVector.NDIM)
; DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,4152,4155)
,k++,DynAbs.Tracing.TraceSender.TraceExitCondition(2,4116,4294))

{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,4116,4294);

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,4166,4289) || true) && (((int)f_2_4175_4186(xp, k)& l) != 0)
) //This used val & 1 != 0 so if there is a problem look here

{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,4166,4289);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,4263,4289);

i += Cell.NSUB >> (k + 1);
DynAbs.Tracing.TraceSender.TraceExitCondition(2,4166,4289);
}
}
}catch(System.Exception) { DynAbs.Tracing.TraceSender.TraceExitLoopByException(2,1,179);
 throw; }finally{DynAbs.Tracing.TraceSender.TraceExitLoop(2,1,179);
}DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,4298,4307);

return i;
DynAbs.Tracing.TraceSender.TraceExitMethod(2,3698,4311);

MathVector
f_2_3760_3776()
{
var return_v = new MathVector();
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 3760, 3776);
return return_v;
}


double
f_2_3797_3809(MathVector
this_param,int
i)
{
var return_v = this_param.value( i);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 3797, 3809);
return return_v;
}


double
f_2_3812_3830(MathVector
this_param,int
i)
{
var return_v = this_param.value( i);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 3812, 3830);
return return_v;
}


double
f_2_3864_3886(double
d)
{
var return_v = Math.Floor( d);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 3864, 3886);
return return_v;
}


int
f_2_3849_3887(MathVector
this_param,int
i,double
v)
{
this_param.setValue( i, v);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 3849, 3887);
return 0;
}


double
f_2_3901_3913(MathVector
this_param,int
i)
{
var return_v = this_param.value( i);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 3901, 3913);
return return_v;
}


double
f_2_3916_3934(MathVector
this_param,int
i)
{
var return_v = this_param.value( i);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 3916, 3934);
return return_v;
}


double
f_2_3968_3990(double
d)
{
var return_v = Math.Floor( d);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 3968, 3990);
return return_v;
}


int
f_2_3953_3991(MathVector
this_param,int
i,double
v)
{
this_param.setValue( i, v);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 3953, 3991);
return 0;
}


double
f_2_4005_4017(MathVector
this_param,int
i)
{
var return_v = this_param.value( i);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 4005, 4017);
return return_v;
}


double
f_2_4020_4038(MathVector
this_param,int
i)
{
var return_v = this_param.value( i);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 4020, 4038);
return return_v;
}


double
f_2_4072_4094(double
d)
{
var return_v = Math.Floor( d);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 4072, 4094);
return return_v;
}


int
f_2_4057_4095(MathVector
this_param,int
i,double
v)
{
this_param.setValue( i, v);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 4057, 4095);
return 0;
}


double
f_2_4175_4186(MathVector
this_param,int
i)
{
var return_v = this_param.value( i);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 4175, 4186);
return return_v;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(2,3698,4311);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(2,3698,4311);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

public void hackGravity(double rsize, Node root)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(2,4497,4713);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,4553,4593);

MathVector 
pos0 = f_2_4571_4592(pos)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,4599,4625);

HG 
hg = f_2_4607_4624(this, pos)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,4629,4670);

hg = f_2_4634_4669(root, rsize * rsize, hg);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,4674,4688);

phi = hg.phi0;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,4692,4709);

newAcc = hg.acc0;
DynAbs.Tracing.TraceSender.TraceExitMethod(2,4497,4713);

MathVector
f_2_4571_4592(MathVector
this_param)
{
var return_v = this_param.cloneMathVector();
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 4571, 4592);
return return_v;
}


HG
f_2_4607_4624(Body
b,MathVector
p)
{
var return_v = new HG( b, p);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 4607, 4624);
return return_v;
}


HG
f_2_4634_4669(Node
this_param,double
dsq,HG
hg)
{
var return_v = this_param.walkSubTree( dsq, hg);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 4634, 4669);
return return_v;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(2,4497,4713);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(2,4497,4713);
}
		}

public override HG walkSubTree(double dsq, HG hg)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(2,4786,4903);

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,4843,4885) || true) && (this != hg.pskip)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,4843,4885);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,4868,4885);

hg = f_2_4873_4884(this, hg);
DynAbs.Tracing.TraceSender.TraceExitCondition(2,4843,4885);
}
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,4889,4899);

return hg;
DynAbs.Tracing.TraceSender.TraceExitMethod(2,4786,4903);

HG
f_2_4873_4884(Body
this_param,HG
hg)
{
var return_v = this_param.gravSub( hg);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 4873, 4884);
return return_v;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(2,4786,4903);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(2,4786,4903);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

public override string ToString()
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(2,5021,5099);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,5062,5095);

return "Body " + DynAbs.Tracing.TraceSender.TraceInvocationWrapper(() => base.ToString(),2,5079,5094);
DynAbs.Tracing.TraceSender.TraceExitMethod(2,5021,5099);
	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(2,5021,5099);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(2,5021,5099);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

static Body()
{
DynAbs.Tracing.TraceSender.TraceEnterStaticConstructor(2,94,5102);
DynAbs.Tracing.TraceSender.TraceExitStaticConstructor(2,94,5102);

DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(2,94,5102);
}

		int ___ignore_me___=DynAbs.Tracing.TraceSender.TraceBeforeConstructor(2,94,5102);

static MathVector
f_2_351_367()
{
var return_v = new MathVector();
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 351, 367);
return return_v;
}


static MathVector
f_2_383_399()
{
var return_v = new MathVector();
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 383, 399);
return return_v;
}


static MathVector
f_2_418_434()
{
var return_v = new MathVector();
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 418, 434);
return return_v;
}

}
