using System;
using System.Collections.Generic;
using System.Data;
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

        internal IEnumerable<Reagent> GetAll()
        {
            string sql = "SELECT * FROM reagents";
            return _db.Query<Reagent>(sql);
        }

        internal Reagent GetById(int id)
        {
            string sql = "SELECT * FROM reagents WHERE id == @id";
            return _db.QueryFirstOrDefault<Reagent>(sql, new { id });
        }

        internal Reagent Create(Reagent newReagent)
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

        internal bool Update(Reagent original)
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

        internal bool Delete(int id)
        {
            string sql = "DELETE FROM reagents WHERE id = @id LIMIT 1";
            int affectedRows = _db.Execute(sql, new { id });
            return affectedRows == 1;
        }
    }
}