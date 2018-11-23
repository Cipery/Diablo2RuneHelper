using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazor.Extensions.Storage;
using D2RuneHelper3.Model;
using Microsoft.AspNetCore.Blazor.Components;

namespace D2RuneHelper3.Services
{
    public class AppState
    {
        public Rune[] Runes;

        public event Action OnAvailableRunesChanged;

        protected LocalStorage LocalStorage { get; set; }
        protected DataTable DataTable { get; set; }

        public AppState(LocalStorage localStorage, DataTable dataTable)
        {
            LocalStorage = localStorage;
            DataTable = dataTable;

            Runes = DataTable.Runes;

            foreach (var rune in Runes)
            {
                rune.AmountHasChanged += Rune_AmountHasChanged;
            }

            LoadRunes();
        }

        private void Rune_AmountHasChanged(Rune obj)
        {
            SaveRunes();
        }

        public async void SaveRunes()
        {
            var intArray = Runes.Select(r => r.Amount).ToArray();
            await LocalStorage.SetItem("runes", intArray);
        }

        public async void LoadRunes()
        {
            var runes = await LocalStorage.GetItem<int[]>("runes");
            if (runes != null)
            {
                for (var i = 0; i < runes.Length; i++)
                {
                    Runes[i].SetAmountSilently(runes[i]);
                }
            }

            StateChanged();
        }

        private void StateChanged() => OnAvailableRunesChanged?.Invoke();
    }
}
