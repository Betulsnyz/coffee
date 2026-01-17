using AutoMapper;
using Coffy.BusinessLayer.Abstract;
using Coffy.DataAccessLayer.Concrete;
using Coffy.DtoLayer.FeatureDto;
using Coffy.DtoLayer.ProductDto;
using Coffy.EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoffyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _ProductService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _ProductService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ProductList()
        {
            var values = _ProductService.TGetListAll();
            return Ok(_mapper.Map<List<ResultProductDto>>(values));
        }

        [HttpGet("ProductCount")]
        public IActionResult ProductCount()
        {
            var values = _ProductService.TProductCount();
            return Ok(values);
        }

        [HttpGet("ProductCountByMakarna")]
        public IActionResult ProductCountByMakarna()
        {
            return Ok(_ProductService.TProductCountByCategoryNameMakarna());
        }

        [HttpGet("ProductCountByDrink")]
        public IActionResult ProductCountByDrink()
        {
            return Ok(_ProductService.TProductCountByCategoryNameDrink());
        }

        [HttpGet("ProductPriceAvg")]
        public IActionResult ProductPriceAvg()
        {
            return Ok(_ProductService.TProductPriceAvg());
        }

        [HttpGet("ProductNameByMaxPrice")]
        public IActionResult ProductNameByMaxPrice()
        {
            return Ok(_ProductService.TProductNameByMaxPrice());
        }

        [HttpGet("ProductNameByMinPrice")]
        public IActionResult ProductNameByMinPrice()
        {
            return Ok(_ProductService.TProductNameByMinPrice());
        }

        [HttpGet("ProductAvgPriceByMakarna")]
        public IActionResult ProductAvgPriceByMakarna()
        {
            return Ok(_ProductService.TProductAvgPriceByMakarna());
        }

        [HttpGet("ProductListWithCategory")]  
        public IActionResult ProductListWithCAtegory()
        {
            var context = new CoffyContext();
            var values = context.Products.Select(x => new
            {
                x.ProductID,
                x.ProductName,
                x.Price,
                x.ImageUrl,
                x.Description,
                x.ProductStatus,
                CategoryName = x.Category.CategoryName
            }).ToList();

            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateProduct(CreateProductDto createProductDto)
        {
            var value=_mapper.Map<Product>(createProductDto);
            _ProductService.TAdd(value);
            return Ok("ürün bilgisi başarılı bir şekilde oluşturuldu");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var value = _ProductService.TGetbyID(id);
            _ProductService.TDelete(value);
            return Ok("ürün bilgisi başarılı bir şekilde silindi");
        }
        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductDto updateProductDto)
        {
            var value = _mapper.Map<Product>(updateProductDto);
            _ProductService.TUpdate(value);
            return Ok("ürün bilgisi başarılı bir şekilde güncellendi");
        }
        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var value = _ProductService.TGetbyID(id);
            return Ok(_mapper.Map<GetProductDto>(value));
        }

        [HttpGet("GetLast9Products")]
        public IActionResult GetLast9Products()
        {
            var value = _ProductService.TGetLast9Products();
            return Ok(value);
        }

    }
}
