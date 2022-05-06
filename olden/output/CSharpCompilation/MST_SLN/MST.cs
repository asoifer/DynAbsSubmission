using System;
public class MST
{
private static int vertices ;

private static bool printResult ;

private static bool printMsgs ;

public static void Main(string[] args)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterStaticMethod(3,767,1752);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,813,832);

f_3_813_831(args);

if ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,840,924) || true) && (printMsgs)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(3,840,924);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,859,924);

f_3_859_923(f_3_859_877(), "Making graph of size " + DynAbs.Tracing.TraceSender.TraceInvocationWrapper(() => (vertices).ToString(),3,914,922));
DynAbs.Tracing.TraceSender.TraceExitCondition(3,840,924);
}
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,928,961);

var 
start0 = f_3_941_960()
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,965,999);

Graph 
graph = f_3_979_998(vertices)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,1003,1034);

var 
end0 = f_3_1014_1033()
;

if ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,1042,1114) || true) && (printMsgs)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(3,1042,1114);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,1061,1114);

f_3_1061_1113(f_3_1061_1079(), "About to compute MST");
DynAbs.Tracing.TraceSender.TraceExitCondition(3,1042,1114);
}
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,1118,1151);

var 
start1 = f_3_1131_1150()
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,1155,1194);

int 
dist = f_3_1166_1193(graph, vertices)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,1198,1229);

var 
end1 = f_3_1209_1228()
;

if ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,1237,1324) || true) && (printResult ||(DynAbs.Tracing.TraceSender.Expression_False(3, 1241, 1265)||printMsgs))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(3,1237,1324);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,1271,1324);

f_3_1271_1323(f_3_1271_1289(), "MST has cost " + DynAbs.Tracing.TraceSender.TraceInvocationWrapper(() => (dist).ToString(),3,1318,1322));
DynAbs.Tracing.TraceSender.TraceExitCondition(3,1237,1324);
}

if ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,1332,1670) || true) && (printMsgs)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(3,1332,1670);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,1356,1459);

f_3_1356_1458(f_3_1356_1374(), "Build graph time " + DynAbs.Tracing.TraceSender.TraceInvocationWrapper(() => ((f_3_1408_1447(f_3_1408_1429(ref end0, start0))) / 1000.0).ToString(),3,1407,1457));
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,1464,1563);

f_3_1464_1562(f_3_1464_1482(), "Compute time " + DynAbs.Tracing.TraceSender.TraceInvocationWrapper(() => ((f_3_1512_1551(f_3_1512_1533(ref end1, start1))) / 1000.0).ToString(),3,1511,1561));
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,1568,1665);

f_3_1568_1664(f_3_1568_1586(), "Total time " + DynAbs.Tracing.TraceSender.TraceInvocationWrapper(() => ((f_3_1614_1653(f_3_1614_1635(ref end1, start0))) / 1000.0).ToString(),3,1613,1663));
DynAbs.Tracing.TraceSender.TraceExitCondition(3,1332,1670);
}
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,1682,1710);

var 
slicingVariable1 = dist
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,1714,1748);

f_3_1714_1747("Done!");
DynAbs.Tracing.TraceSender.TraceExitStaticMethod(3,767,1752);

int
f_3_813_831(string[]
args)
{
parseCmdLine( args);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 813, 831);
return 0;
}


System.IO.TextWriter
f_3_859_877()
{
var return_v = 			System.Console.Out;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(3, 859, 877);
return return_v;
}


int
f_3_859_923(System.IO.TextWriter
this_param,string
value)
{
this_param.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 859, 923);
return 0;
}


System.DateTime
f_3_941_960()
{
var return_v = System.DateTime.Now;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(3, 941, 960);
return return_v;
}


Graph
f_3_979_998(int
numvert)
{
var return_v = new Graph( numvert);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 979, 998);
return return_v;
}


System.DateTime
f_3_1014_1033()
{
var return_v = System.DateTime.Now;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(3, 1014, 1033);
return return_v;
}


