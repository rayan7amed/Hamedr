using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE2___Lab1
{
    public class StringCalculator
    {
        List<String> Delimiters = new() { ",", "\n" };

        public int Calculate(string arg)
        {
            int sum = 0;

            if (string.IsNullOrEmpty(arg))
                return 0;

            if (arg.StartsWith("//"))
            {
                if (arg[2] != '[')
                    Delimiters.Add(arg[2].ToString());

                for (int i = 2; i < arg.LastIndexOf("]"); ++i)
                    if (arg[i] == '[')
                        Delimiters.Add(arg.Substring(i + 1, arg.IndexOf("]", i + 1) - i - 1));
            }
            String numberString = arg.Substring(arg.LastIndexOf("]") + 1);
            String[] nums = numberString.Split(Delimiters.ToArray(), StringSplitOptions.None);
            foreach (String str in nums)
            {
                short res;
                Int16.TryParse(str, out res);
                if (res < 0)
                    throw new Exception("Negative numbers are not allowed!");
                sum += res <= 1000 ? res : 0;
            }

            return sum;
        }

    }

}
