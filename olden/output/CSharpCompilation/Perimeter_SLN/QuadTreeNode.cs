public abstract class QuadTreeNode
{
public static int gcmp ;

public static int lcmp ;

public Quadrant quadrant;

public QuadTreeNode nw;

public QuadTreeNode ne;

public QuadTreeNode sw;

public QuadTreeNode se;

public QuadTreeNode parent;

public static int NORTH ;

public static int EAST ;

public static int SOUTH ;

public static int WEST ;

public QuadTreeNode(Quadrant quad, QuadTreeNode parent)
:this(f_7_1353_1357_C(quad) ,null,null,null,null,parent)
		{
			try
	{ 
DynAbs.Tracing.TraceSender.TraceEnterConstructor(7,1287,1399);
DynAbs.Tracing.TraceSender.TraceExitConstructor(7,1287,1399);
	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(7,1287,1399);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(7,1287,1399);
}
		}

private QuadTreeNode(Quadrant quad, QuadTreeNode nw, QuadTreeNode ne, QuadTreeNode sw, QuadTreeNode se, QuadTreeNode parent)
		{
			try
{DynAbs.Tracing.TraceSender.TraceEnterConstructor(7,1773,2023);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(7,440,448);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(7,544,546);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(7,642,644);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(7,740,742);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(7,838,840);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(7,933,939);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(7,1905,1926);

this.quadrant = quad;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(7,1930,1943);

this.nw = nw;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(7,1947,1960);

this.ne = ne;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(7,1964,1977);

this.sw = sw;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(7,1981,1994);

this.se = se;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(7,1998,2019);

this.parent = parent;
DynAbs.Tracing.TraceSender.TraceExitConstructor(7,1773,2023);
}catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(7,1773,2023);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(7,1773,2023);
}
		}

public void setChildren(QuadTreeNode nw, QuadTreeNode ne, QuadTreeNode sw, QuadTreeNode se)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(7,2316,2483);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(7,2415,2428);

this.nw = nw;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(7,2432,2445);

this.ne = ne;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(7,2449,2462);

this.sw = sw;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(7,2466,2479);

this.se = se;
DynAbs.Tracing.TraceSender.TraceExitMethod(7,2316,2483);
	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(7,2316,2483);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(7,2316,2483);
}
		}

public QuadTreeNode getNorthWest()
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(7,2617,2673);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(7,2659,2669);

return nw;
DynAbs.Tracing.TraceSender.TraceExitMethod(7,2617,2673);
	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(7,2617,2673);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(7,2617,2673);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

public QuadTreeNode getNorthEast()
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(7,2805,2861);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(7,2847,2857);

return ne;
DynAbs.Tracing.TraceSender.TraceExitMethod(7,2805,2861);
	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(7,2805,2861);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(7,2805,2861);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

public QuadTreeNode getSouthWest()
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(7,2993,3049);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(7,3035,3045);

return sw;
DynAbs.Tracing.TraceSender.TraceExitMethod(7,2993,3049);
	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(7,2993,3049);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(7,2993,3049);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

public QuadTreeNode getSouthEast()
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(7,3181,3237);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(7,3223,3233);

return se;
DynAbs.Tracing.TraceSender.TraceExitMethod(7,3181,3237);
	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(7,3181,3237);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(7,3181,3237);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

public static QuadTreeNode createTree(int size, int center_x, int center_y, QuadTreeNode parent, Quadrant quadrant, int level)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterStaticMethod(7,3589,4665);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(7,3723,3741);

QuadTreeNode 
node
=default(QuadTreeNode);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(7,3747,3804);

int 
intersect = f_7_3763_3803(center_x, center_y, size)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(7,3808,3824);

size = size / 2;

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(7,3828,4645) || true) && (intersect == 0 &&(DynAbs.Tracing.TraceSender.Expression_True(7, 3831, 3859)&&size < 512))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(7,3828,4645);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(7,3870,3909);

node = f_7_3877_3908(quadrant, parent);
DynAbs.Tracing.TraceSender.TraceExitCondition(7,3828,4645);
}

