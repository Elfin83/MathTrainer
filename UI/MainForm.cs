using System;
using System.Windows.Forms;
using System.Threading;

namespace MathTrainer
{
    public interface IMainForm
    {
        
        string MathExercise { set; }
        string Answer { get; }
        int TimerBarMaximum { set; }

        void TimeBarProgress();
        void ClearTimerBar();

        event EventHandler CheckAnswer;
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

        public int TimerBarMaximum
        {
            set { timerBar.Maximum = value; }
        }

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentState == State.Exercise)
                {
                    if (CheckAnswer != null)
                    {
                        CheckAnswer(this, EventArgs.Empty);
                    }

                    textBox1.Text = "";
                    textBox1.Focus();
                }
                else if (currentState == State.Start)
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
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }                    
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                char c = e.KeyChar;
                if (c == 13) //Enter
                {
                    if (CheckAnswer != null)
                    {
                        CheckAnswer(this, EventArgs.Empty);
                    }
                    textBox1.Text = "";
                    textBox1.Focus();
                }
                if (!(Char.IsDigit(c) || c == 8)) //numbers or backspace
                {
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }            
        }        

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SettingsForm settingsForm = new SettingsForm();
                if (SettingsPresenterInitialise != null)
                {
                    SettingsPresenterInitialise(settingsForm, EventArgs.Empty);
                }
                settingsForm.Owner = this;
                settingsForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }            
        }

        public void TimeBarProgress()
        {
            try
            {
                if (timerBar.InvokeRequired)
                {
                    timerBar.Invoke((Action)(() => timerBar.PerformStep()));                    
                }
                else
                {
                    timerBar.PerformStep();                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void ClearTimerBar()
        {
            try
            {
                if (timerBar.InvokeRequired)
                {
                    timerBar.Invoke((Action)(() => timerBar.Value = 0));
                }
                else
                {
                    timerBar.Value = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
      
        public event EventHandler CheckAnswer;
        public event EventHandler SetExerciseText;
        public event EventHandler SettingsPresenterInitialise;
    }
}
