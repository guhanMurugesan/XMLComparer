﻿namespace FileComparer.UI
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblDestinationFileName = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.lblResult = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::FileComparer.UI.Properties.Resources.light_blue_gradient_ui_gradient;
            this.button1.Location = new System.Drawing.Point(80, 62);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(25, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "::";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Image = global::FileComparer.UI.Properties.Resources.light_blue_gradient_ui_gradient;
            this.label1.Location = new System.Drawing.Point(131, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "hello";
            // 
            // button2
            // 
            this.button2.BackgroundImage = global::FileComparer.UI.Properties.Resources.light_blue_gradient_ui_gradient;
            this.button2.Location = new System.Drawing.Point(80, 107);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(25, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "::";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Image = global::FileComparer.UI.Properties.Resources.light_blue_gradient_ui_gradient;
            this.label2.Location = new System.Drawing.Point(134, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "hello";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(181, 191);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(114, 20);
            this.textBox1.TabIndex = 4;
            // 
            // lblDestinationFileName
            // 
            this.lblDestinationFileName.AutoSize = true;
            this.lblDestinationFileName.BackColor = System.Drawing.Color.White;
            this.lblDestinationFileName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDestinationFileName.Image = global::FileComparer.UI.Properties.Resources.light_blue_gradient_ui_gradient;
            this.lblDestinationFileName.Location = new System.Drawing.Point(38, 193);
            this.lblDestinationFileName.Name = "lblDestinationFileName";
            this.lblDestinationFileName.Size = new System.Drawing.Size(112, 15);
            this.lblDestinationFileName.TabIndex = 5;
            this.lblDestinationFileName.Text = "Destination File Name";
            this.lblDestinationFileName.Click += new System.EventHandler(this.label3_Click);
            // 
            // button3
            // 
            this.button3.BackgroundImage = global::FileComparer.UI.Properties.Resources.light_blue_gradient_ui_gradient;
            this.button3.Location = new System.Drawing.Point(181, 243);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 6;
            this.button3.Text = "Compare";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.BackgroundImage = global::FileComparer.UI.Properties.Resources.light_blue_gradient_ui_gradient;
            this.button4.Location = new System.Drawing.Point(80, 150);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(25, 23);
            this.button4.TabIndex = 7;
            this.button4.Text = "::";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Image = global::FileComparer.UI.Properties.Resources.light_blue_gradient_ui_gradient;
            this.label4.Location = new System.Drawing.Point(135, 159);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "hello";
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.BackColor = System.Drawing.Color.White;
            this.lblResult.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblResult.Image = global::FileComparer.UI.Properties.Resources.light_blue_gradient_ui_gradient;
            this.lblResult.Location = new System.Drawing.Point(311, 193);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(2, 15);
            this.lblResult.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::FileComparer.UI.Properties.Resources.light_blue_gradient_ui_gradient;
            this.ClientSize = new System.Drawing.Size(622, 438);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.lblDestinationFileName);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Name = "Form1";
            this.Text = "XML Comparer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lblDestinationFileName;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label lblResult;
    }
}

