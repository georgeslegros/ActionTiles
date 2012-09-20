using System;
using System.Collections.Generic;
using System.Linq;
using ActionTiles.ViewModels;
using Microsoft.Phone.Controls;
using Phone.Controls;
using ActionTiles.Utils;

namespace ActionTiles
{
    public partial class MainPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            var groupedTiles = from tile in GenerateDummyData()
                               group tile by tile.TileType
                                   into c
                                   orderby c.Key
                                   select new Group<ActionTile>(c.Key.ToString(), c);
            list.ItemsSource = groupedTiles;
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
        }

        private IEnumerable<ActionTile> GenerateDummyData()
        {
            for (int i = 0; i < 10; i++)
            {
                yield return new ActionTile { Name = "Dummy", TileType = TileType.Airplane };
                yield return new ActionTile { Name = "Dummy", TileType = TileType.Bluetooth };
                yield return new ActionTile { Name = "Dummy", TileType = TileType.Cellular };
                yield return new ActionTile { Name = "Dummy", TileType = TileType.Browse };
                yield return new ActionTile { Name = "Dummy", TileType = TileType.Email };
                yield return new ActionTile { Name = "Dummy", TileType = TileType.Wifi };
            }
        }

        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            var dialog = new PickerBoxDialog();
            // Assign data source and title
            dialog.ItemSource = EnumHelper.GetEnumValues<TileType>();
            dialog.Title = "ACTION TYPE";
            dialog.Closed += dialog_Closed;
            dialog.Show();
        }

        void dialog_Closed(object sender, EventArgs e)
        {
            PickerBoxDialog dialog = (PickerBoxDialog) sender;
            var selected = dialog.SelectedItem;
            
            var tileType = (TileType)Enum.Parse(typeof (TileType), selected.ToString(), true);
            NavigationService.Navigate(new Uri("/Create.xaml?modelType=" + selected, UriKind.Relative));
        }
    }

    public class Group<T> : IEnumerable<T>
    {
        public Group(string name, IEnumerable<T> items)
        {
            this.Title = name;
            this.Items = new List<T>(items);
        }

        public override bool Equals(object obj)
        {
            Group<T> that = obj as Group<T>;

            return (that != null) && (this.Title.Equals(that.Title));
        }

        public string Title
        {
            get;
            set;
        }

        public IList<T> Items
        {
            get;
            set;
        }

        #region IEnumerable<T> Members

        public IEnumerator<T> GetEnumerator()
        {
            return this.Items.GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.Items.GetEnumerator();
        }

        #endregion
    }
}