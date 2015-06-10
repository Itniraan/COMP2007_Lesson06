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
    public partial class students : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // If loading the page for the first time, populate the student grid
                GetStudents();
            }
        }

        protected void GetStudents()
        {
            // Connect to EF
            using (comp2007Entities db = new comp2007Entities())
            {
                // Query the Students table, using the Enity Framework
                var Students = from s in db.Students
                               select s;

                // Bind the result to the gridview
                grdStudents.DataSource = Students.ToList();
                grdStudents.DataBind();
            }
        }

        protected void grdStudents_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Store which row was clicked
            Int32 selectedRow = e.RowIndex;

            // Get the selected StudentID using the grid's Data Key collection
            Int32 StudentID = Convert.ToInt32(grdStudents.DataKeys[selectedRow].Values["StudentID"]);

            // Use Enity Framework to remove the selected student from the DB
            using (comp2007Entities db = new comp2007Entities())
            {
                Student s = (from objS in db.Students
                             where objS.StudentID == StudentID
                             select objS).FirstOrDefault(); // Using First would get an error if no data comes back, FirstOrDefault won't throw an error

                // Do the delete
                db.Students.Remove(s);
                db.SaveChanges();
            }

            // Refresh the grid
            GetStudents();
        }
    }
}