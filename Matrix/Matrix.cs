using System.Text;
using System.Threading.Tasks;

namespace MatrixProject;

public class Matrix
{

    private const string Separator = ", ";
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

        this._columnCount = columnsCount;
        this._rowsCount = rowsCount;
        Array = new int[RowsCount, ColumnCount];
    }

    public void FillRandom()
    {
        for (var i = 0; i < this._rowsCount; i++)
            for (var j = 0; j < this._columnCount; j++)
                this.Array[i, j] = Random.Shared.Next(MinValue, MaxValue);
    }

    public void FillConsistently()
    {
        var currentValue = MinValue;

        for (var i = 0; i < this._rowsCount; i++)
            for (var j = 0; j < this._columnCount; j++)
                this.Array[i, j] = currentValue ++;
    }

    public int Track()
    {
        var sum = 0;

        for (var i = 0; i < this._columnCount; i++)
            for (var j = 0; j < this._rowsCount; j++)
                if (i == j)
                    sum += this.Array[i, j];

        return sum;
    }

    public string PrintSnake()
    {
        var result = new StringBuilder();

        int left = 0, right = ColumnCount - 1, top = 0 , bottom = RowsCount - 1;
        var direction = 0;
 
        while (left <= right && top <= bottom)
        {
            if (direction == 0)
            {
                for(int j = left; j <= right; j++)
                    result.Append(Separator).Append(Array[top, j]);
                top++;
            }

            if (direction == 1)
            {
                for (int i = top; i <= bottom; i++)
                    result.Append(Separator).Append(Array[i, right]);
                right--;
            }

            if (direction == 2)
            {
                for(int j = right; j >= left; j--)
                    result.Append(Separator).Append(Array[bottom, j]);
                bottom--;
            }

            if (direction == 3)
            {
                for(int i = bottom; i>= top; i--)
                    result.Append(Separator).Append(Array[i, left]);
                left++;
            }
            direction = (direction + 1) % 4;
        }
        return result.ToString().Substring(2);
    }
}

