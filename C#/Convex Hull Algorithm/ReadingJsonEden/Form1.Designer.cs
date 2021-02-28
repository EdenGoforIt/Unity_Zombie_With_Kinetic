namespace ReadingJsonEden
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
            this.gMapController = new GMap.NET.WindowsForms.GMapControl();
            this.buttonConvex = new System.Windows.Forms.Button();
            this.buttonEncircle = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.buttonClear = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // gMapController
            // 
            this.gMapController.Bearing = 0F;
            this.gMapController.CanDragMap = true;
            this.gMapController.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMapController.GrayScaleMode = false;
            this.gMapController.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMapController.LevelsKeepInMemmory = 5;
            this.gMapController.Location = new System.Drawing.Point(12, 12);
            this.gMapController.MarkersEnabled = true;
            this.gMapController.MaxZoom = 18;
            this.gMapController.MinZoom = 2;
            this.gMapController.MouseWheelZoomEnabled = true;
            this.gMapController.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gMapController.Name = "gMapController";
            this.gMapController.NegativeMode = false;
            this.gMapController.PolygonsEnabled = true;
            this.gMapController.RetryLoadTile = 0;
            this.gMapController.RoutesEnabled = true;
            this.gMapController.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gMapController.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gMapController.ShowTileGridLines = false;
            this.gMapController.Size = new System.Drawing.Size(824, 608);
            this.gMapController.TabIndex = 0;
            this.gMapController.Zoom = 10D;
            this.gMapController.OnMarkerClick += new GMap.NET.WindowsForms.MarkerClick(this.GMapController_OnMarkerClick);
            this.gMapController.Load += new System.EventHandler(this.GMapController_Load);
            // 
            // buttonConvex
            // 
            this.buttonConvex.BackColor = System.Drawing.SystemColors.Highlight;
            this.buttonConvex.Font = new System.Drawing.Font("Impact", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonConvex.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonConvex.Location = new System.Drawing.Point(856, 13);
            this.buttonConvex.Name = "buttonConvex";
            this.buttonConvex.Size = new System.Drawing.Size(264, 115);
            this.buttonConvex.TabIndex = 1;
            this.buttonConvex.Text = "Convex Hull";
            this.buttonConvex.UseVisualStyleBackColor = false;
            this.buttonConvex.Click += new System.EventHandler(this.ButtonConvex_Click);
            // 
            // buttonEncircle
            // 
            this.buttonEncircle.BackColor = System.Drawing.SystemColors.Highlight;
            this.buttonEncircle.Font = new System.Drawing.Font("Impact", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEncircle.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonEncircle.Location = new System.Drawing.Point(856, 147);
            this.buttonEncircle.Name = "buttonEncircle";
            this.buttonEncircle.Size = new System.Drawing.Size(264, 115);
            this.buttonEncircle.TabIndex = 2;
            this.buttonEncircle.Text = "Encircle";
            this.buttonEncircle.UseVisualStyleBackColor = false;
            this.buttonEncircle.Click += new System.EventHandler(this.ButtonEncircle_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(870, 439);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(236, 195);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            // 
            // buttonClear
            // 
            this.buttonClear.BackColor = System.Drawing.SystemColors.Highlight;
            this.buttonClear.Font = new System.Drawing.Font("Impact", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClear.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonClear.Location = new System.Drawing.Point(856, 289);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(264, 115);
            this.buttonClear.TabIndex = 4;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = false;
            this.buttonClear.Click += new System.EventHandler(this.ButtonClear_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(12, 666);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(1094, 34);
            this.textBox1.TabIndex = 5;
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(12, 706);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(1094, 34);
            this.textBox2.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1142, 747);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.buttonEncircle);
            this.Controls.Add(this.buttonConvex);
            this.Controls.Add(this.gMapController);
            this.Name = "Form1";
            this.Text = "Find ConvexHull and Smallest Enclosing Circle";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GMap.NET.WindowsForms.GMapControl gMapController;
        private System.Windows.Forms.Button buttonConvex;
        private System.Windows.Forms.Button buttonEncircle;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
    }
}

