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
    }
}
