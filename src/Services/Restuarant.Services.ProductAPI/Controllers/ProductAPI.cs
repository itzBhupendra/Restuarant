using Microsoft.AspNetCore.Mvc;
using Restuarant.Services.ProductAPI.Models.Dtos;
using Restuarant.Services.ProductAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restuarant.Services.ProductAPI.Controllers
{
    [Route("api.products")]
    public class ProductAPI : Controller
    {
        private IProductRepository _productRepository;
        protected ResponseDto _responseDto;

        public ProductAPI(IProductRepository productRepository)
        {
            _productRepository = productRepository;
            _responseDto = new ResponseDto();

        }
        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                IEnumerable<ProductDto> productDtos = await _productRepository.GetProducts();
                _responseDto.Result = productDtos;

            }
            catch (Exception ex) {
                _responseDto.isSuccess = false;
                _responseDto.ErrorMessages.Add(ex.ToString());


            }
            return _responseDto;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<object> Get(int id)
        {
            try
            {
                ProductDto productDtos = await _productRepository.GetProductById(id);
                _responseDto.Result = productDtos;

            }
            catch (Exception ex)
            {
                _responseDto.isSuccess = false;
                _responseDto.ErrorMessages.Add(ex.ToString());


            }
            return _responseDto;
        }



        [HttpPost]
        public async Task<object> Post([FromBody]ProductDto productDto )
        {
            try
            {
                ProductDto model = await _productRepository.CreateUpdateProduct(productDto);
                _responseDto.Result = model;

            }
            catch (Exception ex)
            {
                _responseDto.isSuccess = false;
                _responseDto.ErrorMessages.Add(ex.ToString());


            }
            return _responseDto;
        }

        [HttpPut]
        public async Task<object> Put([FromBody] ProductDto productDto)
        {
            try
            {
                ProductDto model = await _productRepository.CreateUpdateProduct(productDto);
                _responseDto.Result = model;

            }
            catch (Exception ex)
            {
                _responseDto.isSuccess = false;
                _responseDto.ErrorMessages.Add(ex.ToString());


            }
            return _responseDto;
        }


        [HttpDelete]
        public async Task<object> Post(int id)
        {
            try
            {
                bool  isSucces= await _productRepository.DeleteProduct(id);
                _responseDto.Result = isSucces;

            }
            catch (Exception ex)
            {
                _responseDto.isSuccess = false;
                _responseDto.ErrorMessages.Add(ex.ToString());


            }
            return _responseDto;
        }

    }
}
