using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestProject
{
    public partial class Form1 : Form
    {
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
    }
}
