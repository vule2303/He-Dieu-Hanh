//// See https://aka.ms/new-console-template for more informationu
//using System;
//using System.Diagnostics;
//using System.Security.Cryptography.X509Certificates;

//namespace ConsoleApp1
//{
//    public class program
//    {
//        static void Main(string[] args)
//        {
//            Console.WriteLine("Nhap so process: ");
//            var process = int.Parse(Console.ReadLine());
//            Console.WriteLine("Nhap so instance: ");
//            var instance = int.Parse(Console.ReadLine());
//            Console.WriteLine("Nhap tai nguyen co san: ");
//            var quatityAvailabe = int.Parse(Console.ReadLine());

//            int[,] Need = new int[process,instance];


//            int[] Available = new int[quatityAvailabe];

//            Banker a = new Banker();
//            a.nhapMT(process, instance, Need);
//            a.nhapAvailable(quatityAvailabe, Available);
//            Console.WriteLine(a.checkSafe(Available, Need, process, instance));



//        }

//        static int nhapMT(int n, int m)
//        {
//            int[,] a = new int[n,m];
//            Console.WriteLine("Allocation");
//            for (int i = 0; i < n; i++)
//            {
//                Console.WriteLine("P{0}", i); ;
//                for(int  j = 0; j < m; j++)
//                {                   
//                    a[i,j] = int.Parse(Console.ReadLine()); 
//                }
//            }

//            return a[n,m];
//        }
//    }
//}

using ConsoleApp1;
using System;

class Program
{
    // Kiểm tra trạng thái an toàn
    static bool KiemTra(int[,] max, int[,] allocation, int[] available, int process, int instance)
    {
        // Khởi tạo mảng need và finish
        int[,] need = new int[process, instance];
        bool[] finish = new bool[process];

        // Tính toán mảng need
        for (int i = 0; i < process; i++)
        {
            for (int j = 0; j < instance; j++)
            {
                need[i, j] = max[i, j] - allocation[i, j];
            }
        }

        // Khởi tạo mảng work và safeSequence
        int[] work = new int[instance];
        int[] safeSequence = new int[process];
        Array.Copy(available, work, instance);

        int count = 0;
        while (count < process)
        {
            bool found = false;

            for (int i = 0; i < process; i++)
            {
                if (!finish[i])
                {
                    bool canExecute = true;

                    for (int j = 0; j < instance; j++)
                    {
                        if (need[i, j] > work[j])
                        {
                            canExecute = false;
                            break;
                        }
                    }

                    if (canExecute)
                    {
                        for (int j = 0; j < instance; j++)
                        {
                            work[j] += allocation[i, j];
                        }

                        safeSequence[count] = i;
                        finish[i] = true;
                        count++;
                        found = true;
                    }
                }
            }

            if (!found)
            {
                break;
            }
        }

        // Kiểm tra trạng thái an toàn
        if (count == process)
        {
            Console.WriteLine("An toan");
            Console.WriteLine("Thu tu cac tien trinh: ");

            for (int i = 0; i < process; i++)
            {
                Console.Write(safeSequence[i] + " ");
            }

            Console.WriteLine();

            return true;
        }
        else
        {
            Console.WriteLine("Khong an toan");
            return false;
        }
    }

    static void Main()
    {
        // Khởi tạo ma trận max
        int[,] max = new int[,]
        {
            {7, 5, 3},
            {3, 2, 2},
            {9, 0, 2},
            {2, 2, 2},
            {4, 3, 3}
        };

        // Khởi tạo ma trận allocation
        int[,] allocation = new int[,]
        {
            {0, 1, 0},
            {2, 0, 0},
            {3, 0, 2},
            {2, 1, 1},
            {0, 0, 2}
        };

        // Khởi tạo mảng available
        int[] available = new int[] { 3, 3, 2 };

        int process = max.GetLength(0);
        int instance = max.GetLength(1);
        Banker a = new Banker();
        // Kiểm tra trạng thái an toàn
        bool isSafe = a.checkSafe(available, max, allocation, process, instance);

        Console.WriteLine();
        Console.WriteLine("Kiem tra ket qua: " + isSafe);
    }
}

