using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    public class IntAlgorithm
    {
        public List<int> Split(int result, int splitEvery)
        {
            List<int> splitList = new List<int>();
            for(int i = 0; i < splitEvery; i++)
            {
                if (result % splitEvery == 0)
                {
                    splitList.Add(result / splitEvery);
                }
                else
                {
                    if (i < splitEvery - 1)
                        splitList.Add(result / splitEvery + 1);
                    else
                        splitList.Add(result - (result / splitEvery) * splitEvery);
                }
            }
            

            return splitList;
        }
    }
}
