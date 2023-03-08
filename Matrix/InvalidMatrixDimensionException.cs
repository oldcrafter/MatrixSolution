namespace MatrixProject;

public class InvalidMatrixDimensionException : ArgumentOutOfRangeException
{
    public InvalidMatrixDimensionException(string? paramName, string? message)
    : base(message, paramName){}
}
