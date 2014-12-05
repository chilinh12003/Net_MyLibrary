<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebTest._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <input type="text" runat="server" id="tbx_Text" />
        <input type="text" runat="server" id="tbx_2" />
        
        <asp:Button runat="server" ID="btn_Button" OnClick="btn_Button_Click" Text="Click" />
        <asp:Button runat="server" ID="btn_Button_2" OnClick="btn_Button_2_Click" Text="Click 2" />
    </div>
    </form>
</body>
</html>
