﻿using API.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.DAL.Interfaces
{
    public interface IExerciseLineRepository : IGenericRepository<ExerciseLine>
    {
        IEnumerable<ExerciseLine> GetAllByRehabProgramId(int id);
    }
}
