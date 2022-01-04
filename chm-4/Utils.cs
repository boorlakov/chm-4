using System.Text;

namespace chm_4;

public static class Utils
{
    private static double[] ReadDoubles(StreamReader file)
    {
        return file
            .ReadLine()!
            .Trim()
            .Split(' ')
            .Select(double.Parse)
            .ToArray();
    }

    private static int[] ReadInts(StreamReader file)
    {
        return file
            .ReadLine()!
            .Trim()
            .Split(' ')
            .Select(int.Parse)
            .ToArray();
    }

    /// <summary>
    /// Read vector from file, values separated by comma. Use another name for more concrete sense
    /// </summary>
    /// <param name="file">Already opened file</param>
    /// <returns>Static double array</returns>
    public static double[] VectorFromFile(StreamReader file) => ReadDoubles(file);

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