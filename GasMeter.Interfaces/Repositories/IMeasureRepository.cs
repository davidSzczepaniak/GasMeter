using GasMeter.DataModels;
using System;
using System.Collections.Generic;

namespace GasMeter.Interfaces.Repositories
{
    public interface IMeasureRepository : IRepository<Measure>
    {
        IEnumerable<Measure> GetAllWithImage();

        Measure GetWithImage(Guid id);
    }
}
