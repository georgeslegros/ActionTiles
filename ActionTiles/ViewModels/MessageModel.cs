using System;
using System.ComponentModel;

namespace ActionTiles.ViewModels
{
    public class MessageModel : INotifyPropertyChanged
    {
        public Guid Id { get; set; }

        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        public string Body { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class MessageParam
    {
        public string Key { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ParamType ParamType { get; set; }
    }

    public enum ParamType
    {
        Text
    }

    public class ActionTile
    {
        public TileType TileType { get; set; }
        public string Name { get; set; }
    }

    public class MessageTile:ActionTile
    {
        public MessageTile()
        {
            TileType = TileType.Message;
        }
    }

    public class DialTile : ActionTile
    {
        public DialTile()
        {
            TileType = TileType.Dial;
        }
    }

    public class BluetoothTile : ActionTile
    {
        public BluetoothTile()
        {
            TileType = TileType.Bluetooth;
        }
    }

    public enum TileType
    {
        Message,
        Dial,
        Email,
        Search,
        Browse,
        Wifi,
        Cellular,
        Bluetooth,
        Airplane
    }
}