namespace coursework
{
    partial class Сalculator
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
            this.components = new System.ComponentModel.Container();
            this.equation_textBox = new System.Windows.Forms.TextBox();
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.clear_button = new System.Windows.Forms.Button();
            this.left_shift_button = new System.Windows.Forms.Button();
            this.right_shift_button = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.button16 = new System.Windows.Forms.Button();
            this.button17 = new System.Windows.Forms.Button();
            this.button18 = new System.Windows.Forms.Button();
            this.button19 = new System.Windows.Forms.Button();
            this.button20 = new System.Windows.Forms.Button();
            this.button21 = new System.Windows.Forms.Button();
            this.button22 = new System.Windows.Forms.Button();
            this.button23 = new System.Windows.Forms.Button();
            this.button24 = new System.Windows.Forms.Button();
            this.button25 = new System.Windows.Forms.Button();
            this.button26 = new System.Windows.Forms.Button();
            this.button27 = new System.Windows.Forms.Button();
            this.button28 = new System.Windows.Forms.Button();
            this.button29 = new System.Windows.Forms.Button();
            this.button30 = new System.Windows.Forms.Button();
            this.button31 = new System.Windows.Forms.Button();
            this.button35 = new System.Windows.Forms.Button();
            this.button36 = new System.Windows.Forms.Button();
            this.button37 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьГрафикToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.label4 = new System.Windows.Forms.Label();
            this.minBorder = new System.Windows.Forms.TextBox();
            this.maxBorder = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.button32 = new System.Windows.Forms.Button();
            this.button33 = new System.Windows.Forms.Button();
            this.button34 = new System.Windows.Forms.Button();
            this.delete_button = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // equation_textBox
            // 
            this.equation_textBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.equation_textBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.equation_textBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.equation_textBox.Location = new System.Drawing.Point(12, 27);
            this.equation_textBox.Multiline = true;
            this.equation_textBox.Name = "equation_textBox";
            this.equation_textBox.ReadOnly = true;
            this.equation_textBox.Size = new System.Drawing.Size(325, 26);
            this.equation_textBox.TabIndex = 27;
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.zedGraphControl1.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.zedGraphControl1.Location = new System.Drawing.Point(349, 27);
            this.zedGraphControl1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0D;
            this.zedGraphControl1.ScrollMaxX = 0D;
            this.zedGraphControl1.ScrollMaxY = 0D;
            this.zedGraphControl1.ScrollMaxY2 = 0D;
            this.zedGraphControl1.ScrollMinX = 0D;
            this.zedGraphControl1.ScrollMinY = 0D;
            this.zedGraphControl1.ScrollMinY2 = 0D;
            this.zedGraphControl1.Size = new System.Drawing.Size(600, 550);
            this.zedGraphControl1.TabIndex = 28;
            this.zedGraphControl1.UseExtendedPrintDialog = true;
            // 
            // clear_button
            // 
            this.clear_button.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.clear_button.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.clear_button.Location = new System.Drawing.Point(12, 210);
            this.clear_button.Name = "clear_button";
            this.clear_button.Size = new System.Drawing.Size(50, 50);
            this.clear_button.TabIndex = 29;
            this.clear_button.Text = "C";
            this.clear_button.UseVisualStyleBackColor = true;
            this.clear_button.Click += new System.EventHandler(this.clear_button_Click);
            // 
            // left_shift_button
            // 
            this.left_shift_button.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.left_shift_button.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.left_shift_button.Location = new System.Drawing.Point(232, 210);
            this.left_shift_button.Name = "left_shift_button";
            this.left_shift_button.Size = new System.Drawing.Size(50, 50);
            this.left_shift_button.TabIndex = 30;
            this.left_shift_button.Text = "π";
            this.left_shift_button.UseVisualStyleBackColor = true;
            this.left_shift_button.Click += new System.EventHandler(this.various_symbols_Click);
            // 
            // right_shift_button
            // 
            this.right_shift_button.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.right_shift_button.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.right_shift_button.Location = new System.Drawing.Point(287, 210);
            this.right_shift_button.Name = "right_shift_button";
            this.right_shift_button.Size = new System.Drawing.Size(50, 50);
            this.right_shift_button.TabIndex = 31;
            this.right_shift_button.Text = "log";
            this.right_shift_button.UseVisualStyleBackColor = true;
            this.right_shift_button.Click += new System.EventHandler(this.various_symbols_Click);
            // 
            // button5
            // 
            this.button5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button5.Location = new System.Drawing.Point(122, 210);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(50, 50);
            this.button5.TabIndex = 33;
            this.button5.Text = "(";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.various_symbols_Click);
            // 
            // button6
            // 
            this.button6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button6.Location = new System.Drawing.Point(177, 210);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(50, 50);
            this.button6.TabIndex = 34;
            this.button6.Text = ")";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.various_symbols_Click);
            // 
            // button7
            // 
            this.button7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button7.Location = new System.Drawing.Point(287, 320);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(50, 50);
            this.button7.TabIndex = 40;
            this.button7.Text = "÷";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.divide_Click);
            // 
            // button8
            // 
            this.button8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button8.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button8.Location = new System.Drawing.Point(232, 265);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(50, 50);
            this.button8.TabIndex = 39;
            this.button8.Text = "9";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.various_symbols_Click);
            // 
            // button9
            // 
            this.button9.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button9.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button9.Location = new System.Drawing.Point(177, 265);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(50, 50);
            this.button9.TabIndex = 38;
            this.button9.Text = "8";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.various_symbols_Click);
            // 
            // button10
            // 
            this.button10.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button10.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button10.Location = new System.Drawing.Point(122, 265);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(50, 50);
            this.button10.TabIndex = 37;
            this.button10.Text = "7";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.various_symbols_Click);
            // 
            // button11
            // 
            this.button11.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button11.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button11.Location = new System.Drawing.Point(67, 265);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(50, 50);
            this.button11.TabIndex = 36;
            this.button11.Text = "e";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.various_symbols_Click);
            // 
            // button12
            // 
            this.button12.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button12.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button12.Location = new System.Drawing.Point(12, 265);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(50, 50);
            this.button12.TabIndex = 35;
            this.button12.Text = "x";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.various_symbols_Click);
            // 
            // button13
            // 
            this.button13.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button13.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button13.Location = new System.Drawing.Point(287, 375);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(50, 50);
            this.button13.TabIndex = 46;
            this.button13.Text = "×";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.multiply_Click);
            // 
            // button14
            // 
            this.button14.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button14.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button14.Location = new System.Drawing.Point(232, 320);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(50, 50);
            this.button14.TabIndex = 45;
            this.button14.Text = "6";
            this.button14.UseVisualStyleBackColor = true;
            this.button14.Click += new System.EventHandler(this.various_symbols_Click);
            // 
            // button15
            // 
            this.button15.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button15.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button15.Location = new System.Drawing.Point(177, 320);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(50, 50);
            this.button15.TabIndex = 44;
            this.button15.Text = "5";
            this.button15.UseVisualStyleBackColor = true;
            this.button15.Click += new System.EventHandler(this.various_symbols_Click);
            // 
            // button16
            // 
            this.button16.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button16.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button16.Location = new System.Drawing.Point(122, 320);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(50, 50);
            this.button16.TabIndex = 43;
            this.button16.Text = "4";
            this.button16.UseVisualStyleBackColor = true;
            this.button16.Click += new System.EventHandler(this.various_symbols_Click);
            // 
            // button17
            // 
            this.button17.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button17.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button17.Location = new System.Drawing.Point(67, 320);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(50, 50);
            this.button17.TabIndex = 42;
            this.button17.Text = "cos";
            this.button17.UseVisualStyleBackColor = true;
            this.button17.Click += new System.EventHandler(this.various_symbols_Click);
            // 
            // button18
            // 
            this.button18.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button18.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button18.Location = new System.Drawing.Point(12, 320);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(50, 50);
            this.button18.TabIndex = 41;
            this.button18.Text = "sin";
            this.button18.UseVisualStyleBackColor = true;
            this.button18.Click += new System.EventHandler(this.various_symbols_Click);
            // 
            // button19
            // 
            this.button19.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button19.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button19.Location = new System.Drawing.Point(287, 430);
            this.button19.Name = "button19";
            this.button19.Size = new System.Drawing.Size(50, 50);
            this.button19.TabIndex = 52;
            this.button19.Text = "-";
            this.button19.UseVisualStyleBackColor = true;
            this.button19.Click += new System.EventHandler(this.various_symbols_Click);
            // 
            // button20
            // 
            this.button20.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button20.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button20.Location = new System.Drawing.Point(232, 375);
            this.button20.Name = "button20";
            this.button20.Size = new System.Drawing.Size(50, 50);
            this.button20.TabIndex = 51;
            this.button20.Text = "3";
            this.button20.UseVisualStyleBackColor = true;
            this.button20.Click += new System.EventHandler(this.various_symbols_Click);
            // 
            // button21
            // 
            this.button21.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button21.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button21.Location = new System.Drawing.Point(177, 375);
            this.button21.Name = "button21";
            this.button21.Size = new System.Drawing.Size(50, 50);
            this.button21.TabIndex = 50;
            this.button21.Text = "2";
            this.button21.UseVisualStyleBackColor = true;
            this.button21.Click += new System.EventHandler(this.various_symbols_Click);
            // 
            // button22
            // 
            this.button22.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button22.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button22.Location = new System.Drawing.Point(122, 375);
            this.button22.Name = "button22";
            this.button22.Size = new System.Drawing.Size(50, 50);
            this.button22.TabIndex = 49;
            this.button22.Text = "1";
            this.button22.UseVisualStyleBackColor = true;
            this.button22.Click += new System.EventHandler(this.various_symbols_Click);
            // 
            // button23
            // 
            this.button23.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button23.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button23.Location = new System.Drawing.Point(67, 375);
            this.button23.Name = "button23";
            this.button23.Size = new System.Drawing.Size(50, 50);
            this.button23.TabIndex = 48;
            this.button23.Text = "cot";
            this.button23.UseVisualStyleBackColor = true;
            this.button23.Click += new System.EventHandler(this.various_symbols_Click);
            // 
            // button24
            // 
            this.button24.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button24.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button24.Location = new System.Drawing.Point(12, 375);
            this.button24.Name = "button24";
            this.button24.Size = new System.Drawing.Size(50, 50);
            this.button24.TabIndex = 47;
            this.button24.Text = "tan";
            this.button24.UseVisualStyleBackColor = true;
            this.button24.Click += new System.EventHandler(this.various_symbols_Click);
            // 
            // button25
            // 
            this.button25.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button25.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button25.Location = new System.Drawing.Point(287, 485);
            this.button25.Name = "button25";
            this.button25.Size = new System.Drawing.Size(50, 50);
            this.button25.TabIndex = 58;
            this.button25.Text = "+";
            this.button25.UseVisualStyleBackColor = true;
            this.button25.Click += new System.EventHandler(this.various_symbols_Click);
            // 
            // button26
            // 
            this.button26.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button26.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button26.Location = new System.Drawing.Point(232, 430);
            this.button26.Name = "button26";
            this.button26.Size = new System.Drawing.Size(50, 50);
            this.button26.TabIndex = 57;
            this.button26.Text = ".";
            this.button26.UseVisualStyleBackColor = true;
            this.button26.Click += new System.EventHandler(this.various_symbols_Click);
            // 
            // button27
            // 
            this.button27.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button27.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button27.Location = new System.Drawing.Point(177, 430);
            this.button27.Name = "button27";
            this.button27.Size = new System.Drawing.Size(50, 50);
            this.button27.TabIndex = 56;
            this.button27.Text = "0";
            this.button27.UseVisualStyleBackColor = true;
            this.button27.Click += new System.EventHandler(this.various_symbols_Click);
            // 
            // button28
            // 
            this.button28.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button28.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button28.Location = new System.Drawing.Point(122, 430);
            this.button28.Name = "button28";
            this.button28.Size = new System.Drawing.Size(50, 50);
            this.button28.TabIndex = 55;
            this.button28.Text = "√";
            this.button28.UseVisualStyleBackColor = true;
            this.button28.Click += new System.EventHandler(this.sqrt_Click);
            // 
            // button29
            // 
            this.button29.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button29.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button29.Location = new System.Drawing.Point(67, 430);
            this.button29.Name = "button29";
            this.button29.Size = new System.Drawing.Size(50, 50);
            this.button29.TabIndex = 54;
            this.button29.Text = "acos";
            this.button29.UseVisualStyleBackColor = true;
            this.button29.Click += new System.EventHandler(this.various_symbols_Click);
            // 
            // button30
            // 
            this.button30.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button30.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button30.Location = new System.Drawing.Point(12, 430);
            this.button30.Name = "button30";
            this.button30.Size = new System.Drawing.Size(50, 50);
            this.button30.TabIndex = 53;
            this.button30.Text = "asin";
            this.button30.UseVisualStyleBackColor = true;
            this.button30.Click += new System.EventHandler(this.various_symbols_Click);
            // 
            // button31
            // 
            this.button31.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button31.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button31.Location = new System.Drawing.Point(287, 265);
            this.button31.Name = "button31";
            this.button31.Size = new System.Drawing.Size(50, 50);
            this.button31.TabIndex = 64;
            this.button31.Text = "ln";
            this.button31.UseVisualStyleBackColor = true;
            this.button31.Click += new System.EventHandler(this.various_symbols_Click);
            // 
            // button35
            // 
            this.button35.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button35.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button35.Location = new System.Drawing.Point(67, 485);
            this.button35.Name = "button35";
            this.button35.Size = new System.Drawing.Size(50, 50);
            this.button35.TabIndex = 60;
            this.button35.Text = "acot";
            this.button35.UseVisualStyleBackColor = true;
            this.button35.Click += new System.EventHandler(this.various_symbols_Click);
            // 
            // button36
            // 
            this.button36.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button36.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button36.Location = new System.Drawing.Point(12, 485);
            this.button36.Name = "button36";
            this.button36.Size = new System.Drawing.Size(50, 50);
            this.button36.TabIndex = 59;
            this.button36.Text = "atan";
            this.button36.UseVisualStyleBackColor = true;
            this.button36.Click += new System.EventHandler(this.various_symbols_Click);
            // 
            // button37
            // 
            this.button37.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button37.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button37.Location = new System.Drawing.Point(94, 547);
            this.button37.Name = "button37";
            this.button37.Size = new System.Drawing.Size(160, 30);
            this.button37.TabIndex = 65;
            this.button37.Text = "Произвести расчеты";
            this.button37.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Location = new System.Drawing.Point(12, 128);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(325, 72);
            this.textBox1.TabIndex = 66;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(962, 24);
            this.menuStrip1.TabIndex = 67;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьToolStripMenuItem,
            this.сохранитьToolStripMenuItem,
            this.сохранитьГрафикToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.открытьToolStripMenuItem.Text = "Открыть";
            this.открытьToolStripMenuItem.Click += new System.EventHandler(this.открытьToolStripMenuItem_Click);
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.сохранитьToolStripMenuItem.Text = "Сохранить";
            this.сохранитьToolStripMenuItem.Click += new System.EventHandler(this.сохранитьToolStripMenuItem_Click);
            // 
            // сохранитьГрафикToolStripMenuItem
            // 
            this.сохранитьГрафикToolStripMenuItem.Name = "сохранитьГрафикToolStripMenuItem";
            this.сохранитьГрафикToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.сохранитьГрафикToolStripMenuItem.Text = "Сохранить график";
            this.сохранитьГрафикToolStripMenuItem.Click += new System.EventHandler(this.сохранитьГрафикToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 589);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(962, 22);
            this.statusStrip1.TabIndex = 68;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(22, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(304, 19);
            this.label4.TabIndex = 69;
            this.label4.Text = "Область поиска локального экстремума:\r\n";
            // 
            // minBorder
            // 
            this.minBorder.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.minBorder.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.minBorder.Location = new System.Drawing.Point(71, 92);
            this.minBorder.Name = "minBorder";
            this.minBorder.Size = new System.Drawing.Size(89, 26);
            this.minBorder.TabIndex = 70;
            // 
            // maxBorder
            // 
            this.maxBorder.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.maxBorder.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.maxBorder.Location = new System.Drawing.Point(248, 92);
            this.maxBorder.Name = "maxBorder";
            this.maxBorder.Size = new System.Drawing.Size(89, 26);
            this.maxBorder.TabIndex = 71;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(12, 92);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 19);
            this.label5.TabIndex = 72;
            this.label5.Text = "Xmin =";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(181, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 19);
            this.label6.TabIndex = 73;
            this.label6.Text = "Xmax =";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            // 
            // button32
            // 
            this.button32.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button32.BackgroundImage = global::coursework.Properties.Resources.степень;
            this.button32.Location = new System.Drawing.Point(232, 485);
            this.button32.Name = "button32";
            this.button32.Size = new System.Drawing.Size(50, 50);
            this.button32.TabIndex = 63;
            this.button32.UseVisualStyleBackColor = true;
            this.button32.Click += new System.EventHandler(this.degree_Click);
            // 
            // button33
            // 
            this.button33.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button33.BackgroundImage = global::coursework.Properties.Resources.степень3_1;
            this.button33.Font = new System.Drawing.Font("Cambria Math", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button33.Location = new System.Drawing.Point(177, 485);
            this.button33.Name = "button33";
            this.button33.Size = new System.Drawing.Size(50, 50);
            this.button33.TabIndex = 62;
            this.button33.UseVisualStyleBackColor = true;
            this.button33.Click += new System.EventHandler(this.cube_Click);
            // 
            // button34
            // 
            this.button34.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button34.BackgroundImage = global::coursework.Properties.Resources.степень21;
            this.button34.Location = new System.Drawing.Point(122, 485);
            this.button34.Name = "button34";
            this.button34.Size = new System.Drawing.Size(50, 50);
            this.button34.TabIndex = 61;
            this.button34.UseVisualStyleBackColor = true;
            this.button34.Click += new System.EventHandler(this.square_Click);
            // 
            // delete_button
            // 
            this.delete_button.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.delete_button.BackgroundImage = global::coursework.Properties.Resources.Без_имени_1;
            this.delete_button.Location = new System.Drawing.Point(67, 210);
            this.delete_button.Name = "delete_button";
            this.delete_button.Size = new System.Drawing.Size(50, 50);
            this.delete_button.TabIndex = 32;
            this.delete_button.UseVisualStyleBackColor = true;
            this.delete_button.Click += new System.EventHandler(this.delete_button_Click);
            // 
            // Сalculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(962, 611);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.maxBorder);
            this.Controls.Add(this.minBorder);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button37);
            this.Controls.Add(this.button31);
            this.Controls.Add(this.button32);
            this.Controls.Add(this.button33);
            this.Controls.Add(this.button34);
            this.Controls.Add(this.button35);
            this.Controls.Add(this.button36);
            this.Controls.Add(this.button25);
            this.Controls.Add(this.button26);
            this.Controls.Add(this.button27);
            this.Controls.Add(this.button28);
            this.Controls.Add(this.button29);
            this.Controls.Add(this.button30);
            this.Controls.Add(this.button19);
            this.Controls.Add(this.button20);
            this.Controls.Add(this.button21);
            this.Controls.Add(this.button22);
            this.Controls.Add(this.button23);
            this.Controls.Add(this.button24);
            this.Controls.Add(this.button13);
            this.Controls.Add(this.button14);
            this.Controls.Add(this.button15);
            this.Controls.Add(this.button16);
            this.Controls.Add(this.button17);
            this.Controls.Add(this.button18);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.delete_button);
            this.Controls.Add(this.right_shift_button);
            this.Controls.Add(this.left_shift_button);
            this.Controls.Add(this.clear_button);
            this.Controls.Add(this.zedGraphControl1);
            this.Controls.Add(this.equation_textBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Сalculator";
            this.Text = "Сalculator";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox equation_textBox;
        private ZedGraph.ZedGraphControl zedGraphControl1;
        private System.Windows.Forms.Button clear_button;
        private System.Windows.Forms.Button left_shift_button;
        private System.Windows.Forms.Button right_shift_button;
        private System.Windows.Forms.Button delete_button;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.Button button16;
        private System.Windows.Forms.Button button17;
        private System.Windows.Forms.Button button18;
        private System.Windows.Forms.Button button19;
        private System.Windows.Forms.Button button20;
        private System.Windows.Forms.Button button21;
        private System.Windows.Forms.Button button22;
        private System.Windows.Forms.Button button23;
        private System.Windows.Forms.Button button24;
        private System.Windows.Forms.Button button25;
        private System.Windows.Forms.Button button26;
        private System.Windows.Forms.Button button27;
        private System.Windows.Forms.Button button28;
        private System.Windows.Forms.Button button29;
        private System.Windows.Forms.Button button30;
        private System.Windows.Forms.Button button31;
        private System.Windows.Forms.Button button32;
        private System.Windows.Forms.Button button33;
        private System.Windows.Forms.Button button34;
        private System.Windows.Forms.Button button35;
        private System.Windows.Forms.Button button36;
        private System.Windows.Forms.Button button37;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьГрафикToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox minBorder;
        private System.Windows.Forms.TextBox maxBorder;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}