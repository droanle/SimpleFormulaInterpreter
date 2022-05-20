using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFormulaInterpreter
{
    public class Data
    {
        private ArrayList[] attributes;

        private Random randNum = new Random();

        public Data() { attributes = new ArrayList[] { new ArrayList(), new ArrayList() }; }

        public void setAttribute(String attributeName, String value)
        {
            attributes[0].Add(attributeName);
            attributes[1].Add(value);
        }

        public String getAttribute(String attributeName)
        {
            for (int i = 0; i < attributes[0].Count; i++)
            {
                if (((String)attributes[0][i]) == attributeName) return (String)attributes[1][i];
            }

            if (attributeName.ToCharArray()[0].ToString() == ":")
            {
                return randNum.Next(Int32.Parse(attributeName.Split("D")[1])).ToString();
            }

            return "0";
        }

    }
}
