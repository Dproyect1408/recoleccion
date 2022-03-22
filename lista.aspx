<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lista.aspx.vb" Inherits="_Default" %>

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
		<title>Lista</title>

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
		<style type="text/css">
            .auto-style1 {
                left: 0px;
                top: 0px;
            }
            .auto-style2 {
                height: 1041px;
            }
            .auto-style7 {
                left: 1px;
                top: 0px;
              
            }
            .auto-style8 {
                width: 78px;
            }
            .auto-style9 {
                width: 253px;
            }
            .auto-style10 {
                width: 401px;
            }
            .auto-style11 {
                width: 110px;
            }
            </style>
		</head>
		<body style="text-align: center; background-image: url('../img/fondo.jpg');"  >	
			<form id="form1" runat="server" class="auto-style2">
			    <!-- #header -->
			<div >
                  <div class="row d-flex justify-content-center">
                  <div class="auto-style1">
                <div class="title text-center" style="text-align: center">
		                        <h1 class="auto-style4">Generar lista de Recoleccíon</h1>
		                        <p style="color: #000000">Recolección de Basura y Renta de Contenedores</p>
		                    </div>
                      </div>
                      </div>
					<div class="auto-style7">
                                <br />
                                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:dp_recoleccion_conection %>" SelectCommand="SELECT * FROM [tt_cliente]"></asp:SqlDataSource>

                                <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:dp_recoleccion_conection %>" SelectCommand="SELECT dbo.tt_lista.Id, dbo.tt_cliente.cliente, dbo.tt_cliente.telefono, dbo.tt_cliente.direccion, dbo.tt_cliente.num_casa, dbo.tt_lista.orden FROM dbo.tt_lista INNER JOIN dbo.tt_cliente ON dbo.tt_lista.id_cliente = dbo.tt_cliente.Id ORDER BY dbo.tt_lista.orden asc"></asp:SqlDataSource>

                     <asp:Button ID="Button4" runat="server" Text="Cargar Lista" Width="451px"  class="primary-btn text-uppercase" CssClass="auto-style1" Height="66px"/>

					            <br />
                                
                                        <asp:Panel ID="Panel1" runat="server" ScrollBars="Auto" Height="325px" Width="100%">
                                            <asp:DataList ID="DataList1" runat="server" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataKeyField="Id" GridLines="Both" Width="100%" Height="309px" CellSpacing="2">
                                                <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                                                <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                                                <ItemStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                                                <ItemTemplate>
                                                    <table style="width:100%;">
                                                        <tr>
                                                            <td style="width: 10%"  >  
                                                                <asp:Button ID="Button6" runat="server" Text="Agregar" CommandName="captura" Font-Bold="True" ForeColor="#009933" />
                                                            </td>
                                                          <td style="width: 50%"  >  
                                                                <asp:Label ID="clienteLabel0" runat="server" Text='<%# Eval("Id") %>' Visible="False" />
                                                                <asp:Label ID="clienteLabel" runat="server" Text='<%# Eval("cliente") %>' />
                                                            </td>
                                                          <td style="width: 10%"  >  
                                                                <asp:Label ID="telefonoLabel" runat="server" Text='<%# Eval("telefono") %>' />
                                                            </td>
                                                          <td style="width: 20%"  >  
                                                                <asp:Label ID="direccionLabel" runat="server" Text='<%# Eval("direccion") %>' />
                                                            </td>
                                                           <td style="width: 10%"  >  
                                                                <asp:Label ID="num_casaLabel" runat="server" Text='<%# Eval("num_casa") %>' />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ItemTemplate>
                                                <SelectedItemStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                                            </asp:DataList>
                                            <br />
                                        </asp:Panel>
                              
                              <h4>  Lista que se va a imprimir</h4><br />
                          <asp:Panel ID="Panel2" runat="server" ScrollBars="Vertical" Height="251px" Width="100%">
                                            <asp:DataList ID="DataList2" runat="server" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" Width="100%" DataKeyField="Id" Visible="False" ForeColor="Black">
                                                <AlternatingItemStyle BackColor="PaleGoldenrod" />
                                                <FooterStyle BackColor="Tan" />
                                                <HeaderStyle BackColor="Tan" Font-Bold="True" />
                                                <ItemTemplate>
                                                    <table style="width:100%;">
                                                        <tr>
                                                            <td class="auto-style8">
                                                                <asp:Button ID="Button7" runat="server" CommandName="borrar" Font-Bold="True" ForeColor="Red" Text="Eliminar" />
                                                            </td>
                                                            <td class="auto-style8">
                                                                <asp:Label ID="IdLabel" runat="server" Text='<%# Eval("Id") %>' />
                                                            </td>
                                                            <td class="auto-style9">
                                                                <asp:Label ID="clienteLabel" runat="server" Text='<%# Eval("cliente") %>' />
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="telefonoLabel" runat="server" Text='<%# Eval("telefono") %>' />
                                                            </td>
                                                            <td class="auto-style10">
                                                                <asp:Label ID="direccionLabel" runat="server" Text='<%# Eval("direccion") %>' />
                                                            </td>
                                                            <td class="auto-style11">
                                                                <asp:Label ID="num_casaLabel" runat="server" Text='<%# Eval("num_casa") %>' />
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="ordenLabel" runat="server" Text='<%# Eval("orden") %>' />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ItemTemplate>
                                                <SelectedItemStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                                            </asp:DataList>
                              </asp:Panel>
                                <br />

                     <asp:Button ID="Button2" runat="server" Text="Impresion" Width="120px"  class="primary-btn text-uppercase" CssClass="auto-style1" Height="52px"/>

                        &nbsp;&nbsp;&nbsp;&nbsp;
                     <asp:Button ID="Button3" runat="server" Text="Salir" Width="100px"  class="primary-btn text-uppercase" CssClass="auto-style1" Height="52px"/>

						                    <br />
						                    <br />
								 <br />

                        &nbsp;<br />
                        <br />

                        &nbsp;<br />
				    <!-- Icon Box Item -->
					<div class="auto-style1">
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/usuarios.aspx" Visible="False">Quieres Registrarte? Entra Aqui...</asp:HyperLink>
					</div>
				</div>
					
				</div>	
			<!-- start banner Area -->
			
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
