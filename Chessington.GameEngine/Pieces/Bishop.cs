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
            

            for (var i = 0; i < 8; i++)
            {
                var placesBishopCanMoveTo = new Square(myLocation.Row + i, myLocation.Col + i);
                if (placesBishopCanMoveTo != myLocation && placesBishopCanMoveTo.Row < 8 && placesBishopCanMoveTo.Col < 8)
                {
                    legalMoves.Add(placesBishopCanMoveTo);
                }       
                placesBishopCanMoveTo = new Square(myLocation.Row - i, myLocation.Col - i);
                if (placesBishopCanMoveTo != myLocation && placesBishopCanMoveTo.Row > -1 &&
                    placesBishopCanMoveTo.Col > -1)
                {
                    legalMoves.Add(placesBishopCanMoveTo);
                }
                placesBishopCanMoveTo = new Square(myLocation.Row + i, myLocation.Col - i);
                if (placesBishopCanMoveTo != myLocation && placesBishopCanMoveTo.Row < 8 &&
                    placesBishopCanMoveTo.Col > -1)
                {
                    legalMoves.Add(placesBishopCanMoveTo);
                }
                placesBishopCanMoveTo = new Square(myLocation.Row - i, myLocation.Col + i);
                if (placesBishopCanMoveTo != myLocation && placesBishopCanMoveTo.Row > -1 &&
                    placesBishopCanMoveTo.Col < 8)
                {
                    legalMoves.Add(placesBishopCanMoveTo);
                }
            }

            return legalMoves;
        }
    }
}