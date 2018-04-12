using System.Collections.Generic;

namespace Chessington.GameEngine.Pieces
{
    public class Rook : Piece
    {
        public Rook(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var legalMoves = new List<Square>();

            for (var i = 0; i < GameSettings.BoardSize; i++)
            {
                var south = new Square(MyLocation(board).Row + i, MyLocation(board).Col);
                if (board.OnBoard(south) && board.isSquareOccupied(south))
                {
                    break;
                }
                legalMoves = OnlyMoveIfPossible(board, legalMoves, south);
            }

            for (var i = 0; i < GameSettings.BoardSize; i++)
            {
                var east = new Square(MyLocation(board).Row, MyLocation(board).Col + i);
                if (board.OnBoard(east) && board.isSquareOccupied(east))
                {
                    break;
                }
                legalMoves = OnlyMoveIfPossible(board, legalMoves, east);
            }

            for (var i = 0; i < GameSettings.BoardSize; i++)
            {
                var north = new Square(MyLocation(board).Row - i, MyLocation(board).Col);
                if(board.OnBoard(north) && board.isSquareOccupied(north))
                {
                    break;
                }
                legalMoves = OnlyMoveIfPossible(board, legalMoves, north);
            }

            for (var i = 0; i < GameSettings.BoardSize; i++)
            {
                var west = new Square(MyLocation(board).Row, MyLocation(board).Col - i);
                if (board.OnBoard(west) && board.isSquareOccupied(west))
                {
                    break;
                }
                legalMoves = OnlyMoveIfPossible(board, legalMoves, west);
            }

            return legalMoves;
        }
        private List<Square> OnlyMoveIfPossible(Board board, List<Square> moves, Square move)
        {
            if (board.isSquareOccupied(move) || move == MyLocation(board))
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