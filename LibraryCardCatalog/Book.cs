using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCardCatalog
{
    [Serializable]
   public class Book
    {
        public string AuthorFirstName { get; set; }
        public string AuthorLastName { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public int Isbn { get; set; }


        

        public Book()
        {
            Console.WriteLine("Enter Authors First Name");
            AuthorFirstName = Console.ReadLine();

            Console.WriteLine("Enter Authors Last Name");
            AuthorLastName = Console.ReadLine();

            Console.WriteLine("Enter Title of Book");
            Title = Console.ReadLine();

            Console.WriteLine("Enter Year book was published");
            Year = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter ISBN number for the book, 10 or 13 digits");
            Isbn = Convert.ToInt32(Console.ReadLine());
            

        }


    }
}
