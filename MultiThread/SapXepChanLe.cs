using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiThread
{
    internal class SapXepChanLe
    {
        public static int[] number;
        public static int[] oddArray;
        public  static int[] evenArray;
        public static int[] combineArray;

        public void AddArray(int n)
        {
            
            number = new int[n];
            for(int i = 0; i < n; i++)
            {
                Console.Write("Nhap phan tu thu {0}: ", i+1);
                number[i] = int.Parse(Console.ReadLine());
            }
        }

        
        public void ODDArray()
        {
            oddArray = number.Where(n => n %2 == 0).OrderBy(n => n).ToArray();
            Console.WriteLine("ODD Array is: ");
            for (int i = 0; i < oddArray.Length; i++)
            {
                Console.Write(oddArray[i] + " ");
            }
        }

        public void EVENArray()
        {
            evenArray = number.Where(n => n % 2 != 0).OrderBy(n => n).ToArray();
            Console.WriteLine("\nEVEN Array is: ");
            for (int i = 0; i < evenArray.Length; i++)
            {
                Console.Write(evenArray[i] + " ");
            }
        }

        public static int []COMBINEArray(int[] a, int[] b)
        {
            combineArray = new int[oddArray.Length + evenArray.Length];
            Array.Copy(oddArray, 0,combineArray,0, oddArray.Length);
            Array.Copy(evenArray, 0,combineArray, oddArray.Length, evenArray.Length);
            return combineArray;
        }
    }
}
