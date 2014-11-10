using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TerritoryServant.Data.Models
{
    internal class HistoryItem
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long PK { get; set; }

        public string PublisherName { get; set; }

        public DateTime DateOut { get; set; }

        public DateTime DateDue { get; set; }

        public DateTime DateTurnedIn { get; set; }

        public long TerritoryPk { get; set; }

        public string Notes { get; set; }
    }
}
