using System;
public class Hashtable
{
public HashEntry[] array;

public int size;

public Hashtable(int sz)
		{
			try
{DynAbs.Tracing.TraceSender.TraceEnterConstructor(2,92,225);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,62,67);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,82,86);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,124,134);

size = sz;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,138,166);

array = new HashEntry[size];
try {DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,179,184);
		for (int 
i = 0
; (DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,170,221) || true) && (i < size)
; DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,196,199)
,i++,DynAbs.Tracing.TraceSender.TraceExitCondition(2,170,221))

{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,170,221);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,205,221);

array[i] = null;
}
}catch(System.Exception) { DynAbs.Tracing.TraceSender.TraceExitLoopByException(2,1,52);
 throw; }finally{DynAbs.Tracing.TraceSender.TraceExitLoop(2,1,52);
}DynAbs.Tracing.TraceSender.TraceExitConstructor(2,92,225);
}catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(2,92,225);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(2,92,225);
}
		}

private int hashMap(object key)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(2,230,314);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,269,310);

return ((f_2_278_295(key)>> 3) % size);
DynAbs.Tracing.TraceSender.TraceExitMethod(2,230,314);

int
f_2_278_295(object
this_param)
{
var return_v = this_param.GetHashCode();
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 278, 295);
return return_v;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(2,230,314);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(2,230,314);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

public virtual object get(object key)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(2,319,565);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,364,385);

int 
j = f_2_372_384(this, key)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,393,414);

HashEntry 
ent = null
;
try {		
		for (DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,427,441)
,ent = array[j]; (DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,422,497) || true) && (ent != null &&(DynAbs.Tracing.TraceSender.Expression_True(2, 443, 474)&&f_2_458_467(ent)!= key))
; DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,476,492)
,ent = f_2_482_492(ent),DynAbs.Tracing.TraceSender.TraceExitCondition(2,422,497)) 
{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,422,497);
}
}catch(System.Exception) { DynAbs.Tracing.TraceSender.TraceExitLoopByException(2,1,76);
 throw; }finally{DynAbs.Tracing.TraceSender.TraceExitLoop(2,1,76);
}
if ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,505,545) || true) && (ent != null)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,505,545);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,526,545);

return f_2_533_544(ent);
DynAbs.Tracing.TraceSender.TraceExitCondition(2,505,545);
}
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,549,561);

return null;
DynAbs.Tracing.TraceSender.TraceExitMethod(2,319,565);

int
f_2_372_384(Hashtable
this_param,object
key)
{
var return_v = this_param.hashMap( key);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 372, 384);
return return_v;
}


object
f_2_458_467(HashEntry
this_param)
{
var return_v = this_param.Key();
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 458, 467);
return return_v;
}


HashEntry
f_2_482_492(HashEntry
this_param)
{
var return_v = this_param.Next();
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 482, 492);
return return_v;
}


object
f_2_533_544(HashEntry
this_param)
{
var return_v = this_param.Entry();
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 533, 544);
return return_v;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(2,319,565);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(2,319,565);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

public virtual void put(object key, object value)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(2,570,727);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,627,648);

int 
j = f_2_635_647(this, key)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,652,704);

HashEntry 
ent = f_2_668_703(key, value, array[j])
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,708,723);

array[j] = ent;
DynAbs.Tracing.TraceSender.TraceExitMethod(2,570,727);

int
f_2_635_647(Hashtable
this_param,object
key)
{
var return_v = this_param.hashMap( key);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 635, 647);
return return_v;
}


HashEntry
f_2_668_703(object
key,object
entry,HashEntry
next)
{
var return_v = new HashEntry( key, entry, next);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 668, 703);
return return_v;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(2,570,727);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(2,570,727);
}
		}

public virtual void remove(object key)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(2,732,1067);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,778,799);

int 
j = f_2_786_798(this, key)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,803,828);

HashEntry 
ent = array[j]
;

if ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,832,1063) || true) && (ent != null &&(DynAbs.Tracing.TraceSender.Expression_True(2, 836, 867)&&f_2_851_860(ent)== key))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,832,1063);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,873,895);

array[j] = f_2_884_894(ent);
DynAbs.Tracing.TraceSender.TraceExitCondition(2,832,1063);
}

else

{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,832,1063);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,913,934);

