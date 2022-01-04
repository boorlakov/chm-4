using static chm_4.LinAlg.GeneralOperations;

namespace chm_4;

/// <summary>
/// System of non-linear equations
/// </summary>
public class SONLE
{
    private static int FunctionsNumber { get; set; }
    private static int VariablesNumber { get; set; }

    /// <summary>
    /// Solves system of non-linear equations with Newton's method
    /// </summary>
    /// <param name="testName"> Switching in tests names, valid names is:
    /// "Intersect1PointCircle",
    /// "Intersect2PointCircle",
    /// "Intersect0PointCircle",
    /// "Intersect1PointCircleLine",
    /// "Intersect3Line".
    /// </param>
    /// <param name="initApprox"> Initial approximation. </param>
    /// <returns> Solution vector </returns>
    /// <exception cref="ArgumentException"> If passes invalid test name </exception>
    public static double[] Solve(string testName, double[] initApprox, string mode)
    {
        var jacobi = CalcJacobi(testName, initApprox, mode);
        var f = CalcFSLAE(testName, initApprox);

        var dx = LinAlg.Gauss.Solve(jacobi, f);

        var x = new double[initApprox.Length];
        var beta = 1;

        for (var i = 0; i < x.Length; i++)
        {
            x[i] += beta * dx[i];
        }

        var fNew = CalcF(testName, initApprox);

        if (Norm(fNew) < Norm(f))
        {
            beta /= 2;
        }

        return x;
    }
                          
    private static double[] CalcFSLAE(string systemName, double[] initApprox)
    {
        var f = new double[initApprox.Length];

        switch (systemName)
        {
            case "Intersect1PointCircle":
                FunctionsNumber = 2;
                VariablesNumber = 2;

                for (var i = 0; i < FunctionsNumber; i++)
                {
                    f[i] = Function.Intersect1PointCircle(i, initApprox);
                }

                break;

            case "Intersect2PointCircle":
                FunctionsNumber = 2;
                VariablesNumber = 2;

                for (var i = 0; i < FunctionsNumber; i++)
                {
                    f[i] = Function.Intersect2PointCircle(i, initApprox);
                }

                break;


            case "Intersect0PointCircle":
                FunctionsNumber = 2;
                VariablesNumber = 2;

                for (var i = 0; i < FunctionsNumber; i++)
                {
                    f[i] = Function.Intersect0PointCircle(i, initApprox);
                }

                break;


            case "Intersect1PointCircleLine":
                FunctionsNumber = 3;
                VariablesNumber = 2;

                for (var i = 0; i < FunctionsNumber; i++)
                {
                    f[i] = Function.Intersect1PointCircleLine(i, initApprox);
                }

                break;

            case "Intersect3Line":
                FunctionsNumber = 3;
                VariablesNumber = 2;

                for (var i = 0; i < FunctionsNumber; i++)
                {
                    f[i] = Function.Intersect3Line(i, initApprox);
                }

                break;

            default:
                throw new ArgumentException("No such systemName exist.");
        }

        for (var i = 0; i < FunctionsNumber; i++)
        {
            f[i] *= -1;
        }

        return f;
    }

    private static double[] CalcF(string systemName, double[] initApprox)
    {
        var f = new double[initApprox.Length];

        switch (systemName)
        {
            case "Intersect1PointCircle":
                FunctionsNumber = 2;
                VariablesNumber = 2;

                for (var i = 0; i < FunctionsNumber; i++)
                {
                    f[i] = Function.Intersect1PointCircle(i, initApprox);
                }

                break;

            case "Intersect2PointCircle":
                FunctionsNumber = 2;
                VariablesNumber = 2;

                for (var i = 0; i < FunctionsNumber; i++)
                {
                    f[i] = Function.Intersect2PointCircle(i, initApprox);
                }

                break;


            case "Intersect0PointCircle":
                FunctionsNumber = 2;
                VariablesNumber = 2;

                for (var i = 0; i < FunctionsNumber; i++)
                {
                    f[i] = Function.Intersect0PointCircle(i, initApprox);
                }

                break;


            case "Intersect1PointCircleLine":
                FunctionsNumber = 3;
                VariablesNumber = 2;

                for (var i = 0; i < FunctionsNumber; i++)
                {
                    f[i] = Function.Intersect1PointCircleLine(i, initApprox);
                }

                break;

            case "Intersect3Line":
                FunctionsNumber = 3;
                VariablesNumber = 2;

                for (var i = 0; i < FunctionsNumber; i++)
                {
                    f[i] = Function.Intersect3Line(i, initApprox);
                }

                break;

            default:
                throw new ArgumentException("No such systemName exist.");
        }

        return f;
    }

    private static double[,] CalcJacobi(string systemName, double[] initApprox, string mode)
    {
        var jacobi = new double[initApprox.Length, initApprox.Length];

        var derivative = FuncDer.CalcAnalytic;

        if (mode == "Numerical")
        {
            derivative = FuncDer.CalcNumerical;
        }

        for (var i = 0; i < FunctionsNumber; i++)
        {
            for (var j = 0; j < VariablesNumber; j++)
            {
                jacobi[i, j] = derivative(systemName, initApprox, i, j);
            }
        }                

        return jacobi;
    }
}