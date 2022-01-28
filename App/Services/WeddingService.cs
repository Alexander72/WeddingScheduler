using System;
using System.Collections.Generic;
using App.Models;

namespace App.Services
{
    public class WeddingService
    {
        public int dayIndexWhenEveryoneCanCome(List<Guest> guests)
        {
            int[] weekDays = new int[7] {1, 2, 3, 4, 5, 6, 7};
            foreach (var weekDay in weekDays)
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
    }
}