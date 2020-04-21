using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PhotoStorage.Services.Interfaces;

namespace PhotoStorage.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : Controller
    {
        private readonly IImageService _imageService;

        public ImageController(IImageService imageService)
        {
            this._imageService = imageService;
        }

        // GET: api/Image
        [HttpGet]
        public IActionResult GetAll()
        {
            var items = _imageService.GetAll();
            if (items.Any())
            {
                return Ok(items);
            }

            return Ok("No data");
        }

        // GET: api/Image/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult GetImage(int id)
        {
            var items = _imageService.GetItemById(id.ToString());
            if (items != null)
            {
                return Ok(items);
            }

            return Ok("No data");
        }
    }
}
