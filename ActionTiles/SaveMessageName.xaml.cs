using System;
using System.Linq;
using System.Windows.Navigation;
using ActionTiles.ViewModels;

namespace ActionTiles
{
    public partial class SaveMessageName
    {
        private MessageModel currentMessageModel;
        public SaveMessageName()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            string selectedIndex;
            if (NavigationContext.QueryString.TryGetValue("messageId", out selectedIndex))
            {
                Guid messageId = Guid.Parse(selectedIndex);
                currentMessageModel = App.ViewModel.Items.SingleOrDefault(item => item.Id == messageId);
                messageName.Text = currentMessageModel.Name;
            }
        }

        private void OnCancelClick(object sender, EventArgs e)
        {
            NavigationService.GoBack();
        }

        private void OnCheckClick(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(messageName.Text))
                return;

            if (currentMessageModel == null)
            {
                App.ViewModel.Items.Add(new MessageModel { Name = messageName.Text, Id = Guid.NewGuid() });
            }
            else
            {
                currentMessageModel.Name = messageName.Text;
            }
            NavigationService.GoBack();
        }
    }
}