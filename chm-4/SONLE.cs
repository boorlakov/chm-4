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
        var jacobian = EvalJacobian(systemName, initApprox, mode, funcsNum, varsNum);
        var f = EvalFuncsToSLAE(systemName, initApprox, funcsNum);

        var normF0 = Norm(f);

        var dArgs = Gauss.Solve(jacobian, f);

        var beta = 1.0;

        var args = new double[initApprox.Length];

        for (var i = 0; i < args.Length; i++)
        {
            args[i] += beta * dArgs[i];
        }

        var fNew = EvalFuncs(systemName, args, funcsNum);
        Utils.ShowStats(0, beta, args, Norm(fNew));

        for (var iter = 1; iter < maxIter && beta > eps1 && Norm(fNew) / normF0 > eps2; iter++)
        {
            if (Norm(fNew) > Norm(f))
            {
                beta /= 2.0;
            }

            jacobian = EvalJacobian(systemName, args, mode, funcsNum, varsNum);
            f = EvalFuncsToSLAE(systemName, args, funcsNum);

            dArgs = Gauss.Solve(jacobian, f);

            for (var i = 0; i < args.Length; i++)
            {
                args[i] += beta * dArgs[i];
            }

            fNew = EvalFuncs(systemName, args, funcsNum);

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
        var f = new double[args.Length];

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

            default:
                throw new ArgumentException("No such systemName exist.");
        }

        return f;
    }

    private static double[,] EvalJacobian(
        string systemName,
        double[] args,
        string mode,
        int funcsNum,
        int varsNum
    )
    {
        var jacobianTrial = new double[varsNum, funcsNum];
        var f = EvalFuncs(systemName, args, funcsNum);

        var evalDerivative = FuncDer.EvalAnalytic;

        if (mode == "Numerical")
        {
            evalDerivative = FuncDer.EvalNumerical;
        }

        for (var i = 0; i < funcsNum; i++)
        {
            for (var j = 0; j < varsNum; j++)
            {
                jacobianTrial[i, j] = evalDerivative(systemName, args, i, j);
            }
        }

        if (varsNum == funcsNum)
        {
            return jacobianTrial;
        }
        else
        {
            var jacobian = new double[args.Length, args.Length];
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

            for (var i = 0; i < funcsNum; i++)
            {
                if (i == maxI)
                {
                    continue;
                }

                // TODO: Add elimination
            }
        }

    }
}