namespace MathTrainer
{
    partial class CheckerForm
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
            this.isCorrectAnswerLabel = new System.Windows.Forms.Label();
            this.exerciseAnswerLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // isCorrectAnswerLabel
            // 
            this.isCorrectAnswerLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.isCorrectAnswerLabel.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.isCorrectAnswerLabel.ForeColor = System.Drawing.Color.LimeGreen;
            this.isCorrectAnswerLabel.Location = new System.Drawing.Point(0, 0);
            this.isCorrectAnswerLabel.Name = "isCorrectAnswerLabel";
            this.isCorrectAnswerLabel.Size = new System.Drawing.Size(284, 79);
            this.isCorrectAnswerLabel.TabIndex = 0;
            this.isCorrectAnswerLabel.Text = "Верно!";
            this.isCorrectAnswerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // exerciseAnswerLabel
            // 
            this.exerciseAnswerLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.exerciseAnswerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.exerciseAnswerLabel.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.exerciseAnswerLabel.Location = new System.Drawing.Point(0, 79);
            this.exerciseAnswerLabel.Name = "exerciseAnswerLabel";
            this.exerciseAnswerLabel.Size = new System.Drawing.Size(284, 124);
            this.exerciseAnswerLabel.TabIndex = 1;
            this.exerciseAnswerLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(43, 153);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(198, 38);
            this.button1.TabIndex = 2;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CheckerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 203);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.exerciseAnswerLabel);
            this.Controls.Add(this.isCorrectAnswerLabel);
            this.Name = "CheckerForm";
            this.Text = "Результат";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label isCorrectAnswerLabel;
        private System.Windows.Forms.Label exerciseAnswerLabel;
        private System.Windows.Forms.Button button1;
    }
}