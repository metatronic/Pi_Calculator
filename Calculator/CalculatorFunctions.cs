using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Calculator
{
    class CalculatorFunctions:INotifyPropertyChanged
    {
        private readonly CalculatorCommand _additionCommand = null;
        public ICommand AdditionCommand => _additionCommand;
        private readonly CalculatorCommand _substractionCommand = null;
        public ICommand SubstractionCommand => _substractionCommand;
        private readonly CalculatorCommand _multiplicationCommand = null;
        public ICommand MultiplyCommand => _multiplicationCommand;
        private readonly CalculatorCommand _divisionCommand = null;
        public ICommand DivisionCommand => _divisionCommand;
        private readonly CalculatorCommand _resultCommand = null;
        public ICommand ResultCommand => _resultCommand;
        private readonly CalculatorCommand _numericCommand = null;
        public ICommand NumericCommand => _numericCommand;
        private readonly CalculatorCommand _clearCommand = null;
        public ICommand ClearCommand => _clearCommand;
        private readonly CalculatorCommand _backSpaceCommand = null;
        public ICommand BackSpaceCommand => _backSpaceCommand;
        private readonly CalculatorCommand _switchOffCommand = null;
        public ICommand SwitchOffCommand => _switchOffCommand;
        public CalculatorFunctions()
        {
            _additionCommand = new CalculatorCommand(Add);
            _substractionCommand = new CalculatorCommand(Subtract);
            _multiplicationCommand = new CalculatorCommand(Multiply);
            _divisionCommand = new CalculatorCommand(Divide);
            _numericCommand = new CalculatorCommand(InputNumber);
            _resultCommand = new CalculatorCommand(CalculateResult);
            _clearCommand = new CalculatorCommand(ClearInput);
            _backSpaceCommand = new CalculatorCommand(BackSpace);
            _switchOffCommand = new CalculatorCommand(SwitchOff);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private string inputString;
        public string InputString
        {
            get { return inputString; }
            set { inputString = value; PropertyChanged(this, new PropertyChangedEventArgs("InputString")); }
        }

        private void Result()
        {
            string operation;
            int indexOperator = 0;
            if (InputString.Contains("+"))
            {
                indexOperator = InputString.IndexOf("+");
            }
            else if (InputString.Contains("-"))
            {
                indexOperator = InputString.IndexOf("-");
            }
            else if (InputString.Contains("*"))
            {
                indexOperator = InputString.IndexOf("*");
            }
            else if (InputString.Contains("/"))
            {
                indexOperator = InputString.IndexOf("/");
            }
            else
            {
                //error    
            }

            operation = InputString.Substring(indexOperator, 1);
            double op1 = Convert.ToDouble(InputString.Substring(0, indexOperator));
            double op2 = Convert.ToDouble(InputString.Substring(indexOperator + 1, InputString.Length - indexOperator - 1));

            if (operation == "+")
            {
                InputString += "=" + (op1 + op2);
            }
            else if (operation == "-")
            {
                InputString += "=" + (op1 - op2);
            }
            else if (operation == "*")
            {
                InputString += "=" + (op1 * op2);
            }
            else
            {
                InputString += "=" + (op1 / op2);
            }
        }

        public void Add(object obj)
        {
            InputString += "+";
        }
        public void Subtract(object obj)
        {
            InputString += "-";
        }
        public void Multiply(object obj)
        {
            InputString += "*";
        }
        public void Divide(object obj)
        {
            InputString += "/";
        }
        public void CalculateResult(object obj)
        {
            try
            {
                Result();
            }
            catch (Exception)
            {
                InputString = "Error!";
            }
        }
        public void InputNumber(object obj)
        {
            string num = obj.ToString();
            InputString += num;
        }
        public void ClearInput(object obj)
        {
            InputString = string.Empty;
        }
        public void BackSpace(object obj)
        {
            if (InputString != string.Empty)
            {
                InputString = InputString.Substring(0, inputString.Length - 1);
            }
        }
        public void SwitchOff(object obj)
        {
            Application.Current.Shutdown();
        }
    }
}
