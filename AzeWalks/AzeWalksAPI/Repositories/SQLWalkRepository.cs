﻿using AzeWalksAPI.Data;
using AzeWalksAPI.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace AzeWalksAPI.Repositories
{
    public class SQLWalkRepository : IWalkRepository
    {
        private readonly AzeWalksDbContext dbContext;

        public SQLWalkRepository(AzeWalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Walk> CreateAsync(Walk walk)
        {
            await dbContext.Walks.AddAsync(walk);
            await dbContext.SaveChangesAsync();
            return walk;
        }

        public async Task<List<Walk>> GetAllAsync()
        {
            return await dbContext.Walks.ToListAsync();
        }
    }
}
