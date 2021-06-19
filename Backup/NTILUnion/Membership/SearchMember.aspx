<%@ Page Language="C#" MasterPageFile="~/NTILU.Master" AutoEventWireup="true" CodeBehind="SearchMember.aspx.cs" Inherits="NTILUnion.Membership.SearchMember" %>


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
                    Member List <small>List of Active member</small>
                </h3>
                <ul class="page-breadcrumb breadcrumb">
                    <li class="btn-group">
                        <button type="button" class="btn blue dropdown-toggle" data-toggle="dropdown" data-hover="dropdown"
                            data-delay="1000" data-close-others="true">
                            <span>Actions</span> <i class="fa fa-angle-down"></i>
                        </button>
                        <ul class="dropdown-menu pull-right" role="menu">
                            <li><a href="#">Action</a></li>
                            <li><a href="#">Another action</a></li>
                            <li><a href="#">Something else here</a></li>
                            <li class="divider"></li>
                            <li><a href="#">Separated link</a></li>
                            <li id="exportToExcel"><a href="#">Export To Excel</a></li>
                        </ul>
                    </li>
                    <li><i class="fa fa-home"></i><a href="/Default.aspx">Home</a> <i class="fa fa-angle-right">
                    </i><a href="MembershipMenu.aspx">Membership Menu</a> <i class="fa fa-angle-right"></i>
                    </li>
                     <li><i class=""></i><a href="Search.aspx">Search</a> </li>
                    
                </ul>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <div id="message" runat="server">
                </div>
                <div class="portlet box purple">
                    <div class="portlet-title">
                        <div class="caption">
                            <i class="fa fa-cogs"></i>Search</div>
                        <div class="tools">
                            <a href="javascript:;" class="collapse"></a><a href="#portlet-config" data-toggle="modal"
                                class="config"></a><a href="javascript:;" class="reload"></a><a href="javascript:;"
                                    class="remove"></a>
                        </div>
                    </div>
                    <div class="portlet-body form">
                        <div class="form-horizontal">
                            <div class="form-body">
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <label class="col-md-2 control-label">
                                            Search By:</label>
                                        <div class="col-md-4">
                                            <div class="input-group">
                                                <span class="input-group-addon"><i class="fa fa-list-ul"></i></span>
                                                <asp:DropDownList ID="dropSearchType" runat="server" CssClass="form-control">
                                                    <asp:ListItem Value="">Select Choice To Search Member</asp:ListItem>
                                                    <asp:ListItem Value="Name">Name</asp:ListItem>
                                                    <asp:ListItem Value="CitizenShipNo">Citizenship Number</asp:ListItem>
                                                    <asp:ListItem Value="FatherName">FatherName</asp:ListItem>
                                                    <asp:ListItem Value="Mobile">Mobile Number</asp:ListItem>
                                                    <asp:ListItem Value="District">District</asp:ListItem>
                                                    <asp:ListItem Value="MemberType">MemberType</asp:ListItem>
                                                    <asp:ListItem Value="Zone">Zone</asp:ListItem>
                                                    <asp:ListItem Value="Gender">Gender</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <label class="col-md-2 control-label">
                                            Search Text:</label>
                                        <div class="col-md-3">
                                            <div class="input-group">
                                                <span class="input-group-addon"><i class="fa fa-search-plus"></i></span>
                                                <asp:TextBox ID="txtSearchText" placeholder="Enter a text to search Member" runat="server"
                                                    CssClass="form-control">
                                                </asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-1">
                                            <asp:Button ID="btnSearch" CssClass="btn btn-primary" runat="server" 
                                                Text="Search" onclick="btnSearch_Click" />

                                           <%-- <asp:Button ID="btnToExcel" runat="server" Text="To Excel" 
                                                onclick="btnToExcel_Click" />--%>
                                            

                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div id="listData" runat="server">
        </div>
    </div>

    <%--<script type="text/javascript">
        $('#<%= btnToExcel.ClientID %>').hide();
        $(document).ready(function () {
            $('#exportToExcel').click(function () {
                $('#<%= btnToExcel.ClientID %>').click();
            });
        });
    </script>--%>
</asp:Content>
