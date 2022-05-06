﻿using Xunit;
using DynAbs.Test.Cases;
using DynAbs.Test.Cases.TryCatch;
using DynAbs.Test.Util;

namespace DynAbs.Test.Suites.Slicing
{
    
    public class TryCatchSuite : BaseSlicingTest
    {
        [Fact]
        public void TryStmtCompleteCase()
        {
            var testedType = typeof(TryStatement);
            var sameFile = SameFileStmtBuilder(testedType);
            TestSimpleSlice(testedType, new DynAbsResult
            {
                Criteria = sameFile.WithLine(27),
                Sliced =
                    {
                        sameFile.WithLine(13),
                        sameFile.WithLine(16),
                        sameFile.WithLine(30),
                        sameFile.WithLine(32),
                        sameFile.WithLine(34),
                        sameFile.WithLine(21),
                        sameFile.WithLine(25),
                        sameFile.WithLine(27),
                    },
            }
            );
        }

        [Fact]
        public void TryStmtThrowInsideTry()
        {
            var testedType = typeof(ThrowInsideTry);
            var sameFile = SameFileStmtBuilder(testedType);
            TestSimpleSlice(testedType, new DynAbsResult
            {
                Criteria = sameFile.WithLine(26),
                Sliced =
                    {
                        sameFile.WithLine(16),
                        sameFile.WithLine(29),
                        sameFile.WithLine(31),
                        sameFile.WithLine(32),
                        sameFile.WithLine(20),
                        sameFile.WithLine(24),
                        sameFile.WithLine(26),
                    },
            }
            );
        }

        [Fact]
        public void TryStmtNonInstrumentedThrowingException()
        {
            var testedType = typeof(TryStmtNonInstrumentedThrowingException);
            var sameFile = SameFileStmtBuilder(testedType);
            TestSimpleSlice(testedType, new DynAbsResult
            {
                Criteria = sameFile.WithLine(23),
                Sliced =
                    {
                        sameFile.WithLine(14),
                        sameFile.WithLine(21),
                        sameFile.WithLine(23),
                    },
            }
            );
        }

        [Fact]
        public void TryStmtBindNonInsThrowedExcep()
        {
            var testedType = typeof(TryStmtBindNonInsThrowedExcep);
            var sameFile = SameFileStmtBuilder(testedType);
            TestSimpleSlice(testedType, new DynAbsResult
            {
                Criteria = sameFile.WithLine(23),
                Sliced =
                    {
                        sameFile.WithLine(21),
                        sameFile.WithLine(23),
                        // Esta bien porque la instanciación se está haciendo en el catch
                        sameFile.WithLine(19),
                    },
                WithoutSummariesExtraLines = { }
            }
            );
        }

        [Fact]
        public void TryStmtBindExceptionUpInStack()
        {
            var testedType = typeof(TryStmtBindExceptionUpInStack);
            var sameFile = SameFileStmtBuilder(testedType);
            TestSimpleSlice(testedType, new DynAbsResult
            {
                Criteria = sameFile.WithLine(22),
                Sliced =
                    {
                        sameFile.WithLine(13),
                        sameFile.WithLine(18),
                        sameFile.WithLine(20),
                        sameFile.WithLine(22),
                        sameFile.WithLine(32),
                        sameFile.WithLine(27),
                        sameFile.WithLine(16),
                    },
            }
            );
        }

        [Fact]
        public void TryStmtExecutingFinallyAfterThrow()
        {
            var testedType = typeof(TryStmtExecutingFinallyAfterThrow);
            var sameFile = SameFileStmtBuilder(testedType);
            TestSimpleSlice(testedType, new DynAbsResult
            {
                Criteria = sameFile.WithLine(22),
                Sliced =
                    {
                        sameFile.WithLine(22),
                        sameFile.WithLine(20),
                        sameFile.WithLine(18),
                        sameFile.WithLine(34),
                        sameFile.WithLine(33),
                        sameFile.WithLine(31),
                        sameFile.WithLine(29),
                        sameFile.WithLine(38),
                        sameFile.WithLine(16),
                    },
            }
            );
        }

        [Fact]
        public void TryStmtReturnWithFinallyInTry()
        {
            var testedType = typeof(TryStmtReturnWithFinallyInTry);
            var sameFile = SameFileStmtBuilder(testedType);
            TestSimpleSlice(testedType, new DynAbsResult
            {
                Criteria = sameFile.WithLine(15),
                Sliced =
                    {
                        sameFile.WithLine(14),
                        sameFile.WithLine(15),
                        sameFile.WithLine(20),
                        sameFile.WithLine(23),
                        sameFile.WithLine(24),
                        sameFile.WithLine(28),
                    },
            }
            );
        }

