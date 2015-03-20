using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Telerik.Storage.Extensions;
using TerritoryServant.Models;


namespace TerritoryServant.Data
{
    public class TerritoryServantDbContext
    {
        protected static Context TerritoryItemsContext { get { return _territoryItemsContext; } }

        private static readonly Context _historyItemContext = new Context("HistoryDB");

        private static Context _territoryItemsContext= new Context("TerritoryDB");

        protected static Context HistoryItemContext
        {
            get { return _historyItemContext; }
        }

        public TerritoryServantDbContext()
        {
#if DEBUG
            //var terr = new TerritoryCard() {
            //    CurrentAssignment = -1,
            //    DateLastWorked = DateTime.Now.AddDays(-1),
            //    Name = string.Format("A{0}", DateTime.Now.Second),
            //    Notes = "Here be some notes.",
            //    ServiceGroup = "Marshbank",
            //    Status = TerritoryStatus.CheckedIn,
            //    Type = TerritoryType.Apartments
            //};
            //TerritoryItemsContext.Insert<TerritoryCard>(terr);
            //TerritoryItemsContext.SaveChanges();
#endif
        }

        ~TerritoryServantDbContext()
        {
            CloseDatabases();
        }

        public async static Task CloseDatabases()
        {
            await TerritoryItemsContext.SaveChangesAsync();
            TerritoryItemsContext.CloseDatabase();

            await HistoryItemContext.SaveChangesAsync();
            HistoryItemContext.CloseDatabase();
        }

        public static async Task<List<TerritoryCard>> GetToBeWorked()
        {
            return await TerritoryItemsContext.GetAsync<TerritoryCard>(
                string.Format(
                    "SELECT * from TerritoryCard " +
                    "WHERE Status = {0} " +
                    "ORDER By DateLastWorked DESC;", (int)TerritoryStatus.CheckedIn
                    ));
        }

        public async static Task<TerritoryCard> GetCard(long id)
        {
           var cards = await TerritoryItemsContext.GetAsync<TerritoryCard>(string.Format("Select * from TerritoryCard where UniqueId = {0};", id));

            return cards.First();
        }

        public static async Task SaveAsync()
        {
            await TerritoryItemsContext.SaveChangesAsync();
        }

        public async static Task<IEnumerable<string>> GetServiceGroups()
        {
            var groups = await TerritoryItemsContext.GetAsync<TerritoryCard>("SELECT ServiceGroup from TerritoryCard");
            return groups.GroupBy(g => g.ServiceGroup).Select(g => g.Key);
        }
        public static async Task<List<TerritoryCard>> GetCheckedOut()
        {
            return await TerritoryItemsContext.GetAsync<TerritoryCard>(
                string.Format(
                    "SELECT * from TerritoryCard " +
                    "WHERE Status = {0} " +
                    "ORDER By DateLastWorked DESC;", (int)TerritoryStatus.CheckedOut
                    ));
        }
    }
}
