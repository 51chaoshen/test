using System.ComponentModel.DataAnnotations;

namespace SPAVUE.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}