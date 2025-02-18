namespace RefactorLargeMethodKataIntermediate
{
    class Program
    {
        static void Main(string[] args)
        {
            //ask for input of assignment scores
            double[] ScoreAssignment = ReadAssignmentScores();
            //ask for input of quiz scores
            double[] ScoreQuiz = ReadQuizScores();
            //ask for input of exam scores
            double[] ScoreExam = ReadExamScores(); 
            //calculate final grade
            Double averageAssignment = CalculateAverage(ScoreAssignment);
            Double averageQuiz = CalculateAverage(ScoreQuiz);
            Double averageExam = CalculateAverage(ScoreExam);
            //display final grade
            DisplayFinalGrades(averageAssignment);
            DisplayFinalGrades(averageQuiz);
            DisplayFinalGrades(averageExam);
        }
    
        //Read assignment scores and convert them to (arrays) double double
        static double[] ReadAssignmentScores()
        {
            Console.WriteLine("Enter assignment scores (separated by spaces): ");
            string[] assignmentScoresInput = Console.ReadLine().Split(' ');
            double[] assignmentScores = Array.ConvertAll(assignmentScoresInput, double.Parse);
            return assignmentScores;
        }

        //Read quiz scores and convert them to (arrays) double double
        // Try to add valudation on the input
        static double[] ReadQuizScores()
        {
            //double[] score;
            double score;
            bool valid = false;
            double[] quizScores = new double[0];

            while (!valid)
            {
                Console.WriteLine("Enter quiz scores (separated by spaces): ");
                string scoresInput = Console.ReadLine() ?? string.Empty;
                string[] quizScoresInput = scoresInput.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                quizScores = new double[quizScoresInput.Length];
                int counter = 0;
                valid = quizScoresInput.Length >= 1;
                foreach (string input in quizScoresInput)
                {
                    if (double.TryParse(input, out score) == true)
                    {
                        quizScores[counter] = score;
                        counter++;
                        
                    }
                    else
                    {
                        valid = false;
                        Console.WriteLine($"Please enter a valid Quiz score {input}.");
                        //break;
                        
                    }

                }
            }
            return quizScores;
        }
        

        //Validate quiz scores????
/*static bool validateQuizScores(double[] quizScores, out double[] quizScoresfalse)
        {
            bool valid = true;
            quizScoresfalse = null;
            foreach (var score in quizScores)
            {
                if (score < 0 || score > 100)
                {
                    valid = false;
                    quizScoresfalse = quizScores;
                    break;
                }
            }
            return valid;
        } */
        

        //Read exam scores and convert them to (arrays) double double
        static double[] ReadExamScores()
        {
            Console.WriteLine("Enter exam scores (separated by spaces): ");
            string[] examScoresInput = Console.ReadLine().Split(' ');
            double[] examScores = Array.ConvertAll(examScoresInput, double.Parse);
            return examScores;
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

        static void DisplayFinalGrades(Double average)
        {
            Console.WriteLine($"The final grade is: {average}");
        }
        
           
    }
}