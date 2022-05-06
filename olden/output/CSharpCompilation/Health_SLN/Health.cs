
using System;
public class Health
{
private static int maxLevel ;

private static int maxTime ;

private static int seed ;

private static bool printResult ;

private static bool printMsgs ;

public static void Main(String[] args)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterStaticMethod(1,1058,2355);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1104,1123);

f_1_1104_1122(args);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1129,1162);

var 
start0 = f_1_1142_1161()
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1166,1232);

Village 
top = f_1_1180_1231(maxLevel, 0, null, seed)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1236,1267);

var 
end0 = f_1_1247_1266()
;

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1273,1356) || true) && (printMsgs)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,1273,1356);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1291,1356);

f_1_1291_1355("Columbian Health Care Simulator\nWorking...");
DynAbs.Tracing.TraceSender.TraceExitCondition(1,1273,1356);
}
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1362,1395);

var 
start1 = f_1_1375_1394()
;
try {DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1407,1412);
		for(int 
i = 0
; (DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1399,1525) || true) && (i < maxTime)
; DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1427,1430)
,i++,DynAbs.Tracing.TraceSender.TraceExitCondition(1,1399,1525))

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,1399,1525);

if ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1441,1500) || true) && ((i % 50) == 0 &&(DynAbs.Tracing.TraceSender.Expression_True(1, 1445, 1471)&&printMsgs))
) 

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,1441,1500);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1479,1500);

f_1_1479_1499(i);
DynAbs.Tracing.TraceSender.TraceExitCondition(1,1441,1500);
}
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1505,1520);

f_1_1505_1519(			top);
}
}catch(System.Exception) { DynAbs.Tracing.TraceSender.TraceExitLoopByException(1,1,127);
 throw; }finally{DynAbs.Tracing.TraceSender.TraceExitLoop(1,1,127);
}DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1531,1560);

Results 
r = f_1_1543_1559(top)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1566,1597);

var 
end1 = f_1_1577_1596()
;

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1605,1871) || true) && (printResult)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,1605,1871);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1630,1693);

f_1_1630_1692("# People treated: " + DynAbs.Tracing.TraceSender.TraceInvocationWrapper(() => ((int)r.totalPatients).ToString(),1,1671,1691));
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1698,1773);

f_1_1698_1772("Avg. length of stay: " + DynAbs.Tracing.TraceSender.TraceInvocationWrapper(() => (r.totalTime / r.totalPatients).ToString(),1,1742,1771));
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1778,1866);

f_1_1778_1865("Avg. # of hospitals visited: " + DynAbs.Tracing.TraceSender.TraceInvocationWrapper(() => (r.totalHospitals / r.totalPatients).ToString(),1,1830,1864));
DynAbs.Tracing.TraceSender.TraceExitCondition(1,1605,1871);
}

if ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1875,2168) || true) && (printMsgs)
) 

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,1875,2168);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1901,1985);

f_1_1901_1984("Build Time " + DynAbs.Tracing.TraceSender.TraceInvocationWrapper(() => ((f_1_1936_1975(f_1_1936_1957(ref end0, start0)))/1000.0).ToString(),1,1935,1983));
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1991,2073);

f_1_1991_2072("Run Time " + DynAbs.Tracing.TraceSender.TraceInvocationWrapper(() => ((f_1_2024_2063(f_1_2024_2045(ref end1, start1)))/1000.0).ToString(),1,2023,2071));
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2079,2163);

f_1_2079_2162("Total Time " + DynAbs.Tracing.TraceSender.TraceInvocationWrapper(() => ((f_1_2114_2153(f_1_2114_2135(ref end1, start0)))/1000.0).ToString(),1,2113,2161));
DynAbs.Tracing.TraceSender.TraceExitCondition(1,1875,2168);
}
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2180,2220);

var 
slicingVariable1 = r.totalHospitals
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2230,2269);

var 
slicingVariable2 = r.totalPatients
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2279,2314);

var 
slicingVariable3 = r.totalTime
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2324,2351);

f_1_2324_2350("Done!");
DynAbs.Tracing.TraceSender.TraceExitStaticMethod(1,1058,2355);

int
f_1_1104_1122(string[]
args)
{
parseCmdLine( args);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 1104, 1122);
return 0;
}


