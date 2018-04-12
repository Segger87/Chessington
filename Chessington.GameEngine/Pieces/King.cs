using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class King : Piece
    {
        public King(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var myLocation = board.FindPiece(this);
            var legalMoves = new List<Square>();
            var movesKingCanMakeForwardsCol = new Square(myLocation.Row, myLocation.Col + 1);
            var movesKingCanMakeForwardsRow = new Square(myLocation.Row, myLocation.Col - 1);
            var movesKingCanMakeBackwardsCol = new Square(myLocation.Row + 1, myLocation.Col);
            var movesKingCanMakeBackwardsRow = new Square(myLocation.Row - 1, myLocation.Col);
            var movesKingCanMakeDiagForward = new Square(myLocation.Row + 1, myLocation.Col + 1);
            var movesKingCanMakeDiagUp= new Square(myLocation.Row + 1, myLocation.Col - 1);
            var movesKingCanMakeDiagBackward2 = new Square(myLocation.Row - 1, myLocation.Col + 1);
            var movesKingCanMakeDiagBackward = new Square(myLocation.Row - 1, myLocation.Col - 1);

            if (movesKingCanMakeForwardsCol != myLocation)
            {
                legalMoves.Add(movesKingCanMakeBackwardsCol);
                legalMoves.Add(movesKingCanMakeForwardsRow);
                legalMoves.Add(movesKingCanMakeBackwardsRow);
                legalMoves.Add(movesKingCanMakeForwardsCol);
                legalMoves.Add(movesKingCanMakeDiagForward);
                legalMoves.Add(movesKingCanMakeDiagBackward);
                legalMoves.Add(movesKingCanMakeDiagUp);
                legalMoves.Add(movesKingCanMakeDiagBackward2);
            }

            return legalMoves;
        }
    }
}