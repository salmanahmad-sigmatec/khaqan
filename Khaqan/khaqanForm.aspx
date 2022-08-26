<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="khaqanForm.aspx.cs" Inherits="Khaqan.khaqanForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            username
            <asp:TextBox ID="username" runat="server"></asp:TextBox>
        </div>

        <div>
            password
            <asp:TextBox ID="password" runat="server"></asp:TextBox>
            
        </div>
        <asp:Button ID="register" runat="server" Text="Register" Width="126px" OnClick="RegisterUser" />
        <asp:Button ID="login" runat="server" Text="Login" Width="138px" OnClick="LoginUser" />


    </form>
</body>
</html>
