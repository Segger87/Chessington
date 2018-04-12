using System.Collections.Generic;

namespace Chessington.GameEngine.Pieces
{
    public class Rook : Piece
    {
        private static readonly Dictionary<string, List<int>> directions = new Dictionary<string, List<int>>
        {
            { "north", new List<int>{-1, 0}},
            { "east", new List<int>{0, 1}},
            { "west", new List<int>{0, -1}},
            { "south", new List<int>{1, 0}}
        };

        public Rook(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            return Steps(board, directions);
        }
    }
}