namespace chm_4.LinAlg;

public static class GeneralOperations
{
    /// <summary>
    /// Calculates Euclidean norm of vector in R 
    /// </summary>
    /// <param name="x">Vector with double elements</param>
    /// <returns>Euclidean norm value of vector in R</returns>
    public static double Norm(double[] x) => Math.Sqrt(x.Sum(t => t * t));
}