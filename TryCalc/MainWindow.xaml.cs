using System.Linq.Expressions;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TryCalc;
namespace TryCalc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private float inputIntNumber = 0f;
        private float inputDecimalNumber = 0f;
        private float firstOperand = 0f;
        private float secondOperand = 0f;
        private int numberDecimalPlaces = 1;
        private bool afterDecimalPoint = false;
        private bool firstEqClick = true;
        private bool firstOperation = true;
        private OperationType CurrentOperation;






        #region SERVICE

        private void BaseClearForAllMethods()
        {
            afterDecimalPoint = false;
            inputDecimalNumber = 0;
            inputIntNumber = 0;
            numberDecimalPlaces = 1;
        }

        private void Any_Comand_Click(object sender, RoutedEventArgs e, string commandSymbol, OperationType operationType)
        {
            if (!firstOperation)
            {
                if (firstEqClick)
                {
                    Key_Equal_Click(sender, e);
                }

                text.Text += $" {commandSymbol} ";
                firstEqClick = true;
                CurrentOperation = operationType;

                return;
            }
            text.Text += $" {commandSymbol} ";
            firstOperand = GetOperand();
            firstEqClick = true;
            firstOperation = false;
            CurrentOperation = operationType;
            BaseClearForAllMethods();
        }

        private void beforeOrAfterDecimalPoint(float keyFigure)
        {
            if (!afterDecimalPoint)
            {
                inputIntNumber = inputIntNumber * 10 + keyFigure;
                return;
            }
            inputDecimalNumber += keyFigure / (float)Math.Pow(10, numberDecimalPlaces);
            numberDecimalPlaces++;
        }

        private float GetOperand()
        {
            return inputIntNumber + inputDecimalNumber;
        }
        #endregion
        
        #region KEYS
        #region COMMANDS
        private void Key_Equal_Click(object sender, RoutedEventArgs e)
        {
            float answer = 0f;
            text.Text = "";
            if (firstEqClick)
            {
                secondOperand = GetOperand();
            }

            if (CurrentOperation == OperationType.addition)
            {
                text.Text = (firstOperand + secondOperand).ToString();
                answer = firstOperand + secondOperand;
            }

            if (CurrentOperation == OperationType.subtraction)
            {
                text.Text = (firstOperand - secondOperand).ToString();
                answer = firstOperand - secondOperand;
            }

            if (CurrentOperation == OperationType.multiplication)
            {
                text.Text = (firstOperand * secondOperand).ToString();
                answer = firstOperand * secondOperand;
            }

            if (CurrentOperation == OperationType.division)
            {
                if (secondOperand == 0)
                {
                    KeyCE_Click(sender, e);

                    text.Text = "НА НОЛЬ НЕ ДЕЛЯТ";
                }
                else
                {
                    text.Text = (firstOperand / secondOperand).ToString();
                    answer = firstOperand / secondOperand;
                }
            }
            firstOperand = answer;
            firstEqClick = false;
            BaseClearForAllMethods();
        }

        private void KeyCE_Click(object sender, RoutedEventArgs e)
        {
            text.Text = "";
            firstOperand = 0;
            secondOperand = 0;
            firstEqClick = true;
            firstOperation = true;
            BaseClearForAllMethods();
        }

        private void Key_Plus_Click(object sender, RoutedEventArgs e)
        {
            Any_Comand_Click(sender, e, "+", OperationType.addition);
        }

        private void Key_Minus_Click(object sender, RoutedEventArgs e)
        {
            Any_Comand_Click(sender, e, "-", OperationType.subtraction);
        }

        private void Key_Multy_Click(object sender, RoutedEventArgs e)
        {
            Any_Comand_Click(sender, e, "*", OperationType.multiplication);
        }

        private void Key_Division_Click(object sender, RoutedEventArgs e)
        {
            Any_Comand_Click(sender, e, "/", OperationType.division);
        }

        private void Key_Point_Click(object sender, RoutedEventArgs e)
        {
            text.Text += ".";
            afterDecimalPoint = true;
        }

        #endregion

        private void Key0_Click(object sender, RoutedEventArgs e)
        {
            text.Text += "0";
            inputIntNumber = inputIntNumber * 10;
        }

        private void Key1_Click(object sender, RoutedEventArgs e)
        {
            text.Text += "1";
            beforeOrAfterDecimalPoint(1);
        }

        private void Key2_Click(object sender, RoutedEventArgs e)
        {
            text.Text += "2";
            beforeOrAfterDecimalPoint(2);
        }

        private void Key3_Click(object sender, RoutedEventArgs e)
        {
            text.Text += "3";
            beforeOrAfterDecimalPoint(3);
        }

        private void Key4_Click(object sender, RoutedEventArgs e)
        {
            text.Text += "4";
            beforeOrAfterDecimalPoint(4);
        }

        private void Key5_Click(object sender, RoutedEventArgs e)
        {
            text.Text += "5";
            beforeOrAfterDecimalPoint(5);
        }

        private void Key6_Click(object sender, RoutedEventArgs e)
        {
            text.Text += "6";
            beforeOrAfterDecimalPoint(6);
        }

        private void Key7_Click(object sender, RoutedEventArgs e)
        {
            text.Text += "7";
            beforeOrAfterDecimalPoint(7);
        }

        private void Key8_Click(object sender, RoutedEventArgs e)
        {
            text.Text += "8";
            beforeOrAfterDecimalPoint(8);
        }

        private void Key9_Click(object sender, RoutedEventArgs e)
        {
            text.Text += "9";
            beforeOrAfterDecimalPoint(9);
        }
        #endregion
    }
}