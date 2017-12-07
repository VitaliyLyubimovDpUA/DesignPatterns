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
        INote SeniorNote { get; set; }
        CurrencyType Currency { get; set; }
        int Value { get; set; }

    }

    class Note: INote
    {
        public INote SeniorNote { get; set; }
        public CurrencyType Currency { get; set; }
        public int Value { get; set; }
        public Note(CurrencyType currency, int value, INote seniorNote)
        {
            Currency = currency;
            Value = value;
            SeniorNote = seniorNote;
        }
    }

    class ATM /* automated teller machine - банкомат */
    {
        /// <summary>
        /// INote - купюра
        /// int - количество купюр
        /// </summary>
        private Dictionary<INote, int> currency = new Dictionary<INote, int>();
        private readonly int maxNote = 500;     //самая большая купюра в банкомате
        private readonly int minNote = 500;     //самая маленькая купюра в банкомате
        private readonly int initionalQuantity = 1000;  //изначальное количество каждой из купюр
        public ATM()
        {

            /* Инициализация купюр в банкомате */
            INote note500 = new Note(CurrencyType.UAH, 500, null);
            INote note200 = new Note(CurrencyType.UAH, 200, note500);
            INote note100 = new Note(CurrencyType.UAH, 100, note200);
            INote note50 = new Note(CurrencyType.UAH, 500, note100);
            INote note20 = new Note(CurrencyType.UAH, 20, note50);
            INote note10 = new Note(CurrencyType.UAH, 10, note20);
            INote note5 = new Note(CurrencyType.UAH, 5, note10);
            
            currency.Add(note500, 0);
            currency.Add(note200, initionalQuantity);
            currency.Add(note100, initionalQuantity);
            currency.Add(note50, initionalQuantity);
            currency.Add(note20, initionalQuantity);
            currency.Add(note10, initionalQuantity);
            currency.Add(note5, initionalQuantity);
        }
        //Выдача наличных
        public int CashWithdrawal(int money)
        {
            //Выбор наибольшей доступной купюры, которая есть в наличии
            var pair = currency.Where(item => item.Key.Value <= money && item.Value > 0).FirstOrDefault();
            int total = money;


            return 0;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ATM atm = new ATM();

            atm.CashWithdrawal(2000);


            Console.Read();
        }
    }
}
