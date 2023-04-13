<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="update02.aspx.cs" Inherits="board_.update02" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div id="update">
        <asp:TextBox ID="user_name" runat="server" />
        <label for="ex_input">이름</label><br />
        <asp:TextBox ID="user_pw" runat="server" />
        <label for="ex_input">비밀번호</label><br />
        <asp:TextBox ID="user_email" runat="server" Class="ex_input" />
        <label for="ex_input">이메일</label><br />
        <asp:TextBox ID="user_phone" runat="server" Class="ex_input" />
        <label for="ex_input">전화번호</label><br />





        <asp:Button ID="btn"
            Text="수정완료"
            OnClick="updateData"
            runat="server"
            class="w-btn w-btn-blue" />
    </div>
</asp:Content>
