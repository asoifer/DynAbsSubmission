using System;
using System.Collections.Generic;
using System.Text;
public class ENode
{
public double value;

public ENode next;

public ENode[] toNodes;

public ENode[] fromNodes;

public double[] coeffs;

public int fromCount;

public int fromLength;

public ENode(int degree)
		{
			try
{DynAbs.Tracing.TraceSender.TraceEnterConstructor(3,991,1237);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,307,312);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,378,382);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,465,472);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,557,566);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,643,649);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,715,724);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,852,862);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,1023,1060);

value = f_3_1031_1059();
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,1109,1137);

toNodes = new ENode[degree];
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,1145,1157);

next = null;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,1161,1178);

fromNodes = null;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,1182,1196);

coeffs = null;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,1200,1214);

fromCount = 0;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,1218,1233);

fromLength = 0;
DynAbs.Tracing.TraceSender.TraceExitConstructor(3,991,1237);
}catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(3,991,1237);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(3,991,1237);
}
		}

public static ENode[] fillTable(int size, int degree)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterStaticMethod(3,1514,1858);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,1575,1607);

ENode[] 
table = new ENode[size]
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,1613,1648);

ENode 
prevNode = f_3_1630_1647(degree)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,1652,1672);

table[0] = prevNode;
try {DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,1685,1690);
		for (int 
i = 1
; (DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,1676,1837) || true) && (i < size)
; DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,1702,1705)
,i++,DynAbs.Tracing.TraceSender.TraceExitCondition(3,1676,1837)) 

{DynAbs.Tracing.TraceSender.TraceEnterCondition(3,1676,1837);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,1718,1752);

ENode 
curNode = f_3_1734_1751(degree)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,1758,1777);

table[i] = curNode;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,1783,1807);

prevNode.next = curNode;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,1813,1832);

prevNode = curNode;
}
}catch(System.Exception) { DynAbs.Tracing.TraceSender.TraceExitLoopByException(3,1,162);
 throw; }finally{DynAbs.Tracing.TraceSender.TraceExitLoop(3,1,162);
}DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,1841,1854);

return table;
DynAbs.Tracing.TraceSender.TraceExitStaticMethod(3,1514,1858);

ENode
f_3_1630_1647(int
degree)
{
var return_v = new ENode( degree);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 1630, 1647);
return return_v;
}


ENode
f_3_1734_1751(int
degree)
{
var return_v = new ENode( degree);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 1734, 1751);
return return_v;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(3,1514,1858);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(3,1514,1858);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

public void makeUniqueNeighbors(ENode[] nodeTable)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(3,2186,2959);
try {DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,2252,2262);
		for(int 
filled = 0
; (DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,2244,2955) || true) && (filled < f_3_2273_2287(toNodes))
; DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,2289,2297)
,filled++,DynAbs.Tracing.TraceSender.TraceExitCondition(3,2244,2955))

{DynAbs.Tracing.TraceSender.TraceEnterCondition(3,2244,2955);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,2308,2314);

int 
k
=default(int);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,2319,2342);

ENode 
otherNode = null
;
{try {
do

{DynAbs.Tracing.TraceSender.TraceEnterCondition(3,2349,2757);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,2417,2452);

int 
index = f_3_2429_2451()
;

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,2458,2493) || true) && (index < 0)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(3,2458,2493);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,2478,2493);

index = -index;
DynAbs.Tracing.TraceSender.TraceExitCondition(3,2458,2493);
}
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,2499,2532);

index = index % f_3_2515_2531(nodeTable);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,2601,2630);

otherNode = nodeTable[index];
try {
				for(DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,2642,2647)
,k = 0; (DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,2638,2732) || true) && (k < filled)
; DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,2661,2664)
,k++,DynAbs.Tracing.TraceSender.TraceExitCondition(3,2638,2732))

{DynAbs.Tracing.TraceSender.TraceEnterCondition(3,2638,2732);

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,2679,2725) || true) && (otherNode == toNodes[filled])
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(3,2679,2725);
DynAbs.Tracing.TraceSender.TraceBreak(3,2719,2725);

break;
DynAbs.Tracing.TraceSender.TraceExitCondition(3,2679,2725);
}
}
}catch(System.Exception) { DynAbs.Tracing.TraceSender.TraceExitLoopByException(3,1,95);
 throw; }finally{DynAbs.Tracing.TraceSender.TraceExitLoop(3,1,95);
}DynAbs.Tracing.TraceSender.TraceExitCondition(3,2349,2757);
}
while((DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,2349,2757) || true) && (k < filled)
);
}catch(System.Exception) { DynAbs.Tracing.TraceSender.TraceExitLoopByException(3,2349,2757);
 throw; }finally{DynAbs.Tracing.TraceSender.TraceExitLoop(3,2349,2757);
}}DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,2826,2854);

