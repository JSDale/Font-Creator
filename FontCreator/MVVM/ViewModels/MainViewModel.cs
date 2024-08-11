using System.Net.Http.Headers;
using System.Windows.Media;

namespace FontCreator.MVVM.ViewModels
{
    internal class MainViewModel : ViewModelBase, IMainViewModel
    {
        public RelayCommand OnClick { get; }

        private List<Brush> _backGroundColors = [];

        public List<Brush> BackGroundColors
        {
            get => _backGroundColors; 
            private set
            {
                _backGroundColors = value;
                OnPropertyChanged(nameof(BackGroundColors));
            }
        }

        private void UpdateColorList(int index, Brush color)
        {
            _backGroundColors[index] = color;
            OnPropertyChanged(nameof(BackGroundColors));
        }

        private readonly Brush _selected = Brushes.Black;

        private readonly Brush _unselected = Brushes.White;

        private List<bool> _isSelected = [];

        public MainViewModel()
        {
            OnClick = new RelayCommand(ButtonClicked);
            for(var i = 0; i < (32*23); i++)
            {
                _backGroundColors.Add(Brushes.White);
                _isSelected.Add(false);
            }
        }

        private void ButtonClicked(object obj)
        {
            var wibble = obj.ToString() ?? "0";
            var number =int.Parse(wibble);
            var index = number - 1;
            if (_isSelected[index])
            {

                UpdateColorList(index, _unselected);
                _isSelected[index] = false;
                return;
            }

            UpdateColorList(index, _selected);
            _isSelected[index] = true;
        }
    }
}
