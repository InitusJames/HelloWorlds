using HelloWorlds;
using ManyHellos;

List<Score> scores = new List<Score>();
int testIterations = 100000;
string filename = "ManyHellos.dll";

//HelloWorld s = new ByStaticString();

if (File.Exists(filename))
{

    foreach (var hello in LoadHelloWorld.Load(File.ReadAllBytes(filename)))
    {
        GC.Collect();

        if (hello != null)
        {
            var time = ExecuteMethod.Execute(hello, testIterations);
            scores.Add(new Score() { Assembly = hello.FullName, AverageTime = time / (double)testIterations, TotalTime = time });
        }
    }
}


//Dump the results, there is no winner here, just interesting details.

foreach (var score in scores)
    Console.WriteLine($"{score.Assembly} : Total = {score.TotalTime}ms || Average = {score.AverageTime}ms");

Console.ReadLine();