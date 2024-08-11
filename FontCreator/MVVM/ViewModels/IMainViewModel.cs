using System.Drawing;
using System.Windows.Media;

namespace FontCreator.MVVM.ViewModels
{
    internal interface IMainViewModel
    {
        RelayCommand OnClick { get; }

        List<Brush> BackGroundColors { get; }
    }
}
