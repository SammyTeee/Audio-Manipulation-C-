﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security;
using System.Windows.Forms;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using NAudio.FileFormats;
using WaveFormRendererLib;
using System.Drawing.Imaging;
using System.Drawing;
using Melanchall.DryWetMidi.Devices;
using Melanchall.DryWetMidi.Core;
using System.Threading;

namespace Audio_Manipulation_2
{
    public partial class Form1 : Form
    {

        private string PositionString = "";
        private WaveOutEvent outputDevice;
        private AudioFileReader audioFile;
        private IWavePlayer waveOutputDevice;

        double numClicktime = 0;
        private System.Windows.Forms.Timer doubleClickTimer = new System.Windows.Forms.Timer();

      //  public string PositionString { get; private set; }

        public Form1()
        {
            InitializeComponent();
        }


        //string PositionString;
        public void OnButtonPlayClick_Click(object sender, EventArgs e)
        {

            if (outputDevice == null)
            {
                outputDevice = new WaveOutEvent();                      //WaveOutEvent best option for sending audio to soundcard 
                outputDevice.PlaybackStopped += OnPlaybackStopped;      // to add ASIO - github.com/naudio/NAudio/blob/master/Docs/AsioPlayback.md
            }
             if (audioFile == null)
            {
                audioFile = new AudioFileReader(textBox1.Text);                             //audioFile = new AudioFileReader(@"c:\aphextwin.mp3");     //hardcoded directory
                outputDevice.Init(audioFile);
            }
            else
            {

            }

            outputDevice.Play();
            long GetPosition;
            GetPosition = outputDevice.GetPosition();
            PositionString = GetPosition.ToString();             //converts bytes to string
            textBox2.Text = PositionString;
            
            Task.Factory.StartNew(() => { printPositionString(); });
            
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        public void printPositionString()
        {

            SetText(PositionString);
        }
        private void SetText(string s)
        {
            textBox2.Invoke((MethodInvoker)delegate { textBox2.Text = s; });
            {
                Thread.Sleep(10);
            }
        }

        public void OnPlaybackStopped(object sender, StoppedEventArgs args)  //stop playback event handler
        {
            outputDevice.Dispose();
            outputDevice = null;
            audioFile.Dispose();
            audioFile = null;       //resets playback to 0/null 
        }

        private void ButBrowse_Click_1(object sender, EventArgs e)      //browse button
        {
            string oSelectedFile = "";
            System.Windows.Forms.OpenFileDialog oDlg = new System.Windows.Forms.OpenFileDialog();
            if (System.Windows.Forms.DialogResult.OK == oDlg.ShowDialog())
            {
                oSelectedFile = oDlg.FileName;      //selected file = oSelectedFile
                textBox1.Text = oSelectedFile;

                //configure Providers
                MaxPeakProvider maxPeakProvider = new MaxPeakProvider();
                RmsPeakProvider rmsPeakProvider = new RmsPeakProvider(200);
                SamplingPeakProvider samplingPeakProvider = new SamplingPeakProvider(200);      //could control these values with sliders?
                AveragePeakProvider averagePeakProvider = new AveragePeakProvider(4);

                //configure the style of the audio wave image
                StandardWaveFormRendererSettings myRendererSettings = new StandardWaveFormRendererSettings();
                myRendererSettings.Width = 1080;
                myRendererSettings.TopHeight = 64;
                myRendererSettings.BottomHeight = 64;

                WaveFormRenderer renderer = new WaveFormRenderer();
                String audioFilePath = textBox1.Text;
                Image image = renderer.Render(audioFilePath, averagePeakProvider, myRendererSettings);
                string folder = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
                System.IO.Directory.CreateDirectory(folder + "\\AudioManipulation");
                image.Save(folder + "\\AudioManipulation\\output.png", ImageFormat.Png);

                AddToLog("- Sound Played");

                //loads waveform after generation on file browse
                Image loadImage = Image.FromFile("\\output.png");
                pictureBox2.Image = image;
                pictureBox2.Height = image.Height;
                pictureBox2.Width = image.Width;


            }
        }

        public static void AddToLog(string txtToAdd)
        {

            string folder = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            System.IO.Directory.CreateDirectory(folder + "\\AudioManipulation");

            string path = folder + "\\AudioManipulation" + "\\logfile.txt";
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(DateTime.Now.ToString("dd MMM yy HH:mm:ss") + " : " + txtToAdd);
            }

        }
        private void textBox1_TextChanged(object sender, EventArgs e)  //text field for selected file directory
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)   //picturebox to display waveform
        {

        }

        public static void AddToProgramData()
        {

            string folder = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            System.IO.Directory.CreateDirectory(folder + "\\AudioManipulation");
            string path = folder + "\\AudioManipulation" + "\\logfile.txt";
            using (StreamWriter sw = File.AppendText(path)) ;

        }

        private void butPauseStop_Click(object sender, EventArgs e)
        {

        }

        private void butPause_Click(object sender, EventArgs e)
        {
            outputDevice.Pause();                  //working playback stop button - doesnt crash when playback null 
        }

        private void butStop_click(object sender, EventArgs e)
        {
            outputDevice.Stop();      
        }

        private void butPauseStop_MouseClick(object sender, MouseEventArgs e)
        {
            if (numClicktime == 0)
            {

                doubleClickTimer.Interval = 50;
                doubleClickTimer.Tick +=
                new EventHandler(doubleClickTimer_Tick);

                numClicktime = DateTime.Now.TimeOfDay.TotalMilliseconds;
                doubleClickTimer.Start();

            }

            if (outputDevice == null)
            {

            }

        }
        void doubleClickTimer_Tick(object sender, EventArgs e)
        {

            if (DateTime.Now.TimeOfDay.TotalMilliseconds - numClicktime > 300)
            {
                numClicktime = 0;
                doubleClickTimer.Stop();
                outputDevice.Pause();
            }

        }

        private void midiOptions_Click(object sender, EventArgs e)
        {
            var form2 = new Form2();
            form2.Show();
        }

        private void openLogFolderButt_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"explorer.exe" , @"C:\ProgramData\AudioManipulation");
        }

        private void volumeSlider1_VolumeChanged(object sender, EventArgs e) //Volume Slider
        {
            if (outputDevice == null)
            {
                Console.WriteLine("You haven't loaded a file yet!!");
            }
            else
            {
                outputDevice.Volume = volumeSlider1.Volume;                     //WaveOutEvent best option for sending audio to soundcard
            }

                         
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
        
        }
    }
}
