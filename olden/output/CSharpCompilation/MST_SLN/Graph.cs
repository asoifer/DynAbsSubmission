using System;
internal class Graph
{
private Vertex[] nodes;

private const int 
CONST_m1 = 10000
;

private const int 
CONST_b = 31415821
;

private const int 
RANGE = 2048
;

public Graph(int numvert)
		{
			try
{DynAbs.Tracing.TraceSender.TraceEnterConstructor(1,429,710);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,166,171);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,462,490);

nodes = new Vertex[numvert];
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,494,510);

Vertex 
v = null
;
try {DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,580,595);
		// the original C code creates them in reverse order 
		for (int 
i = numvert - 1
; (DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,571,684) || true) && (i >= 0)
; DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,605,608)
,i--,DynAbs.Tracing.TraceSender.TraceExitCondition(1,571,684))

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,571,684);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,619,666);

Vertex 
tmp = nodes[i] = f_1_643_665(v, numvert)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,671,679);

v = tmp;
}
}catch(System.Exception) { DynAbs.Tracing.TraceSender.TraceExitLoopByException(1,1,114);
 throw; }finally{DynAbs.Tracing.TraceSender.TraceExitLoop(1,1,114);
}DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,688,706);

f_1_688_705(this, numvert);
DynAbs.Tracing.TraceSender.TraceExitConstructor(1,429,710);
}catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(1,429,710);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(1,429,710);
}
		}

public virtual void createGraph(int numvert)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(1,866,1170);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,918,946);

nodes = new Vertex[numvert];
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,950,966);

Vertex 
v = null
;
try {DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1036,1051);
		// the original C code creates them in reverse order 
		for (int 
i = numvert - 1
; (DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1027,1140) || true) && (i >= 0)
; DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1061,1064)
,i--,DynAbs.Tracing.TraceSender.TraceExitCondition(1,1027,1140))

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,1027,1140);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1075,1122);

Vertex 
tmp = nodes[i] = f_1_1099_1121(v, numvert)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1127,1135);

v = tmp;
}
}catch(System.Exception) { DynAbs.Tracing.TraceSender.TraceExitLoopByException(1,1,114);
 throw; }finally{DynAbs.Tracing.TraceSender.TraceExitLoop(1,1,114);
}DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1148,1166);

f_1_1148_1165(this, numvert);
DynAbs.Tracing.TraceSender.TraceExitMethod(1,866,1170);

Vertex
f_1_1099_1121(Vertex
n,int
numvert)
{
var return_v = new Vertex( n, numvert);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 1099, 1121);
return return_v;
}


int
f_1_1148_1165(Graph
this_param,int
numvert)
{
this_param.addEdges( numvert);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 1148, 1165);
return 0;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(1,866,1170);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(1,866,1170);
}
		}

public virtual Vertex firstNode()
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(1,1271,1332);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1312,1328);

return nodes[0];
DynAbs.Tracing.TraceSender.TraceExitMethod(1,1271,1332);
	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(1,1271,1332);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(1,1271,1332);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

private void addEdges(int numvert)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(1,1532,1885);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1574,1589);

int 
count1 = 0
;
try {DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1605,1619);
		for (Vertex 
tmp = nodes[0]
; (DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1593,1881) || true) && (tmp != null)
; DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1634,1650)
,tmp = f_1_1640_1650(tmp),DynAbs.Tracing.TraceSender.TraceExitCondition(1,1593,1881))

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,1593,1881);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1661,1694);

Hashtable 
hash = f_1_1678_1693(tmp)
;
try {DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1708,1713);
			for (int 
i = 0
; (DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1699,1862) || true) && (i < numvert)
; DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1728,1731)
,i++,DynAbs.Tracing.TraceSender.TraceExitCondition(1,1699,1862))

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,1699,1862);

if ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1744,1856) || true) && (i != count1)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,1744,1856);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1774,1817);

int 
dist = f_1_1785_1816(this, i, count1, numvert)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1824,1849);

