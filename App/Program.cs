using System;
using System.Collections.Generic;
using App.Models;
using App.Services;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            Parser parser = new Parser(@"/app/input.txt");
            List<Guest> guests = parser.parseGuests();
            
            WeddingService weddingService = new WeddingService();
            int dayIndexWhenEveryoneCanCome = weddingService.dayIndexWhenEveryoneCanCome(guests);

            if (dayIndexWhenEveryoneCanCome != 0)
            {
                Console.WriteLine("What a luck!");
                Console.WriteLine("Day index when everyone can come to the wedding: " + dayIndexWhenEveryoneCanCome);   
            }
            else
            {
                Console.WriteLine("Guests are busy people, not everyone can come :(");   
            }
        }
    }
}