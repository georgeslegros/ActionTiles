using System.Windows;

namespace ActionTiles.MVVM
{
    public abstract class DataTemplateSelector : DependencyObject
    {
        /// <summary>
        /// Selects the template.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="container">The container.</param>
        /// <returns>
        /// The selected <see cref="DataTemplate"/> instance.
        /// </returns>
        public abstract DataTemplate SelectTemplate(object item, DependencyObject container);
    }
}