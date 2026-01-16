using System.ComponentModel.DataAnnotations;

namespace ServiceMesh.Web.Utility
{
    public class AllowedExtentionAttribute : ValidationAttribute
    {
        private readonly string[] _extentions;

        public AllowedExtentionAttribute(string[] extentions)
        {
            _extentions = extentions;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var file = value as IFormFile;
            if (file != null)
            {
                var extention = Path.GetExtension(file.FileName);
                if (! _extentions.Contains(extention.ToLower()))
                {
                    return new ValidationResult("This Photo extension is not allowed!");
                }
            }
            return ValidationResult.Success;
        }
    }
}
