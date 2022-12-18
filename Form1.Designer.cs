namespace ImagePacker
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.ImageList = new System.Windows.Forms.ListBox();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.DeleteBtn = new System.Windows.Forms.Button();
            this.ClearBtn = new System.Windows.Forms.Button();
            this.LoadBtn = new System.Windows.Forms.Button();
            this.FolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.SaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.SpaceBetweenPicturesNumericDropDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.SpaceBetweenPicturesNumericDropDown)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            this.ImageList.FormattingEnabled = true;
            this.ImageList.Location = new System.Drawing.Point(12, 171);
            this.ImageList.Name = "ImageList";
            this.ImageList.Size = new System.Drawing.Size(232, 264);
            this.ImageList.TabIndex = 0;
            this.ImageList.SelectedIndexChanged += new System.EventHandler(this.ImageList_SelectedIndexChanged);
            // 
            // SaveBtn
            // 
            this.SaveBtn.Enabled = false;
            this.SaveBtn.Location = new System.Drawing.Point(12, 38);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(232, 23);
            this.SaveBtn.TabIndex = 1;
            this.SaveBtn.Text = "Save";
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // DeleteBtn
            // 
            this.DeleteBtn.Enabled = false;
            this.DeleteBtn.Location = new System.Drawing.Point(12, 142);
            this.DeleteBtn.Name = "DeleteBtn";
            this.DeleteBtn.Size = new System.Drawing.Size(232, 23);
            this.DeleteBtn.TabIndex = 1;
            this.DeleteBtn.Text = "Delete";
            this.DeleteBtn.UseVisualStyleBackColor = true;
            this.DeleteBtn.Click += new System.EventHandler(this.DeleteBtn_Click);
            // 
            // ClearBtn
            // 
            this.ClearBtn.Location = new System.Drawing.Point(12, 113);
            this.ClearBtn.Name = "ClearBtn";
            this.ClearBtn.Size = new System.Drawing.Size(232, 23);
            this.ClearBtn.TabIndex = 1;
            this.ClearBtn.Text = "Clear";
            this.ClearBtn.UseVisualStyleBackColor = true;
            this.ClearBtn.Click += new System.EventHandler(this.ClearBtn_Click);
            // 
            // LoadBtn
            // 
            this.LoadBtn.Location = new System.Drawing.Point(12, 67);
            this.LoadBtn.Name = "LoadBtn";
            this.LoadBtn.Size = new System.Drawing.Size(232, 23);
            this.LoadBtn.TabIndex = 1;
            this.LoadBtn.Text = "Load";
            this.LoadBtn.UseVisualStyleBackColor = true;
            this.LoadBtn.Click += new System.EventHandler(this.LoadBtn_Click);
            // 
            // FolderBrowserDialog
            // 
            this.FolderBrowserDialog.ShowNewFolderButton = false;
            // 
            // SaveFileDialog
            // 
            this.SaveFileDialog.Filter = "PNG|*.png";
            // 
            // SpaceBetweenPicturesNumericDropDown
            // 
            this.SpaceBetweenPicturesNumericDropDown.Location = new System.Drawing.Point(148, 12);
            this.SpaceBetweenPicturesNumericDropDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.SpaceBetweenPicturesNumericDropDown.Name = "SpaceBetweenPicturesNumericDropDown";
            this.SpaceBetweenPicturesNumericDropDown.Size = new System.Drawing.Size(96, 20);
            this.SpaceBetweenPicturesNumericDropDown.TabIndex = 2;
            this.SpaceBetweenPicturesNumericDropDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.SpaceBetweenPicturesNumericDropDown.ValueChanged += new System.EventHandler(this.SpaceBetweenPicturesNumericDropDown_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Spacing between pictures";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(256, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SpaceBetweenPicturesNumericDropDown);
            this.Controls.Add(this.ClearBtn);
            this.Controls.Add(this.DeleteBtn);
            this.Controls.Add(this.LoadBtn);
            this.Controls.Add(this.SaveBtn);
            this.Controls.Add(this.ImageList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Image Packer";
            ((System.ComponentModel.ISupportInitialize)(this.SpaceBetweenPicturesNumericDropDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox ImageList;
        private System.Windows.Forms.Button SaveBtn;
        private System.Windows.Forms.Button DeleteBtn;
        private System.Windows.Forms.Button ClearBtn;
        private System.Windows.Forms.Button LoadBtn;
        private System.Windows.Forms.FolderBrowserDialog FolderBrowserDialog;
        private System.Windows.Forms.SaveFileDialog SaveFileDialog;
        private System.Windows.Forms.NumericUpDown SpaceBetweenPicturesNumericDropDown;
        private System.Windows.Forms.Label label1;
    }
}

