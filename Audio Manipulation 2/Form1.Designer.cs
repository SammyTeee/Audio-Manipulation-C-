using System;

namespace Audio_Manipulation_2
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.butPlay = new System.Windows.Forms.Button();
            this.butBrowse = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.waveformPainter2 = new NAudio.Gui.WaveformPainter();
            this.butPause = new System.Windows.Forms.Button();
            this.butStop = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.butPauseStop = new System.Windows.Forms.Button();
            this.volumeSlider1 = new NAudio.Gui.VolumeSlider();
            this.midiOptions = new System.Windows.Forms.Button();
            this.openLogFolderButt = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // butPlay
            // 
            this.butPlay.Location = new System.Drawing.Point(8, 12);
            this.butPlay.Name = "butPlay";
            this.butPlay.Size = new System.Drawing.Size(75, 45);
            this.butPlay.TabIndex = 0;
            this.butPlay.Text = "Play";
            this.butPlay.UseVisualStyleBackColor = true;
            this.butPlay.Click += new System.EventHandler(this.OnButtonPlayClick_Click);
            // 
            // butBrowse
            // 
            this.butBrowse.Location = new System.Drawing.Point(8, 221);
            this.butBrowse.Name = "butBrowse";
            this.butBrowse.Size = new System.Drawing.Size(75, 27);
            this.butBrowse.TabIndex = 2;
            this.butBrowse.Text = "Browse File";
            this.butBrowse.UseVisualStyleBackColor = true;
            this.butBrowse.Click += new System.EventHandler(this.ButBrowse_Click_1);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(8, 255);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(359, 20);
            this.textBox1.TabIndex = 3;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(8, 72);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(1197, 100);
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // waveformPainter2
            // 
            this.waveformPainter2.Location = new System.Drawing.Point(0, 0);
            this.waveformPainter2.Name = "waveformPainter2";
            this.waveformPainter2.Size = new System.Drawing.Size(0, 0);
            this.waveformPainter2.TabIndex = 0;
            // 
            // butPause
            // 
            this.butPause.Location = new System.Drawing.Point(986, 12);
            this.butPause.Name = "butPause";
            this.butPause.Size = new System.Drawing.Size(69, 45);
            this.butPause.TabIndex = 6;
            this.butPause.Text = "Pause";
            this.butPause.UseVisualStyleBackColor = true;
            this.butPause.Click += new System.EventHandler(this.butPause_Click);
            // 
            // butStop
            // 
            this.butStop.Location = new System.Drawing.Point(1061, 12);
            this.butStop.Name = "butStop";
            this.butStop.Size = new System.Drawing.Size(69, 45);
            this.butStop.TabIndex = 7;
            this.butStop.Text = "Stop";
            this.butStop.UseVisualStyleBackColor = true;
            this.butStop.Click += new System.EventHandler(this.butStop_click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(986, 255);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(144, 20);
            this.textBox2.TabIndex = 8;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // butPauseStop
            // 
            this.butPauseStop.Location = new System.Drawing.Point(89, 12);
            this.butPauseStop.Name = "butPauseStop";
            this.butPauseStop.Size = new System.Drawing.Size(75, 45);
            this.butPauseStop.TabIndex = 9;
            this.butPauseStop.Text = "Pause/Stop";
            this.butPauseStop.UseVisualStyleBackColor = true;
            this.butPauseStop.Click += new System.EventHandler(this.butPauseStop_Click);
            this.butPauseStop.MouseClick += new System.Windows.Forms.MouseEventHandler(this.butPauseStop_MouseClick);
            // 
            // volumeSlider1
            // 
            this.volumeSlider1.Location = new System.Drawing.Point(986, 230);
            this.volumeSlider1.Name = "volumeSlider1";
            this.volumeSlider1.Size = new System.Drawing.Size(144, 19);
            this.volumeSlider1.TabIndex = 10;
            this.volumeSlider1.Load += new System.EventHandler(this.volumeSlider1_Load);
            // 
            // midiOptions
            // 
            this.midiOptions.Location = new System.Drawing.Point(911, 12);
            this.midiOptions.Name = "midiOptions";
            this.midiOptions.Size = new System.Drawing.Size(69, 45);
            this.midiOptions.TabIndex = 11;
            this.midiOptions.Text = "MIDI Settings";
            this.midiOptions.UseVisualStyleBackColor = true;
            this.midiOptions.Click += new System.EventHandler(this.midiOptions_Click);
            // 
            // openLogFolderButt
            // 
            this.openLogFolderButt.Location = new System.Drawing.Point(658, 13);
            this.openLogFolderButt.Name = "openLogFolderButt";
            this.openLogFolderButt.Size = new System.Drawing.Size(69, 44);
            this.openLogFolderButt.TabIndex = 12;
            this.openLogFolderButt.Text = "Open Log Folder";
            this.openLogFolderButt.UseVisualStyleBackColor = true;
            this.openLogFolderButt.Click += new System.EventHandler(this.openLogFolderButt_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 278);
            this.Controls.Add(this.midiOptions);
            this.Controls.Add(this.volumeSlider1);
            this.Controls.Add(this.butPauseStop);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.butStop);
            this.Controls.Add(this.butPause);
            this.Controls.Add(this.waveformPainter2);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.butBrowse);
            this.Controls.Add(this.butPlay);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butPlay;
        private System.Windows.Forms.Button butBrowse;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private NAudio.Gui.WaveformPainter waveformPainter2;
        private System.Windows.Forms.Button butPause;
        private System.Windows.Forms.Button butStop;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button butPauseStop;
        private NAudio.Gui.VolumeSlider volumeSlider1;
        private System.Windows.Forms.Button midiOptions;
        private System.Windows.Forms.Button openLogFolderButt;
    }
}

