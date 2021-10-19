using System.Collections.Generic;
using System.Linq;
using BattleShipTask.Application.Models;
using BattleShipTask.Application.Models.Enums;

namespace BattleShipTask.Application.Extensions
{
    public static class Extensions
    {
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
                    return showShips ? "()" : "  ";
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
