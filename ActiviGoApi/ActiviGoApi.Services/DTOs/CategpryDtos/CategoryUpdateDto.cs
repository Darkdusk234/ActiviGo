using System.ComponentModel.DataAnnotations;

namespace ActiviGoApi.Services.DTOs.CategpryDtos
{
    public class CategoryUpdateDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
