using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ArenaChessGameAnalyzerRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string[] nonCmdCodeArgs = args.Skip(1).ToArray();
                switch ((CmdCode)Enum.Parse(typeof(CmdCode), args[0]))
                {
                    case CmdCode.Done:
                        createDoneFile(nonCmdCodeArgs);
                        break;
                    case CmdCode.Single:
                        singleProcess();
                        break;
                    case CmdCode.Service:
                        simulateService();
                        break;
                    case CmdCode.Analyze:
                        analyzePgn(nonCmdCodeArgs);
                        break;
                    default:
                        Console.WriteLine("Invalid CmdCode: " + args[0] + " | Expecting: " + String.Join(", ", Enum.GetNames(typeof(CmdCode))));
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        static void createDoneFile(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine("Expecting {PGN File} argument");
            }
            else
            {
                var pgnInfo = new FileInfo(args[0]);
                var doneFile = pgnInfo.DirectoryName + @"\" + Path.GetFileNameWithoutExtension(pgnInfo.FullName) + ".done";
                File.WriteAllText(doneFile, DateTime.Now.ToString());
            }
        }

        static void singleProcess()
        {
            //create directories if they don't exist
            Directory.CreateDirectory(Settings.DropFolder);
            Directory.CreateDirectory(Settings.ErrorFolder);
            Directory.CreateDirectory(Settings.PickupFolder);

            //load PGN in pickup directory
            Console.WriteLine("Looking for PGN files: " + Settings.PickupFolder);
            string[] files = Directory.GetFiles(Settings.PickupFolder, "*.pgn", SearchOption.AllDirectories);
            foreach (var file in files)
            {
                //create model
                var model = new AnalyzerModel()
                {
                    AnlysCli = new FileInfo(Settings.AnalysisExe),
                    ArenaInfo = new FileInfo(Settings.ArenaExe),
                    EcoInfo = new FileInfo(Settings.EcoFile),
                    SecondsPerMove = Settings.SecondsPerMove
                };
                model.PgnInfo = new FileInfo(file);

                //check pickup sub-folder
                string pickupSubFolder = model.PgnInfo.Directory.FullName.Replace(Settings.PickupFolder, "");
                if (String.IsNullOrEmpty(pickupSubFolder))
                {
                    //move to one so we have a spot to store additional files
                    pickupSubFolder = Path.GetFileNameWithoutExtension(model.PgnInfo.FullName);
                    string newDirectory = Settings.PickupFolder + "\\" + pickupSubFolder;

                    //check if it already exists
                    if (Directory.Exists(newDirectory))
                        newDirectory += "_" + DateTime.Now.ToString("MMM-dd-yyyy_hh-mm-ss");
                    string newPath = newDirectory + "\\" + model.PgnInfo.Name;

                    //move to newly created folder
                    Directory.CreateDirectory(newDirectory);
                    File.Move(model.PgnInfo.FullName, newPath);
                    model.PgnInfo = new FileInfo(newPath);
                }

                //base output folder
                Console.WriteLine("Working on PGN: " + model.PgnInfo.FullName);
                var destDir = new DirectoryInfo(Settings.DropFolder);
                for (int i = 1; i <= Settings.RetryCount; i++)
                {
                    //delete miscellaneous files
                    string[] extsToDelete = new string[] { ".done", ".error", ".good", ".log", ".rep" };
                    foreach (var ext in extsToDelete)
                        File.Delete(model.PgnInfo.Directory.FullName + "\\" + Path.GetFileNameWithoutExtension(model.PgnInfo.FullName) + ext);

                    //run analysis
                    runAnalyser(model);

                    //determine output folder
                    if (Directory.EnumerateFiles(model.PgnInfo.Directory.FullName, "*.error").Any())
                        destDir = new DirectoryInfo(Settings.ErrorFolder);
                    else
                    {
                        destDir = new DirectoryInfo(Settings.DropFolder);
                        break;
                    }
                }

                //determine Sub-folder
                string subFolder = model.PgnInfo.Directory.FullName.Replace(Settings.PickupFolder, "");
                var dropDir = destDir.FullName + "\\" + subFolder;
                Directory.CreateDirectory(dropDir);

                //move all file over to drop folder
                Console.Write("Moving Analysis PGN to: " + dropDir);
                foreach (var oFile in Directory.EnumerateFiles(model.PgnInfo.Directory.FullName, "*.*", SearchOption.AllDirectories))
                {
                    string relativeRoot = oFile.Replace(model.PgnInfo.Directory.FullName, "");
                    var destinationFile = new FileInfo(dropDir + "\\" + relativeRoot);
                    Directory.CreateDirectory(destinationFile.Directory.FullName);
                    File.Move(oFile, destinationFile.FullName);
                }
                Directory.Delete(model.PgnInfo.Directory.FullName, true);
                Console.WriteLine("PGN Analysis Complete");
            }
        }

        static void simulateService()
        {
            //service mode
            while (true)
            {
                //setup call to run a single iteration of the service
                string callExe = Application.ExecutablePath;
                string callArgs = "single";

                Console.WriteLine("Running Single Service: " + callExe + " " + callArgs);
                var proc = Process.Start(callExe, callArgs);
                proc.WaitForExit();

                Console.WriteLine("Sleeping for 10mins");
                Thread.Sleep(1000 * 60 * Settings.ServiceSleepIntervalMinutes); //10 min delay
            }
        }

        static void analyzePgn(string[] args)
        {
            if (args.Length < 5)
                Console.WriteLine("Expecting 5 arguments: {PGN File} {Eco Codes} {ArenaChess Engine Path} {Analyzer Path} {Seconds per move}");
            else
                //analyze PGN
                runAnalyser(new AnalyzerModel()
                {
                    PgnInfo = new FileInfo(args[0]),
                    EcoInfo = new FileInfo(args[1]),
                    ArenaInfo = new FileInfo(args[2]),
                    AnlysCli = new FileInfo(args[3]),
                    SecondsPerMove = int.Parse(args[4])
                });
        }

        private static void runAnalyser(AnalyzerModel model)
        {
            //file information
            var pgnInfo = model.PgnInfo;
            var ecoInfo = model.EcoInfo;
            var arenaInfo = model.ArenaInfo;
            var anlysCli = model.AnlysCli;
            int secondsPerMove = model.SecondsPerMove;

            //step one, get starting move number
            Console.WriteLine("Finding starting move number");
            int startMove = loadStartingMove(anlysCli, ecoInfo, pgnInfo);

            //simulate arena chess movements
            Console.WriteLine("Analyzing PGN");
            var arenaProcess = arenaRunner(arenaInfo, pgnInfo, startMove, secondsPerMove);

            //wait for completed file
            string baseFile = pgnInfo.DirectoryName + @"\" + Path.GetFileNameWithoutExtension(pgnInfo.FullName);
            string doneFile = baseFile + ".done";
            while (!File.Exists(doneFile))
                Thread.Sleep(10000); //10 second interval
            Thread.Sleep(5000); //sleep again in case end and interval line up, let analysis complete

            //close arena
            Console.WriteLine("Shutting down program");
            arenaDowner(arenaProcess);

            //start up analysis
            string logFile = baseFile + ".log";
            string rptFile = baseFile + ".rep";
            string analysisCmdLine = $"Analysis \"{ecoInfo.FullName}\" \"{pgnInfo.FullName}\" \"{rptFile}\" \"{logFile}\"";
            Console.WriteLine("Analyzing Arena Report: " + anlysCli.FullName + " " + analysisCmdLine);

            var anlsInfo = new ProcessStartInfo(anlysCli.FullName, analysisCmdLine);
            anlsInfo.UseShellExecute = false;
            anlsInfo.RedirectStandardOutput = true;
            var anlsProc = Process.Start(anlsInfo);
            anlsProc.WaitForExit(1000 * 60 * 1); //1 min

            //check result to see if we passed or failed
            var anlsOutput = anlsProc.StandardOutput.ReadToEnd().Split('\r').Select(f => f.Trim(' ', '\n')).ToList();
            anlsOutput.ForEach(f => Console.WriteLine(f));
            if (anlsOutput.Any(f => f.StartsWith("Error")))
                File.WriteAllText(baseFile + ".error", String.Join(System.Environment.NewLine, anlsOutput.Where(f => f.StartsWith("Error"))));
            else
                File.WriteAllText(baseFile + ".good", DateTime.Now.ToString());
        }

        private static int loadStartingMove(FileInfo analysisInfo, FileInfo ecoInfo, FileInfo pgnInfo)
        {
            //analysis line for eco code
            string cmdLineArgs = $"LastEco \"{ ecoInfo.FullName }\" \"{ pgnInfo.FullName }\"";
            Console.WriteLine(analysisInfo.FullName + " " + cmdLineArgs);

            //run program
            var cliInfo = new ProcessStartInfo(analysisInfo.FullName, cmdLineArgs);
            cliInfo.CreateNoWindow = false;
            cliInfo.RedirectStandardOutput = true;
            cliInfo.UseShellExecute = false;
            var cliProc = Process.Start(cliInfo);
            cliProc.WaitForExit(60000);

            //write to console
            var cliOutput = cliProc.StandardOutput.ReadToEnd().Split('\r').Select(f => f.Trim(' ', '\n')).ToList();
            string line = cliOutput[cliOutput.Count - 2];
            Console.WriteLine("Last ECO Code");
            cliOutput.ForEach(f => Console.WriteLine(f));

            //starting move for arena chess engine
            int startMove = int.Parse(line.Split(':')[1].Trim());
            return startMove;
        }

        private static void arenaDowner(Process arenaProcess)
        {
            //shutdown program
            SetForegroundWindow(arenaProcess.MainWindowHandle);
            SendKeys.SendWait("{TAB 6}");
            SendKeys.SendWait("{ENTER}"); //close out of analysis
            Thread.Sleep(1000); //wait for dialog close
            SendKeys.SendWait("%FE");
            Thread.Sleep(2000); //wait for dialog open
            SendKeys.SendWait("{TAB 2}");
            SendKeys.SendWait("{ENTER}");
            Thread.Sleep(5000); //wait for program to completely close
        }

        private static Process arenaRunner(FileInfo arenaInfo, FileInfo pgnInfo, int startingMove, int secondsPerMove)
        {
            LockSetForegroundWindow(2);
            AllowSetForegroundWindow(Process.GetCurrentProcess().MainWindowHandle);

            //start program
            Console.WriteLine("Starting Program: " + arenaInfo.FullName);
            var chessInfo = new ProcessStartInfo(arenaInfo.FullName);
            chessInfo.UseShellExecute = true;
            var chessProc = Process.Start(chessInfo);
            char[] specialKeys = new char[] { '+', '^', '%' }; //SHIFT, CTRL, ALT

            //wait for it to load, easy way
            Console.WriteLine("Loading Program");
            Thread.Sleep(10000);
            SetForegroundWindow(chessProc.MainWindowHandle);
            Thread.Sleep(1000);

            //load PGN
            Console.WriteLine("Loading PGN file");
            SetForegroundWindow(chessProc.MainWindowHandle);
            Thread.Sleep(1000);

            SendKeys.SendWait("{F3}"); //open file
            Thread.Sleep(2000); //wait for dialog
            foreach (var c in pgnInfo.FullName) //type path to file
            {
                SendKeys.SendWait(specialKeys.Contains(c) ? $"{{{ c.ToString() }}}" : c.ToString());
                Thread.Sleep(10);
            }
            SendKeys.SendWait("{ENTER}"); //load file
            Thread.Sleep(3000); //wait for dialog
            SendKeys.SendWait("{ENTER}"); //load first game
            Thread.Sleep(3000); //wait for file to load

            //set up analysis
            Console.WriteLine("Setting up analysis");
            SetForegroundWindow(chessProc.MainWindowHandle);
            Thread.Sleep(1000);

            SendKeys.SendWait("+^A");
            Thread.Sleep(2000); //wait for dialog
            SendKeys.SendWait("{TAB 10}"); //get to starting move
            SendKeys.SendWait(startingMove.ToString());
            SendKeys.SendWait("{TAB}");
            SendKeys.SendWait(Settings.LastMoveNumber.ToString()); //set ending move analysis
            SendKeys.SendWait("{TAB 2}"); //back to menu selection

            //set up analysis engine
            SendKeys.SendWait("{RIGHT}");
            SendKeys.SendWait("{TAB 5}"); //over to seconds per move
            SendKeys.SendWait(secondsPerMove.ToString()); //set x seconds per move
            SendKeys.SendWait("{TAB 3}"); //back to options

            //set up output
            SendKeys.SendWait("{RIGHT}");
            SendKeys.SendWait("{TAB 2}"); //move to protocol file (MUST BE ENABLED BY DEFAULT)
            string baseFile = pgnInfo.DirectoryName + @"\" + Path.GetFileNameWithoutExtension(pgnInfo.FullName);
            string logFile = baseFile + ".log";
            foreach (var c in logFile)
            {
                SendKeys.SendWait(specialKeys.Contains(c) ? $"{{{ c.ToString() }}}" : c.ToString());
                Thread.Sleep(10);
            }
            SendKeys.SendWait("{TAB 9}"); //move to comment
            SendKeys.SendWait("BOTH");
            SendKeys.SendWait("{TAB}");
            SendKeys.SendWait("{ENTER}"); //select button select name like protocol file
            SendKeys.SendWait("{TAB 3}");

            //set up options
            SendKeys.SendWait("{RIGHT}");
            SendKeys.SendWait("{TAB 5}"); //get to start program after analysis
            string myApp = Application.ExecutablePath + " Done \"" + pgnInfo.FullName + "\"";
            foreach (var c in myApp)
            {
                SendKeys.SendWait(specialKeys.Contains(c) ? $"{{{ c.ToString() }}}" : c.ToString());
                Thread.Sleep(10);
            }
            SendKeys.SendWait("{TAB 3}"); //back to options

            //start analysis
            SendKeys.SendWait("{LEFT 3}");
            SendKeys.SendWait("{TAB 5}");
            SendKeys.SendWait("{ENTER}");

            //give instance so we can stop it later
            Console.WriteLine("Analysis started");
            return chessProc;
        }

        [DllImport("user32.dll")]
        static extern bool LockSetForegroundWindow(uint uLockCode);

        [DllImport("user32.dll")]
        static extern bool AllowSetForegroundWindow(IntPtr dwProcessId);

        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);
    }
}
