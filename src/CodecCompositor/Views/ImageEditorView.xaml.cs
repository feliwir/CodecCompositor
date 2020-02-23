using CodecCompositor.Util;
using CodecCompositor.ViewModels.Editors;
using Microsoft.Win32;
using ReactiveUI;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using System.Windows;
using System.Windows.Controls;
using Image = SixLabors.ImageSharp.Image;

namespace CodecCompositor.Views
{
    /// <summary>
    /// Interaktionslogik für ImageNodeView.xaml
    /// </summary>
    public partial class ImageEditorView : UserControl, IViewFor<ImageEditorViewModel>
    {
        #region ViewModel
        public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register(nameof(ViewModel),
            typeof(ImageEditorViewModel), typeof(ImageEditorView), new PropertyMetadata(null));

        public ImageEditorViewModel ViewModel
        {
            get => (ImageEditorViewModel)GetValue(ViewModelProperty);
            set => SetValue(ViewModelProperty, value);
        }

        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = (ImageEditorViewModel)value;
        }
        #endregion

        public ImageEditorView()
        {
            InitializeComponent();

            this.WhenActivated(d =>
            {
                this.OneWayBind(ViewModel,
                    viewModel => viewModel.Image,
                    view => view.imageContainer.Source,
                    value => new ImageSharpImageSource<Rgba32>((Image<Rgba32>)value));
            });
        }

        private void imageContainer_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == true)
            {
                ViewModel.Image = Image.Load<Rgba32>(ofd.FileName);
            }
        }
    }
}
