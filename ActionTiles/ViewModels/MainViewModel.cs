using System;
using System.ComponentModel;
using System.Collections.ObjectModel;
using ActionTiles.Utils;

namespace ActionTiles.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private const string FilePath = "/Models";
        
        private ObservableCollection<MessageModel> items;
        public ObservableCollection<MessageModel> Items
        {
            get { return items; }
            private set
            {
                if (items != null)
                    items.CollectionChanged -= items_CollectionChanged;
                items = value;
                items.CollectionChanged += items_CollectionChanged;
                NotifyPropertyChanged("Items");
            }
        }

        void items_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            SaveData();
        }

        public bool IsDataLoaded
        {
            get;
            private set;
        }

        public void LoadData()
        {
            Items = FileHelper.ReadFromFile<ObservableCollection<MessageModel>>(FilePath) ??
                    new ObservableCollection<MessageModel>();
            IsDataLoaded = true;
        }

        public void SaveData()
        {
            FileHelper.SaveToFile(FilePath, Items);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    public class MasterModel
    {
        
    }

    public abstract class TileModel : ViewModelBase
    {
        
        private TileType tileType;
        public TileType TileType
        {
            get { return tileType; }
            set { Set(ref tileType, value, () => TileType); }
        }

        //public TileType TileType { get; set; }

        public string Name { get; set; }

        public string Path { get; set; }
    }
}