using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerritoryServant.Common;
using TerritoryServant.Data;
using TerritoryServant.Models;

namespace TerritoryServant.ViewModels
{
    class TerritoryCardDetailVm : BindableBase
    {
        private TerritoryCard _selectedCard;

        public TerritoryCard SelectedCard
        {
            get { return _selectedCard; }
            set { SetProperty(ref _selectedCard, value); }
        }

        public ObservableCollection<string> AvailableServiceGroups { get; set; }

        public List<TerritoryType> TerritoryTypes
        {
            get
            {
                var x = Enum.GetValues(typeof (TerritoryType)).Cast<TerritoryType>().ToList();
                return x;
            }
        }


        public async void LoadState(long id)
        {
            SelectedCard = await TerritoryServantDbContext.GetCard(id);

            await GetAvailableServiceGroups();

            
            
        }

        private async Task GetAvailableServiceGroups()
        {
            AvailableServiceGroups = new ObservableCollection<string>();
            var groups = await TerritoryServantDbContext.GetServiceGroups();
            foreach (var g in groups)
            {
                AvailableServiceGroups.Add(g);
            }
        }

        public void AddServiceGroup(string serviceGroupName)
        {
            if (AvailableServiceGroups.Contains(serviceGroupName)) return;
            AvailableServiceGroups.Add(serviceGroupName);
            SelectedCard.ServiceGroup = serviceGroupName;
        }
    }
}
