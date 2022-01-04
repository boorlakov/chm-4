using System.Text;

namespace chm_4;

public static class Utils
{

    /// <summary>
    /// Exports double static array to already opened file
    /// </summary>
    /// <param name="outputFile">File, where exported</param>
    /// <param name="vectorX">Array to export</param>
    public static void ExportToFile(StreamWriter outputFile, double[] vectorX)
    {
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
}