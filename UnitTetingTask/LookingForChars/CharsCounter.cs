using System;

namespace LookingForChars
{
    public static class CharsCounter
    {
        public static int GetMaxConsecutiveUnequalChars(string? str)
        {
            if (str is null || str.Length == 0)
            {
                return 0;
            }

            int maxCount = 1;
            int count = 1;
            for (int i = 1; i < str.Length; i++)
            {
                if (str[i] != str[i - 1])
                {
                    count++;
                    maxCount = Math.Max(maxCount, count);
                }
                else
                {
                    count = 1;
                }
            }

            return maxCount;
        }

        public static int GetMaxConsecutiveIdenticalLatinLetters(string? str)
        {
            if (str is null)
            {
                return 0;
            }

            str = System.Text.RegularExpressions.Regex.Replace(str, @"[^a-zA-Z]", string.Empty);

            if (str.Length == 0)
            {
                return 0;
            }

            int maxCount = 1;
            int count = 1;
            for (int i = 1; i < str.Length; i++)
            {
                if (str[i] == str[i - 1])
                {
                    count++;
                    maxCount = Math.Max(maxCount, count);
                }
                else
                {
                    count = 1;
                }
            }

            return maxCount;
        }

        public static int GetMaxConsecutiveIdenticalDigits(string? str)
        {
            if (str is null)
            {
                return 0;
            }

            str = System.Text.RegularExpressions.Regex.Replace(str, @"[^0-9]", string.Empty);

            if (str.Length == 0)
            {
                return 0;
            }

            int maxCount = 1;
            int count = 1;
            for (int i = 1; i < str.Length; i++)
            {
                if (str[i] == str[i - 1])
                {
                    count++;
                    maxCount = Math.Max(maxCount, count);
                }
                else
                {
                    count = 1;
                }
            }

            return maxCount;
        }
    }
}
