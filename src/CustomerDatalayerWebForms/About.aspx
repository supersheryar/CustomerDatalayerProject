﻿<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="CustomerDatalayerWebForms.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Your1 application description page.</h3>
    <p>Use this area to provide additional information.</p>
    <asp:Label ID="labelElement" runat="server"></asp:Label>
    <asp:Button Text="Click" runat="server" OnClick="OnClick"/>
</asp:Content>
