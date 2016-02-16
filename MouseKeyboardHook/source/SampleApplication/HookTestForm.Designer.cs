namespace SampleApplication
{
    partial class HookTestForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.curXYLabel = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listView2 = new System.Windows.Forms.ListView();
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listView1);
            this.groupBox1.Controls.Add(this.curXYLabel);
            this.groupBox1.Location = new System.Drawing.Point(12, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(481, 138);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "鼠标";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader4,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader5});
            this.listView1.Location = new System.Drawing.Point(6, 35);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(469, 98);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "事件类型";
            this.columnHeader1.Width = 115;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "按键";
            this.columnHeader4.Width = 81;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "X距离";
            this.columnHeader2.Width = 90;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Y距离";
            this.columnHeader3.Width = 92;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "偏移";
            this.columnHeader5.Width = 82;
            // 
            // curXYLabel
            // 
            this.curXYLabel.AutoSize = true;
            this.curXYLabel.Location = new System.Drawing.Point(22, 20);
            this.curXYLabel.Name = "curXYLabel";
            this.curXYLabel.Size = new System.Drawing.Size(0, 12);
            this.curXYLabel.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listView2);
            this.groupBox2.Location = new System.Drawing.Point(12, 155);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(481, 138);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "键盘";
            // 
            // listView2
            // 
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6,
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader13,
            this.columnHeader14,
            this.columnHeader15});
            this.listView2.Location = new System.Drawing.Point(6, 18);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(469, 237);
            this.listView2.TabIndex = 1;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "事件类型";
            this.columnHeader6.Width = 117;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "按键编码";
            this.columnHeader11.Width = 74;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "按键字符";
            this.columnHeader12.Width = 83;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "Shift";
            this.columnHeader13.Width = 50;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "Alt";
            this.columnHeader14.Width = 50;
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "Control";
            this.columnHeader15.Width = 76;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(18, 299);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(469, 96);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // HookTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 414);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "HookTestForm";
            this.Text = "Hook示例";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TestForm_FormClosed);
            this.Load += new System.EventHandler(this.TestForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label curXYLabel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.ColumnHeader columnHeader15;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}

