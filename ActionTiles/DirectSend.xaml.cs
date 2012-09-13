using System;
using System.Linq;
using Microsoft.Phone.Tasks;

namespace ActionTiles
{
    public partial class DirectSend
    {
        public DirectSend()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            string selectedIndex;
            if (NavigationContext.QueryString.TryGetValue("messageId", out selectedIndex))
            {

                Guid itemId = Guid.Parse(selectedIndex);
                if (!App.ViewModel.IsDataLoaded)
                    App.ViewModel.LoadData();

                var currentMessage = App.ViewModel.Items.SingleOrDefault(item => item.Id == itemId);

                issueBlock.Text = "Preparing message " + currentMessage.Name;

                try
                {
                    new SmsComposeTask { Body = currentMessage.Body }.Show();
                    issueBlock.Text = "You can now leave.";
                }
                catch (Exception exc)
                {
                    issueBlock.Text = "Something went wrong: " + exc.Message;
                }

            }
        }
    }
}