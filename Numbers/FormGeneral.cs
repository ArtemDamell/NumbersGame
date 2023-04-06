using System;
using System.Windows.Forms;

namespace Numbers
{
    public partial class FormGeneral : Form
    {
        int buttons = 9;
        int current = 0;

        static Random rnd = new Random();
        public FormGeneral()
        {
            InitializeComponent();
            StartGame();
        }

        /// <summary>
        /// This method is used to start a new game.
        /// </summary>
        private void menu_newGame_Click(object sender, EventArgs e)
        {
            StartGame();
        }

        /// <summary>
        /// This method starts the game by setting the text of each button to its corresponding number, making them visible, and then randomly swapping the buttons 10 times. Finally, the current button is set to 1. 
        /// </summary>
        private void StartGame()
        {
            for (int i = 1; i <= buttons; i++)
            {
                button(i).Text = i.ToString();
                button(i).Visible = true;
            }

            for (int i = 1; i <= buttons * 10; i++)
                SwapButtons();

            current = 1;
        }

        /// <summary>
        /// This method swaps the text of two buttons randomly. 
        /// </summary>
        private void SwapButtons()
        {
            int a = rnd.Next(1, buttons);
            int b;
            do
            {
                b = rnd.Next(1, buttons);
            } while (a == b);

            string text = button(a).Text;
            button(a).Text = button(b).Text;
            button(b).Text = text;
        }

        /// <summary>
        /// Returns a button based on the given number.
        /// </summary>
        /// <param name="nr">The number of the button to return.</param>
        /// <returns>
        /// The button corresponding to the given number, or null if the number is not valid.
        /// </returns>
        private Button button(int nr)
        {
            {
                switch (nr)
                {
                    case 1: return button1;
                    case 2: return button2;
                    case 3: return button3;
                    case 4: return button4;
                    case 5: return button5;
                    case 6: return button6;
                    case 7: return button7;
                    case 8: return button8;
                    case 9: return button9;
                    default:
                        return null;
                }
            }
        }

        /// <summary>
        /// Closes the application.
        /// </summary>
        private void menu_exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Displays a message box with information about the program when the About menu item is clicked. 
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event arguments.</param>
        private void menu_about_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Number game. \nPress the buttons with numbers from 1 to 9.", "About Program");
        }

        /// <summary>
        /// Handles the click event of the button9 control. Checks if the clicked button is the next number in the sequence and if it is, hides the button and increments the current number. If the current number is greater than 9, the user has won the game.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void button9_Click(object sender, EventArgs e)
        {
            string nr = ((Button)sender).Text;

            if (nr == current.ToString())
            {
                ((Button)sender).Visible = false;
                current++;

                if (current > 9)
                    MessageBox.Show("You WIN!", "Congratulation!");
            }
        }
    }
}
