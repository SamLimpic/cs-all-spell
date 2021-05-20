using System;
using System.Collections.Generic;
using cs_all_spell.Models;
using cs_all_spell.Repositories;

namespace cs_all_spell.Services
{
    public class ReagentsService
    {

        private readonly ReagentsRepository _repo;


        public ReagentsService(ReagentsRepository repo)
        {
            _repo = repo;
        }

        internal IEnumerable<Reagent> GetAll()
        {
            return _repo.GetAll();
        }

        internal Reagent GetById(int id)
        {
            Reagent reagent = _repo.GetById(id);
            if (reagent == null)
            {
                throw new Exception("Invalid Id");
            }
            return reagent;
        }

        internal Reagent Create(Reagent newReagent)
        {
            Reagent reagent = _repo.Create(newReagent);
            return newReagent;
        }

        internal Reagent Update(Reagent edit)
        {
            Reagent original = GetById(edit.Id);
            original.Name = edit.Name.Length > 0 ? edit.Name : original.Name;
            original.Description = edit.Description.Length > 0 ? edit.Description : original.Description;

            if (_repo.Update(original))
            {
                return original;
            }
            throw new Exception("Something has gone wrong...");
        }

        internal void DeleteReagent(int id)
        {
            GetById(id);
            _repo.Delete(id);
        }
    }
}