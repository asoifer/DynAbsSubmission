using System;
public class BiGraph
{
public ENode eNodes;

public ENode hNodes;

public BiGraph(ENode e, ENode h)
		{
			try
{DynAbs.Tracing.TraceSender.TraceEnterConstructor(1,574,644);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,311,317);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,400,406);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,614,625);

eNodes = e;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,629,640);

hNodes = h;
DynAbs.Tracing.TraceSender.TraceExitConstructor(1,574,644);
}catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(1,574,644);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(1,574,644);
}
		}

public static BiGraph create(int numNodes, int numDegree, bool verbose)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterStaticMethod(1,958,2263);

if ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1076,1154) || true) && (verbose)
) 

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,1076,1154);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1094,1154);

f_1_1094_1153("making nodes (tables in orig. version)");
DynAbs.Tracing.TraceSender.TraceExitCondition(1,1076,1154);
}
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1158,1208);

var 
hTable = f_1_1171_1207(numNodes, numDegree)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1212,1262);

var 
eTable = f_1_1225_1261(numNodes, numDegree)
;

if ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1291,1355) || true) && (verbose)
) 

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,1291,1355);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1309,1355);

f_1_1309_1354("updating from and coeffs");
DynAbs.Tracing.TraceSender.TraceExitCondition(1,1291,1355);
}
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1359,1381);

var 
tNode = hTable[0]
;
try {
while ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1385,1482) || true) && (tNode != null)
) 

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,1385,1482);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1418,1452);

f_1_1418_1451(		  tNode, eTable);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1458,1477);

tNode = tNode.next;
DynAbs.Tracing.TraceSender.TraceExitCondition(1,1385,1482);
}
}catch(System.Exception) { DynAbs.Tracing.TraceSender.TraceExitLoopByException(1,1385,1482);
 throw; }finally{DynAbs.Tracing.TraceSender.TraceExitLoop(1,1385,1482);
}DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1486,1504);

tNode = eTable[0];
try {
while ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1508,1605) || true) && (tNode != null)
) 

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,1508,1605);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1541,1575);

f_1_1541_1574(		  tNode, hTable);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1581,1600);

tNode = tNode.next;
DynAbs.Tracing.TraceSender.TraceExitCondition(1,1508,1605);
}
}catch(System.Exception) { DynAbs.Tracing.TraceSender.TraceExitLoopByException(1,1508,1605);
 throw; }finally{DynAbs.Tracing.TraceSender.TraceExitLoop(1,1508,1605);
}
if ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1656,1715) || true) && (verbose)
) 

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,1656,1715);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1674,1715);

f_1_1674_1714("filling from fields");
DynAbs.Tracing.TraceSender.TraceExitCondition(1,1656,1715);
}
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1721,1739);

tNode = hTable[0];
try {
while ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1743,1828) || true) && (tNode != null)
) 

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,1743,1828);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1776,1798);

f_1_1776_1797(		  tNode);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1804,1823);

tNode = tNode.next;
DynAbs.Tracing.TraceSender.TraceExitCondition(1,1743,1828);
}
}catch(System.Exception) { DynAbs.Tracing.TraceSender.TraceExitLoopByException(1,1743,1828);
 throw; }finally{DynAbs.Tracing.TraceSender.TraceExitLoop(1,1743,1828);
}DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1832,1850);

tNode = eTable[0];
try {
while ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1854,1939) || true) && (tNode != null)
) 

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,1854,1939);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1887,1909);

f_1_1887_1908(		  tNode);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1915,1934);

tNode = tNode.next;
DynAbs.Tracing.TraceSender.TraceExitCondition(1,1854,1939);
}
}catch(System.Exception) { DynAbs.Tracing.TraceSender.TraceExitLoopByException(1,1854,1939);
 throw; }finally{DynAbs.Tracing.TraceSender.TraceExitLoop(1,1854,1939);
}DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1972,1990);

tNode = hTable[0];
try {
while ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1994,2081) || true) && (tNode != null)
) 

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,1994,2081);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2027,2051);

f_1_2027_2050(		  tNode);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2057,2076);

tNode = tNode.next;
DynAbs.Tracing.TraceSender.TraceExitCondition(1,1994,2081);
}
}catch(System.Exception) { DynAbs.Tracing.TraceSender.TraceExitLoopByException(1,1994,2081);
 throw; }finally{DynAbs.Tracing.TraceSender.TraceExitLoop(1,1994,2081);
}DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2085,2103);

tNode = eTable[0];
try {
while ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2107,2194) || true) && (tNode != null)
) 

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,2107,2194);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2140,2164);

f_1_2140_2163(		  tNode);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2170,2189);

tNode = tNode.next;
DynAbs.Tracing.TraceSender.TraceExitCondition(1,2107,2194);
}
}catch(System.Exception) { DynAbs.Tracing.TraceSender.TraceExitLoopByException(1,2107,2194);
 throw; }finally{DynAbs.Tracing.TraceSender.TraceExitLoop(1,2107,2194);
}DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2200,2246);

BiGraph 
g = f_1_2212_2245(eTable[0], hTable[0])
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2250,2259);

return g;
DynAbs.Tracing.TraceSender.TraceExitStaticMethod(1,958,2263);

int
f_1_1094_1153(string
value)
{
Console.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 1094, 1153);
return 0;
}


ENode[]
f_1_1171_1207(int
size,int
degree)
{
var return_v = ENode.fillTable( size, degree);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 1171, 1207);
return return_v;
}


ENode[]
f_1_1225_1261(int
size,int
degree)
{
var return_v = ENode.fillTable( size, degree);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 1225, 1261);
return return_v;
}


int
f_1_1309_1354(string
value)
{
Console.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 1309, 1354);
return 0;
}


