using System;
using System.Threading;
// Tạo lập một tiểu trình từ một tiến trình


//main
namespace MultiThread
{
    public class MainProgram
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Nhap so luong phan tu cua mang: ");
            int n = int.Parse(Console.ReadLine());
            SapXepChanLe a = new SapXepChanLe();

            a.AddArray(n);
            a.ODDArray();
            //a.SapXepTang();
            //a.separeArray();
        }
    }
}

