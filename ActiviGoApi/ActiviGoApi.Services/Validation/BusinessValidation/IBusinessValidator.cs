using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiviGoApi.Services.Validation.BusinessValidation
{
    public interface IBusinessValidator<T> where T : class
    {
         Task<IEnumerable<string>> ValidateAsync(T entity, CancellationToken ct = default);
    }
}
