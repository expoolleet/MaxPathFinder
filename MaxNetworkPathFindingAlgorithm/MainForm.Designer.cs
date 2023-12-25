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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonVertexTransform = new System.Windows.Forms.Button();
            this.buttonDeleteGraph = new System.Windows.Forms.Button();
            this.buttonVertexAdd = new System.Windows.Forms.Button();
            this.buttonVertexRemove = new System.Windows.Forms.Button();
            this.buttonVertexConnect = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonFord = new System.Windows.Forms.Button();
            this.buttonHelp = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.pictureBoxGraph = new System.Windows.Forms.PictureBox();
            this.textBoxPath = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.buttonAuthor = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGraph)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonVertexTransform);
            this.groupBox1.Controls.Add(this.buttonDeleteGraph);
            this.groupBox1.Controls.Add(this.buttonVertexAdd);
            this.groupBox1.Controls.Add(this.buttonVertexRemove);
            this.groupBox1.Controls.Add(this.buttonVertexConnect);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(790, 67);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Управление";
            // 
            // buttonVertexTransform
            // 
            this.buttonVertexTransform.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonVertexTransform.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonVertexTransform.BackgroundImage")));
            this.buttonVertexTransform.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.buttonVertexTransform.FlatAppearance.BorderSize = 2;
            this.buttonVertexTransform.FlatAppearance.CheckedBackColor = System.Drawing.Color.Brown;
            this.buttonVertexTransform.FlatAppearance.MouseDownBackColor = System.Drawing.Color.CornflowerBlue;
            this.buttonVertexTransform.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.buttonVertexTransform.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonVertexTransform.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.buttonVertexTransform.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonVertexTransform.Location = new System.Drawing.Point(6, 19);
            this.buttonVertexTransform.Name = "buttonVertexTransform";
            this.buttonVertexTransform.Size = new System.Drawing.Size(150, 32);
            this.buttonVertexTransform.TabIndex = 4;
            this.buttonVertexTransform.Text = "По умолчанию";
            this.buttonVertexTransform.UseVisualStyleBackColor = false;
            this.buttonVertexTransform.Click += new System.EventHandler(this.buttonVertexTransform_Click);
            // 
            // buttonDeleteGraph
            // 
            this.buttonDeleteGraph.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonDeleteGraph.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonDeleteGraph.BackgroundImage")));
            this.buttonDeleteGraph.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.buttonDeleteGraph.FlatAppearance.BorderSize = 2;
            this.buttonDeleteGraph.FlatAppearance.CheckedBackColor = System.Drawing.Color.Brown;
            this.buttonDeleteGraph.FlatAppearance.MouseDownBackColor = System.Drawing.Color.CornflowerBlue;
            this.buttonDeleteGraph.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.buttonDeleteGraph.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDeleteGraph.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.buttonDeleteGraph.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonDeleteGraph.Location = new System.Drawing.Point(633, 19);
            this.buttonDeleteGraph.Name = "buttonDeleteGraph";
            this.buttonDeleteGraph.Size = new System.Drawing.Size(151, 32);
            this.buttonDeleteGraph.TabIndex = 5;
            this.buttonDeleteGraph.Text = "Очистить пространство";
            this.buttonDeleteGraph.UseVisualStyleBackColor = false;
            this.buttonDeleteGraph.Click += new System.EventHandler(this.buttonDeleteGraph_Click);
            // 
            // buttonVertexAdd
            // 
            this.buttonVertexAdd.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonVertexAdd.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonVertexAdd.BackgroundImage")));
            this.buttonVertexAdd.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.buttonVertexAdd.FlatAppearance.BorderSize = 2;
            this.buttonVertexAdd.FlatAppearance.CheckedBackColor = System.Drawing.Color.Brown;
            this.buttonVertexAdd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.CornflowerBlue;
            this.buttonVertexAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.buttonVertexAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonVertexAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.buttonVertexAdd.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonVertexAdd.Location = new System.Drawing.Point(162, 19);
            this.buttonVertexAdd.Name = "buttonVertexAdd";
            this.buttonVertexAdd.Size = new System.Drawing.Size(151, 32);
            this.buttonVertexAdd.TabIndex = 1;
            this.buttonVertexAdd.Text = "Добавить вершину";
            this.buttonVertexAdd.UseVisualStyleBackColor = false;
            this.buttonVertexAdd.Click += new System.EventHandler(this.buttonVertexAdd_Click);
            // 
            // buttonVertexRemove
            // 
            this.buttonVertexRemove.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonVertexRemove.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonVertexRemove.BackgroundImage")));
            this.buttonVertexRemove.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.buttonVertexRemove.FlatAppearance.BorderSize = 2;
            this.buttonVertexRemove.FlatAppearance.CheckedBackColor = System.Drawing.Color.Brown;
            this.buttonVertexRemove.FlatAppearance.MouseDownBackColor = System.Drawing.Color.CornflowerBlue;
            this.buttonVertexRemove.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.buttonVertexRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonVertexRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.buttonVertexRemove.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonVertexRemove.Location = new System.Drawing.Point(476, 19);
            this.buttonVertexRemove.Name = "buttonVertexRemove";
            this.buttonVertexRemove.Size = new System.Drawing.Size(151, 32);
            this.buttonVertexRemove.TabIndex = 2;
            this.buttonVertexRemove.Text = "Удалить объект";
            this.buttonVertexRemove.UseVisualStyleBackColor = false;
            this.buttonVertexRemove.Click += new System.EventHandler(this.buttonVertexRemove_Click);
            // 
            // buttonVertexConnect
            // 
            this.buttonVertexConnect.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonVertexConnect.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonVertexConnect.BackgroundImage")));
            this.buttonVertexConnect.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.buttonVertexConnect.FlatAppearance.BorderSize = 2;
            this.buttonVertexConnect.FlatAppearance.CheckedBackColor = System.Drawing.Color.Brown;
            this.buttonVertexConnect.FlatAppearance.MouseDownBackColor = System.Drawing.Color.CornflowerBlue;
            this.buttonVertexConnect.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.buttonVertexConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonVertexConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.buttonVertexConnect.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonVertexConnect.Location = new System.Drawing.Point(319, 19);
            this.buttonVertexConnect.Name = "buttonVertexConnect";
            this.buttonVertexConnect.Size = new System.Drawing.Size(151, 32);
            this.buttonVertexConnect.TabIndex = 3;
            this.buttonVertexConnect.Text = "Соединить вершины";
            this.buttonVertexConnect.UseVisualStyleBackColor = false;
            this.buttonVertexConnect.Click += new System.EventHandler(this.buttonVertexConnect_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonFord);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.groupBox2.Location = new System.Drawing.Point(808, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(164, 67);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Алгоритм Форда";
            // 
            // buttonFord
            // 
            this.buttonFord.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonFord.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonFord.BackgroundImage")));
            this.buttonFord.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.buttonFord.FlatAppearance.BorderSize = 2;
            this.buttonFord.FlatAppearance.CheckedBackColor = System.Drawing.Color.Brown;
            this.buttonFord.FlatAppearance.MouseDownBackColor = System.Drawing.Color.CornflowerBlue;
            this.buttonFord.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.buttonFord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFord.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.buttonFord.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonFord.Location = new System.Drawing.Point(6, 19);
            this.buttonFord.Name = "buttonFord";
            this.buttonFord.Size = new System.Drawing.Size(151, 32);
            this.buttonFord.TabIndex = 6;
            this.buttonFord.Text = "Начать поиск";
            this.buttonFord.UseVisualStyleBackColor = false;
            this.buttonFord.Click += new System.EventHandler(this.buttonFord_Click);
            // 
            // buttonHelp
            // 
            this.buttonHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonHelp.ForeColor = System.Drawing.SystemColors.GrayText;
            this.buttonHelp.Location = new System.Drawing.Point(788, 607);
            this.buttonHelp.Name = "buttonHelp";
            this.buttonHelp.Size = new System.Drawing.Size(90, 38);
            this.buttonHelp.TabIndex = 8;
            this.buttonHelp.Text = "Руководство";
            this.buttonHelp.UseVisualStyleBackColor = true;
            this.buttonHelp.Click += new System.EventHandler(this.buttonHelp_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 654);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(984, 22);
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // pictureBoxGraph
            // 
            this.pictureBoxGraph.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxGraph.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.pictureBoxGraph.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxGraph.InitialImage = global::MaxNetworkPathFindingAlgorithm.Properties.Resources.round_png_circle_empty_download_19;
            this.pictureBoxGraph.Location = new System.Drawing.Point(12, 85);
            this.pictureBoxGraph.Name = "pictureBoxGraph";
            this.pictureBoxGraph.Size = new System.Drawing.Size(962, 511);
            this.pictureBoxGraph.TabIndex = 0;
            this.pictureBoxGraph.TabStop = false;
            this.pictureBoxGraph.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxGraph_Paint);
            this.pictureBoxGraph.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBoxGraph_MouseClick);
            this.pictureBoxGraph.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxGraph_MouseDown);
            this.pictureBoxGraph.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxGraph_MouseMove);
            this.pictureBoxGraph.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBoxGraph_MouseUp);
            // 
            // textBoxPath
            // 
            this.textBoxPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPath.Location = new System.Drawing.Point(6, 19);
            this.textBoxPath.Name = "textBoxPath";
            this.textBoxPath.ReadOnly = true;
            this.textBoxPath.Size = new System.Drawing.Size(301, 29);
            this.textBoxPath.TabIndex = 10;
            this.textBoxPath.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox3.Controls.Add(this.textBoxPath);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.groupBox3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.groupBox3.Location = new System.Drawing.Point(12, 597);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(313, 54);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Найденный путь";
            // 
            // buttonAuthor
            // 
            this.buttonAuthor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAuthor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAuthor.ForeColor = System.Drawing.SystemColors.GrayText;
            this.buttonAuthor.Location = new System.Drawing.Point(884, 607);
            this.buttonAuthor.Name = "buttonAuthor";
            this.buttonAuthor.Size = new System.Drawing.Size(88, 38);
            this.buttonAuthor.TabIndex = 12;
            this.buttonAuthor.Text = "Автор";
            this.buttonAuthor.UseVisualStyleBackColor = true;
            this.buttonAuthor.Click += new System.EventHandler(this.buttonAuthor_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(984, 676);
            this.Controls.Add(this.buttonAuthor);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.buttonHelp);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBoxGraph);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximumSize = new System.Drawing.Size(1800, 1000);
            this.MinimumSize = new System.Drawing.Size(1000, 300);
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Построение графа / Поиск наибольшего пути в сети";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseClick);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGraph)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxGraph;
        private System.Windows.Forms.Button buttonVertexAdd;
        private System.Windows.Forms.Button buttonVertexRemove;
        private System.Windows.Forms.Button buttonVertexConnect;
        private System.Windows.Forms.Button buttonVertexTransform;
        private System.Windows.Forms.Button buttonDeleteGraph;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonFord;
        private System.Windows.Forms.Button buttonHelp;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.TextBox textBoxPath;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button buttonAuthor;
    }
}