System.IO.TextWriter
f_3_1061_1079()
{
var return_v = 			System.Console.Out;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(3, 1061, 1079);
return return_v;
}


int
f_3_1061_1113(System.IO.TextWriter
this_param,string
value)
{
this_param.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 1061, 1113);
return 0;
}


System.DateTime
f_3_1131_1150()
{
var return_v = System.DateTime.Now;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(3, 1131, 1150);
return return_v;
}


int
f_3_1166_1193(Graph
graph,int
numvert)
{
var return_v = computeMST( graph, numvert);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 1166, 1193);
return return_v;
}


System.DateTime
f_3_1209_1228()
{
var return_v = System.DateTime.Now;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(3, 1209, 1228);
return return_v;
}


System.IO.TextWriter
f_3_1271_1289()
{
var return_v = 			System.Console.Out;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(3, 1271, 1289);
return return_v;
}


int
f_3_1271_1323(System.IO.TextWriter
this_param,string
value)
{
this_param.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 1271, 1323);
return 0;
}


System.IO.TextWriter
f_3_1356_1374()
{
var return_v = 			System.Console.Out;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(3, 1356, 1374);
return return_v;
}


System.TimeSpan
f_3_1408_1429(ref System.DateTime
this_param,System.DateTime
value)
{
var return_v = this_param.Subtract( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 1408, 1429);
return return_v;
}


double
f_3_1408_1447(System.TimeSpan
this_param)
{
var return_v = this_param.TotalMilliseconds;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(3, 1408, 1447);
return return_v;
}


int
f_3_1356_1458(System.IO.TextWriter
this_param,string
value)
{
this_param.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 1356, 1458);
return 0;
}


System.IO.TextWriter
f_3_1464_1482()
{
var return_v = 			System.Console.Out;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(3, 1464, 1482);
return return_v;
}


System.TimeSpan
f_3_1512_1533(ref System.DateTime
this_param,System.DateTime
value)
{
var return_v = this_param.Subtract( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 1512, 1533);
return return_v;
}


double
f_3_1512_1551(System.TimeSpan
this_param)
{
var return_v = this_param.TotalMilliseconds;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(3, 1512, 1551);
return return_v;
}


int
f_3_1464_1562(System.IO.TextWriter
this_param,string
value)
{
this_param.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 1464, 1562);
return 0;
}


System.IO.TextWriter
f_3_1568_1586()
{
var return_v = 			System.Console.Out;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(3, 1568, 1586);
return return_v;
}


System.TimeSpan
f_3_1614_1635(ref System.DateTime
this_param,System.DateTime
value)
{
var return_v = this_param.Subtract( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 1614, 1635);
return return_v;
}


double
f_3_1614_1653(System.TimeSpan
this_param)
{
var return_v = this_param.TotalMilliseconds;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(3, 1614, 1653);
return return_v;
}


int
f_3_1568_1664(System.IO.TextWriter
this_param,string
value)
{
this_param.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 1568, 1664);
return 0;
}


int
f_3_1714_1747(string
value)
{
System.Console.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 1714, 1747);
return 0;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(3,767,1752);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(3,767,1752);
}
		}

internal static int computeMST(Graph graph, int numvert)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterStaticMethod(3,1970,2471);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,2034,2047);

int 
cost = 0
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,2079,2115);

Vertex 
inserted = f_3_2097_2114(graph)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,2119,2148);

Vertex 
tmp = f_3_2132_2147(inserted)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,2152,2171);

MyVertexList = tmp;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,2175,2185);

numvert--;
try {
while ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,2237,2451) || true) && (numvert != 0)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(3,2237,2451);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,2315,2355);

BlueReturn 
br = f_3_2331_2354(inserted)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,2360,2384);

inserted = f_3_2371_2383(br);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,2389,2413);

int 
dist = f_3_2400_2412(br)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,2418,2428);

numvert--;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,2433,2446);

