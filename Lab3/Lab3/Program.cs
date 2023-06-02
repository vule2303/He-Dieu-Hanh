using System;

namespace Lab3
{
    class program
    {
        static void Main(string[] args)
        {
            ApDungLab1 a = new ApDungLab1();
            Thread thread1 = new Thread(a.TTCong);
            Thread thread2 = new Thread(a.TTTru);

            
            thread1.Start();
            thread2.Start();

            thread1.Join();
            thread2.Join();

            Console.WriteLine("Final count : " + a.count);

        } 
    }
    class ThreadSyncExample
    {
        private static object DoiTuongDungChung = new object();
        private static void DisplayMessage()
        {
            Console.WriteLine("{0} : Tieu Trinh da bat dau, Dang danh Khoa (lock)... ",
                DateTime.Now.ToString("HH:mm:ss.ffff"));

            try
            {
                //Bắt đầu đạt quyền truy cập
                Monitor.Enter(DoiTuongDungChung);
                Console.WriteLine("{0} : {1}", DateTime.Now.ToString("HH:mm:ss.fffff"),
                    "Da danh duoc khoa tren DoiTuongDungChung, Dang Doi....");
                //Đợi cho đến khi Pulse được gọi trên đối tượng consoleGate.
                Monitor.Wait(DoiTuongDungChung);
                //khi một tiểu trình gọi Wait thì tự động sleep (lock)
                Console.WriteLine("{0} : Tieu trinh tiep tuc chay, dang ket thuc.", DateTime.Now.ToString("HH:mm:ss.ffff"));
                //lúc tiểu trình bị sleep thì câu lệnh trên k chạy
            }
            finally
            {
                Monitor.Exit(DoiTuongDungChung);
            }


        }
        public void ThreadSync()
        {
            //Thu lấy khoá trên đối tượng DoiTuongdngchung
            lock (DoiTuongDungChung)
            {
                for(int count = 0; count < 3; count++)
                {
                    (new Thread(new ThreadStart(DisplayMessage))).Start();
                }
                //đặt 3 tiểu trình sử dụng một cái khoá, đều chạy Display Message
                //3 tiểu trình đều gọi disspalyMesssage 
            }
            Thread.Sleep(1000);
            //Danh thuc mot tieu trinh dang cho
            Console.WriteLine("{0} : {1}", DateTime.Now.ToString("HH:mm:ss.ffff"),
                "Nhan Enter de lay mot tieu trinh dang cho");
            Console.ReadLine();

            //Thu lay khoa tren doi tuong DoiTuongDungChung
            lock (DoiTuongDungChung)
            {
                Monitor.Pulse(DoiTuongDungChung);
            }
            Console.WriteLine("{0} : {1}",DateTime.Now.ToString("HH:mm:ss.ffff"),
                "Nhan Enter de lay tat ca tieu trinh dang cho");
            Console.ReadLine();

            //Thu lay chot tren doi tuong ConsoleGate

            lock (DoiTuongDungChung)
            {
                //Pulse tat ca tieu trinh dang cho
                Monitor.PulseAll(DoiTuongDungChung);
            }
            //an Enter de ket thuc
            Console.WriteLine("Ham Main da hoan thanh. Nhan Enter");
            Console.ReadLine();
        }
    }
    
}
