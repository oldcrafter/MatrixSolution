namespace MatrixTest;
using MatrixProject;

public class Tests
{
    [Test]
    public void PrintSnake_Test()
    {
        var matrix = new Matrix(3, 6);
        matrix.FillConsistently();
        var printSnake = matrix.PrintSnake();
        Assert.AreEqual("0, 1, 2, 3, 4, 5, 11, 17, 16, 15, 14, 13, 12, 6, 7, 8, 9, 10",  printSnake);
    }
}