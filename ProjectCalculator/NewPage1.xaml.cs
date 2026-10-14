using System;
using Microsoft.Maui.Controls;

namespace ProjectCalculator
{

    public partial class NewPage1 : ContentPage
    {
        private double firstNumber = 0;
        private string currentOperator = "";
        private bool isOperatorClicked = false;
        public NewPage1()
        {
            InitializeComponent();
        }

        private void Num_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string ButtonText = button.Text;
            if(CalculatorDisplay.Text == "" || isOperatorClicked)
            {
                CalculatorDisplay.Text = ButtonText;
                isOperatorClicked = false;
            }
            else
            {
                CalculatorDisplay.Text += ButtonText;
            }
        }

        private void Delete_Clicked(object sender, EventArgs e)
        {
            //Still need more work not fully understood yet
        }

        private void Clear_All(object sender, EventArgs e)
        {
            CalculatorDisplay.Text = "";
            firstNumber = 0;
            currentOperator = "";
            isOperatorClicked = false;
        }

        private void Operation(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (double.TryParse(CalculatorDisplay.Text, out double number))
            {
                firstNumber = number;
                CalculatorDisplay.Text = null;
            }

            currentOperator = button.Text;
            isOperatorClicked = true;
        }

        private void Calculate(object sender, EventArgs e)
        {
            if(CalculatorDisplay.Text == null)
                CalculatorDisplay.Text = "Error";
            if (!double.TryParse(CalculatorDisplay.Text, out double secondNumber))
                return;

            double result = 0;

            switch (currentOperator)
            {
                case "Root":
                    if (firstNumber < 0)
                    {
                        CalculatorDisplay.Text = "Error";
                        return;
                    }
                    result = Math.Sqrt(firstNumber);
                    break;

                case "X^2":
                    result = Math.Pow(firstNumber, 2);
                    break;

                case "+":
                    result = firstNumber + secondNumber;
                    break;

                case "-":
                    result = firstNumber - secondNumber;
                    break;

                case "*":
                    result = firstNumber * secondNumber;
                    break;

                case "/":
                    if (secondNumber == 0)
                    {
                        CalculatorDisplay.Text = "Error";
                        return;
                    }

                    result = firstNumber / secondNumber;
                    break;

                default:
                    return;
            }

            CalculatorDisplay.Text = result.ToString();
            currentOperator = "";
            isOperatorClicked = true;
        }
    }
}
//porblems: when entering a number and then an operation because the display is the same 