int
f_1_1418_1451(ENode
this_param,ENode[]
nodeTable)
{
this_param.makeUniqueNeighbors( nodeTable);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 1418, 1451);
return 0;
}


int
f_1_1541_1574(ENode
this_param,ENode[]
nodeTable)
{
this_param.makeUniqueNeighbors( nodeTable);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 1541, 1574);
return 0;
}


int
f_1_1674_1714(string
value)
{
Console.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 1674, 1714);
return 0;
}


int
f_1_1776_1797(ENode
this_param)
{
this_param.makeFromNodes();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 1776, 1797);
return 0;
}


int
f_1_1887_1908(ENode
this_param)
{
this_param.makeFromNodes();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 1887, 1908);
return 0;
}


int
f_1_2027_2050(ENode
this_param)
{
this_param.updateFromNodes();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 2027, 2050);
return 0;
}


int
f_1_2140_2163(ENode
this_param)
{
this_param.updateFromNodes();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 2140, 2163);
return 0;
}


BiGraph
f_1_2212_2245(ENode
e,ENode
h)
{
var return_v = new BiGraph( e, h);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 2212, 2245);
return return_v;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(1,958,2263);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(1,958,2263);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

public void compute()
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(1,2384,2633);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2413,2432);

var 
tNode = eNodes
;
try {
while ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2436,2521) || true) && (tNode != null)
) 

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,2436,2521);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2468,2492);

f_1_2468_2491(			tNode);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2497,2516);

tNode = tNode.next;
DynAbs.Tracing.TraceSender.TraceExitCondition(1,2436,2521);
}
}catch(System.Exception) { DynAbs.Tracing.TraceSender.TraceExitLoopByException(1,2436,2521);
 throw; }finally{DynAbs.Tracing.TraceSender.TraceExitLoop(1,2436,2521);
}DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2525,2540);

tNode = hNodes;
try {
while ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2544,2629) || true) && (tNode != null)
) 

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,2544,2629);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2576,2600);

f_1_2576_2599(			tNode);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2605,2624);

tNode = tNode.next;
DynAbs.Tracing.TraceSender.TraceExitCondition(1,2544,2629);
}
}catch(System.Exception) { DynAbs.Tracing.TraceSender.TraceExitLoopByException(1,2544,2629);
 throw; }finally{DynAbs.Tracing.TraceSender.TraceExitLoop(1,2544,2629);
}DynAbs.Tracing.TraceSender.TraceExitMethod(1,2384,2633);

int
f_1_2468_2491(ENode
this_param)
{
this_param.computeNewValue();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 2468, 2491);
return 0;
}


int
f_1_2576_2599(ENode
this_param)
{
this_param.computeNewValue();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 2576, 2599);
return 0;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(1,2384,2633);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(1,2384,2633);
}
		}

public string toString()
		{
			try
  {
DynAbs.Tracing.TraceSender.TraceEnterMethod(1,2800,3170);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2835,2880);

var 
retval = f_1_2848_2879()
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2883,2902);

var 
tNode = eNodes
;
try {
while ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2905,3009) || true) && (tNode != null)
) 

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,2905,3009);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2935,2982);

f_1_2935_2981(		retval, "E: " + f_1_2957_2973(tNode)+ "\n");
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2986,3005);

tNode = tNode.next;
DynAbs.Tracing.TraceSender.TraceExitCondition(1,2905,3009);
}
}catch(System.Exception) { DynAbs.Tracing.TraceSender.TraceExitLoopByException(1,2905,3009);
 throw; }finally{DynAbs.Tracing.TraceSender.TraceExitLoop(1,2905,3009);
}DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,3012,3027);

tNode = hNodes;
try {
while ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,3030,3134) || true) && (tNode != null)
) 

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,3030,3134);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,3060,3107);

f_1_3060_3106(		retval, "H: " + f_1_3082_3098(tNode)+ "\n");
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,3111,3130);

tNode = tNode.next;
DynAbs.Tracing.TraceSender.TraceExitCondition(1,3030,3134);
}
}catch(System.Exception) { DynAbs.Tracing.TraceSender.TraceExitLoopByException(1,3030,3134);
 throw; }finally{DynAbs.Tracing.TraceSender.TraceExitLoop(1,3030,3134);
}DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,3140,3165);

return f_1_3147_3164(retval);
DynAbs.Tracing.TraceSender.TraceExitMethod(1,2800,3170);

System.Text.StringBuilder
f_1_2848_2879()
{
var return_v = new System.Text.StringBuilder();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 2848, 2879);
return return_v;
}


string
f_1_2957_2973(ENode
this_param)
{
var return_v = this_param.toString();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 2957, 2973);
return return_v;
}


System.Text.StringBuilder
f_1_2935_2981(System.Text.StringBuilder
this_param,string
value)
{
var return_v = this_param.Append( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 2935, 2981);
return return_v;
}


string
f_1_3082_3098(ENode
this_param)
{
var return_v = this_param.toString();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 3082, 3098);
return return_v;
}


System.Text.StringBuilder
f_1_3060_3106(System.Text.StringBuilder
this_param,string
value)
{
var return_v = this_param.Append( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 3060, 3106);
return return_v;
}


string
f_1_3147_3164(System.Text.StringBuilder
this_param)
{
var return_v = this_param.ToString();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 3147, 3164);
return return_v;
}

  }
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(1,2800,3170);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(1,2800,3170);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

static BiGraph()
{
DynAbs.Tracing.TraceSender.TraceEnterStaticConstructor(1,212,3173);
DynAbs.Tracing.TraceSender.TraceExitStaticConstructor(1,212,3173);

DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(1,212,3173);
}

		int ___ignore_me___=DynAbs.Tracing.TraceSender.TraceBeforeConstructor(1,212,3173);
}
