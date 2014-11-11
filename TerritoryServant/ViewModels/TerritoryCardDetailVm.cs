using System;
using System.Collections.Generic;
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


        public async void LoadState(long id)
        {
            SelectedCard = await TerritoryServantDbContext.GetCard(id);
        }
    }
}
