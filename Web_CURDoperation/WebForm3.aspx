<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm.aspx.cs" Inherits="User_CRUD_Operations.WebForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>User Management</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Add New User</h2>
            <asp:TextBox ID="txtName" runat="server" placeholder="Enter Name"></asp:TextBox>
            <asp:TextBox ID="txtEmail" runat="server" placeholder="Enter Email"></asp:TextBox>
            <asp:Button ID="btnAddUser" runat="server" Text="Add User" OnClick="btnAddUser_Click" />
            
            <h2>List of Users</h2>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="ID" ReadOnly="true" />
                    <asp:TemplateField HeaderText="Name">
                        <ItemTemplate>
                            <asp:Label ID="lblName" runat="server" Text='<%# Eval("Name") %>' Visible='<%# !((User_CRUD_Operations.WebForm.User)Container.DataItem).IsEditing %>'></asp:Label>
                            <asp:TextBox ID="txtName" runat="server" Text='<%# Eval("Name") %>' Visible='<%# ((User_CRUD_Operations.WebForm.User)Container.DataItem).IsEditing %>'></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Email">
                        <ItemTemplate>
                            <asp:Label ID="lblEmail" runat="server" Text='<%# Eval("Email") %>' Visible='<%# !((User_CRUD_Operations.WebForm.User)Container.DataItem).IsEditing %>'></asp:Label>
                            <asp:TextBox ID="txtEmail" runat="server" Text='<%# Eval("Email") %>' Visible='<%# ((User_CRUD_Operations.WebForm.User)Container.DataItem).IsEditing %>'></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Actions">
                        <ItemTemplate>
                            <asp:Button ID="btnEdit" runat="server" Text="Edit" CommandName="Edit" OnClick="btnEdit_Click" Visible='<%# !((User_CRUD_Operations.WebForm.User)Container.DataItem).IsEditing %>' />
                            <asp:Button ID="btnUpdate" runat="server" Text="Update" CommandName="Update" OnClick="btnUpdate_Click" Visible='<%# ((User_CRUD_Operations.WebForm.User)Container.DataItem).IsEditing %>' />
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CommandName="Cancel" OnClick="btnCancel_Click" Visible='<%# ((User_CRUD_Operations.WebForm.User)Container.DataItem).IsEditing %>' />
                            <asp:Button ID="btnDelete" runat="server" Text="Delete" CommandName="Delete" OnClick="btnDelete_Click" Visible='<%# !((User_CRUD_Operations.WebForm.User)Container.DataItem).IsEditing %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
