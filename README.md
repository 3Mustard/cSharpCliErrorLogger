# CSharp Error logger 
Write errors to desired filepath and read filepath to display errors in the console
# EXAMPLE OF USE
```
string filePath = System.IO.Path.GetFullPath(@"..\logs.txt");

ErrorLogger eLogger = new ErrorLogger(filePath);

string errorMsg = "new error";

DateTime date = DateTime.UtcNow;

eLogger.LogNewError(errorMsg, date);

eLogger.DisplayErrorsToConsole();
```
# HOW TO ADD/REMOVE PARAMS:
1. UPDATE ERROR CLASS
2. ADD NEW PARAMS TO THESE METHODS LOGNEWERRORS, CREATEERROROBJECTS, DISPLAYERRORS TO CONSOLE
