using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

namespace A_Day_at_the_Races
{
    public class Guy
    {
        public string Name; // The guy's name
        public Bet MyBet; // An instance of Bet that has his bet
        public int Cash; // How much cash he has

        // The last two fields are the Guy's GUI controls on the form
        public RadioButton MyRadioButton; // My radiobutton
        public Label MyLabel; // My label

        public void UpdateLabels()
        {
            // Set my label to my bet's description, and the label on my
            // radio button to show my cash ("Joe has 43 bucks")

            MyRadioButton.Text = Name + " has " + Cash + " bucks";

            if (MyBet == null)
            {
                MyLabel.Text = Name + " hasn't placed a bet";
            }
            else
            {
                MyLabel.Text = MyBet.GetDescription();
            }
        }

        public void ClearBet()
        {
            // Reset my bet so it's zero
            MyBet = null;
        }

        public bool PlaceBet(int BetAmount, int DogToWin)
        {
            // Place a new bet and store it in my bet field
            // Return true if the guy had enough money to bet
            MyBet = new Bet() { Amount = BetAmount, Dog = DogToWin, Bettor = this };

            if (BetAmount > this.Cash)
            {
                return false;
            }
            else
            {
                this.UpdateLabels();
                return true;
            }
        }

        public void Collect(int Winner)
        {
            // Ask my bet to pay out, clear my bet, and update my labels
            if (this.MyBet != null)
            {
                this.Cash = this.Cash + this.MyBet.PayOut(Winner);
            }
            this.ClearBet();
            this.UpdateLabels();
        }
    }
}
