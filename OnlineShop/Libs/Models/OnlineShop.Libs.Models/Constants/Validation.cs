namespace OnlineShop.Libs.Models.Constants
{
    public static class Validation
    {
        public static class Color
        {
            public const int NameMinLenght = 2;
            public const int NameMaxLenght = 30;

            public const int HexColorMaxLength = 10;
        }

        public static class Regexs
        {
            public const string EnBgNumSpaceMinus = @"^[a-zA-Zа-яА-Я0-9\-\s]+$";
            public const string EnBgNumSpace = @"^[a-zA-Zа-яА-Я0-9\s]+$";
            public const string EnBgNumSpaceMinusPlusMore = @"^[a-zA-Zа-яА-Я0-9\-\s\+\!\?]+$";
            public const string EnBgNumSpaceQuotesMinusPlusMore = @"^[a-zA-Zа-яА-Я0-9\-\s\+\!\?""\']+$";
        }
    }
}
