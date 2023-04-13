<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="create.aspx.cs" Inherits="board_.create" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div id="create">
        <label for="ex_input">제품타입</label>
        <asp:TextBox ID="site_kind" runat="server" /><br />
        <label for="ex_input">제품코드</label>
        <asp:TextBox ID="site_code" runat="server" /><br />
        <label for="ex_input">사이트명</label>
        <asp:TextBox ID="site_name" runat="server" Class="ex_input" /><br />
        <label for="ex_input">담당자&nbsp;&nbsp&nbsp</label>
        <asp:TextBox ID="site_manager" runat="server" Class="ex_input" /><br />
        <label for="ex_input">사용여부</label>
        <asp:TextBox ID="use_yn" runat="server" Class="ex_input" /><br />





        <br />
        <asp:Button ID="btn"
            Text="작성완료"
            OnClick="post"
            runat="server"
            class="w-btn w-btn-blue" />





    </div>
</asp:Content>
