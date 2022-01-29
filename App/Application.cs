using System;
using System.Collections.Generic;
using App.Models;
using App.Services;

namespace App
{
    public class Application
    {
        private const string INPUT_FILE_PATH = @"/app/input.txt";
        
        private Parser parser;
        
        private WeddingService weddingService;

        public Application(Parser parser, WeddingService weddingService)
        {
            this.parser = parser;
            this.weddingService = weddingService;
        }

        public void run()
        {
            List<Guest> guests;
            
            try
            {
                guests = parser.parseGuests(INPUT_FILE_PATH);
            }
            catch
            {
                Console.WriteLine("Invalid input file.");
                return;
            }
            
            int dayIndexWhenEveryoneCanCome = weddingService.dayIndexWhenEveryoneCanCome(guests);

            if (dayIndexWhenEveryoneCanCome != 0)
            {
                Console.WriteLine("What a luck!");
                Console.WriteLine("Day index when everyone can come to the wedding: " + dayIndexWhenEveryoneCanCome);   
            }
            else
            {
                Console.WriteLine("Guests are busy people, not everyone can come :(");
                Console.WriteLine("Maybe we should not invite:");
                List<Guest> inconvenientGuests = weddingService.getTheMostInconvenientGuests(guests);
                foreach (var inconvenientGuest in inconvenientGuests)
                {
                    Console.WriteLine(inconvenientGuest.getName());
                }
            }
        }
    }
}