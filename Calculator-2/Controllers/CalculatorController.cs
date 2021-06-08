using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Calculator_2.Controllers
{
    public class CalculatorController : Controller
    {
        // GET: Calculator
        public double Add(double m, double n)
        {
            double result = m + n;
            return result;
        }
        public double Subtract(double m, double n)
        {
            double result = m - n;
            return result;
        }
        public double Multiply(double m, double n)
        {
            double result = m * n;
            return result;
        }
        public double Divide(double m, double n)
        {
            double result = m / n;
            return result;
        }
        public double Modulo(double m, double n)
        {
            double result = m / n;
            return result;
        }

        public ActionResult Calculate()
        {

            return View();
        }
        [HttpPost]
        public string GetResult(string calcValues)
        {
            try
            {
                //TO Store input  Symbole like {+,-,*,/} in the list
                #region To store entered input operator in the list
                List<char> symbolList = new List<char>();

                for (int i = 0; i < calcValues.Length; i++)
                {
                    if (calcValues[i] == '+' || calcValues[i] == '-' || calcValues[i] == '*' || calcValues[i] == '/' || calcValues[i] == '%')
                    {
                        symbolList.Add(calcValues[i]);
                    }
                }
                #endregion
                double result;
                #region Get only numerical value from the input string
                string[] NumberString = calcValues.Split(new[] { "-", "+", "/", "*" }, StringSplitOptions.RemoveEmptyEntries);
                #endregion

                #region if starting string char is operator like{-,+,*,/}
                if (calcValues[0] == '+' || calcValues[0] == '-' || calcValues[0] == '*' || calcValues[0] == '/' || calcValues[0] == '%')
                {

                    //double result = Convert.ToDouble(NumberString[0]) * (-1);

                    //if (calcValues[0] == '-')
                    string firstSymbols = symbolList[0].ToString();
                    result = Convert.ToDouble(firstSymbols + NumberString[0]);
                    //result = Convert.ToDouble(NumberString[0]) * (-1);
                    for (int i = 1; i < NumberString.Length; i++)
                    {

                        double num = Convert.ToDouble(NumberString[i]);

                        switch (symbolList[i])
                        {
                            case '+':
                                result = Add(result, num);
                                break;
                            case '-':
                                result = Subtract(result, num);
                                break;
                            case '*':
                                result = Multiply(result, num);
                                break;
                            case '/':
                                result = Divide(result, num);
                                break;
                            case '%':
                                result = Modulo(result, num);
                                break;
                            default:
                                result = 0.0;
                                break;
                        }

                    }
                   

                    return result.ToString();
                }
                #endregion
                #region first input char in number
                //--------------------if first char is numerical value----------------
                else
                {
                    result = Convert.ToDouble(NumberString[0]);

                    for (int i = 1; i < NumberString.Length; i++)
                    {
                        double num = Convert.ToDouble(NumberString[i]);
                        int j = i - 1;
                        switch (symbolList[j])
                        {
                            case '+':
                                result = Add(result, num);
                                break;
                            case '-':
                                result = Subtract(result, num);
                                break;
                            case '*':
                                result = Multiply(result, num);
                                break;
                            case '/':
                                result = Divide(result, num);
                                break;
                            case '%':
                                result = Modulo(result, num);
                                break;
                            default:
                                result = 0.0;
                                break;
                        }
                    }
                }

                return result.ToString();
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
            
        }
        
    
    #endregion

}
