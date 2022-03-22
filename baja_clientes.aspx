<%@ Page Language="VB" AutoEventWireup="false"  EnableEventValidation="false"  CodeFile="baja_clientes.aspx.vb" Inherits="_Default" %>

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
            }
            .auto-style6 {
                width: 10%;
            }
            .auto-style7 {
                width: 20%;
            }
            .auto-style8 {
                width: 10%;
            }
            .auto-style9 {
                width: 20%;
            }
            .auto-style10 {
                width: 15%;
            }
            .auto-style11 {
                width: 15%;
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
                    <section class="popular-destination-area section-gap">
				        <div class="container">
		                    <div class="row d-flex justify-content-center">
		                        <div class="auto-style1">
		                            <div class="title text-center" style="text-align: center">
		                                <h1 class="auto-style4">
                                            <asp:ScriptManager ID="ScriptManager1" runat="server">
                                            </asp:ScriptManager>
                                            Baja de Cliente</h1>
		                        <p style="color: #000000">Recolección de Basura y Renta de Contenedores<asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:dp_recoleccion_conection %>" SelectCommand="SELECT * FROM [tt_cliente] ORDER BY [orden]"></asp:SqlDataSource>
                                </p>
		                    </div>
		                </div>
		            </div>						
					<div class="row" style="text-align: center">
							<div class="col-lg-4 icon_box_col">
                                <asp:Button ID="Button3" runat="server" Height="74px" Text="Regresar al menu" Width="177px" Font-Bold="True" />
                                <br />
                                <br />
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="False" UpdateMode="Conditional">
                                    <ContentTemplate>
										<asp:Panel ID="Panel2" runat="server" ScrollBars="Vertical" Height="538px" Width="100%">
                                      <asp:DataList ID="DataList1" runat="server" Width="100%" DataKeyField="id" CellPadding="4" ForeColor="#333333" Height="533px">
                                          <AlternatingItemStyle BackColor="White" />
                                          <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                          <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                          <ItemStyle BackColor="#FFFBD6" ForeColor="#333333" />
                                          <ItemTemplate>
                                              <table style="width:100%;">
                                                  <tr>
                                                      <td class="auto-style5">
                                                          <asp:Button ID="Button4" runat="server" CommandName="captura" Text="Eliminar Cliente" OnClick="Button4_Click" />
                                                      </td>
                                                      <td class="auto-style6">
                                                          <asp:Button ID="Button5" runat="server" CommandName="Modificar" OnClick="Button5_Click" Text="Modificar Cliente" />
                                                      </td>
                                                      <td class="auto-style6">
                                                          <asp:Label ID="Label14" runat="server" Text='<%#Eval("id") %>'></asp:Label>
                                                      </td>
                                                      <td class="auto-style7">
                                                          <asp:Label ID="Label17" runat="server" Text='<%#Eval("cliente") %>'></asp:Label>
                                                      </td>
                                                      <td class="auto-style8">
                                                          <asp:Label ID="Label15" runat="server" Text='<%#Eval("telefono") %>'></asp:Label>
                                                      </td>
                                                      <td class="auto-style9">
                                                          <asp:Label ID="Label16" runat="server" Text='<%#Eval("direccion") %>'></asp:Label>
                                                      </td>
                                                      <td class="auto-style10">
                                                          <asp:Label ID="Label18" runat="server" Text='<%#Eval("num_casa") %>'></asp:Label>
                                                      </td>
                                                      <td class="auto-style11">
                                                          <asp:Label ID="Label19" runat="server" Text='<%#Eval("orden") %>'></asp:Label>
                                                      </td>
                                                  </tr>
                                              </table>
                                          </ItemTemplate>
                                          <SelectedItemStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                                      </asp:DataList>
                                            
                                      </asp:Panel>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <br />
                                  
                                <asp:HiddenField ID="HiddenField1" runat="server" />
                                <br />
						        <br />
                                <br />

                        &nbsp; 

                        &nbsp;<br />

                                &nbsp;

                                <br />
                        <br />

                        &nbsp;
                     
                        &nbsp;&nbsp;&nbsp;
                     
                                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:dp_recoleccion_conection %>" SelectCommand="SELECT * FROM [tt_cliente]"></asp:SqlDataSource>

                        <br />
				    <!-- Icon Box Item -->
					<div class="auto-style1">
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
