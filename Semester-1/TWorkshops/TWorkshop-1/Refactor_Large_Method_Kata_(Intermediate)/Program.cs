namespace RefactorLargeMethodKataIntermediate
{
    class Program
    {
        static void Main(string[] args)
        {
            // make new double array for scores and check if they are valid
            double[] ScoreAssignment = GetValidScores("assignment");
            double[] ScoreQuiz = GetValidScores("exam");
            double[] ScoreExam = GetValidScores("quiz"); 
            // make new double for averages
            Double averageAssignment = CalculateAverage(ScoreAssignment);
            Double averageQuiz = CalculateAverage(ScoreQuiz);
            Double averageExam = CalculateAverage(ScoreExam);
            // display final grade
            DisplayFinalGrades("assignment",averageAssignment);
            DisplayFinalGrades("quiz",averageQuiz);
            DisplayFinalGrades("exam",averageExam);
        }
    
      

        // Ask for scores and and convert them to arrays and validate the input
        
        static string[] ReadScores(string type)
        {
            Console.WriteLine($"Enter {type} scores (separated by spaces): ");
            string scoresInput = Console.ReadLine() ?? string.Empty;
            return scoresInput.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        }

        static bool CheckScores(string[] scoreInputDevided, out double[] scores)
        {
            double score;
            scores = new double[scoreInputDevided.Length];
            int counter = 0;
            bool valid = scoreInputDevided.Length >= 1;
            foreach (string input in scoreInputDevided)
            {
                if (double.TryParse(input, out score))
                {
                    scores[counter] = score;
                    counter++;
                }
                else
                {
                    valid = false;
                    Console.WriteLine($"Please enter a valid score. Wrong input: {input}");
                }

            }
            return valid;
        }
        static double[] GetValidScores(string type)
        {
            bool valid = false;
            double[] scores = new double[0];

            while (!valid)
            {
                string[] scoreInputDevided = ReadScores(type);

                valid = CheckScores(scoreInputDevided, out scores);
            }
            
            return scores;
        }
             
     
        //Calculate average of scores call upon with (scores) in (Arrays) double double
        static double CalculateAverage(double[] scores) 
        {
            double sum = 0;
                foreach (var score in scores)
                {
                    sum += score;
                }
                return sum / scores.Length;
        }

        static void DisplayFinalGrades(string type, Double average)
        {
            Console.WriteLine($"The final {type} grade is: {average}");
        }
        
           
    }
}