cost += dist;
DynAbs.Tracing.TraceSender.TraceExitCondition(3,2237,2451);
}
}catch(System.Exception) { DynAbs.Tracing.TraceSender.TraceExitLoopByException(3,2237,2451);
 throw; }finally{DynAbs.Tracing.TraceSender.TraceExitLoop(3,2237,2451);
}DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,2455,2467);

return cost;
DynAbs.Tracing.TraceSender.TraceExitStaticMethod(3,1970,2471);

Vertex
f_3_2097_2114(Graph
this_param)
{
var return_v = this_param.firstNode();
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 2097, 2114);
return return_v;
}


Vertex
f_3_2132_2147(Vertex
this_param)
{
var return_v = this_param.Next();
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 2132, 2147);
return return_v;
}


BlueReturn
f_3_2331_2354(Vertex
inserted)
{
var return_v = doAllBlueRule( inserted);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 2331, 2354);
return return_v;
}


Vertex
f_3_2371_2383(BlueReturn
this_param)
{
var return_v = this_param.getVert();
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 2371, 2383);
return return_v;
}


int
f_3_2400_2412(BlueReturn
this_param)
{
var return_v = this_param.getDist();
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 2400, 2412);
return return_v;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(3,1970,2471);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(3,1970,2471);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

private static BlueReturn BlueRule(Vertex inserted, Vertex vlist)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterStaticMethod(3,2476,3762);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,2549,2586);

BlueReturn 
retval = f_3_2569_2585()
;

if ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,2594,2669) || true) && (vlist == null)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(3,2594,2669);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,2622,2645);

f_3_2622_2644(			retval, 999999);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,2650,2664);

return retval;
DynAbs.Tracing.TraceSender.TraceExitCondition(3,2594,2669);
}
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,2677,2697);

Vertex 
prev = vlist
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,2701,2723);

f_3_2701_2722(		retval, vlist);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,2727,2759);

f_3_2727_2758(		retval, f_3_2742_2757(vlist));
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,2763,2798);

Hashtable 
hash = f_3_2780_2797(vlist)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,2802,2832);

object 
o = f_3_2813_2831(hash, inserted)
;

if ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,2836,3037) || true) && (o != null)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(3,2836,3037);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,2860,2880);

int 
dist = ((int)o)
;

if ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,2885,2981) || true) && (dist < f_3_2896_2912(retval))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(3,2885,2981);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,2925,2948);

f_3_2925_2947(				vlist, dist);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,2954,2975);

f_3_2954_2974(				retval, dist);
DynAbs.Tracing.TraceSender.TraceExitCondition(3,2885,2981);
}
DynAbs.Tracing.TraceSender.TraceExitCondition(3,2836,3037);
}

else

{DynAbs.Tracing.TraceSender.TraceEnterCondition(3,2836,3037);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,2999,3037);

f_3_2999_3036("Not found");
DynAbs.Tracing.TraceSender.TraceExitCondition(3,2836,3037);
}
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,3045,3059);

int 
count = 0
;
try {DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,3134,3152);
		// We are guaranteed that inserted is not first in list
		for (Vertex 
tmp = f_3_3140_3152(vlist)
; (DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,3122,3740) || true) && (tmp != null)
; DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,3167,3177)
,prev = tmp,DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,3179,3195)
,tmp = f_3_3185_3195(tmp),DynAbs.Tracing.TraceSender.TraceExitCondition(3,3122,3740))

{DynAbs.Tracing.TraceSender.TraceEnterCondition(3,3122,3740);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,3206,3214);

count++;

if ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,3219,3735) || true) && (tmp == inserted)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(3,3219,3735);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,3251,3276);

Vertex 
next = f_3_3265_3275(tmp)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,3282,3301);

f_3_3282_3300(				prev, next);
DynAbs.Tracing.TraceSender.TraceExitCondition(3,3219,3735);
}

else

{DynAbs.Tracing.TraceSender.TraceEnterCondition(3,3219,3735);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,3328,3351);

