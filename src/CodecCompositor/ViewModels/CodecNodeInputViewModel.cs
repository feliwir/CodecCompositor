using CodecCompositor.Models;
using NodeNetwork;
using NodeNetwork.Toolkit.ValueNode;
using NodeNetwork.ViewModels;
using NodeNetwork.Views;
using ReactiveUI;
using System;
using System.Linq;

namespace CodecCompositor.ViewModels
{
    public class CodecNodeInputViewModel : ValueNodeInputViewModel<CodecState>
    {
        static CodecNodeInputViewModel()
        {
            Splat.Locator.CurrentMutable.Register(() => new NodeInputView(), typeof(IViewFor<CodecNodeInputViewModel>));
        }

        public CodecNodeInputViewModel(params Type[] acceptedTypes)
        {
            Editor = null;
            ConnectionValidator = con =>
            {
                Type type = ((CodecNodeOutputViewModel)con.Output).ReturnType;
                bool isValidType = acceptedTypes.Contains(type);
                return new ConnectionValidationResult(isValidType,
                    isValidType ? null : new ErrorMessageViewModel($"Incorrect type, got {type.Name} but need one of {string.Join(", ", acceptedTypes.Select(t => t.Name))}"));
            };
        }
    }
}
