using System;
class RandomGenerator
{
static int doubleValuesIndex ;

static double[] DoubleValues ;

static int intValuesIndex ;

static int[] IntValues ;

public static double NextDouble()
		{
			try
    {
DynAbs.Tracing.TraceSender.TraceEnterStaticMethod(4,2082,2186);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(4,2132,2179);

return DoubleValues[(doubleValuesIndex++)%100];
DynAbs.Tracing.TraceSender.TraceExitStaticMethod(4,2082,2186);
    }
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(4,2082,2186);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(4,2082,2186);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

public static int Next()
		{
			try
    {
DynAbs.Tracing.TraceSender.TraceEnterStaticMethod(4,2192,2281);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(4,2233,2274);

return IntValues[(intValuesIndex++)%100];
DynAbs.Tracing.TraceSender.TraceExitStaticMethod(4,2192,2281);
    }
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(4,2192,2281);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(4,2192,2281);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

public RandomGenerator()
{
DynAbs.Tracing.TraceSender.TraceEnterConstructor(4,17,2284);
DynAbs.Tracing.TraceSender.TraceExitConstructor(4,17,2284);

DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(4,17,2284);
}


static RandomGenerator()
{
DynAbs.Tracing.TraceSender.TraceEnterStaticConstructor(4,17,2284);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(4,58,79);
doubleValuesIndex = 0;DynAbs.Tracing.TraceSender.TraceSimpleStatement(4,102,832);
DoubleValues = new double[] { 0.983, 0.905, 0.178, 0.988, 0.533, 0.991, 0.562, 0.695, 0.970, 0.434, 0.901, 0.352, 0.793, 0.518, 0.062, 0.875, 0.670, 0.556, 0.792, 0.932, 0.234, 0.782, 0.169, 0.105, 0.015, 0.770, 0.561, 0.187, 0.749, 0.073, 0.765, 0.838, 0.041, 0.067, 0.096, 0.042, 0.996, 0.035, 0.989, 0.753, 0.455, 0.675, 0.623, 0.269, 0.779, 0.346, 0.728, 0.722, 0.029, 0.547, 0.828, 0.428, 0.275, 0.155, 0.291, 0.200, 0.736, 0.073, 0.973, 0.764, 0.430, 0.375, 0.946, 0.897, 0.668, 0.064, 0.311, 0.726, 0.422, 0.020, 0.880, 0.635, 0.567, 0.039, 0.477, 0.559, 0.159, 0.900, 0.326, 0.669, 0.042, 0.839, 0.158, 0.202, 0.245, 0.337, 0.563, 0.886, 0.776, 0.896, 0.306, 0.923, 0.062, 0.225, 0.322, 0.079, 0.729, 0.726, 0.601, 0.716 };DynAbs.Tracing.TraceSender.TraceSimpleStatement(4,852,870);
intValuesIndex = 0;DynAbs.Tracing.TraceSender.TraceSimpleStatement(4,890,2073);
IntValues = new int[] { 2044697584, 809857254, 873825547, 1476195606, 1297659308, 151901816, 2009487253, 281269204, 1698634757, 1536097030, 1390173638, 1299845275, 1738916259, 1389984754, 233121538, 1330851542, 460285150, 175801656, 802024452, 1133380608, 772771058, 987668032, 2129886188, 1834283428, 332080821, 1110980758, 1014465787, 774527609, 1924221870, 1340113727, 483150232, 204172358, 1695414887, 965137199, 958803308, 1733709767, 494224907, 479767651, 1735581590, 1910516027, 1737407837, 1856544952, 1552709609, 1555623453, 270491650, 1139480388, 1114117068, 1505712628, 373863751, 1080642429, 1805297948, 1269500649, 201033873, 1103661192, 1050259890, 1057029552, 827454713, 1187025766, 1144114785, 186678550, 1284919676, 1234959644, 504530981, 358521030, 1052946798, 1186001280, 1751914035, 773779060, 431181446, 646895418, 836626635, 2128001146, 587703713, 1038992072, 1543456418, 1063709753, 1582442070, 574262735, 1563791778, 1340084080, 2144347337, 1656236806, 400663858, 843579441, 1682299426, 1361133230, 3138485, 591753695, 2062360956, 2049257403, 906255054, 1454682788, 1483136513, 1548903040, 625596351, 502448193, 1352013971, 1194188579, 502676655, 1231974017 };DynAbs.Tracing.TraceSender.TraceExitStaticConstructor(4,17,2284);

DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(4,17,2284);
}

		int ___ignore_me___=DynAbs.Tracing.TraceSender.TraceBeforeConstructor(4,17,2284);
}
