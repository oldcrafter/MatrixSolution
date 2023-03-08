using System.Text;
//using System.Threading.Tasks;

namespace MatrixProject;

public class Matrix
{
    private const int MinValue = 0;
    private const int MaxValue = 100;
    private int _columnCount;
    private int _rowsCount;

    public int ColumnCount => _columnCount;
    public int RowsCount => _rowsCount;
    public int[ , ] Array { get; }

    public Matrix(int rowsCount, int columnsCount)
    {
        if (rowsCount <= 0)
            throw new InvalidMatrixDimensionException(nameof(rowsCount), $"rowsCount can't be zero or negative");

        if (columnsCount <= 0)
            throw new InvalidMatrixDimensionException(nameof(columnsCount), $"columnsCount can't be zero or negative");

        _columnCount = columnsCount;
        _rowsCount = rowsCount;
        Array = new int[RowsCount, ColumnCount];
    }

    public void FillRandom()
    {
        for (var i = 0; i < _rowsCount; i++)
            for (var j = 0; j < _columnCount; j++)
                Array[i, j] = Random.Shared.Next(MinValue, MaxValue);
    }

    public void FillConsistently()
    {
        var currentValue = MinValue;

        for (var i = 0; i < _rowsCount; i++)
            for (var j = 0; j < _columnCount; j++)
                Array[i, j] = currentValue ++;
    }

    public int Track()
    {
        var sum = 0;

        for (var i = 0; i < _columnCount; i++)
            for (var j = 0; j < _rowsCount; j++)
                if (i == j)
                    sum += Array[i, j];

        return sum;
    }

    public int GetValue(int row, int col) 
    {
        return Array[row, col];
    }
}

