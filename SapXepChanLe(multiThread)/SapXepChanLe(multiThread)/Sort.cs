using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SapXepChanLe_multiThread_
{
    public class Sort
    {
        public int[] number;
        public int[] oddArray;
        public int[] evenArray;
        public int[] combineArray;

        public void AddArray(int n)
        {

            number = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write("Nhap phan tu thu {0}: ", i + 1);
                number[i] = int.Parse(Console.ReadLine());
            }
        }


        public void ODDArray()
        {
            oddArray = number.Where(n => n % 2 == 0).OrderBy(n => n).ToArray();
            Console.WriteLine("\nODD Array is: ");
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

        public void COMBINEArray()
        {
            int pos = 0;
            combineArray = new int[oddArray.Length + evenArray.Length];
            foreach (int values in oddArray)
            {
                combineArray[pos] = values;
                pos++;
            }

            foreach (int values in evenArray)
            {
                combineArray[pos] = values;
                pos++;
            }

            //in ra 

            Console.WriteLine("\nCOMBINE Array is: ");
            for (int i = 0; i < combineArray.Length; i++)
            {
                Console.Write(combineArray[i] + " ");
            }
        }
    }
}
