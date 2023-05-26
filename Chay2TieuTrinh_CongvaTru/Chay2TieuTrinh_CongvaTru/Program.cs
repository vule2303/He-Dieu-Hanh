using System;

namespace Chay2TieuTrinh_CongvaTru
{
    class program
    {
        static void Main(string[] args)
        {
            MultiThread ex = new MultiThread();

            Thread t1 = new Thread(ex.TienTrinhCong);
            Thread t2 = new Thread(ex.TienTrinhTru);

            t1.Start();
            t2.Start();
        }
    }
}