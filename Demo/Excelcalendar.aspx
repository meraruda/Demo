<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Excelcalendar.aspx.cs" Inherits="Demo.Excelcalendar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                <asp:ListItem Value="S1" Selected="True">Style1
                </asp:ListItem>
                <asp:ListItem Value="S2">Style2
                </asp:ListItem>
                <asp:ListItem Value="S3">Style3
                </asp:ListItem>
            </asp:RadioButtonList>
            <button id="btn_Excute" type="button" class="btn btn-default btn-sm" runat="server" onserverclick="Button1_Click">
                <span class="glyphicon glyphicon-calendar"></span>匯出
            </button>
        </div>
    </form>
</body>
</html>
