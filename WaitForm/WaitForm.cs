using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace WaitForm
{

 
    internal partial class WaitForm : Form
    {

        private DateTime Begin_time;

        
        private delegate void SetTimeTextHandler(string text);
        private delegate void SetMissionNameTextHandler(string text);
        private delegate void SetPercentTextHandler(string text);
        private delegate void SetProgressBarMaxHandler(int ProgressBarMax);
        private delegate void ProgressBarGrowHandler();


        //public WaitForm(Form Owner)
        //{
        //    InitializeComponent();
          
        //    this.Owner = Owner;

        //    CheckForIllegalCrossThreadCalls = false;

        //    this.timer1.Enabled = true;
        //    this.timer1.Interval = 1000;

        //    this.progressBar1.Value = 0;
        //    this.progressBar1.Step = 1;
        //    Begin_time = DateTime.Now;


        //}


        public WaitForm()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;

            this.progressBar1.Value = 0;
            this.progressBar1.Step = 1;
            Begin_time = DateTime.Now;

        }



        /// <summary>
        /// 设置已经进行的时间
        /// </summary>
        /// <param name="text">想要填入的文字</param>
        public void SetTimeText(string text)
        {
            if (this.label1.InvokeRequired)
            {
                this.Invoke(new SetTimeTextHandler(SetTimeText), text);
            }
            else
            {
                this.label1.Text = text;
            }
        }



        /// <summary>
        /// 设置任务名称
        /// </summary>
        /// <param name="text"></param>
        public void SetMissionNameText(string text)
        {
            if (this.label2.InvokeRequired)
            {
                this.Invoke(new SetMissionNameTextHandler(SetMissionNameText), text);
            }
            else
            {
                this.label2.Text = text;
            }
        }


        /// <summary>
        /// 设置百分比进度
        /// </summary>
        /// <param name="text"></param>
        public void SetPercentText(string text)
        {
            if (this.label3.InvokeRequired)
            {
                this.Invoke(new SetPercentTextHandler(SetPercentText), text);
            }
            else
            {
                this.label3.Text = text;
            }
        }


        /// <summary>
        /// 设置ProgressBar的最大数值与步进值
        /// </summary>
        /// <param name="ProgressBarMax">ProgressBar的最大值</param>
        
        public void SetProgressBarMax(int ProgressBarMax)
        {

            if (this.progressBar1.InvokeRequired)
            {

                this.Invoke(new SetProgressBarMaxHandler(SetProgressBarMax), ProgressBarMax);


            }
            else
            {
                if (ProgressBarMax == 0)
                {
                    this.progressBar1.Visible = false;
                }
                else
                {
                    this.progressBar1.Maximum = ProgressBarMax;
                    this.progressBar1.Value = 0;
                    this.progressBar1.Visible = true;

                }
                

            }


        }


        /// <summary>
        /// 将ProgressBar的值加1
        /// </summary>
        public void ProgressBarGrow()
        {
            if (this.progressBar1.InvokeRequired)
            {
                this.Invoke(new ProgressBarGrowHandler(ProgressBarGrow));
            }
            else
            {
                if (this.progressBar1.Value < this.progressBar1.Maximum)
                {

                    //Console.WriteLine("{0}--{1}",this.progressBar1.Value,this.progressBar1.Maximum);
                    this.progressBar1.Value = this.progressBar1.Value + 1;
                    //this.label2.Text = Convert.ToString(Math.Round(Convert.ToDecimal(progressBar1.Value / progressBar1.Maximum) * 10000) / 100) + "%";
                    SetPercentText(Convert.ToString(Math.Round(Convert.ToDecimal(progressBar1.Value * 1.0 / progressBar1.Maximum) * 100,2) ) + "%");

                }
            }


        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime Date1 = Begin_time;
            DateTime Date2 = DateTime.Now;

            TimeSpan d3 = Date2.Subtract(Date1);
            try
            {
                if (this.label1.InvokeRequired)
                {
                    this.Invoke(new SetTimeTextHandler(SetTimeText), "总用时：" + d3.Days.ToString() + "天" + d3.Hours.ToString() + "小时" + d3.Minutes.ToString() + "分钟" + d3.Seconds.ToString() + "秒");
                }
                else
                {
                    this.label1.Text = "总用时：" + d3.Days.ToString() + "天" + d3.Hours.ToString() + "小时" + d3.Minutes.ToString() + "分钟" + d3.Seconds.ToString() + "秒";
                }
            }
               catch (Exception)
            {

                throw;
            }
        }

        private void WaitForm_Load(object sender, EventArgs e)
        {

        }

        private void WaitForm_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }
    }





    /// <summary>
    /// 用于显示等等窗体
    /// </summary>
    public class WaitFormService
    {

        private Form owner;
        private WaitForm waitform;




        public WaitFormService()
        {
            waitform = new WaitForm();
        }



        public void Show(Form Owner)
        {
            this._CreateForm(Owner);

            owner = Owner;
            owner.Enabled = false;
            //Thread.Sleep(100);
        }

        private void _CreateForm(Form Owner)
        {
            //waitform = null;




            Thread waitThread = new Thread(new ParameterizedThreadStart(this._ShowWaitForm));

            waitThread.Start(Owner);  //启动异步线程

        }

        private void _ShowWaitForm(object Owner)
        {
            waitform.Owner =(Form) Owner;
            waitform.ShowDialog();
        }

        public void Close()
        {
            Thread.Sleep(100);

            if (waitform != null)
            {
                Application.DoEvents();
                owner.Enabled = true;
                waitform.Close();
            }
        }



        /// <summary>  
        /// 设置任务名称
        /// </summary>  
        /// <param name="text"></param>  
        public void SetMissionNameText(string text)
        {


            if (waitform != null)
            {

                waitform.Show();
                waitform.SetMissionNameText(text);
            }

        }


        /// <summary>  
        /// 设置百分比进度
        /// </summary>  
        /// <param name="text"></param>  
        public void SetPercentText(string text)
        {


            if (waitform != null)
            {

                waitform.Show();
                waitform.SetPercentText(text);
            }

        }


        /// <summary>
        /// 设置ProgressBar的最大值与步进值
        /// </summary>
        /// <param name="ProgressBarMax">ProgressBar的最大值</param>
        
        public void SetProgressBarMax(int ProgressBarMax)
        {
            if (waitform != null)
            {
                
                waitform.Show();

                waitform.SetProgressBarMax(ProgressBarMax);

         
            }
        }


        /// <summary>
        /// 将ProgressBar的值加1
        /// </summary>
        public void ProgressBarGrow()
        {
            if (waitform != null)
            {
             

                waitform.Show();
                Application.DoEvents();
                waitform.ProgressBarGrow();

            }
        }


    }

}
