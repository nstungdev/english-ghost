using Dapper;
using EnglishGhost.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishGhost.Infrastructure.Repositories
{
    public class VocabularyRepository : IBaseRepository<Vocabulary>
    {
        private readonly SQLiteConnection _conn;
        private const string _tableName = "vocabulary";
        public VocabularyRepository(SQLiteConnection conn)
        {
            _conn = conn;
        }
        public Task AddAsync(Vocabulary model)
        {
            var props = model.GetType()
                .GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public)
                .Where(e => !e.Name.Equals("Id", StringComparison.OrdinalIgnoreCase))
                .Select(e => $"@{e.Name}");
            var propsStr = string.Join(',', props);
            var cmdText = $"insert into {_tableName} (word, type, mean, pronounce, note) values (@Word, @Type, @Mean, @Pronounce, @Note)";
            return _conn.ExecuteAsync(cmdText, model);
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Vocabulary>> GetAll()
        {
            var cmdText = $"select * from {_tableName}";
            return _conn.QueryAsync<Vocabulary>(cmdText);
        }

        public Task<IEnumerable<Vocabulary>> GetWithCondition(Func<Vocabulary, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Vocabulary model)
        {
            throw new NotImplementedException();
        }
    }
}
