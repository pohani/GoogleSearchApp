﻿using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.IServices
{
    public interface ISearchService
    {
        IEnumerable<Result> Search(string word, string? filter);
    }
}
