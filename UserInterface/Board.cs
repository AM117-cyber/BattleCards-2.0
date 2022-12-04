
namespace WindowsFormsApp1
{
    public partial class Board : Form
    {
        private Form startForm { get; set; }
        public Board(Form previous)
        {
            InitializeComponent();
            startForm = previous;
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void Board_FormClosed(object sender, FormClosedEventArgs e)
        {
            startForm.Close();
        }

        private void attack_button_Click(object sender, EventArgs e)
        {
            //isAttacking = true;
        }
    }
}
