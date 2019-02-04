using GasMeter.Data;
using GasMeter.DataModels;
using GasMeter.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GasMeter.Repositories
{
    public class MeasureRepository : Repository<Measure>, IMeasureRepository
    {
        public MeasureRepository(GasMeterDbContext context) : base(context)
        {

        }

        public Measure GetWithImage(Guid id)
        {
            return context.Measures
                .Where(m => m.Id == id)
                .Include(m => m.Image)
                .FirstOrDefault();
        }

        public IEnumerable<Measure> GetAllWithImage()
        {
            return context.Measures.Include(m => m.Image);
        }
    }
}
