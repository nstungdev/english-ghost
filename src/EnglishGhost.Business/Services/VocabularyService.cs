using EnglishGhost.Business.Forms;
using EnglishGhost.Business.Utils;
using EnglishGhost.Infrastructure.Entities;
using EnglishGhost.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishGhost.Business.Services
{
    public class VocabularyService
    {
        private readonly UnitOfWork _unitOfWork;
        public VocabularyService()
        {
            _unitOfWork = new UnitOfWork(Appsetting.ConnectionString);
        }

        public async Task CreateOneAsync(VocabularyForm form)
        {
            var vocal = Mapper.Map<Vocabulary>(form);
            await _unitOfWork.VocabularyRepository.AddAsync(vocal);
        }

        public async Task<IEnumerable<Vocabulary>> GetAll()
        {
            return await _unitOfWork.VocabularyRepository.GetAll();
        }
    }
}
