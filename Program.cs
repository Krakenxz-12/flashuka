using System;

namespace ApplicationSystem
{
    class Program
    {
        static void RandomFlashCard(string UserN, string[] questions, string[] answer)
        {
            Random random = new Random();

            //Feature: Fisher-Yates Algorithm - used to shuffle the decks equally
            for (int i = questions.Length - 1; i >= 0; i--)
            {
                int cards = random.Next(0, i + 1);
                string flashQuestion = questions[i];
                string flashAnswer = answer[i];

                questions[i] = questions[cards];
                answer[i] = answer[cards];

                questions[cards] = flashQuestion;
                answer[cards] = flashAnswer;

            }

            //Feature: question-answer display
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("                           Flipzo: Here are your Flashcard. Let's Start?");
            Console.WriteLine(":::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::\n\n\n\n\n\n\n\n\n\n");
            Thread.Sleep(2000);

            Console.Clear();
            Console.WriteLine(":::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::");
            Console.WriteLine($"                      Flipzo: Are you ready, {UserN}? Flex your brain as you'll about to start your Quiz!\n\n\n");

            if (questions.Length == 0)
            {
                Console.WriteLine("                              You have no flashcard. You should create one...");
            }

            int correctFlashcard = 0;

            for (int i = 0; i < questions.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine(                              $"Question {i + 1}: {questions[i]}");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write(                           "Your answer: ");
                string UserAnswer = Console.ReadLine();

                //Feature: to be case-insensitive, making sure user input is not affected to the output
                if (string.Equals(UserAnswer.Trim(), answer[i].Trim(), StringComparison.OrdinalIgnoreCase)) 
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("                 Correct!");
                    correctFlashcard++;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"                 Incorrect! The correct answer is: {answer[i]}");
                }

                Console.WriteLine();
            }

            Console.WriteLine($"                   Flipzo: You've got {correctFlashcard} out of {questions.Length} correct!\n\n");


            Console.ResetColor();
        }

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("**********************************************************************************************************\n");
            Console.WriteLine("                                               Welcome to Flashuka!\n"); //Feature: Flashcard system name is Flashuka
            Console.WriteLine("**********************************************************************************************************");
            Thread.Sleep(1000);
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("                                               How may I help you ☺?");
                                                                        //Feature: Interactive prompt
            Console.Write("                         [1] I want to learn something        [2] I want to have fun! ");
            int choice = Convert.ToInt32(Console.ReadLine());
            Console.ResetColor();
            Console.Clear();

            Console.WriteLine();

            if (choice == 1 || choice == 2) //different questions generate the same answer
            {
                Console.ForegroundColor= ConsoleColor.DarkBlue;
                                                                //Feature: Flipzo is the name of Flashuka's assistant for users
                Console.WriteLine("Welcome to Flashuka! I am your friend, Flipzo ☺! Who will help you for your studies in just simple steps!"); 
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::");
                Console.WriteLine("                                    Here are the simple steps!                                     ");
                Console.WriteLine("                          1. Create an Account                                  ");
                Console.WriteLine("                          2. Click Add a Card.                                   ");
                Console.WriteLine("                          3. Enter the number of your questions.                  ");
                Console.WriteLine("                          4. You can now add your questions and its answers and Flipzo will get the job done!");
                Console.WriteLine("                          5. Enjoy your flashies!                                   ");
                Console.WriteLine("::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("                                        Flipzo: Are you ready? Let's Go!\n\n\n                           ");
                Thread.Sleep(3000);

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("                                              Create an Account"); //Feature: Account Creation
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("                                            Username: ");
                string UserN = Console.ReadLine();
                Console.Write("                                            Password: ");
                string PassW = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Red;

                if (UserN != PassW) //Feature: meant that the username and password must not be the same input for basic security
                {
                    Console.WriteLine("                                               Account Created!");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::");

                    string[] questions = new string[0];
                    string[] answer = new string[0];

                    bool RunTime = true;
                    while (RunTime)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("\n");
                        Console.WriteLine("                                                Pick an Option");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("                                            [1] Add a Card");
                        Console.WriteLine("                                            [2] Start the quiz");
                        Console.WriteLine("                                            [3] Exit");
                        Console.Write($"                                              {UserN}'s Choice: ");
                        int choices = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("\n\n\n");
                        Console.Clear();

                        switch (choices)
                        {
                            case 1: //Feature: adding a card
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.Write("                         Flipzo: How many questions do you want to generate? ");
                                int n = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine();
                                Array.Resize(ref questions, n);
                                Array.Resize(ref answer, n);

                                Console.WriteLine();
                                for (int i = 0; i < n; i++)
                                {
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    Console.Write($"Question {i + 1}:  ");
                                    questions[i] = Console.ReadLine();

                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.Write($"Answer for {i + 1}:  ");
                                    answer[i] = Console.ReadLine();
                                    Console.WriteLine();

                                }

                                RandomFlashCard(UserN, questions, answer);

                                bool restart = true;
                                while (restart) //Feature: option to try again or not the quiz
                                {
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    Console.Write("                              Flipzo: Would you like to try again? (Y/N) ");
                                    string restartChoice = Console.ReadLine().ToUpper();

                                    Console.WriteLine();

                                    if (restartChoice == "Y")
                                    {
                                        RandomFlashCard(UserN, questions, answer);
                                    }
                                    else if (restartChoice == "N")
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                                        Console.WriteLine("                              Flipzo: It's okay. You can try again anytime.");
                                        restart = false;
                                    }
                                    else
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                                        Console.WriteLine("                              Invalid choice. Please type Y or N.");
                                    }
                                }


                                break;

                            case 2: //Feature: starting the Flashcard Quiz
                                if (questions.Length == 0)
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                    Console.WriteLine("                               Flipzo: You don't have any flashcards yet!");
                                }
                                else
                                {
                                    RandomFlashCard(UserN, questions, answer);
                                }
                                break;

                            case 3: //Feature: exiting the system
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.WriteLine();
                                Console.Write("                                  Flipzo: Do you really want to go [Y/N]...? ");
                                string UserChoice = Console.ReadLine().ToUpper();
                                Console.WriteLine();

                                if (UserChoice == "Y")
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                    Console.WriteLine($"                             Flipzo: Flipzo bids goodbye... See you again {UserN}!");
                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                    Console.WriteLine("**********************************************************************************************************");
                                    RunTime = false;
                                }
                                else if (UserChoice == "N")
                                {
                                    Console.WriteLine("                                  Flipzo: Welcome back!");
                                }
                                else
                                {
                                    Console.WriteLine("                               Invalid input. Please enter Y or N.");
                                }
                                break;

                            default: //Feature: if none from the choices above
                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                                Console.WriteLine("                      Flipzo: You chose a wrong option. Please try again...");
                                break;

                        }
                    }
                }

                else
                {
                    //Feature: automatically exits the system
                    Console.WriteLine("                  Your Username and Password is the same. Please create an account again.");
                }
                
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("                                          Thank you for using Flashuka! Bye.");
                Console.WriteLine("**********************************************************************************************************");
            }

            Console.ResetColor();
        }    
    }
}