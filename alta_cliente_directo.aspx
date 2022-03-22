<%@ Page Language="VB" AutoEventWireup="false"  EnableEventValidation="false"  CodeFile="alta_cliente_directo.aspx.vb" Inherits="_Default" %>

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
		<title>Alta Cliente</title>

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
            .auto-style4 {
                color: #000000;
            }
        
*,
*::before,
*::after {
  box-sizing: border-box;
}

  *,
  *::before,
  *::after {
    text-shadow: none !important;
    box-shadow: none !important;
  }
            .auto-style5 {
                width: 10%;
                height: 30px;
            }
            .auto-style7 {
                width: 20%;
                height: 30px;
            }
            .auto-style8 {
                width: 5%;
                height: 30px;
            }
            </style>
		</head>
	<body style="text-align: center; background-image: url('../img/fondo.jpg');"  >	
			<form id="form1" runat="server" class="auto-style2">
			    <!-- #header -->
			
			<!-- start banner Area -->
			<section class="banner-area relative">
				<div class="overlay overlay-bg">
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                </div>				
				<div class="container">
                    <%--<div class="row fullscreen align-items-center justify-content-between">--%>
						
						<section class="popular-destination-area section-gap">
				<div class="container">
		            <div class="row d-flex justify-content-center">
		                <div class="auto-style1">
		                    <div class="title text-center" style="text-align: center">
		                        <h1 class="auto-style4">Alta de Cliente directo a lista de chofer</h1>
		                        <p style="color: #000000">Recolección de Basura y Renta de Contenedores<asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:dp_recoleccion_conection %>" SelectCommand="SELECT * FROM [tt_cliente] ORDER BY [orden]"></asp:SqlDataSource>
                                </p>
		                    </div>
		                </div>
		            </div>						
					<div class="row" style="text-align: center">
							<div class="col-lg-4 icon_box_col">
                                <br />
                                <br />

       <asp:Panel ID="Panel2" runat="server" ScrollBars="Vertical" Height="251px" Width="100%">
                                      <asp:DataList ID="DataList1" runat="server" Width="100%" DataKeyField="Id" DataSourceID="SqlDataSource3" CellPadding="4" ForeColor="#333333">
                                          <AlternatingItemStyle BackColor="White" />
                                          <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                          <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                          <HeaderTemplate>
                                              <table style="width:100%;">
                                                  <tr>
                                                      <td class="auto-style8">
                                                          &nbsp;</td>
                                                      <td class="auto-style8">&nbsp;</td>
                                                      <td class="auto-style5">
                                                          <asp:Label ID="Label24" runat="server"></asp:Label>
                                                      </td>
                                                      <td class="auto-style5">
                                                          <asp:Label ID="Label32" runat="server" Text="ID" Visible="False"></asp:Label>
                                                          <asp:Label ID="Label27" runat="server" Text="Orden"></asp:Label>
                                                      </td>
                                                      <td class="auto-style5">
                                                          <asp:Label ID="Label31" runat="server" Text="Cliente"></asp:Label>
                                                      </td>
                                                      <td class="auto-style5">
                                                          <asp:Label ID="Label30" runat="server" Text="Telefono"></asp:Label>
                                                      </td>
                                                      <td class="auto-style7">
                                                          <asp:Label ID="Label29" runat="server" Text="Direccion"></asp:Label>
                                                      </td>
                                                      <td class="auto-style5">
                                                          <asp:Label ID="Label28" runat="server" Text="Numero Casa"></asp:Label>
                                                      </td>
                                                     
                                                      <td class="auto-style5">
                                                          <asp:Label ID="Label26" runat="server" Text="Visitas"></asp:Label>
                                                      </td>
                                                      <td class="auto-style5">
                                                          <asp:Label ID="Label25" runat="server" Text="Rentas"></asp:Label>
                                                      </td>
                                                  </tr>
                                              </table>
                                          </HeaderTemplate>
                                          <ItemStyle BackColor="#FFFBD6" ForeColor="#333333" />
                                          <ItemTemplate>
                                              <table style="width:100%;">
                                                  <tr>
                                                      <td class="auto-style8">
                                                          <asp:Button ID="Button6" runat="server" Text="Chofer 1" CommandName="chofer1" />
                                                      </td>
                                                      <td class="auto-style8">
                                                          <asp:Button ID="Button7" runat="server" Text="Chofer 2" CommandName="chofer2" />
                                                      </td>
                                                      <td class="auto-style5">
                                                          <asp:Button ID="Button4" runat="server" CommandName="captura" Text="Aqui abajo" Visible="False" />
                                                      </td>
                                                      <td class="auto-style5">
                                                          <asp:Label ID="Label14" runat="server" Text='<%# Eval("id") %>' Visible="False"></asp:Label>
                                                          <asp:Label ID="Label19" runat="server" Text='<%#Eval("orden") %>'></asp:Label>
                                                      </td>
                                                      <td class="auto-style5">
                                                          <asp:Label ID="Label17" runat="server" Text='<%#Eval("cliente") %>'></asp:Label>
                                                      </td>
                                                      <td class="auto-style5">
                                                          <asp:Label ID="Label15" runat="server" Text='<%#Eval("telefono") %>'></asp:Label>
                                                      </td>
                                                      <td class="auto-style7">
                                                          <asp:Label ID="Label16" runat="server" Text='<%#Eval("direccion") %>'></asp:Label>
                                                      </td>
                                                      <td class="auto-style5">
                                                          <asp:Label ID="Label18" runat="server" Text='<%#Eval("num_casa") %>'></asp:Label>
                                                      </td>
                                                   
                                                      <td class="auto-style5">
                                                          <asp:Label ID="Label20" runat="server" Text='<%#Eval("visitado") %>'></asp:Label>
                                                      </td>
                                                      <td class="auto-style5">
                                                          <asp:Label ID="Label21" runat="server" Text='<%#Eval("rentas") %>'></asp:Label>
                                                      </td>
                                                  </tr>
                                              </table>
                                          </ItemTemplate>
                                          <SelectedItemStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                                      </asp:DataList>
                                            
                                      </asp:Panel>

                                  
                                <asp:HiddenField ID="HiddenField1" runat="server" />
                                <br />
                                <asp:Label ID="Label18" runat="server" Text="Id_seleccionado: "></asp:Label>
                        <asp:Label ID="Label17" runat="server" Font-Size="Medium" Font-Bold="True"></asp:Label>
						        <br />
                                <asp:Label ID="Label19" runat="server" Text="Orden: "></asp:Label>
                        <asp:Label ID="Label13" runat="server" Font-Size="Medium" Font-Bold="True"></asp:Label>
						        <br />
                                <asp:Label ID="Label20" runat="server" Text="# registro: "></asp:Label>
                        <asp:Label ID="Label21" runat="server" Font-Size="Medium" Font-Bold="True"></asp:Label>
						        <br />
                        <asp:Label ID="Label2" runat="server" Text="Fecha: " Font-Size="Medium" Font-Bold="True" Visible="False"></asp:Label>
						        &nbsp;<asp:TextBox ID="txt_fecha" runat="server" Enabled="False" Width="299px" Visible="False"></asp:TextBox>
					    <br />

                        <asp:Label ID="Label1" runat="server" Text="Nombre del cliente: " Font-Size="Medium" Font-Bold="True" Visible="False"></asp:Label>
								    &nbsp;<asp:TextBox ID="txt_nombre" runat="server" Font-Size="Large" Width="502px" Visible="False"></asp:TextBox>
						                    <br />
								<asp:Label ID="Label8" runat="server" Text="Teléfono: " Font-Size="Medium" Font-Bold="True" Visible="False"></asp:Label>
						        &nbsp;&nbsp; <asp:TextBox ID="txt_telefono" runat="server" Font-Size="Large" Width="299px" Visible="False"></asp:TextBox>
						                    <br />
                                            <asp:Label ID="Label9" runat="server" Text="Direccion: " Font-Size="Medium" Font-Bold="True" Visible="False"></asp:Label>

                                &nbsp;&nbsp; <asp:TextBox ID="txt_direccion" runat="server" TextMode="MultiLine" Height="71px" Width="409px" Font-Size="Large" Visible="False"></asp:TextBox>
								 <br />
								 <asp:Label ID="Label3" runat="server" Text="Casa: " Font-Size="Medium" Font-Bold="True" Visible="False"></asp:Label>

                                &nbsp;&nbsp; <asp:TextBox ID="txt_casa" runat="server" Font-Size="Large" Width="270px" Visible="False"></asp:TextBox>
                                <br />
								 <asp:Label ID="Label10" runat="server" Text="Longitud: " Font-Size="Medium" Enabled="False" Font-Bold="True" Visible="False"></asp:Label>

                                &nbsp;

                                <asp:TextBox ID="txt_longitud" runat="server" Font-Size="Large" Width="250px" Enabled="False" Visible="False"></asp:TextBox>
                                <br />
								 <asp:Label ID="Label11" runat="server" Text="Latitud: " Font-Size="Medium" Enabled="False" Font-Bold="True" Visible="False"></asp:Label>

                                &nbsp;

                                <asp:TextBox ID="txt_latitud" runat="server" Font-Size="Large" Width="261px" Enabled="False" Visible="False"></asp:TextBox>
                                <br />
								 <asp:Label ID="Label12" runat="server" Text="Visitas: " Font-Size="Medium" Font-Bold="True" Visible="False"></asp:Label>

                        &nbsp; <asp:DropDownList ID="DropDownList1" runat="server" Font-Size="Large" Visible="False">
                                    <asp:ListItem Value="0.5">1/2</asp:ListItem>
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
                                    <asp:ListItem>11</asp:ListItem>
                                    <asp:ListItem>12</asp:ListItem>
                                    <asp:ListItem>13</asp:ListItem>
                                    <asp:ListItem>14</asp:ListItem>
                                    <asp:ListItem>15</asp:ListItem>
                                </asp:DropDownList>

                        &nbsp;<asp:Label ID="Label23" runat="server" Text="Rentas: " Font-Size="Medium" Font-Bold="True" Visible="False"></asp:Label>

                                <asp:DropDownList ID="DropDownList2" runat="server" Font-Size="Large" Visible="False">
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
                                    <asp:ListItem>11</asp:ListItem>
                                    <asp:ListItem>12</asp:ListItem>
                                    <asp:ListItem>13</asp:ListItem>
                                    <asp:ListItem>14</asp:ListItem>
                                    <asp:ListItem>15</asp:ListItem>
                                </asp:DropDownList>

                        <br />
                                            <asp:Label ID="Label22" runat="server" Text="Comentarios: " Font-Size="Medium" Font-Bold="True" Visible="False"></asp:Label>

                                &nbsp;

                                <asp:TextBox ID="txt_comentarios" runat="server" TextMode="MultiLine" Height="71px" Width="409px" Font-Size="Large" Visible="False"></asp:TextBox>
                                <br />
                        <br />
                     <asp:Button ID="Button2" runat="server" Text="Guardar" Width="166px" Height="45px"  class="primary-btn text-uppercase" CssClass="auto-style1" Visible="False"/>

                        &nbsp;
                     <asp:Button ID="Button5" runat="server" Text="Guardar al final" Width="166px" Height="45px"  class="primary-btn text-uppercase" CssClass="auto-style1" Visible="False"/>

                        &nbsp;&nbsp;&nbsp;
                     <asp:Button ID="Button3" runat="server" Text="Regresar" Width="166px" Height="45px"  class="primary-btn text-uppercase" CssClass="auto-style1"/>

                                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:dp_recoleccion_conection %>" SelectCommand="SELECT * FROM [tt_cliente]"></asp:SqlDataSource>

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
