<%@ Page Language="VB" AutoEventWireup="false" CodeFile="impresion.aspx.vb" Inherits="_Default" %>

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
		<title>Alta</title>

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
                left: 0px;
                top: 0px;
            }
            .auto-style2 {
                height: 1041px;
            }
            .auto-style3 {
                height: 313px;
            }
            .auto-style5 {
                left: 0px;
                top: 0px;
                height: 45px;
            }
        </style>
		</head>
	<body style="text-align: center; background-image: url('../img/fondo.jpg');"  >	
			<form id="form1" runat="server" class="auto-style2">
			    <!-- #header -->
			
			<!-- start banner Area -->
			<section class="banner-area relative">
				<div class="overlay overlay-bg"></div>				
				<div>
					<%--<div class="row fullscreen align-items-center justify-content-between">--%>
						
						<section class="popular-destination-area section-gap">
				<div >
		            <div class="row d-flex justify-content-center">
		                <div class="auto-style1">
		                    <div class="title text-center">
		                        <h1 style="color: #000000">Recolección de Basura</h1>
		                        <p style="color: #000000">Recolección de Basura y Renta de Contenedores</p>
		                    </div>
		                </div>
		            </div>						
					<div class="row">
							<div class="col-lg-4 icon_box_col">
                                <br />
                                <br />
                                <br />
                        <asp:Label ID="Label2" runat="server" Text="Fecha"></asp:Label>
						        <asp:TextBox ID="txt_fecha" runat="server" Enabled="False"></asp:TextBox>
					    <br />
                        <br />

                        <asp:Label ID="Label1" runat="server" Text="Nombre"></asp:Label>
								    <asp:TextBox ID="txt_nombre" runat="server"></asp:TextBox>
						                    <br />
								<asp:Label ID="Label8" runat="server" Text="Usuario"></asp:Label>
						        <asp:TextBox ID="txt_usuario" runat="server"></asp:TextBox>
						                    <br />
                                            <asp:Label ID="Label9" runat="server" Text="Password"></asp:Label>

                                <asp:TextBox ID="txt_pass" runat="server" TextMode="Password"></asp:TextBox>
								 <br />
								 <asp:Label ID="Label3" runat="server" Text="Tipo"></asp:Label>

                        &nbsp;<asp:DropDownList ID="DropDownList1" runat="server">
                                    <asp:ListItem>Seleccionar...</asp:ListItem>
                                    <asp:ListItem Value="0">Administrador</asp:ListItem>
                                    <asp:ListItem Value="1">Captura</asp:ListItem>
                                </asp:DropDownList>

                        <br />
                                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:dp_recoleccion_conection %>" SelectCommand="SELECT * FROM [tt_usuarios]"></asp:SqlDataSource>
                        <br />
                     <asp:Button ID="Button2" runat="server" Text="Guardar" Width="166px"  class="primary-btn text-uppercase" CssClass="auto-style5"/>

                        &nbsp;<asp:Button ID="Button3" runat="server" Text="Regresar" Width="166px"  class="primary-btn text-uppercase" CssClass="auto-style5"/>

                        <br />
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
