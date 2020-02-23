using CodecCompositor.Models;
using CodecCompositor.ViewModels.Editors;
using DynamicData;
using NodeNetwork.Views;
using ReactiveUI;
using SixLabors.ImageSharp;
using System.Reactive.Linq;

namespace CodecCompositor.ViewModels.Nodes
{
    public class ImageInputNodeViewModel : CodecNodeViewModel
    {
        static ImageInputNodeViewModel()
        {
            Splat.Locator.CurrentMutable.Register(() => new NodeView(), typeof(IViewFor<ImageInputNodeViewModel>));
        }

        public CodecNodeOutputViewModel ImageOutput { get; } = new CodecNodeOutputViewModel();

        public ImageInputNodeViewModel()
        {
            this.Name = "Input";
            this.Category = NodeCategory.Images;

            var editor = new ImageEditorViewModel();
            ImageOutput.Name = "Image";
            ImageOutput.Editor = editor;
            ImageOutput.ReturnType = typeof(IImage);
            ImageOutput.Value = editor.WhenAnyValue(e => e.Image)
                .Select(x => new CodecState(x));

            this.Outputs.Add(ImageOutput);
        }
    }
}
