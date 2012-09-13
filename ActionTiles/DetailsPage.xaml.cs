using System;
using System.Linq;
using System.Windows;
using System.Windows.Navigation;
using ActionTiles.ViewModels;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;

namespace ActionTiles
{
    public partial class DetailsPage
    {
        private MessageModel currentMessage;

        public DetailsPage()
        {
            InitializeComponent();

        }

        // When page is navigated to set data context to selected item in list
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            string selectedIndex;
            if (NavigationContext.QueryString.TryGetValue("messageId", out selectedIndex))
            {
                Guid itemId = Guid.Parse(selectedIndex);
                currentMessage = App.ViewModel.Items.SingleOrDefault(item => item.Id == itemId);
                DataContext = currentMessage;
                messageBody.Text = currentMessage.Body ?? string.Empty;
            }
        }

        private void OnSaveClicked(object sender, EventArgs e)
        {
            currentMessage.Body = messageBody.Text;
            App.ViewModel.SaveData();
            NavigationService.GoBack();
        }

        private void OnRenameClicked(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/SaveMessageName.xaml?messageId=" + currentMessage.Id, UriKind.Relative));
        }


        private void OnDelete(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete " + currentMessage.Name, "Confirmation",
                            MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                App.ViewModel.Items.Remove(currentMessage);
                NavigationService.GoBack();
            }
        }

        private void OnSendMessage(object sender, EventArgs e)
        {
            new SmsComposeTask { Body = currentMessage.Body }.Show();
        }

        private void OnTile(object sender, EventArgs e)
        {
            StandardTileData tile = new StandardTileData
            {
                Title = "Send " + currentMessage.Name,
                BackgroundImage = new Uri("BlueTile.jpg", UriKind.Relative)
            };
            var tileUri = "/DirectSend.xaml?messageId=" + currentMessage.Id + "&uniquenessToken=" + Guid.NewGuid();

            ShellTile.Create(new Uri(tileUri, UriKind.Relative), tile);
        }
    }
}