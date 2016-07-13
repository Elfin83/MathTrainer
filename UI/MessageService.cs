using System.Drawing;
using System.Windows.Forms;

namespace MathTrainer
{
    public interface IMessageService
    {
        void ShowError();
        void TimeIsUpMessage(string exerciseAnswer);
        void WrongAnswerMessage(string exerciseAnswer);
        void CorrectAnswerMessage(string exerciseAnswer);
    }

    public class MessageService : IMessageService
    {
        Form _ownerForm;

        public MessageService(MainForm view)
        {
            _ownerForm = view;
        }

        public void ShowError()
        {
            MessageBox.Show("Пожалуйста, введите ответ.");
        }

        public void TimeIsUpMessage(string exerciseAnswer)
        {
            CheckerForm chForm = NewCheckerForm();
            chForm.IsCorrectLabelText = "Время вышло.\nОтвет:";
            chForm.IsCorrectLableColor = "Red";
            chForm.ExerciseAnswer = exerciseAnswer;
            chForm.ShowDialog();
        }

        public void WrongAnswerMessage(string exerciseAnswer)
        {
            CheckerForm chForm = NewCheckerForm();
            chForm.IsCorrectLabelText = "Неверно!\nОтвет:";
            chForm.IsCorrectLableColor = "Red";
            chForm.ExerciseAnswer = exerciseAnswer;
            chForm.ShowDialog();
        }

        public void CorrectAnswerMessage(string exerciseAnswer)
        {
            CheckerForm chForm = NewCheckerForm();
            chForm.IsCorrectLabelText = "Верно!";
            chForm.IsCorrectLableFont = new Font("Tahoma", 36);
            chForm.IsCorrectLableSize = new Size(284, 150);
            chForm.IsCorrectLableColor = "LimeGreen";
            
            chForm.ShowDialog();
        }

        private CheckerForm NewCheckerForm()
        {
            CheckerForm chForm = new CheckerForm();
            chForm.StartPosition = FormStartPosition.Manual;
            chForm.DesktopLocation = new Point(_ownerForm.DesktopLocation.X + 500, _ownerForm.DesktopLocation.Y);            
            return chForm;
        }

    }
}
