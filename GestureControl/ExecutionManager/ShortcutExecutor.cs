using Forms = System.Windows.Forms;

namespace GestureControl
{
    class ShortcutExecutor : IExecutable
    {
        public void Execute(string param)
        {
            Forms.SendKeys.SendWait(param);
        }
    }
}
