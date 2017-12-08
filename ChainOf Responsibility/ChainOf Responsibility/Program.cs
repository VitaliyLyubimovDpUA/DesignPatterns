using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOf_Responsibility
{
    enum CurrencyType
    {
        USD, UAH, EUR, RUB
    }
    interface INote
    {
        INote JuniorNote { get; set; }
        CurrencyType Currency { get; set; }
        int Value { get; set; }
        int TotalQuantity { get; set; }
    }

    class Note: INote
    {
        public INote JuniorNote { get; set; }
        public CurrencyType Currency { get; set; }
        public int Value { get; set; }
        public int TotalQuantity { get; set; }
        public Note(CurrencyType currency, int value, INote seniorNote)
        {
            Currency = currency;
            Value = value;
            JuniorNote = seniorNote;
            TotalQuantity = 1000;
        }
    }

    class ATM /* automated teller machine - банкомат */
    {
        /// <summary>
        /// INote - купюра
        /// int - количество купюр
        /// </summary>
        private INote maxNote;             //самая большая купюра в банкомате
        private INote minNote;             //самая маленькая купюра в банкомате
        public ATM()
        {


            /* Инициализация купюр в банкомате */
            INote note5 = new Note(CurrencyType.UAH, 5, null);
            INote note10 = new Note(CurrencyType.UAH, 10, note5);
            INote note20 = new Note(CurrencyType.UAH, 20, note10);
            INote note50 = new Note(CurrencyType.UAH, 500, note20);
            INote note100 = new Note(CurrencyType.UAH, 100, note50);
            INote note200 = new Note(CurrencyType.UAH, 200, note100);
            INote note500 = new Note(CurrencyType.UAH, 500, note200);

            minNote = note5;
            maxNote = note500;
        }
        //Выдача наличных
        public bool CashWithdrawal(int money)
        {
            //Выбор наибольшей доступной купюры, которая есть в наличии
           


            //while (total != 0 || (pair.Key.Value != minNote && pair.Value != 0))
            //{
            //    if (pair.Key.Value == minNote && pair.Value == 0) break;
            //    if (pair.Value > 0 && total > pair.Key.Value)
            //    {
            //        total -= pair.Key.Value;
            //        currency[pair.Key] = pair.Value - 1;
            //        pair = currency.Where(item => item.Key.Value == pair.Key.Value).First();
            //    }
            //    else {
            //        if (pair.Key.JuniorNote != null)
            //            pair = currency.Where(item => item.Key.Value == pair.Key.JuniorNote.Value).First();
            //        else
            //            return false;
            //    }
            //}


            return true;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ATM atm = new ATM();

            bool isCashWithdrawal = atm.CashWithdrawal(153);

            Console.Read();
        }
    }
}
