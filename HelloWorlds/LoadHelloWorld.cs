using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ManyHellos;

namespace HelloWorlds
{
    public static class LoadHelloWorld
    {
        public static IEnumerable<HelloWorld> Load(byte[] bytes)
        {
            Assembly helloLib = Assembly.Load(bytes);
           
            Type[] types = helloLib.GetTypes();

            if (types.Length > 0)
            {
                Console.WriteLine(types.Length);
                foreach (Type type in types)
                {
                    if(type.BaseType.Name == typeof(HelloWorld).Name)
                    {
                        HelloWorld hw = (HelloWorld)helloLib.CreateInstance(type.FullName);
                        hw.FullName = type.FullName;
                        yield return hw;
                    }
                }
            }
            else
                yield return null;

        }

      
    }
}
