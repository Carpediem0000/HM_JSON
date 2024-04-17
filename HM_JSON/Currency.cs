using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM_JSON
{
    public class Currency
    {
        static int COUNTER = 1;
        public int ID;
        public int r030 { get; set; }
        public string txt { get; set; }
        public float rate { get; set; }
        public string cc { get; set; }
        public string exchangedate { get; set; }

        public Currency()
        {
            ID = COUNTER++;
            r030 = 0;
            txt = string.Empty;
            rate = 0;
            cc = string.Empty;
            exchangedate = string.Empty;
        }
        public Currency(int r030, string txt, float rate, string cc, string exchangedate)
        {
            ID = COUNTER++;
            this.r030 = r030;
            this.txt = txt;
            this.rate = rate;
            this.cc = cc;
            this.exchangedate = exchangedate;
        }

        public static void Show(List<Currency> currencyList)
        {
            int leftMargin = 0;
            int topMargin = 0;

            foreach (var item in currencyList)
            {
                Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop);
                Console.Write($"{item.ID}. UAH -> {item.cc}({item.txt})");
                Console.SetCursorPosition(45, Console.CursorTop);
                Console.WriteLine($"{item.rate.ToString("F2")} UAH = 1 {item.cc}");
                topMargin++;
            }
        }
        public override string ToString()
        {
            return $"{ID}. UAH -> {cc}({txt})   {rate}";
        }
    }
}
