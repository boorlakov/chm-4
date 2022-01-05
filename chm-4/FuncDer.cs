using static chm_4.Function;

namespace chm_4;

public static class FuncDer
{
    /// <summary>
    /// Partial numerical derivative of i-th function by j-th argument
    /// </summary>
    /// <returns>Value of numerical derivative at given args point</returns>
    /// <exception cref="ArgumentException">If given invalid function</exception>
    public static double EvalNumerical(string systemName, double[] args, int i, int j)
    {
        const double h = 1e-7;

        var argsPlusH = new double[args.Length];
        args.AsSpan().CopyTo(argsPlusH);
        argsPlusH[j] += h;

        return systemName switch
        {
            "Intersect1PointCircle" => (Intersect1PointCircle(i, argsPlusH) - Intersect1PointCircle(i, args)) / h,
            "Intersect2PointCircle" => (Intersect2PointCircle(i, argsPlusH) - Intersect2PointCircle(i, args)) / h,
            "Intersect0PointCircle" => (Intersect0PointCircle(i, argsPlusH) - Intersect0PointCircle(i, args)) / h,
            "Intersect1PointCircleLine" => (Intersect1PointCircleLine(i, argsPlusH) - Intersect1PointCircleLine(i, args)) / h,
            "Intersect3Line" => (Intersect3Line(i, argsPlusH) - Intersect3Line(i, args)) / h,
            _ => throw new ArgumentException($"No such function as {systemName} exist.")
        };
    }

    /// <summary>
    /// Partial analytic derivative of i-th function by j-th argument
    /// </summary>
    /// <returns>Value of analytic derivative at given args point</returns>
    /// <exception cref="ArgumentException">If given invalid function</exception>
    public static double EvalAnalytic(string systemName, double[] args, int functionNum, int parameterNum)
    {
        switch (functionNum)
        {
            case 0:
                switch (parameterNum)
                {
                    case 0:
                        return systemName switch
                        {
                            "Intersect1PointCircle" => 2 * args[0],
                            "Intersect2PointCircle" => 2 * args[0],
                            "Intersect0PointCircle" => 2 * args[0],
                            "Intersect1PointCircleLine" => 2 * args[0],
                            "Intersect3Line" => -1.0,
                            _ => throw new ArgumentException($"No such function as {systemName} exist.")
                        };
                    case 1:
                        return systemName switch
                        {
                            "Intersect1PointCircle" => 2 * args[1],
                            "Intersect2PointCircle" => 2 * args[1],
                            "Intersect0PointCircle" => 2 * args[1],
                            "Intersect1PointCircleLine" => 2 * args[1],
                            "Intersect3Line" => 1.0,
                            _ => throw new ArgumentException($"No such function as {systemName} exist.")
                        };
                }

                break;
            case 1:
                switch (parameterNum)
                {
                    case 0:
                        return systemName switch
                        {
                            "Intersect1PointCircle" => 2 * (args[0] - 10),
                            "Intersect2PointCircle" => 2 * (args[0] - 9),
                            "Intersect0PointCircle" => 2 * (args[0] - 11),
                            "Intersect1PointCircleLine" => 2 * (args[0] - 10),
                            "Intersect3Line" => -2.0,
                            _ => throw new ArgumentException($"No such function as {systemName} exist.")
                        };
                    case 1:
                        return systemName switch
                        {
                            "Intersect1PointCircle" => 2 * args[1],
                            "Intersect2PointCircle" => 2 * args[1],
                            "Intersect0PointCircle" => 2 * args[1],
                            "Intersect1PointCircleLine" => 2 * args[1],
                            "Intersect3Line" => 1.0,
                            _ => throw new ArgumentException($"No such function as {systemName} exist.")
                        };
                }

                break;
            case 2:
                switch (parameterNum)
                {
                    case 0:
                        return systemName switch
                        {
                            "Intersect1PointCircleLine" => -1.0,
                            "Intersect3Line" => 1.0,
                            _ => throw new ArgumentException($"No such function as {systemName} exist.")
                        };
                    case 1:
                        return systemName switch
                        {
                            "Intersect1PointCircleLine" => 1.0,
                            "Intersect3Line" => 1.0,
                            _ => throw new ArgumentException($"No such function as {systemName} exist.")
                        };
                }

                break;
        }

        throw new Exception("[PANIC] All died");
    }
}