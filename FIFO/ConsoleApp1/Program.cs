using ConsoleApp1;
using System;



public class Program {
    static void Main(string[] args)
    {
        ThongTin a = new ThongTin();

        var ListTT = new List<ThongTin>();

        Console.Write("Nhap So Tien Trinh Muon Tao: ");
        int n = Convert.ToInt32(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            Console.Write("Ten TT {0}: ", i + 1);
            string name = Console.ReadLine();
            Console.Write("TG vao : ");
            int tgVao = Int32.Parse(Console.ReadLine());
            Console.Write("TG XL : ");
            int tgXL = Int32.Parse(Console.ReadLine());

            ThongTin TT = new ThongTin(name, tgVao, tgXL);

            ListTT.Add(TT);

        }
        Console.WriteLine("==============CAC TIEN TRINH VUA NHAP ==============");
        foreach (var TT in ListTT)
        {
            Console.WriteLine("{0} {1} {2}", TT.TenTT, TT.TDVao, TT.TGXuLy);
        }
        a.FIFO(ListTT);

        
        Console.ReadLine();


    }

   
}