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
    public partial class departments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // If loading the page for the first time, populate the department grid
                GetDepartments();
            }
        }

        protected void GetDepartments()
        {
            // Connect to EF
            using (comp2007Entities db = new comp2007Entities())
            {
                // Query the Departments table, using the Enity Framework
                var Departments = from d in db.Departments
                               select d;

                // Bind the result to the gridview
                grdDepartments.DataSource = Departments.ToList();
                grdDepartments.DataBind();
            }
        }

        protected void grdDepartments_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Store which row was clicked
            Int32 selectedRow = e.RowIndex;

            // Get the selected StudentID using the grid's Data Key collection
            Int32 DepartmentID = Convert.ToInt32(grdDepartments.DataKeys[selectedRow].Values["DepartmentID"]);

            // Use Enity Framework to remove the selected student from the DB
            using (comp2007Entities db = new comp2007Entities())
            {
                Department d = (from objS in db.Departments
                             where objS.DepartmentID == DepartmentID
                             select objS).FirstOrDefault(); // Using First would get an error if no data comes back, FirstOrDefault won't throw an error

                // Do the delete
                db.Departments.Remove(d);
                db.SaveChanges();
            }

            // Refresh the grid
            GetDepartments();
        }
    }
}