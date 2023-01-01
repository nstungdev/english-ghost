using EnglishGhost.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishGhost.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IDisposable
    {
        private readonly SQLiteConnection _conn;

        // Flag: Has Dispose already been called?
        private bool _disposed;
        public UnitOfWork(string connectionString)
        {
            _conn = new SQLiteConnection(connectionString);
            _conn.Open();
        }

        public VocabularyRepository VocabularyRepository => new VocabularyRepository(_conn);

        public SQLiteTransaction BeginTransaction()
        {
            return _conn.BeginTransaction();
        }
        public ValueTask<DbTransaction> BeginTransactionAsync()
        {
            return _conn.BeginTransactionAsync();
        }
        protected void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                // Free any other managed objects here.
                _conn.Close();
                _conn.Dispose();
            }

            _disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~UnitOfWork()
        {
            Dispose(false);
        }
    }
}
