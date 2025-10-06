using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiviGoApi.Core.DTOs
{
    public record LocationRequestDTO
    {
        public string Name { get; init; } = string.Empty;
    }
}
