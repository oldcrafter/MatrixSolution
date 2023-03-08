using MatrixProject;

var isCorrectInput = false;

while (isCorrectInput == false)
{
    var colCount = MatrixHelper.InputDimension(DimensionType.ColumnsCount);
    var rowCount = MatrixHelper.InputDimension(DimensionType.RowsCount);

    try
    {
        var matrix = new MatrixSnake(rowCount, colCount);
        isCorrectInput = true;
        Console.Write("Do u want to fill matrix random? ([y] to confirm)");
        var input = Console.ReadLine();
        if (input == "y")
            matrix.FillRandom();
        else
            matrix.FillConsistently();

        matrix.ToConsole();

        Console.WriteLine("Matrix track: " + matrix.GetTrace());
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}















