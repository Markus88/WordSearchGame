using WordSearchGame.Logic;

namespace WordSearchGame.Controller
{
    public class SetupGameController
    {
        private GameEngine _gameEngine;
        private DataHandler _dataHandler;

        public SetupGameController()
        {
            _gameEngine = new GameEngine();
            _dataHandler = new DataHandler();
        }

        public bool VerifyWords(string inputWords, int gridSize)
        {
            return _dataHandler.VerifyWords(inputWords, gridSize);
        }

        public GridInformations SetupGame(string words, int gridSize)
        {
            _gameEngine.HandleSetupWords(words, gridSize);
            _gameEngine.HandleSetupGrid(gridSize);

            return new GridInformations
            {
                Words = _gameEngine.Words,
                Grid = _gameEngine.Grid,
                WinningGridLocation = _gameEngine.WinningGrid
            };
        }
    }
}