using Application.Features.Companies;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Companies
{
    public class CompanyService : ICompanyService
    {
        private readonly ApplicationDbContext _context;

        public CompanyService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateAsync(Company company)
        {
            await _context.Companies.AddAsync(company);
            await _context.SaveChangesAsync();
            return company.Id;
        }

        public async Task<int> DeleteAsync(Company company)
        {
            _context.Companies.Remove(company);
            await _context.SaveChangesAsync();
            return company.Id;
        }

        public async Task<List<Company>> GetAllAsync()
        {
            return await _context.Companies.ToListAsync();
        }

        public async Task<Company> GetByIdAsync(int companyId)
        {
            return await _context.Companies
                .Where(company => company.Id == companyId)
                .FirstOrDefaultAsync();
        }

        public async Task<Company> GetByNameAsync(string name)
        {
            return await _context.Companies
                .Where(company => company.Name == name)
                .FirstOrDefaultAsync();
        }

        public async Task<int> UpdateAsync(Company company)
        {
            _context.Companies.Update(company);
            await _context.SaveChangesAsync();
            return company.Id;
        }
    }
}
