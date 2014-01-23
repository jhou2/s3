<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SearchApp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <div class="col-md-6">
            <asp:Image ID="Logo" runat="server" ImageUrl="~/Content/searchstar_.png" />
        </div>
    </div>
    
    <div class="form-group">
       
        <div class="col-md-8">
            <asp:TextBox ID="tbSearch" runat="server" OnTextChanged="tbSearch_TextChanged" class="form-control" TextMode="Search"></asp:TextBox>
        </div>
        <div class="col-md-2">
                <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Search" />
        </div>

    </div>
        
    <div class="row">
        <div class="col-md-8"></div>
            <div class="col-md-4">
        
            <asp:ImageButton ID="btnRewind" runat="server" ImageUrl="~/Content/rewind.png" OnClick="btnRewind_Click" />
        <asp:ImageButton ID="btnBack" runat="server" ImageUrl="~/Content/back.png" OnClick="btnBack_Click" />
        
            <asp:ImageButton ID="btnForward" runat="server" ImageUrl="~/Content/forward.png" OnClick="btnForward_Click" />
        <asp:ImageButton ID="btnFastForward" runat="server" ImageUrl="~/Content/fastforward.png" OnClick="btnFastForward_Click" />
        </div>
  </div>

    <div class="form-group">
            <div class="col-md-8">
       
        <asp:Label ID="lblDocumentName" runat="server" BackColor="#99CCFF" Text="Document: " Width="400px"></asp:Label>
      
                </div>
            <div class="col-md-4">
            <asp:Label ID="lblFileCount" runat="server" Text="Result 0 of 0" BorderColor="White" BorderStyle="Solid" BackColor="#99CCFF"></asp:Label>
                </div>
            </div>
    <div class="row">
        <div class="col-md-11">
           
        <asp:TextBox ID="tbFileText" runat="server" Height="400px" class="form-control" Enabled="True" TextMode="MultiLine"></asp:TextBox>
        </div>
        <div class="col-md-1">
        <asp:ImageButton ID="btnPrint" runat="server" Height="50px" ImageUrl="~/Content/printer.jpg" onClientClick="javascript:window.print();" Width="44px" />
        <asp:ImageButton ID="btnSave" runat="server" Height="48px" ImageUrl="~/Content/save.jpg" OnClick="btnSave_Click" Width="51px" />
        </div>
    </div>        
        

</asp:Content>
