namespace chm_4;

public static class Function
{
    /// <summary>
    /// SOE kind of
    /// 1) x^2 + y^2 = 25
    /// 2) (x - 11)^2 - y^2 = 25
    /// </summary>
    /// <returns></returns>
    /// <exception cref="ArgumentException">If required more than 2 equations</exception>
    public static double IntersectingNoPointsСircles(int i, double[] x)
    {
        return i switch
        {
            0 => x[0] * x[0] + x[1] * x[1] - 25,
            1 => (x[0] - 11) * (x[0] - 11) - x[1] * x[1] - 25,
            _ => throw new ArgumentException($"No such index ({i}) exist")
        };
    }

    /// <summary>
    /// SOE kind of
    /// 1) x^2 + y^2 = 25
    /// 2) (x - 10)^2 - y^2 = 25
    /// </summary>
    /// <returns></returns>
    /// <exception cref="ArgumentException">If required more than 2 equations</exception>
    public static double IntersectingOnePointСircles(int i, double[] x)
    {
        return i switch
        {
            0 => x[0] * x[0] + x[1] * x[1] - 25,
            1 => (x[0] - 10) * (x[0] - 10) - x[1] * x[1] - 25,
            _ => throw new ArgumentException($"No such index ({i}) exist")
        };
    }

    /// <summary>
    /// SOE kind of
    /// 1) x^2 + y^2 = 25
    /// 2) (x - 9)^2 - y^2 = 25
    /// </summary>
    /// <returns></returns>
    /// <exception cref="ArgumentException">If required more than 2 equations</exception>
    public static double IntersectingTwoPointsСircles(int i, double[] x)
    {
        return i switch
        {
            0 => x[0] * x[0] + x[1] * x[1] - 25,
            1 => (x[0] - 9) * (x[0] - 9) - x[1] * x[1] - 25,
            _ => throw new ArgumentException($"No such index ({i}) exist")
        };
    }

    /// <summary>
    /// SOE kind of
    /// 1) x^2 + y^2 = 25
    /// 2) (x - 10)^2 - y^2 = 25
    /// 3) x - y = -5
    /// </summary>
    /// <returns></returns>
    /// <exception cref="ArgumentException">If required more than 3 equations</exception>
    public static double IntersectingOnePointСirclesWithLine(int i, double[] x)
    {
        return i switch
        {
            0 => x[0] * x[0] + x[1] * x[1] - 25,
            1 => (x[0] - 10) * (x[0] - 10) - x[1] * x[1] - 25,
            2 => x[1] - x[0] + 5,
            _ => throw new ArgumentException($"No such index ({i}) exist")
        };
    }

    /// <summary>
    /// SOE kind of
    /// 1) y - x = -5
    /// 2) y - 2x = 5
    /// 3) y + x = 5
    /// </summary>
    /// <returns></returns>
    /// <exception cref="ArgumentException">If required more than 3 equations</exception>
    public static double ThreeIntersectingLines(int i, double[] x)
    {
        return i switch
        {
            0 => x[1] - x[0] + 5,
            1 => x[1] - 2 * x[0] - 5,
            2 => x[1] + x[0] - 5,
            _ => throw new ArgumentException($"No such index ({i}) exist")
        };
    }

    /// <summary>
    /// Numerical derivative of i-th function that given upper
    /// </summary>
    /// <returns>Value of numerical derivative at given x point</returns>
    /// <exception cref="ArgumentException">If given invalid function</exception>
    /// <exception cref="Exception">If switch doesn't work properly</exception>
    public static double NumericalDerivative(string functionName, double[] x, int i)
    {
        switch (i)
        {
            case 0:
                switch (functionName)
                {
                    case "IntersectingOnePointСircles":

                        break;

                    case "IntersectingTwoPointsСircles":

                        break;

                    case "IntersectingNoPointsСircles":

                        break;

                    case "IntersectingOnePointСirclesWithLine":

                        break;

                    case "ThreeIntersectingLines":

                        break;

                    default:
                        throw new ArgumentException($"No such function as {functionName} exist.");
                }

                break;

            case 1:
                switch (functionName)
                {
                    case "IntersectingOnePointСircles":

                        break;

                    case "IntersectingTwoPointsСircles":

                        break;

                    case "IntersectingNoPointsСircles":

                        break;

                    case "IntersectingOnePointСirclesWithLine":

                        break;

                    case "ThreeIntersectingLines":

                        break;

                    default:
                        throw new ArgumentException($"No such function as {functionName} exist.");
                }

                break;

            case 2:
                switch (functionName)
                {
                    case "IntersectingOnePointСirclesWithLine":

                        break;

                    case "ThreeIntersectingLines":

                        break;

                    default:
                        throw new ArgumentException($"No such function as {functionName} exist.");
                }

                break;
            default:
                throw new ArgumentException($"No such index ({i}) exist.");
        }

        throw new Exception($"Numerical derivative is broken");
    }

    /// <summary>
    /// Analytic derivative of i-th function that given upper
    /// </summary>
    /// <returns>Value of analytic derivative at given x point</returns>
    /// <exception cref="ArgumentException">If given invalid function</exception>
    /// <exception cref="Exception">If switch doesn't work properly</exception>
    public static double AnalyticDerivative(string functionName, double[] x, int i)
    {
        switch (i)
        {
            case 0:
                switch (functionName)
                {
                    case "IntersectingOnePointСircles":

                        break;

                    case "IntersectingTwoPointsСircles":

                        break;

                    case "IntersectingNoPointsСircles":

                        break;

                    case "IntersectingOnePointСirclesWithLine":

                        break;

                    case "ThreeIntersectingLines":

                        break;

                    default:
                        throw new ArgumentException($"No such function as {functionName} exist.");
                }

                break;
            case 1:
                switch (functionName)
                {
                    case "IntersectingOnePointСircles":

                        break;

                    case "IntersectingTwoPointsСircles":

                        break;

                    case "IntersectingNoPointsСircles":

                        break;

                    case "IntersectingOnePointСirclesWithLine":

                        break;

                    case "ThreeIntersectingLines":

                        break;

                    default:
                        throw new ArgumentException($"No such function as {functionName} exist.");
                }

                break;
            case 2:
                switch (functionName)
                {
                    case "IntersectingOnePointСirclesWithLine":

                        break;

                    case "ThreeIntersectingLines":

                        break;

                    default:
                        throw new ArgumentException($"No such function as {functionName} exist.");
                }

                break;
            default:
                throw new ArgumentException($"No such index ({i}) exist.");
        }

        throw new Exception($"Analytical derivative is broken");
    }
}