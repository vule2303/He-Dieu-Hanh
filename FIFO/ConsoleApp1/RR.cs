using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class RR
    {
        private List<ThongTin> thongTinList;
        private int quantum;
        private List<String> ListRR;

        public RR(List<ThongTin> thongTinList, int quantum)
        {
            this.thongTinList = thongTinList;
            this.quantum = quantum;
        }

        public void ChayThuatToan()
        {
            Queue<ThongTin> CacTienTrinh = new Queue<ThongTin>(thongTinList);

            while(CacTienTrinh.Count > 0)
            {
                
                ThongTin TTHienTai = CacTienTrinh.Dequeue();
                
                int TGThucHien = Math.Min(quantum, TTHienTai.TGXuLy);

                Console.WriteLine($"Dang thuc thi tien trinh {TTHienTai.TenTT} trong {TGThucHien} giay");

                TTHienTai.TGXuLy -= TGThucHien;

                if(TTHienTai.TGXuLy > 0)
                {
                    CacTienTrinh.Enqueue(TTHienTai);
                    ListRR.Add(TTHienTai.TenTT);
                }
                else
                {
                    Console.WriteLine($"Tien trinh {TTHienTai.TenTT} da xong");
                }
                
            }
            
        }
            //xuat ra qua trinh
            
        }
    }

