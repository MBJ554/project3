using API.DAL.Models;
using System.Collections.Generic;

namespace API.DAL.Interfaces
{
    public interface IExerciseLineRepository : IGenericRepository<ExerciseLine>
    {
        IEnumerable<ExerciseLine> GetAllByRehabProgramId(int id);
    }
}