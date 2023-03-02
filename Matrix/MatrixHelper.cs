namespace MatrixProject;

public static class MatrixHelper
{
    public static int InputDimension(DimensionType dimensionType)
    {

        var prompt = dimensionType switch
        {
            DimensionType.RowsCount => "Input array's height",
            DimensionType.ColumnsCount => "Input array's width",
            _ => string.Empty
        };

        int result = 0;
        var isCorrectInput = false;

        while (isCorrectInput == false)
        {
            Console.Write(prompt + " : ");
            var input = Console.ReadLine();
            try
            {
                result = Int32.Parse(input);
                isCorrectInput = true;
                if (result < 1)
                    throw new InvalidMatrixDimensionException(null, null);
            }
            catch (FormatException)
            {
                Console.WriteLine("Unable to convert '{0}'.", input);
                isCorrectInput = false;
            }
            catch (OverflowException)
            {
                Console.WriteLine("'{0}' is out of range of the Int32 type.", input);
                isCorrectInput = false;
            }
            catch (InvalidMatrixDimensionException)
            {
                Console.WriteLine("Matrix Dimension can`t be zero or negative", input);
                isCorrectInput = false;
            }

        }

        return result;
    }
    
    public static void PrintToConsole(Matrix matrix)
    {
        Console.WriteLine("--------    MATRIX:    ---------- \n");

        for (var i = 0; i < matrix.RowsCount; i++)
        {
            for (var j = 0; j < matrix.ColumnCount; j++)
            {
                if (i == j)
                    Console.ForegroundColor = ConsoleColor.Red;
                else
                    Console.ForegroundColor = ConsoleColor.White;
                Console.Write(matrix.Array[i, j] + "\t");
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n\n\n");
        }
    }
}
