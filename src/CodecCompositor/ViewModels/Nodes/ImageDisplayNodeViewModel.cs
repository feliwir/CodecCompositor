using CodecCompositor.ViewModels.Editors;
using DynamicData;
using NodeNetwork.Views;
using ReactiveUI;
using SixLabors.ImageSharp;
using System.Reactive.Linq;

namespace CodecCompositor.ViewModels.Nodes
{
    public class ImageDisplayNodeViewModel : CodecNodeViewModel
    {
        static ImageDisplayNodeViewModel()
        {
            Splat.Locator.CurrentMutable.Register(() => new NodeView(), typeof(IViewFor<ImageDisplayNodeViewModel>));
        }

        public CodecNodeInputViewModel ImageInput { get; } = new CodecNodeInputViewModel(typeof(IImage));

        private ImageEditorViewModel _editor;

        public ImageDisplayNodeViewModel()
        {
            this.Name = "Display";
            this.Category = NodeCategory.Images;

            _editor = new ImageEditorViewModel();
            ImageInput.Editor = _editor;
            ImageInput.Name = "Image";
            ImageInput.ValueChanged
                .Select(cs => cs.Image)
                .BindTo(_editor, e => e.Image);

            this.Inputs.Add(ImageInput);
        }
    }
}
