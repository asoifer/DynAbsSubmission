using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynAbs
{
    public static class Globals
    {
        public static InstrumentationResult InstrumentationResult;
        public static Solution UserSolution;
        public static bool types_optimization = true;
        public static bool static_mode_enabled = true;
        public static bool loops_optimization_enabled = true;
        public static DateTime start_time = DateTime.Now;
        public static bool print_console = true;

        public static bool properties_as_fields = true;
        public static bool foreach_annotation = true;

        public static bool include_receiver_use_on_calls = false;
        public static bool optimize_union_find_set = true;
        public static bool clean_last_def = true;
        public static bool optimize_types = true;
        public static bool skip_trace_enabled = false;

        // IMPORTANT: this is because we cannot resolve how to wrap structs properties and methods access.
        public static bool wrap_structs_calls = false;

        public const string DefaultKind = "Default";

        // Temp path for debugging purposes
        public const string TempPath = @"C:\Users\alexd\Desktop\Slicer\Varios\temp";
    }
}
