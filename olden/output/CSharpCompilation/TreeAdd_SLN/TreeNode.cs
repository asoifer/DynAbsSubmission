using System;
internal class TreeNode
{
private int value ;

private TreeNode left ;

private TreeNode right ;

internal TreeNode(int v, TreeNode l, TreeNode r)
		{
			try
{DynAbs.Tracing.TraceSender.TraceEnterConstructor(2,353,450);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,97,106);
this.value = 0;DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,127,138);
this.left = null;DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,159,171);
this.right = null;DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,409,419);

value = v;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,423,432);

left = l;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,436,446);

right = r;
DynAbs.Tracing.TraceSender.TraceExitConstructor(2,353,450);
}catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(2,353,450);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(2,353,450);
}
		}

internal TreeNode(TreeNode l, TreeNode r)
:this(f_2_605_606_C(1) ,l,r)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterConstructor(2,553,621);
DynAbs.Tracing.TraceSender.TraceExitConstructor(2,553,621);
	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(2,553,621);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(2,553,621);
}
		}

internal TreeNode()
:this(f_2_754_755_C(1) ,null,null)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterConstructor(2,724,776);
DynAbs.Tracing.TraceSender.TraceExitConstructor(2,724,776);
	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(2,724,776);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(2,724,776);
}
		}

internal TreeNode(int levels)
		{
			try
{DynAbs.Tracing.TraceSender.TraceEnterConstructor(2,974,1278);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,97,106);
this.value = 0;DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,127,138);
this.left = null;DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,159,171);
this.right = null;DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1011,1021);

value = 1;

if ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1025,1274) || true) && (levels <= 1)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,1025,1274);

if ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1051,1141) || true) && (levels <= 0)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,1051,1141);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1073,1141);

throw f_2_1079_1140("Number of levels must be positive no.");
DynAbs.Tracing.TraceSender.TraceExitCondition(2,1051,1141);
}
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1146,1158);

left = null;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1163,1176);

right = null;
DynAbs.Tracing.TraceSender.TraceExitCondition(2,1025,1274);
}

else

{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,1025,1274);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1199,1231);

left = f_2_1206_1230(levels - 1);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1236,1269);

right = f_2_1244_1268(levels - 1);
DynAbs.Tracing.TraceSender.TraceExitCondition(2,1025,1274);
}
DynAbs.Tracing.TraceSender.TraceExitConstructor(2,974,1278);
}catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(2,974,1278);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(2,974,1278);
}
		}

internal virtual void setChildren(TreeNode l, TreeNode r)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(2,1391,1483);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1456,1465);

left = l;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1469,1479);

right = r;
DynAbs.Tracing.TraceSender.TraceExitMethod(2,1391,1483);
	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(2,1391,1483);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(2,1391,1483);
}
		}

internal static TreeNode createTree(int levels)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterStaticMethod(2,1606,1848);

if ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1661,1844) || true) && (levels == 0)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,1661,1844);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1687,1699);

return null;
DynAbs.Tracing.TraceSender.TraceExitCondition(2,1661,1844);
}

else

{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,1661,1844);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1722,1750);

TreeNode 
n = f_2_1735_1749()
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1755,1787);

n.left = f_2_1764_1786(levels - 1);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1792,1825);

n.right = f_2_1802_1824(levels - 1);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1830,1839);

return n;
DynAbs.Tracing.TraceSender.TraceExitCondition(2,1661,1844);
}
DynAbs.Tracing.TraceSender.TraceExitStaticMethod(2,1606,1848);

TreeNode
f_2_1735_1749()
{
var return_v = new TreeNode();
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 1735, 1749);
return return_v;
}


TreeNode
f_2_1764_1786(int
levels)
{
var return_v = createTree( levels);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 1764, 1786);
return return_v;
}


TreeNode
f_2_1802_1824(int
levels)
{
var return_v = createTree( levels);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 1802, 1824);
return return_v;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(2,1606,1848);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(2,1606,1848);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

internal virtual int addTree()
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(2,2010,2189);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2048,2066);

int 
total = value
;

if ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2070,2116) || true) && (left != null)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,2070,2116);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2092,2116);

total += f_2_2101_2115(left);
DynAbs.Tracing.TraceSender.TraceExitCondition(2,2070,2116);
}

if ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2120,2168) || true) && (right != null)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,2120,2168);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2143,2168);

total += f_2_2152_2167(right);
DynAbs.Tracing.TraceSender.TraceExitCondition(2,2120,2168);
}
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2172,2185);

return total;
DynAbs.Tracing.TraceSender.TraceExitMethod(2,2010,2189);

int
f_2_2101_2115(TreeNode
this_param)
{
var return_v = this_param.addTree();
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 2101, 2115);
return return_v;
}


int
f_2_2152_2167(TreeNode
this_param)
{
var return_v = this_param.addTree();
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 2152, 2167);
return return_v;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(2,2010,2189);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(2,2010,2189);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

static TreeNode()
{
DynAbs.Tracing.TraceSender.TraceEnterStaticConstructor(2,56,2192);
DynAbs.Tracing.TraceSender.TraceExitStaticConstructor(2,56,2192);

DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(2,56,2192);
}

		int ___ignore_me___=DynAbs.Tracing.TraceSender.TraceBeforeConstructor(2,56,2192);

static int
f_2_605_606_C(int
i)
{
var return_v = i;
DynAbs.Tracing.TraceSender.TraceBaseCall(2, 553, 621);
return return_v;
}


static int
f_2_754_755_C(int
i)
{
var return_v = i;
DynAbs.Tracing.TraceSender.TraceBaseCall(2, 724, 776);
return return_v;
}


static System.Exception
f_2_1079_1140(string
message)
{
var return_v = new System.Exception( message);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 1079, 1140);
return return_v;
}


static TreeNode
f_2_1206_1230(int
levels)
{
var return_v = new TreeNode( levels);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 1206, 1230);
return return_v;
}


static TreeNode
f_2_1244_1268(int
levels)
{
var return_v = new TreeNode( levels);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 1244, 1268);
return return_v;
}

}