        [Fact]
        public void TryStmtReturnWithFinallyInCatch()
        {
            var testedType = typeof(TryStmtReturnWithFinallyInCatch);
            var sameFile = SameFileStmtBuilder(testedType);
            TestSimpleSlice(testedType, new DynAbsResult
            {
                Criteria = sameFile.WithLine(15),
                Sliced =
                    {
                        sameFile.WithLine(14),
                        sameFile.WithLine(15),
                        sameFile.WithLine(20),
                        sameFile.WithLine(23),
                        sameFile.WithLine(25),
                        sameFile.WithLine(27),
                        sameFile.WithLine(28),
                        sameFile.WithLine(32),
                    },
            }
            );
        }

        [Fact]
        public void TryStmtExceptionInProperty()
        {
            var testedType = typeof(TryStmtExceptionInProperty);
            var sameFile = SameFileStmtBuilder(testedType);
            TestSimpleSlice(testedType, new DynAbsResult
            {
                Criteria = sameFile.WithLine(23),
                Sliced =
                    {
                        sameFile.WithLine(19),
                        sameFile.WithLine(21),
                        sameFile.WithLine(23),
                        sameFile.WithLine(31),
                        sameFile.WithLine(17),
                        sameFile.WithLine(13),
                    },
            }
            );
        }

        [Fact]
        public void TryStmtExceptionInNonInsProperty()
        {
            var testedType = typeof(TryStmtExceptionInNonInsProperty);
            var sameFile = SameFileStmtBuilder(testedType);
            TestSimpleSlice(testedType, new DynAbsResult
            {
                Criteria = sameFile.WithLine(24),
                Sliced =
                    {
                        //sameFile.WithLine(18), // XXX: No estamos bindeando la instrucción que pincha
                        sameFile.WithLine(20),
                        sameFile.WithLine(22),
                        sameFile.WithLine(24),
                    },
            }
            );
        }

        [Fact]
        public void TryStmtCatchThrowWithoutParam()
        {
            var testedType = typeof(TryStmtCatchThrowWithoutParam);
            var sameFile = SameFileStmtBuilder(testedType);
            TestSimpleSlice(testedType, new DynAbsResult
            {
                Criteria = sameFile.WithLine(22),
                Sliced =
                    {
                        sameFile.WithLine(22),
                        sameFile.WithLine(20),
                        sameFile.WithLine(18),
                        sameFile.WithLine(39),
                        sameFile.WithLine(29),
                        sameFile.WithLine(16),
                        // Discutir si va esta línea
                        //sameFile.WithLine(33),
                    },
            }
            );
        }

        [Fact]
        public void AritmeticException()
        {
            var testedType = typeof(AritmeticException);
            var sameFile = SameFileStmtBuilder(testedType);
            TestSimpleSlice(testedType, new DynAbsResult
            {
                Criteria = sameFile.WithLine(22),
                Sliced =
                    {
                        sameFile.WithLine(22),
                        sameFile.WithLine(20)
                    },
            }
            );
        }

        [Fact]
        public void NullPointerException()
        {
            var testedType = typeof(NullPointerException);
            var sameFile = SameFileStmtBuilder(testedType);
            TestSimpleSlice(testedType, new DynAbsResult
            {
                Criteria = sameFile.WithLine(23),
                Sliced =
                    {
                        sameFile.WithLine(23),
                        sameFile.WithLine(21)
                    },
            }
            );
        }

        [Fact]
        public void OutOfRangeException()
        {
            var testedType = typeof(OutOfRangeException);
            var sameFile = SameFileStmtBuilder(testedType);
            TestSimpleSlice(testedType, new DynAbsResult
            {
                Criteria = sameFile.WithLine(23),
                Sliced =
                    {
                        sameFile.WithLine(23),
                        sameFile.WithLine(21)
                    },
            }
            );
        }

        [Fact]
        public void StaticMethodForException()
        {
            var testedType = typeof(StaticMethodForException);
            var sameFile = SameFileStmtBuilder(testedType);
            TestSimpleSlice(testedType, new DynAbsResult
            {
                Criteria = sameFile.WithLine(23),
                Sliced =
                    {
                        sameFile.WithLine(19),
                        sameFile.WithLine(31),
                        sameFile.WithLine(23),
                        sameFile.WithLine(21),
                        sameFile.WithLine(30),
                        sameFile.WithLine(28),
                        sameFile.WithLine(42),
                        sameFile.WithLine(40),
                        sameFile.WithLine(38),
                        sameFile.WithLine(17),
                        sameFile.WithLine(14),
                    },
                WithoutSummariesExtraLines =
                {
                    // Weak update producto del labda ida/vuelta evitable
                    sameFile.WithLine(37),
                }
            }
            );
        }
    }
}
