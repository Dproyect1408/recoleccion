﻿<%@ Page Language="VB" AutoEventWireup="false" CodeFile="captura.aspx.vb" Inherits="_Default" %>

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
        <%--<link rel="stylesheet" href="css/linearicons.css">
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
            .auto-style4 {
                color: #000000;
            }
            .auto-style5 {
                width: 305px;
            }
            </style>
		</head>
		<body style="text-align: center; background-image: url('../img/fondo.jpg');"  >	
			<form id="form1" runat="server" class="auto-style2">
			    <!-- #header -->
			
			<!-- start banner Area -->
			<section class="banner-area relative">
				<div class="overlay overlay-bg"></div>				
				<div class="container">
                    <%--<div class="row fullscreen align-items-center justify-content-between">--%>
						
						<section class="popular-destination-area section-gap">
				<div class="container">
		            <div class="row d-flex justify-content-center">
		                <div class="auto-style1">
		                    <div class="title text-center" style="text-align: center">
		                        <h1 class="auto-style4">Captura de Recoleccion</h1>
		                        <p style="color: #000000">Recolección de Basura y Renta de Contenedores</p>
		                    </div>
		                </div>
		            </div>						
					<div class="row">
							<div class="col-lg-4 icon_box_col">
                                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:dp_recoleccion_conection %>" SelectCommand="SELECT dbo.tt_lista.Id, dbo.tt_cliente.Id AS Expr2, dbo.tt_cliente.cliente + ' - ' + dbo.tt_cliente.direccion + ' - ' + dbo.tt_cliente.num_casa AS Expr1, dbo.tt_cliente.telefono, dbo.tt_lista.orden, dbo.tt_lista.activo FROM dbo.tt_lista INNER JOIN dbo.tt_cliente ON dbo.tt_lista.id_cliente = dbo.tt_cliente.Id WHERE (dbo.tt_lista.activo = 1) AND (dbo.tt_lista.mes = @mes) ORDER BY dbo.tt_lista.orden">
                                    <SelectParameters>
                                       										    <asp:ControlParameter ControlID="Label9" Name="mes" PropertyName="Text" Type="String" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                                <asp:Calendar ID="Calendar1" runat="server" Visible="False"></asp:Calendar>
                                <br />
                        <asp:Label ID="Label2" runat="server" Text="Fecha" Font-Bold="True" Font-Size="X-Large"></asp:Label>
						        <br />
						        <asp:TextBox ID="txt_fecha" runat="server" Enabled="False" Width="291px" Font-Size="X-Large"></asp:TextBox>
					            <br />
                        <asp:Label ID="Label8" runat="server" Text="Mes: " Font-Bold="True"></asp:Label>
                        <asp:Label ID="Label9" runat="server" Font-Bold="True"></asp:Label>
                                <br />
                        <asp:Label ID="Label6" runat="server" Text="Semana" Font-Bold="True"></asp:Label>
                                :
                        <asp:Label ID="Label7" runat="server" Font-Bold="True"></asp:Label>
                                <br />
                        <asp:Label ID="Label5" runat="server" Text="Cliente" Font-Bold="True"></asp:Label>
					            <br />
                                Cantidad de clientes:<asp:Label ID="Label14" runat="server" Font-Bold="True"></asp:Label>
					            <br />

                                <asp:DropDownList ID="ddl_cliente" runat="server" DataTextField="Expr1" DataValueField="Expr2" Height="34px" Width="50%" AutoPostBack="True" Font-Size="X-Large" >
                                </asp:DropDownList>

                                <br />
                                <br />
                                <asp:DataList ID="DataList1" runat="server" DataKeyField="Id" Width="100%" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" GridLines="Both">
                                    <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
                                    <HeaderTemplate>
                                        <table style="width:100%;">
                                            <tr>
                                                <td  class="auto-style5">
                                                    <asp:Label ID="Label17" runat="server" Text="Fecha"></asp:Label>
                                                </td>
                                        
                                            </tr>
                                        </table>
                                    </HeaderTemplate>
                                    <ItemStyle BackColor="White" ForeColor="#330099" />
                                    <ItemTemplate>
                                        <table style="width:100%;">
                                            <tr>
                                         
                                                <td class="auto-style5">
                                                    <asp:Label ID="fechaLabel0" runat="server" Text='<%# Eval("id") %>' Visible="False" />
                                                    <asp:Label ID="fechaLabel" runat="server" Text='<%# Eval("fecha") %>' />
                                                </td>
                                     
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                    <SelectedItemStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                                </asp:DataList>
                                <br />
                                <asp:TextBox ID="TextBox1" runat="server" Enabled="False" Height="83px" TextMode="MultiLine" Width="375px"></asp:TextBox>

                                <br />
								 <br />
                        <asp:Label ID="Label10" runat="server" Text="Cantidad de Visitas Registradas: " Font-Bold="True"></asp:Label>
                        <asp:Label ID="Label11" runat="server" Font-Bold="True"></asp:Label>
                                <br />
                        <asp:Label ID="Label12" runat="server" Text="Cantidad de Visitas Realizadas: " Font-Bold="True"></asp:Label>
                        <asp:Label ID="Label13" runat="server" Font-Bold="True"></asp:Label>
                                <br />
								 <asp:Label ID="Label3" runat="server" Text="Cantidad de contendores " Font-Bold="True"></asp:Label>

                                <br />

                                <asp:DropDownList ID="ddl_num" runat="server" Height="31px" Width="218px">
                                    <asp:ListItem>0</asp:ListItem>
                                    <asp:ListItem>1</asp:ListItem>
                                    <asp:ListItem>2</asp:ListItem>
                                    <asp:ListItem>3</asp:ListItem>
                                    <asp:ListItem>4</asp:ListItem>
                                    <asp:ListItem>5</asp:ListItem>
                                    <asp:ListItem>6</asp:ListItem>
                                    <asp:ListItem>7</asp:ListItem>
                                    <asp:ListItem>8</asp:ListItem>
                                    <asp:ListItem>9</asp:ListItem>
                                    <asp:ListItem>10</asp:ListItem>
                                </asp:DropDownList>

                                <br />
                                <br />
                                <br />

                     <asp:Button ID="Button2" runat="server" Text="Guardar" Width="25%"  class="primary-btn text-uppercase" CssClass="auto-style1" Height="123px" Font-Size="X-Large"/>

                                &nbsp;&nbsp;&nbsp;<asp:Button ID="Button3" runat="server" Text="Salir" Width="25%"  class="primary-btn text-uppercase" CssClass="auto-style1" Height="123px" Font-Size="X-Large"/>

						                    <br />
                                <br />

						                    <br />
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
