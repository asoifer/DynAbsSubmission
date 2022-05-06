
using System;
public class List 
{
public ListNode head;

public ListNode tail;

public List()
		{
			try
{DynAbs.Tracing.TraceSender.TraceEnterConstructor(3,128,195);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,91,95);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,117,121);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,156,168);

head = null;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,177,189);

tail = null;
DynAbs.Tracing.TraceSender.TraceExitConstructor(3,128,195);
}catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(3,128,195);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(3,128,195);
}
		}

public void add(Patient p)
		{
			try
    {
DynAbs.Tracing.TraceSender.TraceEnterMethod(3,201,398);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,242,274);

ListNode 
node = f_3_258_273(p)
;

if ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,283,368) || true) && (head == null)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(3,283,368);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,313,325);

head = node;
DynAbs.Tracing.TraceSender.TraceExitCondition(3,283,368);
}

else

{DynAbs.Tracing.TraceSender.TraceEnterCondition(3,283,368);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,351,368);

tail.next = node;
DynAbs.Tracing.TraceSender.TraceExitCondition(3,283,368);
}
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,380,392);

tail = node;
DynAbs.Tracing.TraceSender.TraceExitMethod(3,201,398);

ListNode
f_3_258_273(Patient
o)
{
var return_v = new ListNode( (object)o);
DynAbs.Tracing.TraceSender.TraceEndInvocation(3, 258, 273);
return return_v;
}

    }
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(3,201,398);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(3,201,398);
}
		}

public void delete(Object o)
		{
			try
    {
DynAbs.Tracing.TraceSender.TraceEnterMethod(3,406,925);

if ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,451,489) || true) && (head == null)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(3,451,489);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,482,489);

return;
DynAbs.Tracing.TraceSender.TraceExitCondition(3,451,489);
}

if ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,501,549) || true) && (tail._object == o)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(3,501,549);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,537,549);

tail = null;
DynAbs.Tracing.TraceSender.TraceExitCondition(3,501,549);
}

if ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,561,657) || true) && (head._object == o)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(3,561,657);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,608,625);

head = head.next;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,639,646);

return;
DynAbs.Tracing.TraceSender.TraceExitCondition(3,561,657);
}
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,669,687);

ListNode 
p = head
;
try {DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,711,725);
        for (ListNode 
ln = head.next
; (DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,697,919) || true) && (ln != null)
; DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,739,751)
,ln = ln.next,DynAbs.Tracing.TraceSender.TraceExitCondition(3,697,919))

{DynAbs.Tracing.TraceSender.TraceEnterCondition(3,697,919);

if ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,777,887) || true) && (ln._object == o)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(3,777,887);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,830,847);

p.next = ln.next;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,865,872);

return;
DynAbs.Tracing.TraceSender.TraceExitCondition(3,777,887);
}
DynAbs.Tracing.TraceSender.TraceSimpleStatement(3,901,908);

p = ln;
}
}catch(System.Exception) { DynAbs.Tracing.TraceSender.TraceExitLoopByException(3,1,223);
 throw; }finally{DynAbs.Tracing.TraceSender.TraceExitLoop(3,1,223);
}DynAbs.Tracing.TraceSender.TraceExitMethod(3,406,925);
    }
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(3,406,925);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(3,406,925);
}
		}

static List()
{
DynAbs.Tracing.TraceSender.TraceEnterStaticConstructor(3,50,927);
DynAbs.Tracing.TraceSender.TraceExitStaticConstructor(3,50,927);

DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(3,50,927);
}

		int ___ignore_me___=DynAbs.Tracing.TraceSender.TraceBeforeConstructor(3,50,927);
}
