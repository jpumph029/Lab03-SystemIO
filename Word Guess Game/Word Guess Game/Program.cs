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

        /// <summary>
        /// Allows the user to see the UserInterface and select an option from the MenuOptions method.
        /// </summary>
        /// <param name="path">Text file path</param>
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

        /// <summary>
        /// Menu Option to run the selected option's methods.
        /// </summary>
        /// <param name="menuInput">User input from UserInterface</param>
        /// <param name="path">File Path</param>
        public static void MenuOptions(int menuInput, string path)
        {
            switch (menuInput)
            {
                case 0:
                    //PlayGame
                    GetRandomWord(path);
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
 
        /// <summary>
        /// Exit the program.
        /// </summary>
        static void ExitProgram()
        {
            Environment.Exit(0);
        }

        /// <summary>
        /// Makes a file with dog, cat and cow on new lines
        /// </summary>
        /// <param name="path">File path</param>
        static void CreateFile(string path)
        {
            try
            {
                using (StreamWriter streamWriter = new StreamWriter(path))
                {
                    try
                    {
                        //the text made with the file
                        streamWriter.WriteLine("dog");
                        streamWriter.WriteLine("cat");
                        streamWriter.WriteLine("cow");
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

        /// <summary>
        /// Reads a file from path
        /// </summary>
        /// <param name="path">File path</param>
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

        /// <summary>
        /// Appends the userInput to the path
        /// </summary>
        /// <param name="path">File path</param>
        /// <param name="userInput">New String to add to file</param>
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

        /// <summary>
        /// Currently removed the file from path
        /// </summary>
        /// <param name="path">File path</param>
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

        /// <summary>
        /// Splits a string at splitHere charchater
        /// </summary>
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

        public static void Play(string path)
        {

        }

        /// <summary>
        /// Retrieves a random word
        /// </summary>
        /// <param name="path">File path</param>
        /// <returns></returns>
        public static string GetRandomWord(string path)
        {
            try
            {
                string[] file = File.ReadAllLines(path);
                Random answer = new Random();
                int i = answer.Next(file.Length);
                Console.WriteLine(file[i]);
                return file[i];
            }
            catch (Exception e)
            {
                throw e;
            }   
        }

    }
}
