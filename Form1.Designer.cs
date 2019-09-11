namespace ChicagoCrime
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
            this.cmdByYear = new System.Windows.Forms.Button();
            this.graphPanel = new System.Windows.Forms.Panel();
            this.txtFilename = new System.Windows.Forms.TextBox();
            this.Arrest = new System.Windows.Forms.Button();
            this.ByCrime = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.SQLBUtton = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.graphPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdByYear
            // 
            this.cmdByYear.Location = new System.Drawing.Point(12, 12);
            this.cmdByYear.Name = "cmdByYear";
            this.cmdByYear.Size = new System.Drawing.Size(95, 62);
            this.cmdByYear.TabIndex = 0;
            this.cmdByYear.Text = "By Year";
            this.cmdByYear.UseVisualStyleBackColor = true;
            this.cmdByYear.Click += new System.EventHandler(this.cmdByYear_Click);
            // 
            // graphPanel
            // 
            this.graphPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.graphPanel.BackColor = System.Drawing.Color.White;
            this.graphPanel.Controls.Add(this.listBox1);
            this.graphPanel.Location = new System.Drawing.Point(123, 12);
            this.graphPanel.Name = "graphPanel";
            this.graphPanel.Size = new System.Drawing.Size(769, 454);
            this.graphPanel.TabIndex = 1;
            // 
            // txtFilename
            // 
            this.txtFilename.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilename.BackColor = System.Drawing.SystemColors.Control;
            this.txtFilename.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFilename.Location = new System.Drawing.Point(123, 474);
            this.txtFilename.Name = "txtFilename";
            this.txtFilename.Size = new System.Drawing.Size(769, 26);
            this.txtFilename.TabIndex = 2;
            this.txtFilename.Text = "Crimes-2013-2015.csv";
            // 
            // Arrest
            // 
            this.Arrest.Location = new System.Drawing.Point(12, 134);
            this.Arrest.Name = "Arrest";
            this.Arrest.Size = new System.Drawing.Size(95, 47);
            this.Arrest.TabIndex = 0;
            this.Arrest.Text = "Arrest%";
            this.Arrest.UseVisualStyleBackColor = true;
            this.Arrest.Click += new System.EventHandler(this.Arrest_Click);
            // 
            // ByCrime
            // 
            this.ByCrime.Location = new System.Drawing.Point(12, 187);
            this.ByCrime.Name = "ByCrime";
            this.ByCrime.Size = new System.Drawing.Size(95, 46);
            this.ByCrime.TabIndex = 0;
            this.ByCrime.Text = "By Crime";
            this.ByCrime.UseVisualStyleBackColor = true;
            this.ByCrime.Click += new System.EventHandler(this.ByCrime_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 239);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 29);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 289);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 47);
            this.button1.TabIndex = 0;
            this.button1.Text = "By Area";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(12, 363);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 29);
            this.textBox2.TabIndex = 0;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 398);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(95, 43);
            this.button2.TabIndex = 0;
            this.button2.Text = "Chicago";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // SQLBUtton
            // 
            this.SQLBUtton.Location = new System.Drawing.Point(12, 80);
            this.SQLBUtton.Name = "SQLBUtton";
            this.SQLBUtton.Size = new System.Drawing.Size(85, 35);
            this.SQLBUtton.TabIndex = 0;
            this.SQLBUtton.Text = "SQL";
            this.SQLBUtton.UseVisualStyleBackColor = true;
            this.SQLBUtton.Click += new System.EventHandler(this.SQLBUtton_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 24;
            this.listBox1.Location = new System.Drawing.Point(101, 93);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(668, 220);
            this.listBox1.TabIndex = 3;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 508);
            this.Controls.Add(this.SQLBUtton);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.ByCrime);
            this.Controls.Add(this.Arrest);
            this.Controls.Add(this.txtFilename);
            this.Controls.Add(this.graphPanel);
            this.Controls.Add(this.cmdByYear);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chicago Crime Analysis";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.graphPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button cmdByYear;
    private System.Windows.Forms.Panel graphPanel;
    private System.Windows.Forms.TextBox txtFilename;
        private System.Windows.Forms.Button Arrest;
        private System.Windows.Forms.Button ByCrime;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button SQLBUtton;
        private System.Windows.Forms.ListBox listBox1;
    }
}

