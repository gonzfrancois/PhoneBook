using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Core.Model
{
    public class CardDisplayAttribute : Attribute
    {
        public readonly string DisplayName;
        public readonly int Width;
        public readonly int Column;

        public CardDisplayAttribute(string displayName, int width, int column)
        {
            DisplayName = displayName;
            Width = width;
            Column = column;
        }
    }
}
