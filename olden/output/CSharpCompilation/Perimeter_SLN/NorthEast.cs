public class NorthEast : Quadrant
{
public override bool adjacent(int direction)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(3,337,468);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,389,464);

return (direction == QuadTreeNode.NORTH ||(DynAbs.Tracing.TraceSender.Expression_False(3, 397, 462)||direction == QuadTreeNode.EAST));
DynAbs.Tracing.TraceSender.TraceExitMethod(3,337,468);
	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(3,337,468);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(3,337,468);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

public override Quadrant reflect(int direction)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(3,668,858);

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,723,823) || true) && (direction == QuadTreeNode.WEST ||(DynAbs.Tracing.TraceSender.Expression_False(3, 726, 790)||direction == QuadTreeNode.EAST))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(3,723,823);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,796,823);

return Quadrant.cNorthWest;
DynAbs.Tracing.TraceSender.TraceExitCondition(3,723,823);
}
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,827,854);

return Quadrant.cSouthEast;
DynAbs.Tracing.TraceSender.TraceExitMethod(3,668,858);
	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(3,668,858);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(3,668,858);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

public override QuadTreeNode child(QuadTreeNode node)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(3,1059,1151);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,1120,1147);

return f_3_1127_1146(node);
DynAbs.Tracing.TraceSender.TraceExitMethod(3,1059,1151);

QuadTreeNode
f_3_1127_1146(QuadTreeNode
this_param)
{
var return_v = this_param.getNorthEast();
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 1127, 1146);
return return_v;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(3,1059,1151);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(3,1059,1151);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

public NorthEast()
{
DynAbs.Tracing.TraceSender.TraceEnterConstructor(3,76,1154);
DynAbs.Tracing.TraceSender.TraceExitConstructor(3,76,1154);

DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(3,76,1154);
}


static NorthEast()
{
DynAbs.Tracing.TraceSender.TraceEnterStaticConstructor(3,76,1154);
DynAbs.Tracing.TraceSender.TraceExitStaticConstructor(3,76,1154);

DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(3,76,1154);
}

		int ___ignore_me___=DynAbs.Tracing.TraceSender.TraceBeforeConstructor(3,76,1154);
}
