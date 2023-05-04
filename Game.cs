namespace Hangman_Team_3
{
    internal class Game
    {

        private int _failCount;
        private GameState _gameState;
        private List<char>? _guesses;
        private Words _words;
        private string _correctWord;
        private string? _shownWord;
        public Game()
        {
            _failCount = 0;
            _gameState = new GameState();
            _guesses = new List<char>();
            _words = new Words();
            _correctWord = _words.FetchWord().ToUpper();
            for(int i = 0; i < _correctWord.Length; i++)
            {
                _shownWord += "_";
            }
        }

        public void UserInput()
        {

            char userGuess = Console.ReadLine().ToUpper().First();

            if (!char.IsLetter(userGuess))
            {
                Console.WriteLine("Ugyldig tegn");
                return;
            }
            if (_guesses.Contains(userGuess)) {
                Console.WriteLine("Guess something else dumbass");
                return;
            }
            _guesses.Add(userGuess);
            CheckIfCorrect(userGuess);
            Show();

        }
        private void CheckIfCorrect(char guess)
        {

            if (!_correctWord.Contains(guess))
            {
                _failCount++;
                Console.WriteLine($"Ordet inneholder ikke '{guess}'...");
                return;
            }
            else RefreshWord(guess);

        }

        private void RefreshWord(char guess)
        {
            var temp = _shownWord.ToList();
            for (var i = 0; i < _correctWord.Length; i++)
            {
                if (_correctWord[i] == guess)
                {
                    temp[i] = _correctWord[i];
                }
            }
            
            _shownWord = string.Join("", temp);

        }

        public void Show()
        {
            Console.Clear();
            var currentState = _gameState.FetchVisualGamestate(_failCount);
            var gameStateLines = currentState.Split("\n").ToList();
            var guessedChars = string.Join(" ", _guesses);


            gameStateLines[3] = $"| | / /      ||                     {_shownWord} \r";

            gameStateLines[4] = $"| |/ /       ||                     {guessedChars}\r";

            foreach(var line in gameStateLines)
            {
                Console.WriteLine($"{line}");
            }
            if (_failCount == 5)
            {
                Console.WriteLine("ur dead");
                return;
            }
            if(_shownWord == _correctWord)
            {
                Console.WriteLine("you won");
                return;
            }
            UserInput();
        }
        public void StartGame()
        {
            Show();
        }
    }
}
