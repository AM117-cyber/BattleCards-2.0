namespace HelloWorld
{
    public partial class GameIsOver : Form
    {
        public GameIsOver(string message)
        {
            InitializeComponent();
            label1.Text = message;
        }

    }
}