using System;
using System.Collections.Generic;
public class Cell : Node
{
public static int NSUB ;

public Node[] subp;

Cell   next;

public Cell() : base()
		{
			try
{DynAbs.Tracing.TraceSender.TraceEnterConstructor(4,361,438);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(4,336,340);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(4,351,355);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(4,391,418);

this.subp = new Node[NSUB];
DynAbs.Tracing.TraceSender.TraceSimpleStatement(4,422,434);

next = null;
DynAbs.Tracing.TraceSender.TraceExitConstructor(4,361,438);
}catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(4,361,438);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(4,361,438);
}
		}

public override Cell loadTree(Body p, MathVector xpic, int l, BTree tree)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(4,719,999);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(4,826,861);

int 
si = f_4_835_860(xpic, l)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(4,865,884);

Node 
rt = subp[si]
;

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(4,888,979) || true) && (rt != null)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(4,888,979);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(4,907,953);

subp[si] = f_4_918_952(rt, p, xpic, l >> 1, tree);
DynAbs.Tracing.TraceSender.TraceExitCondition(4,888,979);
}

else

{DynAbs.Tracing.TraceSender.TraceEnterCondition(4,888,979);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(4,966,979);

subp[si] = p;
DynAbs.Tracing.TraceSender.TraceExitCondition(4,888,979);
}
DynAbs.Tracing.TraceSender.TraceSimpleStatement(4,983,995);

return this;
DynAbs.Tracing.TraceSender.TraceExitMethod(4,719,999);

int
f_4_835_860(MathVector
ic,int
l)
{
var return_v = Node.oldSubindex( ic, l);
DynAbs.Tracing.TraceSender.TraceEndInvocation(4, 835, 860);
return return_v;
}


Cell
f_4_918_952(Node
this_param,Body
p,MathVector
xpic,int
l,BTree
root)
{
var return_v = this_param.loadTree( p, xpic, l, root);
DynAbs.Tracing.TraceSender.TraceEndInvocation(4, 918, 952);
return return_v;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(4,719,999);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(4,719,999);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

public override double hackcofm()
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(4,1102,1526);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(4,1143,1159);

double 
mq = 0.0
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(4,1163,1200);

MathVector 
tmpPos = f_4_1183_1199()
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(4,1204,1239);

MathVector 
tmpv = f_4_1222_1238()
;
try {DynAbs.Tracing.TraceSender.TraceSimpleStatement(4,1251,1256);
		for(int 
i = 0
; (DynAbs.Tracing.TraceSender.TraceSimpleStatement(4,1243,1451) || true) && (i < NSUB)
; DynAbs.Tracing.TraceSender.TraceSimpleStatement(4,1268,1271)
,i++,DynAbs.Tracing.TraceSender.TraceExitCondition(4,1243,1451))

{DynAbs.Tracing.TraceSender.TraceEnterCondition(4,1243,1451);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(4,1282,1304);

Node 
r = this.subp[i]
;

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(4,1309,1446) || true) && (r != null)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(4,1309,1446);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(4,1334,1359);

double 
mr = f_4_1346_1358(r)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(4,1365,1378);

mq = mr + mq;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(4,1384,1412);

f_4_1384_1411(				tmpv, r.pos, mr);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(4,1418,1440);

f_4_1418_1439(				tmpPos, tmpv);
DynAbs.Tracing.TraceSender.TraceExitCondition(4,1309,1446);
}
}
}catch(System.Exception) { DynAbs.Tracing.TraceSender.TraceExitLoopByException(4,1,209);
 throw; }finally{DynAbs.Tracing.TraceSender.TraceExitLoop(4,1,209);
}DynAbs.Tracing.TraceSender.TraceSimpleStatement(4,1455,1465);

mass = mq;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(4,1469,1482);

pos = tmpPos;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(4,1486,1506);

f_4_1486_1505(		pos, mass);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(4,1512,1522);

return mq;
DynAbs.Tracing.TraceSender.TraceExitMethod(4,1102,1526);

MathVector
f_4_1183_1199()
{
var return_v = new MathVector();
DynAbs.Tracing.TraceSender.TraceEndInvocation(4, 1183, 1199);
return return_v;
}


MathVector
f_4_1222_1238()
{
var return_v = new MathVector();
DynAbs.Tracing.TraceSender.TraceEndInvocation(4, 1222, 1238);
return return_v;
}


double
f_4_1346_1358(Node
this_param)
{
var return_v = this_param.hackcofm();
DynAbs.Tracing.TraceSender.TraceEndInvocation(4, 1346, 1358);
return return_v;
}


int
f_4_1384_1411(MathVector
this_param,MathVector
u,double
s)
{
this_param.multScalar2( u, s);
DynAbs.Tracing.TraceSender.TraceEndInvocation(4, 1384, 1411);
return 0;
}


int
f_4_1418_1439(MathVector
this_param,MathVector
u)
{
this_param.addition( u);
DynAbs.Tracing.TraceSender.TraceEndInvocation(4, 1418, 1439);
return 0;
}


