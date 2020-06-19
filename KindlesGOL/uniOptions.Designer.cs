namespace KindlesGOL
{
    partial class uniOptions
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
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.timerInterInput = new System.Windows.Forms.NumericUpDown();
            this.uniWidthInput = new System.Windows.Forms.NumericUpDown();
            this.uniHeightInput = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.timerInterInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uniWidthInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uniHeightInput)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(68, 147);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(100, 25);
            this.buttonOK.TabIndex = 0;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // buttonClose
            // 
            this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonClose.Location = new System.Drawing.Point(174, 147);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.buttonClose.Size = new System.Drawing.Size(100, 25);
            this.buttonClose.TabIndex = 1;
            this.buttonClose.Text = "Cancel";
            this.buttonClose.UseVisualStyleBackColor = true;
            // 
            // timerInterInput
            // 
            this.timerInterInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timerInterInput.Location = new System.Drawing.Point(192, 8);
            this.timerInterInput.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.timerInterInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.timerInterInput.Name = "timerInterInput";
            this.timerInterInput.Size = new System.Drawing.Size(120, 24);
            this.timerInterInput.TabIndex = 2;
            this.timerInterInput.Value = new decimal(new int[] {
            32,
            0,
            0,
            0});
            // 
            // uniWidthInput
            // 
            this.uniWidthInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uniWidthInput.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.uniWidthInput.Location = new System.Drawing.Point(192, 81);
            this.uniWidthInput.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.uniWidthInput.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.uniWidthInput.Name = "uniWidthInput";
            this.uniWidthInput.Size = new System.Drawing.Size(120, 24);
            this.uniWidthInput.TabIndex = 3;
            this.uniWidthInput.Value = new decimal(new int[] {
            75,
            0,
            0,
            0});
            // 
            // uniHeightInput
            // 
            this.uniHeightInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uniHeightInput.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.uniHeightInput.Location = new System.Drawing.Point(192, 111);
            this.uniHeightInput.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.uniHeightInput.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.uniHeightInput.Name = "uniHeightInput";
            this.uniHeightInput.Size = new System.Drawing.Size(120, 24);
            this.uniHeightInput.TabIndex = 4;
            this.uniHeightInput.Value = new decimal(new int[] {
            75,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Timer Interval - Milliseconds";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(144, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Width";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(139, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Height";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(299, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Size of the universe in Cells   ( 10 - 1000 )";
            // 
            // uniOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 191);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.uniHeightInput);
            this.Controls.Add(this.uniWidthInput);
            this.Controls.Add(this.timerInterInput);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "uniOptions";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Universe Options";
            ((System.ComponentModel.ISupportInitialize)(this.timerInterInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uniWidthInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uniHeightInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.NumericUpDown timerInterInput;
        private System.Windows.Forms.NumericUpDown uniWidthInput;
        private System.Windows.Forms.NumericUpDown uniHeightInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}