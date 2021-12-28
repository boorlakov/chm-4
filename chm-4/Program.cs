﻿using System.Text.Json;

namespace chm_4;

internal static class Program
{
    public static void Main(string[] args)
    {
        var content = File.ReadAllText("params.json");
        var parameters = JsonSerializer.Deserialize<ParamsModel>(content);
        var solution = SONLE.Solve("IntersectingOnePointСircles", parameters!.InitApprox);
    }
} 