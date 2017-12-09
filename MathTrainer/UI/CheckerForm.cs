using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MathTrainer
{
    public interface ICheckerForm
    {
        string IsCorrectLabelText { set; }
        string IsCorrectLabelColor { set; }
        Font IsCorrectLableFont { set; }
        Size IsCorrectLableSize { set; }
        string ExerciseAnswer { set; }
    }

    public partial class CheckerForm : Form
    {
        public CheckerForm()
        {
            InitializeComponent();
        }

        #region Fields and props
        public string IsCorrectLabelText
        {
            set { isCorrectAnswerLabel.Text = value; }
        }

        public string IsCorrectLableColor
        {
            set { isCorrectAnswerLabel.ForeColor = Color.FromName(value); }
        }

        public Font IsCorrectLableFont
        {
            set { isCorrectAnswerLabel.Font = value; }
        }

        public Size IsCorrectLableSize
        {
            set { isCorrectAnswerLabel.Size = value; }
        }

        public string ExerciseAnswer
        {
            set { exerciseAnswerLabel.Text = value; }
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
