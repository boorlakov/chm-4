namespace chm_4.LinAlg;

public static class GeneralOperations
{
    public static double Norm(double[] x) => Math.Sqrt(x.Sum(t => t * t));
}