System.DateTime
f_1_1142_1161()
{
var return_v = System.DateTime.Now;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(1, 1142, 1161);
return return_v;
}


Village
f_1_1180_1231(int
level,int
label,Village
back,int
seed)
{
var return_v = Village.createVillage( level, label, back, seed);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 1180, 1231);
return return_v;
}


System.DateTime
f_1_1247_1266()
{
var return_v = System.DateTime.Now;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(1, 1247, 1266);
return return_v;
}


int
f_1_1291_1355(string
value)
{
Console.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 1291, 1355);
return 0;
}


System.DateTime
f_1_1375_1394()
{
var return_v = System.DateTime.Now;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(1, 1375, 1394);
return return_v;
}


int
f_1_1479_1499(int
value)
{
Console.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 1479, 1499);
return 0;
}


List
f_1_1505_1519(Village
this_param)
{
var return_v = this_param.simulate();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 1505, 1519);
return return_v;
}


Results
f_1_1543_1559(Village
this_param)
{
var return_v = this_param.getResults();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 1543, 1559);
return return_v;
}


System.DateTime
f_1_1577_1596()
{
var return_v = System.DateTime.Now;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(1, 1577, 1596);
return return_v;
}


int
f_1_1630_1692(string
value)
{
Console.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 1630, 1692);
return 0;
}


int
f_1_1698_1772(string
value)
{
Console.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 1698, 1772);
return 0;
}


int
f_1_1778_1865(string
value)
{
Console.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 1778, 1865);
return 0;
}


System.TimeSpan
f_1_1936_1957(ref System.DateTime
this_param,System.DateTime
value)
{
var return_v = this_param.Subtract( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 1936, 1957);
return return_v;
}


double
f_1_1936_1975(System.TimeSpan
this_param)
{
var return_v = this_param.TotalMilliseconds;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(1, 1936, 1975);
return return_v;
}


int
f_1_1901_1984(string
value)
{
Console.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 1901, 1984);
return 0;
}


System.TimeSpan
f_1_2024_2045(ref System.DateTime
this_param,System.DateTime
value)
{
var return_v = this_param.Subtract( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 2024, 2045);
return return_v;
}


double
f_1_2024_2063(System.TimeSpan
this_param)
{
var return_v = this_param.TotalMilliseconds;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(1, 2024, 2063);
return return_v;
}


int
f_1_1991_2072(string
value)
{
Console.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 1991, 2072);
return 0;
}


System.TimeSpan
f_1_2114_2135(ref System.DateTime
this_param,System.DateTime
value)
{
var return_v = this_param.Subtract( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 2114, 2135);
return return_v;
}


double
f_1_2114_2153(System.TimeSpan
this_param)
{
var return_v = this_param.TotalMilliseconds;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(1, 2114, 2153);
return return_v;
}


int
f_1_2079_2162(string
value)
{
Console.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 2079, 2162);
return 0;
}


int
f_1_2324_2350(string
value)
{
Console.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 2324, 2350);
return 0;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(1,1058,2355);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(1,1058,2355);
}
		}

private static void parseCmdLine(String[] args)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterStaticMethod(1,2360,3352);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2415,2426);

String 
arg
=default(String);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2430,2440);

int 
i = 0
;
try {
while((DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2444,3298) || true) && (i < f_1_2454_2465(args)&&(DynAbs.Tracing.TraceSender.Expression_True(1, 2450, 2492)&&f_1_2469_2492(args[i], "-")))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,2444,3298);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2503,2519);

arg = args[i++];

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2574,3293) || true) && (f_1_2577_2593(arg, "-l"))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,2574,3293);

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2606,2739) || true) && (i < f_1_2613_2624(args))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,2606,2739);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2632,2666);

maxLevel = f_1_2643_2665(args[i++]);
DynAbs.Tracing.TraceSender.TraceExitCondition(1,2606,2739);
}

else

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,2606,2739);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2683,2739);

throw f_1_2689_2738("-l requires the number of levels");
DynAbs.Tracing.TraceSender.TraceExitCondition(1,2606,2739);
}
DynAbs.Tracing.TraceSender.TraceExitCondition(1,2574,3293);
}

