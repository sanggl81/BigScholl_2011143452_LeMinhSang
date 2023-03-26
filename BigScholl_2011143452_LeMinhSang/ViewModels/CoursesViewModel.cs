using BigScholl_2011143452_LeMinhSang.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BigScholl_2011143452_LeMinhSang.ViewModels
{
    public class CoursesViewModel
    {
        public IEnumerable<Course> UpcommingCourses { get; set; }
        public bool ShowAction { get; set; }
    }
}