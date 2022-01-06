using chm_4.LinAlg;
using static chm_4.LinAlg.GeneralOperations;

namespace chm_4;

/// <summary>
///     System of non-linear equations
/// </summary>
public static class SONLE
{
    /// <summary>
    /// Solves system of non-linear equations with Newton's method
    /// </summary>
    /// <param name="systemName">
    /// Switching in system names, valid names is:
    /// "Intersect1PointCircle",
    /// "Intersect2PointCircle",
    /// "Intersect0PointCircle",
    /// "Intersect1PointCircleLine",
    /// "Intersect3Line"
    /// </param>
    /// <param name="funcsNum">Number of functions in system</param>
    /// <param name="varsNum">Number of variables in system</param>
    /// <param name="initApprox">Initial approximation</param>
    /// <param name="mode">Mode of differentiation (Analytical / Numerical)</param>
    /// <param name="maxIter">parameter for exiting by iteration expiration</param>
    /// <param name="eps1">parameter for exiting by beta</param>
    /// <param name="eps2">parameter for exiting by ||F_k|| / ||F_0||</param>
    /// <returns>Solution vector</returns>
    /// <exception cref="ArgumentException"> If passes invalid test name. </exception>
    public static double[] Solve(
        string systemName,
        int funcsNum,
        int varsNum,
        double[] initApprox,
        string mode,
        int maxIter,
        double eps1,
        double eps2
    )
    {
        var jacobian = new double[varsNum, varsNum];
        var f = new double[varsNum];

        if (funcsNum != varsNum)
        {
            (jacobian, f) = EvalConvSystem(systemName, initApprox, mode, funcsNum, varsNum);
        }
        else
        {
            jacobian = EvalJacobian(systemName, initApprox, mode, 2, 2);
            f = EvalFuncsToSLAE(systemName, initApprox, 2);
        }

        var normF0 = Norm(f);

        var dArgs = Gauss.Solve(jacobian, f);

        var beta = 1.0;

        var args = new double[initApprox.Length];

        for (var i = 0; i < args.Length; i++)
        {
            args[i] += beta * dArgs[i];
        }

        var fNew = EvalFuncs(systemName, args, 2);
        Utils.ShowStats(0, beta, args, Norm(fNew));

        for (var iter = 1; iter < maxIter && beta > eps1 && Norm(fNew) / normF0 > eps2; iter++)
        {
            if (Norm(fNew) > Norm(f))
            {
                beta /= 2.0;
            }

            jacobian = EvalJacobian(systemName, args, mode, 2, 2);
            f = EvalFuncsToSLAE(systemName, args, 2);

            dArgs = Gauss.Solve(jacobian, f);

            for (var i = 0; i < args.Length; i++)
            {
                args[i] += beta * dArgs[i];
            }

            fNew = EvalFuncs(systemName, args, 2);

            Utils.ShowStats(iter, beta, args, Norm(fNew));
        }

        return args;
    }

    private static double[] EvalFuncsToSLAE(string systemName, double[] x, int funcsNum)
    {
        var f = EvalFuncs(systemName, x, funcsNum);

        for (var i = 0; i < funcsNum; i++)
        {
            f[i] *= -1;
        }

        return f;
    }

    private static double[] EvalFuncs(string systemName, double[] args, int funcsNum)
    {
        var f = new double[funcsNum];

        switch (systemName)
        {
            case "Intersect1PointCircle":
                for (var i = 0; i < funcsNum; i++)
                {
                    f[i] = SOE.Intersect1PointCircle(i, args);
                }

                break;

            case "Intersect2PointCircle":
                for (var i = 0; i < funcsNum; i++)
                {
                    f[i] = SOE.Intersect2PointCircle(i, args);
                }

                break;


            case "Intersect0PointCircle":
                for (var i = 0; i < funcsNum; i++)
                {
                    f[i] = SOE.Intersect0PointCircle(i, args);
                }

                break;


            case "Intersect1PointCircleLine":
                for (var i = 0; i < funcsNum; i++)
                {
                    f[i] = SOE.Intersect1PointCircleLine(i, args);
                }

                break;

            case "Intersect3Line":
                for (var i = 0; i < funcsNum; i++)
                {
                    f[i] = SOE.Intersect3Line(i, args);
                }

                break;

            case "Sin":
                for (var i = 0; i < funcsNum; i++)
                {
                    f[i] = SOE.Sin(i, args);
                }

                break;

            default:
                throw new ArgumentException("No such systemName exist.");
        }

        return f;
    }