else 
{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,2574,3293);

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2755,3293) || true) && (f_1_2758_2774(arg, "-t"))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,2755,3293);

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2787,2917) || true) && (i < f_1_2794_2805(args))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,2787,2917);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2813,2846);

maxTime = f_1_2823_2845(args[i++]);
DynAbs.Tracing.TraceSender.TraceExitCondition(1,2787,2917);
}

else

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,2787,2917);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2863,2917);

throw f_1_2869_2916("-t requires the amount of time");
DynAbs.Tracing.TraceSender.TraceExitCondition(1,2787,2917);
}
DynAbs.Tracing.TraceSender.TraceExitCondition(1,2755,3293);
}

else 
{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,2755,3293);

if ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2933,3293) || true) && (f_1_2937_2953(arg, "-s"))
) 

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,2933,3293);

if ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2971,3096) || true) && (i < f_1_2979_2990(args))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,2971,3096);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,3000,3028);

seed = f_1_3007_3027(args[i++]);
DynAbs.Tracing.TraceSender.TraceExitCondition(1,2971,3096);
}

else

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,2971,3096);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,3048,3096);

throw f_1_3054_3095("-s requires a seed value");
DynAbs.Tracing.TraceSender.TraceExitCondition(1,2971,3096);
}
DynAbs.Tracing.TraceSender.TraceExitCondition(1,2933,3293);
}

else 
{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,2933,3293);

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,3115,3293) || true) && (f_1_3118_3134(arg, "-p"))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,3115,3293);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,3147,3166);

printResult = true;
DynAbs.Tracing.TraceSender.TraceExitCondition(1,3115,3293);
}

else 
{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,3115,3293);

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,3182,3293) || true) && (f_1_3185_3201(arg, "-m"))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,3182,3293);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,3214,3231);

printMsgs = true;
DynAbs.Tracing.TraceSender.TraceExitCondition(1,3182,3293);
}

else 
{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,3182,3293);

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,3247,3293) || true) && (f_1_3250_3266(arg, "-h"))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,3247,3293);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,3279,3287);

f_1_3279_3286();
DynAbs.Tracing.TraceSender.TraceExitCondition(1,3247,3293);
}
DynAbs.Tracing.TraceSender.TraceExitCondition(1,3182,3293);
}
DynAbs.Tracing.TraceSender.TraceExitCondition(1,3115,3293);
}
DynAbs.Tracing.TraceSender.TraceExitCondition(1,2933,3293);
}
DynAbs.Tracing.TraceSender.TraceExitCondition(1,2755,3293);
}
DynAbs.Tracing.TraceSender.TraceExitCondition(1,2574,3293);
}
DynAbs.Tracing.TraceSender.TraceExitCondition(1,2444,3298);
}
}catch(System.Exception) { DynAbs.Tracing.TraceSender.TraceExitLoopByException(1,2444,3298);
 throw; }finally{DynAbs.Tracing.TraceSender.TraceExitLoop(1,2444,3298);
}
if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,3302,3348) || true) && (maxTime == 0 ||(DynAbs.Tracing.TraceSender.Expression_False(1, 3305, 3334)||maxLevel == 0))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,3302,3348);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,3340,3348);

f_1_3340_3347();
DynAbs.Tracing.TraceSender.TraceExitCondition(1,3302,3348);
}
DynAbs.Tracing.TraceSender.TraceExitStaticMethod(1,2360,3352);

int
f_1_2454_2465(string[]
this_param)
{
var return_v = this_param.Length ;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(1, 2454, 2465);
return return_v;
}


bool
f_1_2469_2492(string
this_param,string
value)
{
var return_v = this_param.StartsWith( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 2469, 2492);
return return_v;
}


bool
f_1_2577_2593(string
this_param,string
value)
{
var return_v = this_param.Equals( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 2577, 2593);
return return_v;
}


int
f_1_2613_2624(string[]
this_param)
{
var return_v = this_param.Length;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(1, 2613, 2624);
return return_v;
}


int
f_1_2643_2665(string
s)
{
var return_v = Int32.Parse( s);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 2643, 2665);
return return_v;
}


System.Exception
f_1_2689_2738(string
message)
{
var return_v = new System.Exception( message);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 2689, 2738);
return return_v;
}


