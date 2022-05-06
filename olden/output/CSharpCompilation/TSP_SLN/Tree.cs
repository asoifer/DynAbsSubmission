
using System;
public class Tree
{
public int sz;

public double x;

public double y;

public Tree left;

public Tree right;

public Tree next;

public Tree prev;

private static double  M_E2  ;

private static double  M_E3  ;

private static double  M_E6  ;

private static double  M_E12 ;

public Tree(int size, double x, double y, Tree l, Tree r)
		{
			try
{DynAbs.Tracing.TraceSender.TraceEnterConstructor(2,1376,1544);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,238,240);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,323,324);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,345,346);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,410,414);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,473,478);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,633,637);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,789,793);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1441,1451);

sz = size;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1455,1466);

this.x = x;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1470,1481);

this.y = y;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1485,1494);

left = l;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1498,1508);

right = r;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1512,1524);

next = null;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1528,1540);

prev = null;
DynAbs.Tracing.TraceSender.TraceExitConstructor(2,1376,1544);
}catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(2,1376,1544);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(2,1376,1544);
}
		}

public double distance(Tree b)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(2,1725,1833);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1763,1829);

return (f_2_1771_1827((x - b.x) * (x - b.x) + (y - b.y) * (y - b.y)));
DynAbs.Tracing.TraceSender.TraceExitMethod(2,1725,1833);

double
f_2_1771_1827(double
d)
{
var return_v = Math.Sqrt( d);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 1771, 1827);
return return_v;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(2,1725,1833);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(2,1725,1833);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

public Tree makeList()
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(2,2006,2593);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2042,2054);

Tree 
myleft
=default(Tree);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2058,2071);

Tree 
myright
=default(Tree);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2075,2086);

Tree 
tleft
=default(Tree);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2090,2102);

Tree 
tright
=default(Tree);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2106,2125);

Tree 
retval = this
;

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2155,2228) || true) && (left != null)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,2155,2228);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2176,2201);

myleft = f_2_2185_2200(left);
DynAbs.Tracing.TraceSender.TraceExitCondition(2,2155,2228);
}

else

{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,2155,2228);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2214,2228);

myleft = null;
DynAbs.Tracing.TraceSender.TraceExitCondition(2,2155,2228);
}

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2259,2336) || true) && (right != null)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,2259,2336);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2281,2308);

myright = f_2_2291_2307(right);
DynAbs.Tracing.TraceSender.TraceExitCondition(2,2259,2336);
}

else

{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,2259,2336);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2321,2336);

myright = null;
DynAbs.Tracing.TraceSender.TraceExitCondition(2,2259,2336);
}

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2342,2416) || true) && (myright != null)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,2342,2416);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2371,2388);

retval = myright;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2393,2411);

right.next = this;
DynAbs.Tracing.TraceSender.TraceExitCondition(2,2342,2416);
}

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2422,2553) || true) && (myleft != null)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,2422,2553);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2450,2466);

retval = myleft;

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2471,2548) || true) && (myright != null)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,2471,2548);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2496,2516);

left.next = myright;
DynAbs.Tracing.TraceSender.TraceExitCondition(2,2471,2548);
}

else

{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,2471,2548);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2531,2548);

left.next = this;
DynAbs.Tracing.TraceSender.TraceExitCondition(2,2471,2548);
}
DynAbs.Tracing.TraceSender.TraceExitCondition(2,2422,2553);
}
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2557,2569);

next = null;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2575,2589);

return retval;
DynAbs.Tracing.TraceSender.TraceExitMethod(2,2006,2593);

Tree
f_2_2185_2200(Tree
this_param)
{
var return_v = this_param.makeList();
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 2185, 2200);
return return_v;
}


Tree
f_2_2291_2307(Tree
this_param)
{
var return_v = this_param.makeList();
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 2291, 2307);
return return_v;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(2,2006,2593);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(2,2006,2593);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

public void reverse()
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(2,2706,3108);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2735,2757);

Tree 
prev = this.prev
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2761,2778);

prev.next = null;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2782,2799);

this.prev = null;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2803,2820);

Tree 
back = this
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2824,2840);

Tree 
tmp = this
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2887,2897);

