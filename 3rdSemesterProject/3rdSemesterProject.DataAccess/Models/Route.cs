﻿using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3rdSemesterProject.DataAccess.Models;

public class Route
{
    public int RouteID { get; set; } 
    public string Description { get; set; }
    public int Duration { get; set; }
    public string Title { get; set; }
}
