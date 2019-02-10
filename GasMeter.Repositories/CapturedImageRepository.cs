using GasMeter.Data;
using GasMeter.DataModels;
using GasMeter.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace GasMeter.Repositories
{
    public class CapturedImageRepository : Repository<CapturedImage>, ICapturedImageRepository
    {
        public CapturedImageRepository(GasMeterDbContext context) : base(context)
        {

        }
    }
}
