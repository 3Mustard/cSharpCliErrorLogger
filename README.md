# CSharp Error logger 
Write errors to desired filepath and read filepath to display errors in the console
# EXAMPLE OF USE
```
            string filePath = System.IO.Path.GetFullPath(@"..\logs.txt");
            ErrorLogger eLogger = new ErrorLogger(filePath);

            DateTime date = DateTime.UtcNow;

            Error err = new Error();
            Error err2 = new Error();
            Error err3 = new Error();
            err.Message = "new error message 1";
            err.Date = DateTime.UtcNow.ToString();
            err2.Message = "new error message 2";
            err2.Date = DateTime.UtcNow.ToString();
            err3.Message = "new error message 3";
            err3.Date = DateTime.UtcNow.ToString();

            List<Error> errors = new List<Error>();
            errors.Add(err2);
            errors.Add(err3);

            eLogger.LogNewError(err);
            eLogger.LogAllNewErrors(errors);
            eLogger.DisplayErrorsToConsole();
```
# HOW TO ADD/REMOVE PARAMS:
1. UPDATE ERROR CLASS
2. ADD NEW PARAMS TO THESE METHODS LOGNEWERRORS, LOGALLNEWERRORS, CREATEERROROBJECTS, DISPLAYERRORSTOCONSOLE
