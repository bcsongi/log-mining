using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace dataToSql
{
    class Program
    {
        static OperationsWithSQL MyOperations = new OperationsWithSQL();

        static string ReplaceAtIndex(string text, int index, char c)
        {
            var stringBuilder = new StringBuilder(text);
            stringBuilder[index] = c;
            return stringBuilder.ToString();
        }

        // Reads the data and Inserts in the SQL-database
        static void readAndPut(string fileName)
        {
            try
            {   // Open the text file using a stream reader.
                using (StreamReader sr = new StreamReader(fileName))
                {
                    // Read the stream to a string, and write the string to the console.
                    while ( !sr.EndOfStream)
                    {
                        String line = sr.ReadLine();

                        // We need to replace the ' caracter to " because is not posible to insert ' characters to SQL database
                        line = line.Replace('\'', '"');

                        // Replaces the first ',' with '.' because in SQL the is valid date only with '.'
                        for (int i = 0; i < line.Length; i++)
                        {
                            if (line[i] == ',')
                            {
                                //ReplaceAtIndex(line, i, '.');
                                var stringBuilder = new StringBuilder(line);
                                stringBuilder[i] = '.';
                                line = stringBuilder.ToString();
                                break;
                            }

                        }

                        string[] words = line.Split(']');
                        //foreach (string word in words)
                        for (int i = 0; i < words.Length; i++ )
                        {
                            int x = 0;
                            // Removes the ' ' and '[' from the begining of the string
                            while ((words[i][x] == ' ') || (words[i][x] == '[') || (words[i][x] == '-'))
                            {
                                x++;
                            }
                            words[i] = words[i].Remove(0, x);
                            //Console.WriteLine(words[i]);
                        }

                        string InsertResult = MyOperations.InsertToSQL(words);

                        if (InsertResult != "OK")
                        {
                            Console.WriteLine("Error! Unable to insert: " + InsertResult);
                        }

                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }

        static void Main(string[] args)
        {
            readAndPut("F:/3. ev 1. felev/Csoportos Projekt/munkam/EventManagerSmall.log20150714");

        }
    }
}
