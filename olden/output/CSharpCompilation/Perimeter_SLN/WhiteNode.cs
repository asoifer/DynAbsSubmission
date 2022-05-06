class WhiteNode : QuadTreeNode
{
public WhiteNode(Quadrant quadrant, QuadTreeNode parent)
:base(f_10_420_428_C(quadrant) ,parent)
		{
			try
{DynAbs.Tracing.TraceSender.TraceEnterConstructor(10,353,446);
DynAbs.Tracing.TraceSender.TraceExitConstructor(10,353,446);
}catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(10,353,446);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(10,353,446);
}
		}

public override int perimeter(int size)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(10,730,790);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(10,777,786);

return 0;
DynAbs.Tracing.TraceSender.TraceExitMethod(10,730,790);
	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(10,730,790);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(10,730,790);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

public override int sumAdjacent(Quadrant quad1, Quadrant quad2, int size)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(10,1151,1248);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(10,1232,1244);

return size;
DynAbs.Tracing.TraceSender.TraceExitMethod(10,1151,1248);
	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(10,1151,1248);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(10,1151,1248);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

static WhiteNode()
{
DynAbs.Tracing.TraceSender.TraceEnterStaticConstructor(10,147,1251);
DynAbs.Tracing.TraceSender.TraceExitStaticConstructor(10,147,1251);

DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(10,147,1251);
}

		int ___ignore_me___=DynAbs.Tracing.TraceSender.TraceBeforeConstructor(10,147,1251);

static Quadrant
f_10_420_428_C(Quadrant
i)
{
var return_v = i;
DynAbs.Tracing.TraceSender.TraceBaseCall(10, 353, 446);
return return_v;
}

}