Tree 
next
=default(Tree);
try {DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2911,2924);
		for (Tree 
t = this.next
; (DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2901,3027) || true) && (t != null)
; DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2937,2945)
,back = t,DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2947,2955)
,t = next,DynAbs.Tracing.TraceSender.TraceExitCondition(2,2901,3027)) 

{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,2901,3027);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2968,2982);

next = t.next;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2988,3002);

t.next = back;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,3008,3022);

back.prev = t;
}
}catch(System.Exception) { DynAbs.Tracing.TraceSender.TraceExitLoopByException(2,1,127);
 throw; }finally{DynAbs.Tracing.TraceSender.TraceExitLoop(2,1,127);
}DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,3068,3084);

tmp.next = prev;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,3088,3104);

prev.prev = tmp;
DynAbs.Tracing.TraceSender.TraceExitMethod(2,2706,3108);
	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(2,2706,3108);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(2,2706,3108);
}
		}

public Tree conquer()
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(2,3209,4323);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,3269,3289);

Tree 
t = f_2_3278_3288(this)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,3322,3337);

Tree 
cycle = t
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,3341,3352);

t = t.next;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,3356,3375);

cycle.next = cycle;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,3379,3398);

cycle.prev = cycle;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,3437,3449);

Tree 
donext
=default(Tree);
try {		for (; (DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,3453,4300) || true) && (t != null)
; DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,3471,3481)
,t = donext,DynAbs.Tracing.TraceSender.TraceExitCondition(2,3453,4300)) 

{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,3453,4300);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,3493,3509);

donext = t.next;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,3548,3565);

Tree 
min = cycle
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,3570,3605);

double 
mindist = f_2_3587_3604(t, cycle)
;
try {DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,3619,3635);
			for(Tree 
tmp = cycle.next
; (DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,3610,3791) || true) && (tmp != cycle)
; DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,3651,3665)
,tmp = tmp.next,DynAbs.Tracing.TraceSender.TraceExitCondition(2,3610,3791))

{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,3610,3791);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,3678,3708);

double 
test = f_2_3692_3707(tmp, t)
;

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,3714,3785) || true) && (test < mindist)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,3714,3785);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,3746,3761);

mindist = test;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,3768,3778);

min = tmp;
DynAbs.Tracing.TraceSender.TraceExitCondition(2,3714,3785);
}
}
}catch(System.Exception) { DynAbs.Tracing.TraceSender.TraceExitLoopByException(2,1,182);
 throw; }finally{DynAbs.Tracing.TraceSender.TraceExitLoop(2,1,182);
}DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,3798,3819);

Tree 
next = min.next
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,3824,3845);

Tree 
prev = min.prev
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,3852,3890);

double 
mintonext = f_2_3871_3889(min, next)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,3895,3933);

double 
mintoprev = f_2_3914_3932(min, prev)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,3938,3972);

double 
ttonext = f_2_3955_3971(t, next)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,3977,4011);

double 
ttoprev = f_2_3994_4010(t, prev)
;

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,4018,4295) || true) && ((ttoprev - mintoprev) < (ttonext - mintonext))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,4018,4295);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,4118,4132);

prev.next = t;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,4138,4151);

t.next = min;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,4157,4171);

t.prev = prev;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,4177,4190);

min.prev = t;
DynAbs.Tracing.TraceSender.TraceExitCondition(2,4018,4295);
}

else

{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,4018,4295);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,4217,4231);

next.prev = t;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,4237,4251);

t.next = next;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,4257,4270);

min.next = t;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,4276,4289);

t.prev = min;
DynAbs.Tracing.TraceSender.TraceExitCondition(2,4018,4295);
}
}
}catch(System.Exception) { DynAbs.Tracing.TraceSender.TraceExitLoopByException(2,1,848);
 throw; }finally{DynAbs.Tracing.TraceSender.TraceExitLoop(2,1,848);
}DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,4306,4319);

return cycle;
DynAbs.Tracing.TraceSender.TraceExitMethod(2,3209,4323);

Tree
f_2_3278_3288(Tree
this_param)
{
var return_v = this_param.makeList();
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 3278, 3288);
return return_v;
}


double
f_2_3587_3604(Tree
this_param,Tree
b)
{
var return_v = this_param.distance( b);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 3587, 3604);
return return_v;
}


