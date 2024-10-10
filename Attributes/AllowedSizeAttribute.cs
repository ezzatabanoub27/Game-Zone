namespace GameHUB.Attributes
{
    public class AllowedSizeAttribute:ValidationAttribute
    {
        private readonly int _AllowedSize;
        public AllowedSizeAttribute(int AllowedSize)
        {
            _AllowedSize = AllowedSize;
        }

        protected override ValidationResult? IsValid(object? value,
             ValidationContext validationContext)
        {
            var file = value as IFormFile;

            if (file is not null)
            {
                if (file.Length>_AllowedSize)
                {

                    return new ValidationResult($"Maximam Allowed Size is {_AllowedSize}");
                }
            }
            return ValidationResult.Success;

        }


    }
}
