
using Microsoft.EntityFrameworkCore;
using SchoolVaccinationPortalAPI.Data;
using SchoolVaccinationPortalAPI.DTOs.Drive;
using SchoolVaccinationPortalAPI.Models;
using SchoolVaccinationPortalAPI.Services.Interfaces;
using System;

namespace SchoolVaccinationPortalAPI.Services.Implementations
{
    public class DriveService : IDriveService
    {
        private readonly ApplicationDbContext _context;

        public DriveService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<VaccinationDrive>> GetAllAsync()
        {
            return await _context.VaccinationDrives
                .Include(d => d.Vaccine)
                .Select(d => new VaccinationDrive
                {
                    Id= d.Id,
                   DriveName= d.DriveName,
                    Date = d.Date,
                    VaccineId = d.VaccineId,
                    AvailableDoses = d.AvailableDoses,
                    ApplicableClasses = d.ApplicableClasses
                })
                .ToListAsync();
        }

        public async Task<VaccinationDrive> GetByIdAsync(int id)
        {
            var entity = await _context.VaccinationDrives.FindAsync(id);
            if (entity == null) return null;

            return new VaccinationDrive
            {
                Id = entity.Id,
                DriveName = entity.DriveName,
                Date = entity.Date,
                VaccineId = entity.VaccineId,
                AvailableDoses = entity.AvailableDoses,
                ApplicableClasses = entity.ApplicableClasses
            };
        }

        public async Task<bool> CreateAsync(VaccinationDriveDto dto)
        {

            if (dto.Date.Date < DateTime.UtcNow.Date.AddDays(15))
                throw new ArgumentException("Vaccination drives must be scheduled at least 15 days in advance.");

            var exists = await _context.Vaccines.AnyAsync(v => v.Id == dto.VaccineId);
            if (!exists)
                throw new ArgumentException("Invalid VaccineId");



            var drive = new VaccinationDrive
            {
                DriveName = dto.DriveName,
                Date = dto.Date,
                VaccineId = dto.VaccineId,
                AvailableDoses = dto.AvailableDoses,
                ApplicableClasses = dto.ApplicableClasses
            };

            _context.VaccinationDrives.Add(drive);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(int id, VaccinationDriveDto dto)
        {

            if (dto.Date.Date < DateTime.UtcNow.Date.AddDays(15))
                throw new ArgumentException("Vaccination drives must be scheduled at least 15 days in advance.");


            var entity = await _context.VaccinationDrives.FindAsync(id);
            if (entity == null) return false;

            if (entity.Date < DateTime.Today)
                throw new InvalidOperationException("Cannot update a past drive.");
            entity.DriveName = dto.DriveName;
            entity.Date = dto.Date;
            entity.VaccineId = dto.VaccineId;
            entity.AvailableDoses = dto.AvailableDoses;

            entity.ApplicableClasses = dto.ApplicableClasses;

            await _context.SaveChangesAsync();
            return true;
        }

    }
}
