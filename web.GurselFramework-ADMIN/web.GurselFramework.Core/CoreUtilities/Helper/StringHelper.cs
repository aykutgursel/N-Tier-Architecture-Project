namespace web.GurselFramework.Core.CoreUtilities.Helper
{
    public static class StringHelper
    {
        #region Const
        public static readonly char[] TrChars = { 'ç', 'ı', 'ö', 'ş', 'ü', 'ğ', 'Ç', 'İ', 'Ö', 'Ş', 'Ü', 'Ğ' };

        public static readonly char[] EnChars = { 'c', 'i', 'o', 's', 'u', 'g', 'C', 'I', 'O', 'S', 'U', 'G' };
        #endregion
    
        public static bool IsNull(this string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }

        public static bool IsNotNull(this string value)
        {
            return !string.IsNullOrWhiteSpace(value);
        }

        public static bool IsNumeric(this string value)
        {
            if (value.IsNull())
                return false;


            foreach (char character in value)
            {
                if (!char.IsNumber(character))
                {
                    return false;
                }
            }

            return true;
        }

        public static string ReplaceTurkishCharacter(this string value)
        {
            if (value.IsNotNull())
            {
                for (int i = 0; i < TrChars.Length; i++)
                {
                    value = value.Replace(TrChars[i], EnChars[i]);
                }
            }

            return value;
        }
    }
}