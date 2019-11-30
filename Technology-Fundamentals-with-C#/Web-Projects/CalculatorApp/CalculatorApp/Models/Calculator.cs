using System;
using System.ComponentModel.DataAnnotations;

namespace CalculatorApp.Models
{
    public class Calculator
    {
        public decimal LeftOperand { get; set; }

        public decimal RightOperand { get; set; }

        public string Operator { get; set; }

        public string Result { get; set;}

        public Calculator()
        {
            Result = string.Empty;
        }

        public void CalculateResult()
        {
            try
            {
                switch (Operator)
                {
                    case "+":
                        Result = (LeftOperand + RightOperand).ToString();
                        break;
                    case "-":
                        Result = (LeftOperand - RightOperand).ToString();
                        break;
                    case "*":
                        Result = (LeftOperand * RightOperand).ToString();
                        break;
                    case "/":
                        Result = (LeftOperand / RightOperand).ToString();
                        break;
                }
            }
            catch (Exception е)
            {
                Result = е.Message;
            }
        }
    }
}
