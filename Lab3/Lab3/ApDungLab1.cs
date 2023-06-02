using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public class ApDungLab1
    {
        public static object key = new object();
        public int count{get; set;}

        

        public void TTCong()
        {
            try
            {
                Monitor.Enter(key);
                    for (int i = 0; i < 20; i++)
                    {
                        count++;
                        Console.WriteLine("Increament: " + count);
                    // Ngừng tiến trình giảm để tiến trình tăng có thể thực hiện
                        Monitor.Pulse(key);

                    //Chờ tiến trình giảm hoàn thành khi tiếp tục tăng
                        Monitor.Wait(key);
                    }
                
                
            }finally { Monitor.Exit(key); }
           
        }
        public void TTTru ()
        {

            try 
            {
                Monitor.Enter(key);
                for(int i = 0; i<20; i++)
                {
                    count--;
                    Console.WriteLine("Decreament: "+count);

                    //Ngừng TT Tăng
                    Monitor.Pulse(key);

                    //chờ TTtawng
                    Monitor.Wait(key);
                }
            }
            finally { Monitor.Exit(key); }
        }
                
            
     }
        



 }
    

