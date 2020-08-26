using Prism.Commands;
using Prism.Mvvm;
using SPRAK.Domain.Entity;
using SPRAK.Domain.Repositories;
using SPRAK.Infrastructure;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Odbc;
using System.Linq;
using System.Windows;

namespace SPRAK_App.ViewModels
{
    public class PartsListViewModel : BindableBase
    {

        private ISqkDataRepository _sqkDataRepository;
        private IPartsListRipository _partsListRipository;

        public PartsListViewModel():this(Factories.CreateSqkData(),
                                                        Factories.CreatePartsList())
        {

        }
        public PartsListViewModel(ISqkDataRepository sqkDataRepository,
                                               IPartsListRipository partsListRipository)
        {
            _sqkDataRepository = sqkDataRepository;
            _partsListRipository = partsListRipository;
            SearchButton = new DelegateCommand(SearchButtonExecute);
            SaveButton = new DelegateCommand(SaveButtonExecute);
            DeleteButton= new DelegateCommand(DeleteButtonExecute);
        }

        public DelegateCommand SearchButton { get; }
        public DelegateCommand SaveButton { get; }
        public DelegateCommand DeleteButton { get; }

        private void Reset()
        {
            PartsList.Clear();
            SelectedPartsList = null;
            SelectedSqk = null;
            SqkIdText = string.Empty;
            PartsNumberText = string.Empty;
            PartsQuantityText = string.Empty;

        }

        private void PartsListUpDate()
        {
            PartsList.Clear();
            foreach (var partslist in _partsListRipository.GetPartsList(Convert.ToInt32(SqkIdText)))
            {
                PartsList.Add(new PartsListEtity(partslist.Id, partslist.SqkId, partslist.PartsNumber,
                                                               partslist.PartsName, partslist.PartsQuantity));
            }
        }

        private void DeleteButtonExecute()
        {
            //MessageBox.Show(Convert.ToString(SelectedPartsList.Id));
            _partsListRipository.Delete(SelectedPartsList);
            PartsListUpDate();
        }

        private void SaveButtonExecute()
        {
            var savePartsList = new PartsListEtity(0,
                                                                    SelectedSqk.SqkId,
                                                                    PartsNumberText,
                                                                    PartsNameText,
                                                                    Convert.ToInt32(PartsQuantityText));
            _partsListRipository.Save(savePartsList);
            PartsListUpDate();
            SqkIdText = string.Empty;
            PartsNumberText = string.Empty;
            PartsQuantityText = string.Empty;
        }

        private void SearchButtonExecute()
        {
            SelectedSqk = _sqkDataRepository.GetSqkData(Convert.ToInt32(SqkIdText));
            PartsListUpDate();
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

        private SqkEntity _selectedSqk;
        public SqkEntity SelectedSqk
        {
            get { return _selectedSqk; }
            set
            {
                SetProperty(ref _selectedSqk, value);
            }
        }

        private string _sqkIdText;
        public string SqkIdText
        {
            get { return _sqkIdText; }
            set
            {
                SetProperty(ref _sqkIdText, value);
            }
        }

        private string _partsNumberText;
        public string PartsNumberText
        {
            get { return _partsNumberText; }
            set
            {
                SetProperty(ref _partsNumberText, value);
            }
        }

        private string _partsNameText;
        public string PartsNameText
        {
            get { return _partsNameText; }
            set
            {
                SetProperty(ref _partsNameText, value);
            }
        }

        private string _partsQuantityText;
        public string PartsQuantityText
        {
            get { return _partsQuantityText; }
            set
            {
                SetProperty(ref _partsQuantityText, value);
            }
        }

    }
}
