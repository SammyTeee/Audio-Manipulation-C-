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

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int deviceCount = InputDevice.GetDevicesCount();
            string deviceString = deviceCount.ToString();
            textBox1.Text = deviceString;
            Console.WriteLine(deviceString);



            using (var inputDevice = InputDevice.GetById(0))
            {
                inputDevice.EventReceived += OnEventReceived;
                inputDevice.StartEventsListening();
            }
        }
        private void OnEventReceived(object sender, MidiEventReceivedEventArgs e)
        {
            var midiDevice = (MidiDevice)sender;
            Console.WriteLine($"Event received from '{midiDevice.Name}' at {DateTime.Now}: {e.Event}");
            System.Windows.Forms.MessageBox.Show($"Event received from '{midiDevice.Name}' at {DateTime.Now}: {e.Event}");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
