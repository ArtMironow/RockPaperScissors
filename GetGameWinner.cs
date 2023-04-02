using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors
{
    public static class GetGameWinner
    {
        public static string GetWinner(string computerMove, int userInputInt, string[] args)
        {
            userInputInt--;
            int computerMoveInt = 0;
            int half = (args.Length - 1) / 2;

            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] == computerMove)
                {
                    computerMoveInt = i;
                }
            }

            if (userInputInt == computerMoveInt)
            {
                return "DRAW";
            }
            else if ((computerMoveInt > userInputInt && computerMoveInt <= userInputInt + half) || (computerMoveInt < userInputInt && userInputInt > computerMoveInt + half))
            {
                return "You WIN";
            }
            else
            {
                return "You LOSE";
            }  
        }
    }
}
