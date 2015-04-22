using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors
{
    class Program
    {
        public static void Main(string[] args)
        {
            Random ranGenerator = new Random();
            int player1wins = 0;
            int player2wins = 0;
            for (int i = 0; i < 100; i++)
            {
                PlayAction p1 = Program.GeneratePlayer((Acts)ranGenerator.Next(2));
                PlayAction p2 = Program.GeneratePlayer((Acts)ranGenerator.Next(2));
                Winner bresult = Game.Fight(p1, p2);
                Console.WriteLine(Program.GenerateGameString(p1, p2));
                switch (bresult)
                {
                    case Winner.None:
                        {
                            Console.WriteLine("DRAW");
                            break;
                        }
                    case Winner.Player1:
                        {
                            Console.WriteLine("PLAYER1");
                            player1wins++;
                            break;
                        }
                    case Winner.Player2:
                        {
                            Console.WriteLine("PLAYER2");
                            player2wins++;
                            break;
                        }
                }
            }
            Console.WriteLine("*********************************");
            Console.WriteLine("OVERALL RESULT");
            Console.WriteLine(string.Concat("Player1 wins :", player1wins.ToString()));
            Console.WriteLine(string.Concat("Player2 wins :", player2wins.ToString()));
            int num = 100 - (player2wins + player1wins);
            Console.WriteLine(string.Concat("Draw :", num.ToString()));
            Console.ReadLine();
        }

        private static string GenerateGameString(PlayAction player1, PlayAction player2)
        {
            Debug.Assert(player1 != null, "Player1 is null");
            Debug.Assert(player2 != null, "Player2 is null");

            string s = "";
             s = string.Concat("Player1:", Enum.GetName(typeof(Acts), player1.Act), "    Player2:", Enum.GetName(typeof(Acts), player2.Act));
         
            return s;
        }

        /// <summary>
        /// Generate a PlayAction for a given randomtype
        /// which will have a value of 0,1,2 which matches enumeration for Acts (Rock, Paper, Scissors)
        /// </summary>
        /// <param name="randomtype"></param>
        /// <returns></returns>
        private static PlayAction GeneratePlayer(Acts randomtype)
        {
            PlayAction p = null;
            switch (randomtype)
            {
                case Acts.Rock:
                    {
                        p = new PlayerRock();
                        break;
                    }
                case Acts.Paper:
                    {
                        p = new PlayerPaper();
                        break;
                    }
                case Acts.Scissor:
                    {
                        p = new PlayerScissor();
                        break;
                    }
            }
            return p;
        }


    }

}
