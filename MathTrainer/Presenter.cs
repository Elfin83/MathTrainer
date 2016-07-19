using System;
using System.Diagnostics.Contracts;


namespace MathTrainer
{
    public class Presenter
    {
        private readonly IMainForm _view;
        private readonly IMessageService _messageService;  
        private Settings _settings = new Settings();        
        private IExercise ex;

        public Presenter(IMainForm view, IMessageService messageService)
        {
            Contract.Requires<ArgumentNullException>(view != null, "view");
            Contract.Requires<ArgumentNullException>(messageService != null, "messageService");
            _view = view;
            _messageService = messageService;

            _view.SetExerciseText += _view_NewExerciseClick;
            _view.CheckAnswer += _view_CheckExercise;
            _view.SettingsPresenterInitialise += _view_SettingsClick;
            TimeManager.TimeIsUp += _time_IsUp;
            TimeManager.Tick += _next_Tick;
        }

        private void _view_NewExerciseClick(object sender, EventArgs e)
        {
            ViewNewExercise();
        }

        private void _view_CheckExercise(object sender, EventArgs e)
        {           
            if (!IsInputCorrect(_view.Answer))
            {
                _messageService.ShowError();
                return;
            }

            //Stop timer
            TimeManager.StopTimer();
            //Add answer in statistics
            Statistics.AnswersCount++;

            if (IsAnswerCorrect())
            {
                _messageService.CorrectAnswerMessage(ex.Answer());
                //Add answer in statistics
                Statistics.CorrectAnswersCount ++;                
            }
            else
            {
                _messageService.WrongAnswerMessage(ex.Answer());
            }
            
            ViewNewExercise();      
        }

        private void _time_IsUp(object sender, EventArgs e)
        {           
            TimeManager.StopTimer();
            //Add answer in statistics
            Statistics.AnswersCount++;
            _messageService.TimeIsUpMessage(ex.Answer());
            
            ViewNewExercise();
        }

        private void _next_Tick(object sender, EventArgs e)
        {            
            _view.TimeBarProgress();
        }

        //Create SettingsPresenter 
        private void _view_SettingsClick(object sender, EventArgs e)
        {
            SettingsForm settingsForm = (SettingsForm)sender;
            SettingsPresenter settingsPresenter = new SettingsPresenter(settingsForm, _settings);
        }

        private bool IsAnswerCorrect()
        {
            string exerciseAnswer = ex.Answer();
            return (_view.Answer == exerciseAnswer);
        }

        private bool IsInputCorrect(string answer)
        {
            if (String.IsNullOrEmpty(answer))
            {
                return false;
            }
            return true;
        }

        private void ViewNewExercise()
        {
            ex = ExerciseManager.ChooseExercise(_settings.Numbers, _settings.MathOperations);
            _view.MathExercise = ex.ToString();
            _view.ClearTimerBar();

            if (_settings.TimerIsOn)
            {                
                _view.TimerBarMaximum = (int)_settings.TimeLimit;
                TimeManager.StartTimer(_settings.TimeLimit);
            }
            //Refresh StatisticsInfo
            _view.SetStatusStripText(Statistics.AnswersCount, Statistics.CorrectAnswersCount);
        }
    }
}
