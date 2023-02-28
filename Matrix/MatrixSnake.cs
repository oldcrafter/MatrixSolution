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

    private Position _curCell = new Position { Column = 0, Row = 0};

    public StringBuilder Trace { get; }

    private MovementDirection _direction = MovementDirection.Right;

    public MatrixSnake(int rowsCount, int columnsCount) : base(rowsCount, columnsCount)
    { 
        Trace = new StringBuilder();
    }

    public string GetTrace()
    {
        Reset();

        while (CheckDirection() == true)
        { 
            Trace.Append(Separator).Append(GetNextvalue().ToString());
            Console.WriteLine(Trace.ToString().Substring(2));
        }

        
        return Trace.ToString().Substring(2);
 
    }

    private void ChangeDirection()
    {
        if (_direction.Equals(3))
            _direction = MovementDirection.Right;
        else
            _direction++;
    }

    private int GetNextvalue()
    {
         MoveCell();
         return Array[_curCell.Column, _curCell.Row];
    }

    private void MoveCell()
    {
        switch (_direction)
        {
            case MovementDirection.Right:
                _curCell.Column++;
                break;
            case MovementDirection.Left:
                _curCell.Column--;  
                break;
            case MovementDirection.Down:
                _curCell.Row++;
                break;
            case MovementDirection.Up:
                _curCell.Row--;
                break;
        }
    } 

    private bool CheckDirection()
    {
        var counter = 0;
        
        if (_direction == MovementDirection.Right && _curCell.Column == _rightBound)
        {
            ChangeDirection();
            _topBound++;
            counter++;
        }
           
        if (_direction == MovementDirection.Down && _curCell.Row == _bottomBound)
        {
            ChangeDirection();
            _rightBound--;
            counter++;
        }

        if (_direction == MovementDirection.Left && _curCell.Column == _leftBound)
        {
            ChangeDirection();
            _rightBound++;
            counter++;
        }

        if (_direction == MovementDirection.Up && _curCell.Row == _topBound)
        {
            ChangeDirection();
            _bottomBound--;
            counter++;
        }

        if (counter == 4)
            return false;
        else
            return true;
    }

    private void Reset()
    {
        _leftBound = 0;
        _rightBound = ColumnCount - 1;
        _topBound = 0;
        _bottomBound = RowsCount - 1;

        _curCell.Row = 0;
        _curCell.Column = 0;

        Trace.Clear();
    }
}
