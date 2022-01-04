using static chm_4.Function;

namespace chm_4;

public static class FuncDer
{
    /// <summary>
    /// Numerical derivative of i-th function that given upper
    /// </summary>
    /// <returns>Value of numerical derivative at given x point</returns>
    /// <exception cref="ArgumentException">If given invalid function</exception>
    public static double CalcNumerical(string functionName, double[] x, int i)
    {
        const double h = 1e-7;

        var xPlusH = new double[x.Length];

        for (var j = 0; j < xPlusH.Length; j++)
        {
            xPlusH[i] = x[i] + h;
        }

        return i switch
        {
            0 => functionName switch
            {
                "Intersect1PointCircle" => (Intersect1PointCircle(i, xPlusH) - Intersect1PointCircle(i, x)) / h,
                "Intersect2PointCircle" => (Intersect2PointCircle(i, xPlusH) - Intersect2PointCircle(i, x)) / h,
                "Intersect0PointCircle" => (Intersect0PointCircle(i, xPlusH) - Intersect0PointCircle(i, x)) / h,
                "Intersect1PointCircleLine" => (Intersect1PointCircleLine(i, xPlusH) - Intersect1PointCircleLine(i, x)) / h,
                "Intersect3Line" => (Intersect3Line(i, xPlusH) - Intersect3Line(i, x)) / h,
                _ => throw new ArgumentException($"No such function as {functionName} exist.")
            },
            1 => functionName switch
            {
                "Intersect1PointCircle" => (Intersect1PointCircle(i, xPlusH) - Intersect1PointCircle(i, x)) / h,
                "Intersect2PointCircle" => (Intersect2PointCircle(i, xPlusH) - Intersect2PointCircle(i, x)) / h,
                "Intersect0PointCircle" => (Intersect0PointCircle(i, xPlusH) - Intersect0PointCircle(i, x)) / h,
                "Intersect1PointCircleLine" => (Intersect1PointCircleLine(i, xPlusH) - Intersect1PointCircleLine(i, x)) / h,
                "Intersect3Line" => (Intersect3Line(i, xPlusH) - Intersect3Line(i, x)) / h,
                _ => throw new ArgumentException($"No such function as {functionName} exist.")
            },
            2 => functionName switch
            {
                "Intersect1PointCircleLine" => (Intersect1PointCircleLine(i, xPlusH) - Intersect1PointCircleLine(i, x)) / h,
                "Intersect3Line" => (Intersect3Line(i, xPlusH) - Intersect3Line(i, x)) / h,
                _ => throw new ArgumentException($"No such function as {functionName} exist.")
            },
            _ => throw new ArgumentException($"No such index ({i}) exist.")
        };
    }

    /// <summary>
    /// Analytic derivative of i-th function that given upper
    /// </summary>
    /// <returns>Value of analytic derivative at given x point</returns>
    /// <exception cref="ArgumentException">If given invalid function</exception>
    /// <exception cref="Exception">If switch doesn't work properly</exception>
    public static double CalcAnalytic(string functionName, double[] x, int i)
    {
        const double h = 1e-7;

        var xPlusH = new double[x.Length];

        for (var j = 0; j < xPlusH.Length; j++)
        {
            xPlusH[i] = x[i] + h;
        }

        return i switch
        {
            0 => functionName switch
            {
                "Intersect1PointCircle" => (Intersect1PointCircle(i, xPlusH) - Intersect1PointCircle(i, x)) / h,
                "Intersect2PointCircle" => (Intersect2PointCircle(i, xPlusH) - Intersect2PointCircle(i, x)) / h,
                "Intersect0PointCircle" => (Intersect0PointCircle(i, xPlusH) - Intersect0PointCircle(i, x)) / h,
                "Intersect1PointCircleLine" =>
                    (Intersect1PointCircleLine(i, xPlusH) - Intersect1PointCircleLine(i, x)) / h,
                "Intersect3Line" => (Intersect3Line(i, xPlusH) - Intersect3Line(i, x)) / h,
                _ => throw new ArgumentException($"No such function as {functionName} exist.")
            },
            1 => functionName switch
            {
                "Intersect1PointCircle" => (Intersect1PointCircle(i, xPlusH) - Intersect1PointCircle(i, x)) / h,
                "Intersect2PointCircle" => (Intersect2PointCircle(i, xPlusH) - Intersect2PointCircle(i, x)) / h,
                "Intersect0PointCircle" => (Intersect0PointCircle(i, xPlusH) - Intersect0PointCircle(i, x)) / h,
                "Intersect1PointCircleLine" =>
                    (Intersect1PointCircleLine(i, xPlusH) - Intersect1PointCircleLine(i, x)) / h,
                "Intersect3Line" => (Intersect3Line(i, xPlusH) - Intersect3Line(i, x)) / h,
                _ => throw new ArgumentException($"No such function as {functionName} exist.")
            },
            2 => functionName switch
            {
                "Intersect1PointCircleLine" => (Intersect1PointCircleLine(i, xPlusH) -
                                                Intersect1PointCircleLine(i, x)) / h,
                "Intersect3Line" => (Intersect3Line(i, xPlusH) - Intersect3Line(i, x)) / h,
                _ => throw new ArgumentException($"No such function as {functionName} exist.")
            },
            _ => throw new ArgumentException($"No such index ({i}) exist.")
        };
    }
}