double
f_2_3692_3707(Tree
this_param,Tree
b)
{
var return_v = this_param.distance( b);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 3692, 3707);
return return_v;
}


double
f_2_3871_3889(Tree
this_param,Tree
b)
{
var return_v = this_param.distance( b);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 3871, 3889);
return return_v;
}


double
f_2_3914_3932(Tree
this_param,Tree
b)
{
var return_v = this_param.distance( b);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 3914, 3932);
return return_v;
}


double
f_2_3955_3971(Tree
this_param,Tree
b)
{
var return_v = this_param.distance( b);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 3955, 3971);
return return_v;
}


double
f_2_3994_4010(Tree
this_param,Tree
b)
{
var return_v = this_param.distance( b);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 3994, 4010);
return return_v;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(2,3209,4323);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(2,3209,4323);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

public Tree merge(Tree a, Tree b)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(2,4457,7615);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,4537,4550);

Tree 
min = a
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,4554,4583);

double 
mindist = f_2_4571_4582(this, a)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,4587,4600);

Tree 
tmp = a
;
try {		for(DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,4608,4618)
,a = a.next; (DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,4604,4767) || true) && (a != tmp)
; DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,4630,4640)
,a = a.next,DynAbs.Tracing.TraceSender.TraceExitCondition(2,4604,4767))

{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,4604,4767);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,4651,4682);

double 
temp_test = f_2_4670_4681(this, a)
;

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,4687,4762) || true) && (temp_test < mindist)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,4687,4762);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,4722,4742);

mindist = temp_test;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,4748,4756);

min = a;
DynAbs.Tracing.TraceSender.TraceExitCondition(2,4687,4762);
}
}
}catch(System.Exception) { DynAbs.Tracing.TraceSender.TraceExitLoopByException(2,1,164);
 throw; }finally{DynAbs.Tracing.TraceSender.TraceExitLoop(2,1,164);
}DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,4773,4794);

Tree 
next = min.next
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,4798,4819);

Tree 
prev = min.prev
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,4823,4861);

double 
mintonext = f_2_4842_4860(min, next)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,4865,4903);

double 
mintoprev = f_2_4884_4902(min, prev)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,4907,4939);

double 
ttonext = f_2_4924_4938(this, next)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,4943,4975);

double 
ttoprev = f_2_4960_4974(this, prev)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,4981,4989);

Tree 
p1
=default(Tree);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,4993,5001);

Tree 
n1
=default(Tree);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,5005,5018);

double 
tton1
=default(double);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,5022,5035);

double 
ttop1
=default(double);

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,5039,5340) || true) && ((ttoprev - mintoprev) < (ttonext - mintonext))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,5039,5340);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,5139,5149);

p1 = prev;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,5154,5163);

n1 = min;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,5168,5184);

tton1 = mindist;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,5189,5205);

ttop1 = ttoprev;
DynAbs.Tracing.TraceSender.TraceExitCondition(2,5039,5340);
}

else

{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,5039,5340);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,5269,5278);

p1 = min;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,5283,5293);

n1 = next;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,5298,5314);

ttop1 = mindist;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,5319,5335);

tton1 = ttonext;
DynAbs.Tracing.TraceSender.TraceExitCondition(2,5039,5340);
}
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,5386,5394);

min = b;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,5398,5420);

mindist = f_2_5408_5419(this, b);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,5424,5432);

tmp = b;
try {		for(DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,5440,5450)
,b = b.next; (DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,5436,5599) || true) && (b != tmp)
; DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,5462,5472)
,b = b.next,DynAbs.Tracing.TraceSender.TraceExitCondition(2,5436,5599))

{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,5436,5599);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,5483,5514);

double 
temp_test = f_2_5502_5513(this, b)
;

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,5519,5594) || true) && (temp_test < mindist)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,5519,5594);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,5554,5574);

mindist = temp_test;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,5580,5588);

min = b;
DynAbs.Tracing.TraceSender.TraceExitCondition(2,5519,5594);
}
}
}catch(System.Exception) { DynAbs.Tracing.TraceSender.TraceExitLoopByException(2,1,164);
 throw; }finally{DynAbs.Tracing.TraceSender.TraceExitLoop(2,1,164);
}DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,5605,5621);

next = min.next;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,5625,5641);

prev = min.prev;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,5645,5676);

