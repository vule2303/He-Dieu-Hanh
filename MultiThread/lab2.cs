using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiThread
{
    internal class lab2
    {
        
        static int count = 0;

       


        //
        public void Start()
        {
            //Tạo một thể hiện uỷ nhiện ThreadStart tham chiếu đến DisplayMessage.
            ThreadStart method = new ThreadStart(TienTrinhCong);
            // Tạo mội đối tượng thread và truyền thể hiện uỷ nhiệm threaStart cho phương thức tạo
            Thread thread = new Thread(method);
            //khoi chay tiểu trình mới
            thread.Start();
            ThreadStart method2 = new ThreadStart(TienTrinhTru);
            Thread thread2 = new Thread(method2);
            thread2.Start();



        }
        
        //DisplayMessage: xuất ra một chuỗi

        private void TienTrinhCong()
        {
            //Hien thong bao ra cua so Console voi iteration lan, nghi giua moi thong bao
            //Một khoảng thời gian được chỉ định(delay)
            for (int i = 0; i < 2500; i++)
            {
                count++;
                Console.WriteLine("{0} Count++ : {1}", DateTime.Now.ToString("HH:mm:ss.fff"), count); //lấy ra thời gian của hệ thống
                Thread.Sleep(500); //lớp tiểu trình có sẵn trong C#, chương trình sẽ tạm nghỉ delay milisecond
            }
        }

        private void TienTrinhTru()
        {
            for(int i = 2500; i > 0; i--)
            {
                count--;
                Console.WriteLine("{0} Count-- : {1}", DateTime.Now.ToString("HH:mm:ss.fff"), count); //lấy ra thời gian của hệ thống
                Thread.Sleep(1000); //lớp tiểu trình có sẵn trong C#, chương trình sẽ tạm nghỉ delay milisecond
               
            }
            
        }

    }
}
