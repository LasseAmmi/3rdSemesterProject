﻿using System.Reflection;

namespace _3rdSemesterProject.WebAPI.DAL.DTO;

public class RouteDTO
{
    public int PK_routeID { get; set; }
    public string Description { get; set; }
    public int Duration { get; set; }
    public string Title { get; set; }

}