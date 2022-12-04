
namespace WindowsFormsApp1
{
    public partial class StartPage : Form
    {
        private SetPlayer setPlayerForm {get; set;}
        private CreateCardPage cardUIFriendly { get; set;}
        private CreateCardPlainText cardPlainText { get; set;}
        public StartPage()
        {
            InitializeComponent();
            setPlayerForm = new SetPlayer(this);
            cardUIFriendly = new CreateCardPage(this);
            cardPlainText = new CreateCardPlainText(this);
        }

        private void start_bt_Click(object sender, EventArgs e)
        {
            setPlayerForm.Show();
            Hide();
        }

        private void card_friendly_ui_bt_Click(object sender, EventArgs e)
        {
            cardUIFriendly.Show();
            Hide();
        }

        private void cad_plain_text_bt_Click(object sender, EventArgs e)
        {
            cardPlainText.Show();
            Hide();
        }

        private void StartPage_FormClosing(object sender, FormClosingEventArgs e)
        {
            setPlayerForm.Close();
            cardPlainText.Close();
            cardUIFriendly.Close();
        }
    }
}
