using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorldMaker
{
    internal class Threader
    {
        List<string> _bins = new List<string>();
        public Threader(List<string> bins)
        {
            _bins = bins;
        }

        public void Do(long start, long length)
        {
            for (long x = start; x < start+length; x++)
            {
                string newKey = Convert.ToString(x, 2);//.PadLeft(, '0');

                bool found = true;
                foreach (var bin in _bins)
                {
                    if (!(newKey + newKey).Contains(bin))
                    {
                        found = false;
                        break;
                    }
                }

                if (found)                    
                    Console.WriteLine($"{x} : {newKey}");
            }

        }

        public IEnumerable<long> NextNumber()
        {
            for (long x = 0; x < long.MaxValue; x+=100000)
                yield return x;
        }
    }
}








