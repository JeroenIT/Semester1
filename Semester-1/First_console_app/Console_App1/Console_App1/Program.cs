using System.Linq.Expressions;
//onderstaande bool zorgt voor de loop als de gebruiker een nieuwe berekening wil maken en false voor het stoppen van de loop
bool nextSquare = true; 
while (nextSquare)
{
    double sideLength;
    while (true)
    {
        // Hieronder vragen we om de lengte en erna een controle of het een getal is. bij een getal gaat hij naar volgende stap, anders komt hij terug. 
        Console.WriteLine("Welcome to the square area calculator!");
        Console.WriteLine("To calculate the area of a square, enter the length of the square:");
        string input = Console.ReadLine();
        if (double.TryParse(input, out sideLength))
        {
            break;
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");

            
        }
    }



    double sideWidth;
    while (true)
    {
        Console.WriteLine("To calculate the area of a square, enter the width of the square:");
        string input2 = Console.ReadLine();
        if (double.TryParse(input2, out sideWidth))
        {
            break;
        }
        else
        {
            Console.WriteLine("Dat werkt zo toch niet");
        }
    }
    
    

    double area = sideLength * sideWidth;
    Console.WriteLine("The area of the square is " + area);
    Console.WriteLine("The sircumference of the square is " + (sideLength + sideWidth) * 2);

    double diagonal = Convert.ToDouble(Math.Sqrt(sideLength * sideLength + sideWidth * sideWidth));
    Console.WriteLine("The diagonal of the square is " + diagonal);

    Console.WriteLine("Do you want to calculate the area of another square? (yes/no)");
        if (Console.ReadLine() == "no")
        {
                Console.WriteLine("Thank you for using the square area calculator!");
                nextSquare = false;
        }
}