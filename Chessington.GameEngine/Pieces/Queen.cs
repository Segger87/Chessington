using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Queen : Piece
    {
        public Queen(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var myLocation = board.FindPiece(this);
            var legalMoves = new List<Square>();

            for (var i = 0; i < 8; i++)
            {
                //var placesQueenCanMove = new Square(myLocation.Row + i, myLocation.Col + i);
                //var placesQueenCanMoveDiagDown = new Square(myLocation.Row - i, myLocation.Col - i);
                //var placesQueenCanMoveDiagUp1 = new Square(myLocation.Row - i, myLocation.Col + i);
                //var placesQueenCanMoveDiagUp2 = new Square(myLocation.Row + i, myLocation.Col - i);
                //var placesQueenCanMoveRow = new Square(i, myLocation.Col);
                //var placesQueenCanMoveCol = new Square(myLocation.Row, i);

                //if (placesQueenCanMove != myLocation)
                //{
                //    legalMoves.Add(placesQueenCanMove);
                //    legalMoves.Add(placesQueenCanMoveDiagDown);
                //    legalMoves.Add(placesQueenCanMoveDiagUp1);
                //    legalMoves.Add(placesQueenCanMoveDiagUp2);
                //    legalMoves.Add(placesQueenCanMoveRow);
                //    legalMoves.Add(placesQueenCanMoveCol);
                //}     
                var placesQueenCanMove = new Square(myLocation.Row + i, myLocation.Col + i);
                if (placesQueenCanMove != myLocation && placesQueenCanMove.Row < 8 && placesQueenCanMove.Col < 8)
                {
                    legalMoves.Add(placesQueenCanMove);
                }
                placesQueenCanMove = new Square(myLocation.Row - i, myLocation.Col - i);
                if (placesQueenCanMove != myLocation && placesQueenCanMove.Row > -1 &&
                    placesQueenCanMove.Col > -1)
                {
                    legalMoves.Add(placesQueenCanMove);
                }
                placesQueenCanMove = new Square(myLocation.Row + i, myLocation.Col - i);
                if (placesQueenCanMove != myLocation && placesQueenCanMove.Row < 8 &&
                    placesQueenCanMove.Col > -1)
                {
                    legalMoves.Add(placesQueenCanMove);
                }
                placesQueenCanMove = new Square(myLocation.Row - i, myLocation.Col + i);
                if (placesQueenCanMove != myLocation && placesQueenCanMove.Row > -1 &&
                    placesQueenCanMove.Col < 8)
                {
                    legalMoves.Add(placesQueenCanMove);
                }
                placesQueenCanMove = new Square(i, myLocation.Col);
                if (placesQueenCanMove != myLocation)
                {
                    legalMoves.Add(placesQueenCanMove);
                }
                placesQueenCanMove = new Square(myLocation.Row, i);
                if (placesQueenCanMove != myLocation)
                {
                    legalMoves.Add(placesQueenCanMove);
                }
            }

            return legalMoves;
        }
    }
}