bool
f_1_2758_2774(string
this_param,string
value)
{
var return_v = this_param.Equals( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 2758, 2774);
return return_v;
}


int
f_1_2794_2805(string[]
this_param)
{
var return_v = this_param.Length;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(1, 2794, 2805);
return return_v;
}


int
f_1_2823_2845(string
s)
{
var return_v = Int32.Parse( s);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 2823, 2845);
return return_v;
}


System.Exception
f_1_2869_2916(string
message)
{
var return_v = new System.Exception( message);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 2869, 2916);
return return_v;
}


bool
f_1_2937_2953(string
this_param,string
value)
{
var return_v = this_param.Equals( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 2937, 2953);
return return_v;
}


int
f_1_2979_2990(string[]
this_param)
{
var return_v = this_param.Length;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(1, 2979, 2990);
return return_v;
}


int
f_1_3007_3027(string
s)
{
var return_v = int.Parse( s);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 3007, 3027);
return return_v;
}


System.Exception
f_1_3054_3095(string
message)
{
var return_v = new System.Exception( message);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 3054, 3095);
return return_v;
}


bool
f_1_3118_3134(string
this_param,string
value)
{
var return_v = this_param.Equals( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 3118, 3134);
return return_v;
}


bool
f_1_3185_3201(string
this_param,string
value)
{
var return_v = this_param.Equals( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 3185, 3201);
return return_v;
}


bool
f_1_3250_3266(string
this_param,string
value)
{
var return_v = this_param.Equals( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 3250, 3266);
return return_v;
}


int
f_1_3279_3286()
{
usage();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 3279, 3286);
return 0;
}


int
f_1_3340_3347()
{
usage();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 3340, 3347);
return 0;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(1,2360,3352);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(1,2360,3352);
}
		}

private static void usage()
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterStaticMethod(1,3427,3928);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,3462,3549);

f_1_3462_3548("usage: java Health -l <levels> -t <time> -s <seed> [-p] [-m] [-h]");
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,3553,3616);

f_1_3553_3615("    -l the size of the health care system");
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,3620,3678);

f_1_3620_3677("    -t the amount of simulation time");
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,3682,3738);

f_1_3682_3737("    -s a random no. generator seed");
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,3742,3786);

f_1_3742_3785("    -p (print results)");
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,3790,3846);

f_1_3790_3845("    -m (print information messages");
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,3850,3893);

f_1_3850_3892("    -h (this message)");
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,3897,3924);

f_1_3897_3923(0);
DynAbs.Tracing.TraceSender.TraceExitStaticMethod(1,3427,3928);

int
f_1_3462_3548(string
value)
{
Console.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 3462, 3548);
return 0;
}


int
f_1_3553_3615(string
value)
{
Console.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 3553, 3615);
return 0;
}


int
f_1_3620_3677(string
value)
{
Console.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 3620, 3677);
return 0;
}


int
f_1_3682_3737(string
value)
{
Console.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 3682, 3737);
return 0;
}


int
f_1_3742_3785(string
value)
{
Console.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 3742, 3785);
return 0;
}


int
f_1_3790_3845(string
value)
{
Console.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 3790, 3845);
return 0;
}


int
f_1_3850_3892(string
value)
{
Console.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 3850, 3892);
return 0;
}


int
f_1_3897_3923(int
exitCode)
{
System.Environment.Exit( exitCode);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 3897, 3923);
return 0;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(1,3427,3928);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(1,3427,3928);
}
		}

public Health()
{
DynAbs.Tracing.TraceSender.TraceEnterConstructor(1,361,3931);
DynAbs.Tracing.TraceSender.TraceExitConstructor(1,361,3931);

DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(1,361,3931);
}


static Health()
{
DynAbs.Tracing.TraceSender.TraceEnterStaticConstructor(1,361,3931);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,456,468);
maxLevel = 0;DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,559,570);
maxTime = 0;DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,651,659);
seed = 0;DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,732,751);
printResult = false;DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,833,850);
printMsgs = false;DynAbs.Tracing.TraceSender.TraceExitStaticConstructor(1,361,3931);

DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(1,361,3931);
}

		int ___ignore_me___=DynAbs.Tracing.TraceSender.TraceBeforeConstructor(1,361,3931);
}
