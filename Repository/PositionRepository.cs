using Data;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class PositionRepository : BaseRepository<Position>
    {
        public PositionRepository(WebDatabaseContext context) : base(context)
        {

        }
    }
}
