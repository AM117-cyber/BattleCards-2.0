namespace WindowsFormsApp1
{
    public partial class GameIsOver : Form
    {
        private Form startForm { get; set; }
        public GameIsOver(string message)
        {
            InitializeComponent();
            label1.Text = message;
        }

    }
}