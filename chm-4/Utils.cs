using System.Text;

namespace chm_4;

public static class Utils
{

    /// <summary>
    /// Exports double static array to file
    /// </summary>
    /// <param name="outputFileName">FileName, where exported</param>
    /// <param name="vectorX">Array to export</param>
    public static void ExportToFile(string outputFileName, double[] vectorX)
    {
        using var outputFile = new StreamWriter(outputFileName);
        
        var sb = new StringBuilder();

        foreach (var item in vectorX)
        {
            sb.Append($"{item:G15} ");
        }

        var text = sb.ToString();

        outputFile.Write(text);
    }

    /// <summary>
    /// Prints array in console with space separated values
    /// </summary>
    /// <param name="vectorX">Array to print</param>
    public static void Pprint(double[] vectorX)
    {
        Console.WriteLine("\nVector PPRINT:");

        foreach (var item in vectorX)
        {
            Console.Write($"{item:G15} ");
        }

        Console.WriteLine();
    }

    public static void ShowStats(int iter, double beta, double[] x, double normF)
    {
        var sb = new StringBuilder($"\r[INFO] iter: {iter}; beta: {beta:G7}; args: [ ");
        foreach (var item in x)
        {
            sb.Append($"{item:G7} ");
        }
        sb.Append($"]; ||F||: {normF:G7};                              ");
        Console.Write(sb.ToString());
    }
}