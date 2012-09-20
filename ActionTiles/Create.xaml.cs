using System;
using ActionTiles.ViewModels;

namespace ActionTiles
{
    public partial class Create
    {
        public Create()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            string modelType, modelId;
            if (NavigationContext.QueryString.TryGetValue("modelType", out modelType))
            {
                TileType tileType = (TileType)Enum.Parse(typeof(TileType), modelType, false);
                switch (tileType)
                {
                    case TileType.Message:
                        DataContext = new MessageTile();
                        break;
                    case TileType.Dial:
                        DataContext = new DialTile();
                        break;
                    case TileType.Email:
                        break;
                    case TileType.Search:
                        break;
                    case TileType.Browse:
                        break;
                    case TileType.Wifi:
                        break;
                    case TileType.Cellular:
                        break;
                    case TileType.Bluetooth:
                        break;
                    case TileType.Airplane:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            else if (NavigationContext.QueryString.TryGetValue("modelId", out modelId))
            {

            }
        }
    }
}