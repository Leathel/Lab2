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
    public partial class Student1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // if save wasnt clicked and we have a student ID in the URL
            if(!IsPostBack && Request.QueryString.Count >0)
            {
                GetStudent();
            }
        }

        protected void GetStudent()
        {
            //populate form for edit
            //get the ID
            Int32 StudentID = Convert.ToInt32(Request.QueryString["StudentID"]);
            //connec tot he db using Entity
            using(GetWreckedEntities db = new GetWreckedEntities())
            {
                //populate from a student instance with the student ID from the URL params
                Student s = (from objs in db.Students where objs.StudentID == StudentID select objs).FirstOrDefault();

                //mpa the student properties from the form controls
                
                txtLastName.Text = s.LastName;
                txtFirstName.Text = s.FirstMidName;
                txtEnrollDate.Text = s.EnrollmentDate.ToShortDateString();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            using (GetWreckedEntities db = new GetWreckedEntities())
            {
                Student s = new Student();
                Int32 StudentID = 0;
                if (Request.QueryString.Count > 0)
                {
                    StudentID = Convert.ToInt32(Request.QueryString["StudentID"]);
                    //get the student from the entity ;D

                }
                s.LastName = txtLastName.Text;
                s.FirstMidName = txtFirstName.Text;
                s.EnrollmentDate = Convert.ToDateTime(txtEnrollDate.Text);

                if(StudentID ==0)
                {
                    db.Students.Add(s);
                }
                
                db.SaveChanges();
            }
        }
    }
}