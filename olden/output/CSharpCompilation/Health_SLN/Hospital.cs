
using System;
public class Hospital
{
private int  personnel;

private int  freePersonnel;

private int  numWaitingPatients;

private List waiting;

private List assess;

private List inside;

private List up;

public Hospital(int level)
		{
			try
{DynAbs.Tracing.TraceSender.TraceEnterConstructor(2,309,526);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,140,149);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,166,179);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,196,214);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,231,238);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,255,261);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,278,284);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,301,303);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,343,372);

personnel = 1 << (level - 1);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,376,402);

freePersonnel = personnel;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,406,429);

numWaitingPatients = 0;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,433,454);

waiting = f_2_443_453();
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,458,478);

assess = f_2_467_477();
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,482,502);

inside = f_2_491_501();
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,506,522);

up = f_2_511_521();
DynAbs.Tracing.TraceSender.TraceExitConstructor(2,309,526);
}catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(2,309,526);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(2,309,526);
}
		}

public void putInHospital(Patient p)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(2,606,856);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,650,679);

int 
num = p.hospitalsVisited
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,683,704);

p.hospitalsVisited++;

if ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,708,852) || true) && (freePersonnel > 0)
) 

{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,708,852);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,742,758);

freePersonnel--;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,764,778);

f_2_764_777(		  assess, p);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,784,799);

p.timeLeft = 3;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,805,817);

p.time += 3;
DynAbs.Tracing.TraceSender.TraceExitCondition(2,708,852);
}

else

{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,708,852);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,837,852);

f_2_837_851(		  waiting, p);
DynAbs.Tracing.TraceSender.TraceExitCondition(2,708,852);
}
DynAbs.Tracing.TraceSender.TraceExitMethod(2,606,856);

int
f_2_764_777(List
this_param,Patient
p)
{
this_param.add( p);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 764, 777);
return 0;
}


int
f_2_837_851(List
this_param,Patient
p)
{
this_param.add( p);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 837, 851);
return 0;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(2,606,856);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(2,606,856);
}
		}

public void checkPatientsInside(List returned)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(2,1069,1393);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1129,1151);

var 
cur = inside.head
;
try {
while ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1161,1389) || true) && (cur != null)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,1161,1389);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1190,1223);

Patient 
p = (Patient)cur._object
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1228,1244);

p.timeLeft -= 1;

if ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1249,1349) || true) && (p.timeLeft == 0)
) 

{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,1249,1349);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1282,1298);

freePersonnel++;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1304,1321);

f_2_1304_1320(				inside, p);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1327,1343);

f_2_1327_1342(				returned, p);
DynAbs.Tracing.TraceSender.TraceExitCondition(2,1249,1349);
}
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1363,1378);

cur = cur.next;
DynAbs.Tracing.TraceSender.TraceExitCondition(2,1161,1389);
}
}catch(System.Exception) { DynAbs.Tracing.TraceSender.TraceExitLoopByException(2,1161,1389);
 throw; }finally{DynAbs.Tracing.TraceSender.TraceExitLoop(2,1161,1389);
}DynAbs.Tracing.TraceSender.TraceExitMethod(2,1069,1393);

int
f_2_1304_1320(List
this_param,Patient
o)
{
this_param.delete( (object)o);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 1304, 1320);
return 0;
}


int
f_2_1327_1342(List
this_param,Patient
p)
{
this_param.add( p);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 1327, 1342);
return 0;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(2,1069,1393);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(2,1069,1393);
}
		}

public List checkPatientsAssess(Village v)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(2,1497,2006);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1547,1568);

List 
up = f_2_1557_1567()
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1578,1600);

var 
cur = assess.head
;
try {
while ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1610,1988) || true) && (cur != null)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,1610,1988);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1639,1672);

Patient 
p = (Patient)cur._object
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1677,1693);

p.timeLeft -= 1;

if ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1698,1948) || true) && (p.timeLeft == 0)
) 

{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,1698,1948);

if ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1731,1942) || true) && (f_2_1735_1748(v))
) 

{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,1731,1942);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1764,1781);

f_2_1764_1780(					assess, p);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1788,1802);

f_2_1788_1801(					inside, p);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1809,1825);

p.timeLeft = 10;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1832,1845);

