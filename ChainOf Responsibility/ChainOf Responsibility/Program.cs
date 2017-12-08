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

    class Note : INote
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


    class TransactionInfo
    {
        public List<int> Notes { get; set; } = new List<int>();
        public int TotalMoney { get; set; }
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            var dist = Notes.Distinct();
            foreach (var item in dist)
            {
                int count = Notes.Where(val => val == item).Count();
                builder.Append($"   {item}-x{count}\n");
            }
            builder.Append($"   Итого: ${TotalMoney}\n");
            return builder.ToString();
        }
    }


    class ATM /* automated teller machine - банкомат */
    {
        private INote maxNote;             //самая большая купюра в банкомате
        private INote minNote;             //самая маленькая купюра в банкомате
        private List<TransactionInfo> transactions = new List<TransactionInfo>();   //список обработанных транзакций

        public ATM()
        {


            /* Инициализация купюр в банкомате */
            INote note5 = new Note(CurrencyType.UAH, 5, null);
            INote note10 = new Note(CurrencyType.UAH, 10, note5);
            INote note20 = new Note(CurrencyType.UAH, 20, note10);
            INote note50 = new Note(CurrencyType.UAH, 50, note20);
            INote note100 = new Note(CurrencyType.UAH, 100, note50);
            INote note200 = new Note(CurrencyType.UAH, 200, note100);
            INote note500 = new Note(CurrencyType.UAH, 500, note200);

            minNote = note5;
            maxNote = note500;
        }
        //Выдача наличных
        public bool CashWithdrawal(int money)
        {
            if (money <= 0) throw new Exception("Не верное количество денег");
            //Выбор наибольшей доступной купюры, которая есть в наличии
            var note = maxNote;
            var total = money;
            TransactionInfo transaction = new TransactionInfo { TotalMoney = money };
            while (note != null)
            {
                if (note.TotalQuantity > 0 && note.Value <= total)
                {
                    total -= note.Value;
                    note.TotalQuantity--;
                    transaction.Notes.Add(note.Value);
                }
                if (note.Value > total || note.TotalQuantity == 0) note = note.JuniorNote;
            }
            if (total > 0) throw new Exception("В банкомате не хватает денег");
            transactions.Add(transaction);
            return true;
        }

        public TransactionInfo GetLastTransaction() => transactions.Last();

        public int MinWithdrawal() => minNote.Value;
    }

    class Program
    {
        static void Main(string[] args)
        {
            ATM atm = new ATM();
            int minWithdrawal = atm.MinWithdrawal();
            Console.WriteLine($"-= Минимальная сумма снятия = {minWithdrawal} =-");
            int money;
            Console.WriteLine("Сколько денег снять?");
            int.TryParse(Console.ReadLine(), out money);

            if (money < minWithdrawal || money % minWithdrawal != 0) throw new Exception("Недопустимая сумма для снятия");

            bool isCashWithdrawal = atm.CashWithdrawal(money);
            if (isCashWithdrawal)
            {
                var transaction = atm.GetLastTransaction();
                Console.WriteLine("Информация о выданных купюрах:");
                Console.WriteLine(transaction);

            }

            Console.Read();
        }
    }
}
