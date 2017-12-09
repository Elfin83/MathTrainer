using System;
using System.Diagnostics.Contracts;

namespace MathTrainer
{
    public class Presenter
    {
        private readonly IMainForm _view;
        private readonly IMessageService _messageService;                
        private IExercise ex;
        private Settings _settings;

        public Presenter(IMainForm view, Settings settings, IMessageService messageService)
        {
            _view = view;
            _messageService = messageService;
            _settings = settings;
            _view.SetExerciseText += _view_NewExerciseClick;
            _view.CheckAnswer += _view_CheckExercise;
            _view.SettingsPresenterInitialise += _view_SettingsClick;
            TimeManager.TimeIsUp += _time_IsUp;
            TimeManager.Tick += _next_Tick;
        }

        private void _view_NewExerciseClick(object sender, EventArgs e)
        {
            //ViewNewExercise();
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
                _messageService.CorrectAnswerMessage(ex.Answer().ToString());
                //Add answer in statistics
                Statistics.CorrectAnswersCount ++;                
            }
            else
            {
                _messageService.WrongAnswerMessage(ex.Answer().ToString());
            }
            
            //ViewNewExercise();      
        }

        private void _time_IsUp(object sender, EventArgs e)
        {           
            TimeManager.StopTimer();
            //Add answer in statistics
            Statistics.AnswersCount++;
            _messageService.TimeIsUpMessage(ex.Answer().ToString());
            
            //ViewNewExercise();
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
            return (_view.Answer == ex.Answer().ToString());
        }

        private bool IsInputCorrect(string answer)
        {
            if (String.IsNullOrEmpty(answer))
            {
                return false;
            }
            return true;
        }

        public void ViewNewExercise()
        {
            ExerciseManager exManager = new ExerciseManager(_settings.Numbers, _settings.MathOperations);
            ex = exManager.ChooseExercise();
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
