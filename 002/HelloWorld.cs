using Hello;

namespace _002
{
    public class ByCharacters : HelloWorld
    {
        
        public override string SayHello()
        {
            string rtn = "";
            
            foreach(var character in "Hello World")
            {
                rtn+=(character);
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
                rtn[i]=("deHlorW "[(i + int.Parse(primekey.ToString()[i].ToString())) % 8]);
            }

            return new string(rtn);
        }
    }


}