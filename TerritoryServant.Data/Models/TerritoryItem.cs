using System;
using Telerik.Storage.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TerritoryServant.Data.Models
{
    public class TerritoryItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long PK { get; set; }

        public string Name { get; set; }

        public string ServiceGroup { get; set; }

        public TerritoryType Type { get; set; }

        public string Notes { get; set; }

        public DateTime DateLastWorked { get; set; }

        public TerritoryStatus Status { get; set; }

        public long CurrentAssignment { get; set; }
    }
}