else 
{DynAbs.Tracing.TraceSender.TraceEnterCondition(7,3828,4645);

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(7,3923,4645) || true) && (intersect == 2)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(7,3923,4645);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(7,3951,3990);

node = f_7_3958_3989(quadrant, parent);
DynAbs.Tracing.TraceSender.TraceExitCondition(7,3923,4645);
}

else

{DynAbs.Tracing.TraceSender.TraceEnterCondition(7,3923,4645);

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(7,4013,4640) || true) && (level == 0)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(7,4013,4640);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(7,4039,4078);

node = f_7_4046_4077(quadrant, parent);
DynAbs.Tracing.TraceSender.TraceExitCondition(7,4013,4640);
}

else

{DynAbs.Tracing.TraceSender.TraceEnterCondition(7,4013,4640);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(7,4105,4143);

node = f_7_4112_4142(quadrant, parent);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(7,4149,4256);

QuadTreeNode 
sw = f_7_4167_4255(size, center_x - size, center_y - size, node, Quadrant.cSouthWest, level - 1)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(7,4262,4369);

QuadTreeNode 
se = f_7_4280_4368(size, center_x + size, center_y - size, node, Quadrant.cSouthEast, level - 1)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(7,4375,4482);

QuadTreeNode 
ne = f_7_4393_4481(size, center_x + size, center_y + size, node, Quadrant.cNorthEast, level - 1)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(7,4488,4595);

QuadTreeNode 
nw = f_7_4506_4594(size, center_x - size, center_y + size, node, Quadrant.cNorthWest, level - 1)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(7,4601,4634);

f_7_4601_4633(				node, nw, ne, sw, se);
DynAbs.Tracing.TraceSender.TraceExitCondition(7,4013,4640);
}
DynAbs.Tracing.TraceSender.TraceExitCondition(7,3923,4645);
}
DynAbs.Tracing.TraceSender.TraceExitCondition(7,3828,4645);
}
DynAbs.Tracing.TraceSender.TraceSimpleStatement(7,4649,4661);

return node;
DynAbs.Tracing.TraceSender.TraceExitStaticMethod(7,3589,4665);

int
f_7_3763_3803(int
center_x,int
center_y,int
size)
{
var return_v = checkIntersect( center_x, center_y, size);
DynAbs.Tracing.TraceSender.TraceEndInvocation(7, 3763, 3803);
return return_v;
}


WhiteNode
f_7_3877_3908(Quadrant
quadrant,QuadTreeNode
parent)
{
var return_v = new WhiteNode( quadrant, parent);
DynAbs.Tracing.TraceSender.TraceEndInvocation(7, 3877, 3908);
return return_v;
}


BlackNode
f_7_3958_3989(Quadrant
quadrant,QuadTreeNode
parent)
{
var return_v = new BlackNode( quadrant, parent);
DynAbs.Tracing.TraceSender.TraceEndInvocation(7, 3958, 3989);
return return_v;
}


BlackNode
f_7_4046_4077(Quadrant
quadrant,QuadTreeNode
parent)
{
var return_v = new BlackNode( quadrant, parent);
DynAbs.Tracing.TraceSender.TraceEndInvocation(7, 4046, 4077);
return return_v;
}


GreyNode
f_7_4112_4142(Quadrant
quadrant,QuadTreeNode
parent)
{
var return_v = new GreyNode( quadrant, parent);
DynAbs.Tracing.TraceSender.TraceEndInvocation(7, 4112, 4142);
return return_v;
}


QuadTreeNode
f_7_4167_4255(int
size,int
center_x,int
center_y,QuadTreeNode
parent,Quadrant
quadrant,int
level)
{
var return_v = createTree( size, center_x, center_y, parent, quadrant, level);
DynAbs.Tracing.TraceSender.TraceEndInvocation(7, 4167, 4255);
return return_v;
}


QuadTreeNode
f_7_4280_4368(int
size,int
center_x,int
center_y,QuadTreeNode
parent,Quadrant
quadrant,int
level)
{
var return_v = createTree( size, center_x, center_y, parent, quadrant, level);
DynAbs.Tracing.TraceSender.TraceEndInvocation(7, 4280, 4368);
return return_v;
}