p.time += 10;
DynAbs.Tracing.TraceSender.TraceExitCondition(2,1731,1942);
}

else 

{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,1731,1942);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1878,1894);

freePersonnel++;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1901,1918);

f_2_1901_1917(					assess, p);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1925,1935);

f_2_1925_1934(					up, p);
DynAbs.Tracing.TraceSender.TraceExitCondition(2,1731,1942);
}
DynAbs.Tracing.TraceSender.TraceExitCondition(2,1698,1948);
}
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1962,1977);

cur = cur.next;
DynAbs.Tracing.TraceSender.TraceExitCondition(2,1610,1988);
}
}catch(System.Exception) { DynAbs.Tracing.TraceSender.TraceExitLoopByException(2,1610,1988);
 throw; }finally{DynAbs.Tracing.TraceSender.TraceExitLoop(2,1610,1988);
}DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1992,2002);

return up;
DynAbs.Tracing.TraceSender.TraceExitMethod(2,1497,2006);

List
f_2_1557_1567()
{
var return_v = new List();
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 1557, 1567);
return return_v;
}


bool
f_2_1735_1748(Village
this_param)
{
var return_v = this_param.staysHere();
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 1735, 1748);
return return_v;
}


int
f_2_1764_1780(List
this_param,Patient
o)
{
this_param.delete( (object)o);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 1764, 1780);
return 0;
}


int
f_2_1788_1801(List
this_param,Patient
p)
{
this_param.add( p);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 1788, 1801);
return 0;
}


int
f_2_1901_1917(List
this_param,Patient
o)
{
this_param.delete( (object)o);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 1901, 1917);
return 0;
}


int
f_2_1925_1934(List
this_param,Patient
p)
{
this_param.add( p);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 1925, 1934);
return 0;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(2,1497,2006);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(2,1497,2006);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

public void checkPatientsWaiting()
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(2,2011,2378);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2059,2082);

var 
cur = waiting.head
;
try {
while ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2092,2374) || true) && (cur != null)
) 

{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,2092,2374);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2122,2157);

Patient 
p = (Patient)(cur._object)
;

if ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2162,2340) || true) && (freePersonnel > 0)
) 

{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,2162,2340);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2197,2213);

freePersonnel--;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2219,2234);

p.timeLeft = 3;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2240,2252);

p.time += 3;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2258,2276);

f_2_2258_2275(				waiting, p);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2282,2296);

f_2_2282_2295(				assess, p);
DynAbs.Tracing.TraceSender.TraceExitCondition(2,2162,2340);
}

else 

{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,2162,2340);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2325,2334);

p.time++;
DynAbs.Tracing.TraceSender.TraceExitCondition(2,2162,2340);
}
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,2354,2369);

cur = cur.next;
DynAbs.Tracing.TraceSender.TraceExitCondition(2,2092,2374);
}
}catch(System.Exception) { DynAbs.Tracing.TraceSender.TraceExitLoopByException(2,2092,2374);
 throw; }finally{DynAbs.Tracing.TraceSender.TraceExitLoop(2,2092,2374);
}DynAbs.Tracing.TraceSender.TraceExitMethod(2,2011,2378);

int
f_2_2258_2275(List
this_param,Patient
o)
{
this_param.delete( (object)o);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 2258, 2275);
return 0;
}


int
f_2_2282_2295(List
this_param,Patient
p)
{
this_param.add( p);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 2282, 2295);
return 0;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(2,2011,2378);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(2,2011,2378);
}
		}

static Hospital()
{
DynAbs.Tracing.TraceSender.TraceEnterStaticConstructor(2,100,2381);
DynAbs.Tracing.TraceSender.TraceExitStaticConstructor(2,100,2381);

DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(2,100,2381);
}

		int ___ignore_me___=DynAbs.Tracing.TraceSender.TraceBeforeConstructor(2,100,2381);

static List
f_2_443_453()
{
var return_v = new List();
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 443, 453);
return return_v;
}


static List
f_2_467_477()
{
var return_v = new List();
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 467, 477);
return return_v;
}


static List
f_2_491_501()
{
var return_v = new List();
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 491, 501);
return return_v;
}


static List
f_2_511_521()
{
var return_v = new List();
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 511, 521);
return return_v;
}

}
