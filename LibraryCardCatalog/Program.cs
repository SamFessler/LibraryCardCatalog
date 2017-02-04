using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LibraryCardCatalog
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter complete file path that you wish to access the books for");
            string fileName = Console.ReadLine();

            CardCatalog myCatalog = new CardCatalog(fileName);
            
        }
    }
}
