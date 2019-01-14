using System;
using Xunit;
using System.IO;
using Word_Guess_Game;


namespace Word_Guess_Game_Tests
{
    public class UnitTest1
    {
        [Fact]
        public void CanCreateFile()
        {
            //arange
            string path = "../../../testFile.txt";

            //assert
            Assert.True(Program.CreateFile(path));
            
        }
        [Fact]
        public void CanAppendToFile()
        {
            //arange
            string path = "../../../testFile.txt";
            string input = "tests";
      
            //assert
            Assert.Equal("tests", Program.AppendToFile(path, input));
        }
        [Fact]
        public void CanReadFile()
        {
            //arrane
            string path = "../../../testFile.txt";
            //assert
            Assert.True(Program.ReadFile(path));
        }
        [Fact]
        public void CanDetectGuess()
        {
            //arrange
            string answer = "cat";
            string guess = "c";

            //assert
            Assert.Contains("c", answer);
        }
    }
}
