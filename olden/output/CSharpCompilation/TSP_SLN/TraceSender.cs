﻿using System;

namespace DynAbs.Tracing
{
    public static partial class TraceSender
    {
        public static ITracerClient TracerClient { get; set; }

        public static bool TraceSimpleStatement(int fileId, int spanStart, int spanEnd)
        {
            TracerClient.Trace(fileId, (int)TraceType.SimpleStatement, spanStart, spanEnd);
            // Return true is neccesary for instrument conditions in IF, WHILE, etc.
            return true;
        }

        public static void TraceBreak(int fileId, int spanStart, int spanEnd)
        {
            TracerClient.Trace(fileId, (int)TraceType.Break, spanStart, spanEnd);
        }

        public static void TraceExitUsing(int fileId, int spanStart, int spanEnd)
        {
            TracerClient.Trace(fileId, (int)TraceType.ExitUsing, spanStart, spanEnd);
        }

        public static void TraceEnterCondition(int fileId, int spanStart, int spanEnd)
        {
            TracerClient.Trace(fileId, (int)TraceType.EnterCondition, spanStart, spanEnd);
        }

        public static void TraceExitCondition(int fileId, int spanStart, int spanEnd)
        {
            TracerClient.Trace(fileId, (int)TraceType.ExitCondition, spanStart, spanEnd);
        }

        public static void TraceExitLoop(int fileId, int spanStart, int spanEnd)
        {
            TracerClient.Trace(fileId, (int)TraceType.ExitLoop, spanStart, spanEnd);
        }

        public static void TraceExitLoopByException(int fileId, int spanStart, int spanEnd)
        {
            TracerClient.Trace(fileId, (int)TraceType.ExitLoopByException, spanStart, spanEnd);
        }

        public static void TraceEnterMethod(int fileId, int spanStart, int spanEnd)
        {
            TracerClient.Trace(fileId, (int)TraceType.EnterMethod, spanStart, spanEnd);
        }

        public static void TraceExitMethod(int fileId, int spanStart, int spanEnd)
        {
            TracerClient.Trace(fileId, (int)TraceType.ExitMethod, spanStart, spanEnd);
        }

        public static int TraceBeforeConstructor(int fileId, int spanStart, int spanEnd)
        {
            TracerClient.Trace(fileId, (int)TraceType.BeforeConstructor, spanStart, spanEnd);
            return 42;
        }

        public static void TraceEnterConstructor(int fileId, int spanStart, int spanEnd)
        {
            TracerClient.Trace(fileId, (int)TraceType.EnterConstructor, spanStart, spanEnd);
        }

        public static void TraceExitConstructor(int fileId, int spanStart, int spanEnd)
        {
            TracerClient.Trace(fileId, (int)TraceType.ExitConstructor, spanStart, spanEnd);
        }

        public static void TraceEnterStaticMethod(int fileId, int spanStart, int spanEnd)
        {
            TracerClient.Trace(fileId, (int)TraceType.EnterStaticMethod, spanStart, spanEnd);
        }

        public static void TraceExitStaticMethod(int fileId, int spanStart, int spanEnd)
        {
            TracerClient.Trace(fileId, (int)TraceType.ExitStaticMethod, spanStart, spanEnd);
        }

        public static void TraceEnterStaticConstructor(int fileId, int spanStart, int spanEnd)
        {
            TracerClient.Trace(fileId, (int)TraceType.EnterStaticConstructor, spanStart, spanEnd);
        }

        public static void TraceExitStaticConstructor(int fileId, int spanStart, int spanEnd)
        {
            TracerClient.Trace(fileId, (int)TraceType.ExitStaticConstructor, spanStart, spanEnd);
        }

        public static void TraceEnterCatch(int fileId, int spanStart, int spanEnd)
        {
            TracerClient.Trace(fileId, (int)TraceType.EnterCatch, spanStart, spanEnd);
        }

