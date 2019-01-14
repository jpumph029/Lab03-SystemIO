using System;
using Xunit;
using System.IO;
using Word_Guess_Game;


namespace Word_Guess_Game_Tests
{
    public class UnitTest1
    {
        [Fact]
        public void CanAppendToFile()
        {
            //arange
            string path = "../../../testFile.txt";
            string input = "tests";
            //act
            string word = Program.AppendToFile(path, input);
            //assert
            Assert.Equal("tests", word);
        }
    }
}
