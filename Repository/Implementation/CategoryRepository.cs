﻿using CodePulseAPI.Data;
using CodePulseAPI.Models.Domain;
using CodePulseAPI.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CodePulseAPI.Repository.Implementation
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbConetext _dbContext;

        public CategoryRepository(ApplicationDbConetext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Category> CreateAsync(Category category)
        {
            await _dbContext.Categories.AddAsync(category);
            await _dbContext.SaveChangesAsync();
            return category;
        }
   
        public async Task<IEnumerable<Category>> GetAllAsync()
        {
           return await _dbContext.Categories.ToListAsync();
        }

        public async Task<Category?> GetById(Guid id)
        {
            return await _dbContext.Categories.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Category?> UpdateAsync(Category category)
        {
            var existingCategory =  await _dbContext.Categories.FirstOrDefaultAsync(x => x.Id == category.Id);
            if (existingCategory != null) 
            {
                _dbContext.Entry(existingCategory).CurrentValues.SetValues(category);
                await _dbContext.SaveChangesAsync();
                return category;
            }
            return null;
        }

        public async Task<Category?> DeleteAsync(Guid id)
        {
            var existingCategory = await _dbContext.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if (existingCategory is null)
            {
                return null;
            }
            _dbContext.Categories.Remove(existingCategory);
            await _dbContext.SaveChangesAsync();
            return existingCategory;
        }

    }
}
