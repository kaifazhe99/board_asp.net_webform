<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="update01.aspx.cs" Inherits="board_.update01" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div id="update">
        <label for="ex_input">제품타입</label>
        <asp:TextBox ID="site_kind" runat="server" /><br />
        <label for="ex_input">제품코드</label>
        <asp:TextBox ID="site_code" runat="server" /><br />
        <label for="ex_input">사이트명</label>
        <asp:TextBox ID="site_name" runat="server" Class="ex_input" /><br />
        <label for="ex_input">사용여부</label>
        <asp:TextBox ID="use_yn" runat="server" Class="ex_input" /><br />
        <br />





        <asp:Button ID="btn"
            Text="수정완료"
            OnClick="updateData"
            runat="server"
            class="w-btn w-btn-blue" />




    </div>
</asp:Content>
