using Edu.Shared.DTO;
using Edu.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edu.Shared.Interfaces.Technology
{
    public interface ITechnologyRepository
    {
        public Task<ResponseModel<string>> AddTechnology(TechnologyDTO technologyDTO);
        public Task<ResponseModel<string>> DeleteTechnology(int TechnologyId);
        public Task<ResponseModel<string>> UpdateTechnology(TechnologyDTO technologyDto);
        public Task<ResponseModel<IQueryable<TechnologyDTO>>> GetAllTechnologiesAsync(RequestModel @params);
        public Task<ResponseModel<TechnologyDTO>> GetTechnology(int TechnologyId);
        public Task<ResponseModel<TutorialItemDTO>> GetTutorial(int id);
        public Task<ResponseModel<string>> AddTutorialCategory(TutorialCategoryDTO tutorialCategoryDTO);
        public ResponseModel<GetTutorialCategoriesDTO> GetCategoryById(int categoryId);
        public Task<ResponseModel<string>> DeleteTutorialCategory(int CategoryId);
        public Task<ResponseModel<string>> UpdateTutorialCategory(GetTutorialCategoriesDTO tutorialCategoryDTO);
        public ResponseModel<IQueryable<GetTutorialCategoriesDTO>> GetTutorialCategoriesAsync(int technologyId);
        public ResponseModel<IQueryable<TechnologyDTO>> GetTechnologiesAsync();
        public Task<ResponseModel<IQueryable<GetTutorialCategoriesDTO>>> GetAllCategories(RequestModel @params);
        public ResponseModel<IQueryable<TechnologyDTO>> GetTechnologiesPublishedAsync();
        public Task<ResponseModel<string>> AddTutorial(TutorialItemDTO tutorialItemDTO);
        public Task<ResponseModel<string>> DeleteTutorial(int TutorialId);
        public Task<ResponseModel<string>> UpdateTutorial(TutorialItemDTO tutorialDto);
        public Task<ResponseModel<GetTechnologyDTO>> GetTechnologyDetailsAsync(int technologyId);
        public Task<ResponseModel<IQueryable<TutorialItemDTO>>> GetAllTutorialItemsAsync(RequestModel @params);
    }
}
