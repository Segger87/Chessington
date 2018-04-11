using System;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Rook : Piece
    {
        public Rook(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var myLocation = board.FindPiece(this);
            var legalMoves = new List<Square>();

            for (var i = 0; i < 8; i++)
            {
                var placesRookCanMoveTo = new Square(i, myLocation.Col);
                if (placesRookCanMoveTo != myLocation)
                {
                    legalMoves.Add(placesRookCanMoveTo);
                }
                placesRookCanMoveTo = new Square(myLocation.Row, i);
                if (placesRookCanMoveTo != myLocation)
                {
                    legalMoves.Add(placesRookCanMoveTo);
                }
            }

            return legalMoves;
        }
    }
}