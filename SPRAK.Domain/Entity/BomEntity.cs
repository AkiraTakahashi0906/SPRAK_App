using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SPRAK.Domain.Entity
{
    public sealed class BomEntity : INotifyPropertyChanged
    {
        public BomEntity(int id,
                                  int aircraftNumber,
                                  string assyNo,
                                  string partsNo,
                                  int needQuantity,
                                  int receivedQuantity,
                                  string memo
                                  )
        {
            Id = id;
            AircraftNumber = aircraftNumber;
            AssyNo = assyNo;
            PartsNo = partsNo;
            NeedQuantity = needQuantity;
            ReceivedQuantity = receivedQuantity;
            Memo = memo;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public int Id { get;}
        public int AircraftNumber { get;}
        public string AssyNo { get;}
        public string PartsNo { get;}
        public int NeedQuantity { get;}

        private int _receivedQuantity;
        public int ReceivedQuantity
        {
            get { return _receivedQuantity; }
    set
            {
                if (_receivedQuantity != value)
                {
                    _receivedQuantity = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ReceivedQuantity)));//デリケートの呼び出し
                }
            }
        }

        public bool IsCollected
        {
            get
            {
                if (NeedQuantity == ReceivedQuantity) return true;
                return false;
            }
        }

        public string Memo { get; set; }
    }
}
