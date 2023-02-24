using MatrixProject;


var colCount = MatrixHelper.InputDimension(DimensionType.ColumnsCount);
var rowCount = MatrixHelper.InputDimension(DimensionType.RowsCount);

var matrix = MatrixHelper.GetMatrix(rowCount, colCount);

Console.Write("Do u want to fill matrix random? ([y] to confirm)");
var input = Console.ReadLine();
if (input == "y")
    matrix.FillRandom();
else
    matrix.FillConsistently();

MatrixHelper.PrintToConcole(matrix);

Console.WriteLine("Matrix track: " + matrix.Track());

Console.WriteLine("Shake print: " + matrix.PrintSnake());












