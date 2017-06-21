using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestProject
{
    public partial class Form1 : Form
    {


        [DllImport("user32", CharSet = CharSet.Auto)]
        public static extern int EnableWindow(IntPtr hwnd, bool bEnable);
        //锁定：EnableWindow(this.Handle,false);
        //解锁：EnableWindow(this.Handle,true);



        /// <summary>
        /// 定义一个委托，返回值是VOID,参数是string
        /// </summary>
        /// <param name="name"></param>
        public delegate void GreetingDelegate(string name);



        public Form1()
        {
            InitializeComponent();
        }

      
        private void EnglishGreeting(string name)
        {
            Console.WriteLine("Hello {0}", name);
        }

        private void ChineseGreeting(string name)
        {
            Console.WriteLine("你好 {0}", name);
        }


        private static void GreetPeople(string name, GreetingDelegate MakeGreeting)
        {
            MakeGreeting(name);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //最开始是将委托的方法传进来
            GreetPeople("Tom", EnglishGreeting);
            GreetPeople("张子阳", ChineseGreeting);

            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            GreetingDelegate delegate1,delegate2;

            delegate1 = EnglishGreeting;
            delegate2 = ChineseGreeting;

            GreetPeople("Tom", delegate1);
            GreetPeople("张子阳", delegate2);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            GreetingDelegate delegate1;

            delegate1 = EnglishGreeting;
            delegate1 += ChineseGreeting;

            GreetPeople("Tom", delegate1);
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DelegateClass a = new DelegateClass();
            a.MakeGreeting += ChineseGreeting;
            a.GreetPeople("张子阳");



        }

        private void button5_Click(object sender, EventArgs e)
        {
            Class1 a = new Class1();
            a.Boil();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Class2 cl2 = new Class2();

            xianshi xs = new xianshi();


            cl2.jx1 += xs.xs;
            cl2.jx1 += jiao.j;

            cl2.shaoshui();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Heater heater = new Heater();
            Alarm alarm = new Alarm();

            heater.Boiled += alarm.MakeAlert;   //注册方法
            //heater.Boiled += (new Alarm()).MakeAlert;      //给匿名对象注册方法
            //heater.Boiled += new Heater.BoiledEventHandler(alarm.MakeAlert);    //也可以这么注册
            heater.Boiled += Display.ShowMsg;       //注册静态方法

            heater.BoilWater();   //烧水，会自动调用注册过对象的方法
        }




        private void button8_Click(object sender, EventArgs e)
        {
            //this.Enabled = false;
            WaitWin.Show("等待中",this);

            string s = "";
            

            for (int i = 1; i <= 5; i++)
            {
                //WaitWin.Show("等待中，第 " + i + " 秒"); 

                WaitWin.setlabel("等待中，第 " + i + " 秒");

                Thread.Sleep(1000);
            }
            WaitWin.Close();
            //this.Enabled = true;
        }


        public delegate void DeleSetLabel(string Text);
        public delegate void DeleShow(IWin32Window owner);


        public static class WaitWin
        {
            static waitform form = null;
            static Form OwnerForm = null;
            public static void Show(string waitMsg,IWin32Window owner)
            {

                OwnerForm = (Form)owner;
                OwnerForm.Enabled = false;
                



                if (form == null)
                {
                    
                    form = new waitform();
                    


                    ThreadPool.QueueUserWorkItem(state =>
                    {
                        form.ShowDialog();
                    });

                    

                    //DeleShow DS = form.Show;
                    //form.Enabled = false;
                    
                    //IAsyncResult result = DS.BeginInvoke(null, GetResultCallBack, owner);
                }
                form.Msg = waitMsg;
            }

            static void GetResultCallBack(IAsyncResult asyncResult)
            {
                //获取原始的委托对象
                AsyncResult result = (AsyncResult)asyncResult;
                DeleShow salDel = (DeleShow)result.AsyncDelegate;

                //上面begininvoke里的最后一个参数，可以传递到这里来
                Console.WriteLine(asyncResult.AsyncState);
                //调用EndInvoke获取返回值
               salDel.EndInvoke(asyncResult);
                //[Note1:],他的作用就是来 "传递额外的参数",因为他本身是Object对象,我们可以传递任何对象
                //int para = (int)asyncResult.AsyncState;
                //Console.WriteLine(para); //输出:2000

                ((waitform)asyncResult.AsyncState).Enabled = true;
            }




            public static void setlabel(string Text)
            {
                

                if (form != null)
                {
                    if (form.label1.InvokeRequired)
                    {
                        form.label1.Invoke(new DeleSetLabel(setlabel), Text);
                    }
                    else
                    {
                        form.label1.Text = Text;
                    }
                }
                    
            }
          
            public static void Close()
            {
                if (form != null)
                {

                    Application.DoEvents();
                    OwnerForm.Enabled = true;


                    form.Close();
                }
                  
                form = null;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            MessageBox.Show("aa");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            //锁定：
            //EnableWindow(this.Handle,false);
            
            this.button9.Enabled = false;
            for (int i = 0; i < 3000; i++)
            {
                Console.WriteLine(i);
                Application.DoEvents();
            }
            this.button9.Enabled = true;
            //解锁：
            //EnableWindow(this.Handle,true);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            
        }
    }
}
