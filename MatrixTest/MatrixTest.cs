namespace MatrixTest;

using MatrixProject;

public class Tests
{
    [Test]
    public void PrintSnake_6_3_Test()
    {
        var matrix = new Matrix(6, 3);
        matrix.FillConsistently();
        var snake = new MatrixSnake(matrix);
        var printSnake = snake.GetSnake();
        Assert.That(printSnake, Is.EqualTo("0, 1, 2, 5, 8, 11, 14, 17, 16, 15, 12, 9, 6, 3, 4, 7, 10, 13"));
    }

    [Test]
    public void PrintSnake_3_6_Test()
    {
        var matrix = new Matrix(3, 6);
        matrix.FillConsistently();
        var snake = new MatrixSnake(matrix);
        var printSnake = snake.GetSnake();
        Assert.That(printSnake, Is.EqualTo("0, 1, 2, 3, 4, 5, 11, 17, 16, 15, 14, 13, 12, 6, 7, 8, 9, 10"));
    }

    [Test]
    public void PrintSnake_4_4_Test()
    {
        var matrix = new Matrix(4, 4);
        matrix.FillConsistently();
        var snake = new MatrixSnake(matrix);
        var printSnake = snake.GetSnake();
        Assert.That(printSnake, Is.EqualTo("0, 1, 2, 3, 7, 11, 15, 14, 13, 12, 8, 4, 5, 6, 10, 9"));
    }

    [TestCase("-1")]
    [TestCase("fhg")]
    [TestCase("1234567890123")]
    public void Test_GetDimensionValueFromInput(string input)
    {
        var result = MatrixHelper.GetDimensionValueFromInput(input);
        Assert.That(result, Is.EqualTo(null));
    }

    [Test]
    public void GetTrace_5_5()
    {
        var matrix = new Matrix(5, 5);
        matrix.FillConsistently();
        Assert.That(matrix.GetTrace(), Is.EqualTo(60));
    }

    [Test]
    public void GetTrace_7_4()
    {
        var matrix = new Matrix(7, 4);
        matrix.FillConsistently();
        Assert.That(matrix.GetTrace(), Is.EqualTo(30));
    }
}