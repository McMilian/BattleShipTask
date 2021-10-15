using BattleShipTask.Models;
using BattleShipTask.Models.Enums;
using System.Linq;

namespace BattleShipTask
{
    public static class Extensions
    {
        public static Field GetFieldByPosition(this Battlefield battlefield, int row, int column)
        {
            return battlefield.Fields.Single(field => field.Position.Row == row && //should be exception handling done
                 field.Position.Column == column);
        }

        public static Field GetFieldByPosition(this Battlefield battlefield, Position position)
        {
            return battlefield.Fields.Single(field => field.Position.Row == position.Row && //should be exception handling done
                 field.Position.Column == position.Column);
        }

        public static bool IsTrue(this string value)
        {
            return value.ToUpper() == "Y";
        }

        public static string Map(this FieldValue? content, bool showShips) 
        {
            switch (content)
            {
                case FieldValue.Ship:
                    if(showShips)
                    {
                        return "()";
                    }
                    else
                    {
                        return "  ";
                    }
                case FieldValue.Wreck:
                    return "XX";
                case FieldValue.Water:
                    return "~~";
                case FieldValue.ShotWater:
                    return "  ";
                default:
                    return "  ";
            }
        }
    }
}
