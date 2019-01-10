using System;
using System.IO;

namespace Word_Guess_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "../../../testFile.txt";
            //DeleteFile(path);
            CreateFile(path);
            //AppendToFile(path);
            ReadFile(path);
            Console.Read();
            Console.WriteLine("Hello World!");
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
                        streamWriter.WriteLine("This is a test. Hello File");
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
            }
            catch (Exception)
            {

                throw;
            }
        }
        static void AppendToFile(string path)
        {
            try
            {
                using (StreamWriter streamWriter = File.AppendText(path))
                {
                    streamWriter.WriteLine("This is text appened from AppendToFileMethod");
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
    }
}
