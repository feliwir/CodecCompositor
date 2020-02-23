using DynamicData;
using NodeNetwork.Views;
using ReactiveUI;

namespace CodecCompositor.ViewModels.Nodes
{
    public class CodecOutputNodeViewModel : CodecNodeViewModel
    {
        static CodecOutputNodeViewModel()
        {
            Splat.Locator.CurrentMutable.Register(() => new NodeView(), typeof(IViewFor<CodecOutputNodeViewModel>));
        }

        public CodecNodeInputViewModel DataInput { get; } = new CodecNodeInputViewModel(typeof(byte[]));

        public CodecOutputNodeViewModel()
        {
            this.Name = "Codec Output";
            this.Category = NodeCategory.Misc;
            this.CanBeRemovedByUser = false;

            DataInput.Name = "Data";
            this.Inputs.Add(DataInput);
        }
    }
}
