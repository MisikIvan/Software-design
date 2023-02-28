using System;

namespace TicTacToe
{
    class Program
    {
        static char[,] board = new char[3, 3];
        static int turns = 0;
        static bool playAgain = true;
        static int player1Wins = 0;
        static int player2Wins = 0;
        static int draws = 0;

        static void Main(string[] args)
        {
            while (playAgain)
            {
                ResetBoard();
                turns = 0;

                Console.WriteLine("Welcome to Tic Tac Toe!");
                Console.WriteLine("Player 1, please enter your name:");
                string player1Name = Console.ReadLine();
                Console.WriteLine("Player 2, please enter your name:");
                string player2Name = Console.ReadLine();
                char player1Symbol = 'X';
                char player2Symbol = 'O';

                Console.WriteLine("{0} is {1} and {2} is {3}", player1Name, player1Symbol, player2Name, player2Symbol);

                bool gameEnd = false;
                while (!gameEnd)
                {
                    DrawBoard();

                    if (turns % 2 == 0)
                    {
                        Console.WriteLine("{0}'s turn", player1Name);
                        Play(player1Symbol);
                    }
                    else
                    {
                        Console.WriteLine("{0}'s turn", player2Name);
                        Play(player2Symbol);
                    }

                    if (CheckWin() || CheckDraw())
                    {
                        gameEnd = true;
                        DrawBoard();

                        if (CheckDraw())
                        {
                            Console.WriteLine("It's a draw!");
                            draws++;
                        }
                        else
                        {
                            if (turns % 2 == 0)
                            {
                                Console.WriteLine("{0} wins!", player1Name);
                                player1Wins++;
                            }
                            else
                            {
                                Console.WriteLine("{0} wins!", player2Name);
                                player2Wins++;
                            }
                        }

                        Console.WriteLine("Player 1 wins: {0}", player1Wins);
                        Console.WriteLine("Player 2 wins: {0}", player2Wins);
                        Console.WriteLine("Draws: {0}", draws);
                        Console.WriteLine("Play again? (y/n)");
                        string answer = Console.ReadLine().ToUpper();
                        if (answer == "Y")
                        {
                            gameEnd = false;
                            playAgain = true;

                            if (player1Symbol == 'X')
                            {
                                player1Symbol = 'O';
                                player2Symbol = 'X';
                            }
                            else
                            {
                                player1Symbol = 'X';
                                player2Symbol = 'O';
                            }
                        }
                        else if (answer == "N")
                        {
                            gameEnd = true;
                            playAgain = false;
                        }
                    }
                }
            }
        }

        static void ResetBoard()
        {
            board = new char[3, 3]
            {
                {'1', '2', '3'},
                {'4', '5', '6'},
                {'7', '8', '9'}
            };
        }

        static void DrawBoard()
        {
            Console.Clear();
            Console.WriteLine(" {0} | {1} | {2} ", board[0, 0], board[0, 1], board[0, 2]);
            Console.WriteLine("---+---+---");
            Console.WriteLine(" {0} | {1} | {2} ", board[1, 0], board[1, 1], board[1, 2]);
            Console.WriteLine("---+---+---");
            Console.WriteLine(" {0} | {1} | {2} ", board[2, 0], board[2, 1], board[2, 2]);
        }
        static void Play(char symbol)
        {
            bool validInput = false;
            while (!validInput)
            {
                Console.Write("Enter a number (1-9) to place your symbol: ");
                string input = Console.ReadLine();
                if (int.TryParse(input, out int number))
                {
                    if (number >= 1 && number <= 9)
                    {
                        int row = (number - 1) / 3;
                        int col = (number - 1) % 3;
                        if (board[row, col] != 'X' && board[row, col] != 'O')
                        {
                            board[row, col] = symbol;
                            validInput = true;
                            turns++;
                        }
                        else
                        {
                            Console.WriteLine("That cell is already taken, try again.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input, please enter a number between 1 and 9.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input, please enter a number.");
                }
            }
        }

        static bool CheckWin()
        {
            // Check rows
            for (int row = 0; row < 3; row++)
            {
                if (board[row, 0] == board[row, 1] && board[row, 1] == board[row, 2])
                {
                    return true;
                }
            }

            // Check columns
            for (int col = 0; col < 3; col++)
            {
                if (board[0, col] == board[1, col] && board[1, col] == board[2, col])
                {
                    return true;
                }
            }

            // Check diagonals
            if (board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2])
            {
                return true;
            }
            if (board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])
            {
                return true;
            }

            return false;
        }

        static bool CheckDraw()
        {
            return turns >= 9;
        }

        static char Symbol(char symbol)
        {
            if (symbol == 'X' || symbol == 'O')
            {
                return symbol;
            }
            return ' ';
        }
    }
}
