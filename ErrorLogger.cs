using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

// HOW TO ADD/REMOVE PARAMS:
// 1. UPDATE ERROR CLASS
// 2. ADD NEW PARAMS TO THESE METHODS `LOGNEWERROR, LOGALLNEWERRORS, CREATEERROROBJECTS, DISPLAYERRORSTOCONSOLE`
namespace ErrorLoggerApp
{
    class ErrorLogger
    {
        private string FilePath { get; set; }

        public ErrorLogger(string filePath)
        {
            FilePath = filePath;
        }

        public void DisplayErrorsToConsole()
        {
            List<Error> errors = CreateErrorObjects();
            int i = 1;

            foreach (Error error in errors)
            {
                // UPDATE ERROR LOG MSG HERE
                Console.WriteLine($"{i}. {error.Date}: {error.Message}");
                i += 1;
            }
        }

        public void LogNewError(Error error)
        {
            List<string> lines = ReadFile();

            // ADD NEW PARAMETERS HERE
            // PUT " ~ " BETWEEN EACH NEW PARAM 
            // EX $"{x} ~ {y} ~ {z}";
            string newLine = $"{error.Date} ~ {error.Message}";

            lines.Add(newLine);
            File.WriteAllLines(FilePath, lines);
            Console.WriteLine($"ERROR LOGGED");
        }

        public void LogAllNewErrors(List<Error> errors)
        {
            List<string> lines = ReadFile();
            int counter = 0;

            foreach (Error error in errors)
            {
                // ADD NEW PARAMETERS HERE
                // PUT " ~ " BETWEEN EACH NEW PARAM 
                // EX $"{x} ~ {y} ~ {z}";
                string newLine = $"{error.Date} ~ {error.Message}";

                lines.Add(newLine);
                counter += 1;
            }

            File.WriteAllLines(FilePath, lines);
            Console.WriteLine($"{counter} ERRORS LOGGED");
        }

        private List<Error> CreateErrorObjects()
        {
            List<Error> errors = new List<Error>();
            List<string> lines = ReadFile();

            foreach (string line in lines)
            {
                string[] err = line.Split("~");

                Error newError = new Error();

                // ADD NEW PARAMETERS HERE WITH INDEX err[i]
                newError.Date = err[0].Trim();
                newError.Message = err[1].Trim();
                errors.Add(newError);
            }

            return errors;
        }

        private List<string> ReadFile()
        {
            return File.ReadAllLines(FilePath).ToList();
        }
    }

    class Error
    {
        public string Date { get; set; }
        public string Message { get; set; }
    }
}
