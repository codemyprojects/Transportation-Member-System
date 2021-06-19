<%@ Page Title="" Language="C#" MasterPageFile="~/NTILU.Master" AutoEventWireup="true"
    CodeBehind="MemberVerification.aspx.cs" Inherits="NTILUnion.Membership.MemberVerification" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
   <script type="text/javascript">

       var checkFromValidation = false;

       $(document).ready(function () {
           $('#form').validate();
           $("#<%=txtDateFrom.ClientID %>").rules('add', { required: true, messages: { required: 'DateFrom is required.'} });
           $("#<%=txt_dateTo.ClientID %>").rules('add', { required: true, messages: { required: 'DateTo is required.'} });
           checkFromValidation = function () {

               var bool = true;
               if ($('#<%=txtDateFrom.ClientID %>').valid() == false) bool = false;
               if ($('#<%=txt_dateTo.ClientID %>').valid() == false) bool = false;
               if (!bool) $('#form').validate().focusInvalid();
               return bool;
           }

       });

    </script>
   
   <script type="text/javascript">
       $(document).ready(function () {
           $("#<%=txtDateFrom.ClientID %>").datepicker({ dateFormat: "yy-mm-dd", yearRange: '1970:2040', changeMonth: true, changeYear: true }).val(), new Date()
           $("#<%=txt_dateTo.ClientID %>").datepicker({ dateFormat: "yy-mm-dd", yearRange: '1970:2040', changeMonth: true, changeYear: true }).val(), new Date()

       });
    </script>
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
                    Membership Verification <small>Member records are submitted by members to procced membmership
                        process.</small>
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
                    <li><i class="fa fa-home"></i><a href="/Default.aspx">Home</a> <%--<i class="fa fa-angle-right">
                    </i><a href="MembershipMenu.aspx">Membership Menu</a>--%> <i class="fa fa-angle-right"></i>
                    </li>
                    <li><i class=""></i><a href="/Membership/MemberVerification.aspx">Verification</a> </li>
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
                            <i class="fa fa-cogs"></i>Membership Verification</div>
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
                                        <label class="col-md-1 control-label">
                                           From :</label>
                                        <div class="col-md-4">
                                            <div class="input-group">
                                                <span class="input-group-addon"><i class="fa fa-calendar"></i></span>
                                                <asp:TextBox ID="txtDateFrom" runat="server" CssClass="form-control" placeholder="Enter Date From" >
                                                 </asp:TextBox>
                                                   <label for="<%= txtDateFrom.ClientID%>" class="error"  style="display:none" ></label>
                                            </div>
                                        </div>
                                        <label class="col-md-1 control-label">
                                            To : </label>
                                        <div class="col-md-4">
                                            <div class="input-group">
                                                <span class="input-group-addon"><i class="fa fa-calendar"></i></span>
                                                <asp:TextBox ID="txt_dateTo" placeholder="Enter Date To" runat="server"
                                                    CssClass="form-control">
                                                </asp:TextBox>
                                                  <label for="<%= txt_dateTo.ClientID%>" class="error"  style="display:none" ></label>
                                            </div>
                                        </div>
                                        <div class="col-md-2">
                                            <asp:Button ID="btnSearch" CssClass="btn btn-primary" runat="server" 
                                                Text="Search" onclick="btnSearch_Click"/>                                      
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
</asp:Content>
