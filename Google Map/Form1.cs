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



        public string address;
        string zoom;
        int heading;


        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void adrsTxt_TextChanged(object sender, EventArgs e)
        {
            address = adrsTxt.Text;
            EndTxt.Text = address;
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
            if (trackBar2.Value == 0)
                heading = 45;
            else if (trackBar2.Value == 1)
                heading = 90;
            else if (trackBar2.Value == 2)
                heading = 135;
            else if (trackBar2.Value == 3)
                heading = 180;
            else if (trackBar2.Value == 4)
                heading = 225;
            else if (trackBar2.Value == 5)
                heading = 270;
            else if (trackBar2.Value == 6)
                heading = 315;
            else if (trackBar2.Value == 7)
                heading = 360;
            

            requestPicStreet = WebRequest.Create("http://maps.googleapis.com/maps/api/streetview?location=" + address + "&heading=" + heading.ToString() + "&size=353x267&sensor=false");
            repsonsePicStreet = requestPicStreet.GetResponse();
            mapStreet = Image.FromStream(repsonsePicStreet.GetResponseStream());
            pictureBox2.Image = mapStreet;
        }

        private void EndTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void startTxt_Click(object sender, EventArgs e)
        {
            startTxt.Text = address;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 directions = new Form2();
            directions.Show();
            
        }

        
    }
}
