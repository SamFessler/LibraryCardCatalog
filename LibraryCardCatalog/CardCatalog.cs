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
        List<Book> myBookList = new List<Book>();

        


        public CardCatalog(string fileName)
        {

            if (!File.Exists(fileName))
            {
                Console.WriteLine("File does not exist, we will create a new file when you save!");

            }
            else
            {
                List<Book> myBookList = ReadFromXmlFile<List<Book>>(fileName);
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
                        
                        myBookList.Add(new Book());

                        i++;
                        break;

                    case 3:

                        Save(fileName);

                        Console.WriteLine("Goodbye.....");
                        System.Threading.Thread.Sleep(5000);
                        break;

                    default:
                        Console.WriteLine("Sorry, invalid input! enter 1, 2 or 3");
                        break;
                }

            }


        }

        public void ListBooks(string fileName)
        {
            foreach (var book in myBookList)
            {
               Console.WriteLine(book.Title);
            }

           // string bookList = File.ReadAllText(fileName);
           // Console.WriteLine(bookList);

        }


        public void Save(string fileName)
        {
            WriteToXmlFile<List<Book>>(fileName, myBookList);

        }


        ////write


        public static void WriteToXmlFile<T>(string filePath, T objectToWrite, bool append = false) where T : new()
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
        
        public static T ReadFromXmlFile<T>(string filePath) where T : new()
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

