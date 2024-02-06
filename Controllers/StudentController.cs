using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestWEBAPI.Entities;
using TestWEBAPI.Models;
using TestWEBAPI.Repository;

namespace TestWEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ILogger<StudentController> _logger;
        private readonly IMapper _mapper;
        private readonly IStudentRepository _studentRepository;
        public StudentController(ILogger<StudentController> logger, IStudentRepository studentRepository, IMapper mapper, CollegeDB DbCOntext)
        {
            _logger= logger;
            _mapper= mapper;
            _studentRepository= studentRepository;
        }
        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<IEnumerable<StudentDTO>>> GetStudents()
        {
            _logger.LogInformation("GetStudents method started");
            //var students = _DbCOntext.Students.ToList();
            var students = await _studentRepository.GetAllAsync();
            if (students.Count() > 0)
            {
                var studentData = _mapper.Map<List<StudentDTO>>(students);
                return Ok(studentData);
            }
            return BadRequest();
        }
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(400)]
        [Route("{Id:int}",Name = "GetStudentById")]
        public  async Task<ActionResult<StudentDTO>> GetStudentById(int Id)
        {
            if (Id <= 0)
            {
                _logger.LogWarning("Bad Request");
                return BadRequest();
            }
            //var students =CollegeRepository.students.Where(x => x.Id == Id).FirstOrDefault();
            var student = await _studentRepository.GetByIdAsync(x=>x.Id==Id);
            if (student==null)
            {
                _logger.LogError("Student not found with Given Id");
                return NotFound($"The student with {Id} is not Found");
            }
            else{
                var studentData =  _mapper.Map<StudentDTO>(student);
                return Ok(studentData);
            }
        }
        [HttpPost]
        [Route("CreateStudent")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async  Task<ActionResult<StudentDTO>> CreateStudent([FromBody] StudentDTO model)
        {
            if(model==null) return BadRequest();

            //if(model.AddmissionDate< DateTime.Now)
            //{
            //    // 1. Directly Adding Error TO Model state
            //    // 2. Using Custom Attribute
            //    ModelState.AddModelError("AdmissionDateError", " AdminssionDate Must Be greater than or equals to taoday date");
            //    return BadRequest(ModelState);
            //}
           // int newId = _DbCOntext.Students.LastOrDefault().Id + 1;

            Student student = _mapper.Map<Student>(model);  
             await _studentRepository.CreateAsync(student);
            model.Id = student.Id;

            return CreatedAtRoute("GetStudentById", new {Id=model.Id }, model);
            return Ok(student);

        }
        [HttpGet]
        [Route("{Name:alpha}")]  //string is not 
        public async  Task<ActionResult<Student>> GetStudentByName(string Name )
        {
            if(string.IsNullOrEmpty(Name)) return BadRequest();
           var student =await _studentRepository.GetByNameAsync(x=>x.StudentName==Name);
            if(student==null) return NotFound();
            return Ok(student);
        }
        [HttpDelete("{Id}")]
        public  async Task<ActionResult<Student>> DeleteStudentBydId(int Id)
        {
            if(Id<=0) return BadRequest();
            var stu=  await _studentRepository.GetByIdAsync(x=>x.Id==Id);
            await _studentRepository.DeleteAsync(stu);
            if (stu == null) return NotFound();
            return Ok(true);
        }

        [HttpPut]
        [Route("Update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public  async Task<ActionResult> Update (StudentDTO model)
        {
            if (model.Id >0)
            {
                //var existingdata= _DbCOntext.Students.AsNoTracking().Where(x=>x.Id== model.Id).FirstOrDefault();
                var student = _mapper.Map<Student>(model);  
                var existingdata=  await _studentRepository.UpdateAsync(student);
                if(existingdata==null) return NotFound();
                return Ok(existingdata);
            }
            return BadRequest();
        }


        //microsoft.ASp.NEtcore.JSONPatch
        //microsoft.ASp.NEtcore.mv.NewtonSoftJson
        [HttpPatch]
        [Route("{Id:int}/UpdatePartial")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async  Task<ActionResult> UpdatePartial([FromBody] JsonPatchDocument<StudentDTO> patchDocument,int Id)
        {
            if (patchDocument ==null || Id == 0) return BadRequest();
            

                var existingdata =  await _studentRepository.GetByIdAsync(x=>x.Id==Id);
                if (existingdata == null) return NotFound();

            var StudentDTO = _mapper.Map<StudentDTO>(existingdata);
            patchDocument.ApplyTo(StudentDTO,ModelState);
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            existingdata =  _mapper.Map<Student>(StudentDTO);
             _studentRepository.UpdateAsync(existingdata);

                return Ok(existingdata);
            
            return BadRequest();
        }
        
    }
}
