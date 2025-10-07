using ActiviGoApi.Infrastructur.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ActiviGoApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

   
    public class ActivityController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
    }
}
