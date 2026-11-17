using Microsoft.Extensions.Configuration; //    To use ConfigurationBuilder.
using System.Diagnostics; //    To use Debug and Trace.

string logPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), "log.txt");
Console.WriteLine($"Writing to: {logPath}.");
TextWriterTraceListener logFile = new(File.CreateText(logPath));
Trace.Listeners.Add(logFile);
#if DEBUG
//  Text writer is buffered, so this option calls
//  Flush() on all listeners after writing.
Trace.AutoFlush = true;
#endif

Debug.WriteLine("Debug says, I am watching!");
Trace.WriteLine("Trace says, I am watching!");

string settingsFile = "appSettings.json";
string settingsPath = Path.Combine(Directory.GetCurrentDirectory(), settingsFile);
WriteLine("Processing: {0}", settingsPath);
WriteLine("Processing: {0}", settingsFile);
WriteLine(File.ReadAllText(settingsPath));
WriteLine("----");
ConfigurationBuilder builder = new();
builder.SetBasePath(Directory.GetCurrentDirectory());
//  Add the settings file to the processed configuration and make it
//  mandatory so an exception will be thrown if the file is not found.
builder.AddJsonFile(settingsFile, optional: false, reloadOnChange: true);
IConfigurationRoot configuration = builder.Build();
TraceSwitch ts = new(displayName: "PacktSwitch", description: "This switch is set via JSON config.");
configuration.GetSection("PacktSwitch").Bind(ts);
WriteLine($"Trace switch value: {ts.Value}");
WriteLine($"Trace switch level: {ts.Value}");
Trace.WriteLine(ts.TraceError, "Trace error");
Trace.WriteLine(ts.TraceWarning, "Trace warning");
Trace.WriteLine(ts.TraceInfo, "Trace information");
Trace.WriteLine(ts.TraceVerbose, "Trace verbose");

int unitsInStock = 12;
LogSourceDetails(unitsInStock > 10);

//  Close the text file (also flushes) and release resources.
Debug.Close();
Trace.Close();

WriteLine("Press Enter to exit.");
Console.ReadLine();
