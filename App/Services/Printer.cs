using System;
using System.Collections.Generic;
using App.Models;

namespace App.Services
{
    public class Printer
    {
        public void printSuccessfulScenario(int dayIndexWhenEveryoneCanCome)
        {
            Console.WriteLine("What a luck!");
            Console.WriteLine("Day index when everyone can come to the wedding: " + dayIndexWhenEveryoneCanCome);   
        }

        public void printInconvinientGuests(List<Guest> inconvinientGuests)
        {
            Console.WriteLine("Guests are busy people, not everyone can come :(");
            Console.WriteLine("Maybe we should not invite:");
            foreach (var inconvenientGuest in inconvinientGuests)
            {
                Console.WriteLine(inconvenientGuest.getName());
            }
        }
    }
}