mintonext = f_2_5657_5675(min, next);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,5680,5711);

mintoprev = f_2_5692_5710(min, prev);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,5715,5745);

ttonext = f_2_5725_5744(this, next);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,5749,5779);

ttoprev = f_2_5759_5778(this, prev);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,5785,5793);

Tree 
p2
=default(Tree);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,5797,5805);

Tree 
n2
=default(Tree);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,5809,5822);

double 
tton2
=default(double);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,5826,5839);

double 
ttop2
=default(double);

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,5843,6144) || true) && ((ttoprev - mintoprev) < (ttonext - mintonext))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,5843,6144);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,5943,5953);

p2 = prev;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,5958,5967);

n2 = min;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,5972,5988);

tton2 = mindist;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,5993,6009);

ttop2 = ttoprev;
DynAbs.Tracing.TraceSender.TraceExitCondition(2,5843,6144);
}

else

{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,5843,6144);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,6073,6082);

p2 = min;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,6087,6097);

n2 = next;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,6102,6118);

ttop2 = mindist;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,6123,6139);

tton2 = ttonext;
DynAbs.Tracing.TraceSender.TraceExitCondition(2,5843,6144);
}
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,6287,6319);

double 
n1ton2 = f_2_6303_6318(n1, n2)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,6323,6355);

double 
n1top2 = f_2_6339_6354(n1, p2)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,6359,6391);

double 
p1ton2 = f_2_6375_6390(p1, n2)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,6395,6427);

double 
p1top2 = f_2_6411_6426(p1, p2)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,6433,6466);

mindist = ttop1 + ttop2 + n1ton2;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,6470,6485);

int 
choice = 1
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,6491,6528);

double 
test = ttop1 + tton2 + n1top2
;

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,6532,6596) || true) && (test < mindist)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,6532,6596);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,6560,6571);

choice = 2;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,6576,6591);

mindist = test;
DynAbs.Tracing.TraceSender.TraceExitCondition(2,6532,6596);
}
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,6602,6632);

test = tton1 + ttop2 + p1ton2;

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,6636,6700) || true) && (test < mindist)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,6636,6700);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,6664,6675);

choice = 3;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,6680,6695);

mindist = test;
DynAbs.Tracing.TraceSender.TraceExitCondition(2,6636,6700);
}
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,6706,6736);

test = tton1 + tton2 + p1top2;

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,6740,6774) || true) && (test < mindist)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,6740,6774);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,6763,6774);

choice = 4;
DynAbs.Tracing.TraceSender.TraceExitCondition(2,6740,6774);
}
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,6780,7595);

switch (choice)
		{

case 1:
DynAbs.Tracing.TraceSender.TraceEnterCondition(2,6780,7595);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,6864,6877);

f_2_6864_6876(				// 1:p1,this this,p2 n2,n1 -- reverse 2!
				n2);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,6883,6898);

p1.next = this;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,6904,6919);

this.prev = p1;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,6925,6940);

this.next = p2;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,6946,6961);

p2.prev = this;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,6967,6980);

n2.next = n1;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,6986,6999);

n1.prev = n2;
DynAbs.Tracing.TraceSender.TraceBreak(2,7005,7011);

break;
DynAbs.Tracing.TraceSender.TraceExitCondition(2,6780,7595);

case 2:
DynAbs.Tracing.TraceSender.TraceEnterCondition(2,6780,7595);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,7067,7082);

p1.next = this;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,7088,7103);

this.prev = p1;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,7109,7124);

this.next = n2;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,7130,7145);

n2.prev = this;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,7151,7164);

p2.next = n1;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,7170,7183);

n1.prev = p2;
DynAbs.Tracing.TraceSender.TraceBreak(2,7189,7195);

break;
DynAbs.Tracing.TraceSender.TraceExitCondition(2,6780,7595);

case 3:
DynAbs.Tracing.TraceSender.TraceEnterCondition(2,6780,7595);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,7251,7266);

p2.next = this;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,7272,7287);

this.prev = p2;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,7293,7308);

this.next = n1;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,7314,7329);

n1.prev = this;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,7335,7348);

p1.next = n2;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,7354,7367);

n2.prev = p1;
DynAbs.Tracing.TraceSender.TraceBreak(2,7373,7379);

break;
DynAbs.Tracing.TraceSender.TraceExitCondition(2,6780,7595);

