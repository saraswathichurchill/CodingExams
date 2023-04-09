using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPTest
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = 6;
            int i = 0;
            //  int[] arr = new int[] { 1, 5, 7, -1, 5 };
            int[] arr = new int[] { 1, 5, 7, 5, -1 ,4,2,3,4,3,8,-2};
            var tupleList = SumPairs(arr, sum);
            string s = "a-b-c-d-e";
            var singleRes = singleHops(s);
            var doubleRes = doubleHops(s);
            foreach(var item in singleRes)
            {
                Console.WriteLine(item);
            }
            foreach (var item in doubleRes)
            {
                Console.WriteLine(item);
            }
            foreach (var item in tupleList)
            {
                i++;
                Console.WriteLine("Sum Pairs" + i +" : "+item.Item1 +", "+item.Item2);
            }
            //Console.WriteLine("Output: "+count);
            Console.ReadKey();
        }

        public static List<string> singleHops(string s)
        {
            List<string> result = new List<string>();
            string[] splitArr = s.Split('-');
            for (int i = 0; i < splitArr.Length; i++)
            {
                for (int j = i + 1; j < splitArr.Length; j++)
                {
                    result.Add(splitArr[i] + "-" + splitArr[j]);
                }
            }

            return result;
        }
        public static List<string> doubleHops(string s)
        {
            List<string> result = new List<string>();
            string[] splitArr = s.Split('-');
            for (int i = 0; i < splitArr.Length; i++)
            {
                for (int j = i + 1; j < splitArr.Length; j++)
                {
                    for (int k = j + 1; k < splitArr.Length; k++)
                    {
                        result.Add(splitArr[i] + "-" + splitArr[j]+"-"+splitArr[k]);
                    }
                }
            }

            return result;
        }
        public static List<Tuple<int,int>> SumPairs(int[] arr, int sum)
        {
            int count = 0;
            
            var tupleList = new List<Tuple<int, int>>();
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i+1; j < arr.Length; j++)
                {
                        if (arr[i] + arr[j] == sum)
                            tupleList.Add(new Tuple<int, int>(arr[i], arr[j]));
                        count++;
                    
                }

            }
            return tupleList;
        }
    }
}