QuadTreeNode
f_7_4393_4481(int
size,int
center_x,int
center_y,QuadTreeNode
parent,Quadrant
quadrant,int
level)
{
var return_v = createTree( size, center_x, center_y, parent, quadrant, level);
DynAbs.Tracing.TraceSender.TraceEndInvocation(7, 4393, 4481);
return return_v;
}


QuadTreeNode
f_7_4506_4594(int
size,int
center_x,int
center_y,QuadTreeNode
parent,Quadrant
quadrant,int
level)
{
var return_v = createTree( size, center_x, center_y, parent, quadrant, level);
DynAbs.Tracing.TraceSender.TraceEndInvocation(7, 4506, 4594);
return return_v;
}


int
f_7_4601_4633(QuadTreeNode
this_param,QuadTreeNode
nw,QuadTreeNode
ne,QuadTreeNode
sw,QuadTreeNode
se)
{
this_param.setChildren( nw, ne, sw, se);
DynAbs.Tracing.TraceSender.TraceEndInvocation(7, 4601, 4633);
return 0;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(7,3589,4665);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(7,3589,4665);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

abstract public int perimeter(int size);

abstract public int sumAdjacent(Quadrant quad1, Quadrant quad2, int size);

public QuadTreeNode gtEqualAdjNeighbor(int dir)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(7,5824,6151);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(7,5879,5894);

QuadTreeNode 
q
=default(QuadTreeNode);

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(7,5898,6026) || true) && (parent != null &&(DynAbs.Tracing.TraceSender.Expression_True(7, 5901, 5941)&&f_7_5919_5941(quadrant, dir)))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(7,5898,6026);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(7,5952,5987);

q = f_7_5956_5986(parent, dir);
DynAbs.Tracing.TraceSender.TraceExitCondition(7,5898,6026);
}

else

{DynAbs.Tracing.TraceSender.TraceEnterCondition(7,5898,6026);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(7,6010,6021);

q = parent;
DynAbs.Tracing.TraceSender.TraceExitCondition(7,5898,6026);
}

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(7,6032,6147) || true) && (q != null &&(DynAbs.Tracing.TraceSender.Expression_True(7, 6035, 6061)&&q is GreyNode))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(7,6032,6147);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(7,6072,6110);

return f_7_6079_6109(f_7_6079_6100(quadrant, dir), q);
DynAbs.Tracing.TraceSender.TraceExitCondition(7,6032,6147);
}

else

{DynAbs.Tracing.TraceSender.TraceEnterCondition(7,6032,6147);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(7,6133,6142);

return q;
DynAbs.Tracing.TraceSender.TraceExitCondition(7,6032,6147);
}
DynAbs.Tracing.TraceSender.TraceExitMethod(7,5824,6151);

bool
f_7_5919_5941(Quadrant
this_param,int
direction)
{
var return_v = this_param.adjacent( direction);
DynAbs.Tracing.TraceSender.TraceEndInvocation(7, 5919, 5941);
return return_v;
}


QuadTreeNode
f_7_5956_5986(QuadTreeNode
this_param,int
dir)
{
var return_v = this_param.gtEqualAdjNeighbor( dir);
DynAbs.Tracing.TraceSender.TraceEndInvocation(7, 5956, 5986);
return return_v;
}


Quadrant
f_7_6079_6100(Quadrant
this_param,int
direction)
{
var return_v = this_param.reflect( direction);
DynAbs.Tracing.TraceSender.TraceEndInvocation(7, 6079, 6100);
return return_v;
}


QuadTreeNode
f_7_6079_6109(Quadrant
this_param,QuadTreeNode
node)
{
var return_v = this_param.child( node);
DynAbs.Tracing.TraceSender.TraceEndInvocation(7, 6079, 6109);
return return_v;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(7,5824,6151);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(7,5824,6151);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

public int countTree()
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(7,6268,6478);

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(7,6298,6474) || true) && (nw == null &&(DynAbs.Tracing.TraceSender.Expression_True(7, 6301, 6325)&&ne == null )&&(DynAbs.Tracing.TraceSender.Expression_True(7, 6301, 6339)&&sw == null )&&(DynAbs.Tracing.TraceSender.Expression_True(7, 6301, 6353)&&se == null))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(7,6298,6474);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(7,6364,6373);

