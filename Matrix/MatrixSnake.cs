using System.Text;

namespace MatrixProject;
public class MatrixSnake 
{
    private const string Separator = ", ";
    
    private int _leftBound;
    private int _rightBound;
    private int _topBound;
    private int _bottomBound;

    private int _currentRow;
    private int _currentCol;

    public StringBuilder Trace { get; }

    private MovementDirection _direction = MovementDirection.Right;

    private Matrix _matrix;
    
    public MatrixSnake(int row, int col) 
    {
        _matrix = new Matrix(row, col);
        Trace = new StringBuilder();
    }

    public void FillRandom()
    {
        _matrix.FillRandom();
    }

    public void FillConsistently()
    {
        _matrix.FillConsistently();
    }

    public string GetTrace()
    {
        Reset();

        while (TryToMove()) 
        {
            ChangeCurrentPosition();
            AppendCurrentValue();
        }

        return Trace.ToString().Substring(2);
    }

    public void ToConsole()
    {
        MatrixHelper.PrintToConsole(_matrix);
    }

    private void AppendCurrentValue()
    {
        Trace.Append(Separator).Append(_matrix.GetValue(_currentRow, _currentCol)).ToString();
    }

    private void ChangeCurrentPosition()
    {
        if (_direction == MovementDirection.Right)
            _currentCol++;
        if (_direction == MovementDirection.Left)
            _currentCol--;
        if (_direction == MovementDirection.Down)
            _currentRow++;
        if (_direction == MovementDirection.Up)
            _currentRow--;
    }

    private bool TryToMove()
    {
        var changeDirectionCount = 0;

        CheckForArriveRightBound(ref changeDirectionCount);
        CheckForArriveBottomBound(ref changeDirectionCount);
        CheckForArriveLeftBound(ref changeDirectionCount);
        CheckForArriveTopBound(ref changeDirectionCount);

        if (changeDirectionCount > 1)
            return false;

        return true;
    }

    private void CheckForArriveTopBound(ref int changeDirectionCount)
    {
        if (_direction == MovementDirection.Up && _currentRow == _topBound)  
        {
            ChangeDirection();
            _leftBound++;
            changeDirectionCount++;
        }

    }

    private void CheckForArriveLeftBound(ref int changeDirectionCount)
    {
        if (_direction == MovementDirection.Left && _currentCol == _leftBound)
        {
            ChangeDirection();
            _bottomBound--;
            changeDirectionCount++;
        }
    }

    private void CheckForArriveBottomBound(ref int changeDirectionCount)
    {
        if (_direction == MovementDirection.Down && _currentRow == _bottomBound)
        {
            ChangeDirection();
            _rightBound--;
            changeDirectionCount++;
        }
    }

    private void CheckForArriveRightBound(ref int changeDirectionCount)
    {
        if (_direction == MovementDirection.Right && _currentCol == _rightBound)
        {
            ChangeDirection();
            _topBound++;
            changeDirectionCount++;
        }
    }

    private void ChangeDirection()
    {
        _direction = _direction switch
        {
            MovementDirection.Right => MovementDirection.Down,
            MovementDirection.Down => MovementDirection.Left,
            MovementDirection.Left => MovementDirection.Up,
            MovementDirection.Up => MovementDirection.Right,
            _ => throw new Exception()
        };
    }

    private void Reset()
    {
        _leftBound = 0;
        _rightBound = _matrix.ColumnCount - 1;
        _topBound = 0;
        _bottomBound = _matrix.RowsCount - 1;

        _currentRow = 0;
        _currentCol = 0;

        Trace.Clear();

        AppendCurrentValue();
    }
}
