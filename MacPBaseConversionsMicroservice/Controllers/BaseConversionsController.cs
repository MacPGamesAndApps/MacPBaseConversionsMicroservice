using MacPBaseConversionsMicroservice.Models;
using MacPBaseConversionsMicroservice.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace MacPBaseConversionsMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseConversionsController : ControllerBase
    {
        private readonly IBaseConversionService _baseConversionService;

        public BaseConversionsController(IBaseConversionService baseConversionService)
        {
            _baseConversionService = baseConversionService;
        }

        [HttpPost("convert")]
        public string Convert(ConversionRequestData conversionRequestData)
        {
            return _baseConversionService.ConvertValue(conversionRequestData.ValueFrom, conversionRequestData.ConversionType);
        }

        [HttpGet("gettypes")]
        public IEnumerable<ConversionTypeNamed> GetTypes()
        {
            return _baseConversionService.GetTypes();
        }
    }
}
