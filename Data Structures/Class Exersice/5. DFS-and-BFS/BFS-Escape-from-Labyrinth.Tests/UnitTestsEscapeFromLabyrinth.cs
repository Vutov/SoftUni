using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

[TestClass]
public class UnitTestsEscapeFromLabyrinth
{
    [TestMethod]
    public void TestLabyrinth9x7()
    {
        // Arrange
        var input =
            "9" + "\n" +
            "7" + "\n" +
            "*********" + "\n" +
            "*----**--" + "\n" +
            "**-*----*" + "\n" +
            "*--*-*-**" + "\n" +
            "*s*--*-**" + "\n" +
            "**------*" + "\n" +
            "*******-*" + "\n";

        // Act
        var inputReader = new StringReader(input);
        var outputWriter = new StringWriter();
        using (outputWriter)
        {
            Console.SetIn(inputReader);
            Console.SetOut(outputWriter);
            EscapeFromLabyrinth.Main();
        }
        var output = outputWriter.ToString();

        // Assert
        var expectedOutput = "Shortest exit: URUURRDRRRUR";
        output = output.Replace("\r\n", "\n").Trim();
        Assert.AreEqual(expectedOutput, output);
    }

    [TestMethod]
    public void TestLabyrinth4x3()
    {
        // Arrange
        var input =
            "4" + "\n" +
            "3" + "\n" +
            "****" + "\n" +
            "*-s*" + "\n" +
            "****" + "\n";

        // Act
        var inputReader = new StringReader(input);
        var outputWriter = new StringWriter();
        using (outputWriter)
        {
            Console.SetIn(inputReader);
            Console.SetOut(outputWriter);
            EscapeFromLabyrinth.Main();
        }
        var output = outputWriter.ToString();

        // Assert
        var expectedOutput = "No exit!";
        output = output.Replace("\r\n", "\n").Trim();
        Assert.AreEqual(expectedOutput, output);
    }

    [TestMethod]
    public void TestLabyrinth4x2()
    {
        // Arrange
        var input =
            "4" + "\n" +
            "2" + "\n" +
            "****" + "\n" +
            "***s" + "\n";

        // Act
        var inputReader = new StringReader(input);
        var outputWriter = new StringWriter();
        using (outputWriter)
        {
            Console.SetIn(inputReader);
            Console.SetOut(outputWriter);
            EscapeFromLabyrinth.Main();
        }
        var output = outputWriter.ToString();

        // Assert
        var expectedOutput = "Start is at the exit.";
        output = output.Replace("\r\n", "\n").Trim();
        Assert.AreEqual(expectedOutput, output);
    }


    [TestMethod]
    public void TestLabyrinth2x2()
    {
        // Arrange
        var input =
            "2" + "\n" +
            "2" + "\n" +
            "**" + "\n" +
            "**" + "\n";

        // Act
        var inputReader = new StringReader(input);
        var outputWriter = new StringWriter();
        using (outputWriter)
        {
            Console.SetIn(inputReader);
            Console.SetOut(outputWriter);
            EscapeFromLabyrinth.Main();
        }
        var output = outputWriter.ToString();

        // Assert
        var expectedOutput = "No exit!";
        output = output.Replace("\r\n", "\n").Trim();
        Assert.AreEqual(expectedOutput, output);
    }
}
