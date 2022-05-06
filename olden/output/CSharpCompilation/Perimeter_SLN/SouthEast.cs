public class SouthEast : Quadrant
{
public override bool adjacent(int direction)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(8,330,461);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(8,382,457);

return (direction == QuadTreeNode.SOUTH ||(DynAbs.Tracing.TraceSender.Expression_False(8, 390, 455)||direction == QuadTreeNode.EAST));
DynAbs.Tracing.TraceSender.TraceExitMethod(8,330,461);
	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(8,330,461);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(8,330,461);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

public override Quadrant reflect(int direction)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(8,661,851);

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(8,716,816) || true) && (direction == QuadTreeNode.WEST ||(DynAbs.Tracing.TraceSender.Expression_False(8, 719, 783)||direction == QuadTreeNode.EAST))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(8,716,816);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(8,789,816);

return Quadrant.cSouthWest;
DynAbs.Tracing.TraceSender.TraceExitCondition(8,716,816);
}
DynAbs.Tracing.TraceSender.TraceSimpleStatement(8,820,847);

return Quadrant.cNorthEast;
DynAbs.Tracing.TraceSender.TraceExitMethod(8,661,851);
	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(8,661,851);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(8,661,851);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

public override QuadTreeNode child(QuadTreeNode node)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(8,1052,1144);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(8,1113,1140);

return f_8_1120_1139(node);
DynAbs.Tracing.TraceSender.TraceExitMethod(8,1052,1144);

QuadTreeNode
f_8_1120_1139(QuadTreeNode
this_param)
{
var return_v = this_param.getSouthEast();
DynAbs.Tracing.TraceSender.TraceEndInvocation(8, 1120, 1139);
return return_v;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(8,1052,1144);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(8,1052,1144);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

public SouthEast()
{
DynAbs.Tracing.TraceSender.TraceEnterConstructor(8,72,1147);
DynAbs.Tracing.TraceSender.TraceExitConstructor(8,72,1147);

DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(8,72,1147);
}


static SouthEast()
{
DynAbs.Tracing.TraceSender.TraceEnterStaticConstructor(8,72,1147);
DynAbs.Tracing.TraceSender.TraceExitStaticConstructor(8,72,1147);

DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(8,72,1147);
}

		int ___ignore_me___=DynAbs.Tracing.TraceSender.TraceBeforeConstructor(8,72,1147);
}
