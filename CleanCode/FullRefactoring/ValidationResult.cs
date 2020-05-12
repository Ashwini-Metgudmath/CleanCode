using System.Collections.Generic;

namespace Project.UserControls
{
    public class ValidationResult
    {
        public bool IsValid { get; set; }
        public IEnumerable<ValidationError> Errors { get; set; }
    }
}