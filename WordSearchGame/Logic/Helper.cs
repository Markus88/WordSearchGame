namespace WordSearchGame.Logic
{
    public static class Helper
    {
        /// <summary>
        /// Hjælpe klasse, til b.la, gør alle karaktere store, udvidet random kald mm.
        /// </summary>
        private static Random random = new Random();

        public static string[] CapitaliseWordsAll(string[] array)
        {
            string[] arrayCapitalised = new string[array.Length];
            for (int word = 0; word < array.Length; word++)
            {
                string wordCapitalised = array[word].ToUpper();
                arrayCapitalised[word] = wordCapitalised;
            }
            return arrayCapitalised;
        }

        public static int CountWordsCharactersAll(string[] array)
        {
            int count = 0;
            foreach (string word in array)
            {
                foreach (char character in word)
                {
                    count++;
                }
            }
            return count;
        }
        public static int CountElements(string[] array)
        {
            int count = 0;
            foreach (string word in array)
            {
                count++;
            }
            return count;
        }

        public static string LongestWord(string[] array)
        {
            string longestWord = "";

            foreach (string word in array)
            {
                if (word.Length > longestWord.Length)
                {
                    longestWord = word;
                }
            }
            return longestWord;
        }

        public static int Random(int intMin, int intMax)
        {
            int intRandom = random.Next(intMin, intMax + 1);

            return intRandom;
        }
        public static char Random(char min, char max)
        {
            char minFixed = char.ToUpper(min);
            char maxFixed = char.ToUpper(max);
            string charSetTotal = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            int indexStart = charSetTotal.IndexOf(minFixed);
            int indexEnd = charSetTotal.IndexOf(maxFixed);
            int charsToInsertLength = (indexEnd - indexStart) + 1;

            if (indexStart == -1 | indexEnd == -1)
            {
                return ('\0');
            }

            string charSet = charSetTotal.Substring(indexStart, charsToInsertLength);
            char charToInsert = charSet[Random(0, charSet.Length - 1)];

            return charToInsert;
        }
    }
}