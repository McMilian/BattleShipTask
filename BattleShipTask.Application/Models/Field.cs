using BattleShipTask.Application.Models.Enums;

namespace BattleShipTask.Application.Models
{
    public class Field
    {
        public Position Position { get; }
        public Content? Content { get; set; }

        public bool IsShip => Content == Enums.Content.Ship;

        public Field(Position position)
        {
            Position = position;
        }

        public Field(Position position, Content content)
        {
            Position = position;
            Content = content;
        }
    }
}
