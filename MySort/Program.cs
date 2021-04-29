using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySort
{
    class MySort
    {
        // 델리게이트 CompareDelegate 선언
        public delegate int CompareDelegate(int i1, int i2);

        public static void Sort(int[] arr, CompareDelegate comp)
        {
            if (arr.Length < 2) return;
            Console.WriteLine("함수 Prototype: " + comp.Method);

            int ret;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = i+1; j < arr.Length; j++)
                {
                    ret = comp(arr[i], arr[j]);
                    if (ret == -1)
                    {
                        // 교환
                        int tmp = arr[j];
                        arr[j] = arr[i];
                        arr[i] = tmp;
                    }
                }
            }
            Display(arr);
        }
        static void Display(int[] arr)
        {
            foreach (var i in arr)
                Console.Write(i + " ");
            Console.WriteLine();
        }
    }
    class Program
    {
        /// <summary>
        /// Delegate를 사용하면 매개변수 타입이 같은 메서드로 활용이 가능하다
        /// 이것을 보면서 코드가 동일한데 특정부분만 변경되는 코드를 작성할때
        /// 편리할것 같다. 아직 이해가 부족해서 더 많은 곳에 활용할수 있는 이 기능을 
        /// 코드 중복을 해결하는 쪽에서만 이용할려는 생각밖에 안든다...
        /// 더 많은 공부와 응용이 필요 할 것 같다.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            (new Program()).Run();
        }

        void Run()
        {
            int[] a = { 5, 53, 3, 7, 1 };

            // 오름차순으로 sort
            MySort.CompareDelegate compDelegate = AscendingCompare;
            MySort.Sort(a, compDelegate);

            // 내림차순으로 sort
            compDelegate = DescendingCompare;
            MySort.Sort(a, compDelegate);
        }

        // CompareDelegate 델리게이트와 동일한 Prototype
        int AscendingCompare(int i1, int i2)
        {
            if (i1 == i2) 
                return 0;
            return (i2 - i1) > 0 ? 1 : -1;
        }

        // CompareDelegate 델리게이트와 동일한 Prototype
        int DescendingCompare(int i1, int i2)
        {
            if (i1 == i2) 
                return 0;
            return (i1 - i2) > 0 ? 1 : -1;
        }
    }
}
