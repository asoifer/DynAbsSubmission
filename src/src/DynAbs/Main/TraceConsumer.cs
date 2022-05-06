using Microsoft.CodeAnalysis.CSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynAbs.Tracing;

namespace DynAbs
{
    public class TraceConsumer : ITraceConsumer
    {
        public static TraceConsumer Instance { get; internal set; }

        public static TraceConsumer CreateInstance(ITraceReceiver traceReceiver, List<Tuple<int, int>> fileLines)
        {
            Instance = new TraceConsumer(traceReceiver, fileLines);
            return Instance;
        }

        public static TraceConsumer CreateInstance(ITraceReceiver traceReceiver)
        {
            Instance = new TraceConsumer(traceReceiver);
            return Instance;
        }

        ITraceReceiver _traceReceiver;
        TraceBufferedQueue buffer = new TraceBufferedQueue();
        Stack<Stmt> _past;
        int _totalTracedLines;
        public Stack<Stmt> Stack { get { return _past; } }
        public int TotalTracedLines { get { return _totalTracedLines; } }
        readonly Stack<Tuple<int, int>> _fileLines;

        public TraceConsumer(ITraceReceiver traceReceiver, List<Tuple<int, int>> fileLines)
        {
            fileLines.Reverse();
            _fileLines = new Stack<Tuple<int, int>>(fileLines);
            _traceReceiver = traceReceiver;
            _totalTracedLines = 0;
            _past = new Stack<Stmt>();

            var task = Task.Run(() => { _traceReceiver.StartReceivingTrace(); });
            task.ContinueWith(c => Environment.FailFast("Task faulted", c.Exception),
                TaskContinuationOptions.OnlyOnFaulted |
                TaskContinuationOptions.ExecuteSynchronously);
        }

        public TraceConsumer(ITraceReceiver traceReceiver)
        {
            _traceReceiver = traceReceiver;
            _totalTracedLines = 0;
            _past = new Stack<Stmt>();

            var task = Task.Run(() => { _traceReceiver.StartReceivingTrace(); });
            task.ContinueWith(c => Environment.FailFast("Task faulted", c.Exception),
                TaskContinuationOptions.OnlyOnFaulted |
                TaskContinuationOptions.ExecuteSynchronously);
        }

        public static int fileId = 21009;
        public static int spanStart = 26407;
        public static int spanEnd = 26450;
        public Stmt GetNextStatement(bool consume)
        {
            Stmt returnValue;
            if (buffer.Count > 0)
                returnValue = buffer.Dequeue();
            else
            {
                var info = _traceReceiver.Next();
                returnValue = GetStatement(info);
            }

            if (consume)
            {
                if (returnValue.FileId == fileId 
                    && returnValue.SpanStart == spanStart 
                    && returnValue.SpanEnd == spanEnd)
                    ;

                _totalTracedLines++;
                #if DEBUG
                _past.Push(returnValue);
                #endif
            }

            return returnValue;
        }

        public void ReturnStatementsToBuffer(Queue<Stmt> stmts)
        {
            buffer.Enqueue(stmts);
        }

        public Stmt ObserveNextStatement()
        {
            Stmt returnValue;
            if (buffer.Count > 0)
                returnValue = buffer.Peek();
            else
            {
                var info = _traceReceiver.ObserveNext();
                if (info == null)
                    throw new SlicerException(ErrorMessages.TraceConsumer_WithoutNextStatement);
                returnValue = GetStatement(info);
            }
            return returnValue;
        }

        public bool HasNext()
        {
            TraceInfo info = _traceReceiver.ObserveNext();
            return (info != null) || (buffer.Count > 0);
        }
        
        public bool SliceCriteriaReached()
        {
            if (!HasNext())
                return false;

            var currentStatement = ObserveNextStatement();
            if (currentStatement != null && 
                UserSliceConfiguration.CurrentUserConfiguration.criteria.mode == UserConfiguration.Criteria.CriteriaMode.AtEndWithCriteria)
                return _fileLines.FirstOrDefault(x => currentStatement.FileId == x.Item1 && currentStatement.Line == x.Item2) != null;
            return (currentStatement != null && _fileLines != null && currentStatement.FileId == _fileLines.Peek().Item1 && currentStatement.Line == _fileLines.Peek().Item2);
        }

        public bool SliceCriteriaReached(Stmt stmt)
        {
            if (stmt != null &&
                UserSliceConfiguration.CurrentUserConfiguration.criteria.mode == UserConfiguration.Criteria.CriteriaMode.AtEndWithCriteria)
                return _fileLines.FirstOrDefault(x => stmt.FileId == x.Item1 && stmt.Line == x.Item2) != null;
            return (stmt != null && _fileLines != null && stmt.FileId == _fileLines.Peek().Item1 && stmt.Line == _fileLines.Peek().Item2);
        }

        /// <summary>
        /// Retorna true si no hay más criterios
        /// </summary>
        public bool RemoveCriteria()
        {
            _fileLines.Pop();
            return _fileLines.Count == 0;
        }

        public ITraceReceiver TraceReceiver { get { return _traceReceiver; } }

        public void AppendToStack(Stmt stmt)
        {
            Stack.Push(stmt);
        }

        #region Utilities
        Stmt GetStatement(TraceInfo traceInfo)
        {
            if (traceInfo == null)
                return null;
            var ret = new Stmt() { FileId = traceInfo.FileId, SpanStart = traceInfo.SpanStart, SpanEnd = traceInfo.SpanEnd };
            ret.Line = -1;
            ret.TraceType = traceInfo.TraceType;
            return ret;
        }
        #endregion
    }
}
