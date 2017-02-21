using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(Player player) 
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var myLocation = board.FindPiece(this);
            var legalMoves = new List<Square>();
            switch (Player)
            {
                case Player.Black:
                {
                    var positionInfront = new Square(myLocation.Row + 1, myLocation.Col);
                    if (board.GetPiece(positionInfront) == null)
                    {
                        legalMoves.Add(positionInfront);
                    }

                    break;
                }
                case Player.White:
                {
                    var positionInfront = new Square(myLocation.Row - 1, myLocation.Col);
                    if (board.GetPiece(positionInfront) == null)
                    {
                        legalMoves.Add(positionInfront);
                    }

                    break;
                }
            }
            return legalMoves;
        }
    }
}