case 4:
DynAbs.Tracing.TraceSender.TraceEnterCondition(2,6780,7595);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,7443,7456);

f_2_7443_7455(				// 4:n1,this this,n2 p2,p1 -- reverse 1!
				n1);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,7462,7477);

n1.next = this;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,7483,7498);

this.prev = n1;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,7504,7519);

this.next = n2;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,7525,7540);

n2.prev = this;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,7546,7559);

p2.next = p1;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,7565,7578);

p1.prev = p2;
DynAbs.Tracing.TraceSender.TraceBreak(2,7584,7590);

break;
DynAbs.Tracing.TraceSender.TraceExitCondition(2,6780,7595);
		}
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,7599,7611);

return this;
DynAbs.Tracing.TraceSender.TraceExitMethod(2,4457,7615);

double
f_2_4571_4582(Tree
this_param,Tree
b)
{
var return_v = this_param.distance( b);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 4571, 4582);
return return_v;
}


double
f_2_4670_4681(Tree
this_param,Tree
b)
{
var return_v = this_param.distance( b);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 4670, 4681);
return return_v;
}


double
f_2_4842_4860(Tree
this_param,Tree
b)
{
var return_v = this_param.distance( b);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 4842, 4860);
return return_v;
}


double
f_2_4884_4902(Tree
this_param,Tree
b)
{
var return_v = this_param.distance( b);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 4884, 4902);
return return_v;
}


double
f_2_4924_4938(Tree
this_param,Tree
b)
{
var return_v = this_param.distance( b);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 4924, 4938);
return return_v;
}


double
f_2_4960_4974(Tree
this_param,Tree
b)
{
var return_v = this_param.distance( b);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 4960, 4974);
return return_v;
}


double
f_2_5408_5419(Tree
this_param,Tree
b)
{
var return_v = this_param.distance( b);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 5408, 5419);
return return_v;
}


double
f_2_5502_5513(Tree
this_param,Tree
b)
{
var return_v = this_param.distance( b);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 5502, 5513);
return return_v;
}


double
f_2_5657_5675(Tree
this_param,Tree
b)
{
var return_v = this_param.distance( b);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 5657, 5675);
return return_v;
}


double
f_2_5692_5710(Tree
this_param,Tree
b)
{
var return_v = this_param.distance( b);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 5692, 5710);
return return_v;
}


double
f_2_5725_5744(Tree
this_param,Tree
b)
{
var return_v = this_param.distance( b);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 5725, 5744);
return return_v;
}


double
f_2_5759_5778(Tree
this_param,Tree
b)
{
var return_v = this_param.distance( b);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 5759, 5778);
return return_v;
}


double
f_2_6303_6318(Tree
this_param,Tree
b)
{
var return_v = this_param.distance( b);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 6303, 6318);
return return_v;
}


double
f_2_6339_6354(Tree
this_param,Tree
b)
{
var return_v = this_param.distance( b);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 6339, 6354);
return return_v;
}


double
f_2_6375_6390(Tree
this_param,Tree
b)
{
var return_v = this_param.distance( b);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 6375, 6390);
return return_v;
}


double
f_2_6411_6426(Tree
this_param,Tree
b)
{
var return_v = this_param.distance( b);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 6411, 6426);
return return_v;
}


int
f_2_6864_6876(Tree
this_param)
{
this_param.reverse();
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 6864, 6876);
return 0;
}


int
f_2_7443_7455(Tree
this_param)
{
this_param.reverse();
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 7443, 7455);
return 0;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(2,4457,7615);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(2,4457,7615);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

public Tree tsp(int sz)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(2,7756,7936);

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,7787,7826) || true) && (this.sz <= sz)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,7787,7826);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,7809,7826);

return f_2_7816_7825(this);
DynAbs.Tracing.TraceSender.TraceExitCondition(2,7787,7826);
}
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,7832,7860);

Tree 
leftval = f_2_7847_7859(left, sz)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,7864,7894);

Tree 
rightval = f_2_7880_7893(right, sz)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,7900,7932);

return f_2_7907_7931(this, leftval, rightval);
DynAbs.Tracing.TraceSender.TraceExitMethod(2,7756,7936);

