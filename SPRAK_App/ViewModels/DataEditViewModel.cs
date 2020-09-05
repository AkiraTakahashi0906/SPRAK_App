using Prism.Commands;
using Prism.Mvvm;
using SPRAK.Domain.Entity;
using SPRAK.Domain.Repositories;
using SPRAK.Infrastructure;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace SPRAK_App.ViewModels
{
    public class DataEditViewModel : BindableBase
    {
        private IPartsListRipository _partsListRipository;

        public DataEditViewModel():this(Factories.CreatePartsList())
        {
        }

        public DataEditViewModel(IPartsListRipository partsListRipository)
        {
            _partsListRipository = partsListRipository;
            PartsList.Clear();
            foreach (var partslist in _partsListRipository.GetPartsList(1))
            {
                PartsList.Add(new PartsListEtity(partslist.Id, partslist.SqkId, partslist.PartsNumber,
                                                               partslist.PartsName, partslist.PartsQuantity));
            }
        }

        private PartsListEtity _selectedPartsList;
        public PartsListEtity SelectedPartsList
        {
            get { return _selectedPartsList; }
            set
            {
                SetProperty(ref _selectedPartsList, value);
            }
        }

        private ObservableCollection<PartsListEtity> _partsList = new ObservableCollection<PartsListEtity>();
        public ObservableCollection<PartsListEtity> PartsList
        {
            get { return _partsList; }
            set
            {
                SetProperty(ref _partsList, value);
            }
        }
    }
}
