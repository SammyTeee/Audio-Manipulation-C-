using System;
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

namespace Audio_Manipulation_2
{
    public partial class Form1 : Form
    {

        private WaveOutEvent outputDevice;
        private AudioFileReader audioFile;

        double numClicktime = 0;
        private Timer doubleClickTimer = new Timer();

        public Form1()
        {
            InitializeComponent();
        }

        //private void Form1_Load(object sender, EventArgs e)
        // {
        //   Image image = Image.FromFile("c:/output.png");
        //   pictureBox2.Image = image;
        //   pictureBox2.Height = image.Height;
        //   pictureBox2.Width = image.Width;
        // }



        private void OnButtonPlayClick_Click(object sender, EventArgs e)
        {


            if (IsDisposed)
            {
                Console.WriteLine("cheese");        //stops crash when play pressed when playing 
            }
            else if (outputDevice == null)
            {
                outputDevice = new WaveOutEvent();                      //WaveOutEvent best option for sending audio to soundcard 
                outputDevice.PlaybackStopped += OnPlaybackStopped;      // to add ASIO - github.com/naudio/NAudio/blob/master/Docs/AsioPlayback.md
            }
            if (audioFile == null)
            {
                audioFile = new AudioFileReader(textBox1.Text);                             //audioFile = new AudioFileReader(@"c:\aphextwin.mp3");     //hardcoded directory
                outputDevice.Init(audioFile);
            }

            outputDevice.Play();

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
                oSelectedFile = oDlg.FileName;      // selected file = oSelectedFile
                textBox1.Text = oSelectedFile;

                // Configure Providers
                MaxPeakProvider maxPeakProvider = new MaxPeakProvider();
                RmsPeakProvider rmsPeakProvider = new RmsPeakProvider(200); // e.g. 200
                SamplingPeakProvider samplingPeakProvider = new SamplingPeakProvider(200); // e.g. 200
                AveragePeakProvider averagePeakProvider = new AveragePeakProvider(4); // e.g. 4

                // Configure the style of the audio wave image
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

        private void butPause_Click(object sender, EventArgs e)
        {
            outputDevice.Pause();                  //working playback stop button - doesnt crash when playback null 
        }

        private void butStop_click(object sender, EventArgs e)
        {
            outputDevice.Stop();      //throws exception if pressed when already stopped
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

            long playbackDuration = outputDevice.GetPosition();
            string durationString;
            durationString = playbackDuration.ToString();
            textBox2.Text = durationString;

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
            else
            {

                numClicktime = 0;
                doubleClickTimer.Stop();
                outputDevice.Stop();     //double click event
                //MessageBox.Show("DOUBLE");

            }


        }

        void doubleClickTimer_Tick(object sender, EventArgs e)
        {

            if (DateTime.Now.TimeOfDay.TotalMilliseconds - numClicktime > 300)
            {
                numClicktime = 0;
                doubleClickTimer.Stop();
                outputDevice.Pause();       //single click event
                                            //MessageBox.Show("SINGLE");

            }

        }

        private void butPauseStop_Click(object sender, EventArgs e)
        {

        }

        private void volumeSlider1_Load(object sender, EventArgs e)
        {
            //volumeSlider1.Volume = outputDevice.Volume
        }

        private void midiOptions_Click(object sender, EventArgs e)
        {
            var form2 = new Form2();
            form2.Show();
        }
    }
}
