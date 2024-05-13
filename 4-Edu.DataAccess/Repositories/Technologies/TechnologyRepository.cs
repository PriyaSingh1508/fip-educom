using AutoMapper;
using Edu.DAL.Data;
using Edu.DAL.Entities;
using Edu.DAL.Exceptions;
using Edu.Shared.DTO;
using Edu.Shared.Interfaces.Technology;
using Edu.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Edu.DAL.Repositories.Technologies
{
    public class TechnologyRepository : ITechnologyRepository
    {
        private readonly EduContext _context;
        private readonly IMapper _mapper;

        public TechnologyRepository(EduContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ResponseModel<string>> AddTechnology(TechnologyDTO technologyDTO)
        {
            var response = new ResponseModel<string>();
            try
            {
                var technology = _mapper.Map<TechnologyDTO, Technology>(technologyDTO);
                var createTechnology = new Technology()
                {
                    TechnologyName = technology.TechnologyName.Trim().ToUpper(),
                    ImageUrl = technology.ImageUrl,
                };
                await _context.Technologies.AddAsync(createTechnology);
                var res = await _context.SaveChangesAsync();
                if (res > 0)
                {
                    response.Status = HttpStatusCode.OK;
                    response.Data = "Technology added successfully!";
                    response.IsSuccess = true;

                }
                else
                {
                    response.Status = HttpStatusCode.Forbidden;
                    response.Data = "Some Erorr Occured While SAving Data to Database";
                    response.IsSuccess = false;
                }


            }
            catch (Exception ex) {

                throw new DALException(ex.Message, ex);

            }
            return response;

        }
        public async Task<ResponseModel<TechnologyDTO>> GetTechnology(int TechnologyId)
        {
            var response = new ResponseModel<TechnologyDTO>();
            try
            {
                var technology = await _context.Technologies.Where(x => x.Id == TechnologyId).FirstOrDefaultAsync();
                if (technology == null)
                {
                    response.Status = HttpStatusCode.NotFound;
                    response.IsSuccess = false;
                    response.Message = "Technology Not Found In Database";
                }
                else
                {
                    var technologyDto = new TechnologyDTO { Id = technology.Id, TechnologyName = technology.TechnologyName, ImageUrl = technology.ImageUrl, IsPublished = technology.IsPublished };
                    response.Data = technologyDto;
                    response.Status = HttpStatusCode.OK;
                    response.IsSuccess = true;
                }


            }
            catch (Exception ex)
            {
                throw new DALException($"{ex.Message}", ex);

            }
            return response;
        }

        public async Task<ResponseModel<string>> DeleteTechnology(int TechnologyId)
        {
            var response = new ResponseModel<string>();
            try
            {
                var TechnologyToRemove = await _context.Technologies.FindAsync(TechnologyId);
                if (TechnologyToRemove != null)
                {
                    var categories = await _context.TutorialCategories.Where(x => x.TechnologyId == TechnologyId).ToListAsync();
                    if (categories != null)
                    {
                        foreach (var category in categories)
                        {
                            var tutorialItems = await _context.TutorialItems.Where(x => x.TutorialCategoryId == category.Id).ToListAsync();
                            _context.RemoveRange(tutorialItems);
                        }
                        _context.RemoveRange(categories);
                    }
                    _context.Technologies.Remove(TechnologyToRemove);
                    var res = await _context.SaveChangesAsync();

                    response.Data = "Technology Deleted Successfully";
                    response.Status = HttpStatusCode.OK;
                    response.IsSuccess = true;

                }
                else
                {
                    response.IsSuccess = false;
                    response.Data = "No Technology Found With This Particular CategroyID";
                    response.Status = HttpStatusCode.BadRequest;
                }


            }
            catch (Exception ex)
            {
                throw new DALException(ex.Message, ex);
            }
            return response;
        }
        public async Task<ResponseModel<string>> UpdateTechnology(TechnologyDTO technologyDto)
        {
            var response = new ResponseModel<string>();
            try
            {
                var technology = await _context.Technologies.Where(x => x.Id == technologyDto.Id).FirstOrDefaultAsync();
                if (technology != null)
                {

                    technology.IsPublished = true;
                    _context.Technologies.Update(technology);

                    await _context.SaveChangesAsync();
                    response.Data = "Updated Technology Successfully!";
                    response.Status = HttpStatusCode.OK;
                    response.IsSuccess = true;

                }
                else
                {
                    response.IsSuccess = false;
                    response.Data = "No item found with the Particular Technology!";
                    response.Status = HttpStatusCode.BadRequest;

                }


            }
            catch (Exception ex) {
                throw new DALException(ex.Message, ex);
            }
            return response;
        }
        public ResponseModel<GetTutorialCategoriesDTO> GetCategoryById(int categoryId)
        {
            var response = new ResponseModel<GetTutorialCategoriesDTO>();
            try
            {
                var category = _context.TutorialCategories.Include("Technology").Where(x => x.Id == categoryId).FirstOrDefault();
                if (category == null)
                {
                    response.IsSuccess = false;
                    response.Status = HttpStatusCode.NotFound;
                    response.Message = "Category Not Found";
                }
                else
                {
                    var res = new GetTutorialCategoriesDTO()
                    {
                        Id = category.Id,
                        TechnologyId = category.TechnologyId,
                        TechnologyName = category.Technology.TechnologyName,
                        TutorialCategoryName = category.TutorialCategoryName,
                        IsPublished = category.IsPublished
                    };
                    response.IsSuccess = true;
                    response.Data = res;
                    response.Status = HttpStatusCode.OK;
                }

            }
            catch (Exception ex) { throw new DALException($"{ex.Message}", ex); }
            return response;

        }
        public async Task<ResponseModel<string>> AddTutorialCategory(TutorialCategoryDTO tutorialCategoryDTO)
        {
            var response = new ResponseModel<string>();
            try {
                var categories = tutorialCategoryDTO.TutorialCategoryName;

                foreach (var category in categories)
                {

                    var existingTutorialCategory = await _context.TutorialCategories
                        .FirstOrDefaultAsync(data => data.TutorialCategoryName == category.Trim().ToUpper());


                    if (existingTutorialCategory == null)
                    {

                        var technology = await _context.Technologies.FindAsync(tutorialCategoryDTO.TechnologyId);

                        if (technology != null)
                        {

                            var createTutorialCategory = new TutorialCategory()
                            {
                                TechnologyId = technology.Id,
                                TutorialCategoryName = category.Trim().ToUpper(),
                            };


                            await _context.TutorialCategories.AddAsync(createTutorialCategory);
                        }
                        else
                        {
                            //throw new DALException( "Failed To add category");
                            response.Message = "Failed to add categories as selected technology is unavailable";
                        }
                    }
                }
                var res = await _context.SaveChangesAsync();
                if (res > 0)
                {
                    response.Data = "Tutorial Category added successfully!";
                    response.Status = HttpStatusCode.OK;
                    response.IsSuccess = true;
                }
                else
                {
                    response.IsSuccess = false;
                    response.Status = HttpStatusCode.BadRequest;
                    response.Data = "Some Error Occured While saving Categories to Database";
                }



            } catch (Exception ex) { throw new DALException(ex.Message, ex); }
            return response;
        }


        public async Task<ResponseModel<string>> DeleteTutorialCategory(int CategoryId)
        {
            var response = new ResponseModel<string>();
            try
            {
                var categoryToRemove = await _context.TutorialCategories.FindAsync(CategoryId);
                if (categoryToRemove != null)
                {
                    var categoryItems = await _context.TutorialItems.Where(x => x.TutorialCategoryId == CategoryId).ToListAsync();
                    _context.TutorialItems.RemoveRange(categoryItems);
                    _context.TutorialCategories.Remove(categoryToRemove);
                    var res = await _context.SaveChangesAsync();

                    response.Data = "Deleted Successfully";
                    response.Status = HttpStatusCode.OK;
                    response.IsSuccess = true;

                }
                else {
                    response.Data = "No Such Category Found With Particular CategoryId";
                    response.Status = HttpStatusCode.NotFound;
                    response.IsSuccess = false;
                }

                //throw new DALException("No Category Found with the Particular CategoryId !");
            } catch (Exception ex) { throw new DALException(ex.Message, ex); }
            return response;
        }

        public async Task<ResponseModel<string>> UpdateTutorialCategory(GetTutorialCategoriesDTO tutorialCategoryDTO)
        {
            var response = new ResponseModel<string>();
            try
            {
                var category = _context.TutorialCategories.Include("Technology").Where(x => x.Id == tutorialCategoryDTO.Id).FirstOrDefault();
                if (category != null) {
                    var technology = _context.Technologies.Where(x => x.Id == tutorialCategoryDTO.TechnologyId).FirstOrDefault();

                    if (technology != null)
                    {

                        category.TutorialCategoryName = tutorialCategoryDTO.TutorialCategoryName;
                        category.TechnologyId = technology.Id;
                        category.IsPublished = tutorialCategoryDTO.IsPublished;


                        _context.TutorialCategories.Update(category);

                        await _context.SaveChangesAsync();
                        response.Data = "Updated Tutorial Category Successfully!";
                        response.Status = HttpStatusCode.OK;
                        response.IsSuccess = true;
                    }
                    else { response.IsSuccess = false;
                        response.Status = HttpStatusCode.BadRequest;
                        response.Data = "No Technology Available With the Particular Category";
                    }
                }
                else
                {
                    response.IsSuccess = false;
                    response.Data = "No Item Found With the same Category";
                    response.Status = HttpStatusCode.NotFound;

                }


                //throw new Exception( "No item found with the Particular Category!");
            }
            catch (Exception ex) { throw new DALException(ex.Message, ex); }
            return response;
        }
        public async Task<ResponseModel<TutorialItemDTO>> GetTutorial(int id)
        {
            var response = new ResponseModel<TutorialItemDTO>();
            try
            {
                var tutorial = await _context.TutorialItems.Where(x => x.Id == id).FirstOrDefaultAsync();
                if (tutorial == null)
                {
                    response.Status = HttpStatusCode.NotFound;
                    response.IsSuccess = false;
                }
                else
                {
                    var category = await _context.TutorialCategories.Where(x => x.Id == tutorial.TutorialCategoryId).FirstOrDefaultAsync();
                    if (category == null)
                    {
                        response.Message = "Category is Null";
                    }
                    var tutorialDto = new TutorialItemDTO { Id = tutorial.Id, TechnologyId = category.TechnologyId, Topic = tutorial.Topic, Description = tutorial.Description, IsPublished = tutorial.IsPublished, TutorialCategoryId = category.Id };
                    response.Data = tutorialDto;
                    response.Status = HttpStatusCode.OK;
                    response.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {
                throw new DALException(ex.Message, ex);
            }
            return response;
        }
        public async Task<ResponseModel<string>> AddTutorial(TutorialItemDTO tutorialItemDTO)
        {
            var response = new ResponseModel<string>();
            try
            {
                var existingTutorialCategory = await _context.TutorialCategories.FirstOrDefaultAsync(data => data.Id == tutorialItemDTO.TutorialCategoryId && data.Technology.Id == tutorialItemDTO.TechnologyId);
                if (existingTutorialCategory != null)
                {
                    var createTutorial = new TutorialItem()
                    {
                        Topic = tutorialItemDTO.Topic,
                        Description = tutorialItemDTO.Description,
                        TutorialCategoryId = tutorialItemDTO.TutorialCategoryId

                    };
                    await _context.TutorialItems.AddAsync(createTutorial);
                    var res = await _context.SaveChangesAsync();

                    response.Data = "Tutorial Category added successfully!";
                    response.Status = HttpStatusCode.OK;
                    response.IsSuccess = true;
                }
                else {
                    response.Data = "Error while adding Tutorial !";
                    response.Status = HttpStatusCode.BadRequest;
                    response.IsSuccess = false;
                }

                //throw new DALException( "Error while adding Tutorial !");
            }
            catch (Exception ex) { throw new DALException(ex.Message, ex); }
            return response;
        }
        public async Task<ResponseModel<string>> DeleteTutorial(int TutorialId)
        { var response = new ResponseModel<string>();
            try {
                var tutorialToRemove = await _context.TutorialItems.FindAsync(TutorialId);

                if (tutorialToRemove != null)
                {
                    _context.TutorialItems.Remove(tutorialToRemove);
                    var res = await _context.SaveChangesAsync();

                    response.Data = "Tutorial deleted successfully";
                    response.IsSuccess = true;
                    response.Status = HttpStatusCode.OK;

                }
                else
                {
                    response.Data = "No Tutorial Found With PArticular TUtorial Id";
                    response.Status = HttpStatusCode.NotFound;
                    response.IsSuccess = false;
                }

                //throw new DALException ("No Tutorial Found with the Particular TutorialId !");
            } catch (Exception ex) { throw new DALException(ex.Message, ex); }
            return response;
        }

        public async Task<ResponseModel<string>> UpdateTutorial(TutorialItemDTO tutorialDto)
        {
            var response = new ResponseModel<string>();
            try
            {
                var tutorial = _context.TutorialItems.Include("TutorialCategory").Where(x => x.Id == tutorialDto.Id).FirstOrDefault();
                if (tutorial != null)
                {

                    tutorial.Topic = tutorialDto.Topic;
                    tutorial.Description = tutorialDto.Description;
                    tutorial.TutorialCategoryId = tutorialDto.TutorialCategoryId;
                    tutorial.IsPublished = tutorialDto.IsPublished;

                    _context.TutorialItems.Update(tutorial);
                    //_context.Entry(tutorial).CurrentValues.SetValues(newtutorial);

                    await _context.SaveChangesAsync();
                    response.Data = "Updated Tutorial Successfully!";
                    response.Status = HttpStatusCode.OK;
                    response.IsSuccess = true;

                }
                else
                {
                    response.Data = "No item found with the Particular Tutorial!";
                    response.Status = HttpStatusCode.NotFound;
                    response.IsSuccess = false;
                }
                //throw new DALException("No item found with the Particular Tutorial!");
            }
            catch (Exception ex)
            {
                throw new DALException(ex.Message, ex);
            }
            return response;



        }

        public ResponseModel<IQueryable<GetTutorialCategoriesDTO>> GetTutorialCategoriesAsync(int technologyId)
        {
            var response = new ResponseModel<IQueryable<GetTutorialCategoriesDTO>>();
            try
            {
                var res = _context.TutorialCategories.Where(x => x.TechnologyId == technologyId);



                response.Data = from tutorial in res select _mapper.Map<TutorialCategory, GetTutorialCategoriesDTO>(tutorial);
                response.Status = HttpStatusCode.OK;
                response.IsSuccess = true;
            } catch (Exception ex) { throw new DALException(ex.Message, ex); }
            return response;
        }
        public async Task<ResponseModel<IQueryable<GetTutorialCategoriesDTO>>> GetAllCategories(RequestModel @params)
        {
            var response = new ResponseModel<IQueryable<GetTutorialCategoriesDTO>>();
            try
            {
                //var offset = (@params.Page - 1) * @params.ItemsPerPage;
                PaginationParams paginationParams = new PaginationParams();
                paginationParams.PageNo = @params.PageNo;
                paginationParams.ItemsPerPage = @params.ItemsPerPage;
                var res = _context.TutorialCategories.Include(x => x.Technology).OrderBy(c => c.Id).Skip(paginationParams.Offset).Take(@params.ItemsPerPage);
                response.Data = res.Select(category => new GetTutorialCategoriesDTO
                {

                    Id = category.Id,
                    TutorialCategoryName = category.TutorialCategoryName,
                    TechnologyId = category.TechnologyId,
                    TechnologyName = category.Technology != null ? category.Technology.TechnologyName : null,
                    IsPublished = category.IsPublished
                });
              response.TotalRecords = await _context.TutorialCategories.CountAsync();
                response.Status = HttpStatusCode.OK;
                response.IsSuccess = true;

            }
            catch (Exception ex) { throw new DALException(ex.Message, ex); }
            return response;
        }



        public  ResponseModel<IQueryable<TechnologyDTO>> GetTechnologiesAsync()
        {
            var response=new ResponseModel<IQueryable<TechnologyDTO>>();
            try
            {
                var res = _context.Technologies;

                response.Data = from tutorial in res select _mapper.Map<Technology, TechnologyDTO>(tutorial);
                response.Status = HttpStatusCode.OK;
                response.IsSuccess = true;
               
            }catch(Exception ex) { 
                throw new DALException($"{ex.Message}", ex);  
                
            }
            return response;
        }

        public async Task<ResponseModel<IQueryable<TechnologyDTO>>> GetAllTechnologiesAsync(RequestModel @params)
        {
            var response = new ResponseModel<IQueryable<TechnologyDTO>>();
            try
            {
               
                PaginationParams paginationParams = new PaginationParams();
                paginationParams.PageNo = @params.PageNo;
                paginationParams.ItemsPerPage = @params.ItemsPerPage;
                var res = _context.Technologies.OrderBy(c => c.Id).Skip(paginationParams.Offset).Take(@params.ItemsPerPage);
                response.Data= from tutorial in res select _mapper.Map<Technology, TechnologyDTO>(tutorial);
                response.TotalRecords = await _context.Technologies.CountAsync();
                response.Status = HttpStatusCode.OK;
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                throw new DALException($"{ex.Message}", ex);

            }
            return response;

        }
        public ResponseModel<IQueryable<TechnologyDTO>> GetTechnologiesPublishedAsync()
        {
            var response = new ResponseModel<IQueryable<TechnologyDTO>>();
            try
            {
                var res = _context.Technologies.Where(x => x.IsPublished == true);
                response.Data = from tutorial in res select _mapper.Map<Technology, TechnologyDTO>(tutorial);
                response.Status = HttpStatusCode.OK;
                response.IsSuccess = true;
            }
            catch(Exception ex) { throw new DALException(ex.Message,ex); }
            return response;
        }
        public ResponseModel<IQueryable<GetTutorialCategoriesDTO>> GetTutorialCategoriesByTechId(int technologyId)
        {
            var response=new ResponseModel<IQueryable<GetTutorialCategoriesDTO>>();
            try
            {
                var res = _context.TutorialCategories.Where(x => x.TechnologyId == technologyId);



                response.Data= from tutorial in res select _mapper.Map<TutorialCategory, GetTutorialCategoriesDTO>(tutorial);
                response.Status= HttpStatusCode.OK;
                response.IsSuccess = true;
            }catch (Exception ex) { throw new DALException(ex.Message,ex);}
            return response;
        }


        public async Task<ResponseModel<GetTechnologyDTO>> GetTechnologyDetailsAsync(int technologyId)
        {
            var response=new ResponseModel<GetTechnologyDTO>();
            try
            {
                var technology = await _context.Technologies
               .Include(t => t.TutorialCategory.Where(x => x.IsPublished == true))
               .ThenInclude(c => c.TutorialItems.Where(x => x.IsPublished == true))
               .FirstOrDefaultAsync(t => t.Id == technologyId && t.IsPublished == true);

                if (technology == null)
                {
                    response.Status = HttpStatusCode.NotFound;
                    response.IsSuccess = false;
                    response.Message = "Not Found";
                }
                else
                {

                    var technologyDTO = new GetTechnologyDTO
                    {
                        Id = technology.Id,
                        TechnologyName = technology.TechnologyName,
                        ImageUrl = technology.ImageUrl,
                        IsPublished = technology.IsPublished,
                        Categories = technology.TutorialCategory.Select(c => new GetTechnologyCategoryDTO
                        {
                            CategoryId = c.Id,
                            CategoryName = c.TutorialCategoryName,
                            IsPublished = c.IsPublished,

                            CategoryItems = c.TutorialItems.Select(ci => new GetTutorialCategoryItem
                            {
                                Id = ci.Id,
                                Topic = ci.Topic,
                                Description = ci.Description,
                                CategoryId = ci.TutorialCategoryId,
                                IsPublished = ci.IsPublished



                            }).ToList()
                        }).ToList()
                    };


                    response.Data= technologyDTO;
                    response.IsSuccess = true;
                    response.Status= HttpStatusCode.OK;
                }
            }catch  (Exception ex) { throw new DALException(ex.Message, ex); }
            return response;
        }

        public async Task<ResponseModel<IQueryable<TutorialItemDTO>>> GetAllTutorialItemsAsync(RequestModel @params)
        {
            var response =new ResponseModel<IQueryable<TutorialItemDTO>>();
            try
            {
                PaginationParams paginationParams = new PaginationParams();
                paginationParams.PageNo = @params.PageNo;
                paginationParams.ItemsPerPage = @params.ItemsPerPage;
                var res =  _context.TutorialItems.OrderBy(c => c.Id).Skip(paginationParams.Offset).Take(@params.ItemsPerPage); ;

                response.Data = from tutorial in res select _mapper.Map<TutorialItem, TutorialItemDTO>(tutorial);

                response.TotalRecords = await _context.TutorialItems.CountAsync();
                response.Status = HttpStatusCode.OK;
                response.IsSuccess = true;
            }catch(Exception ex) { throw new DALException(ex.Message,ex); }
            return response;
        }

  
      
    }
}
