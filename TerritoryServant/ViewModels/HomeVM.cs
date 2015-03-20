using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using TerritoryServant.Common;
using TerritoryServant.Data;
using TerritoryServant.Models;

namespace TerritoryServant.ViewModels
{
    class HomeVm : BindableBase
    {
        private ObservableCollection<TerritoryCollection> _allGroups = new ObservableCollection<TerritoryCollection>();

        public ObservableCollection<TerritoryCollection> AllGroups
        {
            get { return this._allGroups; }
        }

        public HomeVm()
        {
            LoadData().ConfigureAwait(false);
            CheckInOutCommand = new RelayCommand<long>(HandleCheckInOutCommand);
        }

        private async void HandleCheckInOutCommand(long uid)
        {
            var checkedInCard = AllGroups[0].Items.SingleOrDefault(c => c.UniqueId == uid);
            if (checkedInCard != null)
            {
                checkedInCard.Status = TerritoryStatus.CheckedOut;
                AllGroups[1].Items.Add(checkedInCard);
                //TODO: handle history during this process
                AllGroups[0].Items.Remove(checkedInCard);
            }
            else
            {
                var checkedOutCard = AllGroups[1].Items.SingleOrDefault(c => c.UniqueId == uid);
                if (checkedOutCard == null) return;

                checkedOutCard.Status = TerritoryStatus.CheckedIn;
                AllGroups[0].Items.Add(checkedOutCard);
                AllGroups[1].Items.Remove(checkedOutCard);

            }
        }

        private async Task LoadData()
        {
            var toBeWorked = new TerritoryCollection()
            {
                Title = "To Be Worked"
            };
            foreach (var terr in await TerritoryServantDbContext.GetToBeWorked())
            {
                toBeWorked.Items.Add(terr);
            }
            AllGroups.Add(toBeWorked);

            var checkedOut = new TerritoryCollection()
            {
                Title = "Checked Out To Publishers"
            };
            foreach (var card in await TerritoryServantDbContext.GetCheckedOut())
            {
                checkedOut.Items.Add(card);
            }
            AllGroups.Add(checkedOut);
        }

        public RelayCommand<long> CheckInOutCommand { get; private set; }
    }
}