    private static double[] EvalConvFunc(
        string systemName,
        double[] args,
        int i
    )
    {
        return i switch
        {
            0 => systemName switch
            {
                "Intersect1PointCircleLine" => new[] 
                {
                    args[0] * args[0] + args[1] * args[1] - 25,
                    ((args[0] - 10) * (args[0] - 10) + args[1] * args[1] - 25) * 
                    ((args[0] - 10) * (args[0] - 10) + args[1] * args[1] - 25) + (args[0] - args[1] + 5) * (args[0] - args[1] + 5)
                },

                "Intersect3Line" => new[]
                {
                    args[1] - args[0] + 5,
                    (args[1] + args[0] - 5) * (args[1] + args[0] - 5) + (args[1] - 2 * args[0] - 5) * (args[1] - 2 * args[0] - 5)
                },

                _ => throw new ArgumentOutOfRangeException(nameof(systemName), systemName, null)
            },
            1 => systemName switch
            {
                "Intersect1PointCircleLine" => new[]
                {
                    (args[0] - 10) * (args[0] - 10) + args[1] * args[1] - 25,
                    (args[0] * args[0] + args[1] * args[1] - 25) * 
                    (args[0] * args[0] + args[1] * args[1] - 25) + (args[0] - args[1] + 5) * (args[0] - args[1] + 5)
                },

                "Intersect3Line" => new[]
                {
                    args[1] - 2 * args[0] - 5,
                    (args[1] - args[0] + 5) * (args[1] - args[0] + 5) + (args[1] + args[0] - 5) * (args[1] + args[0] - 5)
                },

                _ => throw new ArgumentOutOfRangeException(nameof(systemName), systemName, null)
            },
            2 => systemName switch
            {
                "Intersect1PointCircleLine" => new[]
                {
                    (args[0] * args[0] + args[1] * args[1] - 25) * (args[0] * args[0] + args[1] * args[1] - 25) +
                    ((args[0] - 10) * (args[0] - 10) + args[1] * args[1] - 25) * ((args[0] - 10) * (args[0] - 10) + args[1] * args[1] - 25),
                    args[0] - args[1] + 5
                },

                "Intersect3Line" => new[]
                {
                    (args[1] - args[0] + 5) * (args[1] - args[0] + 5) + (args[1] - 2 * args[0] - 5) * (args[1] - 2 * args[0] - 5),
                    args[1] + args[0] - 5
                },

                _ => throw new ArgumentOutOfRangeException(nameof(systemName), systemName, null)
            },
            _ => throw new Exception("[Panic] ALL DIED")
        };
    }

    private static double[,] EvalJacobian(
        string systemName,
        double[] args,
        string mode,
        int funcsNum,
        int varsNum
    )
    {
        var jacobian = new double[varsNum, funcsNum];

        var evalDerivative = FuncDer.EvalAnalytic;

        if (mode == "Numerical")
        {
            evalDerivative = FuncDer.EvalNumerical;
        }

        for (var i = 0; i < funcsNum; i++)
        {
            for (var j = 0; j < varsNum; j++)
            {
                jacobian[i, j] = evalDerivative(systemName, args, i, j);
            }
        }

        return jacobian;
    }

    private static (double[,], double[]) EvalConvSystem(
        string systemName,
        double[] args,
        string mode,
        int funcsNum,
        int varsNum
    )
    {
        var f = EvalFuncs(systemName, args, funcsNum);

        var maxI = 0;
        var maxIVal = Math.Abs(f[0]);

        for (var i = 0; i < funcsNum; i++)
        {
            if (maxIVal < Math.Abs(f[i]))
            {
                maxIVal = Math.Abs(f[i]);
                maxI = i;
            }
        }

        return (EvalConvJacobian(systemName, args, maxI), EvalConvFunc(systemName, args, maxI));
    }

    private static double[,] EvalConvJacobian(
        string systemName,
        double[] args,
        int i
    )
    {
        return i switch
        {
            0 => systemName switch
            {
                "Intersect1PointCircleLine" => new[,] 
                {
                    {
                        2 * args[0], 
                        2 * args[1]
                    }, 
                    {
                        4 * (args[0] - 10) * (75 - 20 * args[0] + args[0] * args[0] + args[1] * args[1]) + 2 * (args[0] - args[1] + 5), 
                        4 * args[1] * (args[0] * args[0] - 20 * args[0] + args[1] * args[1] + 75) - 2 * (args[0] - args[1] + 5) 
                    }
                },

                "Intersect3Line" => new[,]
                {
                    {
                        -1.0, 1.0
                    },
                    {
                        10 * args[0] - 2 * args[1] + 10, 10 * args[0] - 2 * args[1] + 10
                    }
                },

                _ => throw new ArgumentOutOfRangeException(nameof(systemName), systemName, null)
            },
            1 => systemName switch
            {
                "Intersect1PointCircleLine" => new[,]
                {
                    {
                        2 * (args[0] - 10), 
                        2 * args[1]
                    },
                    {
                        4 * args[0] * (args[0] * args[0] + args[1] * args[1] - 25) + 2 * (args[0] - args[1] + 5),
                        4 * args[1] * (args[0] * args[0] + args[1] * args[1] - 25) - 2 * (args[0] - args[1] + 5)
                    }
                },

                "Intersect3Line" => new[,]
                {
                    {
                        -2.0, 1.0
                    },
                    {
                        4 * args[0] - 20, 4 * args[1]
                    }
                },
                _ => throw new ArgumentOutOfRangeException(nameof(systemName), systemName, null)
            },
            2 => systemName switch
            {
                "Intersect1PointCircleLine" => new[,]
                {
                    {
                        4 * args[0] * (args[0] * args[0] + args[1] * args[1] - 25) +
                        4 * (args[0] - 10) * (75 - 20 * args[0] + args[0] * args[0] + args[1] * args[1]),

                        4 * args[1] * (args[0] * args[0] + args[1] * args[1] - 25) +
                        4 * args[1] * (args[0] * args[0] - 20 * args[0] + args[1] * args[1] + 75) 
                    },
                    {
                        1.0, -1.0
                    }
                },

                "Intersect3Line" => new[,] {
                {
                    10 * args[0] - 6 * args[1] + 10, -6 * args[0] + 4 * args[1]
                },
                {
                    1.0, 1.0
                }},
                _ => throw new ArgumentOutOfRangeException(nameof(systemName), systemName, null)
            },
            _ => throw new Exception("[Panic] ALL DIED")
        };
    }
}