using System;

namespace MathTrainer
{
    class SettingsPresenter
    {
        private readonly SettingsForm _view;
        private Settings _settings;

        public SettingsPresenter(SettingsForm view, Settings settings)
        {            
            _view = view;
            _settings = settings;
            _view.GetSettings += _settings_LoadSettingsForm;
            _view.SetSettings += _settings_SaveSettingsClick;
        }

        private void _settings_LoadSettingsForm(object sender, EventArgs e)
        {            
            _view.Numbers = _settings.Numbers;
            _view.MathOperations = _settings.MathOperations.ConvertAll(new Converter<MathOperations, string>(MathOpToString));
        }

        private void _settings_SaveSettingsClick(object sender, EventArgs e)
        {           
            _settings.Numbers = _view.Numbers;                     
            _settings.MathOperations = _view.MathOperations.ConvertAll(new Converter<string, MathOperations>(StringToMathOp));
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
