using System;
using cs_all_spell.Models;
using cs_all_spell.Repositories;

namespace cs_all_spell.Services
{
    public class SpellReagentsService
    {
        private readonly SpellReagentsRepository _repo;

        public SpellReagentsService(SpellReagentsRepository repo)
        {
            _repo = repo;
        }



        public SpellReagentDTO Create(SpellReagentDTO data)
        {
            return _repo.Create(data);
        }



        public SpellReagentDTO Update(SpellReagentDTO data)
        {
            if (_repo.Update(data))
            {
                return data;
            }
            throw new Exception("Something has gone wrong...");
        }



        internal void Delete(int id)
        {
            if (!_repo.Delete(id))
            {
                throw new Exception("Something has gone wrong...");
            };
        }
    }
}