f_1_1824_1848(					hash, nodes[i], dist);
DynAbs.Tracing.TraceSender.TraceExitCondition(1,1744,1856);
}
}
}catch(System.Exception) { DynAbs.Tracing.TraceSender.TraceExitLoopByException(1,1,164);
 throw; }finally{DynAbs.Tracing.TraceSender.TraceExitLoop(1,1,164);
}DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1867,1876);

count1++;
}
}catch(System.Exception) { DynAbs.Tracing.TraceSender.TraceExitLoopByException(1,1,289);
 throw; }finally{DynAbs.Tracing.TraceSender.TraceExitLoop(1,1,289);
}DynAbs.Tracing.TraceSender.TraceExitMethod(1,1532,1885);

Vertex
f_1_1640_1650(Vertex
this_param)
{
var return_v = this_param.Next();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 1640, 1650);
return return_v;
}


Hashtable
f_1_1678_1693(Vertex
this_param)
{
var return_v = this_param.Neighbors();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 1678, 1693);
return return_v;
}


int
f_1_1785_1816(Graph
this_param,int
i,int
j,int
numvert)
{
var return_v = this_param.computeDist( i, j, numvert);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 1785, 1816);
return return_v;
}


int
f_1_1824_1848(Hashtable
this_param,Vertex
key,int
value)
{
this_param.put( (object)key, (object)value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 1824, 1848);
return 0;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(1,1532,1885);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(1,1532,1885);
}
		}

private int computeDist(int i, int j, int numvert)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(1,2013,2242);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2071,2080);

int 
less
=default(int);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2084,2091);

int 
gt
=default(int);

if ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2095,2185) || true) && (i < j)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,2095,2185);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2115,2124);

less = i;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2129,2136);

gt = j;
DynAbs.Tracing.TraceSender.TraceExitCondition(1,2095,2185);
}

else

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,2095,2185);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2159,2168);

less = j;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2173,2180);

gt = i;
DynAbs.Tracing.TraceSender.TraceExitCondition(1,2095,2185);
}
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2189,2238);

return (f_1_2197_2224(less * numvert + gt)% RANGE) + 1;
DynAbs.Tracing.TraceSender.TraceExitMethod(1,2013,2242);

int
f_1_2197_2224(int
seed)
{
var return_v = random( seed);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 2197, 2224);
return return_v;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(1,2013,2242);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(1,2013,2242);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

private static int mult(int p, int q)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterStaticMethod(1,2247,2491);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2292,2299);

int 
p1
=default(int);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2303,2310);

int 
p0
=default(int);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2314,2321);

int 
q1
=default(int);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2325,2332);

int 
q0
=default(int);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2336,2354);

p1 = p / CONST_m1;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2358,2376);

p0 = p % CONST_m1;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2380,2398);

q1 = q / CONST_m1;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2402,2420);

q0 = q % CONST_m1;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2424,2487);

return (((p0 * q1 + p1 * q0) % CONST_m1) * CONST_m1 + p0 * q0);
DynAbs.Tracing.TraceSender.TraceExitStaticMethod(1,2247,2491);
	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(1,2247,2491);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(1,2247,2491);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

private static int random(int seed)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterStaticMethod(1,2496,2574);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2539,2570);

return f_1_2546_2565(seed, CONST_b)+ 1;
DynAbs.Tracing.TraceSender.TraceExitStaticMethod(1,2496,2574);

int
f_1_2546_2565(int
p,int
q)
{
var return_v = mult( p, q);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 2546, 2565);
return return_v;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(1,2496,2574);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(1,2496,2574);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

static Graph()
{
DynAbs.Tracing.TraceSender.TraceEnterStaticConstructor(1,75,2577);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,243,259);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,281,299);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,321,333);
DynAbs.Tracing.TraceSender.TraceExitStaticConstructor(1,75,2577);

DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(1,75,2577);
}

		int ___ignore_me___=DynAbs.Tracing.TraceSender.TraceBeforeConstructor(1,75,2577);

static Vertex
f_1_643_665(Vertex
n,int
numvert)
{
var return_v = new Vertex( n, numvert);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 643, 665);
return return_v;
}


static int
f_1_688_705(Graph
this_param,int
numvert)
{
this_param.addEdges( numvert);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 688, 705);
return 0;
}

}
