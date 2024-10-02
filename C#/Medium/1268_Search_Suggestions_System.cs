using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_1268
    {
        public Medium_1268()
        {

        }
        public IList<IList<string>> SuggestedProducts(string[] products, string searchWord)
        {
            IList<IList<string>> solution = new List<IList<string>>();

            List<string> prod = products.ToList();
            prod.Sort();

            string prefix = "";
            foreach (var item in searchWord)
            {
                prefix += item;

                prod = prod.Where(kk => kk.Length >= prefix.Length && kk.Substring(0, prefix.Length) == prefix).ToList();
                solution.Add(prod.Take(3).ToList());
            }

            return solution;
        }
    }
}