return 1;
DynAbs.Tracing.TraceSender.TraceExitCondition(7,6298,6474);
}

else

{DynAbs.Tracing.TraceSender.TraceEnterCondition(7,6298,6474);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(7,6396,6469);

return f_7_6403_6417(sw)+ f_7_6420_6434(se)+ f_7_6437_6451(ne)+ f_7_6454_6468(nw);
DynAbs.Tracing.TraceSender.TraceExitCondition(7,6298,6474);
}
DynAbs.Tracing.TraceSender.TraceExitMethod(7,6268,6478);

int
f_7_6403_6417(QuadTreeNode
this_param)
{
var return_v = this_param.countTree();
DynAbs.Tracing.TraceSender.TraceEndInvocation(7, 6403, 6417);
return return_v;
}


int
f_7_6420_6434(QuadTreeNode
this_param)
{
var return_v = this_param.countTree();
DynAbs.Tracing.TraceSender.TraceEndInvocation(7, 6420, 6434);
return return_v;
}


int
f_7_6437_6451(QuadTreeNode
this_param)
{
var return_v = this_param.countTree();
DynAbs.Tracing.TraceSender.TraceEndInvocation(7, 6437, 6451);
return return_v;
}


int
f_7_6454_6468(QuadTreeNode
this_param)
{
var return_v = this_param.countTree();
DynAbs.Tracing.TraceSender.TraceEndInvocation(7, 6454, 6468);
return return_v;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(7,6268,6478);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(7,6268,6478);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

private static int checkOutside(int x, int y)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterStaticMethod(7,6483,6651);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(7,6536,6563);

int 
euclid = x * x + y * y
;

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(7,6567,6598) || true) && (euclid > gcmp)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(7,6567,6598);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(7,6589,6598);

return 1;
DynAbs.Tracing.TraceSender.TraceExitCondition(7,6567,6598);
}

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(7,6602,6634) || true) && (euclid < lcmp)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(7,6602,6634);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(7,6624,6634);

return -1;
DynAbs.Tracing.TraceSender.TraceExitCondition(7,6602,6634);
}
DynAbs.Tracing.TraceSender.TraceSimpleStatement(7,6638,6647);

return 0;
DynAbs.Tracing.TraceSender.TraceExitStaticMethod(7,6483,6651);
	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(7,6483,6651);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(7,6483,6651);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

private static int checkIntersect(int center_x, int center_y, int size)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterStaticMethod(7,6656,7247);

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(7,6735,6969) || true) && (f_7_6738_6784(center_x + size, center_y + size)== 0 &&(DynAbs.Tracing.TraceSender.Expression_True(7, 6738, 6844)&&f_7_6793_6839(center_x + size, center_y - size)== 0 )&&(DynAbs.Tracing.TraceSender.Expression_True(7, 6738, 6899)&&f_7_6848_6894(center_x - size, center_y - size)== 0 )&&(DynAbs.Tracing.TraceSender.Expression_True(7, 6738, 6954)&&f_7_6903_6949(center_x - size, center_y + size)== 0))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(7,6735,6969);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(7,6960,6969);

return 2;
DynAbs.Tracing.TraceSender.TraceExitCondition(7,6735,6969);
}
DynAbs.Tracing.TraceSender.TraceSimpleStatement(7,6975,7179);

int 
sum = f_7_6985_7031(center_x + size, center_y + size)+ f_7_7034_7080(center_x + size, center_y - size)+ f_7_7083_7129(center_x - size, center_y - size)+ f_7_7132_7178(center_x - size, center_y + size)
;

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(7,7185,7228) || true) && ((sum == 4) ||(DynAbs.Tracing.TraceSender.Expression_False(7, 7188, 7213)||(sum == -4)))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(7,7185,7228);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(7,7219,7228);

return 0;
DynAbs.Tracing.TraceSender.TraceExitCondition(7,7185,7228);
}
DynAbs.Tracing.TraceSender.TraceSimpleStatement(7,7234,7243);

return 1;
DynAbs.Tracing.TraceSender.TraceExitStaticMethod(7,6656,7247);

