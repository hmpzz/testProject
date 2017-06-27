using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace JSON
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s;
            s = "{ \"list\":[{\"order_no\":\"CRAFT001\",\"store_id\":1},{\"order_no\":\"CRAFT002\",\"store_id\":1}]}";

            Rootobject dt;
            dt = JsonStringToObj<Rootobject>(s);


            
        }

        /// <summary>  
        /// json转为对象  
        /// </summary>  
        /// <typeparam name="ObjType"></typeparam>  
        /// <param name="JsonString"></param>  
        /// <returns></returns>  
        public static ObjType JsonStringToObj<ObjType>(string JsonString) where ObjType : class
        {
            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            ObjType s = jsonSerializer.Deserialize<ObjType>(JsonString);
            return s;
        }


       // {"list":[{"order_no":"CRAFT001","store_id":1},{"order_no":"CRAFT002","store_id":1}]}
      


        public class Rootobject
        {
            public List[] list { get; set; }
        }

        public class List
        {
            public string order_no { get; set; }
            public int store_id { get; set; }
        }

    }
}
