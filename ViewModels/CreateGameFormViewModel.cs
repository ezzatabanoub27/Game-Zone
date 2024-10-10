

using GameHUB.Attributes;
using GameHUB.Settings;

namespace GameHUB.ViewModels
{
    public class CreateGameFormViewModel:GameFormModel
    {


        [AllowedExtentionsAttrbut(FileSettings.imageextention)]
        [AllowedSize(FileSettings.maxfileinbyte)]
        public IFormFile Cover { get; set; } = default!;
    }
}
