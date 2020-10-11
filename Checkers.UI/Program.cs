using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C20_Ex05_Oz_203596275
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            WindowsFormUI checkersGame = new WindowsFormUI();
            checkersGame.LaunchGame();
        }
    }
}
