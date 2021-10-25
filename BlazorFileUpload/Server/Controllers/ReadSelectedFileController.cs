
using BlazorFileUpload.Server.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BlazorFileUpload.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReadSelectedFileController : ControllerBase
    {
        private readonly IReadSelectedFileRepository excelRepository;

        public ReadSelectedFileController(IReadSelectedFileRepository excelRepository)
        {
            this.excelRepository = excelRepository;
        }

        [HttpGet("{strFile}")]
        public async Task<ActionResult> ReadSelectedFile(string strFile)
        {
            try
            {
                //await excelRepository.ReadSelectedFile(strFile);
                //return Ok($"File = {strFile} has been saved");

               
                return Ok(await excelRepository.ReadSelectedFile(strFile));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }


    }
}
