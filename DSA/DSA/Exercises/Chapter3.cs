using System;
using System.Collections.Generic;

namespace DSA.Exercises
{
    /*
     *
        A common problem for compilers and text editors is determining whether
        the parentheses in a string are balanced and properly nested. For example, the
        string ((())())() contains properly nested pairs of parentheses, while the strings
        )()( and ()) do not. Give an algorithm that returns true if a string contains
        properly nested and balanced parentheses, and false if otherwise. For full credit,
        identify the position of the first offending parenthesis if the string is not properly
        nested and balanced. 
     *
     */
    public static class Chapter3
    {
        public static (bool, int?) P1_isBalanced(string s)
        {
            var stack = new Stack<char>();

            if (s == null) 
                return (true, null);

            for (int i = 0; i < s.Length; i++)
            {
                var item = s[i];

                if (item.Equals('('))
                {
                    stack.Push(item);
                }

                else if (item.Equals(')'))
                {
                    if (stack.Count == 0)
                    {
                        return (false, i);

                    }
                        stack.TryPop(out var c);
                }
            }

            if (stack.Count > 0) return (false, stack.Peek());

            return (true, null);
        }

        /*
         * 
            Give an algorithm that takes a string S consisting of opening and closing
            parentheses, say )()(())()()))())))(, and finds the length of the longest balanced
            parentheses in S, which is 12 in the example above. (Hint: The solution is not
            necessarily a contiguous run of parenthesis from S.)
         *
         */
        public static int P2_FindLongestBalanced(string s)
        {
            int len = s.Length, maxLen = 0, last = -1;

            if (len == 0 || len == 1)
                return 0;

            // Stack to store the index of '('
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < len; i++)
            {
                if (s[i] == '(')
                {
                    stack.Push(i);
                }
                else // s[i] == ')'
                {
                    if (stack.Count == 0)
                    {
                        // No matching '(' — mark this as the new base
                        last = i;
                    }
                    else
                    {
                        stack.Pop();

                        if (stack.Count == 0)
                        {
                            maxLen = Math.Max(maxLen, i - last);
                        }
                        else
                        {
                            maxLen = Math.Max(maxLen, i - stack.Peek());
                        }
                    }
                }
            }

            return maxLen;

        }

        /* 
         * 
            Tic-tac-toe is a game played on an n×n board (typically n = 3) where two
            players take consecutive turns placing “O” and “X” marks onto the board cells.
            The game is won if n consecutive “O” or ‘X” marks are placed in a row, column,
            or diagonal. Create a data structure with O(n) space that accepts a sequence
            of moves, and reports in constant time whether the last move won the game.
         *
         */
        public class TicTacToe
        {
            private readonly int[] _rows;
            private readonly int[] _cols;
            private int _diagonal;
            private int _antiDiagonal;
            private readonly int _size;

            public TicTacToe(int n)
            {
                _size = n;
                _rows = new int[n];
                _cols = new int[n];
                _diagonal = 0;
                _antiDiagonal = 0;
            }

            /// <summary>
            /// Makes a move and returns:
            /// 0 if no one wins,
            /// 1 if Player 1 wins,
            /// 2 if Player 2 wins.
            /// </summary>
            public int Move(int row, int col, int player)
            {
                int toAdd = player == 1 ? 1 : -1;

                _rows[row] += toAdd;
                _cols[col] += toAdd;

                if (row == col)
                    _diagonal += toAdd;

                if (row + col == _size - 1)
                    _antiDiagonal += toAdd;

                if (Math.Abs(_rows[row]) == _size ||
                    Math.Abs(_cols[col]) == _size ||
                    Math.Abs(_diagonal) == _size ||
                    Math.Abs(_antiDiagonal) == _size)
                {
                    return player;
                }

                return 0; // No winner yet
            }

        }


    }
}
