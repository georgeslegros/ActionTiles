using System.Windows;
using System.Windows.Controls;

namespace ActionTiles.MVVM
{
    public class ViewPresenter : ContentControl
    {
        public ViewPresenter()
        {
            HorizontalContentAlignment = HorizontalAlignment.Stretch;
            IsTabStop = false;
        }

        protected override void OnContentChanged(object oldContent, object newContent)
        {
            base.OnContentChanged(oldContent, newContent);
            UpdateContentTemplate(newContent);
        }

        public static DependencyProperty ContentTemplateSelectorProperty =
            DependencyProperty.Register("ContentTemplateSelector", typeof(DataTemplateSelector), typeof(ViewPresenter), new PropertyMetadata(ContentTemplateSelectorPropertyChanged));

        /// <summary>
        /// Gets or sets the content template selector.
        /// </summary>
        /// <value>The content template selector.</value>
        public DataTemplateSelector ContentTemplateSelector
        {
            get { return (DataTemplateSelector)GetValue(ContentTemplateSelectorProperty); }
            set { SetValue(ContentTemplateSelectorProperty, value); }
        }

        private static void ContentTemplateSelectorPropertyChanged(object sender, DependencyPropertyChangedEventArgs args)
        {
            if (!Equals(args.OldValue, args.NewValue))
            {
                var viewPresenter = (ViewPresenter)sender;
                viewPresenter.UpdateContentTemplate(viewPresenter.Content);
            }
        }

        private void UpdateContentTemplate(object contentItem)
        {
            ContentTemplate = ContentTemplateSelector == null
                                  ? null
                                  : ContentTemplateSelector.SelectTemplate(contentItem, this);
            InvalidateArrange();
        }
    }
}
