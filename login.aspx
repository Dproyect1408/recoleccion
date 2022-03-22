<%@ Page Language="VB" AutoEventWireup="false" CodeFile="login.aspx.vb" Inherits="_Default" %>

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
		<title>Login</title>

		<link href="https://fonts.googleapis.com/css?family=Poppins:100,200,400,300,500,600,700" rel="stylesheet"> 
			<!--
			CSS
			============================================= -->
		<%--	<link rel="stylesheet" href="css/linearicons.css">
			<link rel="stylesheet" href="css/font-awesome.min.css">
			<link rel="stylesheet" href="css/bootstrap.css">
			<link rel="stylesheet" href="css/magnific-popup.css">
			<link rel="stylesheet" href="css/jquery-ui.css">				
			<link rel="stylesheet" href="css/nice-select.css">							
			<link rel="stylesheet" href="css/animate.min.css">
			<link rel="stylesheet" href="css/owl.carousel.css">				
			<link rel="stylesheet" href="css/main.css">--%>
		<style type="text/css">
            .auto-style1 {
                left: 0;
                right: 0;
                top: 0;
            }
            </style>
		</head>
		<body style="text-align: center; background-image: url('../img/fondo.jpg');"  >	
			<form id="form1" runat="server">
			<header id="header" class="auto-style1">
			
				
			</header><!-- #header -->
			
			<!-- start banner Area -->
			<section class="banner-area relative">
				<div class="overlay overlay-bg"></div>				
				<div class="container">
					<div class="row fullscreen align-items-center justify-content-between">
						<div class="col-lg-6 col-md-6 banner-left">
							
							<h1 class="text-white">Servicio de Recolección</h1>
							<div class="col-lg-4 icon_box_col">
                        <asp:Label ID="Label2" runat="server" Text="Fecha" Font-Size="X-Large"></asp:Label>
						        <asp:TextBox ID="txt_fecha" runat="server" Enabled="False" Font-Size="X-Large" Width="387px"></asp:TextBox>
					    <br />
                        <br />
                        <asp:Label ID="Label8" runat="server" Text="Usuario" Font-Size="X-Large"></asp:Label>
						        <asp:TextBox ID="txt_usuario" runat="server" Font-Size="X-Large"></asp:TextBox>
						                    <br />
                                            <asp:Label ID="Label9" runat="server" Text="Password" Font-Size="X-Large"></asp:Label>

                                <asp:TextBox ID="txt_pass" runat="server" TextMode="Password" Font-Size="X-Large"></asp:TextBox>

                        <br />
                        <br />
                     <asp:Button ID="Button2" runat="server" Text="Iniciar Sesion" Width="166px" Height="45px"  class="primary-btn text-uppercase"/>

                        <br />
				    <!-- Icon Box Item -->
					<div class="auto-style1">
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/usuarios.aspx" Visible="False">Quieres Registrarte? Entra Aqui...</asp:HyperLink>
					</div>
				</div>
							<p class="text-white">
								&nbsp;</p>
                            <p class="text-white">
								&nbsp;</p>
                            <p class="text-white">
								&nbsp;</p>
                            <p class="text-white">
								&nbsp;</p>
                            <p class="text-white">
								&nbsp;</p>
                            <p class="text-white">
								&nbsp;</p>
                            <p class="text-white">
								&nbsp;</p>
                            <p class="text-white">
								&nbsp;</p>
                            <p class="text-white">
								&nbsp;</p>
                            <p class="text-white">
								&nbsp;</p>
							&nbsp;</div>
					</div>
				</div>					
			</section>
			<!-- End banner Area -->

			<!-- Start popular-destination Area -->
			
			<!-- End popular-destination Area -->
			

			<!-- Start price Area -->
			
			<!-- End price Area -->
			

			<!-- Start other-issue Area -->
                <%--<section class="other-issue-area section-gap">
				<div class="container">
		            <div class="row d-flex justify-content-center">
		                <div class="menu-content pb-70 col-lg-9">
		                    <div class="title text-center">
		                        <h1 class="mb-10">Other issues we can help you with</h1>
		                        <p>We all live in an age that belongs to the young at heart. Life that is.</p>
		                    </div>
		                </div>
		            </div>					
					<div class="row">
						<div class="col-lg-3 col-md-6">
							<div class="single-other-issue">
								<div class="thumb">
									<img class="img-fluid" src="img/o1.jpg" alt="">					
								</div>
								<a href="#">
									<h4>Rent a Car</h4>
								</a>
								<p>
									The preservation of human life is the ultimate value, a pillar of ethics and the foundation.
								</p>
							</div>
						</div>
						<div class="col-lg-3 col-md-6">
							<div class="single-other-issue">
								<div class="thumb">
									<img class="img-fluid" src="img/o2.jpg" alt="">					
								</div>
								<a href="#">
									<h4>Cruise Booking</h4>
								</a>
								<p>
									I was always somebody who felt quite sorry for myself, what I had not got compared.
								</p>
							</div>
						</div>
						<div class="col-lg-3 col-md-6">
							<div class="single-other-issue">
								<div class="thumb">
									<img class="img-fluid" src="img/o3.jpg" alt="">					
								</div>
								<a href="#">
									<h4>To Do List</h4>
								</a>
								<p>
									The following article covers a topic that has recently moved to center stage–at least it seems.
								</p>
							</div>
						</div>
						<div class="col-lg-3 col-md-6">
							<div class="single-other-issue">
								<div class="thumb">
									<img class="img-fluid" src="img/o4.jpg" alt="">					
								</div>
								<a href="#">
									<h4>Food Features</h4>
								</a>
								<p>
									There are many kinds of narratives and organizing principles. Science is driven by evidence.
								</p>
							</div>
						</div>																		
					</div>
				</div>	
			</section>--%>
			<!-- End other-issue Area -->
			


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
		        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:dp_recoleccion_conection %>" SelectCommand="SELECT * FROM [tt_usuarios]"></asp:SqlDataSource>
		    </form>
		</body>
	</html>
