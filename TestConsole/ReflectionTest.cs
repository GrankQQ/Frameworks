using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    public class ReflectionTest
    {
        public string name { get; set; }

        private string privateName { get; set; }


        public string GetName()
        {
            return name;
        }


        private string GetPrivateName()
        {
            return privateName;
        }

        public void SetName(string name, string privateName)
        {
            this.name = name;
            this.privateName = privateName;
        }

        private bool setPrivateName(string privateName)
        {
            this.privateName = privateName;
            return true;
        }

        public static int Sum(int x, int y, int z)
        {
            return x + y + z;
        }
    }
}
