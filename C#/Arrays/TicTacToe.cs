using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    public class TicTacToe
    {
        public bool IsThereAWinner(char[,] board)
        {
            if (
                (board[0, 0] != ' ' && board[0, 0] == board[0, 1] && board[0, 0] == board[0, 2]) ||
                (board[1, 0] != ' ' && board[1, 0] == board[1, 1] && board[1, 0] == board[1, 2]) ||
                (board[2, 0] != ' ' && board[2, 0] == board[2, 1] && board[2, 0] == board[2, 2]) ||
                (board[0, 0] != ' ' && board[0, 0] == board[1, 0] && board[0, 0] == board[2, 0]) ||
                (board[0, 1] != ' ' && board[0, 1] == board[1, 1] && board[0, 1] == board[2, 1]) ||
                (board[0, 2] != ' ' && board[0, 2] == board[1, 2] && board[0, 2] == board[2, 2]) ||
                (board[0, 0] != ' ' && board[0, 0] == board[1, 1] && board[0, 0] == board[2, 2]) ||
                (board[0, 2] != ' ' && board[0, 2] == board[1, 1] && board[0, 2] == board[2, 0])
                )
                return true;
            else
                return false;
        }

        public char WhoIsTheWinner(char[,] board)
        {
            if (board[0, 0] == board[0, 1] && board[0, 0] == board[0, 2]) return board[0, 0];
            if (board[1, 0] == board[1, 1] && board[1, 0] == board[1, 2]) return board[1, 0];
            if (board[2, 0] == board[2, 1] && board[2, 0] == board[2, 2]) return board[2, 0];
            if (board[0, 0] == board[1, 0] && board[0, 0] == board[2, 0]) return board[0, 0];
            if (board[0, 1] == board[1, 1] && board[0, 1] == board[2, 1]) return board[0, 1];
            if (board[0, 2] == board[1, 2] && board[0, 2] == board[2, 2]) return board[0, 2];
            if (board[0, 0] == board[1, 1] && board[0, 0] == board[2, 2]) return board[0, 0];
            if (board[0, 2] == board[1, 1] && board[0, 2] == board[2, 0]) return board[0, 2];
            return ' ';
        }
    }
}
