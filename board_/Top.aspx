<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Top.aspx.cs" Inherits="board_.iframe" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
      <style>
        #content {
        border:none;
        width: 100%;
        height: 1000px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
             <iframe id="content" name="content"  src="/"> </iframe>
        </div>
    </form>
</body>
</html>