hash = f_3_3335_3350(tmp);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,3357,3383);

int 
dist2 = f_3_3369_3382(tmp)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,3389,3412);

o = f_3_3393_3411(hash, inserted);

if ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,3418,3618) || true) && (o != null)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(3,3418,3618);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,3446,3466);

int 
dist = ((int)o)
;

if ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,3473,3556) || true) && (dist < dist2)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(3,3473,3556);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,3506,3527);

f_3_3506_3526(						tmp, dist);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,3535,3548);

dist2 = dist;
DynAbs.Tracing.TraceSender.TraceExitCondition(3,3473,3556);
}
DynAbs.Tracing.TraceSender.TraceExitCondition(3,3418,3618);
}

else

{DynAbs.Tracing.TraceSender.TraceEnterCondition(3,3418,3618);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,3580,3618);

f_3_3580_3617("Not found");
DynAbs.Tracing.TraceSender.TraceExitCondition(3,3418,3618);
}

if ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,3630,3729) || true) && (dist2 < f_3_3642_3658(retval))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(3,3630,3729);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,3673,3693);

f_3_3673_3692(					retval, tmp);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,3700,3722);

f_3_3700_3721(					retval, dist2);
DynAbs.Tracing.TraceSender.TraceExitCondition(3,3630,3729);
}
DynAbs.Tracing.TraceSender.TraceExitCondition(3,3219,3735);
}
}
}catch(System.Exception) { DynAbs.Tracing.TraceSender.TraceExitLoopByException(3,1,619);
 throw; }finally{DynAbs.Tracing.TraceSender.TraceExitLoop(3,1,619);
}DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,3744,3758);

return retval;
DynAbs.Tracing.TraceSender.TraceExitStaticMethod(3,2476,3762);

BlueReturn
f_3_2569_2585()
{
var return_v = new BlueReturn();
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 2569, 2585);
return return_v;
}


int
f_3_2622_2644(BlueReturn
this_param,int
d)
{
this_param.setDist( d);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 2622, 2644);
return 0;
}


int
f_3_2701_2722(BlueReturn
this_param,Vertex
v)
{
this_param.setVert( v);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 2701, 2722);
return 0;
}


int
f_3_2742_2757(Vertex
this_param)
{
var return_v = this_param.Mindist();
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 2742, 2757);
return return_v;
}


int
f_3_2727_2758(BlueReturn
this_param,int
d)
{
this_param.setDist( d);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 2727, 2758);
return 0;
}


Hashtable
f_3_2780_2797(Vertex
this_param)
{
var return_v = this_param.Neighbors();
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 2780, 2797);
return return_v;
}


object
f_3_2813_2831(Hashtable
this_param,Vertex
key)
{
var return_v = this_param.get( (object)key);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 2813, 2831);
return return_v;
}


int
f_3_2896_2912(BlueReturn
this_param)
{
var return_v = this_param.getDist();
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 2896, 2912);
return return_v;
}


int
f_3_2925_2947(Vertex
this_param,int
m)
{
this_param.setMindist( m);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 2925, 2947);
return 0;
}


int
f_3_2954_2974(BlueReturn
this_param,int
d)
{
this_param.setDist( d);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 2954, 2974);
return 0;
}


int
f_3_2999_3036(string
value)
{
System.Console.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 2999, 3036);
return 0;
}


Vertex
f_3_3140_3152(Vertex
this_param)
{
var return_v = this_param.Next();
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 3140, 3152);
return return_v;
}


Vertex
f_3_3185_3195(Vertex
this_param)
{
var return_v = this_param.Next();
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 3185, 3195);
return return_v;
}


Vertex
f_3_3265_3275(Vertex
this_param)
{
var return_v = this_param.Next();
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 3265, 3275);
return return_v;
}


int
f_3_3282_3300(Vertex
this_param,Vertex
v)
{
this_param.SetNext( v);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 3282, 3300);
return 0;
}


