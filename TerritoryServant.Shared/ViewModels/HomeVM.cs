using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
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
            var toBeWorked = new TerritoryCollection();
            foreach (var terr in TerritoryServantDbContext.GetToBeWorked())
            {
                toBeWorked.Items.Add(terr);
            }
            AllGroups.Add(toBeWorked);
        }
    }
}
