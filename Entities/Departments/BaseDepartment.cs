﻿using System.ComponentModel.DataAnnotations;

namespace Entities.Departments
{
    public abstract class BaseDepartment
    {
        public int Id { get; set; }
        public int Employees { get; set; }
    }
}