HashEntry 
prev = ent
;
try {			for (DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,944,960)
,ent = f_2_950_960(ent); (DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,939,1028) || true) && (ent != null &&(DynAbs.Tracing.TraceSender.Expression_True(2, 962, 993)&&f_2_977_986(ent)!= key))
; DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,995,1005)
,prev = ent,DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1007,1023)
,ent = f_2_1013_1023(ent),DynAbs.Tracing.TraceSender.TraceExitCondition(2,939,1028)) 
{DynAbs.Tracing.TraceSender.TraceEnterCondition(2,939,1028);
}
}catch(System.Exception) { DynAbs.Tracing.TraceSender.TraceExitLoopByException(2,1,90);
 throw; }finally{DynAbs.Tracing.TraceSender.TraceExitLoop(2,1,90);
}DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1033,1058);

f_2_1033_1057(			prev, f_2_1046_1056(ent));
DynAbs.Tracing.TraceSender.TraceExitCondition(2,832,1063);
}
DynAbs.Tracing.TraceSender.TraceExitMethod(2,732,1067);

int
f_2_786_798(Hashtable
this_param,object
key)
{
var return_v = this_param.hashMap( key);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 786, 798);
return return_v;
}


object
f_2_851_860(HashEntry
this_param)
{
var return_v = this_param.Key();
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 851, 860);
return return_v;
}


HashEntry
f_2_884_894(HashEntry
this_param)
{
var return_v = this_param.Next();
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 884, 894);
return return_v;
}


HashEntry
f_2_950_960(HashEntry
this_param)
{
var return_v = this_param.Next();
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 950, 960);
return return_v;
}


object
f_2_977_986(HashEntry
this_param)
{
var return_v = this_param.Key();
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 977, 986);
return return_v;
}


HashEntry
f_2_1013_1023(HashEntry
this_param)
{
var return_v = this_param.Next();
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 1013, 1023);
return return_v;
}


HashEntry
f_2_1046_1056(HashEntry
this_param)
{
var return_v = this_param.Next();
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 1046, 1056);
return return_v;
}


int
f_2_1033_1057(HashEntry
this_param,HashEntry
n)
{
this_param.SetNext( n);
DynAbs.Tracing.TraceSender.TraceEndInvocation(2, 1033, 1057);
return 0;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(2,732,1067);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(2,732,1067);
}
		}

static Hashtable()
{
DynAbs.Tracing.TraceSender.TraceEnterStaticConstructor(2,15,1070);
DynAbs.Tracing.TraceSender.TraceExitStaticConstructor(2,15,1070);

DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(2,15,1070);
}

		int ___ignore_me___=DynAbs.Tracing.TraceSender.TraceBeforeConstructor(2,15,1070);
}
public class HashEntry
{
public object key;

public object entry;

public HashEntry next;

public HashEntry(object key, object entry, HashEntry next)
		{
			try
{DynAbs.Tracing.TraceSender.TraceEnterConstructor(2,1179,1308);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1116,1119);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1140,1145);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1169,1173);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1245,1260);

this.key = key;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1264,1283);

this.entry = entry;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1287,1304);

this.next = next;
DynAbs.Tracing.TraceSender.TraceExitConstructor(2,1179,1308);
}catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(2,1179,1308);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(2,1179,1308);
}
		}

public virtual object Key()
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(2,1313,1363);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1348,1359);

return key;
DynAbs.Tracing.TraceSender.TraceExitMethod(2,1313,1363);
	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(2,1313,1363);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(2,1313,1363);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

public virtual object Entry()
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(2,1368,1422);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1405,1418);

return entry;
DynAbs.Tracing.TraceSender.TraceExitMethod(2,1368,1422);
	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(2,1368,1422);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(2,1368,1422);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

public virtual HashEntry Next()
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(2,1427,1482);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1466,1478);

return next;
DynAbs.Tracing.TraceSender.TraceExitMethod(2,1427,1482);
	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(2,1427,1482);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(2,1427,1482);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

public virtual void SetNext(HashEntry n)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(2,1487,1548);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(2,1535,1544);

next = n;
DynAbs.Tracing.TraceSender.TraceExitMethod(2,1487,1548);
	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(2,1487,1548);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(2,1487,1548);
}
		}

static HashEntry()
{
DynAbs.Tracing.TraceSender.TraceEnterStaticConstructor(2,1074,1551);
DynAbs.Tracing.TraceSender.TraceExitStaticConstructor(2,1074,1551);

DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(2,1074,1551);
}

		int ___ignore_me___=DynAbs.Tracing.TraceSender.TraceBeforeConstructor(2,1074,1551);
}
