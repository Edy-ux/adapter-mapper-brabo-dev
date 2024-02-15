using AutoMapper;
using MapperVsAdapter.Application.Adapter;
using MapperVsAdapter.Application.Entities;
using MapperVsAdapter.Application.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace MapperVsAdapter.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserAdapter _adapter;
        private readonly IMapper _mapper;

        public UserController(IMapper mapper)
        {
            _adapter = new UserAdapter();
            _mapper = mapper;
        }


        [HttpPost("batch")]
        public async Task<IActionResult> Add(List<UserModel> model)
        {
            var watchRange = Stopwatch.StartNew();
            var user = _adapter.Map(model);
            watchRange.Stop();

            var timeAdapter = watchRange.ElapsedMilliseconds;
            Console.WriteLine($"\n Adapter: {timeAdapter}");

            var watchRangeMapper = Stopwatch.StartNew();
            var userMapper = _mapper.Map<List<User>>(model);
            watchRangeMapper.Stop();

            var timeMapper = watchRangeMapper.ElapsedMilliseconds;
            Console.WriteLine($"\n Mapper: {timeMapper}");

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Add(UserModel model)
        {
            var watchRange = Stopwatch.StartNew();
            var user = _adapter.Map(model);
            watchRange.Stop();

            var timeAdapter = watchRange.ElapsedMilliseconds;
            Console.WriteLine($"\n Adapter: {timeAdapter}");

            var watchRangeMapper = Stopwatch.StartNew();
            var userMapper = _mapper.Map<User>(model);
            watchRangeMapper.Stop();

            var timeMapper = watchRangeMapper.ElapsedMilliseconds;
            Console.WriteLine($"\n Mapper: {timeMapper}");
            return Ok(user);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var user = new User()
            {
                Name = "Brabo Dev"
            };

            var model = _adapter.Map(user);

            return Ok(model);
        }
    }
}
