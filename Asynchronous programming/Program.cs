using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Asynchronous_programming
{
    internal class Program
    {
        public delegate void Notify();  // delegate
        public event Notify myevent;
        public static void EnumeratingProcess()
        {


            var runningProcess = from proc in Process.GetProcesses() orderby proc.Id select proc;

            foreach (var p in runningProcess)
            {
                string info = $"-> PID: {p.Id} and name {p.ProcessName}";


                Console.WriteLine(info);

            }

            KillProcess();


        }

        public static void Startprocess()
        {
            Process proc = null;
            try
            {
                Console.WriteLine("Paste path to exe file or url");

                string enter_path = Console.ReadLine();
                Console.WriteLine("enter file or url name");
                string enter_file = Console.ReadLine();

                string Mypath = @"^(([^\s]|(\\ ))*)(?<!\\).*$";


                Regex regex = new(Mypath);

                if (regex.IsMatch(enter_path))
                {
                    Process.Start(enter_path, enter_file);
                }

            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void KillProcess()
        {
            try
            {
                Console.WriteLine("enter process name to kill");
                var enter_process = Console.ReadLine();
                var KillProcess = Process.GetProcesses().Where(pr => pr.ProcessName == enter_process);

                foreach (var proc in KillProcess)
                {
                    proc.Kill();
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("start new process");
            Startprocess();
        }
        public static void CreateProcess(string fileName)
        {
            Process newProcess = new();
            newProcess.StartInfo.FileName = fileName;

            Console.WriteLine($"\n\t Successfully created and added {fileName} process!");
            EnumeratingProcess();
        }

        public static void CreateThread()
        {

            Thread thread = new Thread(Threads);
            Console.WriteLine("Is background thread: {0}", thread.IsBackground = true);



            thread.Start();
            Console.WriteLine("Quitting background");
            Console.WriteLine("Is background thread: {0}", thread.IsBackground = false);

        }
        public static void Threads()
        {

            int count = 10;

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("Counting thread {0}", i);
                Thread.Sleep(1000);
            }


        }

        static void Main(string[] args)
        {

            Console.WriteLine("press 1 to list task 2 to start new task, 3 to create process, 4 to create thread");
            var enter_task = Console.ReadLine();
            while (true)
            {
                if (enter_task != null)
                {
               
                        switch (enter_task)
                        {
                            case "1":
                                EnumeratingProcess();
                                break;
                            case "2":
                                Startprocess();
                                break;
                            case "3":
                                CreateProcess("bishop");

                                break;
                            case "4":
                                CreateThread();
                                break;
                            default: Console.WriteLine("Invalid selection");
                                continue;
                        }
                   
                 }
                break;
            }

        }
    }
}