namespace MaxNetworkPathFindingAlgorithm
{
    partial class FormVertexDialog
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
            this.button = new System.Windows.Forms.Button();
            this.textBoxVertexNumber = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button
            // 
            this.button.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button.Location = new System.Drawing.Point(30, 93);
            this.button.Name = "button";
            this.button.Size = new System.Drawing.Size(149, 35);
            this.button.TabIndex = 4;
            this.button.Text = "OK";
            this.button.UseVisualStyleBackColor = true;
            // 
            // textBoxVertexNumber
            // 
            this.textBoxVertexNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxVertexNumber.Location = new System.Drawing.Point(6, 23);
            this.textBoxVertexNumber.Name = "textBoxVertexNumber";
            this.textBoxVertexNumber.Size = new System.Drawing.Size(172, 29);
            this.textBoxVertexNumber.TabIndex = 0;
            this.textBoxVertexNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxVertexNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxVertexNumber_KeyPress);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxVertexNumber);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(184, 65);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Номер вершины";
            // 
            // FormVertexDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(208, 140);
            this.Controls.Add(this.button);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormVertexDialog";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button;
        public System.Windows.Forms.TextBox textBoxVertexNumber;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}