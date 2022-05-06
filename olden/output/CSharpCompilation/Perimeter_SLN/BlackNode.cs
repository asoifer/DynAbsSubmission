public class BlackNode : QuadTreeNode
{
public BlackNode(Quadrant quadrant, QuadTreeNode parent)
:base(f_1_417_425_C(quadrant) ,parent)
		{
			try
{DynAbs.Tracing.TraceSender.TraceEnterConstructor(1,350,443);
DynAbs.Tracing.TraceSender.TraceExitConstructor(1,350,443);
}catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(1,350,443);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(1,350,443);
}
		}

public override int perimeter(int size)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(1,520,1633);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,567,582);

int 
retval = 0
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,598,661);

QuadTreeNode 
neighbor = f_1_622_660(this, QuadTreeNode.NORTH)
;

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,665,847) || true) && (neighbor == null ||(DynAbs.Tracing.TraceSender.Expression_False(1, 668, 709)||neighbor is WhiteNode))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,665,847);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,715,730);

retval += size;
DynAbs.Tracing.TraceSender.TraceExitCondition(1,665,847);
}

else 
{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,665,847);

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,739,847) || true) && (neighbor is GreyNode)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,739,847);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,768,847);

retval += f_1_778_846(neighbor, Quadrant.cSouthEast, Quadrant.cSouthWest, size);
DynAbs.Tracing.TraceSender.TraceExitCondition(1,739,847);
}
DynAbs.Tracing.TraceSender.TraceExitCondition(1,665,847);
}
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,866,915);

neighbor = f_1_877_914(this, QuadTreeNode.EAST);

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,919,1101) || true) && (neighbor == null ||(DynAbs.Tracing.TraceSender.Expression_False(1, 922, 963)||neighbor is WhiteNode))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,919,1101);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,969,984);

retval += size;
DynAbs.Tracing.TraceSender.TraceExitCondition(1,919,1101);
}

else 
{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,919,1101);

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,993,1101) || true) && (neighbor is GreyNode)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,993,1101);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1022,1101);

retval += f_1_1032_1100(neighbor, Quadrant.cSouthWest, Quadrant.cNorthWest, size);
DynAbs.Tracing.TraceSender.TraceExitCondition(1,993,1101);
}
DynAbs.Tracing.TraceSender.TraceExitCondition(1,919,1101);
}
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1121,1171);

neighbor = f_1_1132_1170(this, QuadTreeNode.SOUTH);

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1175,1357) || true) && (neighbor == null ||(DynAbs.Tracing.TraceSender.Expression_False(1, 1178, 1219)||neighbor is WhiteNode))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,1175,1357);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1225,1240);

retval += size;
DynAbs.Tracing.TraceSender.TraceExitCondition(1,1175,1357);
}

else 
{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,1175,1357);

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1249,1357) || true) && (neighbor is GreyNode)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,1249,1357);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1278,1357);

retval += f_1_1288_1356(neighbor, Quadrant.cNorthWest, Quadrant.cNorthEast, size);
DynAbs.Tracing.TraceSender.TraceExitCondition(1,1249,1357);
}
DynAbs.Tracing.TraceSender.TraceExitCondition(1,1175,1357);
}
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1374,1423);

neighbor = f_1_1385_1422(this, QuadTreeNode.WEST);

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1427,1609) || true) && (neighbor == null ||(DynAbs.Tracing.TraceSender.Expression_False(1, 1430, 1471)||neighbor is WhiteNode))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,1427,1609);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1477,1492);

retval += size;
DynAbs.Tracing.TraceSender.TraceExitCondition(1,1427,1609);
}

else 
{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,1427,1609);

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1501,1609) || true) && (neighbor is GreyNode)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,1501,1609);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1530,1609);

retval += f_1_1540_1608(neighbor, Quadrant.cNorthEast, Quadrant.cSouthEast, size);
DynAbs.Tracing.TraceSender.TraceExitCondition(1,1501,1609);
}
DynAbs.Tracing.TraceSender.TraceExitCondition(1,1427,1609);
}
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1615,1629);

return retval;
DynAbs.Tracing.TraceSender.TraceExitMethod(1,520,1633);

QuadTreeNode
f_1_622_660(BlackNode
this_param,int
dir)
{
var return_v = this_param.gtEqualAdjNeighbor( dir);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 622, 660);
return return_v;
}


int
f_1_778_846(QuadTreeNode
this_param,Quadrant
quad1,Quadrant
quad2,int
size)
{
var return_v = this_param.sumAdjacent( quad1, quad2, size);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 778, 846);
return return_v;
}


QuadTreeNode
f_1_877_914(BlackNode
this_param,int
dir)
{
var return_v = this_param.gtEqualAdjNeighbor( dir);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 877, 914);
return return_v;
}


int
f_1_1032_1100(QuadTreeNode
this_param,Quadrant
quad1,Quadrant
quad2,int
size)
{
var return_v = this_param.sumAdjacent( quad1, quad2, size);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 1032, 1100);
return return_v;
}


QuadTreeNode
f_1_1132_1170(BlackNode
this_param,int
dir)
{
var return_v = this_param.gtEqualAdjNeighbor( dir);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 1132, 1170);
return return_v;
}


int
f_1_1288_1356(QuadTreeNode
this_param,Quadrant
quad1,Quadrant
quad2,int
size)
{
var return_v = this_param.sumAdjacent( quad1, quad2, size);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 1288, 1356);
return return_v;
}


QuadTreeNode
f_1_1385_1422(BlackNode
this_param,int
dir)
{
var return_v = this_param.gtEqualAdjNeighbor( dir);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 1385, 1422);
return return_v;
}


int
f_1_1540_1608(QuadTreeNode
this_param,Quadrant
quad1,Quadrant
quad2,int
size)
{
var return_v = this_param.sumAdjacent( quad1, quad2, size);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 1540, 1608);
return return_v;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(1,520,1633);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(1,520,1633);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

public override int sumAdjacent(Quadrant quad1, Quadrant quad2, int size)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(1,1984,2078);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2065,2074);

return 0;
DynAbs.Tracing.TraceSender.TraceExitMethod(1,1984,2078);
	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(1,1984,2078);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(1,1984,2078);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

static BlackNode()
{
DynAbs.Tracing.TraceSender.TraceEnterStaticConstructor(1,144,2081);
DynAbs.Tracing.TraceSender.TraceExitStaticConstructor(1,144,2081);

DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(1,144,2081);
}

		int ___ignore_me___=DynAbs.Tracing.TraceSender.TraceBeforeConstructor(1,144,2081);

static Quadrant
f_1_417_425_C(Quadrant
i)
{
var return_v = i;
DynAbs.Tracing.TraceSender.TraceBaseCall(1, 350, 443);
return return_v;
}

}
