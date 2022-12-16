
namespace WindowsFormsApp1
{
    public partial class ErrorCreatingCard : Form
    {
        public ErrorCreatingCard(string e)
        {
            InitializeComponent();
            this.label2.Text = e;
        }

    }
}
