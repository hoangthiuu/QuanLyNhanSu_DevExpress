
namespace QLNS
{
    partial class frmBackUp
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
            this.btnBrowserBackUp = new System.Windows.Forms.Button();
            this.btnBackUp = new System.Windows.Forms.Button();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.SuspendLayout();
            // 
            // btnBrowserBackUp
            // 
            this.btnBrowserBackUp.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnBrowserBackUp.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.btnBrowserBackUp.Location = new System.Drawing.Point(615, 172);
            this.btnBrowserBackUp.Name = "btnBrowserBackUp";
            this.btnBrowserBackUp.Size = new System.Drawing.Size(97, 31);
            this.btnBrowserBackUp.TabIndex = 1;
            this.btnBrowserBackUp.Text = "Browser";
            this.btnBrowserBackUp.UseVisualStyleBackColor = true;
            this.btnBrowserBackUp.Click += new System.EventHandler(this.btnBrowserBackUp_Click);
            // 
            // btnBackUp
            // 
            this.btnBackUp.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnBackUp.ForeColor = System.Drawing.Color.Crimson;
            this.btnBackUp.Location = new System.Drawing.Point(615, 219);
            this.btnBackUp.Name = "btnBackUp";
            this.btnBackUp.Size = new System.Drawing.Size(97, 31);
            this.btnBackUp.TabIndex = 2;
            this.btnBackUp.Text = "BackUp";
            this.btnBackUp.UseVisualStyleBackColor = true;
            this.btnBackUp.Click += new System.EventHandler(this.btnBackUp_Click);
            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(394, 134);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(318, 23);
            this.txtLocation.TabIndex = 3;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(404, 42);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(249, 37);
            this.labelControl1.TabIndex = 5;
            this.labelControl1.Text = "BackUp Database";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(394, 106);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(61, 19);
            this.labelControl2.TabIndex = 6;
            this.labelControl2.Text = "Location";
            // 
            // frmBackUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayoutStore = System.Windows.Forms.ImageLayout.Stretch;
            this.BackgroundImageStore = global::QLNS.Properties.Resources.Loginform;
            this.ClientSize = new System.Drawing.Size(744, 392);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txtLocation);
            this.Controls.Add(this.btnBackUp);
            this.Controls.Add(this.btnBrowserBackUp);
            this.DoubleBuffered = true;
            this.Name = "frmBackUp";
            this.Text = "BackUp dữ liệu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnBrowserBackUp;
        private System.Windows.Forms.Button btnBackUp;
        private System.Windows.Forms.TextBox txtLocation;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
    }
}