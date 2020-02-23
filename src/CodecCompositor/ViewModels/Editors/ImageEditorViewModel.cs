using CodecCompositor.Models;
using CodecCompositor.Views;
using NodeNetwork.Toolkit.ValueNode;
using ReactiveUI;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using System.Reactive.Linq;

namespace CodecCompositor.ViewModels.Editors
{
    public class ImageEditorViewModel : ValueEditorViewModel<CodecState>
    {
        static ImageEditorViewModel()
        {
            Splat.Locator.CurrentMutable.Register(() => new ImageEditorView(), typeof(IViewFor<ImageEditorViewModel>));
        }

        #region ImageValue
        private IImage _image;
        public IImage Image
        {
            get => _image;
            set => this.RaiseAndSetIfChanged(ref _image, value);
        }
        #endregion

        public ImageEditorViewModel()
        {
            var img = SixLabors.ImageSharp.Image.Load<Rgba32>("Assets/checkerboard.png");
            this._image = img;

            this.WhenAnyValue(vm => vm.Image)
                .Select(c => new CodecState(c))
                .BindTo(this, vm => vm.Value);
        }
    }
}
