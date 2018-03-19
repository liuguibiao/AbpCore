using System.ComponentModel.DataAnnotations;

namespace AbpCore.Project.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}