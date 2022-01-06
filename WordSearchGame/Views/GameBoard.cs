using WordSearchGame.Controller;
using WordSearchGame.Logic;

namespace WordSearchGame
{
    public partial class GameBoard : Form
    {
        private Settings _settings;
        private SetupGameController _setupGameController;
        private GridInformations _gridInformations;

        public GameBoard()
        {
            InitializeComponent();
            StartGameButtonStatus();

            _settings = new Settings();
            _setupGameController = new SetupGameController();

            foreach (var gridSize in _settings.PredifinedGridSize)
            {
                comboBox_gridSize.Items.Add(gridSize.ObjectValue);
            }
        }

        private void MapDataToGameBoard(Color color, char[,] grid)
        {
            var formGraphics = CreateGraphics();
            var drawFont = new Font("Verdana", Convert.ToInt32(Math.Floor(16d)));
            var drawBrush = new SolidBrush(color);
            var calibrationFactor = 10;

            for (int i = 0; i < _settings.GridSize; i++)
                for (int j = 0; j < _settings.GridSize; j++)
                {
                    if (grid[i, j] != '\0')
                    {
                        var characterToMap = string.Empty + grid[i, j];
                        formGraphics.DrawString(characterToMap, drawFont, drawBrush,
                            (i + 1) * _settings.SizeFactor + calibrationFactor, (j + 1) * _settings.SizeFactor + calibrationFactor);
                    }
                }

            drawFont.Dispose();
            drawBrush.Dispose();
            formGraphics.Dispose();
            // Tegne ide fra: https://msdn.microsoft.com/en-us/library/9why95hd%28v=vs.110%29.aspx?f=255&MSPPError=-2147217396
        }

        private void StartGameButtonStatus()
        {
            if (string.IsNullOrEmpty(comboBox_gridSize.Text) || string.IsNullOrEmpty(textBox_wordList.Text)) button_startGame.Enabled = false;
            else button_startGame.Enabled = true;
        }
        private void ClearGrid()
        {
            Invalidate();
            Refresh();
        }

        #region Events
        private void Button_startGame_Click(object sender, EventArgs e)
        {
            ClearGrid();
            var extractedWords = textBox_wordList.Text;
            _settings.GridSize = _settings.PredifinedGridSize[comboBox_gridSize.SelectedIndex].Value;

            if (!_setupGameController.VerifyWords(extractedWords, _settings.GridSize))
            {
                MessageBox.Show(string.Format(ResourceMessages.warningGridAndAmountOfWordsMustMatch, _settings.GridSize));
                return;
            }

            _gridInformations = _setupGameController.SetupGame(extractedWords, _settings.GridSize);
            MapDataToGameBoard(Color.Black, _gridInformations.Grid);
        }

        private void Button_seeWinningLocation_Click(object sender, EventArgs e)
        {
            MapDataToGameBoard(Color.Red, _gridInformations.WinningGridLocation);
        }

        private void TextBox_wordList_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            StartGameButtonStatus();
        }

        private void ComboBox_gridSize_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            StartGameButtonStatus();
        }
        #endregion Events
    }
}