        public static void TraceExitCatch(int fileId, int spanStart, int spanEnd)
        {
            TracerClient.Trace(fileId, (int)TraceType.ExitCatch, spanStart, spanEnd);
        }

        public static void TraceEnterFinally(int fileId, int spanStart, int spanEnd)
        {
            TracerClient.Trace(fileId, (int)TraceType.EnterFinally, spanStart, spanEnd);
        }

        public static void TraceExitFinally(int fileId, int spanStart, int spanEnd)
        {
            TracerClient.Trace(fileId, (int)TraceType.ExitFinally, spanStart, spanEnd);
        }

        public static void TraceEnterFinalCatch(int fileId, int spanStart, int spanEnd)
        {
            TracerClient.Trace(fileId, (int)TraceType.EnterFinalCatch, spanStart, spanEnd);
        }

        public static void TraceEnterFinalFinally(int fileId, int spanStart, int spanEnd)
        {
            TracerClient.Trace(fileId, (int)TraceType.EnterFinalFinally, spanStart, spanEnd);
        }

        public static void TraceEndInvocation(int fileId, int spanStart, int spanEnd)
        {
            TracerClient.Trace(fileId, (int)TraceType.EndInvocation, spanStart, spanEnd);
        }

        public static void TraceEndMemberAccess(int fileId, int spanStart, int spanEnd)
        {
            TracerClient.Trace(fileId, (int)TraceType.EndMemberAccess, spanStart, spanEnd);
        }

        public static void TraceEnterExpression(int fileId, int spanStart, int spanEnd)
        {
            TracerClient.Trace(fileId, (int)TraceType.EnterExpression, spanStart, spanEnd);
        }

        public static void TraceBaseCall(int fileId, int spanStart, int spanEnd)
        {
            TracerClient.Trace(fileId, (int)TraceType.BaseCall, spanStart, spanEnd);
        }

        public static T TraceConditionalOperator<T>(int fileId, Func<bool> condition, int spanStart, int spanEnd, Func<T> t1, int spanStartT1, int spanEndT1, Func<T> t2, int spanStartT2, int spanEndT2)
        {
            TraceSimpleStatement(fileId, spanStart, spanEnd);
            if (condition.Invoke())
            {
                TraceEnterCondition(fileId, spanStart, spanEnd);
                TraceSimpleStatement(fileId, spanStartT1, spanEndT1);
                var tmp = t1.Invoke();
                TraceExitCondition(fileId, spanStart, spanEnd);
                return tmp;
            }
            else
            {
                TraceEnterCondition(fileId, spanStart, spanEnd);
                TraceSimpleStatement(fileId, spanStartT2, spanEndT2);
                var tmp = t2.Invoke();
                TraceExitCondition(fileId, spanStart, spanEnd);
                return tmp;
            }
        }

        public static T TraceConditionalAccessExpression<T>(T val, int fileId, int spanStart, int spanEnd)
        {
            if (val == null)
                TracerClient.Trace(fileId, (int)TraceType.ConditionalAccessIsNull, spanStart, spanEnd);
            return val;
        }

        public static T TraceEnterExpression<T>(Func<T> expression, int fileId, int spanStart, int spanEnd)
        {
            TraceEnterExpression(fileId, spanStart, spanEnd);
            return expression.Invoke();
        }

        public static T TraceInvocationWrapper<T>(Func<T> function, int fileId, int spanStart, int spanEnd)
        {
            //var sended = false;
            //try
            //{
            T ret = function.Invoke();
            TraceEndInvocation(fileId, spanStart, spanEnd);
            //sended = true;
            return ret;
            //}
            //catch
            //{
            //    throw;
            //}
            //finally
            //{
            //    if (!sended)
            //        TraceEndInvocation(fileId, spanStart, spanEnd);
            //}
        }
        
