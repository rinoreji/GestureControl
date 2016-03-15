using System.Diagnostics;

namespace GestureControl
{
    class ProcessExecutor : IExecutable
    {
        public void Execute(string param)
        {
            StartProcess(param);
        }

        void StartProcess(string cmd)
        {
            Process p = new Process();
            p.StartInfo = new ProcessStartInfo(cmd);
            p.Start();
        }
    }
}
