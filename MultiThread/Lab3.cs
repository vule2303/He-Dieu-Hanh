using MultiThread;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiThread
{
    internal class Lab3
    {
        public static void DisplayMessage1()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("{0} : Second thread runnung. Enter" + "(S)uspend, (R)esume,(I)nterupt, or (E)xit", DateTime.Now.ToString("HH:mm:ss.ffff"));
                    Thread.Sleep(2000);
                }
                catch ( ThreadInterruptedException)
                {
                    //Tiến trình đã bị gián đoạn. Việc bắt ngoại lệ ThreadInterruptedException cho phép ví dụ này thực hiện hành động phù hợp và tiếp tục thực thi
                    Console.WriteLine("{0} : Second thread interrupted",
                        DateTime.Now.ToString("HH:mm:ss:ffff")
                        );
                    
                }
                catch(ThreadAbortException abortEx)
                {
                    //Đối tượng trong thuộc tính ThreadAbortExceptionState được cung cấp
                    //bởi tiến trình đã gọi Thread.Abort
                    //Trong trường hợp này, nó chứa một chuỗi mô tả lý do của việc huỷ bỏ
                    Console.WriteLine("{0} : Second thread aborted ({1})", DateTime.Now.ToString("HH:mm:ss.ffff"));
                }
            }
        } 

        // run
        public void runLab3()
        {
            //Tạo mới đối tượng Thread và truyền cho nó một thẻ hiện uỷ quyền ThreadStart tham chiến đế DisplayMessage1
            Thread thread = new Thread(new ThreadStart(DisplayMessage1));
            Console.WriteLine("{0} : Starting second thread", DateTime.Now.ToString("HH:mm:ss.ffff"));
            //khởi chạy tiểu trình 2
            thread.Start();

            //Lặp và sử lý lệnh do người dùng nhập
            char? command = null;
            do
            {
                string input = Console.ReadLine();
                if (input.Length > 0)
                    command = input.ToUpper()[0];
                else
                    command = null;
                switch (command)
                {
                    case 'S': // Toạn hoãn tiến trình 2
                        Console.WriteLine("{0} : Suspending second thread",
                        DateTime.Now.ToString("HH:mm:ss.ffff"));
                        thread.Suspend();
                        break;
                    case 'R':
                        try
                        {
                            Console.WriteLine("{0} : Resuming second thread", DateTime.Now.ToString("HH:mm:ss.ffff"));
                            thread.Resume();
                        }
                        catch (ThreadStartException)
                        {
                            Console.WriteLine("{0} : Thread wasn't suspended", DateTime.Now.ToString("HH:mm:ss.ffff"));
                        }
                        break;
                    case 'E':
                        //huỷ bỏ tiểu trình thứ 2 và truyền một đối tượng trạng thái cho tiểu trình đang bị huỷ.
                        // trong trường hợp này là một thông báo
                        Console.WriteLine("{0} : aborting second thread", DateTime.Now.ToString("HH:mm:ss.ffff"));
                        thread.Join();
                        break;
                }
            } while (command != 'E');
                Console.WriteLine("Main method complete. Press Enter");
            Console.ReadLine();
        }
    }
}


//Tao mot doi tuong ThreadExample
//lab2 example = new lab2();
//khoi chay doi tuong
//example.Start(); // gọi hàm start


//for (int count = 0; count < 2500; count++)
//{
//    Console.WriteLine("{0} : Continue processing...", DateTime.Now.ToString("HH:mm:ss.fff"));
//    Thread.Sleep(200);
//}

//Enter to exit
//Console.WriteLine("Main method complete. Press Enter");
//Console.ReadLine();