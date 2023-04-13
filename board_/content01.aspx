<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="content01.aspx.cs" Inherits="board_.content01" %>







<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div id="content01">

 

        <div class="main-content">
            <div id="top">
                <label>타입</label>
                <asp:DropDownList ID="DropDownList1"
                    runat="server" AutoPostBack="true" OnSelectedIndexChanged="typeSort">
                    <asp:ListItem Value="전체">전체</asp:ListItem>
                    <asp:ListItem Value="EMS">EMS</asp:ListItem>
                    <asp:ListItem Value="PMS">PMS</asp:ListItem>
                    <asp:ListItem Value="HMI">HMI</asp:ListItem>
                    <asp:ListItem Value="PVHMI">PVHMI</asp:ListItem>
                    <asp:ListItem Value="SOLAR">SOLAR</asp:ListItem>
                    <asp:ListItem Value="WPWX">WPWX</asp:ListItem>
                    <asp:ListItem Value="HMIDEX">HMIDEX</asp:ListItem>
                    <asp:ListItem Value="EVEMS">EVEMS</asp:ListItem>
                    <asp:ListItem Value="HMIFR">HMIFR</asp:ListItem>
                </asp:DropDownList>
                <label>검색조건</label>
                <asp:DropDownList ID="DropDownList2"
                    runat="server" AutoPostBack="true" OnSelectedIndexChanged="searchTypeSelect">
                    <asp:ListItem Value="통합검색">통합검색</asp:ListItem>
                    <asp:ListItem Value="사이트명">사이트명</asp:ListItem>
                    <asp:ListItem Value="제품코드">제품코드</asp:ListItem>

                </asp:DropDownList>
                <asp:TextBox ID="searchTxt" runat="server"></asp:TextBox>
                <asp:Button Text="검색"
                    runat="server" OnClick="btnSearch_Click" ID="search" />

            </div>



            <div id="content">
                <asp:GridView runat="server" ID="dataGridView1" AllowPaging="True" PageSize="16" OnPageIndexChanging="GridView1_PageIndexChanging"  OnRowDataBound="GridView1_RowDataBound">
                      <PagerSettings 
           mode="Numeric"
          position="Bottom"           
          pagebuttoncount="10"  />

                </asp:GridView>
            </div>
            <div id="bottom">
                <asp:Button OnClick="btnWrite_Click" runat="server" Text="글작성" class="w-btn w-btn-blue" />

            </div>
        </div>


    </div>
</asp:Content>
