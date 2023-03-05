using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixProject;
internal class MatrixSnake : Matrix
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

    public MatrixSnake(int rowsCount, int columnsCount) : base(rowsCount, columnsCount)
    { 
        Trace = new StringBuilder();
    }

    public string GetTrace()
    {
        Reset();

        while (TryToMove() == true) 
        {
            ChangeCurrentPosition();
            AppendCurrentValue();
        }

        return Trace.ToString().Substring(2);
    }

    private void AppendCurrentValue()
    {
        Trace.Append(Separator).Append(Array[_currentRow, _currentCol]).ToString();
    }

    private void ChangeCurrentPosition()
    {
        switch (_direction)
        {
            case MovementDirection.Right:
                _currentCol++;
                break;
            case MovementDirection.Left:
                _currentCol--;
                break;
            case MovementDirection.Down:
                _currentRow++;
                break;
            case MovementDirection.Up:
                _currentRow--;
                break;
        }
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
        if (_direction == MovementDirection.Up && _currentRow == _topBound)  //<
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
        _rightBound = ColumnCount - 1;
        _topBound = 0;
        _bottomBound = RowsCount - 1;

        _currentRow = 0;
        _currentCol = 0;

        Trace.Clear();

        AppendCurrentValue();
    }
}
