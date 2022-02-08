using App.Services;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            Application app = new Application(
                new Parser(),
                new WeddingService(),
                new Printer()
            );
            
            app.run();
        }
    }
}