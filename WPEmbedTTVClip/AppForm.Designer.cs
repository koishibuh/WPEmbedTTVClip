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
            this.VideoHeightTextBox = new System.Windows.Forms.TextBox();
            this.VideoWidthTextBox = new System.Windows.Forms.TextBox();
            this.DomainLabel = new System.Windows.Forms.Label();
            this.HeightLabel = new System.Windows.Forms.Label();
            this.WidthLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            //
            // ConvertButton
            //
            this.ConvertButton.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ConvertButton.Location = new System.Drawing.Point(11, 59);
            this.ConvertButton.Name = "ConvertButton";
            this.ConvertButton.Size = new System.Drawing.Size(326, 41);
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
            this.WordpressCodeLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            //
            // StatusLabel
            //
            this.StatusLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.StatusLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.StatusLabel.Location = new System.Drawing.Point(11, 103);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(326, 23);
            this.StatusLabel.TabIndex = 5;
            this.StatusLabel.Text = "Ready To Convert Clipboard Link";
            this.StatusLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            //
            // DomainTextBox
            //
            this.DomainTextBox.Location = new System.Drawing.Point(35, 30);
            this.DomainTextBox.Name = "DomainTextBox";
            this.DomainTextBox.Size = new System.Drawing.Size(131, 23);
            this.DomainTextBox.TabIndex = 6;
            //
            // VideoHeightTextBox
            //
            this.VideoHeightTextBox.Location = new System.Drawing.Point(263, 30);
            this.VideoHeightTextBox.Name = "VideoHeightTextBox";
            this.VideoHeightTextBox.Size = new System.Drawing.Size(54, 23);
            this.VideoHeightTextBox.TabIndex = 7;
            this.VideoHeightTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.VideoDimensionTextBox_KeyPress);
            //
            // VideoWidthTextBox
            //
            this.VideoWidthTextBox.Location = new System.Drawing.Point(200, 30);
            this.VideoWidthTextBox.Name = "VideoWidthTextBox";
            this.VideoWidthTextBox.Size = new System.Drawing.Size(54, 23);
            this.VideoWidthTextBox.TabIndex = 8;
            this.VideoWidthTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.VideoDimensionTextBox_KeyPress);
            //
            // DomainLabel
            //
            this.DomainLabel.AutoSize = true;
            this.DomainLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DomainLabel.Location = new System.Drawing.Point(73, 8);
            this.DomainLabel.Name = "DomainLabel";
            this.DomainLabel.Size = new System.Drawing.Size(57, 19);
            this.DomainLabel.TabIndex = 9;
            this.DomainLabel.Text = "Domain";
            //
            // HeightLabel
            //
            this.HeightLabel.AutoSize = true;
            this.HeightLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.HeightLabel.Location = new System.Drawing.Point(265, 9);
            this.HeightLabel.Name = "HeightLabel";
            this.HeightLabel.Size = new System.Drawing.Size(50, 19);
            this.HeightLabel.TabIndex = 10;
            this.HeightLabel.Text = "Height";
            //
            // WidthLabel
            //
            this.WidthLabel.AutoSize = true;
            this.WidthLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.WidthLabel.Location = new System.Drawing.Point(204, 9);
            this.WidthLabel.Name = "WidthLabel";
            this.WidthLabel.Size = new System.Drawing.Size(46, 19);
            this.WidthLabel.TabIndex = 11;
            this.WidthLabel.Text = "Width";
            //
            // AppForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 237);
            this.Controls.Add(this.WidthLabel);
            this.Controls.Add(this.HeightLabel);
            this.Controls.Add(this.DomainLabel);
            this.Controls.Add(this.VideoWidthTextBox);
            this.Controls.Add(this.VideoHeightTextBox);
            this.Controls.Add(this.DomainTextBox);
            this.Controls.Add(this.StatusLabel);
            this.Controls.Add(this.WordpressCodeLabel);
            this.Controls.Add(this.ConvertButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "AppForm";
            this.Text = "WP Embed TTV Clip";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Button ConvertButton;
        private Label WordpressCodeLabel;
        private Label StatusLabel;
        private TextBox DomainTextBox;
        private TextBox VideoHeightTextBox;
        private TextBox VideoWidthTextBox;
        private Label DomainLabel;
        private Label HeightLabel;
        private Label WidthLabel;
    }
}
