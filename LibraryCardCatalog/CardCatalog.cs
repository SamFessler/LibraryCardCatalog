using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace LibraryCardCatalog
{
    public class CardCatalog
    {
        public static List<Book> myBookList = new List<Book>();
        
        public CardCatalog(string fileName)
        {

            if (!File.Exists(fileName))
            {
                Console.WriteLine("File does not exist, we will create a new file when you save!");

            }
            else
            {
                 myBookList = ReadFromXmlFile<List<Book>>(fileName);
            }

            int i = 0;
            var userInput = 0;


            while (userInput != 3)
            {
                Console.WriteLine("MENU:");
                Console.WriteLine("1. List All Books");
                Console.WriteLine("2. Add a Book");
                Console.WriteLine("3. Save and Exit");

                userInput = Convert.ToInt32(Console.ReadLine());


                switch (userInput)
                {
                    case 1:
                        ListBooks(fileName);
                        break;

                    case 2:
                        AddBook(myBookList);
                        i++;
                        break;

                    case 3:
                        Save(fileName);

                        Console.WriteLine("Goodbye.....");
                        System.Threading.Thread.Sleep(3000);
                        break;

                    default:
                        Console.WriteLine("Sorry, invalid input! enter 1, 2 or 3");
                        break;
                }

            }


        }

        //prints author and title of all books in curretn file
        public void ListBooks(string fileName)
        {
            foreach (var book in myBookList)
            {
                Console.WriteLine("{0} -by {1}, {2}", book.Title, book.AuthorLastName, book.AuthorFirstName);
                Console.WriteLine("");
            }

            // string bookList = File.ReadAllText(fileName);
            // Console.WriteLine(bookList);

        }

        //add book method
        public void AddBook(List<Book> books)
        {

            Console.WriteLine("Enter Authors First Name");
            string first = Console.ReadLine();

            Console.WriteLine("Enter Authors Last Name");
            string last = Console.ReadLine();

            Console.WriteLine("Enter Title of Book");
            string title = Console.ReadLine();

            Console.WriteLine("Enter Year book was published");
            int year = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter ISBN number for the book, or other sorting identification");
            string isbn = Console.ReadLine();

            books.Add(new Book() { AuthorFirstName = first, AuthorLastName = last, Title = title, Year = year, Isbn = isbn });

        }


        public void Save(string fileName)
        {
            WriteToXmlFile(fileName, myBookList);

        }


        //write to file
        public static void WriteToXmlFile<T>(string filePath, T objectToWrite, bool append = false)
        {
            TextWriter writer = null;
            try
            {
                var serializer = new XmlSerializer(typeof(T));
                writer = new StreamWriter(filePath, append);
                serializer.Serialize(writer, objectToWrite);
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }
        }

        //read from file
        public static T ReadFromXmlFile<T>(string filePath)
        {
            TextReader reader = null;
            try
            {
                var serializer = new XmlSerializer(typeof(T));
                reader = new StreamReader(filePath);
                return (T)serializer.Deserialize(reader);
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
        }




    }


}
