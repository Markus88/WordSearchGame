namespace WordSearchGame.Logic
{
    /// <summary>
    /// Denne her fil er lidt rodet og giver ikke nødvendigvis så meget mening. Vil være bedst og nemmest med lokal fil eller lign. 
    /// En måde at holde noget persistence data. (F.eks gennem DB).
    /// </summary>
    public class Settings
    {
        public int GridRows { get; private set; }
        public int GridColumns { get; private set; }
        public int GridSize { get; set; }
        public int SizeFactor { get; set; } = 60;
        public List<ComboBoxItem> PredifinedGridSize { get; private set; }

        public Settings()
        {
            PredifinedGridSize = new List<ComboBoxItem>
            {
                new ComboBoxItem(8),
                new ComboBoxItem(10),
                new ComboBoxItem(12)
            };
        }

        public void SetGridSize(int row, int column)
        {
            GridRows = column;
            GridColumns = row;
        }
    }

    public class ComboBoxItem
    {
        public int Value { get; private set; }
        public object ObjectValue { get; private set; }

        public ComboBoxItem(int value)
        {
            Value = value;
            ObjectValue = value;
        }
    }
}