Hashtable
f_3_3335_3350(Vertex
this_param)
{
var return_v = this_param.Neighbors();
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 3335, 3350);
return return_v;
}


int
f_3_3369_3382(Vertex
this_param)
{
var return_v = this_param.Mindist();
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 3369, 3382);
return return_v;
}


object
f_3_3393_3411(Hashtable
this_param,Vertex
key)
{
var return_v = this_param.get( (object)key);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 3393, 3411);
return return_v;
}


int
f_3_3506_3526(Vertex
this_param,int
m)
{
this_param.setMindist( m);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 3506, 3526);
return 0;
}


int
f_3_3580_3617(string
value)
{
System.Console.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 3580, 3617);
return 0;
}


int
f_3_3642_3658(BlueReturn
this_param)
{
var return_v = this_param.getDist();
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 3642, 3658);
return return_v;
}


int
f_3_3673_3692(BlueReturn
this_param,Vertex
v)
{
this_param.setVert( v);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 3673, 3692);
return 0;
}


int
f_3_3700_3721(BlueReturn
this_param,int
d)
{
this_param.setDist( d);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 3700, 3721);
return 0;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(3,2476,3762);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(3,2476,3762);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

private static Vertex MyVertexList ;

private static BlueReturn doAllBlueRule(Vertex inserted)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterStaticMethod(3,3814,3995);

if ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,3878,3947) || true) && (inserted == MyVertexList)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(3,3878,3947);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,3912,3947);

MyVertexList = f_3_3927_3946(MyVertexList);
DynAbs.Tracing.TraceSender.TraceExitCondition(3,3878,3947);
}
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,3951,3991);

return f_3_3958_3990(inserted, MyVertexList);
DynAbs.Tracing.TraceSender.TraceExitStaticMethod(3,3814,3995);

Vertex
f_3_3927_3946(Vertex
this_param)
{
var return_v = this_param.Next();
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 3927, 3946);
return return_v;
}


BlueReturn
f_3_3958_3990(Vertex
inserted,Vertex
vlist)
{
var return_v = BlueRule( inserted, vlist);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 3958, 3990);
return return_v;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(3,3814,3995);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(3,3814,3995);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

private static void parseCmdLine(string[] args)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterStaticMethod(3,4093,4701);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,4148,4158);

int 
i = 0
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,4162,4173);

string 
arg
=default(string);
try {
while ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,4177,4662) || true) && (i < f_3_4188_4199(args)&&(DynAbs.Tracing.TraceSender.Expression_True(3, 4184, 4226)&&f_3_4203_4226(args[i], "-")))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(3,4177,4662);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,4237,4253);

arg = args[i++];

if ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,4258,4657) || true) && (f_3_4262_4278(arg, "-v"))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(3,4258,4657);

if ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,4291,4459) || true) && (i < f_3_4299_4310(args))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(3,4291,4459);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,4325,4370);

vertices = f_3_4336_4369(args[i++]);
DynAbs.Tracing.TraceSender.TraceExitCondition(3,4291,4459);
}

else

{DynAbs.Tracing.TraceSender.TraceEnterCondition(3,4291,4459);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,4394,4459);

throw f_3_4400_4458("-v requires the number of vertices");
DynAbs.Tracing.TraceSender.TraceExitCondition(3,4291,4459);
}
DynAbs.Tracing.TraceSender.TraceExitCondition(3,4258,4657);
}

else 
{DynAbs.Tracing.TraceSender.TraceEnterCondition(3,4258,4657);

if ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,4475,4657) || true) && (f_3_4479_4495(arg, "-p"))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(3,4475,4657);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,4508,4527);

printResult = true;
DynAbs.Tracing.TraceSender.TraceExitCondition(3,4475,4657);
}

else 
{DynAbs.Tracing.TraceSender.TraceEnterCondition(3,4475,4657);

if ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,4544,4657) || true) && (f_3_4548_4564(arg, "-m"))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(3,4544,4657);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,4577,4594);

