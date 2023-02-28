using MatrixProject;
using System.Diagnostics;

var isCorrectInput = false;

var snake = new MatrixSnake(6, 3);
snake.FillConsistently();
MatrixHelper.PrintToConsole(snake);
Console.WriteLine(snake.GetTrace());


//while (isCorrectInput == false)
//{
//    var colCount = MatrixHelper.InputDimension(DimensionType.ColumnsCount);
//    var rowCount = MatrixHelper.InputDimension(DimensionType.RowsCount);


//    //    try
//    //    {
//    //        var matrix = new Matrix(rowCount, colCount);
//    //        isCorrectInput = true;
//    //        Console.Write("Do u want to fill matrix random? ([y] to confirm)");
//    //        var input = Console.ReadLine();
//    //        if (input == "y")
//    //            matrix.FillRandom();
//    //        else
//    //            matrix.FillConsistently();

//    //        MatrixHelper.PrintToConsole(matrix);

//    //        Console.WriteLine("Matrix track: " + matrix.Track());

//    //        Console.WriteLine("Shake print: " + matrix.PrintSnake());
//    //    }
//    //    catch (Exception ex)
//    //    {
//    //        Console.WriteLine("TRY AGAIN! \n");
//    //    }
//    //}

//    try
//    {
//        var snake = new MatrixSnake(6, 3);
//        snake.FillConsistently();
//        MatrixHelper.PrintToConsole(snake);
//        Console.WriteLine(snake.GetTrace()); 


//    }
//    catch (Exception ex)
//    {
//        Console.WriteLine(ex.Message);
//    }

//}
















