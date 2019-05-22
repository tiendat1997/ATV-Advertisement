namespace ATV_Advertisement.Forms
{
    partial class AdvertisementForm
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
            this.btnGetAds1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGetAds1
            // 
            this.btnGetAds1.Location = new System.Drawing.Point(289, 130);
            this.btnGetAds1.Name = "btnGetAds1";
            this.btnGetAds1.Size = new System.Drawing.Size(75, 23);
            this.btnGetAds1.TabIndex = 0;
            this.btnGetAds1.Text = "GetAdvertisment1";
            this.btnGetAds1.UseVisualStyleBackColor = true;
            this.btnGetAds1.Click += new System.EventHandler(this.btnGetAds1_Click);
            // 
            // AdvertisementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnGetAds1);
            this.Name = "AdvertisementForm";
            this.Text = "AdvertisementForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGetAds1;
    }
}