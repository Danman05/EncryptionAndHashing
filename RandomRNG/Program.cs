using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Xml.XPath;
namespace RandomRNG;

class Program
{
    static void Main(string[] args)
    {
        // Define integers
        int minNum = 0, maxNum = 1000;
        int numberOfTests = 100;


        //  Task 1  Generation of 100 random numers between 0-999

        // RNGCryptoServiceProvider
        List<int> numberRNG = RandomTest.TestRandomnessWithRNGCryptoServiceProvider(numberOfTests, minNum, maxNum);
        // numberRNG.Sort();

        // Console.WriteLine("RNGCryptoServiceProvider tilfældighedstest:");
        // for (int i = 0; i < numberRNG.Count; i++)
        // {
        //     Console.WriteLine($"RNG [{i+1}]: {numberRNG[i]}");
        // }

        // Random 
        List<int> numberRandom = RandomTest.TestRandomnessWithRandom(numberOfTests, minNum, maxNum);
        // numberRandom.Sort();
        // Console.WriteLine("Random tilfældighedstest:");
        // for (int i = 0; i < numberRandom.Count; i++)
        // {
        //     Console.WriteLine($"Random [{i+1}]: {numberRandom[i]}");
        // }


        // Task 2 - Generation of 1 million random numers between 0-999

        // RunBenchmark(RandomTest.TestRandomnessWithRNGCryptoServiceProvider(numberOfTests,minNum,maxNum), "RNG Crypto Service provider");

        numberOfTests = 1000000;

        // Using lambda expression to wrap the method call RandomTest.Methods(...)
        // This lambda expression matches the signature of Action, taking no arguments and returning void.
        RunBenchmark(() => RandomTest.TestRandomnessWithRNGCryptoServiceProvider(numberOfTests, minNum, maxNum), "RNG Crypto Service provider");
        RunBenchmark(() => RandomTest.TestRandomnessWithRandom(numberOfTests, minNum, maxNum), "Random provider");


        // Task 3 - Substition Encryption
        string rawValue = "Hello-World";
        string encryptedString = Encrypter.EncryptString(rawValue);
        System.Console.WriteLine(encryptedString);
        string decryptedString = Encrypter.DecryptString(encryptedString);
        System.Console.WriteLine(decryptedString);

    }

    /// <summary>
    ///  Benchmarks an method, captures elapsed time in ticks
    ///  Action Encapsulates a method that has no parameters and does not return a value.
    /// </summary>
    /// <param name="benchmarkMethod">The method to benchmark</param>
    /// <param name="methodName">Name of the method being benchmarked</param>
    private static void RunBenchmark(Action benchmarkMethod, string methodName)
    {
        long startTime = DateTime.Now.Ticks;
        benchmarkMethod(); // Invoking the provided method.
        long endTime = DateTime.Now.Ticks;
        long elapsedTime = endTime - startTime;
        Console.WriteLine($"{methodName} tid (ticks): {elapsedTime}");
    }
}
