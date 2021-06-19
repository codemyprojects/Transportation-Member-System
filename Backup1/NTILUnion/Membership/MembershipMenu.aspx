<%@ Page Title="" Language="C#" MasterPageFile="~/NTILU.Master" AutoEventWireup="true"
    CodeBehind="MembershipMenu.aspx.cs" Inherits="NTILUnion.Membership.MembershipMenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="page-content">
        <div class="modal fade" id="portlet-config" tabindex="-1" role="dialog" aria-labelledby="myModalLabel"
            aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                        </button>
                        <h4 class="modal-title">
                            Modal title</h4>
                    </div>
                    <div class="modal-body">
                        Widget settings form goes here
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn blue">
                            Save changes</button>
                        <button type="button" class="btn default" data-dismiss="modal">
                            Close</button>
                    </div>
                </div>
            </div>
        </div>
        <div class="theme-panel hidden-xs hidden-sm">
            <div class="toggler">
            </div>
            <div class="toggler-close">
            </div>
            <div class="theme-options">
                <div class="theme-option theme-colors clearfix">
                    <span>THEME COLOR</span>
                    <ul>
                        <li class="color-black current color-default" data-style="default"></li>
                        <li class="color-blue" data-style="blue"></li>
                        <li class="color-brown" data-style="brown"></li>
                        <li class="color-purple" data-style="purple"></li>
                        <li class="color-grey" data-style="grey"></li>
                        <li class="color-white color-light" data-style="light"></li>
                    </ul>
                </div>
                <div class="theme-option">
                    <span>Layout</span>
                    <select class="layout-option form-control input-small">
                        <option value="fluid" selected="selected">Fluid</option>
                        <option value="boxed">Boxed</option>
                    </select>
                </div>
                <div class="theme-option">
                    <span>Header</span>
                    <select class="header-option form-control input-small">
                        <option value="fixed" selected="selected">Fixed</option>
                        <option value="default">Default</option>
                    </select>
                </div>
                <div class="theme-option">
                    <span>Sidebar</span>
                    <select class="sidebar-option form-control input-small">
                        <option value="fixed">Fixed</option>
                        <option value="default" selected="selected">Default</option>
                    </select>
                </div>
                <div class="theme-option">
                    <span>Footer</span>
                    <select class="footer-option form-control input-small">
                        <option value="fixed">Fixed</option>
                        <option value="default" selected="selected">Default</option>
                    </select>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <h3 class="page-title">
                    Dashboard <small>Gridview Display of Menus.</small>
                </h3>
                <ul class="page-breadcrumb breadcrumb">
                    <li class="btn-group">
                        <button type="button" class="btn blue dropdown-toggle" data-toggle="dropdown" data-hover="dropdown"
                            data-delay="1000" data-close-others="true">
                            <span>Reports</span> <i class="fa fa-angle-down"></i>
                        </button>
                        <ul class="dropdown-menu pull-right" role="menu">
                            <li><a href="#">HR</a></li>
                            <li><a href="#">Settings</a></li>
                            <li><a href="#">Advanced Reports</a></li>
                        </ul>
                    </li>
                    <li><i class="fa fa-home"></i><a href="/default.aspx">Home</a> <i class="fa fa-angle-right">
                    </i></li>
                    <li><a href="MembershipMenu.aspx">Membership Menu </a><i class="fa fa-angle-right"></i>
                    </li>
                    <li>
                        <%--<i class="fa fa-gear"></i>
                        <a href="/Membership/MembershipMenu.aspx">Management</a>
                        <i class="fa fa-angle-right"></i>
                        </li>--%>
                </ul>
            </div>
        </div>
        <div class="dashboard_head_menu">
            <div class="col-lg-3 col-md-4 col-sm-4 col-xs-6">
                <div class="menu_caption">
                    <span class="menu_icon fa fa-male"></span><span class="menu_info"><a href="/Membership/Membership.aspx">
                        New Membership</a> <i>To New Membership!</i> </span>
                </div>
            </div>
            <div class="col-lg-3 col-md-4 col-sm-4 col-xs-6">
                <div class="menu_caption">
                    <span class="menu_icon fa fa-search-plus"></span><span class="menu_info"><a href="Search.aspx">
                        Search Members</a> </span>
                </div>
            </div>
            <div class="col-lg-3 col-md-4 col-sm-4 col-xs-6">
                <div class="menu_caption">
                    <span class="menu_icon fa fa-refresh "></span><span class="menu_info"><a href="RenewMembership.aspx">
                       
                        Renew Membership</a> <i>For Renew Membership!</i> </span>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
