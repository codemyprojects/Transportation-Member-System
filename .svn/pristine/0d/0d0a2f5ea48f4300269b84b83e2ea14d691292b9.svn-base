<%@ Page Language="C#" MasterPageFile="~/NTILU.Master" AutoEventWireup="true" CodeBehind="DocumentViewer.aspx.cs"
    Inherits="NTILUnion.Membership.DocumentViewer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" type="text/css" media="screen" href="http://cdnjs.cloudflare.com/ajax/libs/fancybox/1.3.4/jquery.fancybox-1.3.4.css" />
    <script type="text/javascript" src="https://code.jquery.com/jquery-1.11.0.js"></script>
    <script type="text/javascript" src="https://code.jquery.com/jquery-1.11.0.min.js"></script>
    <script type="text/javascript" src="https://code.jquery.com/jquery.fancybox-1.3.4.pack.min.js"></script>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.4/jquery.min.js"></script>
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/fancybox/2.1.5/jquery.fancybox.min.js"></script>
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/fancybox/2.1.5/jquery.fancybox.pack.js"></script>
    <script type="text/javascript">
        $(function ($) {
            var addToAll = false;
            var gallery = true;
            var titlePosition = 'inside';
            $(addToAll ? 'img' : 'img.fancybox').each(function () {
                var $this = $(this);
                var title = $this.attr('title');
                var src = $this.attr('data-big') || $this.attr('src');
                var a = $('<a href="#" class="fancybox"></a>').attr('href', src).attr('title', title);
                $this.wrap(a);
            });
            if (gallery)
                $('a.fancybox').attr('rel', 'fancyboxgallery');
            $('a.fancybox').fancybox({
                titlePosition: titlePosition
            });
        });
        $.noConflict();
    </script>
    <style type="text/css">
        body
        {
            font-family: "Aller" , "sans-serif"; /* just a custom font */
        }
        
        ul
        {
            list-style-type: none; /* hiding the bullets from ul */
        }
        
        a:-webkit-any-link
        {
            text-decoration: none; /* ignoring default link settings */
        }
        .fade
        {
            opacity: 0.8; /* sets default view to a 80% opacity */
            transition: opacity .25s ease-in-out;
            -moz-transition: opacity .25s ease-in-out;
            -webkit-transition: opacity .25s ease-in-out;
        }
        
        .fade:hover
        {
            opacity: 1; /* sets default view to a 100% opacity when on hover state */
        }
        .gallery-wrapper ul li
        {
            display: inline-block; /* sit wrappers in rows, not column block */
        }
        
        h4
        {
            /* style the photos titles */
            text-align: center;
            font-size: 1em;
            margin: 0;
            padding: 0.5em 2em;
            text-transform: uppercase;
            font-weight: bold;
            color: black;
        }
        
        h1
        {
            /* just a main title alignment */
            padding-left: 10em;
        }
        
        .img-wrapper
        {
            /* this will be the wrapping box */
            width: 300px;
            height: 240px;
            border: 0.1em solid #ccc;
            border-radius: 0.4em;
            background-color: #f3f3f3;
            box-shadow: 0.1em 0.1em 0.5em -0.2em #777;
            margin: 1em 1em;
        }
        
        img
        {
            border-radius: 0.4em 0.4em 0em 0em; /* radius should be the same as the wrapper */
        }
    </style>
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
                            <%--<li id="exportToExcel"><a href="#">Export To Excel</a></li>--%>
                        </ul>
                    </li>
                    <li><i class="fa fa-home"></i><a href="/Default.aspx">Home</a> <i class="fa fa-angle-right">
                    </i><a href="DocumentViewer.aspx">Membership Menu</a> <i class="fa fa-angle-right"></i>
                    </li>
                    <li><i class=""></i><a href="Search.aspx">Document Viewer</a> <asp:hyperlink id="hyperlink1" runat="server" NavigateUrl="~/Membership/DownloaderFiles.aspx" ></asp:hyperlink></li>
                </ul>
            </div>
        </div>
        <div>
        <asp:Button ID="Button1" runat="server" Text="File Dowloader" 
                onclick="Button1_Click" />
        </div>
        

        <div class="gallery-wrapper">
            <h1>
                Photo Gallery</h1>        
                      
           <div id="ImageViewwer" runat="server"></div>
           <%-- <ul>
                <li>
                    <figure class="img-wrapper fade"><a class="fancybox" href="/DocFiles/img1.jpg"><img  src="/DocFiles/thumbnails/img1.jpg" width="300" height="240"><h4>City at Night</h4></a></figure>
                </li>
              </ul>--%>
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
