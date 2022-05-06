public class Patient
{
public int hospitalsVisited;

public int time;

public int timeLeft;

Village home;

public Patient(Village v)
		{
			try
{DynAbs.Tracing.TraceSender.TraceEnterConstructor(5,314,415);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,112,128);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,143,147);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,162,170);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,182,186);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,347,356);

home = v;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,360,381);

hospitalsVisited = 0;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,385,394);

time = 0;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,398,411);

timeLeft = 0;
DynAbs.Tracing.TraceSender.TraceExitConstructor(5,314,415);
}catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(5,314,415);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(5,314,415);
}
		}

static Patient()
{
DynAbs.Tracing.TraceSender.TraceEnterStaticConstructor(5,75,418);
DynAbs.Tracing.TraceSender.TraceExitStaticConstructor(5,75,418);

DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(5,75,418);
}

		int ___ignore_me___=DynAbs.Tracing.TraceSender.TraceBeforeConstructor(5,75,418);
}