int
f_4_1486_1505(MathVector
this_param,double
s)
{
this_param.divScalar( s);
DynAbs.Tracing.TraceSender.TraceEndInvocation(4, 1486, 1505);
return 0;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(4,1102,1526);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(4,1102,1526);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

public override HG walkSubTree(double dsq, HG hg)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(4,1599,1873);

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(4,1656,1855) || true) && (f_4_1659_1675(this, dsq, hg))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(4,1656,1855);
try {DynAbs.Tracing.TraceSender.TraceSimpleStatement(4,1694,1699);
			for(int 
k = 0
; (DynAbs.Tracing.TraceSender.TraceSimpleStatement(4,1686,1820) || true) && (k < Cell.NSUB)
; DynAbs.Tracing.TraceSender.TraceSimpleStatement(4,1716,1719)
,k++,DynAbs.Tracing.TraceSender.TraceExitCondition(4,1686,1820))

{DynAbs.Tracing.TraceSender.TraceEnterCondition(4,1686,1820);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(4,1732,1754);

Node 
r = this.subp[k]
;

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(4,1760,1814) || true) && (r != null)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(4,1760,1814);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(4,1780,1814);

hg = f_4_1785_1813(r, dsq / 4.0, hg);
DynAbs.Tracing.TraceSender.TraceExitCondition(4,1760,1814);
}
}
}catch(System.Exception) { DynAbs.Tracing.TraceSender.TraceExitLoopByException(4,1,135);
 throw; }finally{DynAbs.Tracing.TraceSender.TraceExitLoop(4,1,135);
}DynAbs.Tracing.TraceSender.TraceExitCondition(4,1656,1855);
}

else

{DynAbs.Tracing.TraceSender.TraceEnterCondition(4,1656,1855);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(4,1838,1855);

hg = f_4_1843_1854(this, hg);
DynAbs.Tracing.TraceSender.TraceExitCondition(4,1656,1855);
}
DynAbs.Tracing.TraceSender.TraceSimpleStatement(4,1859,1869);

return hg;
DynAbs.Tracing.TraceSender.TraceExitMethod(4,1599,1873);

bool
f_4_1659_1675(Cell
this_param,double
dsq,HG
hg)
{
var return_v = this_param.subdivp( dsq, hg);
DynAbs.Tracing.TraceSender.TraceEndInvocation(4, 1659, 1675);
return return_v;
}


HG
f_4_1785_1813(Node
this_param,double
dsq,HG
hg)
{
var return_v = this_param.walkSubTree( dsq, hg);
DynAbs.Tracing.TraceSender.TraceEndInvocation(4, 1785, 1813);
return return_v;
}


HG
f_4_1843_1854(Cell
this_param,HG
hg)
{
var return_v = this_param.gravSub( hg);
DynAbs.Tracing.TraceSender.TraceEndInvocation(4, 1843, 1854);
return return_v;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(4,1599,1873);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(4,1599,1873);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

public bool subdivp(double dsq, HG hg)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(4,1997,2236);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(4,2043,2076);

MathVector 
dr = f_4_2059_2075()
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(4,2080,2110);

f_4_2080_2109(		dr, pos, hg.pos0);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(4,2114,2144);

double 
drsq = f_4_2128_2143(dr)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(4,2212,2232);

return (drsq < dsq);
DynAbs.Tracing.TraceSender.TraceExitMethod(4,1997,2236);

MathVector
f_4_2059_2075()
{
var return_v = new MathVector();
DynAbs.Tracing.TraceSender.TraceEndInvocation(4, 2059, 2075);
return return_v;
}


int
f_4_2080_2109(MathVector
this_param,MathVector
u,MathVector
v)
{
this_param.subtraction2( u, v);
DynAbs.Tracing.TraceSender.TraceEndInvocation(4, 2080, 2109);
return 0;
}


double
f_4_2128_2143(MathVector
this_param)
{
var return_v = this_param.dotProduct();
DynAbs.Tracing.TraceSender.TraceEndInvocation(4, 2128, 2143);
return return_v;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(4,1997,2236);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(4,1997,2236);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

public override string ToString()
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(4,2354,2432);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(4,2395,2428);

return "Cell " + DynAbs.Tracing.TraceSender.TraceInvocationWrapper(() => base.ToString(),4,2412,2427);
DynAbs.Tracing.TraceSender.TraceExitMethod(4,2354,2432);
	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(4,2354,2432);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(4,2354,2432);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

static Cell()
{
DynAbs.Tracing.TraceSender.TraceEnterStaticConstructor(4,117,2435);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(4,188,196);
NSUB = 8;DynAbs.Tracing.TraceSender.TraceExitStaticConstructor(4,117,2435);

DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(4,117,2435);
}

		int ___ignore_me___=DynAbs.Tracing.TraceSender.TraceBeforeConstructor(4,117,2435);
}
