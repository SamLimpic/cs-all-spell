using System;
using System.Collections.Generic;
using System.Data;
using cs_all_spell.Models;
using Dapper;

namespace cs_all_spell.Repositories
{
    public class SpellsRepository
    {

        private readonly IDbConnection _db;

        public SpellsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal IEnumerable<Spell> GetAll()
        {
            string sql = "SELECT * FROM spells";
            return _db.Query<Spell>(sql);
        }

        internal Spell GetById(int id)
        {
            string sql = "SELECT * FROM spells WHERE id == @id";
            return _db.QueryFirstOrDefault<Spell>(sql, new { id });
        }

        internal Spell Create(Spell newSpell)
        {
            string sql = @"
            INSERT INTO spells
            (name, school, description, level,  castingTime, material, verbal, somatic, concentration)
            VALUES
            (@Name, @School, @Description, @Level, @CastingTime,  @Material, @Verbal, @Somatic, @Concentration)
            SELECT LAST_INSERT_ID()";
            newSpell.Id = _db.ExecuteScalar<int>(sql, newSpell);
            return newSpell;
        }

        internal bool Update(Spell original)
        {
            string sql = @"
            UPDATE spells
            SET
                name = @Name,
                school = @School,
                description = @Description,
                level = @Level,
                castingTime = @CastingTime,
                material = @Material,
                verbal = @Verbal,
                somatic = @Somatic,
                concentration = @Concentration";
            int affectedRows = _db.Execute(sql, original);
            return affectedRows == 1;
        }

        internal bool Delete(int id)
        {
            string sql = "DELETE FROM spells WHERE id = @id LIMIT 1";
            int affectedRows = _db.Execute(sql, new { id });
            return affectedRows == 1;
        }
    }
}