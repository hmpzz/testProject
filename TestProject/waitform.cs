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
    public partial class waitform : Form
    {

        private System.Windows.Forms.Form OwnerForm;

        public waitform()
        {
            InitializeComponent();
            //Control.CheckForIllegalCrossThreadCalls = false;
            setMsg = invoke;
            close = base.Close;

            
        }


        Action<string> setMsg;
        Action close;
       
        public string Msg
        {
            get
            {
                return this.label1.Text;
            }
            set
            {
                while (!this.IsHandleCreated) ;
                this.Invoke(setMsg, value);
            }
        }
        public new void Close()
        {
            while (!this.IsHandleCreated) ;
            //OwnerForm.Enabled = true;
            this.Invoke(close);
        }
        void invoke(string msg)
        {
            this.label1.Text = msg;
        }

        private void waitform_Load(object sender, EventArgs e)
        {

        }

        public void ShowDialog(Form Owner)
        {
            this.OwnerForm = Owner;
            OwnerForm.Enabled = false;
            base.ShowDialog(Owner);
        }
    }
}
