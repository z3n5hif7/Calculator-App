using System;
using Xamarin.Forms;

namespace CalculatorApp
{
    public partial class MainPage : ContentPage
    {
        public float n1, n2;
        public bool operationClicked, calculated;
        public string operation;

        public MainPage()
        {
            InitializeComponent();
            n1 = n2 = 0;
            operationClicked = false;
            operation = "none";
        }
        public void Number(object sender, EventArgs e)
        {
            if (Display.Text == "0")
            {
                Display.Text = ((sender as Button).Text == ".") ? "0." : (sender as Button).Text;
            }
            else
            {
                if (Display.Text.Length < 8)//Maximum number of inputs at best to minimize overflow
                {
                    bool decimalExists = false;
                    foreach (char x in Display.Text)
                    {
                        if (x == '.')
                        {
                            decimalExists = true;
                            break;
                        }
                    }
                    if (decimalExists && (sender as Button).Text == ".")
                    {
                    }
                    else
                    {
                        Display.Text += (sender as Button).Text;
                    }
                }
            }

            if (operationClicked)
            {
                n2 = Convert.ToSingle(Display.Text);

            }
            else
            {
                n1 = Convert.ToSingle(Display.Text);
            }
        }

        public void Clear(object sender, EventArgs e)
        {
            Display.Text = "0";
            n1 = n2 = 0;
            operation = "none";
            operationClicked = false;
            calculated = false;
        }

        public void Delete(object sender, EventArgs e)
        {
            if (Display.Text != "0")
            {
                Display.Text = Display.Text.Remove(Display.Text.Length - 1, 1);
                if (string.IsNullOrEmpty(Display.Text))
                {
                    Display.Text = "0";
                    if (operationClicked)
                    {
                        n2 = 0;
                    }
                    else
                    {
                        n1 = 0;
                    }
                }
                else
                {
                    if (operationClicked)
                    {
                        n2 = Convert.ToSingle(Display.Text);

                    }
                    else
                    {
                        n1 = Convert.ToSingle(Display.Text);
                    }
                }
            }
        }

        public void Solve(object sender, EventArgs e)
        {
            if (!calculated)
            {
                if (operation == "+")
                {
                    Display.Text = (n1 + n2).ToString();
                }
                else if (operation == "-")
                {
                    Display.Text = (n1 - n2).ToString();
                }
                else if (operation == "X")
                {
                    Display.Text = (n1 * n2).ToString();
                }
                else if (operation == "/")
                {
                    if (n2 != 0)
                    {
                        Display.Text = (n1 / n2).ToString();
                    }
                }

                if (operation == "/" && n2 == 0)//Dividing by 0 = Math Error
                {
                    _ = DisplayAlert("Math Error", "Cannot divide a number by 0 .", "Ok");
                    n1 = n2 = 0;
                    operation = "none";
                }else if (Display.Text.Contains("E+") || Display.Text.Contains("E-"))//Overflow (Result contained exponents after solving)
                {
                    Display.Text = "0";
                    _ = DisplayAlert("Overflow", "Result was a large number that contained an exponent.", "Ok");
                    n1 = n2 = 0;
                    operation = "none";
                }
                else
                {
                    n1 = Convert.ToSingle(Display.Text);
                }

                operationClicked = false;
                calculated = true;
            }
        }

        public void Operation(object sender, EventArgs e)
        {
            Display.Text = "0";
            operationClicked = true;
            operation = ((Button)sender).Text;
            calculated = false;
        }
    }
}