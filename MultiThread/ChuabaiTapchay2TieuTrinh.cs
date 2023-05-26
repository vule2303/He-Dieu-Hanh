using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiThread
{
    internal class ChuabaiTapchay2TieuTrinh
    {

        //Thread thi ko co kieu tra ve
        public static int count = 0; // biến count static là biến toàn cùng dùng cho tất cả cho lớp đó.
        public void Start_TTCong()
        {
            ThreadStart a = new ThreadStart(IncreamentCount);

            Thread i = new Thread(a);

            i.Start();
        }

        public void IncreamentCount()
        {
            for(int i = 0; i < 2500; i++)
            {
                count++;
                Console.WriteLine("Count increase : " + count);
                Thread.Sleep(400);

            }
        }
        public void Start_TTTru()
        {
            
            ThreadStart b = new ThreadStart(decreasementCount);

            Thread e = new Thread(b);

            e.Start();
        }
        public void decreasementCount()
        {
            for (int i = 0; i < 2500; i++)
            {
                count--;
                Console.WriteLine("Count decrease : " + count);
                Thread.Sleep(700);
            }
        }

        /*
         Cach viet so 2 o trong ham main
            Thread t1 = new Thread(IncreasementCount);
            Thread t2 = new Thread(IncreasementCount);
            
            t1.Start();
            t2.Start();
            t1.Join();
            t2.Join();
            
            // 2 dong Join thi phai cho 2 thang no chay xong thi moi chay cau lenh tiep theo
         
         */
    }
}
