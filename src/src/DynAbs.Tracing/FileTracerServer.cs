using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;

namespace DynAbs.Tracing
{
    internal class FileTracerServer : ITracerServer
    {
        public ITraceReceiver Receiver { get; set; }
        public string TraceInput { get; set; }

        public FileTracerServer(ITraceReceiver receiver, string traceInput)
        {
            this.Receiver = receiver;

            // Si el traceInput es vacío o null tomamos el generado por defecto por las aplicaciones
            if (string.IsNullOrEmpty(traceInput))
                throw new Exception("Trace input file must be defined");

            TraceInput = traceInput;
        }

        public void Initialize()
        {
        }

        public void StartReceivingTrace()
        {
            char separator = ',';
            var lines = File.ReadAllLines(TraceInput);
            foreach (var line in lines)
            {
                // Comments on the trace
                //if (line.Contains("##")) 
                //{ 
                //    Console.WriteLine(line);
                //    continue;
                //}

                // Other threads
                //if (line.Contains("#"))
                //{
                //    continue;
                //}

                // For debugging
                //try
                //{ 
                    var data = line.Split(separator);
                    var fileId = Convert.ToInt32(data[0]);
                    var traceType = (TraceType)Convert.ToInt32(data[1]);
                    var spanStart = Convert.ToInt32(data[2]);
                    var spanEnd = Convert.ToInt32(data[3]);
                    TraceInfo info = new TraceInfo() { FileId = fileId, TraceType = traceType, SpanStart = spanStart, SpanEnd = spanEnd };
                    Receiver.TraceReceived(info);
                //}
                //catch(Exception ex)
                //{
                //    Console.WriteLine("No se pudo procesar: " + line);
                //}
            }
            Receiver.StopReceiving();
        }
    }
}
