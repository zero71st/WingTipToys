﻿<%@ Page Title="Welcome" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="WingTipToys._Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1><%: Title %>.</h1>
                <h2>Wingtip Toys can help you find the perfect gift.</h2>
            </hgroup>
            <p>
                We're all about transportation toys. you can order any of our toys today.
                Each toy listing has detailed information to help you choose the right toy.
            </p>
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <section class="alignment-adjust:middle">

    </section>
</asp:Content>
