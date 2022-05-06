using System;
using System.Collections.Generic;
using DynAbs.Tracing;
using System.Linq;
using System.Threading;

namespace DynAbs.Tracing
{
    public class TraceReceiver : ITraceReceiver
    {
        private ITracerServer tracerServer;
        private TraceQueue traceBuffer = new TraceQueue(null);
        public bool ReceivingStoped { get; set; }

        public TraceReceiver(string traceInput)
        {
            //Open connection.
            //tracerServer = new TcpTracerServer(this);
            if (traceInput == null)
            {
                throw new NotImplementedException();
                //tracerServer = new PipeTracerServer(this);
            }
            else
            {
                tracerServer = new FileTracerServer(this, traceInput);
            }
            tracerServer.Initialize();
            ReceivingStoped = false;
        }

        public void StartReceivingTrace()
        {
            tracerServer.StartReceivingTrace();
        }

        public bool TraceReceived(TraceInfo info)
        {
            if (!ReceivingStoped)
            {
                traceBuffer.Add(info);
                return true;
            }

            return false;
        }

        //static int fromRange = 10800;
        //static int toRange = 10999;

        public TraceInfo Next()
        {
            TraceInfo temp;
            if (Globals.skip_trace_enabled)
            {
                do
                {
                    temp = traceBuffer.Take();

                    if (temp == null)
                        ;

                } while (UserSliceConfiguration.FilesToSkip.Contains(temp.FileId));
            }
            else
            {
                temp = traceBuffer.Take();
            }

            return temp;
        }

        public TraceInfo ObserveNext()
        {
            TraceInfo temp = traceBuffer.Peek();

            if (Globals.skip_trace_enabled)
            {
                while (temp != null && UserSliceConfiguration.FilesToSkip.Contains(temp.FileId))
                {
                    traceBuffer.Take();
                    temp = traceBuffer.Peek();
                }
            }

            return temp;
        }

        public void StopReceiving()
        {
            traceBuffer.IsAddingComplete = true;
            ReceivingStoped = true;
        }
    }
}