public class Leaf
{
private Demand D;

private double pi_R;

private double pi_I;

public Leaf()
		{
			try
{DynAbs.Tracing.TraceSender.TraceEnterConstructor(4,392,442);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(4,248,249);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(4,311,315);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(4,382,386);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(4,413,438);

D = f_4_417_437(1.0, 1.0);
DynAbs.Tracing.TraceSender.TraceExitConstructor(4,392,442);
}catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(4,392,442);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(4,392,442);
}
		}

public Demand compute(double pi_R, double pi_I)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(4,563,721);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(4,618,645);

f_4_618_644(		D, pi_R, pi_I);

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(4,651,704) || true) && (D.P < 0.0)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(4,651,704);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(4,674,684);

D.P = 0.0;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(4,689,699);

D.Q = 0.0;
DynAbs.Tracing.TraceSender.TraceExitCondition(4,651,704);
}
DynAbs.Tracing.TraceSender.TraceSimpleStatement(4,708,717);

return D;
DynAbs.Tracing.TraceSender.TraceExitMethod(4,563,721);

int
f_4_618_644(Demand
this_param,double
pi_R,double
pi_I)
{
this_param.optimizeNode( pi_R, pi_I);
DynAbs.Tracing.TraceSender.TraceEndInvocation(4, 618, 644);
return 0;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(4,563,721);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(4,563,721);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

static Leaf()
{
DynAbs.Tracing.TraceSender.TraceEnterStaticConstructor(4,165,724);
DynAbs.Tracing.TraceSender.TraceExitStaticConstructor(4,165,724);

DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(4,165,724);
}

		int ___ignore_me___=DynAbs.Tracing.TraceSender.TraceBeforeConstructor(4,165,724);

static Demand
f_4_417_437(double
toP,double
toQ)
{
var return_v = new Demand( toP, toQ);
DynAbs.Tracing.TraceSender.TraceEndInvocation(4, 417, 437);
return return_v;
}

}
