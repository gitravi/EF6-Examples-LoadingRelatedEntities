﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF6LoadingRelatedEntitiesDemo.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
