using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Interdisciplinary.Core.DomainServices;
using Interdisciplinary.Core.Entity;

namespace Interdisciplinary.Core.ApplicationServices.Services
{
    public class NeonService: INeonService
    {
        private INeonLightRepository _nlRepo;

        public NeonService(INeonLightRepository nlRepo)
        {
            _nlRepo = nlRepo;
        }
        public void Create(Neonlight nl)
        {
            _nlRepo.Create(nl);
        }

        public Neonlight ReadById(int id)
        {
            try
            {
                return _nlRepo.ReadById(id);
            }
            catch (Exception ex)
            {
                throw new InvalidDataException("The id does not exist");
            }

        }

        public List<Neonlight> ReadAll()
        {
            try
            {
                return _nlRepo.ReadAll().ToList();
            }
            catch (Exception ex)
            {
                throw new InvalidDataException("There is no neonlights in da shop");
            }
        }

        public Neonlight Update(int id)
        {
            try
            {
                return _nlRepo.Update(id);
            }
            catch (Exception ex)
            {
                throw new InvalidDataException("You have entered something wrong");
            }
        }

        public void Delete(int id)
        {
            try
            {
                _nlRepo.Delete(id);
            }
            catch (Exception ex)
            {
                throw new InvalidDataException("The id does not exist fagget!");
            }
        }
    }
}