Tree
f_2_7816_7825(Tree
this_param)
{
var return_v = this_param.conquer();
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 7816, 7825);
return return_v;
}


Tree
f_2_7847_7859(Tree
this_param,int
sz)
{
var return_v = this_param.tsp( sz);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 7847, 7859);
return return_v;
}


Tree
f_2_7880_7893(Tree
this_param,int
sz)
{
var return_v = this_param.tsp( sz);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 7880, 7893);
return return_v;
}


Tree
f_2_7907_7931(Tree
this_param,Tree
a,Tree
b)
{
var return_v = this_param.merge( a, b);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 7907, 7931);
return return_v;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(2,7756,7936);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(2,7756,7936);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

public void printVisitOrder()
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(2,8158,8353);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,8195,8239);

f_2_8195_8238("x = " + DynAbs.Tracing.TraceSender.TraceInvocationWrapper(() => (x).ToString(),2,8222,8223)+ " y = " + DynAbs.Tracing.TraceSender.TraceInvocationWrapper(() => (y).ToString(),2,8236,8237));
try {DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,8252,8262);
		for(Tree 
tmp = next
; (DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,8243,8349) || true) && (tmp != this)
; DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,8277,8291)
,tmp = tmp.next,DynAbs.Tracing.TraceSender.TraceExitCondition(2,8243,8349))

{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,8243,8349);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,8297,8349);

f_2_8297_8348("x = " + DynAbs.Tracing.TraceSender.TraceInvocationWrapper(() => (tmp.x).ToString(),2,8324,8329)+ " y = " + DynAbs.Tracing.TraceSender.TraceInvocationWrapper(() => (tmp.y).ToString(),2,8342,8347));
}
}catch(System.Exception) { DynAbs.Tracing.TraceSender.TraceExitLoopByException(2,1,107);
 throw; }finally{DynAbs.Tracing.TraceSender.TraceExitLoop(2,1,107);
}DynAbs.Tracing.TraceSender.TraceExitMethod(2,8158,8353);

int
f_2_8195_8238(string
value)
{
Console.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 8195, 8238);
return 0;
}


int
f_2_8297_8348(string
value)
{
Console.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 8297, 8348);
return 0;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(2,8158,8353);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(2,8158,8353);
}
		}

private static double median(double min, double max, int n)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterStaticMethod(2,8627,9117);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,8731,8771);

double 
t = f_2_8742_8770()
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,8777,8791);

double 
retval
=default(double);

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,8795,8965) || true) && (t > 0.5)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,8795,8965);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,8811,8885);

retval = f_2_8820_8877(1.0 - (2.0 * (M_E12 - 1.0) * (t - 0.5) / M_E12))/ 12.0;
DynAbs.Tracing.TraceSender.TraceExitCondition(2,8795,8965);
}

else

{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,8795,8965);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,8898,8965);

retval = -f_2_8908_8957(1.0 - (2.0 * (M_E12 - 1.0) * t / M_E12))/ 12.0;
DynAbs.Tracing.TraceSender.TraceExitCondition(2,8795,8965);
}
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,9025,9069);

retval = (retval + 1.0) * (max - min) / 2.0;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,9073,9095);

retval = retval + min;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,9099,9113);

return retval;
DynAbs.Tracing.TraceSender.TraceExitStaticMethod(2,8627,9117);

double
f_2_8742_8770()
{
var return_v = RandomGenerator.NextDouble();
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 8742, 8770);
return return_v;
}


double
f_2_8820_8877(double
d)
{
var return_v = Math.Log( d);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 8820, 8877);
return return_v;
}


double
f_2_8908_8957(double
d)
{
var return_v = Math.Log( d);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 8908, 8957);
return return_v;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(2,8627,9117);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(2,8627,9117);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

private static double uniform(double min, double max)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterStaticMethod(2,9245,9454);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,9347,9392);

double 
retval = f_2_9363_9391()
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,9396,9426);

retval = retval * (max - min);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,9430,9450);

return retval + min;
DynAbs.Tracing.TraceSender.TraceExitStaticMethod(2,9245,9454);

double
f_2_9363_9391()
{
var return_v = RandomGenerator.NextDouble();
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 9363, 9391);
return return_v;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(2,9245,9454);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(2,9245,9454);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

