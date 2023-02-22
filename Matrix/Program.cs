using MatrixProject;

Console.WriteLine("Input array's width");
int width = int.Parse(Console.ReadLine());

Console.WriteLine("Input array's height");
int height = int.Parse(Console.ReadLine());

var matrix = new Matrix(height, width );



matrix.FillСonsistently();
matrix.Print();

Console.WriteLine("Shake print: " + matrix.PrintSnakeNew());









