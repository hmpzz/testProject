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
        /// <summary>
        /// 设置时间的label
        /// </summary>
        /// <param name="text"></param>
        private delegate void SetTopTextHandler(string text);

        public WaitForm(Form Owner)
        {
            InitializeComponent();

            this.Owner = Owner;
        }

        /// <summary>
        /// 置头顶上的label(label1)
        /// </summary>
        /// <param name="text">想要填入的文字</param>
        public void SetTopText(string text)
        {
            if (this.label1.InvokeRequired)
            {
                this.Invoke(new SetTopTextHandler(SetTopText), text);
            }
            else
            {
                this.label1.Text = text;
            }
        }




    }





    /// <summary>
    /// 用于显示等等窗体
    /// </summary>
    public class WaitFormService
    {

        private Form owner;
        private WaitForm waitform;


        public WaitFormService(Form Owner)
        {
            waitform = new WaitForm(Owner);
            owner = Owner;
        }



        public void Show()
        {
            owner.Enabled = false;

            Thread waitThread = new Thread(new ThreadStart(waitform.Show));

            waitThread.Start();  //启动异步线程



        }


        public void Close()
        {
            if (waitform != null)
            {
                Application.DoEvents();
                owner.Enabled = true;
                waitform.Close();
            }
        }




        /// <summary>  
        /// 设置等待窗体标题  
        /// </summary>  
        /// <param name="text"></param>  
        public void SetTopText(string text)
        {
            //if (isclose == true)  
            //{  
            //    return;  
            //}  
            //try  
            //{  
            waitform.Show();
            waitform.SetTopText(text);

            //}  
            //catch (Exception ex)  
            //{   
            //}  
        }

    }

}
