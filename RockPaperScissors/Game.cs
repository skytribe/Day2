using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors
{
    class Game
    {
        /// <summary>
        /// Dtermine the winner out of the two players provides
        /// </summary>
        /// <param name="player1"></param>
        /// <param name="player2"></param>
        /// <returns></returns>
        public static Winner Fight(PlayAction player1, PlayAction player2)
        {
            if (player1 == null || player2 == null)
                throw new Exception("Invalid player state provided to fight");

            Debug.Assert(player1 != null, "Player 1 is set to null");
            Debug.Assert(player2 != null, "Player 2 is set to null");

            Winner result = Winner.None;
            if (player1.Act == player2.Act)
            {
                result = Winner.None;
            }
            else
            {
                switch (player1.Act)
                {
                    case Acts.Rock:
                        {
                            if (player2.Act == Acts.Paper)
                            {
                                result = Winner.Player2;
                            }
                            else if (player2.Act == Acts.Scissor)
                            {
                                result = Winner.Player1;
                            }
                            break;
                        }
                    case Acts.Paper:
                        {
                            if (player2.Act == Acts.Rock)
                            {
                                result = Winner.Player1;
                            }
                            else if (player2.Act == Acts.Scissor)
                            {
                                result = Winner.Player2;
                            }
                            break;
                        }
                    case Acts.Scissor:
                        {
                            if (player2.Act == Acts.Rock)
                            {
                                result = Winner.Player2;
                            }
                            else if (player2.Act == Acts.Paper)
                            {
                                result = Winner.Player1;
                            }
                            break;
                        }
                }
            }

            return result;
        }
    }
}
