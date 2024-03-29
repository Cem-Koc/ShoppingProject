﻿using ShoppingProject.Data.Context;
using ShoppingProject.Data.Repositories.Abstractions;
using ShoppingProject.Data.Repositories.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingProject.Data.UnitOfWorks
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly AppDbContext _dbContext;

		public UnitOfWork(AppDbContext dbContext)
        {
			_dbContext = dbContext;
		}
        public async ValueTask DisposeAsync()
		{
			await _dbContext.DisposeAsync();
		}

		public int Save()
		{
			return _dbContext.SaveChanges();
		}

		public async Task<int> SaveAsync()
		{
			return await _dbContext.SaveChangesAsync();
		}

		IRepository<T> IUnitOfWork.GetRepository<T>()
		{
			return new Repository<T>(_dbContext);
		}
	}
}
