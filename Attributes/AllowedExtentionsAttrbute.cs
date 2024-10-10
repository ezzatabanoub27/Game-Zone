namespace GameHUB.Attributes
{
    public class AllowedExtentionsAttrbut: ValidationAttribute
    {

        private readonly string _AllowedExtentions;
        public AllowedExtentionsAttrbut(string allowedExtentions)
        {
            _AllowedExtentions = allowedExtentions;
        }

        protected override ValidationResult? IsValid(object? value,
            ValidationContext validationContext)
        {
            var file = value as IFormFile; 

            if (file is not  null)
            {
                var Extention = Path.GetExtension(file.FileName);
                var IsAllowed = _AllowedExtentions.Split(',').Contains(Extention,StringComparer.OrdinalIgnoreCase);
                if (!IsAllowed) 
                {

                    return new ValidationResult($"Only {_AllowedExtentions} Are Allowed ");
                }
            }
            return ValidationResult.Success;
           
        }

    }
}
