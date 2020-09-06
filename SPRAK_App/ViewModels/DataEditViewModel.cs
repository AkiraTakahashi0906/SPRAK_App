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
        private IBomRepository _bomRepository;

        public DataEditViewModel():this(Factories.CreatePartsList(),
                                                        Factories.CreateBom())
        {
        }

        public DataEditViewModel(IPartsListRipository partsListRipository,
                                               IBomRepository bomRepository)
        {
            _partsListRipository = partsListRipository;
            _bomRepository = bomRepository;

            PartsList.Clear();
            foreach (var partslist in _partsListRipository.GetPartsList(1))
            {
                PartsList.Add(new PartsListEtity(partslist.Id, partslist.SqkId, partslist.PartsNumber,
                                                               partslist.PartsName, partslist.PartsQuantity));
            }

            BomList.Clear();
            foreach(var bomlist in _bomRepository.GetBoms("test"))
            {
                BomList.Add(new BomEntity(bomlist.Id, bomlist.AircraftNumber, bomlist.AssyNo,
                                                           bomlist.PartsNo, bomlist.NeedQuantity, bomlist.ReceivedQuantity,bomlist.Memo));
                OriginalQuantityText += bomlist.ReceivedQuantity;
            }

            UpdateButton = new DelegateCommand(UpdateButtonExecute);

            DivideQuantityText = 10;
            RemainingQuantityText = DivideQuantityText;
        }

        public DelegateCommand UpdateButton { get; }

        private void UpdateButtonExecute()
        {
            RemainingQuantityText = 0;
            var remainingQuantity = 0;
            var updateList = new ObservableCollection<BomEntity>();
            foreach (var bomlist in BomList)
            {
                updateList.Add(new BomEntity(bomlist.Id, bomlist.AircraftNumber, bomlist.AssyNo,
                                                           bomlist.PartsNo, bomlist.NeedQuantity, bomlist.ReceivedQuantity, bomlist.Memo));
                remainingQuantity += bomlist.ReceivedQuantity;
            }
            BomList.Clear();
            BomList = updateList;
            RemainingQuantityText = OriginalQuantityText + DivideQuantityText - remainingQuantity;
        }

        private int _remainingQuantityText;
        public int RemainingQuantityText
        {
            get { return _remainingQuantityText; }
            set
            {
                SetProperty(ref _remainingQuantityText, value);
            }
        }

        private int _originalQuantityText;
        public int OriginalQuantityText
        {
            get { return _originalQuantityText; }
            set
            {
                SetProperty(ref _originalQuantityText, value);
            }
        }

        private int _divideQuantityText;
        public int DivideQuantityText
        {
            get { return _divideQuantityText; }
            set
            {
                SetProperty(ref _divideQuantityText, value);
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

        private ObservableCollection<BomEntity> _bomList = new ObservableCollection<BomEntity>();
        public ObservableCollection<BomEntity> BomList
        {
            get { return _bomList; }
            set
            {
                SetProperty(ref _bomList, value);
            }
        }

    }
}
