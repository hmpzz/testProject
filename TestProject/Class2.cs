using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    public delegate void jx(int wd);


    public class Class2
    {

        public event jx jx1;
        public void shaoshui()
        {


            int wd;
            wd = 0;

            for (int i = 1; i <= 100; i++)
            {
                wd = wd + 1;

                if (wd>=90)
                {
                    if (jx1 !=null)
                    {
                        jx1(wd);
                    }
                }
            }
        }
    }
}
