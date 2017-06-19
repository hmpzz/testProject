using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
   public  class Class1
    {

        public void Boil()
        {
            int WD;
            WD = 0;

            for (int i = 1; i <= 100; i++)
            {
                WD = WD + 1;
                if (WD>=90)
                {
                    jiao(WD);
                    xianshi(WD);
                }
            }
        }

        private void jiao(int wd)
        {
            Console.WriteLine("已经{0}度了！",wd);
        }

        private void xianshi(int wd)
        {
            Console.WriteLine("显示仪表{0}度了！",wd);
        }
    }
}
