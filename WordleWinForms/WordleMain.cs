using System.Reflection;
using System.Transactions;

namespace WordleWinForms
{
    public partial class WordleMain : Form
    {
        public int lineNumber = 0;
        public int currentletter = 0;

        public string wordleAnswer = GetRandomLine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Words.txt");
        public WordleMain()
        {
            InitializeComponent();
            LetterArray.Fill(this);
#if RELEASE
                DBG_Output.Visible = false;
#endif
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\"; // Start directory
                openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*"; // File filter
                openFileDialog.Title = "Select a Word List File";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    string randomLine = GetRandomLine(filePath);
                    MessageBox.Show($"Random line: {randomLine}");
                }
            }
        }
        static string GetRandomLine(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("The specified file does not exist.", filePath);
            }

            int lineCount = 0;
            using (var reader = new StreamReader(filePath))
            {
                while (reader.ReadLine() != null)
                {
                    lineCount++;
                }
            }

            Random random = new Random();
            int randomIndex = random.Next(lineCount);
            string randomLine = null;
            using (var reader = new StreamReader(filePath))
            {
                for (int i = 0; i <= randomIndex; i++)
                {
                    randomLine = reader.ReadLine();
                }
            }

            return randomLine;
        }
        public bool isLastLetterInLine()
        {
            return (currentletter - (lineNumber*5)) / 5 == 1;
        }
        public bool isFirstLetterInLine()
        {
            return currentletter % 5 == 0 && lineNumber == (currentletter / 5);
        }
        public void WriteLetter(char letter)
        {
            if (currentletter < 30 && !isLastLetterInLine() && letter != '\b')
            {
                LetterArray.Array[lineNumber, currentletter % 5].Text = "  " + letter.ToString();
                currentletter++;
                DBG_Output.Text = currentletter.ToString();
            }
            if (letter == '\b' && !isFirstLetterInLine() && currentletter != 0)
            {
                currentletter--;
                LetterArray.Array[lineNumber, currentletter % 5].Text = "";
                DBG_Output.Text = currentletter.ToString();
            }
        }
        public void WordTest()
        {         

            if (isFirstLetterInLine() && currentletter != 30)
            {
                MessageBox.Show("You didnt input anything!");
                return;
            }
            if (!isLastLetterInLine() && currentletter != 30)
            {
                MessageBox.Show("Not enough letters!");
                return;
            }
            if (isLastLetterInLine()) // checking time >:)
            {
                int correctLetters = 0;
                for(int i = 0; i < 5;i++)
                {
                    RichTextBox currentLetter = LetterArray.Array[lineNumber, i];
                    char currentChar = currentLetter.Text[currentLetter.Text.Length - 1];
                    if (!wordleAnswer.Contains(currentChar) && currentChar != wordleAnswer[i])
                    {
                        currentLetter.BackColor = Color.Gray;
                        LetterArray.KeyBoardDictonary.TryGetValue(currentChar, out Button _Button);
                        if(_Button.BackColor != Color.Gray && _Button.BackColor != Color.Yellow && _Button.BackColor != Color.Green) _Button.BackColor = Color.Gray;
                        continue;
                    }
                    if (wordleAnswer.Contains(currentChar) && currentChar != wordleAnswer[i])
                    {
                        currentLetter.BackColor = Color.Yellow;
                        LetterArray.KeyBoardDictonary.TryGetValue(currentChar, out Button _Button);
                        if (_Button.BackColor != Color.Green && _Button.BackColor != Color.Yellow) _Button.BackColor = Color.Yellow;
                        continue;
                    }
                    if (wordleAnswer.Contains(currentChar) && currentChar == wordleAnswer[i])
                    {
                        currentLetter.BackColor = Color.Green;
                        correctLetters++;
                        LetterArray.KeyBoardDictonary.TryGetValue(currentChar, out Button _Button);
                        if (_Button.BackColor != Color.Green) _Button.BackColor = Color.Green;
                        continue;
                    }                    
                }
                if(correctLetters == 5)
                {
                    MessageBox.Show("Correct answer!");
                }
                
                lineNumber++;
                if (currentletter == 30 && correctLetters != 5)
                {
                    MessageBox.Show("You failed...");
                }
            }
        }
        private void BTN_Backspace_Click(object sender, EventArgs e)
        {
            WriteLetter('\b');
        }

        private void BTN_Enter_Click(object sender, EventArgs e)
        {
            WordTest();
        }

        private void BTN_LetterQ_Click(object sender, EventArgs e)
        {
            WriteLetter('Q');
        }

        private void BTN_LetterW_Click(object sender, EventArgs e)
        {
            WriteLetter('W');
        }

        private void BTN_LetterE_Click(object sender, EventArgs e)
        {
            WriteLetter('E');
        }

        private void BTN_LetterR_Click(object sender, EventArgs e)
        {
            WriteLetter('R');
        }
        private void BTN_LetterT_Click(object sender, EventArgs e)
        {
            WriteLetter('T');
        }

        private void BTN_LetterY_Click(object sender, EventArgs e)
        {
            WriteLetter('Y');
        }

        private void BTN_LetterU_Click(object sender, EventArgs e)
        {
            WriteLetter('U');
        }

        private void BTN_LetterI_Click(object sender, EventArgs e)
        {
            WriteLetter('I');
        }

        private void BTN_LetterO_Click(object sender, EventArgs e)
        {
            WriteLetter('O');
        }

        private void BTN_LetterP_Click(object sender, EventArgs e)
        {
            WriteLetter('P');
        }

        private void BTN_LetterA_Click(object sender, EventArgs e)
        {
            WriteLetter('A');
        }

        private void BTN_LetterS_Click(object sender, EventArgs e)
        {
            WriteLetter('S');
        }

        private void BTN_LetterD_Click(object sender, EventArgs e)
        {
            WriteLetter('D');
        }

        private void BTN_LetterF_Click(object sender, EventArgs e)
        {
            WriteLetter('F');
        }

        private void BTN_LetterG_Click(object sender, EventArgs e)
        {
            WriteLetter('G');
        }

        private void BTN_LetterH_Click(object sender, EventArgs e)
        {
            WriteLetter('H');
        }

        private void BTN_LetterJ_Click(object sender, EventArgs e)
        {
            WriteLetter('J');
        }

        private void BTN_LetterK_Click(object sender, EventArgs e)
        {
            WriteLetter('K');
        }

        private void BTN_LetterL_Click(object sender, EventArgs e)
        {
            WriteLetter('L');
        }

        private void BTN_LetterZ_Click(object sender, EventArgs e)
        {
            WriteLetter('Z');
        }

        private void BTN_LetterX_Click(object sender, EventArgs e)
        {
            WriteLetter('X');
        }

        private void BTN_LetterC_Click(object sender, EventArgs e)
        {
            WriteLetter('C');
        }

        private void BTN_LetterV_Click(object sender, EventArgs e)
        {
            WriteLetter('V');
        }

        private void BTN_LetterB_Click(object sender, EventArgs e)
        {
            WriteLetter('B');
        }

        private void BTN_LetterN_Click(object sender, EventArgs e)
        {
            WriteLetter('N');
        }

        private void BTN_LetterM_Click(object sender, EventArgs e)
        {
            WriteLetter('M');
        }
    }
}
