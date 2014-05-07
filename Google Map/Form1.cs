using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace Google_Map
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        WebRequest requestPicStatic;
        WebResponse repsonsePicStatic;
        WebRequest requestPicStreet;
        WebResponse repsonsePicStreet;
        Image mapStatic;
        Image mapStreet;



        string address;
        string zoom;
        int heading;


        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void adrsTxt_TextChanged(object sender, EventArgs e)
        {
            address = adrsTxt.Text;
        }

        private void staticBtn_Click(object sender, EventArgs e)
        {
            requestPicStatic = WebRequest.Create("http://maps.googleapis.com/maps/api/staticmap?center=" + address + "&zoom=" + zoom + "&size=353x267&sensor=false");
            repsonsePicStatic = requestPicStatic.GetResponse();
            mapStatic = Image.FromStream(repsonsePicStatic.GetResponseStream());
            pictureBox1.Image = mapStatic;
            
        }

        private void strtBtn_Click(object sender, EventArgs e)
        {
            requestPicStreet = WebRequest.Create("http://maps.googleapis.com/maps/api/streetview?location=" + address + "&heading=" + heading.ToString() + "&zoom=12&size=453x267&sensor=false");
            repsonsePicStreet = requestPicStreet.GetResponse();
            mapStreet = Image.FromStream(repsonsePicStreet.GetResponseStream());
            pictureBox2.Image = mapStreet;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            zoom = trackBar1.Value.ToString();
            requestPicStatic = WebRequest.Create("http://maps.googleapis.com/maps/api/staticmap?center=" + address + "&zoom=" + zoom + "&size=353x267&sensor=false");
            repsonsePicStatic = requestPicStatic.GetResponse();
            mapStatic = Image.FromStream(repsonsePicStatic.GetResponseStream());
            pictureBox1.Image = mapStatic;
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            if(trackBar2.Value == 0)
                heading = 45 + trackBar2.Value;

            if (trackBar2.Value != 0)
                heading = 45 + heading;

            requestPicStreet = WebRequest.Create("http://maps.googleapis.com/maps/api/streetview?location=" + address + "&heading=" + heading.ToString() + "&size=353x267&sensor=false");
            repsonsePicStreet = requestPicStreet.GetResponse();
            mapStreet = Image.FromStream(repsonsePicStreet.GetResponseStream());
            pictureBox2.Image = mapStreet;
        }

        
    }
}
