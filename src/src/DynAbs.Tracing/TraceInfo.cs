using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DynAbs.Tracing
{
    public class TraceInfo
    {
        public int FileId { get; set; }
        public int SpanStart { get; set; }
        public int SpanEnd { get; set; }
        public TraceType TraceType { get; set; }

        public override bool Equals(object obj)
        {
            var other = (TraceInfo)obj;
            return this.TraceType == other.TraceType &&
                this.FileId == other.FileId &&
                this.SpanStart == other.SpanStart &&
                this.SpanEnd == other.SpanEnd;
        }

        public override int GetHashCode()
        {
            int prime = 31;
            int result = 1;
            result = prime * result + FileId;
            result = prime * result + SpanStart;
            result = prime * result + SpanEnd;
            result = prime * result + (int)TraceType;
            return result;
        }
    }
}