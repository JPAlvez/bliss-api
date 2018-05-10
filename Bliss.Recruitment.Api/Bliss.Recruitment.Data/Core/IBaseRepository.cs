using System.Collections.Generic;

namespace Bliss.Recruitment.Data.Core
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        TEntity Add(TEntity entity);
        TEntity TrackExisting(TEntity entity);
        TEntity Delete(TEntity entity);
        TEntity Get(long id);

        void Save();
        void Dispose();
    }
}
