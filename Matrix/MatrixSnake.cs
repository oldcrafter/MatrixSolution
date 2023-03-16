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
    private int _changeDirectionCount;

    private Matrix _matrix;

    public MatrixSnake(Matrix matrix)
    {
        _matrix = matrix;
        Trace = new StringBuilder();
    }

    public string GetSnake()
    {
        Reset();

        while (TryToMove())
        {
            ChangeCurrentPosition();
            AppendCurrentValue();
        }

        return Trace.ToString().Substring(2);
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
        _changeDirectionCount = 0;

        CheckForArriveRightBound();
        CheckForArriveBottomBound();
        CheckForArriveLeftBound();
        CheckForArriveTopBound();

        if (_changeDirectionCount > 1)
            return false;

        return true;
    }

    private void CheckForArriveTopBound()
    {
        if (_direction != MovementDirection.Up || _currentRow != _topBound)
            return;

        ChangeDirection();
        _leftBound++;
        _changeDirectionCount++;
    }

    private void CheckForArriveLeftBound()
    {
        if (_direction != MovementDirection.Left || _currentCol != _leftBound)
            return;

        ChangeDirection();
        _bottomBound--;
        _changeDirectionCount++;
    }

    private void CheckForArriveBottomBound()
    {
        if (_direction != MovementDirection.Down || _currentRow != _bottomBound)
            return;

        ChangeDirection();
        _rightBound--;
        _changeDirectionCount++;
    }

    private void CheckForArriveRightBound()
    {
        if (_direction != MovementDirection.Right || _currentCol != _rightBound)
            return;
        
        ChangeDirection();
        _topBound++;
        _changeDirectionCount++;
        
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
        _changeDirectionCount = 0;

        Trace.Clear();

        AppendCurrentValue();
    }
}