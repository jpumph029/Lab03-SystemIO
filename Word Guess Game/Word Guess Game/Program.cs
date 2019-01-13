using System;
using System.IO;

namespace Word_Guess_Game
{
    class Program
    {
        static void Main(string[] args)
        {

            string path = "../../../testFile.txt";
            if (File.Exists(path))
            {
                UserInterface(path);
            }
            else
            {
                CreateFile(path);
                UserInterface(path);
            }
    
            //DeleteFile(path);
            //ReadFile(path);
            //SplitWords();
            Console.Read();
            
        }
        static void UserInterface(string path)
        {
            Console.WriteLine(@"

    (0) Play Guessing Game
    (1) Add new word
    (2) View words
    (3) Delete ALL WORDS
    (4) Exit

                               ");
            try
            {
                int menuInput = Convert.ToInt32(Console.ReadLine());
                MenuOptions(menuInput, path);
            }
            catch (Exception)
            {
                Console.Write("Invalid input. Try again.\nPress Enter to Continue . . .");
                Console.ReadKey();
                Console.Clear();
            }
            finally
            {
                UserInterface(path);
            }

        }
        public static void MenuOptions(int menuInput, string path)
        {
            switch (menuInput)
            {
                case 0:
                    //PlayGame
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case 1:
                    //AddNewWord
                    Console.Write("Please Type a word you would like to add: ");
                    string userInput = Console.ReadLine();
                    
                    AppendToFile(path, userInput);
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case 2:
                    //ViewWords
                    ReadFile(path);
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case 3:
                    //DeleteWords
                    DeleteFile(path);
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case 4:
                    //Exit
                    ExitProgram();
                    Console.ReadKey();
                    Console.Clear();
                    break;
                default:
                    Console.WriteLine("Invalid input. Try again.\nPress Enter to Continue . . .");
                    Console.ReadKey();
                    Console.Clear();
                    break;
            }
        }
 
        static void ExitProgram()
        {
            Environment.Exit(0);
        }
        static void CreateFile(string path)
        {
            try
            {
                using (StreamWriter streamWriter = new StreamWriter(path))
                {
                    try
                    {
                        //the text made with the file
                        streamWriter.WriteLine("123 123 123 123 --test");
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
            catch (IOException e)
            {

                Console.Write(e);
                throw;
            }
            catch (NotSupportedException e)
            {

                Console.Write(e);
                throw;
            }
            catch (Exception e)
            {

                Console.Write(e);
                throw;
            }
        }
        static void ReadFile(string path)
        {
            try
            {
                string[] lines = File.ReadAllLines(path);
                for (int i = 0; i < lines.Length; i++)
                {
                    Console.WriteLine(lines[i]);
                   
                }
                Console.WriteLine("\nPress any key to continue . . .");
            }
            catch (Exception)
            {

                throw;
            }
        }
        static void AppendToFile(string path, string userInput)
        {
            try
            {
                using (StreamWriter streamWriter = File.AppendText(path))
                {
                    streamWriter.WriteLine(userInput);
                    Console.WriteLine("Word added\nPress any key to continue . . .");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }   
        static void DeleteFile(string path)
        {
            try
            {
                File.Delete(path);
            }
            catch (Exception)
            {
                throw;
            }
        }
        static void SplitWords()
        {
            char[] splitHere = {' ', ',', '.', ':', '\t'};
            string testSplit = "one two:three.four,five";
            string[] splitWords = testSplit.Split(splitHere);
            foreach(string word in splitWords)
            {
                Console.WriteLine(word);
            }
        }
    }
}