        public static void TraceInvocationWrapper(Action function, int fileId, int spanStart, int spanEnd)
        {
            //var sended = false;
            //try
            //{
            function.Invoke();
            TraceEndInvocation(fileId, spanStart, spanEnd);
            //sended = true;
            //}
            //catch
            //{
            //    throw;
            //}
            //finally
            //{
            //    if (!sended)
            //        TraceEndInvocation(fileId, spanStart, spanEnd);
            //}
        }

        public static T TraceMemberAccessWrapper<T>(Func<T> function, int fileId, int spanStart, int spanEnd)
        {
            //var sended = false;
            //try
            //{
            T ret = function.Invoke();
            TraceEndMemberAccess(fileId, spanStart, spanEnd);
            //sended = true;
            return ret;
            //}
            //catch
            //{
            //    throw;
            //}
            //finally
            //{
            //    if (!sended)
            //        TraceEndMemberAccess(fileId, spanStart, spanEnd);
            //}
        }

        public static void TraceMemberAccessWrapper(Action function, int fileId, int spanStart, int spanEnd)
        {
            //var sended = false;
            //try
            //{
            function.Invoke();
            TraceEndMemberAccess(fileId, spanStart, spanEnd);
            //    sended = true;
            //}
            //catch
            //{
            //    throw;
            //}
            //finally
            //{
            //    if (!sended)
            //        TraceEndMemberAccess(fileId, spanStart, spanEnd);
            //}
        }

        /// <summary>
        /// La diferencia con el otro es que manda la traza antes. Se utiliza para avisar que leimos el campo izquierdo en el operador +=
        /// </summary>
        public static T TraceInitialMemberAccessWrapper<T>(Func<T> function, int fileId, int spanStart, int spanEnd)
        {
            //var sended = false;
            //try
            //{
            TraceEndMemberAccess(fileId, spanStart, spanEnd);
            //sended = true;
            return function.Invoke();
            //}
            //catch
            //{
            //    throw;
            //}
            //finally
            //{
            //    if (!sended)
            //        TraceEndMemberAccess(fileId, spanStart, spanEnd);
            //}
        }

        public static void TraceInitialMemberAccessWrapper(Action function, int fileId, int spanStart, int spanEnd)
        {
            //var sended = false;
            //try
            //{
            TraceEndMemberAccess(fileId, spanStart, spanEnd);
            //sended = true;
            function.Invoke();

            //}
            //catch
            //{
            //    throw;
            //}
            //finally
            //{
            //    if (!sended)
            //        TraceEndMemberAccess(fileId, spanStart, spanEnd);
            //}
        }

        public static T TraceInitializationWrapper<T>(Func<T> function, int fileId, int spanStart, int spanEnd)
        {
            TraceEndInvocation(fileId, spanStart, spanEnd);
            T ret = function.Invoke();
            return ret;
        }

        public static bool Conditional_F1(int fileId, int spanStart, int spanEnd)
        {
            TraceSimpleStatement(fileId, spanStart, spanEnd);
            return false;
        }
        public static bool Conditional_F2(int fileId, int spanStart, int spanEnd)
        {
            TraceSimpleStatement(fileId, spanStart, spanEnd);
            return true;
        }
        public static bool Conditional_F3(int fileId, int spanStart, int spanEnd)
        {
            TraceSimpleStatement(fileId, spanStart, spanEnd);
            return false;
        }

        public static T Expression_Null<T>(int fileId, int spanStart, int spanEnd)
        {
            TraceEnterExpression(fileId, spanStart, spanEnd);
            // En los objetos, el default es NULL que es lo que queremos
            return default(T);
        }

        public static bool Expression_False(int fileId, int spanStart, int spanEnd)
        {
            TraceEnterExpression(fileId, spanStart, spanEnd);
            return false;
        }

        public static bool Expression_True(int fileId, int spanStart, int spanEnd)
        {
            TraceEnterExpression(fileId, spanStart, spanEnd);
            return true;
        }
    }
}