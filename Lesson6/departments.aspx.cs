using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Lesson6.Models;
using System.Web.ModelBinding;

namespace Lesson6
{
    public partial class departments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getDepartments();
            }
        }
        protected void getDepartments()
        {
            using (GetWreckedEntities db = new GetWreckedEntities())
            {
                //query the students table using entity
                var Departments = from s in db.Departments
                               select s;

                grdDepartments.DataSource = Departments.ToList();
                grdDepartments.DataBind();
            }
        }

        protected void grdDepartments_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //Store which row was clicked
            Int32 selectedRow = e.RowIndex;

            //get the selected sudent ID using the grids data key collection
            Int32 DepartmentID = Convert.ToInt32(grdDepartments.DataKeys[selectedRow].Values["DepartmentID"]);

            //use entity to find the object and remove it
            using(GetWreckedEntities db = new GetWreckedEntities())
            {
                Department d = (from objs in db.Departments where objs.DepartmentID == DepartmentID select objs).FirstOrDefault();

                //now we need to do the delete
                db.Departments.Remove(d);
                db.SaveChanges();
            }
            //refresh the grid
            getDepartments();
        }

       

       
    }
}