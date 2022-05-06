
using System;
public class ListNode
{
public ListNode next;

public object _object;

public ListNode(object o)
		{
			try
{DynAbs.Tracing.TraceSender.TraceEnterConstructor(4,98,177);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(4,60,64);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(4,84,91);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(4,138,150);

_object = o;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(4,159,171);

next = null;
DynAbs.Tracing.TraceSender.TraceExitConstructor(4,98,177);
}catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(4,98,177);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(4,98,177);
}
		}

static ListNode()
{
DynAbs.Tracing.TraceSender.TraceEnterStaticConstructor(4,16,179);
DynAbs.Tracing.TraceSender.TraceExitStaticConstructor(4,16,179);

DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(4,16,179);
}

		int ___ignore_me___=DynAbs.Tracing.TraceSender.TraceBeforeConstructor(4,16,179);
}
