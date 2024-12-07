using ActCourse.Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace ActCourse.Backend.Data
{
    public class InstructorData : IInstructor
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public InstructorData(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task<Instructor> Add(Instructor entity)
        {
            try
            {
                _applicationDbContext.Add(entity);
                await _applicationDbContext.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"{ex.Message}");
            }
        }

        public async Task<Instructor> Delete(int id)
        {
            var result = await GetById(id);
            if (result == null)
            {
                throw new ArgumentException("Instructor not found");
            }
            try
            {
                _applicationDbContext.Remove(result);
                await _applicationDbContext.SaveChangesAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"{ex.Message}");
            }
        }

        public async Task<IEnumerable<Instructor>> GetAll()
        {
            return await _applicationDbContext.Instructors.ToListAsync();
        }

        public async Task<Instructor> GetById(int id)
        {
            var result = await _applicationDbContext.Instructors.FirstOrDefaultAsync(x => x.InstructorId == id);
            if (result == null)
            {
                throw new ArgumentException("Instructor not found");
            }
            return result;
        }

        public async Task<Instructor> Update(Instructor entity)
        {
            try
            {
                _applicationDbContext.Update(entity);
                await _applicationDbContext.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"{ex.Message}");
            }
        }
    }
}
