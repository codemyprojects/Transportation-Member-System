<%@ Page Title="" Language="C#" MasterPageFile="~/NTILU.Master" AutoEventWireup="true"
    CodeBehind="File upload.aspx.cs" Inherits="NTILUnion.Membership.File_upload" %>




<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">

        var checkFromValidation = false;

        $(document).ready(function () {


            $('#form').validate();


            $("#<%=txtMemberName.ClientID %>").rules('add', { required: true, messages: { required: 'Applicant Name is required.'} });
            $("#<%=txtFatherName.ClientID %>").rules('add', { required: true, messages: { required: 'Applicant Father Name is required.'} });
            $("#<%=txtMotherName.ClientID %>").rules('add', { required: true, messages: { required: 'Applicant Mother Name is required.'} });
            $("#<%=txtCitizenShipNo.ClientID %>").rules('add', { required: true, messages: { required: 'CitizenShip Number is required.'} });
            $("#<%=txtLicenseNo.ClientID %>").rules('add', { required: true, messages: { required: 'License Number is required.'} });
            $("#<%=txtMobile.ClientID %>").rules('add', { required: true, number: true, text: false, maxlength: 10, messages: { required: 'Mobile Number is required.'} });
            $("#<%=txtTelephone1.ClientID %>").rules('add', { text: false, number: true, maxlength: 10, messages: { required: 'Telephone Number is required.'} });
            $("#<%=txtEmail.ClientID %>").rules('add', { email: true, messages: { required: 'Enter valid Email.'} });
            $("#<%=txtDateofBirth.ClientID %>").rules('add', { required: true, messages: { required: 'Date of Birth is required.'} });
            $("#<%=txtValidDate.ClientID %>").rules('add', { required: true, messages: { required: 'Date of Validation is required.'} });
            $("#<%=txtMembershipDate.ClientID %>").rules('add', { required: true, messages: { required: 'Date of Registration is required.'} });
            checkFromValidation = function () {

                var bool = true;


                if ($('#<%=txtMemberName.ClientID %>').valid() == false) bool = false;
                if ($('#<%=txtFatherName.ClientID %>').valid() == false) bool = false;
                if ($('#<%=txtMotherName.ClientID %>').valid() == false) bool = false;
                if ($('#<%=txtCitizenShipNo.ClientID %>').valid() == false) bool = false;
                if ($('#<%=txtLicenseNo.ClientID %>').valid() == false) bool = false;
                if ($('#<%=txtMobile.ClientID %>').valid() == false) bool = false;
                if ($('#<%=txtTelephone1.ClientID %>').valid() == false) bool = false;
                if ($('#<%=txtEmail.ClientID %>').valid() == false) bool = false;
                if ($('#<%=txtDateofBirth.ClientID %>').valid() == false) bool = false;
                if ($('#<%=txtValidDate.ClientID %>').valid() == false) bool = false;
                if ($('#<%=txtMembershipDate.ClientID %>').valid() == false) bool = false;

                if (!bool) $('#form').validate().focusInvalid();
                return bool;
            }

        });

    </script>

   <script type="text/javascript">

       $(document).ready(function () {
           $("#<%=txtValidDate.ClientID %>").datepicker({ dateFormat: "yy-mm-dd", yearRange: '1970:2040', changeMonth: true, changeYear: true }).datepicker("setDate", new Date());
           $("#<%=txtMembershipDate.ClientID %>").datepicker({ dateFormat: "yy-mm-dd", yearRange: '1970:2040', changeMonth: true, changeYear: true }).datepicker("setDate", new Date());

           $("#<%=txtDateofBirth.ClientID %>").datepicker({ dateFormat: "yy-mm-dd", yearRange: '1970:2040', changeMonth: true, changeYear: true })


           Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(function (evt, args) {
               $("#<%=txtValidDate.ClientID %>").datepicker({ dateFormat: "yy-mm-dd", yearRange: '1970:2040', changeMonth: true, changeYear: true }).val(), new Date()
               $("#<%=txtMembershipDate.ClientID %>").datepicker({ dateFormat: "yy-mm-dd", yearRange: '1970:2040', changeMonth: true, changeYear: true }).val(), new Date()

               $("#<%=txtDateofBirth.ClientID %>").datepicker({ dateFormat: "yy-mm-dd", yearRange: '1970:2040', changeMonth: true, changeYear: true })
           });





       });
    </script>

   
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
                    <li><a href="#">New Membership</a></li>
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
                            <i class="fa fa-user"></i>Create Membership
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
                                              Multi File Upload :</label>
                                             <div class="col-md-9">
                                                <div class="FileUploaders">
                                                <input type ="file" id = "fileupload" name = "fileupload" />
                                                </div>
                                                <label for="<%= fpMemberPhoto.ClientID%>" class="error" style="display: none">
                                                </label>
                                            </div>
                                        </div>



                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <div class="form-actions fluid">
                                    <div class="col-md-offset-3 col-md-9">
                                        <asp:Button ID="btnSubmit" class="btn purple" OnClientClick="return checkFromValidation();"
                                            runat="server" Text="Submit" onclick="btnSubmit_Click" />
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
