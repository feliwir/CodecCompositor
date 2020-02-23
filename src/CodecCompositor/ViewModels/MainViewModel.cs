using CodecCompositor.ViewModels.Nodes;
using DynamicData;
using NodeNetwork;
using NodeNetwork.Toolkit;
using NodeNetwork.Toolkit.NodeList;
using NodeNetwork.ViewModels;
using ReactiveUI;
using System.Linq;

namespace CodecCompositor.ViewModels
{
    public class MainViewModel : ReactiveObject
    {
        public NodeListViewModel NodeListViewModel { get; } = new NodeListViewModel();
        public NetworkViewModel NetworkViewModel { get; } = new NetworkViewModel();

        public ImageInputNodeViewModel CodecInputNode { get; } = new ImageInputNodeViewModel();
        public CodecOutputNodeViewModel CodecOutputNode { get; } = new CodecOutputNodeViewModel();

        public MainViewModel()
        {
            NodeListViewModel.AddNodeType(() => new ImageInputNodeViewModel());
            NodeListViewModel.AddNodeType(() => new ImageDisplayNodeViewModel());

            NetworkViewModel.Validator = network =>
            {
                bool containsLoops = GraphAlgorithms.FindLoops(network).Any();
                if (containsLoops)
                {
                    return new NetworkValidationResult(false, false, new ErrorMessageViewModel("Network contains loops!"));
                }

                return new NetworkValidationResult(true, true, null);
            };

            NetworkViewModel.Nodes.Add(CodecInputNode);
            NetworkViewModel.Nodes.Add(CodecOutputNode);
        }
    }
}
