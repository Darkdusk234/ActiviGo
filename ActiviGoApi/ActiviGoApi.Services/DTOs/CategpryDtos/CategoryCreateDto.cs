using System.ComponentModel.DataAnnotations;

namespace ActiviGoApi.Services.DTOs.CategpryDtos
{
    public class CategoryCreateDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
