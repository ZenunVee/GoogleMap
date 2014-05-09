using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Net;
using Newtonsoft.Json.Linq;

namespace Google_Map
{
    public partial class Form2 : Form
    {
        private string addressStart;
        private string addressEnd;
       
        
        public Form2(string addstart, string addend)
        {
            InitializeComponent();
            addressStart = addstart;
            addressEnd = addend;
        }


        private void Form2_Load(object sender, EventArgs e)
        {
            webBrowser1.Navigate("https://www.google.com/maps/dir/" + addressStart + "/" + addressEnd + "/"); 
            
        }

    }
}
