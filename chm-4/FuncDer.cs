using static chm_4.Function;

namespace chm_4;

public static class FuncDer
{
    /// <summary>
    /// Numerical derivative of i-th function that given upper
    /// </summary>
    /// <returns>Value of numerical derivative at given args point</returns>
    /// <exception cref="ArgumentException">If given invalid function</exception>
    public static double CalcNumerical(string functionName, double[] args, int i)
    {
        const double h = 1e-7;

        var argsPlusH = new double[args.Length];
        args.AsSpan().CopyTo(argsPlusH);
        argsPlusH[i] = args[i] + h;
        
        return i switch
        {
            0 => functionName switch
            {
                "Intersect1PointCircle" => (Intersect1PointCircle(i, argsPlusH) - Intersect1PointCircle(i, args)) / h,
                "Intersect2PointCircle" => (Intersect2PointCircle(i, argsPlusH) - Intersect2PointCircle(i, args)) / h,
                "Intersect0PointCircle" => (Intersect0PointCircle(i, argsPlusH) - Intersect0PointCircle(i, args)) / h,
                "Intersect1PointCircleLine" => (Intersect1PointCircleLine(i, argsPlusH) - Intersect1PointCircleLine(i, args)) / h,
                "Intersect3Line" => (Intersect3Line(i, argsPlusH) - Intersect3Line(i, args)) / h,
                _ => throw new ArgumentException($"No such function as {functionName} exist.")
            },
            1 => functionName switch
            {
                "Intersect1PointCircle" => (Intersect1PointCircle(i, argsPlusH) - Intersect1PointCircle(i, args)) / h,
                "Intersect2PointCircle" => (Intersect2PointCircle(i, argsPlusH) - Intersect2PointCircle(i, args)) / h,
                "Intersect0PointCircle" => (Intersect0PointCircle(i, argsPlusH) - Intersect0PointCircle(i, args)) / h,
                "Intersect1PointCircleLine" => (Intersect1PointCircleLine(i, argsPlusH) - Intersect1PointCircleLine(i, args)) / h,
                "Intersect3Line" => (Intersect3Line(i, argsPlusH) - Intersect3Line(i, args)) / h,
                _ => throw new ArgumentException($"No such function as {functionName} exist.")
            },
            2 => functionName switch
            {
                "Intersect1PointCircleLine" => (Intersect1PointCircleLine(i, argsPlusH) - Intersect1PointCircleLine(i, args)) / h,
                "Intersect3Line" => (Intersect3Line(i, argsPlusH) - Intersect3Line(i, args)) / h,
                _ => throw new ArgumentException($"No such function as {functionName} exist.")
            },
            _ => throw new ArgumentException($"No such index ({i}) exist.")
        };
    }

    /// <summary>
    /// Analytic derivative of i-th function that given upper
    /// </summary>
    /// <returns>Value of analytic derivative at given args point</returns>
    /// <exception cref="ArgumentException">If given invalid function</exception>
    /// <exception cref="Exception">If switch doesn't work properly</exception>
    public static double CalcAnalytic(string functionName, double[] args, int i)
    {
        const double h = 1e-7;

        var argsPlusH = new double[args.Length];

        for (var j = 0; j < argsPlusH.Length; j++)
        {
            argsPlusH[i] = args[i] + h;
        }

        return i switch
        {
            0 => functionName switch
            {
                "Intersect1PointCircle" => (Intersect1PointCircle(i, argsPlusH) - Intersect1PointCircle(i, args)) / h,
                "Intersect2PointCircle" => (Intersect2PointCircle(i, argsPlusH) - Intersect2PointCircle(i, args)) / h,
                "Intersect0PointCircle" => (Intersect0PointCircle(i, argsPlusH) - Intersect0PointCircle(i, args)) / h,
                "Intersect1PointCircleLine" =>
                    (Intersect1PointCircleLine(i, argsPlusH) - Intersect1PointCircleLine(i, args)) / h,
                "Intersect3Line" => (Intersect3Line(i, argsPlusH) - Intersect3Line(i, args)) / h,
                _ => throw new ArgumentException($"No such function as {functionName} exist.")
            },
            1 => functionName switch
            {
                "Intersect1PointCircle" => (Intersect1PointCircle(i, argsPlusH) - Intersect1PointCircle(i, args)) / h,
                "Intersect2PointCircle" => (Intersect2PointCircle(i, argsPlusH) - Intersect2PointCircle(i, args)) / h,
                "Intersect0PointCircle" => (Intersect0PointCircle(i, argsPlusH) - Intersect0PointCircle(i, args)) / h,
                "Intersect1PointCircleLine" =>
                    (Intersect1PointCircleLine(i, argsPlusH) - Intersect1PointCircleLine(i, args)) / h,
                "Intersect3Line" => (Intersect3Line(i, argsPlusH) - Intersect3Line(i, args)) / h,
                _ => throw new ArgumentException($"No such function as {functionName} exist.")
            },
            2 => functionName switch
            {
                "Intersect1PointCircleLine" => (Intersect1PointCircleLine(i, argsPlusH) -
                                                Intersect1PointCircleLine(i, args)) / h,
                "Intersect3Line" => (Intersect3Line(i, argsPlusH) - Intersect3Line(i, args)) / h,
                _ => throw new ArgumentException($"No such function as {functionName} exist.")
            },
            _ => throw new ArgumentException($"No such index ({i}) exist.")
        };
    }
}