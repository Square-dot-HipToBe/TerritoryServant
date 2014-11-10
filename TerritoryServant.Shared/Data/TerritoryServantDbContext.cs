using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Telerik.Storage.Extensions;
using TerritoryServant.Models;


namespace TerritoryServant.Data
{
    public class TerritoryServantDbContext
    {
        protected static Context TerritoryItemsContext { get { return _territoryItemsContext; } }

        private static readonly Context _historyItemContext = new Context("HistoryDB", DatabaseLocation.Roaming);

        private static Context _territoryItemsContext= new Context("TerritoryDB", DatabaseLocation.Roaming);

        protected static Context HistoryItemContext
        {
            get { return _historyItemContext; }
        }

        public TerritoryServantDbContext()
        {
        }

        ~TerritoryServantDbContext()
        {
            CloseDatabases();
        }

        public async void CloseDatabases()
        {
            await TerritoryItemsContext.SaveChangesAsync();
            TerritoryItemsContext.CloseDatabase();

            await HistoryItemContext.SaveChangesAsync();
            HistoryItemContext.CloseDatabase();
        }

        public static IEnumerable<TerritoryCard> GetToBeWorked()
        {
            return from x in TerritoryItemsContext.GetAll<TerritoryCard>()
                where x.Status == TerritoryStatus.CheckedIn
                orderby x.DateLastWorked
                select x;
        }
    }
}
