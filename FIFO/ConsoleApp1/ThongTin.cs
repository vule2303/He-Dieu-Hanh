using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class ThongTin
    {
        public int TGXuLy { get; set; }
        public int TDVao { get; set; }
        public string TenTT { get; set; }

        public ThongTin()
        {
        }

        public ThongTin(string tenTT, int tGVao, int tGXuLy)
        {
            TenTT = tenTT;
            TDVao = tGVao;
            TGXuLy = tGXuLy;
        }
        public void FIFO(List<ThongTin> TT)
        {
            float tgTGCho = 0;
            double tgTB;
            var temp = 0;
            Console.WriteLine("Thoi Gian Cho Cua Moi Tien Trinh");
            foreach (var T in TT)
            {
                Console.Write("{0} = {1} ",T.TenTT, temp);
                tgTGCho += temp - T.TDVao;

                temp += T.TGXuLy;
            }
            tgTB = tgTGCho / TT.Count;
            Console.WriteLine("\nThoi gian trung binh la: {0}", tgTB);
        }
        






    }
}
