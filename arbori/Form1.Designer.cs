namespace arbori
{
    partial class Form1
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
            treePanel = new Panel();
            btnInsert = new Button();
            btnDelete = new Button();
            txtValue = new TextBox();
            btnClear = new Button();
            btnFind = new Button();
            btnRandom = new Button();
            SuspendLayout();
            // 
            // treePanel
            // 
            treePanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            treePanel.Location = new Point(0, 61);
            treePanel.Name = "treePanel";
            treePanel.Size = new Size(800, 389);
            treePanel.TabIndex = 0;
            treePanel.Paint += treePanel_Paint;
            // 
            // btnInsert
            // 
            btnInsert.BackColor = SystemColors.HotTrack;
            btnInsert.ForeColor = SystemColors.Control;
            btnInsert.Location = new Point(93, 12);
            btnInsert.Name = "btnInsert";
            btnInsert.Size = new Size(75, 43);
            btnInsert.TabIndex = 1;
            btnInsert.Text = "INSERARE";
            btnInsert.UseVisualStyleBackColor = false;
            btnInsert.Click += btnInsert_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.Red;
            btnDelete.ForeColor = SystemColors.Control;
            btnDelete.Location = new Point(174, 12);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 43);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "STERGERE";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // txtValue
            // 
            txtValue.Location = new Point(417, 23);
            txtValue.Name = "txtValue";
            txtValue.Size = new Size(111, 23);
            txtValue.TabIndex = 3;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.ForestGreen;
            btnClear.ForeColor = SystemColors.Control;
            btnClear.Location = new Point(336, 12);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(75, 43);
            btnClear.TabIndex = 4;
            btnClear.Text = "CLEAR";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // btnFind
            // 
            btnFind.BackColor = Color.DarkGoldenrod;
            btnFind.ForeColor = SystemColors.Control;
            btnFind.Location = new Point(255, 12);
            btnFind.Name = "btnFind";
            btnFind.Size = new Size(75, 43);
            btnFind.TabIndex = 5;
            btnFind.Text = "CAUTA";
            btnFind.UseVisualStyleBackColor = false;
            btnFind.Click += btnFind_Click;
            // 
            // btnRandom
            // 
            btnRandom.BackColor = Color.DarkViolet;
            btnRandom.ForeColor = SystemColors.Control;
            btnRandom.Location = new Point(12, 12);
            btnRandom.Name = "btnRandom";
            btnRandom.Size = new Size(75, 43);
            btnRandom.TabIndex = 6;
            btnRandom.Text = "RANDOM";
            btnRandom.UseVisualStyleBackColor = false;
            btnRandom.Click += btnRandom_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnRandom);
            Controls.Add(btnFind);
            Controls.Add(btnClear);
            Controls.Add(txtValue);
            Controls.Add(btnDelete);
            Controls.Add(btnInsert);
            Controls.Add(treePanel);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel treePanel;
        private Button btnInsert;
        private Button btnDelete;
        private TextBox txtValue;
        private Button btnClear;
        private Button btnFind;
        private Button btnRandom;
    }
}
