using System;
using System.Collections.Generic;
using cs_all_spell.Models;
using cs_all_spell.Repositories;

namespace cs_all_spell.Services
{
    public class SpellsService
    {

        private readonly SpellsRepository _repo;


        public SpellsService(SpellsRepository repo)
        {
            _repo = repo;
        }

        internal IEnumerable<Spell> GetAll()
        {
            return _repo.GetAll();
        }

        internal Spell GetById(int id)
        {
            Spell spell = _repo.GetById(id);
            if (spell == null)
            {
                throw new Exception("Invalid Id");
            }
            return spell;
        }

        internal Spell Create(Spell newSpell)
        {
            Spell spell = _repo.Create(newSpell);
            return newSpell;
        }

        internal Spell Update(Spell edit)
        {
            Spell original = GetById(edit.Id);
            original.Name = edit.Name.Length > 0 ? edit.Name : original.Name;
            original.Description = edit.Description.Length > 0 ? edit.Description : original.Description;

            if (_repo.Update(original))
            {
                return original;
            }
            throw new Exception("Something has gone wrong...");
        }

        internal void DeleteSpell(int id)
        {
            GetById(id);
            _repo.Delete(id);
        }
    }
}