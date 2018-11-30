using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using D2RuneHelper3.Services;

namespace D2RuneHelper3.Model
{
    public class Rune
    {
        public event Action<Rune> AmountHasChanged;

        public string Name { get; private set; }
        public int RuneNumber { get; private set; }
        private int _amount;
        public int Amount
        {
            get => _amount;
            set
            {
                _amount = value;
                AmountHasChanged?.Invoke(this);
            }
        }

        public Rune()
        {

        }

        public Rune(int runeNumber, string name)
        {
            RuneNumber = runeNumber;
            Name = name;
        }

        public void SetAmountSilently(int amount)
        {
            _amount = amount;
        }
    }
}
