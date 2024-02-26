using System.Runtime.CompilerServices;
using System.Security.Cryptography;
namespace RandomRNG;


class RandomTest() {

    internal static List<int> TestRandomnessWithRNGCryptoServiceProvider(int numberOfTests, int minNum, int maxNum)
    {
        List<int> RNGresult = new List<int>();

        for (int i = 0; i < numberOfTests; i++)
        {
            RNGresult.Add(RandomNumberGenerator.GetInt32(minNum, maxNum));
        }
        return RNGresult;
    }

    internal static List<int> TestRandomnessWithRandom(int numberOfTests, int minNum, int maxNum)
    {
        List<int> RandomResult = new List<int>();

        Random random = new Random();
        for (int i = 0; i < numberOfTests; i++)
        {
            RandomResult.Add(random.Next(minNum, maxNum));
        }
        return RandomResult;
    }
}