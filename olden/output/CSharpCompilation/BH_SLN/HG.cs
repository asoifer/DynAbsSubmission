public class HG
{
public Body pskip;

public MathVector pos0;

public double phi0;

public MathVector acc0;

public HG(Body b, MathVector p)
		{
			try
{DynAbs.Tracing.TraceSender.TraceEnterConstructor(5,524,651);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,190,195);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,265,269);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,329,333);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,400,404);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,563,573);

pskip = b;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,577,604);

pos0 = f_5_584_603(p);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,608,619);

phi0 = 0.0;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,623,647);

acc0 = f_5_630_646();
DynAbs.Tracing.TraceSender.TraceExitConstructor(5,524,651);
}catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(5,524,651);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(5,524,651);
}
		}

static HG()
{
DynAbs.Tracing.TraceSender.TraceEnterStaticConstructor(5,109,654);
DynAbs.Tracing.TraceSender.TraceExitStaticConstructor(5,109,654);

DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(5,109,654);
}

		int ___ignore_me___=DynAbs.Tracing.TraceSender.TraceBeforeConstructor(5,109,654);

static MathVector
f_5_584_603(MathVector
this_param)
{
var return_v = this_param.cloneMathVector();
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 584, 603);
return return_v;
}


static MathVector
f_5_630_646()
{
var return_v = new MathVector();
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 630, 646);
return return_v;
}

}
