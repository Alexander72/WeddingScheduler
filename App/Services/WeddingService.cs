using System;
using System.Collections.Generic;
using App.Models;

namespace App.Services
{
    public class WeddingService
    {
        private static readonly int[] WEEK_DAYS = {
            7, 6, 5, 4, 3, 2, 1
        };
        
        public int dayIndexWhenEveryoneCanCome(List<Guest> guests)
        {
            foreach (var weekDay in WEEK_DAYS)
            {
                bool everyoneCanCome = true;
                foreach (var guest in guests)
                {
                    if (guest.isWorkingAt(weekDay))
                    {
                        everyoneCanCome = false;
                    }
                }

                if (everyoneCanCome)
                {
                    return weekDay;
                }
            }

            return 0;
        }

        public List<Guest> getTheMostInconvenientGuests(List<Guest> guests)
        {
            var guestsWorkingDaysMatrix = buildGuestsWorkingDaysMatrix(guests);

            int minimumBusyPeopleAmount = Int32.MaxValue;
            int dayIndexWithMinimumBusyPeople = 0;
            
            foreach (var entry in guestsWorkingDaysMatrix)
            {
                if (entry.Value.Count < minimumBusyPeopleAmount)
                {
                    minimumBusyPeopleAmount = entry.Value.Count;
                    dayIndexWithMinimumBusyPeople = entry.Key;
                }
            }
            
            return guestsWorkingDaysMatrix[dayIndexWithMinimumBusyPeople];
        }

        private static Dictionary<int, List<Guest>> buildGuestsWorkingDaysMatrix(List<Guest> guests)
        {
            Dictionary<int, List<Guest>> guestsWorkingDaysMatrix = new Dictionary<int, List<Guest>>();

            foreach (var weekDay in WEEK_DAYS)
            {
                if (!guestsWorkingDaysMatrix.ContainsKey(weekDay))
                {
                    guestsWorkingDaysMatrix.Add(weekDay, new List<Guest>());
                }

                foreach (var guest in guests)
                {
                    if (guest.isWorkingAt(weekDay))
                    {
                        guestsWorkingDaysMatrix[weekDay].Add(guest);
                    }
                }
            }

            return guestsWorkingDaysMatrix;
        }
    }
}