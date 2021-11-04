namespace Damajatek
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
            this.nev1TBX = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.startBTN = new System.Windows.Forms.Button();
            this.keszitokBTN = new System.Windows.Forms.Button();
            this.leirasBTN = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // nev1TBX
            // 
            this.nev1TBX.Location = new System.Drawing.Point(659, 159);
            this.nev1TBX.Name = "nev1TBX";
            this.nev1TBX.Size = new System.Drawing.Size(100, 20);
            this.nev1TBX.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(659, 94);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(584, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Első név:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(571, 159);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Második név:";
            // 
            // startBTN
            // 
            this.startBTN.Location = new System.Drawing.Point(684, 38);
            this.startBTN.Name = "startBTN";
            this.startBTN.Size = new System.Drawing.Size(75, 23);
            this.startBTN.TabIndex = 4;
            this.startBTN.Text = "Start";
            this.startBTN.UseVisualStyleBackColor = true;
            this.startBTN.Click += new System.EventHandler(this.startBTN_Click);
            // 
            // keszitokBTN
            // 
            this.keszitokBTN.Location = new System.Drawing.Point(684, 227);
            this.keszitokBTN.Name = "keszitokBTN";
            this.keszitokBTN.Size = new System.Drawing.Size(75, 23);
            this.keszitokBTN.TabIndex = 5;
            this.keszitokBTN.Text = "Készítők";
            this.keszitokBTN.UseVisualStyleBackColor = true;
            // 
            // leirasBTN
            // 
            this.leirasBTN.Location = new System.Drawing.Point(684, 290);
            this.leirasBTN.Name = "leirasBTN";
            this.leirasBTN.Size = new System.Drawing.Size(75, 23);
            this.leirasBTN.TabIndex = 5;
            this.leirasBTN.Text = "Leírás";
            this.leirasBTN.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.leirasBTN);
            this.Controls.Add(this.keszitokBTN);
            this.Controls.Add(this.startBTN);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.nev1TBX);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox nev1TBX;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button startBTN;
        private System.Windows.Forms.Button keszitokBTN;
        private System.Windows.Forms.Button leirasBTN;
    }
}

