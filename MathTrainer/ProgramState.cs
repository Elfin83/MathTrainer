using MathTrainer;
using System;
interface IAutomat
{
    void SuggestExercise(Presenter presenter);
    void CheckAnswer(Presenter presenter);
    void SetSettings(Presenter presenter);

    void SetState(IProgramState s);
    IProgramState PreparingState();
    IProgramState ExerciseSuggestedState();
    IProgramState AnswerCheckingState();
    IProgramState WaitingState();
} 
   
interface IProgramState
    {
    void SuggestExercise(Presenter presenter);
    void CheckAnswer(Presenter presenter);
    void SetSettings(Presenter presenter);
    }

public class Automat : IAutomat
{
    private IProgramState _preparingState;
    private IProgramState _exerciseSuggestedState;
    private IProgramState _answerCheckingState;
    private IProgramState _state;
    private Presenter _presenter;


    public Automat(Presenter presenter)
    {
        _presenter = presenter;
        _preparingState = new PreparingState(this);
        _exerciseSuggestedState = new ExerciseSuggestedState(this);
        _answerCheckingState = new AnswerCheckingState(this);
        _state = _preparingState;
    }

    public void SuggestExercise()
    {
        _state.SuggestExercise(_presenter);
    }

    public void CheckAnswer()
    {
        _state.CheckAnswer(_presenter);
    }

    public void SetSettings()
    {
        _state.SetSettings(_presenter);
    }

    public void SetState(IProgramState s) { _state = s; }
    public IProgramState GetPreparingState() { return _preparingState; }
    public IProgramState GetExerciseSuggestedState() { return _exerciseSuggestedState; }
    public IProgramState GetAnswerCheckingState() { return _answerCheckingState; }
}

    public class PreparingState : IProgramState
    {
        private Automat _automat;

        public PreparingState(Automat automat)
        {
            _automat = automat;
        }

        void SuggestExercise(MainForm view) { }
        void CheckAnswer(MainForm view) { }
        void SetSettings(MainForm view) { }
    }

    public class ExerciseSuggestedState : IProgramState
    {
        private Automat _automat;

        public ExerciseSuggestedState(Automat automat)
        {
            _automat = automat;
        }
        void SuggestExercise(MainForm view) { }
        void CheckAnswer(MainForm view) { }
        void SetSettings(MainForm view) { }
    }

    class AnswerCheckingState : IProgramState
    {
        private Automat _automat;

        public AnswerCheckingState(Automat automat)
        {
            _automat = automat;
        }
        void SuggestExercise(MainForm view) 
        {
            _presenter.ViewNewExercise();
        }
        void CheckAnswer(MainForm view) { }
        void SetSettings(MainForm view) { }        
    }


