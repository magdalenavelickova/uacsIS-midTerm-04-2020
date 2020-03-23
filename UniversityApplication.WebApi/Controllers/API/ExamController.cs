using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UniversityApplication.Data.DTOs;
using UniversityApplication.Service.Service;

namespace UniversityApplication.WebApi.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : ControllerBase
    {
        private readonly ILogger<ExamController> _logger;
        private readonly IExamService _service;

        public ExamController(ILogger<ExamController> logger, IExamService service)
        {
            _logger = logger;
            _service = service;
        }

        // GET: api/Exam
        [HttpGet]
        [Route("Get")]
        public IEnumerable<ExamDTO> Get()
        {
            return _service.GetExams();
        }

        // GET: api/Exam/5
        [HttpGet("{id}", Name = "Get")]
        public ExamDTO Get(int id)
        {
            return _service.GetExam(id);
        }

        // POST: api/Exam
        [HttpPost]
        public IActionResult Post([FromBody] ExamDTO exam)
        {
            if (ModelState.IsValid)
            {
                var result = _service.SaveExam(exam);
                return Ok(result);
            }

            return BadRequest(ModelState);
        }

        // PUT: api/Exam/5
        [HttpPut("{id}")]
        public ExamDTO Put(int id, [FromBody] ExamDTO exam)
        {
            return _service.PutPoints(id, exam);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deleted = _service.DeleteExam(id);
            if (deleted)
            {
                return Ok("Exam successfully deleted");
            }

            return BadRequest("There isn't any exam with that id");
        }
    }
}
