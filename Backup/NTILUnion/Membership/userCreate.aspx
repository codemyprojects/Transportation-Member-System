<%@ Page Language="C#" MasterPageFile="~/NTILU.Master" AutoEventWireup="true" CodeBehind="userCreate.aspx.cs" Inherits="NTILUnion.Membership.userCreate" %>



<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">

        var checkFromValidation = false;

        $(document).ready(function () {


            $('#form').validate();


            $("#<%=txtUserName.ClientID %>").rules('add', { required: true, messages: { required: 'User Name is required.'} });
            $("#<%=txtAddress.ClientID %>").rules('add', { required: true, messages: { required: 'User Address is required.'} });
            $("#<%=txtMobile.ClientID %>").rules('add', { required: true, number: true, text: false, maxlength: 10, messages: { required: 'Mobile Number is required.'} });
            checkFromValidation = function () {

                var bool = true;


                if ($('#<%=txtUserName.ClientID %>').valid() == false) bool = false;
                if ($('#<%=txtAddress.ClientID %>').valid() == false) bool = false;
                if ($('#<%=txtMobile.ClientID %>').valid() == false) bool = false;
               
                if (!bool) $('#form').validate().focusInvalid();
                return bool;
            }

        });

    </script>
   <%-- <script type="text/javascript">

        $(document).ready(function () {
            $("#<%=txtCreatedDate.ClientID %>").datepicker({ dateFormat: "yy-mm-dd", yearRange: '1970:2040', changeMonth: true, changeYear: true }).datepicker("setDate", new Date());
            
            Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(function (evt, args) {
                $("#<%=txtCreatedDate.ClientID %>").datepicker({ dateFormat: "yy-mm-dd", yearRange: '1970:2040', changeMonth: true, changeYear: true }).val(), new Date()
            
            
            });

        });
    </script>--%>
    <%--    <script>
        $(function () {
            var scntDiv = $('#FileUploaders');
            var i = $('#FileUploaders p').size() + 1;
            $('#FileUploaders').live('click', function () {
                $('<input type="file' + 1 + '" id="FileUploader1" name ="FileUploader1' + 1 + '" /></label> <a href ="#" id="removeUploader">')
                i++;
                return false;

            });


            $('#removeUploader').live('click', function () {

                if (i > 2) {
                    $(this).parents('p').remove();
                    i--;

                }
                return false;
            });
        });
    
    
    </script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
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
                        Widget settings form goes here</div>
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
                    Membership</h3>
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
                        </ul>
                    </li>
                    <li><i class="fa fa-home"></i><a href="/Default.aspx">Home</a> <i class="fa fa-angle-right">
                    </i><a href="MembershipMenu.aspx">Membership Menu</a> <i class="fa fa-angle-right"></i>
                    </li>
                    <li><a href="#">New User</a></li>
                </ul>
            </div>
        </div>
        <div class="row">
        </div>
        <div class="row">
            <div class="col-md-12 ">
                <div id="message" runat="server">
                </div>
                <div class="portlet box green ">
                    <div class="portlet-title">
                        <div class="caption">
                            <i class="fa fa-user"></i>Create User
                        </div>
                        <div class="tools">
                            <a href="" class="collapse"></a><a href="#portlet-config" data-toggle="modal" class="config">
                            </a><a href="" class="reload"></a><a href="" class="remove"></a>
                        </div>
                    </div>
                    <div class="portlet-body form">
                        <div class="form-horizontal">
                            <div class="form-body">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <div class="form-group">
                                            <label class="col-md-3 control-label">
                                                User Name :</label>
                                            <div class="col-md-9">
                                                <div class="input-group">
                                                    <span class="input-group-addon"><i class="fa fa-user"></i></span>
                                                    <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control" placeholder="Enter Applicant User Name"></asp:TextBox>
                                                </div>
                                                <label for="<%= txtUserName.ClientID%>" class="error" style="display: none">
                                                </label>
                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <label class="col-md-3 control-label">
                                                Password :</label>
                                            <div class="col-md-9">
                                                <div class="input-group">
                                                    <span class="input-group-addon"><i class="fa fa-user"></i></span>
                                                    <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" placeholder="Enter Password"></asp:TextBox>
                                                </div>
                                                <label for="<%= txtPassword.ClientID%>" class="error" style="display: none">
                                                </label>
                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <label class="col-md-3 control-label">
                                               Address :</label>
                                            <div class="col-md-9">
                                                <div class="input-group">
                                                    <span class="input-group-addon"><i class="fa fa-user"></i></span>
                                                    <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" placeholder="Enter Applicant Address"></asp:TextBox>
                                                </div>
                                                <label for="<%= txtAddress.ClientID%>" class="error" style="display: none">
                                                </label>
                                            </div>
                                        </div>
                                        
                                        <div class="form-group">
                                            <label class="col-md-3 control-label">
                                                District :</label>
                                            <div class="col-md-9">
                                                <div class="input-group">
                                                    <span class="input-group-addon"><i class="fa fa-plane"></i></span>
                                                    <asp:DropDownList ID="DropAddressDistrictID" CssClass="form-control dropdown" runat="server" >
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                        
                                        
                                        <div class="form-group">
                                            <label class="col-md-3 control-label">
                                                Mobile Number :</label>
                                            <div class="col-md-9">
                                                <div class="input-group">
                                                    <span class="input-group-addon"><i class="fa fa-mobile"></i></span>
                                                    <asp:TextBox ID="txtMobile" runat="server" CssClass="form-control" placeholder="Enter Mobile Number"
                                                        MaxLength="10"></asp:TextBox>
                                                </div>
                                                <label for="<%= txtMobile.ClientID%>" class="error" style="display: none">
                                                </label>
                                            </div>
                                        </div>
                                        
                                        <div class="form-group">
                                            <label class="col-md-3 control-label">
                                                Post :</label>
                                            <div class="col-md-9">
                                                <div class="input-group">
                                                    <span class="input-group-addon"><i class="fa fa-star"></i></span>
                                                    <asp:DropDownList ID="DropPost" CssClass="form-control dropdown" runat="server">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                       
                                       <div class="form-group">
                                            <label class="col-md-3 control-label">
                                                Role :</label>
                                            <div class="col-md-9">
                                                <div class="input-group">
                                                    <span class="input-group-addon"><i class="fa fa-star"></i></span>
                                                    <asp:DropDownList ID="DropRole" CssClass="form-control dropdown" runat="server">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>   
                                        
                                             <div class="form-group">
                                            <label class="col-md-3 control-label">
                                                IsActive :</label>
                                            <div class="col-md-9">
                                                <div class="input-group">
                                                    <asp:CheckBox ID="ChekIsActive" runat="server" />
                                                </div>
                                            </div>
                                        </div>                                 
                                       
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <div class="form-actions fluid">
                                    <div class="col-md-offset-3 col-md-9">
                                        <asp:Button ID="btnSubmit" class="btn purple" OnClientClick="return checkFromValidation();"
                                            runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                                        <asp:Button ID="btnCancel" type="button" class="btn default" runat="server" Text="Back"
                                            Width="86px" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="portlet-body flip-scroll" id="listData" runat="server">
    </div>
</asp:Content>

