using System;


namespace MathTrainer
{
    public class Presenter
    {
        private readonly IMainForm _view;
        private readonly IMessageService _messageService;
        private ExerciseManager _model = new ExerciseManager();
        private Settings _settings = new Settings();
        private IExercise ex;                

        public Presenter(IMainForm view, IMessageService messageService)
        {
            _view = view;                   
            _messageService = messageService;      
            _view.SetExerciseText += _view_NewExerciseClick;
            _view.CheckAnswerClick += _view_CheckExerciseClick;
            _view.SettingsPresenterInitialise += _view_SettingsClick;
        }

        private void _view_NewExerciseClick(object sender, EventArgs e)
        {
            CreateNewExercise();
        }

        private void _view_CheckExerciseClick(object sender, EventArgs e)
        {
            if (!IsInputCorrect(_view.Answer))
            {
                _messageService.ShowError();
                return;
            }

            string exerciseAnswer = ex.Answer().ToString();
            _messageService.ShowAnswerForm((_view.Answer == exerciseAnswer), exerciseAnswer); //Show message depending on answer true or false

            CreateNewExercise();
        }

        //Create SettingsPresenter 
        private void _view_SettingsClick(object sender, EventArgs e)
        {
           SettingsForm settingsForm = (SettingsForm)sender;
           SettingsPresenter settingsPresenter = new SettingsPresenter(settingsForm, _settings);            
        }
        
        private void CreateNewExercise()
        {
            ex = ExerciseManager.ChooseExercise(_settings.Numbers, _settings.MathOperations);
            _view.MathExercise = ex.ExerciseText();
        }

        private bool IsInputCorrect(string answer)
        {
            if (String.IsNullOrEmpty(answer))
            {
                return false;
            }
            return true;
        }
    }
}
