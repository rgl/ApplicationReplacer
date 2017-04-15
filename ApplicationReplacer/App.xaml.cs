using System;
using System.Diagnostics;
using System.Linq;
using System.Windows;

namespace ApplicationReplacer
{
    public partial class App : Application
    {
        [STAThread]
        public static int Main(string[] args)
        {
            if (args.Length == 0)
            {
                var app = new App();
                app.InitializeComponent();
                return app.Run();
            }

            if (args[0] != "--")
            {
                MessageBox.Show(
                    string.Format(
                        "The application is misconfigured, the first argument must be --.\n\nThe application arguments were:\n\n{0}",
                        string.Join("\n\n", args)),
                    "ApplicationReplacer Configuration Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                return 1;
            }

            // Assuming Windows is configured with:
            //
            //      New-Item -Force -Path 'HKLM:\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\notepad.exe' `
            //          | Set-ItemProperty `
            //              -Name Debugger `
            //              -Value '"C:\Program Files\ApplicationReplacer\ApplicationReplacer.exe" -- "C:\Program Files\Notepad++\notepad++.exe"'
            //
            // Our application will be called with the following arguments:
            //
            //      args[0]: --
            //      args[1]: C:\Program Files\Notepad++\notepad++.exe
            //      args[2]: C:\Windows\System32\notepad.exe
            //      args[*]: notepad arguments, normally, a path to the file to open.

            var p = Process.Start(
                args[1],
                args.Skip(3).ToCommandLine());
            p.Dispose();

            return 0;
        }
    }
}
