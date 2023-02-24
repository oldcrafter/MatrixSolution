namespace MatrixProject;
public static class MatrixHelper
{
    public static Matrix GetMatrix(int rowsCount, int columnsCount)
    {
        Matrix matrix;
        try {
            matrix = new Matrix(rowsCount, columnsCount);
            return matrix;
        }
        catch (InvalidMatrixDimensionException ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
    }

    public static int InputDimension(DimensionType dimensionType)
    {
        var prompt = string.Empty;

        switch (dimensionType)
        {
            case DimensionType.RowsCount:
                prompt = "Input array's height";
                break;
            case DimensionType.ColumnsCount:
                prompt = "Input array's width";
                break;
        }

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
        }

        return result;
    }
    
    public static void PrintToConcole(Matrix matrix)
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
