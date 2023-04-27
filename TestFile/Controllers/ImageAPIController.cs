using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestFile.Models;
using TestFile.Services.FileService;

namespace TestFile.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageAPIController : ControllerBase
    {
        private readonly ImageDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly IFileService _fileService;

        public ImageAPIController(ImageDbContext context, IWebHostEnvironment hostEnvironment, IFileService fileService)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
            _fileService = fileService;
        }

        // GET: api/ImageAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ImageModel>>> GetImages()
        {
          if (_context.Images == null)
          {
              return NotFound();
          }
            return await _context.Images.ToListAsync();
        }

        // GET: api/ImageAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ImageModel>> GetImageModel(int id)
        {
          if (_context.Images == null)
          {
              return NotFound();
          }
            var imageModel = await _context.Images.FindAsync(id);

            if (imageModel == null)
            {
                return NotFound();
            }

            return imageModel;
        }

        // PUT: api/ImageAPI/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutImageModel(int id, ImageModel imageModel)
        {
            if (id != imageModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(imageModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ImageModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ImageAPI
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ImageModel>> PostImageModel([FromForm][Bind("Id,Title,ImageFile")] ImageModel imageModel)
        {
          if (_context.Images == null)
          {
              return Problem("Entity set 'ImageDbContext.Images'  is null.");
          }

            try
            {
                // Injecting File Service
                _fileService.FileUpload(imageModel);

                _context.Images.Add(imageModel);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetImageModel", new { id = imageModel.Id }, imageModel);
            }
            catch (Exception)
            {

                return BadRequest("You have already updated!");
            }
        }

        // DELETE: api/ImageAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteImageModel(int id)
        {
            if (_context.Images == null)
            {
                return NotFound();
            }
            var imageModel = await _context.Images.FindAsync(id);
            if (imageModel == null)
            {
                return NotFound();
            }

            _context.Images.Remove(imageModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ImageModelExists(int id)
        {
            return (_context.Images?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
