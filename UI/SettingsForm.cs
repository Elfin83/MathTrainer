using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MathTrainer
{
    public interface ISettingsForm
    {
        List<int> Numbers { get; set; }
        List<string> MathOperations { get; set; }
        bool TimerIsOn { get; set; }
        decimal TimeLimit { get; set; }

        event EventHandler SetSettings;
        event EventHandler GetSettings;
    }
    public partial class SettingsForm : Form
    {
        #region Fields and props
        private List<int> _numColl = new List<int> { };
        private List<string> _mathOp = new List<string> { };

        private IEnumerable<CheckBox> _checkBoxColl;         

        public List<int> Numbers
        {
            get
            {
                _numColl.Clear();
                foreach (CheckBox checkBox in _checkBoxColl)
                {
                    if (checkBox.Name == "multCheckBox" || checkBox.Name == "divCheckBox" 
                        || checkBox.Name == "timerIsOn") continue;
                    //Перебираем все чекбоксы с цифрами на форме
                    if (checkBox.Checked)
                    {
                        _numColl.Add(int.Parse(checkBox.Text));
                    }
                    else
                    {
                        _numColl.Remove(int.Parse(checkBox.Text));
                    }
                }                
                return _numColl;
            }
            set
            {
                _numColl = value;
            }
        }

        public List<string> MathOperations
        {
            get
            {
                _mathOp.Clear();
                foreach (CheckBox checkBox in _checkBoxColl)
                {
                    if (checkBox.Checked)
                    {
                        if (checkBox.Name == "multCheckBox")
                        {
                            _mathOp.Add("Умножать");
                        }
                        if (checkBox.Name == "divCheckBox")
                        {
                            _mathOp.Add("Делить");
                        }
                    }
                }
                return _mathOp;
            }
            set
            {
                _mathOp = value;
            }
        }

        public bool TimerIsOn
        {
            get
            {
                return timerIsOn.Checked;
            }
            set
            {
                timerIsOn.Checked = value;                
            }
        }

        public decimal TimeLimit
        {
            get
            {
                return timerDuration.Value;
            }

            set
            {
                timerDuration.Value = value;
            }
        }
        #endregion        

        public SettingsForm()
        {
            InitializeComponent();
            _checkBoxColl = this.Controls.OfType<CheckBox>().Where(element => element != timerIsOn);
        }

        private void saveButton1_Click(object sender, EventArgs e)
        {            
            if (!IsControlsChecked(Numbers, MathOperations))
            { return; }

            if (SetSettings != null)
            {
                SetSettings(this, EventArgs.Empty);
            }
            this.Close();
        }

        private bool IsControlsChecked(List<int> numbers, List<string> mathOp)
        {
            if (numbers.Count == 0)
            {
                MessageBox.Show("Пожалуйста, укажите в настройках, какие числа должны использоваться в примерах.");
                return false;
            }
            if (mathOp.Count == 0)
            {
                MessageBox.Show("Пожалуйста, укажите в настройках, какие математические операции должны использоваться в примерах.");
                return false;
            }
            return true;
        }

        private void SetContolsByValue()
        {
           foreach (var checkBox in _checkBoxColl)
            {
                string checkBoxTxt = checkBox.Text;
                
                if (_numColl.Exists(x => x.ToString() == checkBoxTxt) ||
                    _mathOp.Exists(x => x.ToString() == checkBoxTxt)) 
                {
                    checkBox.Checked = true;
                }
                else
                {
                    checkBox.Checked = false;
                }
            }
        }

        public event EventHandler SetSettings;
        public event EventHandler GetSettings;

        private void SettingsForm_Load_1(object sender, EventArgs e)
        {
           
            if (GetSettings != null)
            {
                GetSettings(this, EventArgs.Empty);
            }

            SetContolsByValue();
        }

        private void timerIsOn_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
