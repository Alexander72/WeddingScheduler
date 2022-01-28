using System;
using System.Collections.Generic;

namespace App.Models
{
    public class Guest
    {
        private string name;
        private List<int> workingWeekDayIndexes;

        public Guest(string name, List<int> workingWeekDayIndexes) 
        {
            this.name = name;
            this.workingWeekDayIndexes = workingWeekDayIndexes;
        }

        public Boolean isWorkingAt(int weekDayIndex) 
        {
            return  workingWeekDayIndexes.Contains(weekDayIndex);
        }

        public string getName()
        {
            return name;
        }
    }
}