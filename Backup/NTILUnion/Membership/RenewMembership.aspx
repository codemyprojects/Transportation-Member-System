<%@ Page Title="" Language="C#" MasterPageFile="~/NTILU.Master" AutoEventWireup="true" CodeBehind="RenewMembership.aspx.cs" Inherits="NTILUnion.Membership.RenewPayment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
   
   <script type="text/javascript">

       var checkFromValidation = false;

       $(document).ready(function () {


           $('#form').validate();


           $("#<%=txtAmount.ClientID %>").rules('add', { required: true,number: true, messages: { required: 'Renew Amount is required.'} });
           $("#<%=txtMemName.ClientID %>").rules('add', { required: true, messages: { required: 'Name is required.'} });
                     checkFromValidation = function () {

               var bool = true;


               if ($('#<%=txtAmount.ClientID %>').valid() == false) bool = false;
               if ($('#<%=txtMemName.ClientID %>').valid() == false) bool = false;
               

               if (!bool) $('#form').validate().focusInvalid();
               return bool;
           }

       });

    </script>
   
   <script type="text/javascript">
       $(document).ready(function () 
    {
           $("#<%=txtRenewDate.ClientID %>").datepicker({ dateFormat: "yy-mm-dd", yearRange: '1970:2040', changeMonth: true, changeYear: true }).val(), new Date()
          

       });
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div class="page-content">           
		<div class="modal fade" id="portlet-config" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
			<div class="modal-dialog">
				<div class="modal-content">
					<div class="modal-header">
						<button type="button" class="close" data-dismiss="modal" aria-hidden="true"></button>
						<h4 class="modal-title">Modal title</h4>
					</div>
					<div class="modal-body">
						Widget settings form goes here
					</div>
					<div class="modal-footer">
						<button type="button" class="btn blue">Save changes</button>
						<button type="button" class="btn default" data-dismiss="modal">Close</button>
					</div>
				</div>
			</div>
		</div>
		<div class="theme-panel hidden-xs hidden-sm">
			<div class="toggler"></div>
			<div class="toggler-close"></div>
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
					Renew			<small> Renew Membership.</small>
				</h3>
				<ul class="page-breadcrumb breadcrumb">
					<li class="btn-group">
						<button type="button" class="btn blue dropdown-toggle" data-toggle="dropdown" data-hover="dropdown" data-delay="1000" data-close-others="true">
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
					<li>
						<i class="fa fa-home"></i>
						<a href="/Default.aspx">Home</a> 
						<i class="fa fa-angle-right"></i>
                        <a href="SetupMenu.aspx">Setup Menu</a>
						<i class="fa fa-angle-right"></i>
					</li>
					<li><a href="#">Renew</a></li>
				</ul>
            
			</div>
		</div>
		<div class="row">
		</div>
		<div class="row">
			<div class="col-md-12 ">

            
				<div id="message" runat="server"></div>
            
				<div class="portlet box purple ">
					<div class="portlet-title">
						<div class="caption">
							<i class="fa fa-reorder"></i>  Renew 
						</div>
						<div class="tools">
							<a href="" class="collapse"></a>
							<a href="#portlet-config" data-toggle="modal" class="config"></a>
							<a href="" class="reload"></a>
							<a href="" class="remove"></a>
						</div>
					</div>




					<div class="portlet-body form">
						<div class="form-horizontal">
							<div class="form-body">
							
          
                                <div class="form-group">
									<label  class="col-md-3 control-label">Membership :</label>
									<div class="col-md-9">
                                        <div class="input-group">
                                            <span class="input-group-addon"><i class="fa fa-user "></i></span>
                                            <asp:TextBox ID="txtMemName" runat="server" CssClass="form-control" placeholder=" Enter Description "></asp:TextBox>
                                        </div>
                                        <label for="<%= txtMemName.ClientID%>" class="error"  style="display:none" ></label>
									</div>
								</div>
                                <div class="form-group">
									<label  class="col-md-3 control-label">Renew Date :</label>
									<div class="col-md-9">
                                        <div class="input-group">
                                            <span class="input-group-addon"><i class="fa fa-calendar"></i></span>
                                            <asp:TextBox ID="txtRenewDate" runat="server" CssClass="form-control" placeholder=" Enter Description "></asp:TextBox>
                                        </div>
                                        <label for="<%= txtRenewDate.ClientID%>" class="error"  style="display:none" ></label>
									</div>
								</div>
                                 <div class="form-group">
									<label  class="col-md-3 control-label">Amount :</label>
									<div class="col-md-9">
                                        <div class="input-group">
                                            <span class="input-group-addon"><i class="fa fa-dollar"></i></span>
                                            <asp:TextBox ID="txtAmount" runat="server" CssClass="form-control" placeholder=" Enter Description "></asp:TextBox>
                                        </div>
                                        <label for="<%= txtAmount.ClientID%>" class="error"  style="display:none" ></label>
									</div>
								</div>
                                
                               

                                <div class="form-actions fluid">
								<div class="col-md-offset-3 col-md-9">

                                    <asp:Button ID="btnSave" runat="server" Text="Submit" 
                                        OnClientClick= "return checkFromValidation();" class="btn green" 
                                        onclick="btnSave_Click" />
									<asp:Button id="btnCancel" type="button" class="btn purple" runat="server" Text="Cancel"/>
                                                             
								</div>
							</div>
                            </div>
						</div>
                            
					</div>
				</div>
                			</div>

               <%-- <div class="row">
		    <div class="col-md-12">
			    <div class="portlet box green">
				    <div class="portlet-title">
					    <div class="caption"><i class="fa fa-cogs"></i>Renew Information</div>
					    <div class="tools">
						    <a href="javascript:;" class="collapse"></a>
						    <a href="#portlet-config" data-toggle="modal" class="config"></a>
						    <a href="javascript:;" class="reload"></a>
						    <a href="javascript:;" class="remove"></a>
					    </div>
				    </div>
				    <div class="portlet-body flip-scroll" id="listData" runat="server"> 
			    </div>
		    </div>
	    </div>
	    </div>  --%>
			</div>
		</div>

         <div class="portlet-body flip-scroll" id="Div1" runat="server"> 
	</div>

  
</asp:Content>
