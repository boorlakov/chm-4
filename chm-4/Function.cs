namespace chm_4;

public static class Function
{
    public static double IntersectingNoPointsСircles(int i, double[] x)
    {
        return i switch
        {
            0 => x[0] * x[0] + x[1] * x[1] - 25,
            1 => (x[0] - 11) * (x[0] - 11) - x[1] * x[1] - 25,
            _ => throw new ArgumentException($"No such index ({i}) exist")
        };
    }

    public static double IntersectingOnePointСircles(int i, double[] x)
    {
        return i switch
        {
            0 => x[0] * x[0] + x[1] * x[1] - 25,
            1 => (x[0] - 10) * (x[0] - 10) - x[1] * x[1] - 25,
            _ => throw new ArgumentException($"No such index ({i}) exist")
        };
    }

    public static double IntersectingTwoPointsСircles(int i, double[] x)
    {
        return i switch
        {
            0 => x[0] * x[0] + x[1] * x[1] - 25,
            1 => (x[0] - 9) * (x[0] - 9) - x[1] * x[1] - 25,
            _ => throw new ArgumentException($"No such index ({i}) exist")
        };
    }

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