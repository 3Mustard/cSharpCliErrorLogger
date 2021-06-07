﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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
            int i = 0;

            foreach (Error error in errors)
            {
                Console.WriteLine($"{i}. {error.Message} ~ Date: {error.Date}");
                i += 1;
            }
        }

        public void LogNewError(string error, DateTime date)
        {
            List<string> lines = ReadFile();
            string fDate = date.ToString();

            string err = $"{fDate} ~ {error}";

            lines.Add(err);
            File.WriteAllLines(FilePath, lines);
            Console.WriteLine($"Error Logged at {fDate}");
        }

        private List<Error> CreateErrorObjects()
        {
            List<Error> errors = new List<Error>();
            List<string> lines = ReadFile();

            foreach (string line in lines)
            {
                string[] err = line.Split("~");

                Error newError = new Error();

                newError.Date = err[0];
                newError.Message = err[1];

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