using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFormulaInterpreter
{
    public class Interpreter
    {
        String formula;
        Data values;
        public Interpreter(String formula, Data values)
        {
            this.formula = formula;
            this.values = values;
        }
        public String recursivePreparer()
        {
            identifyVariable();
            this.formula = separator(formula);

            return formula;
        }

        private String[] splitString(int openingPosition, int lockPosition, String formula)
        {
            String beforeFormula = "", contents = "", afterFormula = "";

            formula = new String(formula.ToCharArray());


            for (int i = 0; i < openingPosition; i++)
                beforeFormula += formula[i];

            for (int i = (formula.Length - 1); i > lockPosition; i--)
                afterFormula = formula[i] + afterFormula;

            for (int i = (openingPosition + 1); i < lockPosition; i++)
                contents += formula[i];

            contents = (openingPosition == lockPosition) ? formula[openingPosition].ToString() : contents;

            return new string[] { beforeFormula, contents, afterFormula };

        }

        private void identifyVariable()
        {
            Boolean tranformiValidatior = true;
            int openingPosition, lockPosition;
            String[] splittedString = new String[3];
            String internalFormula;

            while (tranformiValidatior)
            {
                openingPosition = -1;
                lockPosition = -1;
                internalFormula = new String(this.formula.ToCharArray());

                for (int i = 0; i < formula.Length; i++)
                {
                    if (internalFormula[i].ToString() == "{" && openingPosition == -1)
                        openingPosition = i;

                    if (lockPosition == -1 && internalFormula[i].ToString() == "}")
                        lockPosition = i;
                }

                if (openingPosition == -1 || lockPosition == -1) tranformiValidatior = false;
                else
                {
                    splittedString = splitString(openingPosition, lockPosition, this.formula);

                    this.formula = splittedString[0] + values.getAttribute(splittedString[1]) + splittedString[2];
                }
            }
        }

        private String separator(String formula)
        {
            Boolean tranformiValidatior = true;
            int openingPosition, lockPosition, foundParentheses;
            String[] splittedString = new String[3];
            String internalFormula;

            while (tranformiValidatior)
            {
                openingPosition = -1;
                lockPosition = -1;
                foundParentheses = 0;

                internalFormula = new String(formula.ToCharArray());

                for (int i = 0; i < formula.Length; i++)
                {
                    if (internalFormula[i].ToString() == "(" && openingPosition == -1)
                        openingPosition = i;
                    else if (internalFormula[i].ToString() == "(")
                        foundParentheses++;

                    if (lockPosition == -1 && internalFormula[i].ToString() == ")" && foundParentheses == 0)
                        lockPosition = i;
                    else if (internalFormula[i].ToString() == ")") foundParentheses--;
                }

                if (openingPosition == -1 || lockPosition == -1) tranformiValidatior = false;
                else
                {
                    splittedString = splitString(openingPosition, lockPosition, formula);

                    formula = splittedString[0] + separator(splittedString[1]) + splittedString[2];
                }
            }

            return primitiveProcesses(formula);
        }

        private String primitiveProcesses(String formula)
        {
            formula = logicalStructure(formula);

            formula = operators(formula);

            return formula;
        }

        private String logicalStructure(String formula)
        {
            Boolean tranformiValidatior = true;
            int openingPosition, lockPosition;
            Boolean condition;
            String[] splittedString = new String[3];
            String internalFormula = new String(formula.ToCharArray());

            while (tranformiValidatior)
            {
                openingPosition = -1;
                lockPosition = -1;

                for (int i = 0; i < formula.Length; i++)
                {
                    if (internalFormula[i].ToString() == "[" && openingPosition == -1)
                        openingPosition = i;

                    if (openingPosition != -1 && internalFormula[i].ToString() == "]")
                        lockPosition = i;
                }

                if (openingPosition == -1 || lockPosition == -1) tranformiValidatior = false;
                else
                {
                    splittedString = splitString(openingPosition, lockPosition, formula);


                    condition = (splittedString[1].Split('?')[0] == "true") ? true : false;

                    splittedString[1] = condition ? splittedString[1].Split('?')[1].Split(';')[0] : splittedString[1].Split('?')[1].Split(';')[1];

                    formula = splittedString[0] + separator(splittedString[1]) + splittedString[2];
                }
            }
            return formula;
        }

        private String operators(String formula)
        {
            Boolean tranformiValidatior = true;
            int operatorPosition = -1, previousOperatorPosition = -1, rearOperatorPosition = -1;
            String[] splittedString = new String[3];
            Char[] internalFormula;

            while (tranformiValidatior)
            {
                operatorPosition = -1;
                previousOperatorPosition = -1;
                rearOperatorPosition = -1;

                internalFormula = new Char[3];
                internalFormula = formula.ToCharArray();

                for (int i = 0; i < formula.Length; i++)
                {
                    if (internalFormula[i].ToString() == "=")
                        operatorPosition = i;
                    else if (internalFormula[i].ToString() == "!")
                        operatorPosition = i;
                    else if (internalFormula[i].ToString() == ">")
                        operatorPosition = i;
                    else if (internalFormula[i].ToString() == "<")
                        operatorPosition = i;
                    else if (internalFormula[i].ToString() == "*")
                        operatorPosition = i;
                    else if (internalFormula[i].ToString() == "/")
                        operatorPosition = i;
                    else if (internalFormula[i].ToString() == "+")
                        operatorPosition = i;
                    else if (internalFormula[i].ToString() == "_")
                        operatorPosition = i;

                }

                if (operatorPosition == -1) tranformiValidatior = false;
                else
                {
                    splittedString = splitString(operatorPosition, operatorPosition, formula);

                    String stringPartition = "";
                    String openingPosition = new String(splittedString[0].ToCharArray());
                    String lockPosition = new String(splittedString[2].ToCharArray());

                    for (int i = 0; i < splittedString[0].Length; i++)
                    {
                        stringPartition = openingPosition[i].ToString();
                        if (
                            stringPartition == "=" ||
                            stringPartition == "!" ||
                            stringPartition == ">" ||
                            stringPartition == "<" ||
                            stringPartition == "*" ||
                                    stringPartition == "/" ||
                            stringPartition == "+" ||
                            stringPartition == "_"
                            )
                            previousOperatorPosition = i;
                    }

                    for (int i = 0; i < splittedString[2].Length; i++)
                    {
                        stringPartition = lockPosition[i].ToString();
                        if (
                                (
                                    stringPartition == "=" ||
                                    stringPartition == "!" ||
                                    stringPartition == ">" ||
                                    stringPartition == "<" ||
                                    stringPartition == "*" ||
                                    stringPartition == "/" ||
                                    stringPartition == "+" ||
                                    stringPartition == "_"
                                ) && rearOperatorPosition == -1
                            )
                            rearOperatorPosition = i;
                    }

                    if (previousOperatorPosition != -1)
                        splittedString[0] = splitString(previousOperatorPosition, previousOperatorPosition, splittedString[0])[2];

                    if (rearOperatorPosition != -1)
                        splittedString[2] = splitString(rearOperatorPosition, rearOperatorPosition, splittedString[0])[2];

                    Boolean isBoolean = false;
                    int firstValue = 0, secondValue = 0;

                    if (splittedString[0] == "true" || splittedString[0] == "false" || splittedString[2] == "true" || splittedString[2] == "false")
                        isBoolean = true;
                    else
                    {
                        firstValue = Int32.Parse(splittedString[0]);
                        secondValue = Int32.Parse(splittedString[2]);
                    }


                    switch (splittedString[1])
                    {
                        case "=":
                            if (isBoolean)
                            {
                                if ((splittedString[0] == "true" ? true : false) == (splittedString[2] == "false" ? false : true))
                                    splittedString[1] = "true";
                                else splittedString[1] = "false";
                            }
                            else
                            {
                                if (Int32.Parse(splittedString[0]) == Int32.Parse(splittedString[2]))
                                    splittedString[1] = "true";
                                else splittedString[1] = "false";
                            }

                            break;

                        case "!":
                            if (isBoolean)
                            {
                                if ((splittedString[0] == "true" ? true : false) != (splittedString[2] == "false" ? false : true))
                                    splittedString[1] = "true";
                                else splittedString[1] = "false";
                            }
                            else
                            {
                                if (Int32.Parse(splittedString[0]) != Int32.Parse(splittedString[2]))
                                    splittedString[1] = "true";
                                else splittedString[1] = "false";
                            }
                            break;

                        case ">":
                            if (Int32.Parse(splittedString[0]) > Int32.Parse(splittedString[2]))
                                splittedString[1] = "true";
                            else splittedString[1] = "false";
                            break;

                        case "<":
                            if (Int32.Parse(splittedString[0]) < Int32.Parse(splittedString[2]))
                                splittedString[1] = "true";
                            else splittedString[1] = "false";
                            break;

                        case "*":
                            splittedString[1] = (firstValue * secondValue).ToString();
                            break;

                        case "/":

                            try
                            {
                                splittedString[1] = (firstValue / secondValue).ToString();
                            }
                            catch
                            {
                                splittedString[1] = "0";
                            }

                            break;

                        case "+":
                            splittedString[1] = (firstValue + secondValue).ToString();
                            break;

                        case "_":
                            splittedString[1] = (firstValue - secondValue).ToString();
                            break;
                    }

                    splittedString[0] = "";
                    splittedString[2] = "";

                    if (previousOperatorPosition != -1)
                        splittedString[0] = splitString(previousOperatorPosition, previousOperatorPosition, splittedString[0])[0];

                    if (rearOperatorPosition != -1)
                        splittedString[2] = splitString(rearOperatorPosition, rearOperatorPosition, splittedString[0])[0];

                    formula = splittedString[0] + splittedString[1] + splittedString[2];
                }
            }

            return formula;
        }
    }
}
