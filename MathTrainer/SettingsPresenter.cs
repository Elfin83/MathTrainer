using System;

namespace MathTrainer
{
    class SettingsPresenter
    {
        private readonly SettingsForm _settingsView;
        private Settings _settings;

        public SettingsPresenter(SettingsForm view, Settings settings)
        {            
            _settingsView = view;
            _settings = settings;
            _settingsView.GetSettings += _settings_LoadSettingsForm;
            _settingsView.SetSettings += _settings_SaveSettingsClick;
        }

        private void _settings_LoadSettingsForm(object sender, EventArgs e)
        {            
            _settingsView.Numbers = _settings.Numbers;
            _settingsView.MathOperations = _settings.MathOperations.ConvertAll(new Converter<MathOperations, string>(MathOpToString));
            _settingsView.TimerIsOn = _settings.TimerIsOn;
            _settingsView.TimeLimit = _settings.TimeLimit;      
        }

        private void _settings_SaveSettingsClick(object sender, EventArgs e)
        {           
            _settings.Numbers = _settingsView.Numbers;                     
            _settings.MathOperations = _settingsView.MathOperations.ConvertAll(new Converter<string, MathOperations>(StringToMathOp));
            _settings.TimerIsOn = _settingsView.TimerIsOn;
            _settings.TimeLimit = _settingsView.TimeLimit;
        }

        private string MathOpToString(MathOperations mathOp)
        {
            return mathOp.ToString();
        }

        private MathOperations StringToMathOp(string mathOp)
        {
            try
            {
                return (MathOperations)Enum.Parse(typeof(MathOperations), mathOp);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("'{0}' не входит в список допустимых математических операций.", mathOp);                
                return MathOperations.None;                
            }
        }
    }
}
