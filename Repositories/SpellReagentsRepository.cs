using System.Collections.Generic;
using System.Data;
using cs_all_spell.Models;
using Dapper;

namespace cs_all_spell.Repositories
{
    public class SpellReagentsRepository
    {
        private readonly IDbConnection _db;

        public SpellReagentsRepository(IDbConnection db)
        {
            _db = db;
        }



        internal IEnumerable<SpellReagentView> GetSpellReagents(int id)
        {
            string sql = @"
            SELECT
            r.*,
            s.name,
            s.id as spellReagentId,
            sr.spellId,
            sr.reagentId,
            FROM
            spell_reagents sr
            JOIN spells s ON s.id = sr.spellId
            JOIN reagents r ON r.id = sr.reagentId
            WHERE
            sr.spellId = @Id
            ";
            return _db.Query<SpellReagentView>(sql, new { id });
        }



        public SpellReagentDTO Create(SpellReagentDTO data)
        {
            string sql = @"
            INSERT INTO spell_reagents
            (spellId, reagentId)
            VALUES
            (@SpellId, @ReagentId)
            SELECT LAST_INSERT_ID()
            ";
            data.Id = _db.ExecuteScalar<int>(sql, data);
            return data;
        }



        internal bool Update(SpellReagentDTO data)
        {
            string sql = @"
            UPDATE spell_reagents
            SET
                spellId = @SpellId,
                reagentId = @ReagentId
            WHERE id = @Id
            ";
            int affectedRows = _db.Execute(sql, data);
            return affectedRows == 1;
        }



        public bool Delete(int id)
        {
            string sql = "DELETE FROM spell_reagents WHERE id = @Id LIMIT 1";
            int affectedRows = _db.Execute(sql, new { id });
            return affectedRows == 1;
        }
    }
}