using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using TerritoryServant.Common;
using TerritoryServant.Data;

namespace TerritoryServant.Models
{
    public class TerritoryCard : BindableBase
    {
        private string _name;
        private string _serviceGroup;
        private string _notes;
        private TerritoryType _type;
        private TerritoryStatus _status;
        private long _uniqueId;
        private DateTime _dateLastWorked;
        private long _currentAssignment;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long UniqueId
        {
            get { return _uniqueId; }
            private set { SetProperty(ref _uniqueId, value); }
        }

        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        public string ServiceGroup
        {
            get { return _serviceGroup; }
            set { SetProperty(ref _serviceGroup, value); }
        }

        public string Notes
        {
            get { return _notes; }
            set { SetProperty(ref _name, value); }
        }

        public TerritoryType Type
        {
            get { return _type; }
            set { SetProperty(ref _type, value); }
        }

        public TerritoryStatus Status
        {
            get { return _status; }
            set { SetProperty(ref _status, value); }
        }

        public TerritoryCard(long id)
        {
            this.UniqueId = id;
        }

        public DateTime DateLastWorked
        {
            get { return _dateLastWorked; }
            set { SetProperty(ref _dateLastWorked, value); }
        }

        public long CurrentAssignment
        {
            get { return _currentAssignment; }
            set { SetProperty(ref _currentAssignment, value); }
        }
    }
}
