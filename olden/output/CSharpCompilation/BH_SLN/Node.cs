using System;
public abstract class Node
{
public double mass;

public MathVector pos;

public static int IMAX ;

public static double EPS ;

public Node()
		{
			try
{DynAbs.Tracing.TraceSender.TraceEnterConstructor(7,439,502);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(7,186,190);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(7,248,251);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(7,460,471);

mass = 0.0;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(7,475,498);

pos = f_7_481_497();
DynAbs.Tracing.TraceSender.TraceExitConstructor(7,439,502);
}catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(7,439,502);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(7,439,502);
}
		}

public abstract Cell loadTree(Body p, MathVector xpic, int l, BTree root);

public abstract double hackcofm();

public abstract HG walkSubTree(double dsq, HG hg);

public static int oldSubindex(MathVector ic, int l)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterStaticMethod(7,676,884);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(7,735,745);

int 
i = 0
;
try {DynAbs.Tracing.TraceSender.TraceSimpleStatement(7,757,762);
		for(int 
k = 0
; (DynAbs.Tracing.TraceSender.TraceSimpleStatement(7,749,867) || true) && (k < MathVector.NDIM)
; DynAbs.Tracing.TraceSender.TraceSimpleStatement(7,785,788)
,k++,DynAbs.Tracing.TraceSender.TraceExitCondition(7,749,867))

{DynAbs.Tracing.TraceSender.TraceEnterCondition(7,749,867);

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(7,799,862) || true) && (((int)f_7_808_819(ic, k)& l) != 0)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(7,799,862);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(7,836,862);

i += Cell.NSUB >> (k + 1);
DynAbs.Tracing.TraceSender.TraceExitCondition(7,799,862);
}
}
}catch(System.Exception) { DynAbs.Tracing.TraceSender.TraceExitLoopByException(7,1,119);
 throw; }finally{DynAbs.Tracing.TraceSender.TraceExitLoop(7,1,119);
}DynAbs.Tracing.TraceSender.TraceSimpleStatement(7,871,880);

return i;
DynAbs.Tracing.TraceSender.TraceExitStaticMethod(7,676,884);

double
f_7_808_819(MathVector
this_param,int
i)
{
var return_v = this_param.value( i);
DynAbs.Tracing.TraceSender.TraceEndInvocation(7, 808, 819);
return return_v;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(7,676,884);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(7,676,884);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

public override string ToString()
		{
			try
	  {
DynAbs.Tracing.TraceSender.TraceEnterMethod(7,1006,1081);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(7,1049,1075);

return DynAbs.Tracing.TraceSender.TraceInvocationWrapper(() => (mass).ToString(),7,1056,1060)+ " : " + DynAbs.Tracing.TraceSender.TraceInvocationWrapper(() => (pos).ToString(),7,1071,1074);
DynAbs.Tracing.TraceSender.TraceExitMethod(7,1006,1081);
	  }
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(7,1006,1081);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(7,1006,1081);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

public HG gravSub(HG hg)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(7,1153,1488);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(7,1185,1218);

MathVector 
dr = f_7_1201_1217()
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(7,1222,1252);

f_7_1222_1251(		dr, pos, hg.pos0);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(7,1258,1302);

double 
drsq = f_7_1272_1287(dr)+ (EPS * EPS)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(7,1306,1337);

double 
drabs = f_7_1321_1336(drsq)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(7,1343,1370);

double 
phii = mass / drabs
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(7,1374,1390);

hg.phi0 -= phii;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(7,1394,1420);

double 
mor3 = phii / drsq
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(7,1424,1445);

f_7_1424_1444(		dr, mor3);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(7,1449,1470);

f_7_1449_1469(		hg.acc0, dr);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(7,1474,1484);

return hg;
DynAbs.Tracing.TraceSender.TraceExitMethod(7,1153,1488);

MathVector
f_7_1201_1217()
{
var return_v = new MathVector();
DynAbs.Tracing.TraceSender.TraceEndInvocation(7, 1201, 1217);
return return_v;
}


int
f_7_1222_1251(MathVector
this_param,MathVector
u,MathVector
v)
{
this_param.subtraction2( u, v);
DynAbs.Tracing.TraceSender.TraceEndInvocation(7, 1222, 1251);
return 0;
}


double
f_7_1272_1287(MathVector
this_param)
{
var return_v = this_param.dotProduct();
DynAbs.Tracing.TraceSender.TraceEndInvocation(7, 1272, 1287);
return return_v;
}


double
f_7_1321_1336(double
d)
{
var return_v = Math.Sqrt( d);
DynAbs.Tracing.TraceSender.TraceEndInvocation(7, 1321, 1336);
return return_v;
}


int
f_7_1424_1444(MathVector
this_param,double
s)
{
this_param.multScalar1( s);
DynAbs.Tracing.TraceSender.TraceEndInvocation(7, 1424, 1444);
return 0;
}


int
f_7_1449_1469(MathVector
this_param,MathVector
u)
{
this_param.addition( u);
DynAbs.Tracing.TraceSender.TraceEndInvocation(7, 1449, 1469);
return 0;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(7,1153,1488);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(7,1153,1488);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

static Node()
{
DynAbs.Tracing.TraceSender.TraceEnterStaticConstructor(7,107,1491);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(7,305,322);
IMAX = 1073741824;DynAbs.Tracing.TraceSender.TraceSimpleStatement(7,384,394);
EPS = 0.05;DynAbs.Tracing.TraceSender.TraceExitStaticConstructor(7,107,1491);

DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(7,107,1491);
}

		int ___ignore_me___=DynAbs.Tracing.TraceSender.TraceBeforeConstructor(7,107,1491);

static MathVector
f_7_481_497()
{
var return_v = new MathVector();
DynAbs.Tracing.TraceSender.TraceEndInvocation(7, 481, 497);
return return_v;
}

}
