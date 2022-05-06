public abstract class Quadrant
{
public static Quadrant cNorthWest ;

public static Quadrant cNorthEast ;

public static Quadrant cSouthWest ;

public static Quadrant cSouthEast ;

abstract public bool adjacent(int direction);

abstract public Quadrant reflect(int direction);

abstract public QuadTreeNode child(QuadTreeNode node);

public Quadrant()
{
DynAbs.Tracing.TraceSender.TraceEnterConstructor(6,146,1170);
DynAbs.Tracing.TraceSender.TraceExitConstructor(6,146,1170);

DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(6,146,1170);
}


static Quadrant()
{
DynAbs.Tracing.TraceSender.TraceEnterStaticConstructor(6,146,1170);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,205,233);
cNorthWest = f_6_218_233();DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,260,288);
cNorthEast = f_6_273_288();DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,315,343);
cSouthWest = f_6_328_343();DynAbs.Tracing.TraceSender.TraceSimpleStatement(6,370,398);
cSouthEast = f_6_383_398();DynAbs.Tracing.TraceSender.TraceExitStaticConstructor(6,146,1170);

DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(6,146,1170);
}

		int ___ignore_me___=DynAbs.Tracing.TraceSender.TraceBeforeConstructor(6,146,1170);

static NorthWest
f_6_218_233()
{
var return_v = new NorthWest();
DynAbs.Tracing.TraceSender.TraceEndInvocation(6, 218, 233);
return return_v;
}


static NorthEast
f_6_273_288()
{
var return_v = new NorthEast();
DynAbs.Tracing.TraceSender.TraceEndInvocation(6, 273, 288);
return return_v;
}


static SouthWest
f_6_328_343()
{
var return_v = new SouthWest();
DynAbs.Tracing.TraceSender.TraceEndInvocation(6, 328, 343);
return return_v;
}


static SouthEast
f_6_383_398()
{
var return_v = new SouthEast();
DynAbs.Tracing.TraceSender.TraceEndInvocation(6, 383, 398);
return return_v;
}

}
