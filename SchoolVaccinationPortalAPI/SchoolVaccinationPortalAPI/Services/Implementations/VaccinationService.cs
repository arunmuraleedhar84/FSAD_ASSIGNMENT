using Microsoft.EntityFrameworkCore;
using SchoolVaccinationPortalAPI.Data;
using SchoolVaccinationPortalAPI.DTOs.Vaccination;
using SchoolVaccinationPortalAPI.Models;
using SchoolVaccinationPortalAPI.Services.Interfaces;

namespace SchoolVaccinationPortalAPI.Services.Implementations
{
    public class VaccinationService : IVaccinationService
    {


            private readonly ApplicationDbContext _context;

            public VaccinationService(ApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<VaccinationRecord>> GetAllVaccinationsAsync()
            {
                return await _context.VaccinationRecords.ToListAsync();
            }

            public async Task<VaccinationRecord> MarkStudentVaccinatedAsync(VaccinationRecordDto vaccinationRecordDto)
            {
                // Validate: Student and Drive must exist
                var student = await _context.Students.FindAsync(vaccinationRecordDto.StudentId);
                if (student == null) throw new Exception("Student not found.");

                var drive = await _context.VaccinationDrives.FindAsync(vaccinationRecordDto.DriveId);
                if (drive == null) throw new Exception("Vaccination drive not found.");

                // Validation: Prevent duplicate vaccination for the same vaccine
                var duplicate = await _context.VaccinationRecords
                    .AnyAsync(v => v.StudentId == vaccinationRecordDto.StudentId && v.DriveId == vaccinationRecordDto.DriveId);

                if (duplicate)
                {
                    throw new Exception("Student is already vaccinated for this drive.");
                }

                // Create new Vaccination Record
                var record = new VaccinationRecord
                {
                    StudentId = vaccinationRecordDto.StudentId,
                    DriveId = vaccinationRecordDto.DriveId,
                    VaccinationDate = vaccinationRecordDto.DateOfVaccination,
                    Vaccinated= true
                };

                _context.VaccinationRecords.Add(record);

              
               

                await _context.SaveChangesAsync();
                return record;
            }


        }
    }
