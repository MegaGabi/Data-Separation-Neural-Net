namespace NN_matricies
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
            this.pnl_DrawHere = new System.Windows.Forms.Panel();
            this.btn_Learn = new System.Windows.Forms.Button();
            this.btn_Clear = new System.Windows.Forms.Button();
            this.rb_Red = new System.Windows.Forms.RadioButton();
            this.rb_Green = new System.Windows.Forms.RadioButton();
            this.rb_Blue = new System.Windows.Forms.RadioButton();
            this.pnl_Rbs = new System.Windows.Forms.Panel();
            this.x_pos = new System.Windows.Forms.Label();
            this.y_pos = new System.Windows.Forms.Label();
            this.btn_Amnesia = new System.Windows.Forms.Button();
            this.nud_IterationsNumber = new System.Windows.Forms.NumericUpDown();
            this.btn_Stop = new System.Windows.Forms.Button();
            this.l_CurrIter = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chkbx_RdrwInTheEnd = new System.Windows.Forms.CheckBox();
            this.pnl_Rbs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_IterationsNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // pnl_DrawHere
            // 
            this.pnl_DrawHere.BackColor = System.Drawing.Color.White;
            this.pnl_DrawHere.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_DrawHere.Location = new System.Drawing.Point(125, 17);
            this.pnl_DrawHere.MaximumSize = new System.Drawing.Size(500, 500);
            this.pnl_DrawHere.Name = "pnl_DrawHere";
            this.pnl_DrawHere.Size = new System.Drawing.Size(500, 500);
            this.pnl_DrawHere.TabIndex = 0;
            this.pnl_DrawHere.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.pnl_DrawHere.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.pnl_DrawHere.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // btn_Learn
            // 
            this.btn_Learn.Location = new System.Drawing.Point(12, 93);
            this.btn_Learn.Name = "btn_Learn";
            this.btn_Learn.Size = new System.Drawing.Size(107, 23);
            this.btn_Learn.TabIndex = 5;
            this.btn_Learn.Text = "Learn";
            this.btn_Learn.UseVisualStyleBackColor = true;
            this.btn_Learn.Click += new System.EventHandler(this.button2_Click);
            // 
            // btn_Clear
            // 
            this.btn_Clear.Location = new System.Drawing.Point(12, 497);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.Size = new System.Drawing.Size(107, 23);
            this.btn_Clear.TabIndex = 6;
            this.btn_Clear.Text = "Clear";
            this.btn_Clear.UseVisualStyleBackColor = true;
            this.btn_Clear.Click += new System.EventHandler(this.button5_Click);
            // 
            // rb_Red
            // 
            this.rb_Red.AutoSize = true;
            this.rb_Red.Checked = true;
            this.rb_Red.Location = new System.Drawing.Point(3, 3);
            this.rb_Red.Name = "rb_Red";
            this.rb_Red.Size = new System.Drawing.Size(45, 17);
            this.rb_Red.TabIndex = 7;
            this.rb_Red.TabStop = true;
            this.rb_Red.Text = "Red";
            this.rb_Red.UseVisualStyleBackColor = true;
            this.rb_Red.CheckedChanged += new System.EventHandler(this.rb_Green_CheckedChanged);
            // 
            // rb_Green
            // 
            this.rb_Green.AutoSize = true;
            this.rb_Green.Location = new System.Drawing.Point(3, 26);
            this.rb_Green.Name = "rb_Green";
            this.rb_Green.Size = new System.Drawing.Size(54, 17);
            this.rb_Green.TabIndex = 8;
            this.rb_Green.Text = "Green";
            this.rb_Green.UseVisualStyleBackColor = true;
            this.rb_Green.CheckedChanged += new System.EventHandler(this.rb_Green_CheckedChanged);
            // 
            // rb_Blue
            // 
            this.rb_Blue.AutoSize = true;
            this.rb_Blue.Location = new System.Drawing.Point(3, 49);
            this.rb_Blue.Name = "rb_Blue";
            this.rb_Blue.Size = new System.Drawing.Size(46, 17);
            this.rb_Blue.TabIndex = 9;
            this.rb_Blue.Text = "Blue";
            this.rb_Blue.UseVisualStyleBackColor = true;
            this.rb_Blue.CheckedChanged += new System.EventHandler(this.rb_Green_CheckedChanged);
            // 
            // pnl_Rbs
            // 
            this.pnl_Rbs.Controls.Add(this.rb_Red);
            this.pnl_Rbs.Controls.Add(this.rb_Blue);
            this.pnl_Rbs.Controls.Add(this.rb_Green);
            this.pnl_Rbs.Location = new System.Drawing.Point(12, 16);
            this.pnl_Rbs.Name = "pnl_Rbs";
            this.pnl_Rbs.Size = new System.Drawing.Size(63, 71);
            this.pnl_Rbs.TabIndex = 10;
            // 
            // x_pos
            // 
            this.x_pos.AutoSize = true;
            this.x_pos.Location = new System.Drawing.Point(12, 425);
            this.x_pos.Name = "x_pos";
            this.x_pos.Size = new System.Drawing.Size(24, 13);
            this.x_pos.TabIndex = 11;
            this.x_pos.Text = "x: 0";
            // 
            // y_pos
            // 
            this.y_pos.AutoSize = true;
            this.y_pos.Location = new System.Drawing.Point(12, 452);
            this.y_pos.Name = "y_pos";
            this.y_pos.Size = new System.Drawing.Size(24, 13);
            this.y_pos.TabIndex = 12;
            this.y_pos.Text = "y: 0";
            // 
            // btn_Amnesia
            // 
            this.btn_Amnesia.Location = new System.Drawing.Point(12, 468);
            this.btn_Amnesia.Name = "btn_Amnesia";
            this.btn_Amnesia.Size = new System.Drawing.Size(107, 23);
            this.btn_Amnesia.TabIndex = 13;
            this.btn_Amnesia.Text = "Amnesia";
            this.btn_Amnesia.UseVisualStyleBackColor = true;
            this.btn_Amnesia.Click += new System.EventHandler(this.btn_Amnesia_Click);
            // 
            // nud_IterationsNumber
            // 
            this.nud_IterationsNumber.Location = new System.Drawing.Point(12, 135);
            this.nud_IterationsNumber.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nud_IterationsNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_IterationsNumber.Name = "nud_IterationsNumber";
            this.nud_IterationsNumber.Size = new System.Drawing.Size(107, 20);
            this.nud_IterationsNumber.TabIndex = 14;
            this.nud_IterationsNumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btn_Stop
            // 
            this.btn_Stop.Enabled = false;
            this.btn_Stop.Location = new System.Drawing.Point(12, 197);
            this.btn_Stop.Name = "btn_Stop";
            this.btn_Stop.Size = new System.Drawing.Size(107, 23);
            this.btn_Stop.TabIndex = 15;
            this.btn_Stop.Text = "Stop";
            this.btn_Stop.UseVisualStyleBackColor = true;
            this.btn_Stop.Click += new System.EventHandler(this.btn_Stop_Click);
            // 
            // l_CurrIter
            // 
            this.l_CurrIter.AutoSize = true;
            this.l_CurrIter.Location = new System.Drawing.Point(12, 223);
            this.l_CurrIter.Name = "l_CurrIter";
            this.l_CurrIter.Size = new System.Drawing.Size(13, 13);
            this.l_CurrIter.TabIndex = 16;
            this.l_CurrIter.Text = "0";
            this.l_CurrIter.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Epochs:";
            // 
            // chkbx_RdrwInTheEnd
            // 
            this.chkbx_RdrwInTheEnd.AutoSize = true;
            this.chkbx_RdrwInTheEnd.Location = new System.Drawing.Point(12, 161);
            this.chkbx_RdrwInTheEnd.Name = "chkbx_RdrwInTheEnd";
            this.chkbx_RdrwInTheEnd.Size = new System.Drawing.Size(88, 30);
            this.chkbx_RdrwInTheEnd.TabIndex = 18;
            this.chkbx_RdrwInTheEnd.Text = "Redraw only \r\nin the end";
            this.chkbx_RdrwInTheEnd.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 529);
            this.Controls.Add(this.chkbx_RdrwInTheEnd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.l_CurrIter);
            this.Controls.Add(this.btn_Stop);
            this.Controls.Add(this.nud_IterationsNumber);
            this.Controls.Add(this.btn_Amnesia);
            this.Controls.Add(this.y_pos);
            this.Controls.Add(this.x_pos);
            this.Controls.Add(this.pnl_Rbs);
            this.Controls.Add(this.btn_Clear);
            this.Controls.Add(this.btn_Learn);
            this.Controls.Add(this.pnl_DrawHere);
            this.MinimumSize = new System.Drawing.Size(656, 568);
            this.Name = "Form1";
            this.Text = "Neural Net";
            this.pnl_Rbs.ResumeLayout(false);
            this.pnl_Rbs.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_IterationsNumber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnl_DrawHere;
        private System.Windows.Forms.Button btn_Learn;
        private System.Windows.Forms.Button btn_Clear;
        private System.Windows.Forms.RadioButton rb_Red;
        private System.Windows.Forms.RadioButton rb_Green;
        private System.Windows.Forms.RadioButton rb_Blue;
        private System.Windows.Forms.Panel pnl_Rbs;
        private System.Windows.Forms.Label x_pos;
        private System.Windows.Forms.Label y_pos;
        private System.Windows.Forms.Button btn_Amnesia;
        private System.Windows.Forms.NumericUpDown nud_IterationsNumber;
        private System.Windows.Forms.Button btn_Stop;
        private System.Windows.Forms.Label l_CurrIter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkbx_RdrwInTheEnd;
    }
}

