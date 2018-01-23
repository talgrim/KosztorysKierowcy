namespace KosztorysKierowcy
{
    partial class MainWindow
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
            this.bBackup = new System.Windows.Forms.Button();
            this.bRestore = new System.Windows.Forms.Button();
            this.cDrivers = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cCars = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cRoutes = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tPetroleum = new System.Windows.Forms.TextBox();
            this.tOut = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bBackup
            // 
            this.bBackup.Location = new System.Drawing.Point(201, 12);
            this.bBackup.Name = "bBackup";
            this.bBackup.Size = new System.Drawing.Size(159, 23);
            this.bBackup.TabIndex = 0;
            this.bBackup.Text = "Backup database";
            this.bBackup.UseVisualStyleBackColor = true;
            this.bBackup.Click += new System.EventHandler(this.bBackup_Click);
            // 
            // bRestore
            // 
            this.bRestore.Location = new System.Drawing.Point(379, 12);
            this.bRestore.Name = "bRestore";
            this.bRestore.Size = new System.Drawing.Size(145, 23);
            this.bRestore.TabIndex = 1;
            this.bRestore.Text = "Restore database";
            this.bRestore.UseVisualStyleBackColor = true;
            this.bRestore.Click += new System.EventHandler(this.bRestore_Click);
            // 
            // cDrivers
            // 
            this.cDrivers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cDrivers.FormattingEnabled = true;
            this.cDrivers.Location = new System.Drawing.Point(22, 146);
            this.cDrivers.Name = "cDrivers";
            this.cDrivers.Size = new System.Drawing.Size(121, 21);
            this.cDrivers.TabIndex = 2;
            this.cDrivers.SelectedIndexChanged += new System.EventHandler(this.cDrivers_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Kierowcy";
            // 
            // cCars
            // 
            this.cCars.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cCars.FormattingEnabled = true;
            this.cCars.Location = new System.Drawing.Point(187, 146);
            this.cCars.Name = "cCars";
            this.cCars.Size = new System.Drawing.Size(121, 21);
            this.cCars.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(219, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Auto";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(400, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Trasa";
            // 
            // cRoutes
            // 
            this.cRoutes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cRoutes.FormattingEnabled = true;
            this.cRoutes.Location = new System.Drawing.Point(314, 146);
            this.cRoutes.Name = "cRoutes";
            this.cRoutes.Size = new System.Drawing.Size(211, 21);
            this.cRoutes.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(50, 219);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Aktualna cena paliwa";
            // 
            // tPetroleum
            // 
            this.tPetroleum.Location = new System.Drawing.Point(53, 235);
            this.tPetroleum.Name = "tPetroleum";
            this.tPetroleum.Size = new System.Drawing.Size(100, 20);
            this.tPetroleum.TabIndex = 9;
            this.tPetroleum.Text = "5,00";
            this.tPetroleum.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tPetroleum_KeyPress);
            // 
            // tOut
            // 
            this.tOut.Location = new System.Drawing.Point(270, 308);
            this.tOut.Name = "tOut";
            this.tOut.ReadOnly = true;
            this.tOut.Size = new System.Drawing.Size(100, 20);
            this.tOut.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(267, 292);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Obliczony koszt trasy";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 399);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tOut);
            this.Controls.Add(this.tPetroleum);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cRoutes);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cCars);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cDrivers);
            this.Controls.Add(this.bRestore);
            this.Controls.Add(this.bBackup);
            this.Name = "MainWindow";
            this.Text = "Kosztorys kierowcy";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bBackup;
        private System.Windows.Forms.Button bRestore;
        private System.Windows.Forms.ComboBox cDrivers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cCars;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cRoutes;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tPetroleum;
        private System.Windows.Forms.TextBox tOut;
        private System.Windows.Forms.Label label5;
    }
}

