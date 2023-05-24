using AutoMapper;
using DataLayer.IConfiguration;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimApi.Data.Context;
using SimodevApi.Dtos;

[Route("simapi/v1/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private IUnitOfWork unitOfWork;
    private readonly IMapper mapper;
 
    public CategoryController(IUnitOfWork unitOfWork, IMapper mapper, SimDbContext db)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
       
    }


    [HttpGet("getAll")]
    public ActionResult<List<CategoryResponseDto>> GetAll()
    {
        try
        {
            var list = unitOfWork.Category2Repository.GetAllWithInclude();
            var mapped = mapper.Map<List<Category>, List<CategoryResponseDto>>(list);
            return new List<CategoryResponseDto>(mapped);

        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

    }

    [HttpGet]
    [Route("GetCategoryById/{id}")]
    public ActionResult<CategoryResponseDto> GetById(int id)
    {
        try
        {
            var list = unitOfWork.Category2Repository.GetByIdWithInclude(id);
            var mapped = mapper.Map<Category, CategoryResponseDto>(list);
            
            return mapped;
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);

        }

    }

    [HttpPost("CreateCategory")]
    public ActionResult<CategoryResponseDto> Post([FromBody] CategoryRequestDto requestDto)
    {
        try
        {
            var mapped = mapper.Map<CategoryRequestDto, Category>(requestDto);

            unitOfWork.CategoryRepository.Insert(mapped);

            unitOfWork.Complete();
            var mapped2 = mapper.Map<Category, CategoryResponseDto>(mapped);

            return mapped2;
        }
        catch (Exception ex)
        {

            return BadRequest(ex.Message);
        }

    }

     [HttpPut("UpdateCategoryType")]
      public ActionResult Put([FromQuery] int id, [FromBody] CategoryRequestDto CategoryRequestDto)
      {
          try
          {
            var category = unitOfWork.CategoryRepository.GetById(id);

            var mapped = mapper.Map(CategoryRequestDto, category);




            unitOfWork.CategoryRepository.Update(mapped);
              unitOfWork.Complete();
              return Ok();
          }
          catch (Exception ex)
          {
              return BadRequest(ex.Message);
          }

      }
    [HttpDelete("DeleteCategoryById/{id}")]
    public void Delete(int id)
    {
        var staffdelete = unitOfWork.CategoryRepository.GetById(id);

        unitOfWork.CategoryRepository.Delete(staffdelete);
        unitOfWork.Complete();
    }



}
