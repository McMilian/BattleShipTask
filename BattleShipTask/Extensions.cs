using BattleShipTask.Exceptions;
using BattleShipTask.Models;
using BattleShipTask.Models.Enums;
using System.Collections.Generic;
using System.Linq;

namespace BattleShipTask
{
    public static class Extensions
    {
        public static Field GetFieldByPosition(this Battlefield battlefield, int row, int column)
        {
            try
            {
                return battlefield.Fields.Single(field => field.Position.Row == row &&
                    field.Position.Column == column);
            }
            catch
            {
                throw new BattleshipApplicationException("Field is out of Battlefield", ApplicationErrorType.ForbiddenOperation);
            }
        }

        public static void SetFieldContent(this IEnumerable<Field> fields, Position position, Content content)
        {
            fields.Single(field => field.Position.Row == position.Row && 
                field.Position.Column == position.Column).Content = content;
        }

        public static Field? SingleOrDefaultField(this IEnumerable<Field> fields, Position position)
        {
            return fields.SingleOrDefault(field => field.Position.Row == position.Row &&
                field.Position.Column == position.Column);
        }

        public static bool IsTrue(this string value)
        {
            return value.ToUpper() == "Y";
        }

        public static string Map(this Content? content, bool showShips) 
        {
            switch (content)
            {
                case Content.Ship:
                    if(showShips)
                    {
                        return "()";
                    }
                    else
                    {
                        return "  ";
                    }
                case Content.Wreck:
                    return "XX";
                case Content.Water:
                    return "~~";
                default:
                    return "  ";
            }
        }
    }
}
