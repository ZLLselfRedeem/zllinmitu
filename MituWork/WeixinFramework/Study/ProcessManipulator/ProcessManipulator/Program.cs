using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace ProcessManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("****** Fun with Processes *****\n");
            //ListAllRunningProcess();
            //Console.WriteLine("***** Enter PID of process to investigate");
            //Console.Write("PID: ");
            //string pID = Console.ReadLine();
            //int theProcId = int.Parse(pID);
            //EnumModsForPid(theProcId);
            //GetSpecificProcess();
            StartAndKillProcess();
            Console.ReadLine();
        }

        static void EnumThreadsForPid(int pID)
        {
            Process theProc = null;
            try
            {
                theProc = Process.GetProcessById(pID);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            Console.WriteLine("Here are the threads used by: {0}", theProc.ProcessName);
            ProcessThreadCollection theThreads = theProc.Threads;
            foreach (ProcessThread pt in theThreads)
            {
                string info = string.Format("-> Thread ID: {0}\tStart Time: {1}\tPriority: {2}", 
                    pt.Id, pt.StartTime.ToShortTimeString(), pt.PriorityLevel);
                Console.WriteLine(info);
            }
            Console.WriteLine("*****************************************");
        }

        static void GetSpecificProcess() 
        {
            Process theProc = null;
            try
            {
                theProc = Process.GetProcessById(987);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Continue");
        }

        static void ListAllRunningProcess() 
        {
            var runningProcs = from proc in Process.GetProcesses(".")
                              orderby proc.Id
                              select proc;
            foreach (var p in runningProcs)
            {
                string info = string.Format("->PID: {0}\tName: {1}", p.Id, p.ProcessName);
                Console.WriteLine(info);
            }
            Console.WriteLine("**************************************\n");
        }

        static void EnumModsForPid(int pID)
        {
            Process theProc = null;
            try
            {
                theProc = Process.GetProcessById(pID);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Here are thr loaded module for: {0}", theProc.ProcessName);
            ProcessModuleCollection theMods = theProc.Modules;
            foreach(ProcessModule pm in theMods)
            {
                string info = string.Format("-> Mod Name: {0}", pm.ModuleName);
                Console.WriteLine(info);
            }
            Console.WriteLine("***********************************\n");
        }

        static void StartAndKillProcess() 
        {
            Process ieProc = null;
            try
            {
                //ieProc = Process.Start("IExplore.exe", "www.baidu.com");
                ProcessStartInfo startInfo = new ProcessStartInfo("IExplore.exe", "www.baidu.com");
                startInfo.WindowStyle = ProcessWindowStyle.Maximized;

                ieProc = Process.Start(startInfo);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.Write("-->Hit enter to kill{0}...", ieProc.ProcessName);
            Console.ReadLine();

            try
            {
                ieProc.Kill();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
