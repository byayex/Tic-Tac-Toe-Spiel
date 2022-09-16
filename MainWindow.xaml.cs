using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Tic_Tac_Toe_Spiel
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private bool CurrentTurn; // CurrentTurn = True means O | CurrentTurn = False means X
        private int CurrentClickedButton = 0;

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            Button buttonClicked = sender as Button;

            buttonClicked.Content = GetTurn();
            buttonClicked.IsEnabled = false;
            ChangeTurn();
            CheckForState();
        }

        private void ChangeTurn()
        {
            if(CurrentTurn)
            {
                CurrentTurn = false;
                CurrentTurnTXT.Text = "X";
            }
            else
            {
                CurrentTurn = true;
                CurrentTurnTXT.Text = "O";
            }
        }

        private string GetTurn()
        {
            if (CurrentTurn)
            {
                return "O";
            }
            else
            {
                return "X";
            }
        }

        private void EndGame(String winner)
        {
            CurrentClickedButton = 0;
            if (winner != "draw")
            {
                ClearFields();
                MessageBox.Show(winner + " has won!");
                if (winner == "X")
                {
                    int newPoints = int.Parse(PointsX.Text) + 1;
                    PointsX.Text = newPoints.ToString();
                }
                if (winner == "O")
                {
                    int newPoints = int.Parse(PointsO.Text) + 1;
                    PointsO.Text = newPoints.ToString();
                }
            }else
            {
                ClearFields();
                MessageBox.Show("Its a draw!");
            }

        }

        private void ClearFields()
        {
            A0.Content = "•";
            A0.IsEnabled = true;
            A1.Content = "•";
            A1.IsEnabled = true;
            A2.Content = "•";
            A2.IsEnabled = true;
            B0.Content = "•";
            B0.IsEnabled = true;
            B1.Content = "•";
            B1.IsEnabled = true;
            B2.Content = "•";
            B2.IsEnabled = true;
            C0.Content = "•";
            C0.IsEnabled = true;
            C1.Content = "•";
            C1.IsEnabled = true;
            C2.Content = "•";
            C2.IsEnabled = true;
        }

        private void CheckForState()
        {
            // Start of
            // Vertical Check
            CurrentClickedButton += 1;
            if (A0.Content == A1.Content && A0.Content == A2.Content && A0.Content.ToString() != "•")
            {
                EndGame(A0.Content.ToString());
                return;
            }
            if (B0.Content == B1.Content && B0.Content == B2.Content && B0.Content.ToString() != "•")
            {
                EndGame(B0.Content.ToString());
                return;
            }
            if (C0.Content == C1.Content && C0.Content == C2.Content && C0.Content.ToString() != "•")
            {
                EndGame(C0.Content.ToString());
                return;
            }
            // Start of
            // Horizontal Check
            if (A0.Content == B0.Content && A0.Content == C0.Content && A0.Content.ToString() != "•")
            {
                EndGame(A0.Content.ToString());
                return;
            }
            if (A1.Content == B1.Content && A1.Content == C1.Content && A1.Content.ToString() != "•")
            {
                EndGame(A1.Content.ToString());
                return;
            }
            if (A2.Content == B2.Content && A2.Content == C2.Content && A2.Content.ToString() != "•")
            {
                EndGame(A2.Content.ToString());
                return;
            }
            // Start of
            // Diagonal Check
            if (A0.Content == B1.Content && A0.Content == C2.Content && A0.Content.ToString() != "•")
            {
                EndGame(A0.Content.ToString());
                return;
            }
            if (A2.Content == B1.Content && A2.Content == C0.Content && A2.Content.ToString() != "•")
            {
                EndGame(A2.Content.ToString());
                return;
            }
            // Start of
            // Draw Manager
            if(CurrentClickedButton >= 9)
            {
                EndGame("draw");
            }
        }
    }
}
