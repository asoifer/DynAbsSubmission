public class Results
{
public double totalPatients;

public double totalTime;

public double totalHospitals;

public Results()
{
DynAbs.Tracing.TraceSender.TraceEnterConstructor(6,77,193);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,117,130);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,148,157);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,175,189);
DynAbs.Tracing.TraceSender.TraceExitConstructor(6,77,193);

DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(6,77,193);
}


static Results()
{
DynAbs.Tracing.TraceSender.TraceEnterStaticConstructor(6,77,193);
DynAbs.Tracing.TraceSender.TraceExitStaticConstructor(6,77,193);

DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(6,77,193);
}

		int ___ignore_me___=DynAbs.Tracing.TraceSender.TraceBeforeConstructor(6,77,193);
}