int
f_7_6738_6784(int
x,int
y)
{
var return_v = checkOutside( x, y);
DynAbs.Tracing.TraceSender.TraceEndInvocation(7, 6738, 6784);
return return_v;
}


int
f_7_6793_6839(int
x,int
y)
{
var return_v = checkOutside( x, y);
DynAbs.Tracing.TraceSender.TraceEndInvocation(7, 6793, 6839);
return return_v;
}


int
f_7_6848_6894(int
x,int
y)
{
var return_v = checkOutside( x, y);
DynAbs.Tracing.TraceSender.TraceEndInvocation(7, 6848, 6894);
return return_v;
}


int
f_7_6903_6949(int
x,int
y)
{
var return_v = checkOutside( x, y);
DynAbs.Tracing.TraceSender.TraceEndInvocation(7, 6903, 6949);
return return_v;
}


int
f_7_6985_7031(int
x,int
y)
{
var return_v = checkOutside( x, y);
DynAbs.Tracing.TraceSender.TraceEndInvocation(7, 6985, 7031);
return return_v;
}


int
f_7_7034_7080(int
x,int
y)
{
var return_v = checkOutside( x, y);
DynAbs.Tracing.TraceSender.TraceEndInvocation(7, 7034, 7080);
return return_v;
}


int
f_7_7083_7129(int
x,int
y)
{
var return_v = checkOutside( x, y);
DynAbs.Tracing.TraceSender.TraceEndInvocation(7, 7083, 7129);
return return_v;
}


int
f_7_7132_7178(int
x,int
y)
{
var return_v = checkOutside( x, y);
DynAbs.Tracing.TraceSender.TraceEndInvocation(7, 7132, 7178);
return return_v;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(7,6656,7247);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(7,6656,7247);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

public override string ToString() 
		{
			try
	{ 
DynAbs.Tracing.TraceSender.TraceEnterMethod(7,7253,7360);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(7,7296,7355);

return f_7_7303_7322(f_7_7303_7317(this))+ " " + f_7_7331_7354(f_7_7331_7349(quadrant));
DynAbs.Tracing.TraceSender.TraceExitMethod(7,7253,7360);

System.Type
f_7_7303_7317(QuadTreeNode
this_param)
{
var return_v = this_param.GetType();
DynAbs.Tracing.TraceSender.TraceEndInvocation(7, 7303, 7317);
return return_v;
}


string
f_7_7303_7322(System.Type
this_param)
{
var return_v = this_param.Name ;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(7, 7303, 7322);
return return_v;
}


System.Type
f_7_7331_7349(Quadrant
this_param)
{
var return_v = this_param.GetType();
DynAbs.Tracing.TraceSender.TraceEndInvocation(7, 7331, 7349);
return return_v;
}


string
f_7_7331_7354(System.Type
this_param)
{
var return_v = this_param.Name;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(7, 7331, 7354);
return return_v;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(7,7253,7360);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(7,7253,7360);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

static QuadTreeNode()
{
DynAbs.Tracing.TraceSender.TraceEnterStaticConstructor(7,60,7363);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(7,186,200);
gcmp = 4194304;DynAbs.Tracing.TraceSender.TraceSimpleStatement(7,290,304);
lcmp = 1048576;DynAbs.Tracing.TraceSender.TraceSimpleStatement(7,994,1003);
NORTH = 0;DynAbs.Tracing.TraceSender.TraceSimpleStatement(7,1025,1033);
EAST = 1;DynAbs.Tracing.TraceSender.TraceSimpleStatement(7,1055,1064);
SOUTH = 2;DynAbs.Tracing.TraceSender.TraceSimpleStatement(7,1086,1094);
WEST = 3;DynAbs.Tracing.TraceSender.TraceExitStaticConstructor(7,60,7363);

DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(7,60,7363);
}

		int ___ignore_me___=DynAbs.Tracing.TraceSender.TraceBeforeConstructor(7,60,7363);

static Quadrant
f_7_1353_1357_C(Quadrant
i)
{
var return_v = i;
DynAbs.Tracing.TraceSender.TraceBaseCall(7, 1287, 1399);
return return_v;
}

}
