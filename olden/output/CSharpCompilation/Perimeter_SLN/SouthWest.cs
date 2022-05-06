public class SouthWest : Quadrant
{
public override bool adjacent(int direction)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(9,331,462);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(9,383,458);

return (direction == QuadTreeNode.SOUTH ||(DynAbs.Tracing.TraceSender.Expression_False(9, 391, 456)||direction == QuadTreeNode.WEST));
DynAbs.Tracing.TraceSender.TraceExitMethod(9,331,462);
	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(9,331,462);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(9,331,462);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

public override Quadrant reflect(int direction)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(9,662,862);

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(9,717,827) || true) && (direction == QuadTreeNode.WEST ||(DynAbs.Tracing.TraceSender.Expression_False(9, 720, 784)||direction == QuadTreeNode.EAST))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(9,717,827);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(9,795,822);

return Quadrant.cSouthEast;
DynAbs.Tracing.TraceSender.TraceExitCondition(9,717,827);
}
DynAbs.Tracing.TraceSender.TraceSimpleStatement(9,831,858);

return Quadrant.cNorthWest;
DynAbs.Tracing.TraceSender.TraceExitMethod(9,662,862);
	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(9,662,862);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(9,662,862);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

public override QuadTreeNode child(QuadTreeNode node)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(9,1063,1155);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(9,1124,1151);

return f_9_1131_1150(node);
DynAbs.Tracing.TraceSender.TraceExitMethod(9,1063,1155);

QuadTreeNode
f_9_1131_1150(QuadTreeNode
this_param)
{
var return_v = this_param.getSouthWest();
DynAbs.Tracing.TraceSender.TraceEndInvocation(9, 1131, 1150);
return return_v;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(9,1063,1155);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(9,1063,1155);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

public SouthWest()
{
DynAbs.Tracing.TraceSender.TraceEnterConstructor(9,73,1158);
DynAbs.Tracing.TraceSender.TraceExitConstructor(9,73,1158);

DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(9,73,1158);
}


static SouthWest()
{
DynAbs.Tracing.TraceSender.TraceEnterStaticConstructor(9,73,1158);
DynAbs.Tracing.TraceSender.TraceExitStaticConstructor(9,73,1158);

DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(9,73,1158);
}

		int ___ignore_me___=DynAbs.Tracing.TraceSender.TraceBeforeConstructor(9,73,1158);
}
