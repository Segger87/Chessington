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
                var withinBoardBoundarys = board.OnBoard(placesBishopCanMoveTo);

                if (placesBishopCanMoveTo != myLocation && withinBoardBoundarys)
                {
                    legalMoves.Add(placesBishopCanMoveTo);
                }       
                placesBishopCanMoveTo = new Square(myLocation.Row - i, myLocation.Col - i);
                withinBoardBoundarys = board.OnBoard(placesBishopCanMoveTo);

                if (placesBishopCanMoveTo != myLocation && withinBoardBoundarys)
                {
                    legalMoves.Add(placesBishopCanMoveTo);
                }
                placesBishopCanMoveTo = new Square(myLocation.Row + i, myLocation.Col - i);
                withinBoardBoundarys = board.OnBoard(placesBishopCanMoveTo);

                if (placesBishopCanMoveTo != myLocation && withinBoardBoundarys)
                {
                    legalMoves.Add(placesBishopCanMoveTo);
                }
                placesBishopCanMoveTo = new Square(myLocation.Row - i, myLocation.Col + i);
                withinBoardBoundarys = board.OnBoard(placesBishopCanMoveTo);

                if (placesBishopCanMoveTo != myLocation && withinBoardBoundarys)
                {
                    legalMoves.Add(placesBishopCanMoveTo);
                }
            }

            return legalMoves;
        }
    }
}