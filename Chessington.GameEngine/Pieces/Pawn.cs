using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Chessington.GameEngine.Pieces
{
    public class Pawn : Piece
    {
        private bool firstMove;

        public Pawn(Player player)
            : base(player) //base calls the parent constructor with whatever we pass in, and will also do what is in the code block
        {
            firstMove = true;
        }

        public override void MoveTo(Board board, Square newSquare)
        {
            firstMove = false;
            base.MoveTo(board, newSquare); //calls the original parent version of this method
        }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var myLocation = board.FindPiece(this);
            var legalMoves = new List<Square>();

            int direction;
            if (Player == Player.Black)
            {
                direction = 1;
            }
            else
            {
                direction = -1;
            }
            var oneStep = new Square(myLocation.Row + direction, myLocation.Col);
            var twoStep = new Square(myLocation.Row + 2 * direction, myLocation.Col);
            legalMoves = onlyMoveIfPossible(board, legalMoves, oneStep);
            if (firstMove)
            {
                legalMoves = onlyMoveIfPossible(board, legalMoves, twoStep);
            }

            //switch (Player)
            //{
            //    case Player.Black:
            //        {
            //            var positionInfront = new Square(myLocation.Row + 1, myLocation.Col);
            //            var firstMove2Spaces = new Square(myLocation.Row + 2, myLocation.Col);

            //            if (firstMove)
            //            {
            //                legalMoves.Add(firstMove2Spaces);
            //            }
            //            if (!board.isSquareOccupied(positionInfront))
            //            {
            //                legalMoves.Add(positionInfront);
            //            }
            //            break;
            //        }
            //    case Player.White:
            //        {
            //            var positionInfront = new Square(myLocation.Row - 1, myLocation.Col);
            //            if (!board.isSquareOccupied(positionInfront))
            //            {
            //                legalMoves.Add(positionInfront);
            //            }

            //            break;
            //        }
            //}
            return legalMoves;
        }

        private List<Square> onlyMoveIfPossible(Board board, List<Square> moves, Square move)
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