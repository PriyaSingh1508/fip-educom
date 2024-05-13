using Edu.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edu.Shared.Interfaces.IServices
{
    public interface IBlobService
    {
        public Task<string> Upload(TutorialCategoryDTO tutorialCategoryDTO);
    }
}
