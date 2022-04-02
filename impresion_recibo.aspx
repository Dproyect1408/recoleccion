<%@ Page Language="VB" AutoEventWireup="false" CodeFile="impresion_recibo.aspx.vb" Inherits="_Default" %>

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
                height: 243px;
            }
            .auto-style7 {
                margin-left: 0px;
                margin-top: 0px;
                margin-bottom: 0px;
            }
            .auto-style8 {
                width: 154px;
                height: 62px;
            }
            .auto-style5 {
                width: 305px;
            }
            .auto-style9 {
                margin-left: 0px;
            }
            .contenedor
            {
                text-align:center
            }
            </style>
		</head>
		<body style="text-align: center; background-image: url('../img/fondo.jpg');"  >	
			<form id="form1" runat="server" class="auto-style2">
			    <!-- #header -->
			
			<!-- start banner Area -->
			<section class="banner-area relative">
				<div class="overlay overlay-bg">
                    <input type="button" value="Recibo de Pago" onclick="window.print();"></div>				
				<div class="container">
                    <%--<div class="row fullscreen align-items-center justify-content-between">--%>
						
						<section class="popular-destination-area section-gap">
				<div class="container">
		            <div class="row d-flex justify-content-center">
		                <div class="auto-style1">
		                    <div class="title text-center" style="text-align: center">
		                        <p style="color: #000000; font-size: 8px;" class="auto-style7">Recolección de Basura y Renta de Contenedores</p>
                                <p style="color: #000000; font-size: 8px;" class="auto-style7">
                                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:dp_recoleccion_conection %>" SelectCommand="SELECT dbo.tt_lista.Id, dbo.tt_cliente.Id AS Expr2, dbo.tt_cliente.cliente + ' - ' + dbo.tt_cliente.direccion + ' - ' + dbo.tt_cliente.num_casa AS Expr1, dbo.tt_cliente.telefono, dbo.tt_lista.orden, dbo.tt_lista.activo FROM dbo.tt_lista INNER JOIN dbo.tt_cliente ON dbo.tt_lista.id_cliente = dbo.tt_cliente.Id WHERE (dbo.tt_lista.activo = 1) AND (dbo.tt_lista.mes = @mes) ORDER BY dbo.tt_lista.orden">
                                    <SelectParameters>
                                       										    <asp:ControlParameter ControlID="Label9" Name="mes" PropertyName="Text" Type="String" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                                    <img alt="" class="auto-style8" src="img/RECIBO.jpg" /></p>
                                <p style="color: #000000; font-size: 8px;" class="auto-style7">
                                    <asp:Label ID="Label12" runat="server" Text="Label"></asp:Label>
                                </p>
                                <p style="color: #000000; font-size: 8px;" class="auto-style7">-------------------------------------------------------------------------------------</p>
                                <p style="color: #000000" class="auto-style7">
                                    <asp:Label ID="Label7" runat="server" Text="Cliente" Font-Size="Smaller" Font-Bold="True"></asp:Label>
                                    :</p>
                                <p style="color: #000000" class="auto-style7">
                                    <asp:Label ID="Label1" runat="server" Text="Label" Font-Size="Smaller"></asp:Label>
                                </p>
                                <p style="color: #000000" class="auto-style7">
                                    <asp:Label ID="Label8" runat="server" Text="Cantidad Pagada:" Font-Size="Smaller" Font-Bold="True"></asp:Label>
                                </p>
                               <p style="color: #000000" class="auto-style7">
                                    <asp:Label ID="Label2" runat="server" Text="Label" Font-Size="Smaller"></asp:Label>
                                </p>
                                <p style="color: #000000" class="auto-style7">
                                    <asp:Label ID="Label9" runat="server" Text="Rentas:" Font-Size="Smaller" Font-Bold="True"></asp:Label>
                                </p>
                                <p style="color: #000000" class="auto-style7">
                                    <asp:Label ID="Label3" runat="server" Text="Label" Font-Size="Smaller"></asp:Label>
                                </p>
                                <p style="color: #000000" class="auto-style7">
                                    <asp:Label ID="Label10" runat="server" Text="Recolecciones:" Font-Size="Smaller" Font-Bold="True"></asp:Label>
                                </p>
                                 <p style="color: #000000" class="auto-style7">
                                    <asp:Label ID="Label4" runat="server" Text="Label" Font-Size="Smaller"></asp:Label>
                                </p>
                                 <p style="color: #000000" class="auto-style7">
                                    <asp:Label ID="Label11" runat="server" Text="Mes Pagado:" Font-Size="Smaller" Font-Bold="True"></asp:Label>
                                </p>
                                <p style="color: #000000" class="auto-style7">
                                    <asp:Label ID="Label5" runat="server" Text="Label" Font-Size="Smaller"></asp:Label>
                                </p>
                                <p style="color: #000000" class="auto-style7">
                                    <asp:Label ID="Label13" runat="server" Text="Label" Font-Size="Smaller" Visible="False"></asp:Label>
                                </p>
                                <p style="color: #000000; text-align: center;" class="auto-style7">
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </p>
                                <p style="color: #000000" class="auto-style7">
                                    ---------------------------------------------</p>
                                <div class="contenedor">
                                    <asp:DataList ID="DataList1" runat="server" DataKeyField="Id" Width="100%" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" GridLines="Both" CssClass="auto-style9" Font-Size="Smaller">
                                    <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                                    <HeaderStyle BackColor="#999999" Font-Bold="True" ForeColor="#FFFFCC" />
                                    <HeaderTemplate>
                                        <table style="width:100%;">
                                            <tr>
                                                <td  class="auto-style5">
                                                    <asp:Label ID="Label17" runat="server" Text="Fecha" Font-Bold="True" ForeColor="White"></asp:Label>
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Cantidad</td>
                                        
                                            </tr>
                                        </table>
                                    </HeaderTemplate>
                                    <ItemStyle BackColor="White" ForeColor="#330099" />
                                    <ItemTemplate>
                                       
                                                    <asp:Label ID="fechaLabel" runat="server" Text='<%# Eval("fecha") %>' />
                                                    <asp:Label ID="fechaLabel0" runat="server" Text='<%# Eval("id") %>' Visible="False" />
                                            
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; $<asp:Label ID="fechaLabel1" runat="server" Text='<%# Eval("cantidad_pagada") %>' />
                                            
                                    </ItemTemplate>
                                    <SelectedItemStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                                </asp:DataList>
                                </div>
                             
		                    </div>
		                </div>
		            </div>
				</div>
			</section>
					
				</div>
			</section>
		    </form>
		</body>
	</html>
