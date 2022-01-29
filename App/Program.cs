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
            Application app = new Application(new Parser(), new WeddingService());
            app.run();
        }
    }
}