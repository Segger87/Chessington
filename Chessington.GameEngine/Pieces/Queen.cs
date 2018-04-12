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
                var placeCanMove = new Square(myLocation.Row + i, myLocation.Col + i);
                var onBoard = board.OnBoard(placeCanMove);

                if (placeCanMove != myLocation && onBoard)
                {
                    legalMoves.Add(placeCanMove);
                }

                placeCanMove = new Square(myLocation.Row - i, myLocation.Col - i);
                onBoard = board.OnBoard(placeCanMove);

                if (placeCanMove != myLocation && onBoard)
                {
                    legalMoves.Add(placeCanMove);
                }

                placeCanMove = new Square(myLocation.Row + i, myLocation.Col - i);
                onBoard = board.OnBoard(placeCanMove);

                if (placeCanMove != myLocation && onBoard)
                {
                    legalMoves.Add(placeCanMove);
                }

                placeCanMove = new Square(myLocation.Row - i, myLocation.Col + i);
                onBoard = board.OnBoard(placeCanMove);

                if (placeCanMove != myLocation && onBoard)
                {
                    legalMoves.Add(placeCanMove);
                }

                placeCanMove = new Square(i, myLocation.Col);
                if (placeCanMove != myLocation)
                {
                    legalMoves.Add(placeCanMove);
                }

                placeCanMove = new Square(myLocation.Row, i);
                if (placeCanMove != myLocation)
                {
                    legalMoves.Add(placeCanMove);
                }
            }

            return legalMoves;
        }
    }
}