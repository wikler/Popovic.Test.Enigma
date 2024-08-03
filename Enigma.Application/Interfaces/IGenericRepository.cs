using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Enigma.Domain.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        T? GetById(Guid id);
        List<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
    }
}
