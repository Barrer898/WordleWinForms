using System.Transactions;

namespace WordleWinForms
{
    public partial class WordleMain : Form
    {
        public int currentletter = 0;
        public string wordleAnswer = "TESTA";
        public WordleMain()
        {
            InitializeComponent();
            LetterArray.Fill(this);
        }
        public void WriteLetter(char letter)
        {
            LetterArray.Array[currentletter / 5, currentletter % 5].Text = letter.ToString();
            currentletter++;
            DBG_Output.Text = currentletter.ToString();
        }

        private void BTN_LetterT_Click(object sender, EventArgs e)
        {
            WriteLetter('T');
        }
    }
}
