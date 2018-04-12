using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Queen : Piece
    {

        private static readonly Dictionary<string, List<int>> directions = new Dictionary<string, List<int>>
        {
            { "north", new List<int>{-1, 0}},
            { "east", new List<int>{0, 1}},
            { "west", new List<int>{0, -1}},
            { "south", new List<int>{1, 0}},
            { "northWest", new List<int>{-1, -1}},
            { "northEast", new List<int>{-1, 1}},
            { "southWest", new List<int>{1, -1}},
            { "southEast", new List<int>{1, 1}}
        };
        public Queen(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            return Steps(board, directions);
        }
    }
}