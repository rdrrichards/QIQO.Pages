﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QIQO.Pages.Data.Interfaces
{
    public interface IRepository { }

    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIDAsync(Guid Id);
        void Insert(T entity);
        void Delete(Guid Id);
        void Update(T entity);
        void Save();
    }
}