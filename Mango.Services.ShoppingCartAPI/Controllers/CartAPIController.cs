using AutoMapper;
using Mango.Services.ShoppingCartAPI.Data;
using Mango.Services.ShoppingCartAPI.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Mango.Services.ShoppingCartAPI.Controllers
{
    [Route("api/cart")]
    [ApiController]
    public class CartAPIController : ControllerBase
    {
        private ResponseDto _response;
        private IMapper _mapper;
        private readonly AppDbContext _db;
        
        public CartAPIController(AppDbContext db,
            IMapper mapper)
        {
            _db = db;           
            this._response = new ResponseDto();
            _mapper = mapper;            
        }

        [HttpPost("CartUpsert")]
        public async Task<IActionResult> CartUpsert(CartDto cartDto) 
        {
            try
            {
               var cartHeaderFromDb = await _db.CartHeaders.FirstOrDefaultAsync(u=>u.UserId == cartDto.CartHeader.UserId);
                if (cartHeaderFromDb == null)
                {
                }
                else
                {
                    var cartDeatilsFromDb = await _db.CartDetails.FirstOrDefaultAsync(
                        u=>u.ProductId ==cartDto.CartDetails.First().ProductId 
                        && u.CartHeaderId == cartHeaderFromDb.CartHeaderId);
                    if (cartDeatilsFromDb == null)
                    {
                        //create cartdetails
                    }
                    else
                    {
                        //update cartdetails
                    }
                }
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            
        }
    }
}
