namespace MaxNetworkPathFindingAlgorithm
{
    partial class MainForm
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
            this.pictureBoxGraph = new System.Windows.Forms.PictureBox();
            this.buttonVertexAdd = new System.Windows.Forms.Button();
            this.buttonVertexRemove = new System.Windows.Forms.Button();
            this.buttonVertexConnect = new System.Windows.Forms.Button();
            this.buttonVertexTransform = new System.Windows.Forms.Button();
            this.buttonDeleteGraph = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGraph)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxGraph
            // 
            this.pictureBoxGraph.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxGraph.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.pictureBoxGraph.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxGraph.InitialImage = global::MaxNetworkPathFindingAlgorithm.Properties.Resources.round_png_circle_empty_download_19;
            this.pictureBoxGraph.Location = new System.Drawing.Point(12, 50);
            this.pictureBoxGraph.Name = "pictureBoxGraph";
            this.pictureBoxGraph.Size = new System.Drawing.Size(851, 455);
            this.pictureBoxGraph.TabIndex = 0;
            this.pictureBoxGraph.TabStop = false;
            this.pictureBoxGraph.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxGraph_Paint);
            this.pictureBoxGraph.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBoxGraph_MouseClick);
            this.pictureBoxGraph.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxGraph_MouseDown);
            this.pictureBoxGraph.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxGraph_MouseMove);
            this.pictureBoxGraph.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBoxGraph_MouseUp);
            // 
            // buttonVertexAdd
            // 
            this.buttonVertexAdd.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonVertexAdd.Location = new System.Drawing.Point(168, 12);
            this.buttonVertexAdd.Name = "buttonVertexAdd";
            this.buttonVertexAdd.Size = new System.Drawing.Size(151, 32);
            this.buttonVertexAdd.TabIndex = 1;
            this.buttonVertexAdd.Text = "Добавить вершину";
            this.buttonVertexAdd.UseVisualStyleBackColor = true;
            this.buttonVertexAdd.Click += new System.EventHandler(this.buttonVertexAdd_Click);
            // 
            // buttonVertexRemove
            // 
            this.buttonVertexRemove.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonVertexRemove.Location = new System.Drawing.Point(482, 12);
            this.buttonVertexRemove.Name = "buttonVertexRemove";
            this.buttonVertexRemove.Size = new System.Drawing.Size(151, 32);
            this.buttonVertexRemove.TabIndex = 2;
            this.buttonVertexRemove.Text = "Удалить объект";
            this.buttonVertexRemove.UseVisualStyleBackColor = true;
            this.buttonVertexRemove.Click += new System.EventHandler(this.buttonVertexRemove_Click);
            // 
            // buttonVertexConnect
            // 
            this.buttonVertexConnect.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonVertexConnect.Location = new System.Drawing.Point(325, 12);
            this.buttonVertexConnect.Name = "buttonVertexConnect";
            this.buttonVertexConnect.Size = new System.Drawing.Size(151, 32);
            this.buttonVertexConnect.TabIndex = 3;
            this.buttonVertexConnect.Text = "Соединить вершины";
            this.buttonVertexConnect.UseVisualStyleBackColor = true;
            this.buttonVertexConnect.Click += new System.EventHandler(this.buttonVertexConnect_Click);
            // 
            // buttonVertexTransform
            // 
            this.buttonVertexTransform.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonVertexTransform.Location = new System.Drawing.Point(12, 12);
            this.buttonVertexTransform.Name = "buttonVertexTransform";
            this.buttonVertexTransform.Size = new System.Drawing.Size(150, 32);
            this.buttonVertexTransform.TabIndex = 4;
            this.buttonVertexTransform.Text = "Переместить вершину";
            this.buttonVertexTransform.UseVisualStyleBackColor = true;
            this.buttonVertexTransform.Click += new System.EventHandler(this.buttonVertexTransform_Click);
            // 
            // buttonDeleteGraph
            // 
            this.buttonDeleteGraph.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDeleteGraph.Location = new System.Drawing.Point(639, 12);
            this.buttonDeleteGraph.Name = "buttonDeleteGraph";
            this.buttonDeleteGraph.Size = new System.Drawing.Size(151, 32);
            this.buttonDeleteGraph.TabIndex = 5;
            this.buttonDeleteGraph.Text = "Очистить пространство";
            this.buttonDeleteGraph.UseVisualStyleBackColor = true;
            this.buttonDeleteGraph.Click += new System.EventHandler(this.buttonDeleteGraph_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 517);
            this.Controls.Add(this.buttonDeleteGraph);
            this.Controls.Add(this.buttonVertexTransform);
            this.Controls.Add(this.buttonVertexConnect);
            this.Controls.Add(this.buttonVertexRemove);
            this.Controls.Add(this.buttonVertexAdd);
            this.Controls.Add(this.pictureBoxGraph);
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseClick);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGraph)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxGraph;
        private System.Windows.Forms.Button buttonVertexAdd;
        private System.Windows.Forms.Button buttonVertexRemove;
        private System.Windows.Forms.Button buttonVertexConnect;
        private System.Windows.Forms.Button buttonVertexTransform;
        private System.Windows.Forms.Button buttonDeleteGraph;
    }
}

