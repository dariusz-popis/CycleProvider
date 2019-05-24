using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CycleProvider.Library
{
    public class DbProviderMock : IDisposable
    {
        private string _dbConnection;
        private string _name;

        public DbProviderMock(string name = null)
        {
            _name = name ?? $"Noname {DateTime.Now:hh:mm:ss:ms}";
            _dbConnection = "OPEN";
        }

        #region Dispose pattern implementation (region created for learning only)
        private bool _disposed = false;
        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool dispose)
        {
            if (_disposed) return;

            _disposed = true;
            if (!dispose) Console.WriteLine($"Developer didn't invoke Dispose() for => {_name}");

            _dbConnection = "CLOSE";
            Console.WriteLine($"Dispose({dispose}) invoked {DateTime.Now:mm:ss:ms}. Status db {_dbConnection}=> by: '{_name}'");

            GC.SuppressFinalize(this);
        }

        ~DbProviderMock()
        {
            if (!_disposed) Dispose(false);
            else
            {
                Console.WriteLine($"***\n* Finalize() [destructor] invoked by GC at {DateTime.Now:mm:ss:ms}. Status db {_dbConnection}=> by: '{_name}'\n***");
                throw new ObjectDisposedException("Don't play with me and with Garbage Collector !!!");
            }
        }
            #endregion
        }
}
