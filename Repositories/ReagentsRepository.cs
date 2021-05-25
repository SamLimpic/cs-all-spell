using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using cs_all_spell.Models;
using Dapper;

namespace cs_all_spell.Repositories
{
    public class ReagentsRepository
    {

        private readonly IDbConnection _db;

        public ReagentsRepository(IDbConnection db)
        {
            _db = db;
        }

        public IEnumerable<Reagent> GetAll()
        {
            // NOTE GET ALL & PUPULATE
            //     string sql = @"
            //     SELECT 
            //     r.*,
            //     s.*
            //     FROM reagents r
            //     JOIN spells s ON r.spellId = s.id";
            //     return _db.Query<Reagent, Spell, Reagent>(sql, (reagent, spell) =>
            //     {
            //         reagent.Spell = spell;
            //         return reagent;
            //     }, splitOn: "id");
            string sql = "SELECT * FROM reagents";
            return _db.Query<Reagent>(sql).ToList();
        }

        // public IEnumerable<Reagent> GetBySpellId(int id)
        // {
        // NOTE GET BY SPELL ID & PUPULATE
        //     string sql = @"
        //     SELECT 
        //     r.*,
        //     s.*
        //     FROM reagents r
        //     JOIN spells s ON r.spellId = s.id";
        //     return _db.Query<Reagent, Spell, Reagent>(sql, (reagent, spell) =>
        //     {
        //         reagent.Spell = spell;
        //         return reagent;
        //     }, new { id }, splitOn: "id");
        // }

        public Reagent GetById(int id)
        {
            // NOTE GET BY ID & PUPULATE
            //     string sql = @"
            //     SELECT 
            //     r.*,
            //     s.*
            //     FROM reagents r
            //     JOIN spells s ON r.spellId = s.id";
            //     return _db.Query<Reagent, Spell, Reagent>(sql, (reagent, spell) =>
            //     {
            //         reagent.Spell = spell;
            //         return reagent;
            //     }, new { id }, splitOn: "id").FirstOrDefault();
            string sql = "SELECT * FROM reagents WHERE id = @id";
            return _db.QueryFirstOrDefault<Reagent>(sql, new { id });
        }

        public Reagent Create(Reagent newReagent)
        {
            string sql = @"
            INSERT INTO reagents
            (spellId, name, description)
            VALUES
            (@SpellId, @Name, @Description)
            SELECT LAST_INSERT_ID()";
            newReagent.Id = _db.ExecuteScalar<int>(sql, newReagent);
            return newReagent;
        }

        public bool Update(Reagent original)
        {
            string sql = @"
            UPDATE reagents
            SET
                spellId = @SpellId,
                name = @Name,
                description = @Description";
            int affectedRows = _db.Execute(sql, original);
            return affectedRows == 1;
        }

        public bool Delete(int id)
        {
            string sql = "DELETE FROM reagents WHERE id = @id LIMIT 1";
            int affectedRows = _db.Execute(sql, new { id });
            return affectedRows == 1;
        }
    }
}