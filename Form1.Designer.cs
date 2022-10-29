namespace Simulation
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
            this.components = new System.ComponentModel.Container();
            this.controll = new System.Windows.Forms.Panel();
            this.Time_interval = new System.Windows.Forms.NumericUpDown();
            this.Absorbsion = new System.Windows.Forms.TrackBar();
            this.Speed = new System.Windows.Forms.NumericUpDown();
            this.Border_loop = new System.Windows.Forms.RadioButton();
            this.Border_solid = new System.Windows.Forms.RadioButton();
            this.Border_none = new System.Windows.Forms.RadioButton();
            this.Particle_grav = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Force_field = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.G_rad = new System.Windows.Forms.RadioButton();
            this.G_vert = new System.Windows.Forms.RadioButton();
            this.G_none = new System.Windows.Forms.RadioButton();
            this.reset = new System.Windows.Forms.Button();
            this.pause = new System.Windows.Forms.Button();
            this.start = new System.Windows.Forms.Button();
            this.Base = new System.Windows.Forms.Panel();
            this.timer_render = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.Mass_setter = new System.Windows.Forms.TrackBar();
            this.Add = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.controll.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Time_interval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Absorbsion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Speed)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Mass_setter)).BeginInit();
            this.SuspendLayout();
            // 
            // controll
            // 
            this.controll.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.controll.Controls.Add(this.Time_interval);
            this.controll.Controls.Add(this.Absorbsion);
            this.controll.Controls.Add(this.Speed);
            this.controll.Controls.Add(this.Border_loop);
            this.controll.Controls.Add(this.Border_solid);
            this.controll.Controls.Add(this.Border_none);
            this.controll.Controls.Add(this.Particle_grav);
            this.controll.Controls.Add(this.label2);
            this.controll.Controls.Add(this.Force_field);
            this.controll.Controls.Add(this.label1);
            this.controll.Location = new System.Drawing.Point(0, 0);
            this.controll.Name = "controll";
            this.controll.Size = new System.Drawing.Size(952, 147);
            this.controll.TabIndex = 0;
            this.controll.Paint += new System.Windows.Forms.PaintEventHandler(this.controll_Paint);
            // 
            // Time_interval
            // 
            this.Time_interval.Location = new System.Drawing.Point(505, 81);
            this.Time_interval.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.Time_interval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Time_interval.Name = "Time_interval";
            this.Time_interval.Size = new System.Drawing.Size(118, 35);
            this.Time_interval.TabIndex = 16;
            this.Time_interval.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.Time_interval.ValueChanged += new System.EventHandler(this.Time_interval_ValueChanged);
            // 
            // Absorbsion
            // 
            this.Absorbsion.AutoSize = false;
            this.Absorbsion.Location = new System.Drawing.Point(104, 45);
            this.Absorbsion.Maximum = 100;
            this.Absorbsion.Name = "Absorbsion";
            this.Absorbsion.Size = new System.Drawing.Size(148, 33);
            this.Absorbsion.SmallChange = 2;
            this.Absorbsion.TabIndex = 15;
            this.Absorbsion.TickFrequency = 10;
            this.Absorbsion.Value = 10;
            this.Absorbsion.Scroll += new System.EventHandler(this.Absorbsion_Scroll);
            // 
            // Speed
            // 
            this.Speed.DecimalPlaces = 1;
            this.Speed.Increment = new decimal(new int[] {
            2,
            0,
            0,
            65536});
            this.Speed.Location = new System.Drawing.Point(505, 11);
            this.Speed.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            this.Speed.Name = "Speed";
            this.Speed.Size = new System.Drawing.Size(118, 35);
            this.Speed.TabIndex = 14;
            this.Speed.ValueChanged += new System.EventHandler(this.Speed_ValueChanged);
            // 
            // Border_loop
            // 
            this.Border_loop.AutoSize = true;
            this.Border_loop.Location = new System.Drawing.Point(7, 78);
            this.Border_loop.Name = "Border_loop";
            this.Border_loop.Size = new System.Drawing.Size(99, 33);
            this.Border_loop.TabIndex = 13;
            this.Border_loop.Text = "Loop";
            this.Border_loop.UseVisualStyleBackColor = true;
            this.Border_loop.CheckedChanged += new System.EventHandler(this.Border_loop_CheckedChanged);
            // 
            // Border_solid
            // 
            this.Border_solid.AutoSize = true;
            this.Border_solid.Checked = true;
            this.Border_solid.Location = new System.Drawing.Point(7, 43);
            this.Border_solid.Name = "Border_solid";
            this.Border_solid.Size = new System.Drawing.Size(100, 33);
            this.Border_solid.TabIndex = 12;
            this.Border_solid.TabStop = true;
            this.Border_solid.Text = "Solid";
            this.Border_solid.UseVisualStyleBackColor = true;
            this.Border_solid.CheckedChanged += new System.EventHandler(this.Border_solid_CheckedChanged);
            // 
            // Border_none
            // 
            this.Border_none.AutoSize = true;
            this.Border_none.Location = new System.Drawing.Point(7, 8);
            this.Border_none.Name = "Border_none";
            this.Border_none.Size = new System.Drawing.Size(103, 33);
            this.Border_none.TabIndex = 11;
            this.Border_none.Text = "None";
            this.Border_none.UseVisualStyleBackColor = true;
            this.Border_none.CheckedChanged += new System.EventHandler(this.Border_none_CheckedChanged);
            // 
            // Particle_grav
            // 
            this.Particle_grav.AutoSize = true;
            this.Particle_grav.Checked = true;
            this.Particle_grav.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Particle_grav.Location = new System.Drawing.Point(656, 15);
            this.Particle_grav.Name = "Particle_grav";
            this.Particle_grav.Size = new System.Drawing.Size(281, 33);
            this.Particle_grav.TabIndex = 10;
            this.Particle_grav.Text = "Enable particle gravity";
            this.Particle_grav.UseVisualStyleBackColor = true;
            this.Particle_grav.CheckedChanged += new System.EventHandler(this.particle_grav_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Gainsboro;
            this.label2.Location = new System.Drawing.Point(267, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 58);
            this.label2.TabIndex = 9;
            this.label2.Text = "Speed:\r\n1";
            // 
            // Force_field
            // 
            this.Force_field.AutoSize = true;
            this.Force_field.Location = new System.Drawing.Point(656, 63);
            this.Force_field.Name = "Force_field";
            this.Force_field.Size = new System.Drawing.Size(218, 33);
            this.Force_field.TabIndex = 7;
            this.Force_field.Text = "Show force field";
            this.Force_field.UseVisualStyleBackColor = true;
            this.Force_field.CheckedChanged += new System.EventHandler(this.Force_field_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Gainsboro;
            this.label1.Location = new System.Drawing.Point(266, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 29);
            this.label1.TabIndex = 5;
            this.label1.Text = "Time Interval:";
            // 
            // G_rad
            // 
            this.G_rad.AutoSize = true;
            this.G_rad.Location = new System.Drawing.Point(9, 80);
            this.G_rad.Name = "G_rad";
            this.G_rad.Size = new System.Drawing.Size(113, 33);
            this.G_rad.TabIndex = 19;
            this.G_rad.Text = "Radial";
            this.G_rad.UseVisualStyleBackColor = true;
            this.G_rad.CheckedChanged += new System.EventHandler(this.G_rad_CheckedChanged);
            // 
            // G_vert
            // 
            this.G_vert.AutoSize = true;
            this.G_vert.Checked = true;
            this.G_vert.Location = new System.Drawing.Point(9, 45);
            this.G_vert.Name = "G_vert";
            this.G_vert.Size = new System.Drawing.Size(124, 33);
            this.G_vert.TabIndex = 18;
            this.G_vert.TabStop = true;
            this.G_vert.Text = "Vertical";
            this.G_vert.UseVisualStyleBackColor = true;
            this.G_vert.CheckedChanged += new System.EventHandler(this.G_vert_CheckedChanged);
            // 
            // G_none
            // 
            this.G_none.AutoSize = true;
            this.G_none.Location = new System.Drawing.Point(9, 10);
            this.G_none.Name = "G_none";
            this.G_none.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.G_none.Size = new System.Drawing.Size(103, 33);
            this.G_none.TabIndex = 17;
            this.G_none.Text = "None";
            this.G_none.UseVisualStyleBackColor = true;
            this.G_none.CheckedChanged += new System.EventHandler(this.G_none_CheckedChanged);
            // 
            // reset
            // 
            this.reset.Location = new System.Drawing.Point(345, 12);
            this.reset.Name = "reset";
            this.reset.Size = new System.Drawing.Size(160, 45);
            this.reset.TabIndex = 6;
            this.reset.Text = "Reset";
            this.reset.UseVisualStyleBackColor = true;
            this.reset.Click += new System.EventHandler(this.reset_Click);
            // 
            // pause
            // 
            this.pause.Location = new System.Drawing.Point(173, 13);
            this.pause.Name = "pause";
            this.pause.Size = new System.Drawing.Size(160, 45);
            this.pause.TabIndex = 1;
            this.pause.Text = "Pause";
            this.pause.UseVisualStyleBackColor = true;
            this.pause.Click += new System.EventHandler(this.pause_Click);
            // 
            // start
            // 
            this.start.Location = new System.Drawing.Point(173, 64);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(160, 45);
            this.start.TabIndex = 0;
            this.start.Text = "Start";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // Base
            // 
            this.Base.AutoSize = true;
            this.Base.BackColor = System.Drawing.Color.Transparent;
            this.Base.Location = new System.Drawing.Point(0, 129);
            this.Base.Name = "Base";
            this.Base.Size = new System.Drawing.Size(1651, 1272);
            this.Base.TabIndex = 1;
            this.Base.Paint += new System.Windows.Forms.PaintEventHandler(this.Base_Paint);
            // 
            // timer_render
            // 
            this.timer_render.Interval = 500;
            this.timer_render.Tick += new System.EventHandler(this.timer_render_Tick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.Add);
            this.panel1.Controls.Add(this.Mass_setter);
            this.panel1.Controls.Add(this.start);
            this.panel1.Controls.Add(this.G_rad);
            this.panel1.Controls.Add(this.pause);
            this.panel1.Controls.Add(this.G_vert);
            this.panel1.Controls.Add(this.reset);
            this.panel1.Controls.Add(this.G_none);
            this.panel1.Location = new System.Drawing.Point(949, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(710, 147);
            this.panel1.TabIndex = 20;
            // 
            // Mass_setter
            // 
            this.Mass_setter.AutoSize = false;
            this.Mass_setter.LargeChange = 10;
            this.Mass_setter.Location = new System.Drawing.Point(465, 72);
            this.Mass_setter.Maximum = 3500;
            this.Mass_setter.Name = "Mass_setter";
            this.Mass_setter.Size = new System.Drawing.Size(228, 37);
            this.Mass_setter.TabIndex = 20;
            this.Mass_setter.TickFrequency = 100;
            this.Mass_setter.Value = 3;
            this.Mass_setter.Scroll += new System.EventHandler(this.Mass_setter_Scroll);
            // 
            // Add
            // 
            this.Add.Location = new System.Drawing.Point(513, 13);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(160, 45);
            this.Add.TabIndex = 21;
            this.Add.Text = "Add";
            this.Add.UseVisualStyleBackColor = true;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(362, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 58);
            this.label3.TabIndex = 22;
            this.label3.Text = "Mass:\r\n19.90";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1649, 1401);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.controll);
            this.Controls.Add(this.Base);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Simulation";
            this.controll.ResumeLayout(false);
            this.controll.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Time_interval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Absorbsion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Speed)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Mass_setter)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel controll;
        private System.Windows.Forms.Button pause;
        private System.Windows.Forms.Button start;
        private System.Windows.Forms.Panel Base;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer_render;
        private System.Windows.Forms.Button reset;
        private System.Windows.Forms.CheckBox Force_field;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox Particle_grav;
        private System.Windows.Forms.NumericUpDown Speed;
        private System.Windows.Forms.RadioButton Border_loop;
        private System.Windows.Forms.RadioButton Border_solid;
        private System.Windows.Forms.RadioButton Border_none;
        private System.Windows.Forms.TrackBar Absorbsion;
        private System.Windows.Forms.NumericUpDown Time_interval;
        private System.Windows.Forms.RadioButton G_rad;
        private System.Windows.Forms.RadioButton G_vert;
        private System.Windows.Forms.RadioButton G_none;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.TrackBar Mass_setter;
    }
}

