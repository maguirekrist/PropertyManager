using System.ComponentModel.DataAnnotations;
using PropertyManager.Models;

namespace PropertyManager.Utility.Validation;

public class FileOrVideoAttribute : ValidationAttribute
{
    private List<string> _validContentTypes = new List<string>
    {
        "video",
        "image"
    };
    
    public string GetErrorMessage() => $"Files must be either images or videos.";

    protected override ValidationResult? IsValid(
        object? value, ValidationContext validationContext)
    {
        var val = (CreatePropertyViewModel)validationContext.ObjectInstance;
        var files = val.FormFiles;
        if (files != null)
        {
            foreach (var formFile in files)
            {
                if (!_validContentTypes.Any(w => formFile.ContentType.Contains(w)))
                {
                    return new ValidationResult(GetErrorMessage());
                }
            }
        }

        return ValidationResult.Success;
    }
}