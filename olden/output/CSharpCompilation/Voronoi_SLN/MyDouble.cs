public class MyDouble
{
public double value;

internal MyDouble(double d)
		{
			try
{DynAbs.Tracing.TraceSender.TraceEnterConstructor(3,219,268);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,210,215);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,254,264);

value = d;
DynAbs.Tracing.TraceSender.TraceExitConstructor(3,219,268);
}catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(3,219,268);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(3,219,268);
}
		}

public override string ToString()
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(3,271,340);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,312,336);

return f_3_319_335(value);
DynAbs.Tracing.TraceSender.TraceExitMethod(3,271,340);

string
f_3_319_335(double
this_param)
{
var return_v = this_param.ToString();
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 319, 335);
return return_v;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(3,271,340);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(3,271,340);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

static MyDouble()
{
DynAbs.Tracing.TraceSender.TraceEnterStaticConstructor(3,169,343);
DynAbs.Tracing.TraceSender.TraceExitStaticConstructor(3,169,343);

DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(3,169,343);
}

		int ___ignore_me___=DynAbs.Tracing.TraceSender.TraceBeforeConstructor(3,169,343);
}
