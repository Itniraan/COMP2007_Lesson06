using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// Reference the EF Models
using COMP2007_Lesson06.Models;
using System.Web.ModelBinding;

namespace COMP2007_Lesson06
{
    public partial class editStudent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            // Use EF to connect to SQL Server
            using (comp2007Entities db = new comp2007Entities())
            {
                // Use the Student Model to save the new record
                Student s = new Student();

                s.LastName = txtLastName.Text;
                s.FirstMidName = txtFirstName.Text;
                s.EnrollmentDate = Convert.ToDateTime(txtEnrollmentDate.Text);

                db.Students.Add(s);
                db.SaveChanges();

                // Redirect to the updated students page
                Response.Redirect("students.aspx");
            }
        }
    }
}