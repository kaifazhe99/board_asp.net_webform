<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="detail02.aspx.cs" Inherits="board_.detail02" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div id="detail">
        <div id="btn">
            <asp:Button OnClick="delete" runat="server" Text="삭제하기" class="w-btn w-btn-blue" />
            <asp:Button OnClick="update" runat="server" Text="수정하기" class="w-btn w-btn-blue" />
            <asp:Button OnClick="home" runat="server" Text="HOME" class="w-btn w-btn-blue" />
        </div>
        <asp:Literal ID="litTable" runat="server" />

    </div>

</asp:Content>

