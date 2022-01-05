using System.Text.Json;

namespace chm_4;

internal static class Program
{
    public static void Main(string[] args)
    {
        var content = File.ReadAllText("params.json");
        var inputParameters = JsonSerializer.Deserialize<ParamsModel>(content);

        var sonleParameters = new SONLEParams(2, 2, "Intersect2PointCircle");

        var solution = SONLE.Solve(
            sonleParameters.SystemName,
            sonleParameters.FuncsNum,
            sonleParameters.VarsNum,
            inputParameters!.InitApprox, 
            inputParameters.Mode,
            inputParameters.MaxIter,
            inputParameters.Eps1,
            inputParameters.Eps2
        );

        Utils.ExportToFile("solution.txt", solution);
    }
} 