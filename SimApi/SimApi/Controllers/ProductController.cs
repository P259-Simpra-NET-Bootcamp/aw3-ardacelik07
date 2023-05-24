using AutoMapper;
using DataLayer.IConfiguration;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;
using SimApi.Data.Context;
using SimApi.Data.Domain;
using SimodevApi.Dtos;
using System.Collections.Generic;

namespace SimApi.Service.Controllers;

[Route("simapi/v1/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private IUnitOfWork unitOfWork;
    private readonly IMapper mapper;
    private readonly SimDbContext db;
    public ProductController(IUnitOfWork unitOfWork, IMapper mapper, SimDbContext db)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
        this.db = db;
    }


    [HttpGet("getAll")]
    public ActionResult<List<ProductResponseDto>> GetAll()
    {
        try
        {
            var list = unitOfWork.ProductRepository.GetAll();
            var mapped = mapper.Map<List<Product>, List<ProductResponseDto>>(list);
            return  new  List<ProductResponseDto>(mapped);
            
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

    }

    [HttpGet]
    [Route("GetProductById/{id}")]
    public ActionResult<ProductResponseDto> GetById(int id)
    {
        try
        {
            var staff = unitOfWork.ProductRepository.GetById(id);
            var mapped = mapper.Map<Product, ProductResponseDto>(staff);
            return mapped;
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);

        }

    }

    [HttpPost("CreateProduct")]
    public ActionResult<ProductResponseDto> Post([FromBody] ProductResponseDto requestDto)
    {
        try
        {
            var mapped = mapper.Map<ProductResponseDto, Product>(requestDto);

            unitOfWork.ProductRepository.Insert(mapped);

            unitOfWork.Complete();
            var mapped2 = mapper.Map<Product, ProductResponseDto>(mapped);

            return mapped2;
        }
        catch (Exception ex)
        {

            return BadRequest(ex.Message);
        }

    }

    [HttpPut("UpdateProduct")]
    public ActionResult Put([FromQuery] int id, [FromBody] ProductResponseDto updateDto)
    {
        try
        {
            var staff = unitOfWork.ProductRepository.GetById(id);

            var mapped = mapper.Map(updateDto,staff);


            unitOfWork.ProductRepository.Update(mapped);
            unitOfWork.Complete();
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

    }
    [HttpDelete("DeleteProductById/{id}")]
    public void Delete(int id)
    {
        var staffdelete = unitOfWork.ProductRepository.GetById(id);

        unitOfWork.ProductRepository.Delete(staffdelete);
        unitOfWork.Complete();
    }



}
