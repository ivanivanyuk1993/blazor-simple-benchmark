using System;
using System.Linq;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorCheck.Pages
{
    public partial class Index
    {
        [Inject]
        private IJSRuntime _jsRuntime { get; set; }
        private readonly Random _random = new();
        readonly string cSharpBenchmarkIntsText = @"
// C# benchmark with ints
var randomCount = (int) 1e7;
var randomList = Enumerable
    .Range(0, randomCount)
    .Select(_ => _random.Next())
    .ToArray();
var randomSum = 0;
var startTime = DateTime.Now;
for (var i = 0; i < randomCount; i++)
{
    randomSum += randomList[i];
}
var finishTime = DateTime.Now;
Console.WriteLine(randomSum);
Console.WriteLine((finishTime - startTime).TotalMilliseconds);
_jsRuntime.InvokeVoidAsync(""alert"", $""Took {(finishTime - startTime).TotalMilliseconds}} ms"");
";

        readonly string cSharpBenchmarkDoublesText = @"
// C# benchmark with doubles
var randomCount = (int) 1e7;
var randomList = Enumerable
    .Range(0, randomCount)
    .Select(_ => _random.NextDouble())
    .ToArray();
double randomSum = 0;
var startTime = DateTime.Now;
for (var i = 0; i < randomCount; i++)
{
    randomSum += randomList[i];
}
var finishTime = DateTime.Now;
Console.WriteLine(randomSum);
Console.WriteLine((finishTime - startTime).TotalMilliseconds);
_jsRuntime.InvokeVoidAsync(""alert"", $""Took {(finishTime - startTime).TotalMilliseconds} ms"");
";

        readonly string jsBenchmarkText = @"
// JavaScript benchmark
var randomCount = 1e7;
var randomList = [...Array(randomCount).keys()].map(_ => Math.random());
var randomSum = 0;
var startTime = Date.now();
for (var i = 0; i < randomCount; i++)
{
    randomSum += randomList[i];
}
var finishTime = Date.now();
console.log(randomSum);
console.log(finishTime - startTime);
alert(`Took ${finishTime - startTime} ms`);
";

        public void BenchmarkInts()
        {
            // C# benchmark with ints
            var randomCount = (int) 1e7;
            var randomList = Enumerable
                .Range(0, randomCount)
                .Select(_ => _random.Next())
                .ToArray();
            var randomSum = 0;
            var startTime = DateTime.Now;
            for (var i = 0; i < randomCount; i++)
            {
                randomSum += randomList[i];
            }
            var finishTime = DateTime.Now;
            Console.WriteLine(randomSum);
            Console.WriteLine((finishTime - startTime).TotalMilliseconds);
            _jsRuntime.InvokeVoidAsync("alert", $"Took {(finishTime - startTime).TotalMilliseconds} ms");
        }

        public void BenchmarkDoubles()
        {
            // C# benchmark with doubles
            var randomCount = (int) 1e7;
            var randomList = Enumerable
                .Range(0, randomCount)
                .Select(_ => _random.NextDouble())
                .ToArray();
            double randomSum = 0;
            var startTime = DateTime.Now;
            for (var i = 0; i < randomCount; i++)
            {
                randomSum += randomList[i];
            }
            var finishTime = DateTime.Now;
            Console.WriteLine(randomSum);
            Console.WriteLine((finishTime - startTime).TotalMilliseconds);
            _jsRuntime.InvokeVoidAsync("alert", $"Took {(finishTime - startTime).TotalMilliseconds} ms");
        }
    }
}
