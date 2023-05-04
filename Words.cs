namespace Hangman_Team_3
{
    internal class Words
    {
        private List<string> randomWords = new()
        {
            "Jazz",
            "Kokepunkt",
            "Felg",
            "Matte",
            "Tastatur",
            "Kaffe",
            "English",
            "Dependant",
            "Bob",
            "Plastpose"
        };
        public string FetchWord()
        {
            var Random = new Random ();
            var randomNumber = Random.Next(0 , randomWords.Count);
            return randomWords[randomNumber];
        }
    }
}
