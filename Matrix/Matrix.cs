using System.Text;

namespace MatrixProject;

public class Matrix
{
    private const int MinValue = 0;
    private const int MaxValue = 100;
    public int ColumnCount { get; set; }
    public int RowsCount { get; }
    public int[ , ] Array { get; }

    public Matrix( int rows, int columns )
    {
        ColumnCount = columns;
        RowsCount = rows;
        Array = new int[RowsCount, ColumnCount];
    }

    public void FillRandom()
    {
        Random rnd = new Random();

        for (var i = 0; i < RowsCount; i++)
        {
            for (var j = 0; j < ColumnCount; j++)
            {
                Array[i, j] = rnd.Next(MinValue, MaxValue);
            }
        }
    }

    public void FillСonsistently()
    {
        var currentValue = MinValue;

        for (var i = 0; i < RowsCount; i++)
        {
            for (var j = 0; j < ColumnCount; j++)
            {
                Array[i, j] = currentValue ++;
            }
        }
    }

    public void Print()
    {
        Console.WriteLine("--------    MATRIX:    ---------- \n");

        for (var i = 0; i < RowsCount; i++)
        {
            for (var j = 0; j < ColumnCount; j++)
            {
                if (i == j)
                    Console.ForegroundColor = ConsoleColor.Red;
                else
                    Console.ForegroundColor = ConsoleColor.White;
                Console.Write(Array[i, j] + "\t");
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n\n\n");
        }
    }

    public int Track()
    {
        var sum = 0;

        for (var i = 0; i < ColumnCount; i++)
        {
            for (var j = 0; j < RowsCount; j++)
            {
                if (i == j)
                    sum += Array[i, j];
            }
        }
        return sum;
    }

    public string PrintSnake()
    {
        int iter = (int)Math.Ceiling(Math.Min(RowsCount, ColumnCount) / 2.0);
        int i = 0, j = 0, k = 0;

        var str = new StringBuilder();

        while (k < iter)
        { 
            while (j < ColumnCount - k - 1)
            {
                str.Append(", " + Array[i, j]);
                j++;
            }


            while (i < RowsCount - k - 1 )
            {
                str.Append(", " + Array[i, j]);
                i++;
            }

            //if (k == iter - 1)
            //    break;

            while (j > k)
            {
                str.Append(", " + Array[i, j]);
                j--;
            }


            while (i > k)
            {
                str.Append(", " + Array[i, j]);
                i--;
            }

            k++;
            i++;
            j++;
        }

        return str.ToString().Substring(2);
    }

}