printMsgs = true;
DynAbs.Tracing.TraceSender.TraceExitCondition(3,4544,4657);
}

else 
{DynAbs.Tracing.TraceSender.TraceEnterCondition(3,4544,4657);

if ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,4610,4657) || true) && (f_3_4614_4630(arg, "-h"))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(3,4610,4657);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,4643,4651);

f_3_4643_4650();
DynAbs.Tracing.TraceSender.TraceExitCondition(3,4610,4657);
}
DynAbs.Tracing.TraceSender.TraceExitCondition(3,4544,4657);
}
DynAbs.Tracing.TraceSender.TraceExitCondition(3,4475,4657);
}
DynAbs.Tracing.TraceSender.TraceExitCondition(3,4258,4657);
}
DynAbs.Tracing.TraceSender.TraceExitCondition(3,4177,4662);
}
}catch(System.Exception) { DynAbs.Tracing.TraceSender.TraceExitLoopByException(3,4177,4662);
 throw; }finally{DynAbs.Tracing.TraceSender.TraceExitLoop(3,4177,4662);
}
if ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,4666,4697) || true) && (vertices == 0)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(3,4666,4697);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,4689,4697);

f_3_4689_4696();
DynAbs.Tracing.TraceSender.TraceExitCondition(3,4666,4697);
}
DynAbs.Tracing.TraceSender.TraceExitStaticMethod(3,4093,4701);

int
f_3_4188_4199(string[]
this_param)
{
var return_v = this_param.Length ;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(3, 4188, 4199);
return return_v;
}


bool
f_3_4203_4226(string
this_param,string
value)
{
var return_v = this_param.StartsWith( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 4203, 4226);
return return_v;
}


bool
f_3_4262_4278(string
this_param,string
value)
{
var return_v = this_param.Equals( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 4262, 4278);
return return_v;
}


int
f_3_4299_4310(string[]
this_param)
{
var return_v = this_param.Length;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(3, 4299, 4310);
return return_v;
}


int
f_3_4336_4369(string
value)
{
var return_v = System.Convert.ToInt32( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 4336, 4369);
return return_v;
}


System.Exception
f_3_4400_4458(string
message)
{
var return_v = new System.Exception( message);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 4400, 4458);
return return_v;
}


bool
f_3_4479_4495(string
this_param,string
value)
{
var return_v = this_param.Equals( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 4479, 4495);
return return_v;
}


bool
f_3_4548_4564(string
this_param,string
value)
{
var return_v = this_param.Equals( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 4548, 4564);
return return_v;
}


bool
f_3_4614_4630(string
this_param,string
value)
{
var return_v = this_param.Equals( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 4614, 4630);
return return_v;
}


int
f_3_4643_4650()
{
usage();
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 4643, 4650);
return 0;
}


int
f_3_4689_4696()
{
usage();
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 4689, 4696);
return 0;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(3,4093,4701);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(3,4093,4701);
}
		}

private static void usage()
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterStaticMethod(3,4778,5205);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,4813,4890);

f_3_4813_4889(f_3_4813_4833(), "usage: java MST -v <levels> [-p] [-m] [-h]");
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,4894,4971);

f_3_4894_4970(f_3_4894_4914(), "    -v the number of vertices in the graph");
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,4975,5036);

f_3_4975_5035(f_3_4975_4995(), "    -p (print the result>)");
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,5040,5110);

f_3_5040_5109(f_3_5040_5060(), "    -m (print informative messages)");
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,5114,5170);

f_3_5114_5169(f_3_5114_5134(), "    -h (this message)");
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,5174,5201);

f_3_5174_5200(0);
DynAbs.Tracing.TraceSender.TraceExitStaticMethod(3,4778,5205);

System.IO.TextWriter
f_3_4813_4833()
{
var return_v = 		System.Console.Error;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(3, 4813, 4833);
return return_v;
}


