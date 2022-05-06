using System;
internal class Vertex
{
internal int mindist;

internal Vertex next;

internal Hashtable neighbors;

internal Vertex(Vertex n, int numvert)
		{
			try
{DynAbs.Tracing.TraceSender.TraceEnterConstructor(4,520,644);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(4,234,241);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(4,310,314);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(4,407,416);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(4,566,584);

mindist = 9999999;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(4,588,597);

next = n;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(4,601,640);

neighbors = f_4_613_639(numvert / 4);
DynAbs.Tracing.TraceSender.TraceExitConstructor(4,520,644);
}catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(4,520,644);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(4,520,644);
}
		}

public virtual int Mindist()
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(4,649,704);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(4,685,700);

return mindist;
DynAbs.Tracing.TraceSender.TraceExitMethod(4,649,704);
	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(4,649,704);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(4,649,704);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

public virtual void setMindist(int m)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(4,709,770);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(4,754,766);

mindist = m;
DynAbs.Tracing.TraceSender.TraceExitMethod(4,709,770);
	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(4,709,770);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(4,709,770);
}
		}

public virtual Vertex Next()
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(4,775,827);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(4,811,823);

return next;
DynAbs.Tracing.TraceSender.TraceExitMethod(4,775,827);
	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(4,775,827);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(4,775,827);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

public virtual void SetNext(Vertex v)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(4,832,890);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(4,877,886);

next = v;
DynAbs.Tracing.TraceSender.TraceExitMethod(4,832,890);
	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(4,832,890);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(4,832,890);
}
		}

public virtual Hashtable Neighbors()
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(4,895,960);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(4,939,956);

return neighbors;
DynAbs.Tracing.TraceSender.TraceExitMethod(4,895,960);
	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(4,895,960);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(4,895,960);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

static Vertex()
{
DynAbs.Tracing.TraceSender.TraceEnterStaticConstructor(4,135,963);
DynAbs.Tracing.TraceSender.TraceExitStaticConstructor(4,135,963);

DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(4,135,963);
}

		int ___ignore_me___=DynAbs.Tracing.TraceSender.TraceBeforeConstructor(4,135,963);

static Hashtable
f_4_613_639(int
sz)
{
var return_v = new Hashtable( sz);
DynAbs.Tracing.TraceSender.TraceEndInvocation(4, 613, 639);
return return_v;
}

}
