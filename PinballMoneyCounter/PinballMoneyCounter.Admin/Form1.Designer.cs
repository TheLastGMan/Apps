namespace PinballMoneyCounter.Admin
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
			this.numericUpDownDollars = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.numericUpDownCents = new System.Windows.Forms.NumericUpDown();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.button5 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownDollars)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownCents)).BeginInit();
			this.SuspendLayout();
			// 
			// numericUpDownDollars
			// 
			this.numericUpDownDollars.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.numericUpDownDollars.Location = new System.Drawing.Point(167, 17);
			this.numericUpDownDollars.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
			this.numericUpDownDollars.Name = "numericUpDownDollars";
			this.numericUpDownDollars.Size = new System.Drawing.Size(121, 34);
			this.numericUpDownDollars.TabIndex = 0;
			this.numericUpDownDollars.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numericUpDownDollars.ThousandsSeparator = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(12, 19);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(149, 29);
			this.label1.TabIndex = 1;
			this.label1.Text = "Total Spent: ";
			// 
			// numericUpDownCents
			// 
			this.numericUpDownCents.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.numericUpDownCents.Location = new System.Drawing.Point(294, 17);
			this.numericUpDownCents.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
			this.numericUpDownCents.Name = "numericUpDownCents";
			this.numericUpDownCents.Size = new System.Drawing.Size(121, 34);
			this.numericUpDownCents.TabIndex = 2;
			this.numericUpDownCents.ThousandsSeparator = true;
			// 
			// button1
			// 
			this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button1.Location = new System.Drawing.Point(167, 57);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(248, 46);
			this.button1.TabIndex = 3;
			this.button1.Text = "Set Spent";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button2.Location = new System.Drawing.Point(115, 109);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(92, 92);
			this.button2.TabIndex = 4;
			this.button2.Text = "Add $0.50";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button3
			// 
			this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button3.Location = new System.Drawing.Point(11, 109);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(92, 92);
			this.button3.TabIndex = 5;
			this.button3.Text = "Add $0.25";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// button4
			// 
			this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button4.Location = new System.Drawing.Point(219, 109);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(92, 92);
			this.button4.TabIndex = 6;
			this.button4.Text = "Add $0.75";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// button5
			// 
			this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button5.Location = new System.Drawing.Point(323, 109);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(92, 92);
			this.button5.TabIndex = 7;
			this.button5.Text = "Add $1.00";
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new System.EventHandler(this.button5_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(429, 212);
			this.Controls.Add(this.button5);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.numericUpDownCents);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.numericUpDownDollars);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownDollars)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownCents)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.NumericUpDown numericUpDownDollars;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown numericUpDownCents;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button5;
	}
}