public static Tree buildTree(int n, bool dir, double min_x, double max_x, double min_y, double max_y)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterStaticMethod(2,9893,10617);

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,10002,10029) || true) && (n == 0)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,10002,10029);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,10017,10029);

return null;
DynAbs.Tracing.TraceSender.TraceExitCondition(2,10002,10029);
}
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,10035,10045);

Tree 
left
=default(Tree);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,10049,10060);

Tree 
right
=default(Tree);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,10064,10073);

double 
x
=default(double);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,10077,10086);

double 
y
=default(double);

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,10090,10571) || true) && (dir)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,10090,10571);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,10107,10118);

dir = !dir;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,10123,10160);

double 
med = f_2_10136_10159(min_x, max_x, n)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,10165,10220);

left = f_2_10172_10219(n / 2, dir, min_x, med, min_y, max_y);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,10225,10281);

right = f_2_10233_10280(n / 2, dir, med, max_x, min_y, max_y);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,10286,10294);

x = med;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,10299,10325);

y = f_2_10303_10324(min_y, max_y);
DynAbs.Tracing.TraceSender.TraceExitCondition(2,10090,10571);
}

else

{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,10090,10571);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,10348,10359);

dir = !dir;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,10364,10401);

double 
med = f_2_10377_10400(min_y, max_y, n)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,10406,10461);

left = f_2_10413_10460(n / 2, dir, min_x, max_x, min_y, med);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,10466,10522);

right = f_2_10474_10521(n / 2, dir, min_x, max_x, med, max_y);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,10527,10535);

y = med;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,10540,10566);

x = f_2_10544_10565(min_x, max_x);
DynAbs.Tracing.TraceSender.TraceExitCondition(2,10090,10571);
}
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,10575,10613);

return f_2_10582_10612(n, x, y, left, right);
DynAbs.Tracing.TraceSender.TraceExitStaticMethod(2,9893,10617);

double
f_2_10136_10159(double
min,double
max,int
n)
{
var return_v = median( min, max, n);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 10136, 10159);
return return_v;
}


Tree
f_2_10172_10219(int
n,bool
dir,double
min_x,double
max_x,double
min_y,double
max_y)
{
var return_v = buildTree( n, dir, min_x, max_x, min_y, max_y);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 10172, 10219);
return return_v;
}


Tree
f_2_10233_10280(int
n,bool
dir,double
min_x,double
max_x,double
min_y,double
max_y)
{
var return_v = buildTree( n, dir, min_x, max_x, min_y, max_y);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 10233, 10280);
return return_v;
}


double
f_2_10303_10324(double
min,double
max)
{
var return_v = uniform( min, max);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 10303, 10324);
return return_v;
}


double
f_2_10377_10400(double
min,double
max,int
n)
{
var return_v = median( min, max, n);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 10377, 10400);
return return_v;
}


Tree
f_2_10413_10460(int
n,bool
dir,double
min_x,double
max_x,double
min_y,double
max_y)
{
var return_v = buildTree( n, dir, min_x, max_x, min_y, max_y);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 10413, 10460);
return return_v;
}


Tree
f_2_10474_10521(int
n,bool
dir,double
min_x,double
max_x,double
min_y,double
max_y)
{
var return_v = buildTree( n, dir, min_x, max_x, min_y, max_y);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 10474, 10521);
return return_v;
}


double
f_2_10544_10565(double
min,double
max)
{
var return_v = uniform( min, max);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 10544, 10565);
return return_v;
}


Tree
f_2_10582_10612(int
size,double
x,double
y,Tree
l,Tree
r)
{
var return_v = new Tree( size, x, y, l, r);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 10582, 10612);
return return_v;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(2,9893,10617);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(2,9893,10617);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

static Tree()
{
DynAbs.Tracing.TraceSender.TraceEnterStaticConstructor(2,137,10620);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,863,892);
M_E2 = 7.3890560989306502274;DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,922,953);
M_E3 = 20.08553692318766774179;DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,983,1015);
M_E6 = 403.42879349273512264299;DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1045,1080);
M_E12 = 162754.79141900392083592475;DynAbs.Tracing.TraceSender.TraceExitStaticConstructor(2,137,10620);

DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(2,137,10620);
}

		int ___ignore_me___=DynAbs.Tracing.TraceSender.TraceBeforeConstructor(2,137,10620);
}
