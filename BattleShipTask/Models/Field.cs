using BattleShipTask.Models.Enums;

namespace BattleShipTask.Models
{
    public class Field
    {
        public Position Position { get; }
        public FieldValue? Content { get; set; }

        public Field(Position position)
        {
            Position = position;
        }

        public Field(Position position, FieldValue content)
        {
            Position = position;
            Content = content;
        }
    }
}
