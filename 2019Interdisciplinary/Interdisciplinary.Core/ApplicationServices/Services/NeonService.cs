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
            try
            {
                //if(nl.Color == null) throw new InvalidDataException("You need a color for the neonlight");
                //else if (nl.Description == null)
                //    throw new InvalidDataException("You need a description for the product");
                //else if (nl.Name == null) throw new InvalidDataException("You need a name for the product");
                //else if (nl.Shape == null) throw new InvalidDataException("You need a Shape for the Product");
                _nlRepo.Create(nl);
            }
            catch (Exception ex)
            {
                throw new InvalidDataException("You are missing some data");
            }
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

        public Neonlight Update(Neonlight nlToUpdate)
        {
            try
            {
                return _nlRepo.Update(nlToUpdate);
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
