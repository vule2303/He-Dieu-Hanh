using System;

namespace SapXepChanLe_multiThread_
{
    class program
    {
        static void Main(string[] args)
        {
            Sort ex = new Sort();
            Console.WriteLine("Nhap so luong phan tu cua mang: ");
            int n = Int32.Parse(Console.ReadLine());
            ex.AddArray(n);
            
            Thread t1 = new Thread(ex.ODDArray);
            Thread t2 = new Thread(ex.EVENArray);
            t1.Start();
            t2.Start();
            t1.Join();
            t2.Join();


            ex.COMBINEArray();
            



        }
    }
}
