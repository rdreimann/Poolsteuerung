
namespace Poolsteuerung
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btn_off = new System.Windows.Forms.Button();
            this.btn_auto = new System.Windows.Forms.Button();
            this.btn_timer = new System.Windows.Forms.Button();
            this.timer_abfrage = new System.Windows.Forms.Timer(this.components);
            this.timer_1h = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Ausgang = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btn_off
            // 
            this.btn_off.BackColor = System.Drawing.Color.Lime;
            this.btn_off.Location = new System.Drawing.Point(100, 150);
            this.btn_off.Name = "btn_off";
            this.btn_off.Size = new System.Drawing.Size(100, 100);
            this.btn_off.TabIndex = 0;
            this.btn_off.Text = "AUS";
            this.btn_off.UseVisualStyleBackColor = false;
            this.btn_off.Click += new System.EventHandler(this.btn_off_Click);
            // 
            // btn_auto
            // 
            this.btn_auto.BackColor = System.Drawing.Color.Red;
            this.btn_auto.Location = new System.Drawing.Point(300, 150);
            this.btn_auto.Name = "btn_auto";
            this.btn_auto.Size = new System.Drawing.Size(100, 100);
            this.btn_auto.TabIndex = 1;
            this.btn_auto.Text = "AUTO";
            this.btn_auto.UseVisualStyleBackColor = false;
            this.btn_auto.Click += new System.EventHandler(this.btn_auto_Click);
            // 
            // btn_timer
            // 
            this.btn_timer.BackColor = System.Drawing.Color.Red;
            this.btn_timer.Location = new System.Drawing.Point(500, 150);
            this.btn_timer.Name = "btn_timer";
            this.btn_timer.Size = new System.Drawing.Size(100, 100);
            this.btn_timer.TabIndex = 2;
            this.btn_timer.Text = "1h aktivieren";
            this.btn_timer.UseVisualStyleBackColor = false;
            this.btn_timer.Click += new System.EventHandler(this.btn_timer_Click);
            // 
            // timer_abfrage
            // 
            this.timer_abfrage.Enabled = true;
            this.timer_abfrage.Interval = 30000;
            this.timer_abfrage.Tick += new System.EventHandler(this.timer_abfrage_Tick);
            // 
            // timer_1h
            // 
            this.timer_1h.Interval = 1000;
            this.timer_1h.Tick += new System.EventHandler(this.timer_1h_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(125, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(225, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(325, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "label3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(425, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "label4";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(525, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "label5";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(325, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "label6";
            // 
            // Ausgang
            // 
            this.Ausgang.AutoSize = true;
            this.Ausgang.Location = new System.Drawing.Point(319, 270);
            this.Ausgang.Name = "Ausgang";
            this.Ausgang.Size = new System.Drawing.Size(68, 17);
            this.Ausgang.TabIndex = 11;
            this.Ausgang.Text = "Ausgang";
            this.Ausgang.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 362);
            this.Controls.Add(this.Ausgang);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_timer);
            this.Controls.Add(this.btn_auto);
            this.Controls.Add(this.btn_off);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_off;
        private System.Windows.Forms.Button btn_auto;
        private System.Windows.Forms.Button btn_timer;
        private System.Windows.Forms.Timer timer_abfrage;
        private System.Windows.Forms.Timer timer_1h;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox Ausgang;
    }
}

