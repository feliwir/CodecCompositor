using SixLabors.ImageSharp;

namespace CodecCompositor.Models
{
    public class CodecState
    {
        public IImage Image { get; set; }

        public CodecState(IImage image)
        {
            this.Image = image;
        }
    }
}
