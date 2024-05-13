using Edu.Shared.DTO;

using Edu.Shared.Interfaces.Technology;
using Edu.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edu.BLL.Tutorial
{
    public class TechnologyBLL
    {
        private readonly ITechnologyRepository _technologyRepository;

        public TechnologyBLL(ITechnologyRepository technologyRepository)
        {
            _technologyRepository = technologyRepository;
        }
        public async Task<ResponseModel<string>> AddTechnology(TechnologyDTO tutorialDTO)
        {
            try
            {
                var res = await _technologyRepository.AddTechnology(tutorialDTO);
                return res;
                
            }
           
            
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ResponseModel<string>> DeleteTechnology(int TechnologyId)
        {
            try
            {
                var res = await _technologyRepository.DeleteTechnology(TechnologyId);
                return res;
            }catch (Exception ex) { throw new Exception (ex.Message); };
        }
        public async Task<ResponseModel<TechnologyDTO>> GetTechnology(int TechnologyId)
        {
            try
            {
                var res = await _technologyRepository.GetTechnology(TechnologyId);
                return res;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<ResponseModel<string>> UpdateTechnology(TechnologyDTO technologyDto)
        {
            try
            {
                var res = await _technologyRepository.UpdateTechnology(technologyDto);
                return res;
            }
            catch(Exception ex) { throw new Exception(ex.Message); };
        }

        public async Task<ResponseModel<string>> AddTutorialCategory(TutorialCategoryDTO tutorialCategoryDTO)
        {
            try
            {
                var res = await _technologyRepository.AddTutorialCategory(tutorialCategoryDTO);
                return res;
            }
            catch (Exception ex) { throw new Exception(ex.Message) ; }
        }
        public ResponseModel<GetTutorialCategoriesDTO> GetCategoryById(int categoryId)
        {
            try
            {
                var res = _technologyRepository.GetCategoryById(categoryId);
                return res;
            }
            catch(Exception ex) { throw new Exception(ex.Message); }
        }
        public async Task<ResponseModel<string>> DeleteTutorialCategory(int CategoryId)
        {
            
            try
            {
                var res = await _technologyRepository.DeleteTutorialCategory(CategoryId);
                
                return res;
            }
            catch(Exception ex) { throw new Exception(ex.Message); }
        }

        public async Task<ResponseModel<string>> UpdateTutorialCategory(GetTutorialCategoriesDTO tutorialCategoryDTO)
        {
            try
            {
                var res = await _technologyRepository.UpdateTutorialCategory(tutorialCategoryDTO);
                return res;
            }
            catch(Exception ex) { throw new Exception(ex.Message); }
        }
        public async Task<ResponseModel<IQueryable<GetTutorialCategoriesDTO>>> GetAllCategories(RequestModel @params)
        {
            try
            {
                var res = await _technologyRepository.GetAllCategories(@params);
                return res;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public async Task<ResponseModel<IQueryable<TechnologyDTO>>> GetAllTechnologiesAsync(RequestModel @params)
        {
            try
            {
                var res = await _technologyRepository.GetAllTechnologiesAsync(@params);
                return res;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        public ResponseModel<IQueryable<GetTutorialCategoriesDTO>> GetTutorialCategoriesAsync(int technologyId)
        {
            try
            {
                var res = _technologyRepository.GetTutorialCategoriesAsync(technologyId);
                return res;
            }catch(Exception ex) { throw new Exception(ex.Message); }
        }
        public ResponseModel<IQueryable<TechnologyDTO>> GetTechnologiesAsync()
        {
            try
            {
                var res = _technologyRepository.GetTechnologiesAsync();
                return res;
            }catch (Exception ex) { throw new Exception(ex.Message); }
        }
        public ResponseModel<IQueryable<TechnologyDTO>> GetTechnologiesPublishedAsync()
        {
            try
            {
                var res =  _technologyRepository.GetTechnologiesPublishedAsync();
                return res;
            }
            catch(Exception ex) { throw new Exception(ex.Message) ; }
        }
        public async Task<ResponseModel<string>> AddTutorial(TutorialItemDTO tutorialItemDTO)
        {
            try
            {
                var res = await _technologyRepository.AddTutorial(tutorialItemDTO);
                return res;
            }
            catch (Exception ex) { throw new Exception(ex.Message) ; }
        }

        public async Task<ResponseModel<string>> DeleteTutorial(int TutorialId)
        {
            try
            {
                var res = await _technologyRepository.DeleteTutorial(TutorialId);
                return res;
            }
            catch (Exception ex) { throw new Exception(ex.Message) ; }
        }

        public async Task<ResponseModel<string>> UpdateTutorial(TutorialItemDTO tutorialDto)
        {
            try
            {
                var res = await _technologyRepository.UpdateTutorial(tutorialDto);
                return res;
            }
            catch (Exception ex) { throw new Exception(ex.Message) ; }
        }
        public async Task<ResponseModel<TutorialItemDTO>> GetTutorial(int TechnologyId)
        {
            try
            {
                var res = await _technologyRepository.GetTutorial(TechnologyId);
                return res;
            }
            catch (Exception ex) { throw new Exception(ex.Message) ; }
        }
        public async Task<ResponseModel<GetTechnologyDTO>> GetTechnologyDetailsAsync(int technologyId)
        {
            try
            {
                var res = await _technologyRepository.GetTechnologyDetailsAsync(technologyId);
                return res;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        public async Task<ResponseModel<IQueryable<TutorialItemDTO>>> GetAllTutorialItemsAsync(RequestModel @params)
        {
            try
            {
                var res = await _technologyRepository.GetAllTutorialItemsAsync(@params);

                return res;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
    }
}
