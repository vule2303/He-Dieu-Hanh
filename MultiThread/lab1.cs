using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiThread
{

    public class Program
    {

        private int iterations; // số lần lặp
        private string message; // chuỗi xuát ra
        private int delay; // thời gian trễ / chờ
        public int count;

        public Program(int iterations, string message, int delay)
        {
            this.iterations = iterations;
            this.message = message;
            this.delay = delay;
        }


        //
        public void Start()
        {
            //Tạo một thể hiện uỷ nhiện ThreadStart tham chiếu đến DisplayMessage.
            ThreadStart method = new ThreadStart(DisplayMessage);
            // Tạo mội đối tượng thread và truyền thể hiện uỷ nhiệm threaStart cho phương thức tạo
            Thread thread = new Thread(method);
            Console.WriteLine("{0} : Starting new thread", DateTime.Now.ToString("HH:mm:ss.ffff"));
            //khoi chay tiểu trình mới
            thread.Start();
        }
        //DisplayMessage: xuất ra một chuỗi

        private void DisplayMessage()
        {
            //Hien thong bao ra cua so Console voi iteration lan, nghi giua moi thong bao
            //Một khoảng thời gian được chỉ định(delay)
            for (int count = 0; count < iterations; count++)
            {
                Console.WriteLine("{0} : {1}", DateTime.Now.ToString("HH:mm:ss.fff"), message); //lấy ra thời gian của hệ thống
                Thread.Sleep(delay); //lớp tiểu trình có sẵn trong C#, chương trình sẽ tạm nghỉ delay milisecond
            }
        }
    }
}
