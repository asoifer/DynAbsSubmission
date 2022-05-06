public class GreyNode : QuadTreeNode
{
public GreyNode(Quadrant quadrant, QuadTreeNode parent)
:base(f_2_426_434_C(quadrant) ,parent)
		{
			try
{DynAbs.Tracing.TraceSender.TraceEnterConstructor(2,360,452);
DynAbs.Tracing.TraceSender.TraceExitConstructor(2,360,452);
}catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(2,360,452);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(2,360,452);
}
		}

public override int perimeter(int size)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(2,672,892);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,719,735);

size = size / 2;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,739,771);

int 
retval = f_2_752_770(sw, size)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,775,804);

retval += f_2_785_803(se, size);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,808,837);

retval += f_2_818_836(ne, size);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,841,870);

retval += f_2_851_869(nw, size);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,874,888);

return retval;
DynAbs.Tracing.TraceSender.TraceExitMethod(2,672,892);

int
f_2_752_770(QuadTreeNode
this_param,int
size)
{
var return_v = this_param.perimeter( size);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 752, 770);
return return_v;
}


int
f_2_785_803(QuadTreeNode
this_param,int
size)
{
var return_v = this_param.perimeter( size);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 785, 803);
return return_v;
}


int
f_2_818_836(QuadTreeNode
this_param,int
size)
{
var return_v = this_param.perimeter( size);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 818, 836);
return return_v;
}


int
f_2_851_869(QuadTreeNode
this_param,int
size)
{
var return_v = this_param.perimeter( size);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 851, 869);
return return_v;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(2,672,892);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(2,672,892);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

public override int sumAdjacent(Quadrant quad1, Quadrant quad2, int size)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(2,1373,1653);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1454,1494);

QuadTreeNode 
child1 = f_2_1476_1493(quad1, this)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1498,1538);

QuadTreeNode 
child2 = f_2_1520_1537(quad2, this)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1542,1558);

size = size / 2;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1562,1649);

return f_2_1569_1607(child1, quad1, quad2, size)+ f_2_1610_1648(child2, quad1, quad2, size);
DynAbs.Tracing.TraceSender.TraceExitMethod(2,1373,1653);

QuadTreeNode
f_2_1476_1493(Quadrant
this_param,GreyNode
node)
{
var return_v = this_param.child( (QuadTreeNode)node);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 1476, 1493);
return return_v;
}


QuadTreeNode
f_2_1520_1537(Quadrant
this_param,GreyNode
node)
{
var return_v = this_param.child( (QuadTreeNode)node);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 1520, 1537);
return return_v;
}


int
f_2_1569_1607(QuadTreeNode
this_param,Quadrant
quad1,Quadrant
quad2,int
size)
{
var return_v = this_param.sumAdjacent( quad1, quad2, size);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 1569, 1607);
return return_v;
}


int
f_2_1610_1648(QuadTreeNode
this_param,Quadrant
quad1,Quadrant
quad2,int
size)
{
var return_v = this_param.sumAdjacent( quad1, quad2, size);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 1610, 1648);
return return_v;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(2,1373,1653);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(2,1373,1653);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

static GreyNode()
{
DynAbs.Tracing.TraceSender.TraceEnterStaticConstructor(2,150,1656);
DynAbs.Tracing.TraceSender.TraceExitStaticConstructor(2,150,1656);

DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(2,150,1656);
}

		int ___ignore_me___=DynAbs.Tracing.TraceSender.TraceBeforeConstructor(2,150,1656);

static Quadrant
f_2_426_434_C(Quadrant
i)
{
var return_v = i;
DynAbs.Tracing.TraceSender.TraceBaseCall(2, 360, 452);
return return_v;
}

}
