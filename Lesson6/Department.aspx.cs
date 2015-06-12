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
    public partial class Department1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // if save wasnt clicked and we have a student ID in the URL
            if(!IsPostBack && Request.QueryString.Count >0)
            {
                GetDepartment();
            }
        }

        protected void GetDepartment()
        {
            //populate form for edit
            //get the ID
            Int32 DepartmentID = Convert.ToInt32(Request.QueryString["DepartmentID"]);
            //connec tot he db using Entity
            using(GetWreckedEntities db = new GetWreckedEntities())
            {
                //populate from a student instance with the student ID from the URL params
                Department s = (from objs in db.Departments where objs.DepartmentID == DepartmentID select objs).FirstOrDefault();

                //mpa the student properties from the form controls

                txtDepartment.Text = s.Name;
                txtBudget.Text = Convert.ToDecimal(s.Budget).ToString();
                
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            using (GetWreckedEntities db = new GetWreckedEntities())
            {
                Department d = new Department();

                Int32 DepartmentID = 0;
                if (Request.QueryString.Count > 0)
                {

                    DepartmentID = Convert.ToInt32(Request.QueryString["DepartmentID"]);
                    d = (from objs in db.Departments where objs.DepartmentID == DepartmentID select objs).FirstOrDefault();
                    //get the student from the entity ;D

                }
                d.Name = txtDepartment.Text;
                d.Budget = Convert.ToDecimal(txtBudget.Text);
                

                if(DepartmentID ==0)
                {
                    db.Departments.Add(d);
                }
                
                db.SaveChanges();
                Response.Redirect("departments.aspx");
            }
        }
    }
}