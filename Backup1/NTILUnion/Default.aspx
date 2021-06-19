<%@ Page Title="" Language="C#" MasterPageFile="~/NTILU.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="NTILUnion.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

 <script src="assets/scripts/jquery.flip.js" type="text/javascript"></script>
    <link href="/assets/css/custom.css" rel="stylesheet" type="text/css" />
  <script type="text/javascript">
      $(document).ready(function () {

          var flip_options = { axis: 'x', trigger: 'click' };
          $('.flip_card').each(function () {
              $(this).flip(flip_options);
          });

          $('#so_options').on('shown.bs.collapse', function () {
              $('a[href="#so_options"] i').removeClass('fa-angle-down').addClass('fa-angle-up');
          })
          $('#so_options').on('hidden.bs.collapse', function () {
              $('a[href="#so_options"] i').removeClass('fa-angle-up').addClass('fa-angle-down');
          })

          $('#so_options input').attr('checked', true);
          $('#so_options input').click(function () {
              if ($(this).is(':checked')) {
                  $($(this).attr('data-target')).removeClass('hidden');
              } else {
                  $($(this).attr('data-target')).addClass('hidden');
              }
          });

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
						Dashboard					<small>Gridview display of menus.</small>
					</h3>
					<ul class="page-breadcrumb breadcrumb">
						<li class="btn-group">
							<a class="btn blue" data-toggle="collapse" data-parent="#screen_options" href="#so_options">
							    <span>Screen Options</span> <i class="fa fa-angle-down"></i>
							</a>
							<button type="button" class="btn blue dropdown-toggle" data-toggle="dropdown" data-hover="dropdown" data-delay="1000" data-close-others="true">
							<span>Reports</span> <i class="fa fa-angle-down"></i>
							</button>
							<ul class="dropdown-menu pull-right" role="menu">
								<li><a href="#">Student</a></li>
								<li><a href="#">HR</a></li>
                                <li><a href="#">Account</a></li>
								<li><a href="#">Settings</a></li>
                                <li><a href="#">Setup</a></li>
								<li class="divider"></li>
								<li><a href="#">Advanced Reports</a></li>
							</ul>
						</li>
						<li>
							<i class="fa fa-home"></i>
							<a href="default.aspx">Home</a> 
							<i class="fa fa-angle-right"></i>
						</li>
						<li><a href="/default.aspx">Dashboard</a></li>
					</ul>

                    
                    <div id="screen_options" class="panel-group">
                      <div class="panel so_panel">
  
                        <div style="" id="so_options" class="panel-collapse collapse">
                          <div class="panel-body">
                            <label><input type="checkbox" data-target="#box_Member" /> Membership</label>
                            <label><input type="checkbox" data-target="#box_setup" /> setup</label>
                          </div>
                        </div>
                      </div>
                    </div>

				</div>
			</div>
			
			<div class="row dashboard_boxes">
				<div class="col-lg-2 col-md-3 col-sm-4 col-xs-6" id="box_Member">
					<div class="portlet box blue">
						<div class="portlet-title">
							<div class="caption">
                                <a href="Membership/MembershipMenu.aspx">
							        <i class="fa fa-user"></i>Membership
                                </a>
							</div>
						
						</div>
						    <div class="portlet-body form" >
                                <div class="flip_card"> 
                                  <div class="front">
                                      <div class="portlet-image">
                                        <img src="assets/img/student51.png" />
                                      </div> 
                                  </div> 
                                  <div class="back">
                                    <i class="fa fa-sort"> Total :  223 </i> 
                                    <i class="fa fa-calendar"> September:  122 </i> 
                                    <i class="fa fa-dashboard"> Today :  23 </i> 
                                  </div> 
                                </div>
                            </div>
					</div>
				</div>

                	<div class="col-lg-2 col-md-3 col-sm-4 col-xs-6" id="box_setup">
					<div class="portlet box blue">
						<div class="portlet-title">
							<div class="caption">
                                <a href="SetUp/SetupMenu.aspx">
								<i class="fa fa-gears"></i> Setup
                                </a> 
							</div>
					
						</div>
						<div class="portlet-body form" >
                                <div class="flip_card"> 
                                  <div class="front">
                                      <div class="portlet-image">
                                        <img src="assets/img/Setup.png" />
                                      </div> 
                                  </div> 
                                  <div class="back">
                                    <i class="fa fa-sort"> Total :  223 </i> 
                                    <i class="fa fa-calendar"> September:  122 </i> 
                                    <i class="fa fa-dashboard"> Today :  23 </i> 
                                  </div> 
                                </div>
                            </div>
					</div>
				</div>


			</div>
		</div>
      
</asp:Content>
