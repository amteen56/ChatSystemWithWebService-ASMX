<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Chat.aspx.cs" Inherits="ChatWebApp.Chat" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Page 1</title>
    <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
    <div class="col-md-6">
        <div class="box box-primary">
            <div class="box-header">
                <h3 class="box-title">Online Chat</h3>
            </div>

            <div class="box-body">
               <div runat="server" id="maindatadiv"></div>
        <br />

                <asp:Label runat="server" Text="Name"></asp:Label>
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                   <asp:Label runat="server" Text="Message"></asp:Label>
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            </div>

        </div>
        <br />
        <asp:Button  ID="Button1" CssClass="btn btn-success" width="100%" runat="server" Text="Send" OnClick="Button1_Click" />

    </div>
</div>
    </form>
</body>
</html>
