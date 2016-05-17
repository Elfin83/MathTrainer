using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MathTrainer
{
    public interface IMessageService
    {

        void ShowError();
        void ShowAnswerForm(bool isCorrect, string exerciseAnswer);
    }
    public class MessageService : IMessageService
    {
        public MessageService()
        {
            
        }

        public void ShowError()
        {
            MessageBox.Show("Пожалуйста, введите ответ.");
        }

        public void ShowAnswerForm(bool isCorrect, string exerciseAnswer)
        {
            CheckerForm chForm = new CheckerForm();
            
            if (isCorrect)
            {
                chForm.IsCorrectLabelText = "Верно!";
                chForm.IsCorrectLableColor = "LimeGreen";
            }
            else
            {
                chForm.IsCorrectLabelText = "Неверно!";
                chForm.IsCorrectLableColor = "Red";
            }
            chForm.ExerciseAnswer = exerciseAnswer;
            chForm.ShowDialog();    
    }

    }
}
