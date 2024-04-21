using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace User_CRUD_Operations
{
    public partial class WebForm : System.Web.UI.Page
    {
        // Define a simple user class
        public class User
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
            public bool IsEditing { get; set; } // Flag to indicate if the row is in edit mode
        }

        // Static list to store user data
        private static List<User> users = new List<User>();

        // Create operation
        protected void btnAddUser_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string email = txtEmail.Text;
            AddUser(name, email);
            BindGridView();
        }

        // Read operation
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridView();
            }
        }

        // Method to bind user data to the GridView
        private void BindGridView()
        {
            GridView1.DataSource = users;
            GridView1.DataBind();
        }

        // Update operation
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Button btnUpdate = (Button)sender;
            GridViewRow row = (GridViewRow)btnUpdate.NamingContainer;
            int id = int.Parse(row.Cells[0].Text);
            TextBox txtName = (TextBox)row.FindControl("txtName");
            TextBox txtEmail = (TextBox)row.FindControl("txtEmail");
            UpdateUser(id, txtName.Text, txtEmail.Text);
            BindGridView();
        }

        // Delete operation
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Button btnDelete = (Button)sender;
            GridViewRow row = (GridViewRow)btnDelete.NamingContainer;
            int id = int.Parse(row.Cells[0].Text);
            DeleteUser(id);
            BindGridView();
        }

        // Add user to the list
        public static void AddUser(string name, string email)
        {
            int id = users.Count + 1;
            users.Add(new User { Id = id, Name = name, Email = email });
        }

        // Update user in the list
        public static void UpdateUser(int id, string newName, string newEmail)
        {
            User user = users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                user.Name = newName;
                user.Email = newEmail;
                user.IsEditing = false; // Set editing flag to false after update
            }
        }

        // Delete user from the list
        public static void DeleteUser(int id)
        {
            User user = users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                users.Remove(user);
            }
        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Button btnEdit = (Button)sender;
            GridViewRow row = (GridViewRow)btnEdit.NamingContainer;
            int id = int.Parse(row.Cells[0].Text);
            // Find the user from the static list by ID
            User user = users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                // Set IsEditing flag to true for the corresponding user
                user.IsEditing = true;
                // Rebind the GridView to reflect changes
                BindGridView();
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Button btnCancel = (Button)sender;
            GridViewRow row = (GridViewRow)btnCancel.NamingContainer;
            int id = int.Parse(row.Cells[0].Text);
            // Set IsEditing flag to false for the corresponding user
            User_CRUD_Operations.WebForm.User user = (User_CRUD_Operations.WebForm.User)row.DataItem;
            user.IsEditing = false;
            // Rebind the GridView to reflect changes
            BindGridView();
        }


    }


}
