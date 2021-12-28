namespace chm_4;

/// <summary>
/// System of non-linear equations
/// </summary>
public class SONLE
{
    public static int FunctionsNumber { get; private set; }
    public static int VariablesNumber { get; private set; }

    /// <summary>
    /// Solves system of non-linear equations
    /// </summary>
    /// <param name="testName"> Switching in tests names, valid names is:
    /// "IntersectingOnePointСircles",
    /// "IntersectingTwoPointsСircles",
    /// "IntersectingNoPointsСircles",
    /// "IntersectingOnePointСirclesWithLine",
    /// "ThreeIntersectingLines".
    /// </param>
    /// <param name="initApprox"> Initial approximation. </param>
    /// <returns> Solution vector </returns>
    /// <exception cref="ArgumentException"> If passes invalid test name </exception>
    public static double[] Solve(string testName, double[] initApprox)
    {
        var x = new double[initApprox.Length];

        switch (testName)
        {
           case "IntersectingOnePointСircles":
               for (var i = 0; i < FunctionsNumber; i++)
               {
                   Function.IntersectingOnePointСircles(i, initApprox);
               }
               break;

           case "IntersectingTwoPointsСircles":
               for (var i = 0; i < FunctionsNumber; i++)
               {
                   Function.IntersectingTwoPointsСircles(i, initApprox);
               }
               break;

           case "IntersectingNoPointsСircles":
               for (var i = 0; i < FunctionsNumber; i++)
               {
                   Function.IntersectingNoPointsСircles(i, initApprox);
               }
               break;

           case "IntersectingOnePointСirclesWithLine":
               for (var i = 0; i < FunctionsNumber; i++)
               {
                   Function.IntersectingOnePointСirclesWithLine(i, initApprox);
               }
               break;

           case "ThreeIntersectingLines":
               for (var i = 0; i < FunctionsNumber; i++)
               {
                   Function.ThreeIntersectingLines(i, initApprox);
               }
               break;

           default:
               throw new ArgumentException("No such testName exist.");
        }

        return x;
    }
}