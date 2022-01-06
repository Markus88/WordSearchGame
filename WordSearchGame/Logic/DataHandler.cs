using System.Text.RegularExpressions;

namespace WordSearchGame.Logic
{
    public class DataHandler
    {
        /// <summary>
        /// Tjek inden spillet, om antal ord og grid størrelse passer sammen.
        /// </summary>
        /// <param name="inputWords"></param>
        /// <param name="gridSize"></param>
        /// <returns></returns>
        public bool VerifyWords(string inputWords, int gridSize)
        {
            var wordsStringSanitised = SanitiseWords(inputWords);
            var numberOfWords = SeperateWords(wordsStringSanitised).Count();

            return numberOfWords == gridSize ? true : false;
        }

        /// <summary>
        /// Sørger for først at klargøre/rengøre alle ord , og fjerne mellemrum og ugyldige karaktere.
        /// </summary>
        /// <param name="inputWords"></param>
        /// <param name="gridSize"></param>
        /// <returns></returns>
        public static string[] HandleListLoad(string inputWords, int gridSize)
        {
            var wordsStringSanitised = SanitiseWords(inputWords);
            var wordsSeperated = SeperateWords(wordsStringSanitised);
            var words = Helper.CapitaliseWordsAll(wordsSeperated);

            return words;
        }
        /// <summary>
        /// Fjerner unødvendige karaktere.
        /// </summary>
        /// <param name="listWords"></param>
        /// <returns></returns>
        private static string SanitiseWords(string listWords)
        {
            var wordsSanitised = Regex.Replace(listWords, "[^A-Za-z æøåÆØÅ]", "");

            return wordsSanitised;
        }
        /// <summary>
        /// Separere ord
        /// </summary>
        /// <param name="listWords"></param>
        /// <returns></returns>
        private static string[] SeperateWords(string listWords)
        {
            var delimiters = new char[] { ',', ' ', ';' };

            var words = listWords.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

            return words;
        }
    }
}