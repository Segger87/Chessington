using System;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public abstract class Piece
    {

        protected Piece(Player player)
        {
            Player = player;
        }

        public Square MyLocation(Board board)
        {
            return board.FindPiece(this);
        }

        public Player Player { get; private set; }

        public abstract IEnumerable<Square> GetAvailableMoves(Board board);

        //virtual allows an override 
        public virtual void MoveTo(Board board, Square newSquare)
        {
            var currentSquare = board.FindPiece(this);
            board.MovePiece(currentSquare, newSquare);
        }

        public List<Square> Steps(Board board, Dictionary<string, List<int>> directions)
        {
            var legalMoves = new List<Square>();

            foreach (var directionName in directions.Keys)
            {
                var direction = directions[directionName];
                for (var i = 1; i<GameSettings.BoardSize; i++)
                {
                    var step = new Square(
                        MyLocation(board).Row + direction[0] * i,
                        MyLocation(board).Col + direction[1] * i);
                    if (!board.OnBoard(step) || board.isSquareOccupied(step))
                    {
                        break;
                    }
                    legalMoves.Add(step);
                }
            }

            return legalMoves;
        }
    }
}