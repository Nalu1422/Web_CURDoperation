using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web_CURDoperation
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        private static List<Employee> employees = new List<Employee>
        {
            new Employee { Id = 1, Name = "John Doe", Email = "john@example.com", Department = "IT" },
            new Employee { Id = 2, Name = "Jane Smith", Email = "jane@example.com", Department = "HR" }
        };

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridView();
            }
        }

        private void BindGridView()
        {
            GridView1.DataSource = employees;
            GridView1.DataBind();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            BindGridView();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.RowIndex];
            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
            TextBox txtName = (TextBox)row.FindControl("txtName");
            TextBox txtEmail = (TextBox)row.FindControl("txtEmail");
            TextBox txtDepartment = (TextBox)row.FindControl("txtDepartment");

            Employee employee = employees.FirstOrDefault(emp => emp.Id == id);
            if (employee != null)
            {
                employee.Name = txtName.Text;
                employee.Email = txtEmail.Text;
                employee.Department = txtDepartment.Text;
            }

            GridView1.EditIndex = -1;
            BindGridView();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
            Employee employee = employees.FirstOrDefault(emp => emp.Id == id);
            if (employee != null)
            {
                employees.Remove(employee);
            }
            BindGridView();
        }
        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            BindGridView();
        }


        protected void btnAddEmployee_Click(object sender, EventArgs e)
        {
            Employee newEmployee = new Employee
            {
                Id = employees.Count + 1,
                Name = txtNewName.Text,
                Email = txtNewEmail.Text,
                Department = txtNewDepartment.Text
            };
            employees.Add(newEmployee);
            BindGridView();
        }

        public class Employee
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
            public string Department { get; set; }
        }
    }
}
