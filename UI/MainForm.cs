using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MathTrainer
{
    public interface IMainForm
    {
        
        string MathExercise { set; }
        string Answer { get; }

        event EventHandler CheckAnswerClick;
        event EventHandler SetExerciseText;
        event EventHandler SettingsPresenterInitialise;
    }
    
    public partial class MainForm : Form, IMainForm
    {        
        public MainForm()
        {
            InitializeComponent();
        }

        #region Fields and props
                
        enum State { Start, Exercise};
        State currentState = State.Start;
        
        public string MathExercise
        {
            set { exerciseLabel.Text = value; }
        }

        public string Answer
        {
            get
            {
                return textBox1.Text;
            }
        } 
        #endregion    

        private void button1_Click(object sender, EventArgs e)
        {
            if (currentState == State.Start)
            {
                if (SetExerciseText != null)
                {
                    SetExerciseText(this, EventArgs.Empty);
                }
                button1.Text = "Ответ";
                currentState = State.Exercise;
                textBox1.Text = "";
                textBox1.Focus();
            }
            else if (currentState == State.Exercise)
            {
                if (CheckAnswerClick != null)
                {
                    CheckAnswerClick(this, EventArgs.Empty);
                }

                textBox1.Text = "";
                textBox1.Focus();
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if (c == 13) //Enter
            {
                if (CheckAnswerClick != null)
                {
                    CheckAnswerClick(this, EventArgs.Empty);
                }
                textBox1.Text = "";
                textBox1.Focus();
            }
            if (!(Char.IsDigit(c) || c == 8)) //numbers or backspace
            {
                e.Handled = true;
            }            
        }        

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm();
            if (SettingsPresenterInitialise != null)
            {
                SettingsPresenterInitialise(settingsForm, EventArgs.Empty);
            }
            settingsForm.Owner = this;
            settingsForm.ShowDialog();
        }

        public event EventHandler CheckAnswerClick;
        public event EventHandler SetExerciseText;
        public event EventHandler SettingsPresenterInitialise;
    }
}
