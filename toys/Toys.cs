using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace toys
{
    public class Toys
    {
        private int n;
        private Random random;
        private Type[] nabor;
        private Type pattern;
        private string[] strNabor;

        public Toys()
        {
            n = 10;
            nabor = new Type[n];
            strNabor = new string[n];
            random = new Random();
        }
        public Toys(int n)
        {
            this.n = n;
            nabor = new Type[n];
            strNabor = new string[n];
            random = new Random();
        }
        public Toys(Type[] pp)
        {
            this.n = pp.Length;
            nabor = new Type[n];
            strNabor = new string[n];
            random = new Random();
        }
        public Type Pattern
        {
            set { pattern = value; }
        }
        public void FormNabor()
        {
            int properties = 7;
            int p = 0, q = 0, currentProps = 0;
            string strQ;
            for (int i = 0; i < n; i++)
            {
                currentProps = 0; strQ = "";
                for (int j = 0; j < properties; j++)
                {
                    p = random.Next(2);
                    q = (int)Math.Pow(2, j);
                    if (p == 1)
                    {
                        currentProps += q;
                        strQ += (Type)q + ", ";
                    }
                }
                nabor[i] = (Type)currentProps;
                if (strQ != "") strNabor[i] = strQ.Remove(strQ.Length - 2);
                else strNabor[i] = "";
            }
        }
        public string[] GetStrNabor()
        {
            return strNabor;
        }
        public Type[] GetNabor()
        {
            return nabor;
        }

        public string[] NaborHavePet()
        {
            int k = 0;
            for (int i = 0; i < n; i++)
            {
                if((nabor[i]&pattern)== pattern)
                {
                    k++;
                }
            }
            string[] ret = new string[k];
            k= 0;
            for(int i = 0; i < n; i++)
            {
                if((nabor[i]&pattern)== pattern)
                {
                    ret[k]="Набор["+(i+1)+"]";
                    k++;
                }
            }
            return ret;
        }

        
    }

    
}