int
f_3_4813_4889(System.IO.TextWriter
this_param,string
value)
{
this_param.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 4813, 4889);
return 0;
}


System.IO.TextWriter
f_3_4894_4914()
{
var return_v = 		System.Console.Error;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(3, 4894, 4914);
return return_v;
}


int
f_3_4894_4970(System.IO.TextWriter
this_param,string
value)
{
this_param.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 4894, 4970);
return 0;
}


System.IO.TextWriter
f_3_4975_4995()
{
var return_v = 		System.Console.Error;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(3, 4975, 4995);
return return_v;
}


int
f_3_4975_5035(System.IO.TextWriter
this_param,string
value)
{
this_param.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 4975, 5035);
return 0;
}


System.IO.TextWriter
f_3_5040_5060()
{
var return_v = 		System.Console.Error;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(3, 5040, 5060);
return return_v;
}


int
f_3_5040_5109(System.IO.TextWriter
this_param,string
value)
{
this_param.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 5040, 5109);
return 0;
}


System.IO.TextWriter
f_3_5114_5134()
{
var return_v = 		System.Console.Error;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(3, 5114, 5134);
return return_v;
}


int
f_3_5114_5169(System.IO.TextWriter
this_param,string
value)
{
this_param.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 5114, 5169);
return 0;
}


int
f_3_5174_5200(int
exitCode)
{
System.Environment.Exit( exitCode);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 5174, 5200);
return 0;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(3,4778,5205);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(3,4778,5205);
}
		}

public MST()
{
DynAbs.Tracing.TraceSender.TraceEnterConstructor(3,431,5208);
DynAbs.Tracing.TraceSender.TraceExitConstructor(3,431,5208);

DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(3,431,5208);
}


static MST()
{
DynAbs.Tracing.TraceSender.TraceEnterStaticConstructor(3,431,5208);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,528,540);
vertices = 0;DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,622,641);
printResult = false;DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,744,761);
printMsgs = false;DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,3789,3808);
MyVertexList = null;DynAbs.Tracing.TraceSender.TraceExitStaticConstructor(3,431,5208);

DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(3,431,5208);
}

		int ___ignore_me___=DynAbs.Tracing.TraceSender.TraceBeforeConstructor(3,431,5208);
}
internal class BlueReturn
{
private Vertex vert;

private int dist;

public virtual Vertex getVert()
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(3,5334,5389);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,5373,5385);

return vert;
DynAbs.Tracing.TraceSender.TraceExitMethod(3,5334,5389);
	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(3,5334,5389);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(3,5334,5389);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

public virtual void setVert(Vertex v)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(3,5394,5452);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,5439,5448);

vert = v;
DynAbs.Tracing.TraceSender.TraceExitMethod(3,5394,5452);
	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(3,5394,5452);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(3,5394,5452);
}
		}

public virtual int getDist()
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(3,5457,5509);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,5493,5505);

return dist;
DynAbs.Tracing.TraceSender.TraceExitMethod(3,5457,5509);
	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(3,5457,5509);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(3,5457,5509);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

public virtual void setDist(int d)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(3,5514,5569);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,5556,5565);

dist = d;
DynAbs.Tracing.TraceSender.TraceExitMethod(3,5514,5569);
	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(3,5514,5569);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(3,5514,5569);
}
		}

public BlueReturn()
{
DynAbs.Tracing.TraceSender.TraceEnterConstructor(3,5258,5572);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,5304,5308);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,5324,5328);
DynAbs.Tracing.TraceSender.TraceExitConstructor(3,5258,5572);

DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(3,5258,5572);
}


static BlueReturn()
{
DynAbs.Tracing.TraceSender.TraceEnterStaticConstructor(3,5258,5572);
DynAbs.Tracing.TraceSender.TraceExitStaticConstructor(3,5258,5572);

DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(3,5258,5572);
}

		int ___ignore_me___=DynAbs.Tracing.TraceSender.TraceBeforeConstructor(3,5258,5572);
}
