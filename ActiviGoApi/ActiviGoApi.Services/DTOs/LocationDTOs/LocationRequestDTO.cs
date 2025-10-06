using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiviGoApi.Services.DTOs
{
    public record LocationRequestDTO
    {
        public string Name { get; init; } = string.Empty;
    }
}
