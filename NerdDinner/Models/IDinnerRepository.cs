﻿using NerdDinner.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NerdDinner.Models
{
    public interface IDinnerRepository
    {
        void Add(Dinner dinner);
        IQueryable<Dinner> FindAllDinners();
        Dinner GetDinner(int id);
        void Update(Dinner dinner);
        void Delete(Dinner dinner);
    }
}