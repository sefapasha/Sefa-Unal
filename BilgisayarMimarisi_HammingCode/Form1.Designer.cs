namespace BilgisayarMimarisi_HammingCode
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBox1 = new TextBox();
            button1 = new Button();
            textBox2 = new TextBox();
            button2 = new Button();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            printDocument1 = new System.Drawing.Printing.PrintDocument();
            label3 = new Label();
            label4 = new Label();
            textBox5 = new TextBox();
            label6 = new Label();
            textBox6 = new TextBox();
            label5 = new Label();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(30, 65);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(316, 27);
            textBox1.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(405, 65);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 1;
            button1.Text = "Kaydet";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(30, 158);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(316, 27);
            textBox2.TabIndex = 2;
            // 
            // button2
            // 
            button2.Location = new Point(405, 156);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 3;
            button2.Text = "Değiştir";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(30, 297);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(316, 27);
            textBox3.TabIndex = 4;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(30, 378);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(316, 27);
            textBox4.TabIndex = 5;
            textBox4.TextChanged += textBox4_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(66, 42);
            label1.Name = "label1";
            label1.Size = new Size(238, 20);
            label1.TabIndex = 6;
            label1.Text = "8.16 veya 32 bitlik Binary Veri Girişi";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(63, 135);
            label2.Name = "label2";
            label2.Size = new Size(241, 20);
            label2.TabIndex = 7;
            label2.Text = "Hesaplanan Hamming Code Binary";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(124, 274);
            label3.Name = "label3";
            label3.Size = new Size(123, 20);
            label3.TabIndex = 8;
            label3.Text = "Hatalı Binary Veri";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(149, 355);
            label4.Name = "label4";
            label4.Size = new Size(69, 20);
            label4.TabIndex = 9;
            label4.Text = "Sendrom";
            // 
            // textBox5
            // 
            textBox5.Location = new Point(30, 455);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(316, 27);
            textBox5.TabIndex = 11;
            textBox5.TextChanged += textBox5_TextChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(124, 432);
            label6.Name = "label6";
            label6.Size = new Size(140, 20);
            label6.TabIndex = 12;
            label6.Text = "Hatalı Bit Pozisyonu";
            // 
            // textBox6
            // 
            textBox6.Location = new Point(30, 529);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(316, 27);
            textBox6.TabIndex = 13;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(100, 506);
            label5.Name = "label5";
            label5.Size = new Size(192, 20);
            label5.TabIndex = 14;
            label5.Text = "Düzeltilmiş Hamming Code";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveBorder;
            ClientSize = new Size(529, 581);
            Controls.Add(label5);
            Controls.Add(textBox6);
            Controls.Add(label6);
            Controls.Add(textBox5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(button2);
            Controls.Add(textBox2);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Name = "Form1";
            Text = "Hamming Kod Simülasyonu";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Button button1;
        private TextBox textBox2;
        private Button button2;
        private TextBox textBox3;
        private TextBox textBox4;
        private Label label1;
        private Label label2;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private Label label3;
        private Label label4;
        private TextBox textBox5;
        private Label label6;
        private TextBox textBox6;
        private Label label5;
    }
}
