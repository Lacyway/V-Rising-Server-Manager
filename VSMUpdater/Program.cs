using System.Diagnostics;
using System.IO.Compression;

Console.WriteLine("Ready to download latest version.");
Console.WriteLine("Press any key to start...");
Console.ReadLine();

Process[] vsmProcesses = Process.GetProcessesByName("VRisingServerManager");
if (vsmProcesses.Length != 0)
{
    Console.WriteLine("An instance of 'VRisingServerManager' was found. Please exit VSM before updating.");
    Console.WriteLine("Press any key to exit...");
    Console.ReadKey();
    Environment.Exit(2);
}

string workingDir = AppDomain.CurrentDomain.BaseDirectory;
HttpClient httpClient = new();

if (!File.Exists(workingDir + @"\VRisingServerManager.exe"))
{
    Console.WriteLine("Unable to find 'VRisingServermanager.exe' in root directory. Make sure the app is installed correctly.");
    Console.ReadKey();
    Environment.Exit(2);
}

Console.WriteLine("Starting update of VSM.");
Console.WriteLine("Downloading files...");

byte[] fileBytes = await httpClient.GetByteArrayAsync(@"https://github.com/Lacyway/V-Rising-Server-Manager/releases/latest/download/VSM.zip");
Console.WriteLine("Done.");

if (Directory.Exists(workingDir + @"\temp"))
    Directory.Delete(workingDir + @"\temp", true);

Directory.CreateDirectory(workingDir + @"\temp");

await File.WriteAllBytesAsync(workingDir + @"\temp\VSM.zip", fileBytes);

Console.WriteLine();

Console.WriteLine("Creating backup of settings.");
if (!Directory.Exists(workingDir + @"\Backups"))
    Directory.CreateDirectory(workingDir + @"\Backups");

if (File.Exists(workingDir + @"\VSMSettings.json"));
    File.Copy(workingDir + @"\VSMSettings.json", workingDir + @"\Backups\VSMSettings.bak", true);

Console.WriteLine();

ZipFile.ExtractToDirectory(workingDir + @"\temp\VSM.zip", workingDir + @"\temp", true);

Console.WriteLine("Copying new files...");
string[] files = Directory.GetFiles(workingDir + @"\temp");

foreach (string file in files)
{
    string fileName = Path.GetFileName(file);    
    if (fileName != "VSMUpdater.exe" && fileName != "VSM.zip")
    {
        Console.WriteLine("Copying: " + fileName);
        File.Copy(file, workingDir + fileName, true);
    }
}

if (Directory.Exists(workingDir + @"\temp"))
    Directory.Delete(workingDir + @"\temp", true);

Console.WriteLine();
Console.WriteLine(@"Update done. Backup of the VSMSettings can be found in the \Backups folder.");
Console.WriteLine("Press any key to finish...");
Console.ReadKey();

Process.Start("VRisingServerManager.exe");

Environment.Exit(0);