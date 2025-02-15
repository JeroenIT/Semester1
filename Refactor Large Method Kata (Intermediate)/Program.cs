using System;

namespace RefactorLargeMethodKataIntermediate
{
    class Program
    {
        static void Main(string[] args)
        {
            CalculateAndDisplayFinalGrade();


        }
    
        static void CalculateAndDisplayFinalGrade()
        {        // Read assignment scores
            Console.WriteLine("Enter assignment scores (separated by spaces): ");
            string[] assignmentScoresInput = Console.ReadLine().Split(' ');
            double[] assignmentScores = Array.ConvertAll(assignmentScoresInput, double.Parse);


            // Read quiz scores
            Console.WriteLine("Enter quiz scores (separated by spaces): ");
            string[] quizScoresInput = Console.ReadLine().Split(' ');
            double[] quizScores = Array.ConvertAll(quizScoresInput, double.Parse);

            // Read exam scores
            Console.WriteLine("Enter exam scores (separated by spaces): ");
            string[] examScoresInput = Console.ReadLine().Split(' ');
            double[] examScores = Array.ConvertAll(examScoresInput, double.Parse);

            // Calculate average scores
            double assignmentAverage = CalculateAverage(assignmentScores);
            double quizAverage = CalculateAverage(quizScores);
            double examAverage = CalculateAverage(examScores);


            // Calculate final grade
            double finalGrade = (assignmentAverage * 0.4) + (quizAverage * 0.2) + (examAverage *0.4);

            // Display final grade
            Console.WriteLine($"The final grade is: {finalGrade}");
        }
        static double CalculateAverage(double[] scores)
        {
            double sum = 0;
            foreach (var score in scores)
                {
                sum += score;
                }
            return sum / scores.Length;

    
        }
    }
}