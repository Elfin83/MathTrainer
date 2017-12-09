using System;
using System.Windows.Forms;

namespace MathTrainer
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MainForm view = new MainForm();
            MessageService messageService = new MessageService(view);
            Settings settings = new Settings(); 
            Presenter presenter = new Presenter(view, settings, messageService);            
            Application.Run(view);
        }
    }
}
