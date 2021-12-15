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

    public static double[] VectorFromFile(StreamReader file) => ReadDoubles(file);

    public static void ExportToFile(StreamWriter outputFile, double[] vectorX, double[] absVector)
    {
        var sb = new StringBuilder();

        foreach (var item in vectorX)
        {
            sb.AppendFormat("{0:G15} ", item);
        }

        sb.Append('\n');

        foreach (var item in absVector)
        {
            sb.AppendFormat("{0:G15} ", item);
        }

        var text = sb.ToString();

        outputFile.Write(text);
    }

    public static void Pprint(double[] vectorX)
    {
        Console.WriteLine("\nVector PPRINT:");

        foreach (var item in vectorX)
        {
            Console.Write("{0:G15} ", item);
        }

        Console.WriteLine();
    }
}