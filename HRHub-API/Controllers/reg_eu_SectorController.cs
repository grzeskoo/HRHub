using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HRHub_API.Contracts;
using HRHub_API.DTOs;
using HRHub_API.Models;
using HRHub_API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRHub_API.Controllers
{   /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
 
    public class reg_eu_SectorController : ControllerBase
    {
        private readonly Ireg_eu_SectorRepository _reg_eu_SectorRepository ;
        private readonly ILoggerService _logger;
        private readonly IMapper _mapper;


        public reg_eu_SectorController(Ireg_eu_SectorRepository reg_eu_SectorRepository,
                                        ILoggerService logger,
                                        IMapper mapper)
        {
            _reg_eu_SectorRepository = reg_eu_SectorRepository;
            _logger = logger ;
            _mapper = mapper;
        }
        /// <summary>
        /// Get all Sectors
        /// </summary>
        /// <returns>List of Sectors</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetSectors()
      
        {
            //_logger.LogInfo("Acceesed HomeController");
            //return new string[] { "value1", "value2" };
            try
            {
                _logger.LogInfo("Attempted GetSector");
                var sectors = await _reg_eu_SectorRepository.FindAll();
                var response = _mapper.Map<IList<reg_eu_SectorDTO>>(sectors);
                _logger.LogInfo("Successfully got all Sectors");
                return Ok(response);
            }
            catch (Exception e)
            {
                return InternalError($"{e.Message} - {e.InnerException}");
            }

        }
        /// <summary>
        /// Get Sector by id
        /// </summary>
        /// <param name="id">Sector record </param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetSector(int id)

        {
            try
            {
                 _logger.LogInfo($"Attempted GetSector id:{id}");
                var sectors = await _reg_eu_SectorRepository.FindbyId(id);
                if(sectors == null)
                {
                    _logger.LogWarn($"Empty response for {id}");
                    return NotFound();
                }
                var response = _mapper.Map<reg_eu_SectorDTO>(sectors);
                _logger.LogInfo($"Successfully got Sector: {id}");
                return Ok(response);
            }
            catch (Exception e)
            {
              return   InternalError($"{e.Message} - {e.InnerException}");
            }

        }

        /// <summary>
        /// Creates Sector
        /// </summary>
        /// <param name="reg_eu_SectorCreateDTO"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] reg_eu_SectorCreateDTO reg_eu_SectorCreateDTO)
        {
            try
            {
                _logger.LogInfo($"Sector submission attempted");
                if (reg_eu_SectorCreateDTO == null)
                {
                    _logger.LogWarn($"Empty request was submitted");
                    return BadRequest(ModelState);
                }
                if(!ModelState.IsValid)
                {
                    _logger.LogWarn($"Wrong data provided to sector");
                    return BadRequest(ModelState);
                }
                var sector = _mapper.Map<reg_eu_Sector>(reg_eu_SectorCreateDTO);
                var isSuccess = await _reg_eu_SectorRepository.Create(sector);
                if(!isSuccess)
                {
                    _logger.LogWarn($" Creation sector failed");
                    return InternalError($"Creation sector failed");
                }

                _logger.LogInfo($" Creation sector success");
                return Created("Stauts Created", new { sector });
            }
            catch (Exception e)
            {

                return InternalError($"{e.Message} - {e.InnerException}");
            }
        }


        /// <summary>
        /// Update sector
        /// </summary>
        /// <param name="id"></param>
        /// <param name="reg_eu_SectorUpdateDTO"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id,[FromBody] reg_eu_SectorUpdateDTO reg_eu_SectorUpdateDTO)
        {
            try
            {
                if(id <1 || reg_eu_SectorUpdateDTO == null || id != reg_eu_SectorUpdateDTO.reg_eu_SectorId) 
                {
                    _logger.LogWarn($" Creation sector failed");
                    return BadRequest();
                }
                if(!ModelState.IsValid)
                {
                    _logger.LogError($" Bad model state -  failed");
                    return BadRequest();
                }
                var sector = _mapper.Map<reg_eu_Sector>(reg_eu_SectorUpdateDTO);
                var isSuccess = await _reg_eu_SectorRepository.Update(sector);
                if(!isSuccess)
                {
                    _logger.LogWarn($" update sector failed");
                    return InternalError($"Update sector failed");
                }
                return NoContent();
            }
            catch (Exception e)
            {

                return InternalError($"{e.Message} - {e.InnerException}");
            }
        }



        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var location = GetControllerActionNames();

                _logger.LogInfo($"{location}: Delete Attempted on record with id: {id} ");
                if (id < 1)
                {
                    _logger.LogWarn($"Empty request was submitted");
                    return BadRequest();
                }
                var isExists = await _reg_eu_SectorRepository.isExists(id);
                if (!isExists)
                {
                    _logger.LogWarn($"{location}: Failed to retrieve record with id: {id}");
                    return NotFound();
                }
                 var sector = await _reg_eu_SectorRepository.FindbyId(id);
                var isSuccess = await _reg_eu_SectorRepository.Delete(sector);
                if (!isSuccess)
                {
                    _logger.LogWarn($" Deletion of  sector failed");
                    return InternalError($"Deleting of  sector failed");
                }

                _logger.LogInfo($"{location}: Record with id: {id} successfully deleted");
                return NoContent();



            }
            catch (Exception e )
            {

                return InternalError($"{e.Message} - {e.InnerException}");
            }



        }

        private object GetControllerActionNames()
        {
            var controller = ControllerContext.ActionDescriptor.ControllerName;
            var action = ControllerContext.ActionDescriptor.ActionName;

            return $"{controller} - {action}";
        }

        private ObjectResult InternalError(string message)
        {
            _logger.LogError(message);
            return StatusCode(500, "somehting went wrong, please contact with Administrator");
        }
    }
}