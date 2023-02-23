using MatrixProject;

var width = InputParameter("Input array's width");
var height = InputParameter("Input array's height");

var matrix = new Matrix(height, width);

Console.Write("Do u want to fill matrix random? ([y] to confirm)");
var input = Console.ReadLine();
if (input == "y")
    matrix.FillRandom();
else
    matrix.FillСonsistently();

matrix.Print();

Console.WriteLine("Matrix track: " + matrix.Track());

Console.WriteLine("Shake print: " + matrix.PrintSnake());

int InputParameter(string prompt)
{
    int result = 0;
    var input = string.Empty;
    var isCorrectInput = false;
    
    while (isCorrectInput == false)
    {
        Console.Write(prompt + " : ");
        input = Console.ReadLine();
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









