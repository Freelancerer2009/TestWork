using Data;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLayer
{
    public class UnitOfWork
    {
        private WebDatabaseContext _context;
        public readonly WebDatabaseContext Context;        

        public UnitOfWork()
        {
            Context = new WebDatabaseContext();
        }

        #region RepositoriesField
        private EmployeeRepository _employeeRepository;
        private PositionRepository _positionRepository;
        #endregion

        #region Repositories prop
        public EmployeeRepository EmployeeRepository
        {
            get
            {
                if (_employeeRepository == null)
                    _employeeRepository = new EmployeeRepository(Context);
                return _employeeRepository;
            }
        }
        public PositionRepository PositionRepository
        {
            get
            {
                if (_positionRepository == null)
                    _positionRepository = new PositionRepository(Context);
                return _positionRepository;
            }
        }
        #endregion

    }
}
