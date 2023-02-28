﻿using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepositories
{
    public interface IKeyWordRepository : IRepository<KeyWord>
    {
        KeyWord GetByWord(String word);
    }
}
