using DynAbs.Tracing;
using System;
using System.Collections.Generic;
using System.Text;

namespace DynAbs
{
    public class SkipFilesTraceConsumer : ITraceConsumer
    {
        ITraceConsumer _traceConsumer;

        public Stack<Stmt> Stack { get { return _traceConsumer.Stack; } }
        public int TotalTracedLines => _traceConsumer.TotalTracedLines;

        public SkipFilesTraceConsumer(ITraceConsumer traceConsumer)
        {
            _traceConsumer = traceConsumer;
        }

        public Stmt GetNextStatement(bool consume = true)
        {
            Stmt result = null;
            do
            {
                result = _traceConsumer.GetNextStatement(consume);
            } while (result.FileId < 100);
            return result;
        }

        public void ReturnStatementsToBuffer(Queue<Stmt> stmts)
        {
            _traceConsumer.ReturnStatementsToBuffer(stmts);
        }

        public Stmt ObserveNextStatement()
        {
            Stmt result = _traceConsumer.ObserveNextStatement();
            while (result.FileId < 100)
            {
                _traceConsumer.GetNextStatement();
                result = _traceConsumer.ObserveNextStatement();
            } 
            return result;
        }

        public bool HasNext()
        {
            // TODO: XXX
            var result = _traceConsumer.HasNext();
            return result;
        }

        public bool SliceCriteriaReached()
        {
            var result = _traceConsumer.SliceCriteriaReached();
            return result;
        }

        public bool SliceCriteriaReached(Stmt stmt)
        {
            var result = _traceConsumer.SliceCriteriaReached(stmt);
            return result;
        }

        public bool RemoveCriteria()
        {
            return _traceConsumer.RemoveCriteria();
        }

        public ITraceReceiver TraceReceiver { get { return _traceConsumer.TraceReceiver; } }
    }
}
