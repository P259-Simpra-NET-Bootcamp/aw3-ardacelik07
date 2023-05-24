using DataLayer.IConfiguration;
using Microsoft.AspNetCore.Mvc;
using SimApi.Data.Context;
using SimApi.Data.Domain;
using SimodevApi.Dtos;

namespace SimApi.Service.Controllers;

[Route("simapi/v1/[controller]")]
[ApiController]
public class StaffController : ControllerBase
{
    private IUnitOfWork unitOfWork;
    public StaffController(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }


    [HttpGet("getAll")]
    public ActionResult<List<staff>> GetAll()
    {
        try
        {
            var list = unitOfWork.staffRepository.GetAll();
            return Ok(list);
        }catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
        
    }

    [HttpGet]
    [Route("GetStaffById/{id}")]
    public ActionResult<staff> GetById(int id)
    {
        try
        {
            var staff = unitOfWork.staffRepository.GetById(id);
            return Ok(staff);
        }catch(Exception ex) {
            return BadRequest(ex.Message);

}
      
    }

    [HttpPost("CreateStaff")]
    public ActionResult<staff> Post([FromBody] StaffRequestDto requestDto)
    {
        try
        {
            var newstaff = new staff()
            {
                FirstName = requestDto.FirstName,
                LastName = requestDto.LastName,
                AddressLine1 = requestDto.AddressLine1,
                DateOfBirth = requestDto.DateOfBirth,
                City = requestDto.City,
                Country = requestDto.Country,
                Email = requestDto.Email,
                Phone = requestDto.Phone,
                Province = requestDto.Province,

            };

            unitOfWork.staffRepository.Insert(newstaff);

            unitOfWork.Complete();

            return newstaff;
        }
        catch (Exception ex)
        {

            return BadRequest(ex.Message);
        }
       
    }

    [HttpPut("UpdateStaff")]
    public ActionResult Put([FromQuery] int id, [FromBody] UserUpdateDto updateDto)
    {
        try
        {
            var staff = unitOfWork.staffRepository.GetById(id);


            staff.FirstName = updateDto.FirstName;
            staff.LastName = updateDto.LastName;
            staff.AddressLine1 = updateDto.AddressLine1;
            staff.DateOfBirth = updateDto.DateOfBirth;
            staff.City = updateDto.City;
            staff.Country = updateDto.Country;
            staff.Email = updateDto.Email;
            staff.Phone = updateDto.Phone;
            staff.Province = updateDto.Province;


            unitOfWork.staffRepository.Update(staff);
            unitOfWork.Complete();
            return Ok();
        }catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
       
    }

                 
    [HttpDelete("DeleteStaffById/{id}")]
    public void Delete(int id)
    {
        var staffdelete = unitOfWork.staffRepository.GetById(id);

        unitOfWork.staffRepository.Delete(staffdelete);
        unitOfWork.Complete();
    }
    [HttpGet("getwithFilter")]
    public IQueryable<staff> GetWithFilter([FromQuery] filterParams filter)
    {
   
        var query = unitOfWork.staffRepository.GetWithFilter(p => p.FirstName == filter.FirstName ||  p.City == filter.City);
    
        return query;
    }

}
