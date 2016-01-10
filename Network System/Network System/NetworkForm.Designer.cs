namespace Network_System
{
    partial class NetworkForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NetworkForm));
            this.panel4 = new System.Windows.Forms.Panel();
            this.label16 = new System.Windows.Forms.Label();
            this.btnSaveAs = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btSave = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.btnRemove = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnUpdateFlow = new System.Windows.Forms.Button();
            this.tbCurrentFlow = new System.Windows.Forms.TextBox();
            this.tbCapacity = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.gbToolbox = new System.Windows.Forms.GroupBox();
            this.btnMerger = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAdjSplitter = new System.Windows.Forms.Button();
            this.btnSplitter = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSink = new System.Windows.Forms.Button();
            this.btnPump = new System.Windows.Forms.Button();
            this.btnPipe = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitterTrackBar = new System.Windows.Forms.TrackBar();
            this.lblInfo = new System.Windows.Forms.Label();
            this.AdjSplitLb = new System.Windows.Forms.Label();
            this.AdjSplitLb1 = new System.Windows.Forms.Label();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.gbToolbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitterTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label16);
            this.panel4.Controls.Add(this.btnSaveAs);
            this.panel4.Controls.Add(this.label11);
            this.panel4.Controls.Add(this.label10);
            this.panel4.Controls.Add(this.btnLoad);
            this.panel4.Controls.Add(this.btSave);
            this.panel4.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel4.Location = new System.Drawing.Point(1004, 11);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(83, 295);
            this.panel4.TabIndex = 22;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(14, 111);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(51, 16);
            this.label16.TabIndex = 14;
            this.label16.Text = "Save As";
            // 
            // btnSaveAs
            // 
            this.btnSaveAs.BackgroundImage = Properties.Resources.save_as;
            this.btnSaveAs.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSaveAs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveAs.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveAs.Location = new System.Drawing.Point(17, 130);
            this.btnSaveAs.Name = "btnSaveAs";
            this.btnSaveAs.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnSaveAs.Size = new System.Drawing.Size(47, 45);
            this.btnSaveAs.TabIndex = 13;
            this.btnSaveAs.UseVisualStyleBackColor = true;
            this.btnSaveAs.Click += new System.EventHandler(this.btnSaveAs_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(23, 202);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(36, 16);
            this.label11.TabIndex = 12;
            this.label11.Text = "Load";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(23, 15);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(37, 16);
            this.label10.TabIndex = 11;
            this.label10.Text = "Save";
            // 
            // btnLoad
            // 
            this.btnLoad.BackgroundImage = Properties.Resources.load;
            this.btnLoad.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoad.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoad.Location = new System.Drawing.Point(17, 221);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnLoad.Size = new System.Drawing.Size(47, 45);
            this.btnLoad.TabIndex = 10;
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btSave
            // 
            this.btSave.BackgroundImage = Properties.Resources.save;
            this.btSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSave.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSave.Location = new System.Drawing.Point(17, 31);
            this.btSave.Name = "btSave";
            this.btSave.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btSave.Size = new System.Drawing.Size(47, 45);
            this.btSave.TabIndex = 9;
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label13);
            this.panel3.Controls.Add(this.btnRemove);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel3.Location = new System.Drawing.Point(357, 11);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(150, 67);
            this.panel3.TabIndex = 21;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(68, 35);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(72, 16);
            this.label13.TabIndex = 9;
            this.label13.Text = "component";
            // 
            // btnRemove
            // 
            this.btnRemove.BackgroundImage = Properties.Resources.rubbish;
            this.btnRemove.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemove.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemove.Location = new System.Drawing.Point(15, 12);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnRemove.Size = new System.Drawing.Size(47, 45);
            this.btnRemove.TabIndex = 8;
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(68, 17);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 16);
            this.label9.TabIndex = 8;
            this.label9.Text = "Remove";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnUpdateFlow);
            this.panel2.Controls.Add(this.tbCurrentFlow);
            this.panel2.Controls.Add(this.tbCapacity);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(133, 11);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 67);
            this.panel2.TabIndex = 20;
            // 
            // btnUpdateFlow
            // 
            this.btnUpdateFlow.BackgroundImage = Properties.Resources.tick;
            this.btnUpdateFlow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnUpdateFlow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateFlow.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateFlow.Location = new System.Drawing.Point(153, 20);
            this.btnUpdateFlow.Name = "btnUpdateFlow";
            this.btnUpdateFlow.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnUpdateFlow.Size = new System.Drawing.Size(35, 29);
            this.btnUpdateFlow.TabIndex = 11;
            this.btnUpdateFlow.UseVisualStyleBackColor = true;
            this.btnUpdateFlow.Click += new System.EventHandler(this.btnUpdateFlow_Click);
            // 
            // tbCurrentFlow
            // 
            this.tbCurrentFlow.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCurrentFlow.Location = new System.Drawing.Point(92, 8);
            this.tbCurrentFlow.Name = "tbCurrentFlow";
            this.tbCurrentFlow.Size = new System.Drawing.Size(46, 21);
            this.tbCurrentFlow.TabIndex = 5;
            // 
            // tbCapacity
            // 
            this.tbCapacity.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCapacity.Location = new System.Drawing.Point(92, 38);
            this.tbCapacity.Name = "tbCapacity";
            this.tbCapacity.Size = new System.Drawing.Size(46, 21);
            this.tbCapacity.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(13, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 16);
            this.label7.TabIndex = 3;
            this.label7.Text = "Current flow";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(13, 38);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 16);
            this.label8.TabIndex = 4;
            this.label8.Text = "Capacity ";
            // 
            // gbToolbox
            // 
            this.gbToolbox.Controls.Add(this.btnMerger);
            this.gbToolbox.Controls.Add(this.label15);
            this.gbToolbox.Controls.Add(this.label6);
            this.gbToolbox.Controls.Add(this.label5);
            this.gbToolbox.Controls.Add(this.label4);
            this.gbToolbox.Controls.Add(this.label3);
            this.gbToolbox.Controls.Add(this.btnAdjSplitter);
            this.gbToolbox.Controls.Add(this.btnSplitter);
            this.gbToolbox.Controls.Add(this.label2);
            this.gbToolbox.Controls.Add(this.label1);
            this.gbToolbox.Controls.Add(this.btnSink);
            this.gbToolbox.Controls.Add(this.btnPump);
            this.gbToolbox.Controls.Add(this.btnPipe);
            this.gbToolbox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gbToolbox.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbToolbox.Location = new System.Drawing.Point(10, 11);
            this.gbToolbox.Name = "gbToolbox";
            this.gbToolbox.Size = new System.Drawing.Size(97, 499);
            this.gbToolbox.TabIndex = 18;
            this.gbToolbox.TabStop = false;
            this.gbToolbox.Text = "ToolBox";
            // 
            // btnMerger
            // 
            this.btnMerger.BackgroundImage = Properties.Resources.merger;
            this.btnMerger.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMerger.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMerger.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMerger.Location = new System.Drawing.Point(16, 433);
            this.btnMerger.Name = "btnMerger";
            this.btnMerger.Size = new System.Drawing.Size(47, 45);
            this.btnMerger.TabIndex = 9;
            this.btnMerger.UseVisualStyleBackColor = true;
            this.btnMerger.Click += new System.EventHandler(this.btnMerger_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(17, 336);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(42, 16);
            this.label15.TabIndex = 8;
            this.label15.Text = "splitter";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(13, 414);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 16);
            this.label6.TabIndex = 7;
            this.label6.Text = "Merger";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 320);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 16);
            this.label5.TabIndex = 6;
            this.label5.Text = "Adjustable \r\n";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 247);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Splitter";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 173);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Sink";
            // 
            // btnAdjSplitter
            // 
            this.btnAdjSplitter.BackgroundImage = Properties.Resources.adjustable_splitter;
            this.btnAdjSplitter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAdjSplitter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdjSplitter.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdjSplitter.Location = new System.Drawing.Point(16, 355);
            this.btnAdjSplitter.Name = "btnAdjSplitter";
            this.btnAdjSplitter.Size = new System.Drawing.Size(47, 45);
            this.btnAdjSplitter.TabIndex = 4;
            this.btnAdjSplitter.UseVisualStyleBackColor = true;
            this.btnAdjSplitter.Click += new System.EventHandler(this.btnAdjSplitter_Click);
            // 
            // btnSplitter
            // 
            this.btnSplitter.BackgroundImage = Properties.Resources.splitter;
            this.btnSplitter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSplitter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSplitter.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSplitter.Location = new System.Drawing.Point(16, 263);
            this.btnSplitter.Name = "btnSplitter";
            this.btnSplitter.Size = new System.Drawing.Size(47, 45);
            this.btnSplitter.TabIndex = 2;
            this.btnSplitter.UseVisualStyleBackColor = true;
            this.btnSplitter.Click += new System.EventHandler(this.btnSplitter_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Pump";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Pipe";
            // 
            // btnSink
            // 
            this.btnSink.BackgroundImage = Properties.Resources.sink;
            this.btnSink.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSink.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSink.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSink.Location = new System.Drawing.Point(16, 189);
            this.btnSink.Name = "btnSink";
            this.btnSink.Size = new System.Drawing.Size(47, 45);
            this.btnSink.TabIndex = 3;
            this.btnSink.UseVisualStyleBackColor = true;
            this.btnSink.Click += new System.EventHandler(this.btnSink_Click);
            // 
            // btnPump
            // 
            this.btnPump.BackgroundImage = Properties.Resources.pump;
            this.btnPump.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPump.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPump.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPump.Location = new System.Drawing.Point(16, 117);
            this.btnPump.Name = "btnPump";
            this.btnPump.Size = new System.Drawing.Size(47, 45);
            this.btnPump.TabIndex = 2;
            this.btnPump.UseVisualStyleBackColor = true;
            this.btnPump.Click += new System.EventHandler(this.btnPump_Click);
            // 
            // btnPipe
            // 
            this.btnPipe.BackgroundImage = Properties.Resources.pipeline1;
            this.btnPipe.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPipe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPipe.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPipe.Location = new System.Drawing.Point(16, 44);
            this.btnPipe.Name = "btnPipe";
            this.btnPipe.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnPipe.Size = new System.Drawing.Size(47, 45);
            this.btnPipe.TabIndex = 1;
            this.btnPipe.UseVisualStyleBackColor = true;
            this.btnPipe.Click += new System.EventHandler(this.btnPipe_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(121, 86);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(876, 511);
            this.panel1.TabIndex = 23;
            this.panel1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseClick);
            this.panel1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDoubleClick);
            // 
            // splitterTrackBar
            // 
            this.splitterTrackBar.Location = new System.Drawing.Point(654, -4);
            this.splitterTrackBar.Maximum = 100;
            this.splitterTrackBar.Name = "splitterTrackBar";
            this.splitterTrackBar.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.splitterTrackBar.Size = new System.Drawing.Size(45, 82);
            this.splitterTrackBar.SmallChange = 10;
            this.splitterTrackBar.TabIndex = 24;
            this.splitterTrackBar.TickFrequency = 10;
            this.splitterTrackBar.Value = 1;
            this.splitterTrackBar.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblInfo.Location = new System.Drawing.Point(781, 28);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(0, 13);
            this.lblInfo.TabIndex = 25;
            // 
            // AdjSplitLb
            // 
            this.AdjSplitLb.AutoSize = true;
            this.AdjSplitLb.Location = new System.Drawing.Point(592, 11);
            this.AdjSplitLb.Name = "AdjSplitLb";
            this.AdjSplitLb.Size = new System.Drawing.Size(56, 13);
            this.AdjSplitLb.TabIndex = 26;
            this.AdjSplitLb.Text = "Adjustable";
            // 
            // AdjSplitLb1
            // 
            this.AdjSplitLb1.AutoSize = true;
            this.AdjSplitLb1.Location = new System.Drawing.Point(592, 28);
            this.AdjSplitLb1.Name = "AdjSplitLb1";
            this.AdjSplitLb1.Size = new System.Drawing.Size(39, 13);
            this.AdjSplitLb1.TabIndex = 27;
            this.AdjSplitLb1.Text = "Splitter";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1088, 609);
            this.Controls.Add(this.AdjSplitLb1);
            this.Controls.Add(this.AdjSplitLb);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.splitterTrackBar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.gbToolbox);
            this.Icon = Properties.Resources.favicon;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Network Form";
            this.Text = "Canvas";
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.gbToolbox.ResumeLayout(false);
            this.gbToolbox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitterTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label16;
        public System.Windows.Forms.Button btnSaveAs;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        public System.Windows.Forms.Button btnLoad;
        public System.Windows.Forms.Button btSave;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label13;
        public System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Button btnUpdateFlow;
        private System.Windows.Forms.TextBox tbCurrentFlow;
        private System.Windows.Forms.TextBox tbCapacity;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox gbToolbox;
        private System.Windows.Forms.Button btnMerger;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAdjSplitter;
        private System.Windows.Forms.Button btnSplitter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSink;
        private System.Windows.Forms.Button btnPump;
        public System.Windows.Forms.Button btnPipe;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TrackBar splitterTrackBar;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Label AdjSplitLb;
        private System.Windows.Forms.Label AdjSplitLb1;
    }
}