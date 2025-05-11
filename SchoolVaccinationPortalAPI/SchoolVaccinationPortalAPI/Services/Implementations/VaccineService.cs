using Microsoft.EntityFrameworkCore;
using SchoolVaccinationPortalAPI.Data;
using SchoolVaccinationPortalAPI.DTOs.Drive;
using SchoolVaccinationPortalAPI.Models;
using SchoolVaccinationPortalAPI.Services.Interfaces;
using System;

namespace SchoolVaccinationPortalAPI.Services.Implementations
{
    public class VaccineService : IVaccineService
    {
        private readonly ApplicationDbContext _context;

        public VaccineService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Vaccines>> GetAllVaccinesAsync()
        {
            return await _context.Vaccines.OrderBy(v => v.Name).ToListAsync();
        }

        public async Task<Vaccines> CreateVaccineAsync(VaccineDto dto)
        {
            var vaccine = new Vaccines
            {
                Name = dto.Name,
                Manufacturer = dto.Manufacturer
            };
            _context.Vaccines.Add(vaccine);
            await _context.SaveChangesAsync();
            return vaccine;
        }
    }
}
