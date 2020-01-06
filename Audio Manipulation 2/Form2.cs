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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void OnEventReceived(object sender, MidiEventReceivedEventArgs e)
        {
            var midiDevice = (MidiDevice)sender;
            Console.WriteLine($"Event received from '{midiDevice.Name}' at {DateTime.Now}: {e.Event}");
            MessageBox.Show($"Event received from '{midiDevice.Name}' at {DateTime.Now}: {e.Event}");
        }

        

        private void Form2_Load(object sender, EventArgs e)
        {

            int deviceCount = InputDevice.GetDevicesCount();
            string deviceCountString = deviceCount.ToString();
            textBox1.Text = deviceCountString;
            //Console.WriteLine(deviceString);     //seems to crash when highlight textbox 


            using (var inputDevice = InputDevice.GetById(0))
            {
                inputDevice.EventReceived += OnEventReceived;
                inputDevice.StartEventsListening();
                textBox2.Text = inputDevice.Name;
                int midiIDINT = inputDevice.Id;
                string midiIDString = midiIDINT.ToString();
                midiID.Text = midiIDString;
            }

        }

        public void midiDeviceName_TextChanged(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void midiID_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
