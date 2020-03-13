using AForge.Video.DirectShow;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wineforever.Coordinate;

namespace mask_wearing
{
    public partial class mainFrm : Form
    {
        //To get start,you need to prepare a background image first,
        //which means the image state when the object to be identified
        //does not exist, so that the target object can be identified
        //in the background, to achieve the effect of removing background
        //noise interference.
        private Bitmap background = (Bitmap)Bitmap.FromFile(System.AppDomain.CurrentDomain.BaseDirectory + "bg.jpg");
        private FilterInfoCollection videoDevices;//All camera equipment
        private VideoCaptureDevice videoDevice;//Camera equipment
        public mainFrm()
        {
            InitializeComponent();
        }
        public void Render()
        {
            //Photograph.
            Bitmap sample = vispShoot.GetCurrentVideoFrame();
            //Preprocessing.
            sample = Wineforever.Coordinate.client.HandleScale(sample, 250, 250);
            //Noise reduction.
            sample = Wineforever.Coordinate.client.HandleMask(sample, background, -50, "null", "B");
            //Render
            resWin.Image = sample;
        }
        private void mainFrm_Load(object sender, EventArgs e)
        {
            //Get all the camera equipment connected to the machine.
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            //First device selected by default.
            videoDevice = new VideoCaptureDevice(videoDevices[0].MonikerString);
            //Assign camera to control.
            vispShoot.VideoSource = videoDevice;
            //Turn on the camera.
            vispShoot.Start();
            //Initialization
            Wineforever.Coordinate.client.SetDistance(1);
            Wineforever.Coordinate.client.SetOriginalPoint(0,resWin.Height);
            Wineforever.Coordinate.client.Initialization();
            Thread.Sleep(1000);
            timer.Enabled = true;
        }
        //Disconnect and free up memory.
        private void mainFrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            vispShoot.SignalToStop();
            vispShoot.WaitForStop();
            vispShoot.VideoSource = null;
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            Render();
        }
    }
}
