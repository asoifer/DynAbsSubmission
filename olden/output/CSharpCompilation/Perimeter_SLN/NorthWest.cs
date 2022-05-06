public class NorthWest : Quadrant
{
public override bool adjacent(int direction)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(4,335,466);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(4,387,462);

return (direction == QuadTreeNode.NORTH ||(DynAbs.Tracing.TraceSender.Expression_False(4, 395, 460)||direction == QuadTreeNode.WEST));
DynAbs.Tracing.TraceSender.TraceExitMethod(4,335,466);
	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(4,335,466);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(4,335,466);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

public override Quadrant reflect(int direction)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(4,666,856);

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(4,721,821) || true) && (direction == QuadTreeNode.WEST ||(DynAbs.Tracing.TraceSender.Expression_False(4, 724, 788)||direction == QuadTreeNode.EAST))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(4,721,821);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(4,794,821);

return Quadrant.cNorthEast;
DynAbs.Tracing.TraceSender.TraceExitCondition(4,721,821);
}
DynAbs.Tracing.TraceSender.TraceSimpleStatement(4,825,852);

return Quadrant.cSouthWest;
DynAbs.Tracing.TraceSender.TraceExitMethod(4,666,856);
	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(4,666,856);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(4,666,856);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

public override QuadTreeNode child(QuadTreeNode node)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(4,1057,1149);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(4,1118,1145);

return f_4_1125_1144(node);
DynAbs.Tracing.TraceSender.TraceExitMethod(4,1057,1149);

QuadTreeNode
f_4_1125_1144(QuadTreeNode
this_param)
{
var return_v = this_param.getNorthWest();
DynAbs.Tracing.TraceSender.TraceEndInvocation(4, 1125, 1144);
return return_v;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(4,1057,1149);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(4,1057,1149);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

public NorthWest()
{
DynAbs.Tracing.TraceSender.TraceEnterConstructor(4,75,1152);
DynAbs.Tracing.TraceSender.TraceExitConstructor(4,75,1152);

DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(4,75,1152);
}


static NorthWest()
{
DynAbs.Tracing.TraceSender.TraceEnterStaticConstructor(4,75,1152);
DynAbs.Tracing.TraceSender.TraceExitStaticConstructor(4,75,1152);

DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(4,75,1152);
}

		int ___ignore_me___=DynAbs.Tracing.TraceSender.TraceBeforeConstructor(4,75,1152);
}
