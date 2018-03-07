using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoBid.Update
{
    class Program
    {
        static void Main(string[] args)
        {
            UpdateService update = new UpdateService { };
            var result = update.Update();
            if (result)
            {
                Console.WriteLine("更新成功,按任意键立即启动");
                Console.ReadLine();
                Process.Start("AutoBid.exe");
            }
            else
            {
                Console.WriteLine("更新失败,按任意键退出");
                Console.ReadLine();
            }
        }
    }
}
