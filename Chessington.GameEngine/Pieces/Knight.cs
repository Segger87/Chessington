using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Knight : Piece
    {
        public Knight(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var myLocation = board.FindPiece(this);
            var legalMoves = new List<Square>();

            var placesKnightsCanMove = new Square(myLocation.Row + 2, myLocation.Col + 1);
            var placesKnightsCanMoveAgain = new Square(myLocation.Row + 2, myLocation.Col - 1);

            var placesKnightsCanMove1 = new Square(myLocation.Row - 2, myLocation.Col + 1);
            var placesKnightsCanMoveAgain1 = new Square(myLocation.Row - 2, myLocation.Col - 1);

            var placesKnightsCanMove2 = new Square(myLocation.Row + 1, myLocation.Col + 2);
            var placesKnightsCanMoveAgain2 = new Square(myLocation.Row + 1, myLocation.Col - 2);

            var placesKnightsCanMove3 = new Square(myLocation.Row - 1, myLocation.Col - 2);
            var placesKnightsCanMoveAgain3 = new Square(myLocation.Row - 1, myLocation.Col + 2);

            if (placesKnightsCanMove != myLocation)
            {
                legalMoves.Add(placesKnightsCanMove);
                legalMoves.Add(placesKnightsCanMoveAgain);
                legalMoves.Add(placesKnightsCanMoveAgain1);
                legalMoves.Add(placesKnightsCanMove1);
                legalMoves.Add(placesKnightsCanMoveAgain2);
                legalMoves.Add(placesKnightsCanMove2);
                legalMoves.Add(placesKnightsCanMoveAgain3);
                legalMoves.Add(placesKnightsCanMove3);
            }

            return legalMoves;
        }
    }
}