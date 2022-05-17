using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using oneline.Dtos;
using oneline.Models;
using oneline.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace oneline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KartController : ControllerBase
    {
        private readonly IKartRepository _kartRepository;
        private readonly IBaseRepository _baseRepository;
        private readonly IMapper _mapper;

        public KartController(IKartRepository kartRepository, IBaseRepository baseRepository, IMapper mapper)
        {
            _kartRepository = kartRepository;
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        [HttpPost("Register")]
        public ActionResult Register([FromBody] KartRegDto kart)
        {
            string userid = kart.UserId;
            if (!(_baseRepository.UserExist(userid)))
            {
                return Ok(_baseRepository.BaseResponse(311, "User not exist"));
            }
            if (kart == null)
            {
                return BadRequest();
            }
            Kart nowkart = _mapper.Map<Kart>(kart);
            _kartRepository.Register(nowkart);
            return Ok(_baseRepository.BaseResponse(201, "Success"));
        }

        [HttpGet("{userid}")]
        public ActionResult<IDictionary<string, object>> KartBestLab(string userid)
        {
            if (_kartRepository.KartBestLab(userid).Count() == 0)
            {
                return Ok(_baseRepository.BaseResponse(316, "No labtime data"));
            }
            else
            {
                return Ok(_kartRepository.KartBestLab(userid));
            }
        }
    }
}
