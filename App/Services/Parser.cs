using System;
using System.Collections.Generic;
using System.Linq;
using App.Models;

namespace App.Services
{
    public class Parser
    {
        string inputFileName;

        public Parser(string inputFileName)
        {
            this.inputFileName = inputFileName;
        }

        public List<Guest> parseGuests()
        {
            List<Guest> guests = new List<Guest>();
 
            foreach (string line in System.IO.File.ReadLines(inputFileName))
            {
                string[] lineParts = line.Split(':');
                
                string name = lineParts[0];
                string workingWeekdayIndexesString = lineParts[1].Trim();
                
                List<int> workingWeekdayIndexes = workingWeekdayIndexesString.Split(' ').Select(Int32.Parse).ToList();
                
                guests.Add(new Guest(name, workingWeekdayIndexes));
            } 
            
            return guests;
        }
    }
}