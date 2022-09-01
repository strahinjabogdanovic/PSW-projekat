using System;
using System.Collections.Generic;

namespace Integration.Repository
{
    public interface IGenericRepository<T1, T2> where T1 : class
    {
        List<T1> GetAll();
        T1 GetOne(T2 id);
        Boolean Save(T1 newObject);
        Boolean Update(T1 editedObject);
        Boolean Delete(T2 id);
    }
}