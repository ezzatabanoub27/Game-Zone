using GameHUB.Attributes;

namespace GameHUB.ViewModels
{
    public class EditGameFormModel:GameFormModel
    {
        public int Id { get; set; }
        public string? CurrentCover { get; set; }

        [AllowedExtentionsAttrbut(FileSettings.imageextention)]
        [AllowedSize(FileSettings.maxfileinbyte)]
        public IFormFile? Cover { get; set; } = default!;
    }
}
