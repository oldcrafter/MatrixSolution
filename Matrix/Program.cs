using MatrixProject;

var isCorrectInput = false;

while (isCorrectInput == false)
{
    var colCount = MatrixHelper.InputDimension(DimensionType.ColumnsCount);
    var rowCount = MatrixHelper.InputDimension(DimensionType.RowsCount);

    try
    {

        var matrix = new Matrix(rowCount, colCount);
        isCorrectInput = true;
        Console.Write("Do u want to fill matrix random? ([y] to confirm)");
        var input = Console.ReadLine();

        if (input == "y")
            matrix.FillRandom();
        else
            matrix.FillConsistently();

        MatrixHelper.ToConsole(matrix);
        var snake = new MatrixSnake(matrix);
        Console.WriteLine("Matrix trace: " + matrix.GetTrace());
        Console.WriteLine("Matrix snake: " + snake.GetSnake());
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}















