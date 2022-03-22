<%@ Page Language="VB" AutoEventWireup="false" CodeFile="google.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html>
	<html lang="zxx" class="no-js">
	<head>
    
		<!-- Mobile Specific Meta -->
		<meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
		<!-- Favicon-->
		<link rel="shortcut icon" href="img/fav.png">
		<!-- Author Meta -->
		<meta name="author" content="colorlib">
		<!-- Meta Description -->
		<meta name="description" content="">
		<!-- Meta Keyword -->
		<meta name="keywords" content="">
		<!-- meta character set -->
		<meta charset="UTF-8">
		<!-- Site Title -->
		<title>Menu</title>

		<link href="https://fonts.googleapis.com/css?family=Poppins:100,200,400,300,500,600,700" rel="stylesheet"> 
			<!--
			CSS
			============================================= -->
			<link rel="stylesheet" href="css/linearicons.css">
			<link rel="stylesheet" href="css/font-awesome.min.css">
			<link rel="stylesheet" href="css/bootstrap.css">
			<link rel="stylesheet" href="css/magnific-popup.css">
			<link rel="stylesheet" href="css/jquery-ui.css">				
			<link rel="stylesheet" href="css/nice-select.css">							
			<link rel="stylesheet" href="css/animate.min.css">
			<link rel="stylesheet" href="css/owl.carousel.css">				
			<link rel="stylesheet" href="css/main.css">



		   <link rel="stylesheet" href="https://netdna.bootstrapcdn.com/bootstrap/3.0.3/css/bootstrap.min.css" />
    <link rel="stylesheet" href="https://netdna.bootstrapcdn.com/bootstrap/3.0.3/css/bootstrap-theme.min.css" />
    <script src="https://code.jquery.com/jquery-1.10.2.min.js"></script>
    <script src="https://netdna.bootstrapcdn.com/bootstrap/3.0.3/js/bootstrap.min.js"></script>
 <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyBwZ8xihRw3iQNVcBCcorKmimzI5kzX3N4"></script>
		<script src="js/locationpicker.jquery.js"></script>
		<style type="text/css">
            .auto-style1 {
                left: 0px;
                top: 0px;
            }
            .auto-style2 {
                height: 1041px;
            }
            .auto-style3 {
                height: 313px;
            }
        </style>
		</head>
		<body style="left: 0px; top: 0px; height: 1012px">	
			<form id="form1" runat="server" class="auto-style2">
			<header id="header">
				<div class="header-top">
					<div class="container">
			  		<div class="row align-items-center">
			  			<div class="col-lg-6 col-sm-6 col-6 header-top-left">
                            <%--<ul>
			  					<li><a href="#">Visit Us</a></li>
			  					<li><a href="#">Buy Tickets</a></li>
			  				</ul>	--%>		
			  			</div>
			  			<div class="col-lg-6 col-sm-6 col-6 header-top-right">
                            <%--	<div class="header-social">
								<a href="#"><i class="fa fa-facebook"></i></a>
								<a href="#"><i class="fa fa-twitter"></i></a>
								<a href="#"><i class="fa fa-dribbble"></i></a>
								<a href="#"><i class="fa fa-behance"></i></a>
							</div>--%>
			  			</div>
			  		</div>			  					
					</div>
				</div>
				<div class="container main-menu">
					<div class="row align-items-center justify-content-between d-flex">
				      <div id="logo">
				        <a href="default.aspx"><img src="img/logo.png" alt="" title="" /></a>
				      </div>
				      <nav id="nav-menu-container">
				        <ul class="nav-menu">
				          <li><a href="default.aspx">Inicio</a></li>
				              <%--<li><a href="about.html">About</a></li>
				          <li><a href="packages.html">Packages</a></li>
				          <li><a href="hotels.html">Hotels</a></li>
				          <li><a href="insurance.html">Insurence</a></li>--%>				          <%--<li class="menu-has-children"><a href="">Blog</a>
				            <ul>
				              <li><a href="blog-home.html">Blog Home</a></li>
				              <li><a href="blog-single.html">Blog Single</a></li>
				            </ul>
				          </li>	
				          <li class="menu-has-children"><a href="">Pages</a>
				            <ul>
				            	  <li><a href="elements.html">Elements</a></li>
						          <li class="menu-has-children"><a href="">Level 2 </a>
						            <ul>
						              <li><a href="#">Item One</a></li>
						              <li><a href="#">Item Two</a></li>
						            </ul>
						          </li>					                		
				            </ul>
				          </li>					          					          		    --%>      
				          <li><a href="contact.aspx">Contacto</a></li>
				        </ul>
				      </nav><!-- #nav-menu-container -->					      		  
					</div>
				</div>
			</header><!-- #header -->
			
			<!-- start banner Area -->
			<section class="banner-area relative">
				<div class="overlay overlay-bg"></div>				
				<div class="container">
                    <%--<div class="row fullscreen align-items-center justify-content-between">--%>
						
						<section class="popular-destination-area section-gap">
				<div class="container">
		            <div class="row d-flex justify-content-center">
		                <div class="auto-style1">
		                    <div class="title text-center">
		                        <h1 style="color: #FFFFFF">Recolección de Basura</h1>
		                        <p style="color: #FFFFFF">Recolección de Basura y Renta de Contenedores</p>
		                    </div>
		                </div>
		            </div>						
					<div class="row">
							<div class="col-lg-4 icon_box_col">
                                <br />
                                <br />
                                <br />
					    <br />
                        <br />

						                    <br />
						                    <br />
								 <br />
                                <br />
                                <br />
                                <br />

                        &nbsp;<br />
                        <br />

                       <div class="container">
 
            <button type="button" data-toggle="modal" data-target="#ModalMap" class="btn btn-default">
                <span class="glyphicon glyphicon-map-marker"></span><span id="ubicacion">Seleccionar Ubicacion</span>
 
            </button>
 
            <div class="modal fade" id="ModalMap" tabindex="-1" role="dialog">
                <style>
                    .pac-container {
                        z-index: 99999;
                    }
                </style>
                <div class="modal-dialog" role="document">
                    <div class="modal-content">
                        <div class="modal-body">
                            <div class="form-horizontal">
                                <div class="form-group">
                                    <label class="col-sm-2 control-label">Ubicación:</label>
                                    <div class="col-sm-9">
                                        <input type="text" class="form-control" id="ModalMap-address" />
                                    </div>
                                    <div class="col-sm-1">
                                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                    </div>
                                </div>
                                <div id="ModalMapPreview" style="width: 100%; height: 400px;"></div>
                                <div class="clearfix">&nbsp;</div>
                                <div class="m-t-small">
                                    <label class="p-r-small col-sm-1 control-label">Lat.:</label>
                                    <div class="col-sm-3">
                                        <input type="text" class="form-control" id="ModalMap-lat" />
                                    </div>
                                    <label class="p-r-small col-sm-2 control-label">Long.:</label>
 
                                    <div class="col-sm-3">
                                        <input type="text" class="form-control" id="ModalMap-lon" />
                                    </div>
                                    <div class="col-sm-3">
                                        <button type="button" class="btn btn-primary btn-block" data-dismiss="modal">Aceptar</button>
                                    </div>
 
                                </div>
                                <div class="clearfix"></div>
                                <script>
                                    $('#ModalMapPreview').locationpicker({
                                        radius: 0,
                                        location: {
                                            latitude: 20.938297181414647,
                                            longitude: -89.61501516379462
                                        },
                                        inputBinding: {
                                            latitudeInput: $('#ModalMap-lat'),
                                            longitudeInput: $('#ModalMap-lon'),
                                            locationNameInput: $('#ModalMap-address')
                                        },
                                        enableAutocomplete: true,
                                        onchanged: function (currentLocation, radius, isMarkerDropped) {
                                            $('#ubicacion').html($('#ModalMap-address').val());
                                        }
                                    });
                                    $('#ModalMap').on('shown.bs.modal', function () {
                                        $('#ModalMapPreview').locationpicker('autosize');
                                    });
                                </script>
                            </div>
                        </div>
                    </div>
                </div>
 
            </div>
        </div>
				    <!-- Icon Box Item -->
					<div class="auto-style1">
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/usuarios.aspx" Visible="False">Quieres Registrarte? Entra Aqui...</asp:HyperLink>
					</div>
				</div>
						
						<%--<div class="col-lg-4">
							<div class="single-destination relative">
								<div class="thumb relative">
									<div class="overlay overlay-bg"></div>
									<img class="img-fluid" src="img/d3.jpg" alt="">
								</div>
								<div class="desc">	
									<a href="#" class="price-btn">$350</a>			
									<h4>Cloud Mountain</h4>
									<p>Sri Lanka</p>			
								</div>
							</div>
						</div>				--%>								
					</div>
				</div>	
			</section>
					
					   <%-- </div>--%>
					<div class="auto-style3">
					
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
						
					</div>
				</div>					
			</section>
			<!-- End banner Area -->


			<!-- start footer Area -->		
			<!-- End footer Area -->	

			<script src="js/vendor/jquery-2.2.4.min.js"></script>
			<script src="js/popper.min.js"></script>
			<script src="js/vendor/bootstrap.min.js"></script>			
			<script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyBhOdIF3Y9382fqJYt5I_sswSrEw5eihAA"></script>		
 			<script src="js/jquery-ui.js"></script>					
  			<script src="js/easing.min.js"></script>			
			<script src="js/hoverIntent.js"></script>
			<script src="js/superfish.min.js"></script>	
			<script src="js/jquery.ajaxchimp.min.js"></script>
			<script src="js/jquery.magnific-popup.min.js"></script>						
			<script src="js/jquery.nice-select.min.js"></script>					
			<script src="js/owl.carousel.min.js"></script>							
			<script src="js/mail-script.js"></script>	
			<script src="js/main.js"></script>	
		    </form>
		</body>
	</html>
