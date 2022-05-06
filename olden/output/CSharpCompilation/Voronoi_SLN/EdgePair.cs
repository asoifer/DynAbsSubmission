public class EdgePair
{
internal Edge left;

internal Edge right;

public EdgePair(Edge l, Edge r)
		{
			try
{DynAbs.Tracing.TraceSender.TraceEnterConstructor(2,130,196);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,97,101);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,119,124);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,169,178);

left = l;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,182,192);

right = r;
DynAbs.Tracing.TraceSender.TraceExitConstructor(2,130,196);
}catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(2,130,196);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(2,130,196);
}
		}

public virtual Edge getLeft()
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(2,201,254);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,238,250);

return left;
DynAbs.Tracing.TraceSender.TraceExitMethod(2,201,254);
	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(2,201,254);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(2,201,254);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

public virtual Edge getRight()
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(2,259,314);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,297,310);

return right;
DynAbs.Tracing.TraceSender.TraceExitMethod(2,259,314);
	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(2,259,314);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(2,259,314);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

static EdgePair()
{
DynAbs.Tracing.TraceSender.TraceEnterStaticConstructor(2,56,317);
DynAbs.Tracing.TraceSender.TraceExitStaticConstructor(2,56,317);

DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(2,56,317);
}

		int ___ignore_me___=DynAbs.Tracing.TraceSender.TraceBeforeConstructor(2,56,317);
}
