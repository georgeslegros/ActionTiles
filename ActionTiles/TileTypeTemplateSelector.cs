using System.Windows;
using ActionTiles.MVVM;
using ActionTiles.ViewModels;

namespace ActionTiles
{
    public class TileTypeTemplateSelector : DataTemplateSelector
    {
        public DataTemplate MessageTemplate
        {
            get { return (DataTemplate)GetValue(MessageTemplateProperty); }
            set { SetValue(MessageTemplateProperty, value); }
        }

        public static readonly DependencyProperty MessageTemplateProperty = DependencyProperty.Register(
            "MessageTemplate", typeof(DataTemplate), typeof(TileTypeTemplateSelector), null);

        public DataTemplate DialTemplate
        {
            get { return (DataTemplate)GetValue(DialTemplateProperty); }
            set { SetValue(DialTemplateProperty, value); }
        }

        public static readonly DependencyProperty DialTemplateProperty = DependencyProperty.Register(
            "DialTemplate", typeof(DataTemplate), typeof(TileTypeTemplateSelector), null);

        public DataTemplate EmailTemplate
        {
            get { return (DataTemplate)GetValue(EmailTemplateProperty); }
            set { SetValue(EmailTemplateProperty, value); }
        }

        public static readonly DependencyProperty EmailTemplateProperty = DependencyProperty.Register(
            "EmailTemplate", typeof(DataTemplate), typeof(TileTypeTemplateSelector), null);

        public DataTemplate SearchTemplate
        {
            get { return (DataTemplate)GetValue(SearchTemplateProperty); }
            set { SetValue(SearchTemplateProperty, value); }
        }

        public static readonly DependencyProperty SearchTemplateProperty = DependencyProperty.Register(
            "SearchTemplate", typeof(DataTemplate), typeof(TileTypeTemplateSelector), null);

        public DataTemplate BrowseTemplate
        {
            get { return (DataTemplate)GetValue(BrowseTemplateProperty); }
            set { SetValue(BrowseTemplateProperty, value); }
        }

        public static readonly DependencyProperty BrowseTemplateProperty = DependencyProperty.Register(
            "BrowseTemplate", typeof(DataTemplate), typeof(TileTypeTemplateSelector), null);

        public DataTemplate WifiTemplate
        {
            get { return (DataTemplate)GetValue(WifiTemplateProperty); }
            set { SetValue(WifiTemplateProperty, value); }
        }

        public static readonly DependencyProperty WifiTemplateProperty = DependencyProperty.Register(
            "WifiTemplate", typeof(DataTemplate), typeof(TileTypeTemplateSelector), null);

        public DataTemplate CellularTemplate
        {
            get { return (DataTemplate)GetValue(CellularTemplateProperty); }
            set { SetValue(CellularTemplateProperty, value); }
        }

        public static readonly DependencyProperty CellularTemplateProperty = DependencyProperty.Register(
            "CellularTemplate", typeof(DataTemplate), typeof(TileTypeTemplateSelector), null);

        public DataTemplate BluetoothTemplate
        {
            get { return (DataTemplate)GetValue(BluetoothTemplateProperty); }
            set { SetValue(BluetoothTemplateProperty, value); }
        }

        public static readonly DependencyProperty BluetoothTemplateProperty = DependencyProperty.Register(
            "BluetoothTemplate", typeof(DataTemplate), typeof(TileTypeTemplateSelector), null);

        public DataTemplate AirplaneTemplate
        {
            get { return (DataTemplate)GetValue(AirplaneTemplateProperty); }
            set { SetValue(AirplaneTemplateProperty, value); }
        }

        public static readonly DependencyProperty AirplaneTemplateProperty = DependencyProperty.Register(
            "AirplaneTemplate", typeof(DataTemplate), typeof(TileTypeTemplateSelector), null);

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is MessageTile)
                return MessageTemplate;
            if (item is DialTile)
                return DialTemplate;
            if (item is BluetoothTile)
                return BluetoothTemplate;
            return null;
        }
    }
}