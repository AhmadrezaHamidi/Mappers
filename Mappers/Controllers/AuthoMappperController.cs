//using AutoMapper;
//using Mappers.AuthoDtos;
//using Microsoft.AspNetCore.Mvc;

//namespace Mappers.Controllers
//{
//    [ApiController]
//    [Route("[controller]")]
//    public class AuthoMappperController : ControllerBase
//    {
//        private readonly IMapper _mapper;

//        public AuthoMappperController(IMapper mapper)
//        {
//            _mapper = mapper;
//        }

//        public IActionResult Get()
//        {
//            var sourceModel = new SourceAuthoModel("Ahmad", 20);
//            var destinationDTO = _mapper.Map<SourceAuthoModel, DestinationAuthoDTO>(sourceModel);
//            return Ok(destinationDTO);
//        }
//    }

//}
