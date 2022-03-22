<%@ Page Language="VB" AutoEventWireup="false" CodeFile="imprimir.aspx.vb" Inherits="_Default" %>

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
		<title>Lista de Clientes</title>

		<link href="https://fonts.googleapis.com/css?family=Poppins:100,200,400,300,500,600,700" rel="stylesheet"> 
			<!--
			CSS
			============================================= -->
        <%--		<link rel="stylesheet" href="css/linearicons.css">
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
            .auto-style7 {
                left: 1px;
                top: 0px;
              
            }
            .auto-style8 {
                width: 337px;
                height: 34px;
            }
            .auto-style9 {
                margin-left: 187px;
            }
            .auto-style10 {
                width: 26%;
            }
            </style>
		</head>
	<body >		
			<form id="form1" runat="server" class="auto-style2">
			    <!-- #header -->
			<div >
					<div class="auto-style7">
                                <br />
                                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:dp_recoleccion_conection %>" SelectCommand="SELECT * FROM [tt_cliente]"></asp:SqlDataSource>

                                <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:dp_recoleccion_conection %>" SelectCommand="SELECT dbo.tt_lista.Id, dbo.tt_cliente.cliente, dbo.tt_cliente.telefono, dbo.tt_cliente.direccion, dbo.tt_cliente.num_casa, dbo.tt_lista.orden FROM dbo.tt_lista INNER JOIN dbo.tt_cliente ON dbo.tt_lista.id_cliente = dbo.tt_cliente.Id ORDER BY dbo.tt_lista.orden asc"></asp:SqlDataSource>

                                <table style="width:100%;">
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td>
                          <asp:DataList ID="DataList2" runat="server" Width="82%" DataKeyField="Id" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" CssClass="auto-style9">
                                                <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                                                <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                                                <HeaderTemplate>
                                                    <table style="width:100%;">
                                                        <tr>
                                                            <td style="width:10%">
                                                                <asp:Label ID="IdLabel" runat="server" />
                                                            </td>
                                                            <td class="auto-style10">
                                                                <asp:Label ID="clienteLabel" runat="server" Text="Cliente" />
                                                            </td>
                                                            <td style="width: 10%">
                                                                <asp:Label ID="num_casaLabel" runat="server" Text="Casa numero" />
                                                            </td>
                                                            <td style="width: 20%">
                                                                <asp:Label ID="direccionLabel" runat="server" Text="Direccion" />
                                                            </td>
                                                            <td style="width: 10%">
                                                                <asp:Label ID="telefonoLabel" runat="server" Text="Telefono" />
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="ordenLabel" runat="server" Text="Orden" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <table style="width:100%;">
                                                        <tr>
                                                            <td style="width:10%">
                                                                <asp:Label ID="IdLabel" runat="server" Text='<%# Eval("Id") %>' />
                                                            </td>
                                                            <td class="auto-style10">
                                                                <asp:Label ID="clienteLabel" runat="server" Text='<%# Eval("cliente") %>' />
                                                            </td>
                                                            <td style="width: 10%">
                                                                <asp:Label ID="num_casaLabel" runat="server" Text='<%# Eval("num_casa") %>' />
                                                            </td>
                                                            <td style="width: 20%">
                                                                <asp:Label ID="direccionLabel" runat="server" Text='<%# Eval("direccion") %>' />
                                                            </td>
                                                            <td style="width: 10%">
                                                                <asp:Label ID="telefonoLabel" runat="server" Text='<%# Eval("telefono") %>' />
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="ordenLabel" runat="server" Text='<%# Eval("orden") %>' />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ItemTemplate>
                                                <SelectedItemStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                                            </asp:DataList>
                                        </td>
                                        <td>&nbsp;</td>
                                    </tr>
                                </table>

                                <br />
                          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <br />

                              <input type="button" value="Print" onclick="window.print();" class="auto-style8">
                     
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
