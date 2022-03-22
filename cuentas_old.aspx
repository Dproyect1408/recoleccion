<%@ Page Language="VB" AutoEventWireup="false" CodeFile="cuentas_old.aspx.vb" Inherits="_Default" %>

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
            .auto-style6 {
                width: 353px;
            }
            .auto-style7 {
                width: 561px;
            }
            .auto-style8 {
                margin-top: 0px;
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
		                        <h1 class="auto-style4">Cuentas</h1>
		                        <p style="color: #000000">Recolección de Basura y Renta de Contenedores</p>
		                    </div>
		                </div>
		            </div>						
					<div class="row">
							<div class="col-lg-4 icon_box_col">
                                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:dp_recoleccion_conection %>" SelectCommand="SELECT [cliente], [Id] FROM [tt_cliente]">
                                </asp:SqlDataSource>
                                <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:dp_recoleccion_conection %>" SelectCommand="SELECT * FROM [tt_recoleccion]">
                                </asp:SqlDataSource>
                                <br />
                        <asp:Label ID="Label2" runat="server" Text="Fecha" Font-Bold="True" Font-Size="X-Large"></asp:Label>
						        <br />
						        <asp:TextBox ID="txt_fecha" runat="server" Enabled="False" Width="208px" Font-Size="X-Large"></asp:TextBox>
					            <br />
                        <asp:Label ID="Label14" runat="server" Text="Cliente" Font-Bold="True" Font-Size="X-Large"></asp:Label>
                                <br />
					            <br />

                                <asp:DropDownList ID="ddl_cliente" runat="server" Height="34px" Width="50%" AutoPostBack="True" Font-Bold="True" Font-Size="Large" >
                                </asp:DropDownList>

                                <br />
                        <asp:Label ID="Label26" runat="server" Font-Bold="True" Font-Size="X-Large">Rentas</asp:Label>
								 :<asp:Label ID="Label25" runat="server" Font-Bold="True" Font-Size="X-Large"></asp:Label>
								 <br />
                                <table style="width:100%;">
                                    <tr>
                                        <td colspan="2">===================================================================================================================================================</td>
                                    </tr>
                                    <tr>
                                        <td>DEUDA</td>
                                        <td>PAGADO</td>
                                    </tr>
                                    <tr>
                                        <td>
                                <asp:DataList ID="DataList2" runat="server" DataKeyField="Id" Width="90%" CellPadding="4" ForeColor="#333333" CssClass="auto-style8">
                                    <AlternatingItemStyle BackColor="White" ForeColor="#284775" />
                                    <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
                                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                    <HeaderTemplate>
                                        <table style="width:100%;">
                                            <tr>
                                                <td  class="auto-style5">
                                                    <asp:Label ID="Label17" runat="server" Text="Fecha"></asp:Label>
                                                </td>
                                                <td  class="auto-style6">
                                                    <asp:Label ID="Label18" runat="server" Text="Rentas"></asp:Label>
                                                </td>
                                             
                                        
                                                <td class="auto-style6">
                                                    <asp:Label ID="Label19" runat="server" Text="Pagar" />
                                                </td>
                                             
                                        
                                            </tr>
                                        </table>
                                    </HeaderTemplate>
                                    <ItemStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                    <ItemTemplate>
                                        <table style="width:100%;">
                                            <tr>
                                         
                                                <td class="auto-style5">
                                                    <asp:Label ID="fechaLabel" runat="server" Text='<%# Eval("fecha") %>' />
                                                    <asp:Label ID="id" runat="server" Text='<%# Eval("id") %>' Visible="False" />
                                                </td>
                                                <td class="auto-style6">
                                                    <asp:Label ID="cantidadLabel" runat="server" Text='<%# Eval("cantidad") %>' />
                                                </td>
                                               
                                     
                                                <td class="auto-style6">
                                                    <asp:Button ID="Button4" runat="server" CommandName="pagar" OnClick="Button4_Click" Text="Pagar" Visible="False" />
                                                </td>
                                               
                                     
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                    <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                </asp:DataList>
                                        </td>
                                        <td>
                                <asp:DataList ID="DataList3" runat="server" DataKeyField="Id" Width="90%" CellPadding="4" ForeColor="#333333" CssClass="auto-style8">
                                    <AlternatingItemStyle BackColor="White" />
                                    <FooterStyle BackColor="#1C5E55" ForeColor="White" Font-Bold="True" />
                                    <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                    <HeaderTemplate>
                                        <table style="width:100%;">
                                            <tr>
                                                <td  class="auto-style5">
                                                    <asp:Label ID="Label17" runat="server" Text="Fecha"></asp:Label>
                                                </td>
                                                <td  class="auto-style6">
                                                    <asp:Label ID="Label18" runat="server" Text="Rentas"></asp:Label>
                                                </td>
                                             
                                        
                                               
                                             
                                        
                                            </tr>
                                        </table>
                                    </HeaderTemplate>
                                    <ItemStyle BackColor="#E3EAEB" />
                                    <ItemTemplate>
                                        <table style="width:100%;">
                                            <tr>
                                         
                                                <td class="auto-style5">
                                                    <asp:Label ID="fechaLabel" runat="server" Text='<%# Eval("fecha") %>' />
                                                    <asp:Label ID="id" runat="server" Text='<%# Eval("fecha") %>' />
                                                </td>
                                                <td class="auto-style6">
                                                    <asp:Label ID="cantidadLabel" runat="server" Text='<%# Eval("cantidad") %>' />
                                                </td>
                                               
                                     
                                              
                                               
                                     
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                    <SelectedItemStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                                </asp:DataList>
                                        </td>
                                    </tr>
                                </table>
								 <br />
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
                                                <td  class="auto-style6">
                                                    <asp:Label ID="Label18" runat="server" Text="Contenedores"></asp:Label>
                                                </td>
                                                <td  class="auto-style7">
                                                    <asp:Label ID="Label19" runat="server" Text="$$$$$"></asp:Label>
                                                </td>
                                        
                                            </tr>
                                        </table>
                                    </HeaderTemplate>
                                    <ItemStyle BackColor="White" ForeColor="#330099" />
                                    <ItemTemplate>
                                        <table style="width:100%;">
                                            <tr>
                                         
                                                <td class="auto-style5">
                                                    <asp:Label ID="fechaLabel" runat="server" Text='<%# Eval("fecha") %>' />
                                                </td>
                                                <td class="auto-style6">
                                                    <asp:Label ID="cantidadLabel" runat="server" Text='<%# Eval("cantidad") %>' />
                                                </td>
                                                <td class="auto-style7">
                                                    <asp:Label ID="debeLabel" runat="server" Text='<%# Eval("debe") %>' />
                                                </td>
                                     
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                    <SelectedItemStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                                </asp:DataList>
                                <br />

                                <asp:Label ID="Label27" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Rentas:"></asp:Label>
                                <asp:Label ID="Label28" runat="server" Font-Bold="True" Font-Size="X-Large" ForeColor="Red" Text="Label"></asp:Label>
                                <br />

                                <asp:Label ID="Label20" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Deuda: "></asp:Label>
                                <asp:Label ID="Label21" runat="server" Font-Bold="True" Font-Size="X-Large" ForeColor="Red" Text="Label"></asp:Label>
                                <br />
                                <asp:Label ID="Label23" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Abono:"></asp:Label>
&nbsp;<asp:Label ID="Label24" runat="server" Font-Bold="True" Font-Size="X-Large" ForeColor="#009933" Text="Label"></asp:Label>
                                <br />
                                <br />
                                <asp:Label ID="Label22" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Abonar :"></asp:Label>
                                <asp:TextBox ID="TextBox1" runat="server" Font-Size="X-Large" Height="26px" Width="329px">0</asp:TextBox>

                                <br />
                                <asp:Label ID="Label29" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Total deuda:"></asp:Label>
&nbsp;<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:Label ID="Label30" runat="server" Font-Bold="True" Font-Size="X-Large" ForeColor="#009933" Text="Label"></asp:Label>
                                    </ContentTemplate>
                                </asp:UpdatePanel>

                                <br />
                                <br />
                                <br />

                     <asp:Button ID="Button2" runat="server" Text="Abonar e Imprimir" Width="25%"  class="primary-btn text-uppercase" CssClass="auto-style1" Height="123px" Font-Size="X-Large" ForeColor="#00CC00"/>

                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                                <asp:Button ID="Button5" runat="server" Text="Recibo" Font-Size="X-Large" ForeColor="#00CC00" Height="121px" Width="183px" Visible="False" />

                                <br />
                                <br />
                                <asp:Button ID="Button3" runat="server" Text="Salir" Width="25%"  class="primary-btn text-uppercase" CssClass="auto-style1" Height="123px" Font-Size="X-Large" ForeColor="Red"/>

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
