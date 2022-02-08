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
        
        private Printer printer;

        public Application(
            Parser parser, 
            WeddingService weddingService,
            Printer printer
        )
        {
            this.parser = parser;
            this.weddingService = weddingService;
            this.printer = printer;
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

            if (dayIndexWhenEveryoneCanCome == 0)
            {
                List<Guest> inconvenientGuests = weddingService.getTheMostInconvenientGuests(guests);
                printer.printInconvinientGuests(inconvenientGuests);
                return;
            }
            
            printer.printSuccessfulScenario(dayIndexWhenEveryoneCanCome);  
        }
    }
}