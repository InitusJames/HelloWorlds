using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;

namespace ManyHellos
{
    public class ByHardString : ManyHellos.HelloWorld
    {
        public override string SayHello()
        {
            return "Hello World";
        }
    }

    public class ByHardStrings : HelloWorld
    {
        public override string SayHello()
        {
            return "H" + "e" + "l" + "l" + "o" + " " + "W" + "o" + "r" + "l" + "d";
        }
    }

    public class ByCharacters : HelloWorld
    {

        public override string SayHello()
        {
            string rtn = "";

            foreach (var character in "Hello World")
            {
                rtn += (character);
            }

            return rtn;
        }
    }

    public class ByPrimeKey : HelloWorld
    {
        public override string SayHello()
        {
            char[] rtn = new char[11];

            long primekey = 2 * 13 * 199 * 5448049l;

            for (int i = 0; i < primekey.ToString().Length; i++)
            {
                rtn[i] = ("deHlorW "[(i + int.Parse(primekey.ToString()[i].ToString())) % 8]);
            }

            return new string(rtn);
        }
    }
    public class ByReverseOrder : HelloWorld
    {
        public override string SayHello()
        {
            char[] charArray = ("dlroW olleH").ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }

    public class ByDeBruijn : HelloWorld
    {
        public override string SayHello()
        {
            char[] rtn = new char[11];

            string hex_index = "729A5610";

            string octal_index = Convert.ToString(Convert.ToInt32("65B82DEB", 16), 8);

            var compressed_indexes = new long[4] { 2126, 8622, 101677, 68889532 };
            var index_length = new int[4] { 4, 4, 5, 7 };

            var cIndex = new int[hex_index.Length];

            for (int i = 0; i < hex_index.Length; i++)
            {
                string key = string.Concat(Enumerable.Repeat(Convert.ToString(compressed_indexes[0], 2), 2));
                int idx = Convert.ToInt32(hex_index[i].ToString(), 16);
                string bits = key.Substring(idx, index_length[0]);
                cIndex[i] = Convert.ToInt32(bits, 2);
            }

            for (int x = 1; x < hex_index.Length / 2; x++)
            {
                string key = string.Concat(Enumerable.Repeat(Convert.ToString(compressed_indexes[x], 2), 2));

                for (int i = 0; i < cIndex.Length; i++)
                {
                    string bits = key.Substring(cIndex[i], index_length[x]);
                    cIndex[i] = Convert.ToInt32(bits, 2);
                }
            }

            for (int i = 0; i < octal_index.Length; i++)
            {
                rtn[i] = (char)cIndex[int.Parse(octal_index[i].ToString())];
            }

            return new string(rtn);

        }
    }

    public class ByReflection : HelloWorld
    {
        public override string SayHello()
        {
            return GetType().BaseType.Name.Insert(5," ");
        }
    }





}
        