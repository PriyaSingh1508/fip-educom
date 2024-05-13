
using Azure.Core;
using Edu.BLL.Tutorial;
using Edu.Services.Service;
using Edu.Shared.DTO;
using Edu.Shared.Interfaces;
using Edu.Shared.Interfaces.IServices;
using Edu.Shared.Models;
using Edu.Shared.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using System.Linq;

namespace Edu.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class TechnologyController : ControllerBase
    {
        private readonly TechnologyBLL _technologyBLL;
        public readonly IImageService _imageService;
        private readonly IBlobService _blobService;

        public TechnologyController(TechnologyBLL technologyBLL,IImageService imageService, IBlobService blobService)
        {
            _technologyBLL = technologyBLL;
            _imageService = imageService;
            _blobService=blobService;
        }
       
        [HttpPost("add-tutorial-category")]
        public async Task<IActionResult> AddTutorialCategory([FromBody] TutorialCategoryDTO tutorialCategoryDTO)
        {
            try
            {
                var res = await _technologyBLL.AddTutorialCategory(tutorialCategoryDTO);
                return Ok(new { message = res });
            }catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }


        [HttpPut("update-tutorial-category")]
        public async Task<IActionResult> UpdateTutorialCategory([FromBody] GetTutorialCategoriesDTO tutorialCategoryDTO)
        {
            try
            {
                var res = await _technologyBLL.UpdateTutorialCategory(tutorialCategoryDTO);
                return Ok(new { message = res });
            }
            catch (Exception ex) { return StatusCode(500, $"Internal Server Error: {ex.Message}"); }
        }

        [HttpDelete("delete-tutorial-category/{CategoryId:int}")]
        public async Task<IActionResult> DeleteTutorialCategory([FromRoute] int CategoryId)
        {
            try
            {
                var res = await _technologyBLL.DeleteTutorialCategory(CategoryId);
                return Ok(new { message = res });
            }
            catch(Exception ex) { return StatusCode(500, $"Internal Server Error: {ex.Message}"); }
        }

        [HttpPost("add-tutorial")]
        public async Task<IActionResult> AddTutorial(TutorialItemDTO tutorialItemDTO)
        {
            try
            {
                var res = await _technologyBLL.AddTutorial(tutorialItemDTO);
                return Ok(new { message = res });
            }
            catch(Exception ex) { return StatusCode(500, $"Internal Server Error: {ex.Message}"); }
        }
        [HttpGet("get-tutorial/{id:int}")]
        public async Task<IActionResult> GetTutorial(int id)
        {
            try
            {
                var res = await _technologyBLL.GetTutorial(id);
                if (res == null)
                {
                    return BadRequest("not found");
                }
                else
                {
                    return Ok(res);
                }
            }
            catch(Exception ex) { return StatusCode(500, $"Internal Server Error: {ex.Message}"); }
        }

        [HttpDelete("delete-tutorial/{tutorialId:int}")]
        public async Task<IActionResult> DeleteTutorial(int tutorialId)
        {
            try
            {
                var res = await _technologyBLL.DeleteTutorial(tutorialId);
                return Ok(new { message = res });
            }
            catch(Exception ex) { return StatusCode(500, $"Internal Server Error: {ex.Message}"); }
        }

        [HttpPut("update-tutorial")]
        public async Task<IActionResult> UpdateTutorial([FromBody] TutorialItemDTO tutorialDto)
        {
            try
            {
                var res = await _technologyBLL.UpdateTutorial(tutorialDto);
                return Ok(new { message = res });
            }catch(Exception ex) { return StatusCode(500, $"Internal Server Error: {ex.Message}"); }
            
        }
        [HttpGet("get-category-by-id/{id:int}")]
        public  IActionResult  GetCategoryById(int id)
        {
            try
            {
                var res = _technologyBLL.GetCategoryById(id);
                return Ok(res);
            }
            catch(Exception ex) { return StatusCode(500, $"Internal Server Error: {ex.Message}"); }
        }
        [HttpGet("get-all-technologies")]
        public async Task<IActionResult> GetAllTechnologiesAsync()
        {
            var requestModel = new RequestModel();
            try
            {
                if (Request.GetHeaderValue("id") != string.Empty)
                {
                    requestModel.Id = int.Parse(Request.GetHeaderValue("id"));
                }
                
                requestModel.ItemsPerPage = int.Parse(Request.GetHeaderValue("itemsPerPage"));
                requestModel.PageNo = int.Parse(Request.GetHeaderValue("pageNo"));
               
                var res = await _technologyBLL.GetAllTechnologiesAsync(requestModel);
                return Ok(res);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        [HttpGet("get-all-categories")]
        public async Task<IActionResult> GetAllCategories()
        {

            var requestModel = new RequestModel();
            try
            {
                if (Request.GetHeaderValue("id") != string.Empty)
                {
                    requestModel.Id = int.Parse(Request.GetHeaderValue("id"));
                }
                requestModel.ItemsPerPage = int.Parse(Request.GetHeaderValue("itemsPerPage"));
                requestModel.PageNo = int.Parse(Request.GetHeaderValue("pageNo"));
                
                //var headerService=new HeaderService();
                //headerService.AddToDictionary(Request.Headers);
                //var request = headerService.GetRequestModel();




                //var id =Request.Headers.TryGetValue("id",out StringValues Id);
                //var ans = Id.FirstOrDefault();
                //var pageNo = Request.Headers.TryGetValue("pageNo",out StringValues PageNo);
                //var ans2 = PageNo.FirstOrDefault();
                //var itemsPerPage = Request.Headers.TryGetValue("itemsPerPage",out StringValues ItemsPerPage);
                //var ans3 = ItemsPerPage.FirstOrDefault();
                //request.ItemsPerPage = int.Parse(ans3);
                //request.PageNo=int.Parse(ans2);
                //request.Id=int.Parse(ans);



                //var request = requestModel;
                //var request=JsonConvert.DeserializeObject<RequestModel>(Params);

                var res = await _technologyBLL.GetAllCategories(requestModel);
                return Ok(res);
            }
            catch(Exception ex) { return StatusCode(500, $"Internal Server Error: {ex.Message}"); }
        }
        [HttpGet("get-tutorial-categories/{id}")]
        public IActionResult GetTutorialCategoriesAsync(int id)
        {
            try
            {
                var res = _technologyBLL.GetTutorialCategoriesAsync(id);
                return Ok(res);
            }
            catch(Exception ex) { return StatusCode(500, $"Internal Server Error: {ex.Message}"); }
        }

        [HttpGet("get-technologies")]
        public IActionResult GetTechnologiesAsync()
        {
            try
            {
                var res =  _technologyBLL.GetTechnologiesAsync();
                if (res == null) return NotFound("No Technologies found");
                return Ok(res);
            }
            catch(Exception ex) { return StatusCode(500, $"Internal Server Error: {ex.Message}"); }
        }
        [HttpGet("get-publishedtechnologies")]
        public  IActionResult GetTechnologiesPublishedAsync()
        {
            try
            {
                var res =  _technologyBLL.GetTechnologiesPublishedAsync();
                if (res == null) return NotFound("No Technologies found");
                return Ok(res);
            }
            catch(Exception ex) { return StatusCode(500, $"Internal Server Error: {ex.Message}"); }
        }

        [HttpGet("get-technologies-details/{id:int}")]
        public async Task<IActionResult> GetTechnologyDetailsAsync([FromRoute] int id)
        {
            try
            {
                var res = await _technologyBLL.GetTechnologyDetailsAsync(id);
                if (res == null)
                {
                    return NotFound("No technology found!!");
                }
                return Ok(res);
            }catch(Exception ex) { return StatusCode(500, $"Internal Server Error: {ex.Message}"); }
        }
        [HttpGet("getalltutorials")]
        public async Task<IActionResult> GetAllTutorialItemsAsync()
        { var requestModel = new RequestModel();
            try
            {
                if (Request.GetHeaderValue("id") != string.Empty)
                {
                    requestModel.Id = int.Parse(Request.GetHeaderValue("id"));
                }
                requestModel.ItemsPerPage = int.Parse(Request.GetHeaderValue("itemsPerPage"));
                requestModel.PageNo = int.Parse(Request.GetHeaderValue("pageNo"));

                var res =await  _technologyBLL.GetAllTutorialItemsAsync(requestModel);
                if (res == null)
                {
                    return NotFound("No tutorials found!!");
                }
                return Ok(res);
            }catch(Exception ex) { return StatusCode(500, $"Internal Server Error: {ex.Message}"); }

        }
        [HttpPost("add-technology")]
        public async Task<IActionResult> AddTechnology([FromForm] TechImage techImage)
        {
            try
            {

                var imageUrl = await _imageService.Upload(techImage);
                var technologyDTO = new TechnologyDTO { Id = 0, TechnologyName = techImage.Name, ImageUrl = imageUrl };



                var res = await _technologyBLL.AddTechnology(technologyDTO);
                return Ok(new { message = res });
            }catch(Exception ex) { return StatusCode(500, $"Internal Server Error: {ex.Message}"); }
        }

        [HttpDelete("delete-technology/{technologyId:int}")]
        public async Task<IActionResult> DeleteTechnology(int technologyId)
        {
            try
            {
                var res = await _technologyBLL.DeleteTechnology(technologyId);
                return Ok(new { message = res });
            }
            catch(Exception ex) { return StatusCode(500, $"Internal Server Error: {ex.Message}"); }
        }
        [HttpGet("get-technology/{id:int}")]
        public async Task<IActionResult> GetTechnology(int id)
        {
            try
            {
                var res = await _technologyBLL.GetTechnology(id);
                if (res == null)
                {
                    return BadRequest("not found");
                }
                else
                {
                    return Ok(res);
                }
            }
            catch(Exception ex) { return StatusCode(500, $"Internal Server Error: {ex.Message}"); }
        }

        [HttpPut("update-technology")]
        public async Task<IActionResult> UpdateTechnology([FromBody] TechnologyDTO technologyDto)
        {
            try
            {
                var res = await _technologyBLL.UpdateTechnology(technologyDto);
                return Ok(new { message = res });
            }
            catch(Exception ex) { return StatusCode(500, $"Internal Server Error: {ex.Message}"); }
        }

    }
}
