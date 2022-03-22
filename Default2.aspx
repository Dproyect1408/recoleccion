<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default2.aspx.vb" Inherits="Default2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
 
    <!--Boostrap y jquery-->
    <title>Ubicación Google Maps</title>
    <link rel="stylesheet" href="https://netdna.bootstrapcdn.com/bootstrap/3.0.3/css/bootstrap.min.css" />
    <link rel="stylesheet" href="https://netdna.bootstrapcdn.com/bootstrap/3.0.3/css/bootstrap-theme.min.css" />
    <script src="https://code.jquery.com/jquery-1.10.2.min.js"></script>
    <script src="https://netdna.bootstrapcdn.com/bootstrap/3.0.3/js/bootstrap.min.js"></script>
 
 
    <!-- inclucion de complemento-->
    <script src="js/locationpicker.jquery.js"></script>
 

    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyBUR13VSUWRf3mQMhIAh224YkGLfPPgrHM"></script>
</head>
<body>

    <form id="form1" runat="server">
        <div class="container">
 
            <button type="button" data-toggle="modal" data-target="#ModalMap" class="btn btn-default">
                <span class="glyphicon glyphicon-map-marker"></span><span id="ubicacion">Seleccionar Ubicacion</span>
 
            </button>
          <style>
                    .pac-container {
                        z-index: 99999;
                    }
                </style>
            <div class="modal fade" id="ModalMap" tabindex="-1" role="dialog">
       
                <div class="modal-dialog" role="document">
                    <div class="modal-content">
                        <div class="modal-body">
                            <div class="form-horizontal">
                                <div class="form-group">
                                    <label class="col-sm-2 control-label">Ubicación:</label>
                                    <div class="col-sm-9">
                                        <asp:TextBox ID="ModalMapaddress" CssClass="form-control " runat="server"></asp:TextBox>
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
                                          <asp:TextBox ID="ModalMapLat" CssClass="form-control " runat="server"></asp:TextBox>
                                                                           </div>
                                   <label class="p-r-small col-sm-1 control-label">Lat.:</label>
                                    <div class="col-sm-3">
                                          <asp:TextBox ID="ModalMapLon" CssClass="form-control " runat="server"></asp:TextBox>
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
                                        enableAutocomplete: true,
                                        inputBinding: {
                                            latitudeInput: $('#<%=ModalMapLat.ClientID%>'),
                                            longitudeInput: $('#<%=ModalMapLon.ClientID%>'),
                                            locationNameInput: $('#<%=ModalMapaddress.ClientID%>')
                                        },
                                        enableAutocomplete: true,
                                        onchanged: function (currentLocation, radius, isMarkerDropped) {
                                            $('#ubicacion').html($('#<%=ModalMapaddress.ClientID%>').val());
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
    </form>
</body>
</html>
