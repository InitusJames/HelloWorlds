using ManyHellos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;


namespace HelloWorlds
{
    internal static class ExecuteMethod
    {
        public static long Execute(HelloWorld executable, int executions)
        {
            Stopwatch stopWatch = new();
            for (int x = 0; x < executions; x++)
            {
                string rtn = "";

                stopWatch.Start();
                rtn = executable.SayHello();
                stopWatch.Stop();

                if(rtn!="Hello World")
                {
                    return -1;
                }    

            }

            return stopWatch.ElapsedMilliseconds;                
        }
    }
}
