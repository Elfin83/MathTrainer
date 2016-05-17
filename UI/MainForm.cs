using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MathTrainer
{
    public interface IMainForm
    {
        List<int> Numbers { get; }
        List<string> MathOperations { get; }
        string MathExercise { set; }
        string Answer { get; }

        event EventHandler CheckAnswerClick;
        event EventHandler SetExerciseText;
    }
    
    public partial class MainForm : Form, IMainForm
    {        
        public MainForm()
        {
            InitializeComponent();
        }

        #region Fields and props
        private List<int> _numColl;
        private List<string> _mathOp;
        enum State { Start, Exercise};
        State currentState = State.Start; 

        public List<int> Numbers
        {
            get
            {
                _numColl = new List<int>();
                foreach (CheckBox checkBox in this.Controls.OfType<CheckBox>())
                {
                    if (checkBox.Name == "multCheckBox" || checkBox.Name == "divCheckBox") continue;
                    //Перебираем все чекбоксы на форме
                    if (checkBox.Checked)
                    {
                        _numColl.Add(Int32.Parse(checkBox.Text));
                    }
                }
                return _numColl;
            }
        }

        public List<string> MathOperations
        {
            get
            {
                _mathOp = new List<string>();
                foreach (CheckBox checkBox in this.Controls.OfType<CheckBox>())
                {
                    if (checkBox.Checked)
                    {
                        if (checkBox.Name == "multCheckBox")
                        {
                            _mathOp.Add("Умножение");
                        }
                        if (checkBox.Name == "divCheckBox")
                        {
                            _mathOp.Add("Деление");
                        }
                    }
                }
                return _mathOp;
            }
        }

        public string MathExercise
        {
            set { exerciseLabel.Text = value; }
        }

        public string Answer
        {
            get
            {
                //if(IsInputCorrect()) 
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

        public event EventHandler CheckAnswerClick;
        public event EventHandler SetExerciseText;

      
    }
}
