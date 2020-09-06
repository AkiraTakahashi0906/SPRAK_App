using Prism.Commands;
using Prism.Mvvm;
using SPRAK.Domain.Entity;
using SPRAK.Domain.Repositories;
using SPRAK.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SPRAK_App.ViewModels
{
    public class ShelfDataEditViewModel : BindableBase
    {
        private IShelfBoxRepository _shelfBoxRepository;

        public ShelfDataEditViewModel():this(Factories.CreateShelfBoxData())
        {

        }
        public ShelfDataEditViewModel(IShelfBoxRepository shelfBoxRepository)
        {
            _shelfBoxRepository = shelfBoxRepository;
            ShelfDatas = _shelfBoxRepository.GetSheflAll();
            BoxUpdateShelfDatas= _shelfBoxRepository.GetSheflAll();
            BoxDatas = _shelfBoxRepository.GetBoxAll();

            AddNewButton = new DelegateCommand(AddNewButtonExecute);
            BoxSelectedButton = new DelegateCommand(BoxSelectedButtonExecute);
            PrintButton = new DelegateCommand(PrintButtonExecute);
            UpdateButton = new DelegateCommand(UpdateButtonExecute);
        }

        public DelegateCommand AddNewButton { get; }
        public DelegateCommand BoxSelectedButton { get; }
        public DelegateCommand PrintButton { get; }
        public DelegateCommand UpdateButton { get; }

        private void UpdateButtonExecute()
        {

        }

        private void PrintButtonExecute()
        {

        }

        private void BoxSelectedButtonExecute()
        {
            UpdateBoxInstallationLocationText = SelectedBoxData.BoxInstallationLocation;
            UpdateBoxAssyNoText = SelectedBoxData.BoxSetAssyNo;
        }

        private void AddNewButtonExecute()
        {
            var id = _shelfBoxRepository.GetLatestBoxId();
            var barcodeText = "C2P-" + id;
            var addBoxData = new BoxDataEntity(id,
                                                                     SelectedShelfData.Shelfd,
                                                                     barcodeText,
                                                                     BoxInstallationLocationText,
                                                                     BoxAssyNoText);
            _shelfBoxRepository.AddNewBox(addBoxData);
        }

        private List<BoxDataEntity> _BoxDatas = new List<BoxDataEntity>();
        public List<BoxDataEntity> BoxDatas
        {
            get { return _BoxDatas; }
            set
            {
                SetProperty(ref _BoxDatas, value);
            }
        }

        private BoxDataEntity _selectedBoxData;
        public BoxDataEntity SelectedBoxData
        {
            get { return _selectedBoxData; }
            set
            {
                SetProperty(ref _selectedBoxData, value);
            }
        }

        private List<ShelfDataEntity> _shelfDatas = new List<ShelfDataEntity>();
        public List<ShelfDataEntity> ShelfDatas
        {
            get { return _shelfDatas; }
            set
            {
                SetProperty(ref _shelfDatas, value);
            }
        }

        private ShelfDataEntity _selectedShelfData;
        public ShelfDataEntity SelectedShelfData
        {
            get { return _selectedShelfData; }
            set
            {
                SetProperty(ref _selectedShelfData, value);
            }
        }

        private string _boxInstallationLocationText;
        public string BoxInstallationLocationText
        {
            get { return _boxInstallationLocationText; }
            set
            {
                SetProperty(ref _boxInstallationLocationText, value);
            }
        }

        private string _boxAssyNoText;
        public string BoxAssyNoText
        {
            get { return _boxAssyNoText; }
            set
            {
                SetProperty(ref _boxAssyNoText, value);
            }
        }

        private string _updateBoxInstallationLocationText;
        public string UpdateBoxInstallationLocationText
        {
            get { return _updateBoxInstallationLocationText; }
            set
            {
                SetProperty(ref _updateBoxInstallationLocationText, value);
            }
        }

        private string _updateBoxAssyNoText;
        public string UpdateBoxAssyNoText
        {
            get { return _updateBoxAssyNoText; }
            set
            {
                SetProperty(ref _updateBoxAssyNoText, value);
            }
        }

        private List<ShelfDataEntity> _boxUpdateShelfDatas = new List<ShelfDataEntity>();
        public List<ShelfDataEntity> BoxUpdateShelfDatas
        {
            get { return _boxUpdateShelfDatas; }
            set
            {
                SetProperty(ref _boxUpdateShelfDatas, value);
            }
        }

        private ShelfDataEntity _boxUpdateSelectedShelfData;
        public ShelfDataEntity BoxUpdateSelectedShelfData
        {
            get { return _boxUpdateSelectedShelfData; }
            set
            {
                SetProperty(ref _boxUpdateSelectedShelfData, value);
            }
        }

    }
}
