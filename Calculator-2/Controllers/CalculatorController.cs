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

        public ActionResult Calculate()
        {

            return View();
        }

        public string GetResult(string calcValues)
        {
            //TO Store input  Symbole like {+,-,*,/} in the list
            #region To store entered input operator in the list
            List<char> symbolList = new List<char>();

            for (int i = 0; i < calcValues.Length; i++)
            {
                if (calcValues[i] == '+' || calcValues[i] == '-' || calcValues[i] == '*' || calcValues[i] == '/' ||calcValues[i]=='%')
                {
                    symbolList.Add(calcValues[i]);
                }
            }
            #endregion
            #region Get only numerical value from the input string
            string[] NumberString = calcValues.Split(new[] { "-", "+", "/", "*" }, StringSplitOptions.RemoveEmptyEntries);
            #endregion

            #region if starting string char is operator like{-,+,*,/}
            if (calcValues[0] == '+' || calcValues[0] == '-' || calcValues[0] == '*' || calcValues[0] == '/')
            {
                double result = Convert.ToDouble(NumberString[0])*(-1) ;

                if (calcValues[0] == '-')
                {
                    
                    for (int i = 1; i < NumberString.Length; i++)
                    {

                        double num = Convert.ToDouble(NumberString[i]);
                        
                        switch (symbolList[i])
                        {
                            case '+':
                                result += num;
                                break;
                            case '-':
                                result -= num;
                                break;
                            case '*':
                                result *= num;
                                break;
                            case '/':
                                result /= num;
                                break;
                            case '%':
                                result %= num;
                                break;
                            default:
                                result = 0.0;
                                break;
                        }
                    }
                   
                }
                else
                {
                    ViewBag.error = "please enter correct operation";
                }
                return result.ToString();
            }
            #endregion
            #region first input char in number
            //--------------------if first char is numerical value----------------
            else
            {
             
                double result = Convert.ToDouble(NumberString[0]);

                for (int i = 1; i < NumberString.Length; i++)
                {
                    double num = Convert.ToDouble(NumberString[i]);
                    int j = i - 1;
                    switch (symbolList[j])
                    {
                        case '+':
                            result += num;
                            break;
                        case '-':
                            result -= num;
                            break;
                        case '*':
                            result *= num;
                            break;
                        case '/':
                            result /= num;
                            break;
                        case '%':
                            result %= num;
                            break;
                        default:
                            result = 0.0;
                            break;
                    }
                }

                return result.ToString();
            }
            #endregion
        }
    }
}