toNodes[filled] = otherNode;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,2904,2950);

otherNode.fromCount = otherNode.fromCount + 1;
}
}catch(System.Exception) { DynAbs.Tracing.TraceSender.TraceExitLoopByException(3,1,712);
 throw; }finally{DynAbs.Tracing.TraceSender.TraceExitLoop(3,1,712);
}DynAbs.Tracing.TraceSender.TraceExitMethod(3,2186,2959);

int
f_3_2273_2287(ENode[]
this_param)
{
var return_v = this_param.Length;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(3, 2273, 2287);
return return_v;
}


int
f_3_2429_2451()
{
var return_v = RandomGenerator.Next();
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 2429, 2451);
return return_v;
}


int
f_3_2515_2531(ENode[]
this_param)
{
var return_v = this_param.Length;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(3, 2515, 2531);
return return_v;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(3,2186,2959);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(3,2186,2959);
}
		}

public void makeFromNodes()
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(3,3253,3393);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,3288,3321);

fromNodes = new ENode[fromCount];
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,3358,3389);

coeffs = new double[fromCount];
DynAbs.Tracing.TraceSender.TraceExitMethod(3,3253,3393);
	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(3,3253,3393);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(3,3253,3393);
}
		}

public void updateFromNodes()
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(3,3497,3770);
try {DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,3542,3547);
		for(int 
i = 0
; (DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,3534,3766) || true) && (i < f_3_3553_3572(this.toNodes))
; DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,3574,3577)
,++i,DynAbs.Tracing.TraceSender.TraceExitCondition(3,3534,3766))

{DynAbs.Tracing.TraceSender.TraceEnterCondition(3,3534,3766);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,3588,3622);

ENode 
otherNode = this.toNodes[i]
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,3627,3662);

int 
count = otherNode.fromLength++
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,3667,3701);

otherNode.fromNodes[count] = this;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,3706,3761);

otherNode.coeffs[count] = f_3_3732_3760();
}
}catch(System.Exception) { DynAbs.Tracing.TraceSender.TraceExitLoopByException(3,1,233);
 throw; }finally{DynAbs.Tracing.TraceSender.TraceExitLoop(3,1,233);
}DynAbs.Tracing.TraceSender.TraceExitMethod(3,3497,3770);

int
f_3_3553_3572(ENode[]
this_param)
{
var return_v = this_param.Length;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(3, 3553, 3572);
return return_v;
}


double
f_3_3732_3760()
{
var return_v = RandomGenerator.NextDouble();
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 3732, 3760);
return return_v;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(3,3497,3770);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(3,3497,3770);
}
		}

public void computeNewValue()
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(3,3887,4007);
try {DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,3932,3937);
		for(int 
i = 0
; (DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,3924,4003) || true) && (i < fromCount)
; DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,3954,3957)
,i++,DynAbs.Tracing.TraceSender.TraceExitCondition(3,3924,4003))

{DynAbs.Tracing.TraceSender.TraceEnterCondition(3,3924,4003);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,3963,4003);

value -= coeffs[i] * fromNodes[i].value;
}
}catch(System.Exception) { DynAbs.Tracing.TraceSender.TraceExitLoopByException(3,1,80);
 throw; }finally{DynAbs.Tracing.TraceSender.TraceExitLoop(3,1,80);
}DynAbs.Tracing.TraceSender.TraceExitMethod(3,3887,4007);
	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(3,3887,4007);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(3,3887,4007);
}
		}

public string toString()
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(3,4131,4221);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,4163,4217);

return "value " + DynAbs.Tracing.TraceSender.TraceInvocationWrapper(() => (value).ToString(),3,4181,4186)+ ", from_count " + DynAbs.Tracing.TraceSender.TraceInvocationWrapper(() => (fromCount).ToString(),3,4207,4216);
DynAbs.Tracing.TraceSender.TraceExitMethod(3,4131,4221);
	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(3,4131,4221);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(3,4131,4221);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

static ENode()
{
DynAbs.Tracing.TraceSender.TraceEnterStaticConstructor(3,225,4224);
DynAbs.Tracing.TraceSender.TraceExitStaticConstructor(3,225,4224);

DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(3,225,4224);
}

		int ___ignore_me___=DynAbs.Tracing.TraceSender.TraceBeforeConstructor(3,225,4224);

static double
f_3_1031_1059()
{
var return_v = RandomGenerator.NextDouble();
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 1031, 1059);
return return_v;
}

}
