﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module10.Unit4.Task4
{
    public interface IUpdater<in T>
    {
        void Update(T entity);
    }
}
