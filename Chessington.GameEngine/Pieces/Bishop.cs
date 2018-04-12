using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var myLocation = board.FindPiece(this);
            var legalMoves = new List<Square>();

            for (var i = 1; i < GameSettings.BoardSize; i++)
            {
                var placeBishopCanMoveTo = new Square(myLocation.Row + i, myLocation.Col + i);
                if (!board.OnBoard(placeBishopCanMoveTo) || board.isSquareOccupied(placeBishopCanMoveTo))
                {
                    break;
                }

                legalMoves = OnlyMoveIfPossible(board, legalMoves, placeBishopCanMoveTo);
            }

            for (var i = 1; i < GameSettings.BoardSize; i++)
            {
                var placeBishopCanMoveTo = new Square(myLocation.Row - i, myLocation.Col - i);
                if (!board.OnBoard(placeBishopCanMoveTo) || board.isSquareOccupied(placeBishopCanMoveTo))
                {
                    break;
                }

                legalMoves = OnlyMoveIfPossible(board, legalMoves, placeBishopCanMoveTo);
            }

            for (var i = 1; i < GameSettings.BoardSize; i++)
            {
                var placeBishopCanMoveTo = new Square(myLocation.Row + i, myLocation.Col - i);
                if (!board.OnBoard(placeBishopCanMoveTo) || board.isSquareOccupied(placeBishopCanMoveTo))
                {
                    break;
                }

                legalMoves = OnlyMoveIfPossible(board, legalMoves, placeBishopCanMoveTo);
            }

            for (var i = 1; i < GameSettings.BoardSize; i++)
            {
               var placeBishopCanMoveTo = new Square(myLocation.Row - i, myLocation.Col + i);
                if (!board.OnBoard(placeBishopCanMoveTo) || board.isSquareOccupied(placeBishopCanMoveTo))
                {
                    break;
                }

                legalMoves = OnlyMoveIfPossible(board, legalMoves, placeBishopCanMoveTo);
            }


            return legalMoves;
        }

        private List<Square> OnlyMoveIfPossible(Board board, List<Square> moves, Square move)
        {
            if (board.isSquareOccupied(move))
            {
                return moves;
            }
            else
            {
                moves.Add(move);
                return moves;
            }
        }
    }
}