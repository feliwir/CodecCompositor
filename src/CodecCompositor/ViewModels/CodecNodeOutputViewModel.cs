using CodecCompositor.Models;
using NodeNetwork.Toolkit.ValueNode;
using NodeNetwork.Views;
using ReactiveUI;
using System;

namespace CodecCompositor.ViewModels
{
    public class CodecNodeOutputViewModel : ValueNodeOutputViewModel<CodecState>
    {
        static CodecNodeOutputViewModel()
        {
            Splat.Locator.CurrentMutable.Register(() => new NodeOutputView(), typeof(IViewFor<CodecNodeOutputViewModel>));
        }

        public Type ReturnType { get; set; }
    }
}
