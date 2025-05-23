﻿using Amazon.S3;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhotoSmart.Api.PostModels;
using PhotoSmart.Core.DTOs;
using PhotoSmart.Core.IServices;
using PhotoSmart.Service.Services;

namespace PhotoSmart.Api.Controllers
{
    [ApiController]
    [Route("api/photos")]
    public class PhotoController : ControllerBase
    {
        private readonly IPhotoService _photoService;
        private readonly IMapper _mapper;

        public PhotoController(IPhotoService photoService,IMapper mapper)
        {
            _photoService = photoService;
            _mapper = mapper;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadPhoto([FromBody] PhotoDto photoDto)
        {
            try
            {
                await _photoService.UploadPhoto(photoDto);
                return Ok(new { message = "הקובץ הועלה בהצלחה!", url = photoDto.Url });
            }
            catch (FileNotFoundException ex)
            {
                return NotFound(new { message = ex.Message }); // החזר שגיאת 404 אם הקובץ לא קיים
            }
            catch (AmazonS3Exception ex)
            {
                return StatusCode(500, new { message = "שגיאה בעת העלאת הקובץ ל-S3.", details = ex.Message }); // החזר שגיאה ל-S3
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "שגיאה כללית.", details = ex.Message }); // החזר שגיאה כללית
            }
        }

        [HttpGet("{eventId}")]
        public async Task<IActionResult> GetPhotosByEventId(int eventId)
        {
            var photos = await _photoService.GetPhotosByEventIdAsync(eventId);
            return Ok(photos);
        }

        [HttpGet("photo/{id}")]
        public async Task<IActionResult> GetPhotoById(int id)
        {
            var photo = await _photoService.GetByIdAsync(id);
            if (photo == null)
            {
                return NotFound();
            }
            return Ok(photo);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePhoto(int id)
        {
            await _photoService.DeleteAsync(id);
            return NoContent();
        }
    }

}
