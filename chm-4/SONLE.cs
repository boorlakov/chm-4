using System.Diagnostics.CodeAnalysis;
using static chm_4.LinAlg.GeneralOperations;
// ReSharper disable ReturnTypeCanBeEnumerable.Global

namespace chm_4;

/// <summary>
/// System of non-linear equations
/// </summary>
[SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
public class SONLE
{
    private static int FuncsNum { get; set; }
    private static int VarsNum { get; set; }

    /// <summary>
    /// Solves system of non-linear equations with Newton's method
    /// </summary>
    /// <param name="systemName"> Switching in system names, valid names is:
    ///     "Intersect1PointCircle",
    ///     "Intersect2PointCircle",
    ///     "Intersect0PointCircle",
    ///     "Intersect1PointCircleLine",
    ///     "Intersect3Line".
    /// </param>
    /// <param name="initApprox"> Initial approximation. </param>
    /// <param name="mode">Mode of differentiation (Analytical / Numerical).</param>
    /// <param name="maxIter">parameter for exiting by iteration expiration.</param>
    /// <param name="eps1">parameter for exiting by beta.</param>
    /// <param name="eps2">parameter for exiting by ||F_k|| / ||F_0||.</param>
    /// <returns> Solution vector. </returns>
    /// <exception cref="ArgumentException"> If passes invalid test name. </exception>
    public static double[] Solve(
        string systemName,
        double[] initApprox,
        string mode,
        int maxIter,
        double eps1,
        double eps2
    )
    {
        var jacobian = EvalJacobian(systemName, initApprox, mode);
        var f = EvalFuncsToSLAE(systemName, initApprox);
        
        var normF0 = Norm(f);

        var dx = LinAlg.Gauss.Solve(jacobian, f);
        
        var beta = 1.0;
        
        var x = new double[initApprox.Length];
        for (var i = 0; i < x.Length; i++)
        {
            x[i] += beta * dx[i];
        }

        var fNew = EvalFunc(systemName, x);
        Utils.ShowStats(0, beta, x, Norm(fNew));

        for (var iter = 1; iter < maxIter && beta > eps1 && Norm(fNew) / normF0 > eps2; iter++)
        {
            if (Norm(fNew) < Norm(f))
            {
                beta /= 2.0;
            }

            jacobian = EvalJacobian(systemName, x, mode);
            f = EvalFuncsToSLAE(systemName, x);

            dx = LinAlg.Gauss.Solve(jacobian, f);

            for (var i = 0; i < x.Length; i++)
            {
                x[i] += beta * dx[i];
            }

            fNew = EvalFunc(systemName, x);

            Utils.ShowStats(iter, beta, x, Norm(fNew));
        }

        return x;
    }

    private static double[] EvalFuncsToSLAE(string systemName, double[] initApprox)
    {
        var f = EvalFunc(systemName, initApprox);

        for (var i = 0; i < FuncsNum; i++)
        {
            f[i] *= -1;
        }

        return f;
    }

    private static double[] EvalFunc(string systemName, double[] initApprox)
    {
        var f = new double[initApprox.Length];

        switch (systemName)
        {
            case "Intersect1PointCircle":
                FuncsNum = 2;
                VarsNum = 2;

                for (var i = 0; i < FuncsNum; i++)
                {
                    f[i] = Function.Intersect1PointCircle(i, initApprox);
                }

                break;

            case "Intersect2PointCircle":
                FuncsNum = 2;
                VarsNum = 2;

                for (var i = 0; i < FuncsNum; i++)
                {
                    f[i] = Function.Intersect2PointCircle(i, initApprox);
                }

                break;


            case "Intersect0PointCircle":
                FuncsNum = 2;
                VarsNum = 2;

                for (var i = 0; i < FuncsNum; i++)
                {
                    f[i] = Function.Intersect0PointCircle(i, initApprox);
                }

                break;


            case "Intersect1PointCircleLine":
                FuncsNum = 3;
                VarsNum = 2;

                for (var i = 0; i < FuncsNum; i++)
                {
                    f[i] = Function.Intersect1PointCircleLine(i, initApprox);
                }

                break;

            case "Intersect3Line":
                FuncsNum = 3;
                VarsNum = 2;

                for (var i = 0; i < FuncsNum; i++)
                {
                    f[i] = Function.Intersect3Line(i, initApprox);
                }

                break;

            default:
                throw new ArgumentException("No such systemName exist.");
        }

        return f;
    }

    private static double[,] EvalJacobian(string systemName, double[] initApprox, string mode)
    {
        var jacobian = new double[initApprox.Length, initApprox.Length];

        var evalDerivative = FuncDer.EvalAnalytic;

        if (mode == "Numerical")
        {
            evalDerivative = FuncDer.EvalNumerical;
        }

        for (var i = 0; i < FuncsNum; i++)
        {
            for (var j = 0; j < VarsNum; j++)
            {
                jacobian[i, j] = evalDerivative(systemName, initApprox, i, j);
            }
        }                

        return jacobian;
    }
}