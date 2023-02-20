namespace URLConvert
{
    partial class AppForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AppForm));
            this.ConvertButton = new System.Windows.Forms.Button();
            this.WordpressCodeLabel = new System.Windows.Forms.Label();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.DomainTextBox = new System.Windows.Forms.TextBox();
            this.DomainLabel = new System.Windows.Forms.Label();
            this.HeightLabel = new System.Windows.Forms.Label();
            this.WidthLabel = new System.Windows.Forms.Label();
            this.HowToLabel = new System.Windows.Forms.Label();
            this.VideoWidthBox = new System.Windows.Forms.NumericUpDown();
            this.VideoHeightBox = new System.Windows.Forms.NumericUpDown();
            this.CopyLastWPCodeButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.VideoWidthBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VideoHeightBox)).BeginInit();
            this.SuspendLayout();
            // 
            // ConvertButton
            // 
            this.ConvertButton.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ConvertButton.Location = new System.Drawing.Point(11, 59);
            this.ConvertButton.Name = "ConvertButton";
            this.ConvertButton.Size = new System.Drawing.Size(261, 41);
            this.ConvertButton.TabIndex = 3;
            this.ConvertButton.Text = "CONVERT";
            this.ConvertButton.UseVisualStyleBackColor = true;
            this.ConvertButton.Click += new System.EventHandler(this.ConvertButton_Click);
            // 
            // WordpressCodeLabel
            // 
            this.WordpressCodeLabel.Location = new System.Drawing.Point(12, 126);
            this.WordpressCodeLabel.Name = "WordpressCodeLabel";
            this.WordpressCodeLabel.Size = new System.Drawing.Size(325, 109);
            this.WordpressCodeLabel.TabIndex = 4;
            this.WordpressCodeLabel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.WordpressCodeLabel_MouseClick);
            // 
            // StatusLabel
            // 
            this.StatusLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.StatusLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.StatusLabel.ForeColor = System.Drawing.Color.Green;
            this.StatusLabel.Location = new System.Drawing.Point(11, 103);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(326, 23);
            this.StatusLabel.TabIndex = 5;
            this.StatusLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // DomainTextBox
            // 
            this.DomainTextBox.Location = new System.Drawing.Point(12, 30);
            this.DomainTextBox.Name = "DomainTextBox";
            this.DomainTextBox.Size = new System.Drawing.Size(182, 23);
            this.DomainTextBox.TabIndex = 6;
            // 
            // DomainLabel
            // 
            this.DomainLabel.AutoSize = true;
            this.DomainLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DomainLabel.Location = new System.Drawing.Point(8, 8);
            this.DomainLabel.Name = "DomainLabel";
            this.DomainLabel.Size = new System.Drawing.Size(57, 19);
            this.DomainLabel.TabIndex = 9;
            this.DomainLabel.Text = "Domain";
            // 
            // HeightLabel
            // 
            this.HeightLabel.AutoSize = true;
            this.HeightLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.HeightLabel.Location = new System.Drawing.Point(274, 9);
            this.HeightLabel.Name = "HeightLabel";
            this.HeightLabel.Size = new System.Drawing.Size(50, 19);
            this.HeightLabel.TabIndex = 10;
            this.HeightLabel.Text = "Height";
            // 
            // WidthLabel
            // 
            this.WidthLabel.AutoSize = true;
            this.WidthLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.WidthLabel.Location = new System.Drawing.Point(211, 9);
            this.WidthLabel.Name = "WidthLabel";
            this.WidthLabel.Size = new System.Drawing.Size(46, 19);
            this.WidthLabel.TabIndex = 11;
            this.WidthLabel.Text = "Width";
            // 
            // HowToLabel
            // 
            this.HowToLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.HowToLabel.Location = new System.Drawing.Point(11, 126);
            this.HowToLabel.Name = "HowToLabel";
            this.HowToLabel.Size = new System.Drawing.Size(325, 109);
            this.HowToLabel.TabIndex = 12;
            // 
            // VideoWidthBox
            // 
            this.VideoWidthBox.Location = new System.Drawing.Point(213, 30);
            this.VideoWidthBox.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.VideoWidthBox.Name = "VideoWidthBox";
            this.VideoWidthBox.Size = new System.Drawing.Size(59, 23);
            this.VideoWidthBox.TabIndex = 13;
            this.VideoWidthBox.ValueChanged += new System.EventHandler(this.VideoWidthTextBox_TextChanged);
            // 
            // VideoHeightBox
            // 
            this.VideoHeightBox.Location = new System.Drawing.Point(276, 30);
            this.VideoHeightBox.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.VideoHeightBox.Name = "VideoHeightBox";
            this.VideoHeightBox.Size = new System.Drawing.Size(59, 23);
            this.VideoHeightBox.TabIndex = 14;
            this.VideoHeightBox.ValueChanged += new System.EventHandler(this.VideoHeightTextBox_TextChanged);
            // 
            // CopyLastWPCodeButton
            // 
            this.CopyLastWPCodeButton.Enabled = false;
            this.CopyLastWPCodeButton.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CopyLastWPCodeButton.Location = new System.Drawing.Point(274, 59);
            this.CopyLastWPCodeButton.Name = "CopyLastWPCodeButton";
            this.CopyLastWPCodeButton.Size = new System.Drawing.Size(63, 41);
            this.CopyLastWPCodeButton.TabIndex = 15;
            this.CopyLastWPCodeButton.Text = "COPY";
            this.CopyLastWPCodeButton.UseVisualStyleBackColor = true;
            this.CopyLastWPCodeButton.Click += new System.EventHandler(this.CopyLastWPCodeButton_Click);
            // 
            // AppForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 237);
            this.Controls.Add(this.CopyLastWPCodeButton);
            this.Controls.Add(this.VideoHeightBox);
            this.Controls.Add(this.VideoWidthBox);
            this.Controls.Add(this.HowToLabel);
            this.Controls.Add(this.WidthLabel);
            this.Controls.Add(this.HeightLabel);
            this.Controls.Add(this.DomainLabel);
            this.Controls.Add(this.DomainTextBox);
            this.Controls.Add(this.StatusLabel);
            this.Controls.Add(this.WordpressCodeLabel);
            this.Controls.Add(this.ConvertButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AppForm";
            this.Text = "WP Embed TTV Clip";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.VideoWidthBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VideoHeightBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Button ConvertButton;
        private Label WordpressCodeLabel;
        private Label StatusLabel;
        private TextBox DomainTextBox;
        private Label DomainLabel;
        private Label HeightLabel;
        private Label WidthLabel;
        private Label HowToLabel;
        private NumericUpDown VideoWidthBox;
        private NumericUpDown VideoHeightBox;
        private Button CopyLastWPCodeButton;
    }
}