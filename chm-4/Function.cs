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
    public static double Intersect0PointCircle(int i, double[] x)
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
    public static double Intersect1PointCircle(int i, double[] x)
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
    public static double Intersect2PointCircle(int i, double[] x)
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
    public static double Intersect1PointCircleLine(int i, double[] x)
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
    public static double Intersect3Line(int i, double[] x)
    {
        return i switch
        {
            0 => x[1] - x[0] + 5,
            1 => x[1] - 2 * x[0] - 5,
            2 => x[1] + x[0] - 5,
            _ => throw new ArgumentException($"No such index ({i}) exist")
        };
    }
}