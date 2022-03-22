Imports System.Data

Imports System.Data.SqlClient
Partial Class _Default
    Inherits System.Web.UI.Page

    Private Sub _Default_Load(sender As Object, e As EventArgs) Handles Me.Load
        txt_fecha.Text = Date.Now
        'DataList1.DataSource = SqlDataSource3
        'DataList1.DataBind()
        If Session("autorizado") = 0 Then

        Else
            Response.Redirect("login.aspx")
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim fecha As Date
        Dim max As Integer
        fecha = txt_fecha.Text
        'Dim d1 As SqlDataReader
        'SqlDataSource2.SelectCommand = "select max(id) from tt_cliente"
        'SqlDataSource2.DataSourceMode = SqlDataSourceMode.DataReader
        'd1 = SqlDataSource2.Select(DataSourceSelectArguments.Empty)
        'For x = 0 To DataList1.Items.Count - 1
        '    Dim cliente As Label = DataList1.Items(x).FindControl("clienteLabel")
        '    Dim telefono As Label = DataList1.Items(x).FindControl("telefonoLabel")
        '    Dim direccion As Label = DataList1.Items(x).FindControl("direccionLabel")
        '    Dim casa As Label = DataList1.Items(x).FindControl("num_casaLabel")
        '    Dim orden As Label = DataList1.Items(x).FindControl("ordenLabel")
        '    SqlDataSource3.InsertCommand = "insert into tt_lista_rom(cliente,telefono,direccion,numero,orden,fecha,tipo) values ('" & cliente.Text & "','" & telefono.Text & "', '" & direccion.Text & "', '" & casa.Text & "', '" & orden.Text & "', '" & fecha.ToString("yyyy-MM-dd") & "','" & 0 & "')"
        '    SqlDataSource3.Insert()

        'Next
        SqlDataSource2.InsertCommand = "insert into tt_cliente(cliente,telefono,direccion,num_casa,longitud,latitud,visitas,fecha,comentarios,orden,rentas,saldo) values('" & txt_nombre.Text & "', '" & txt_telefono.Text & "', '" & txt_direccion.Text & "','" & txt_casa.Text & "','" & txt_longitud.Text & "','" & txt_latitud.Text & "','" & DropDownList1.SelectedValue & "','" & fecha.ToString("yyyy-MM-dd") & "','" & txt_comentarios.Text & "','" & Label13.Text + 1 & "','" & DropDownList2.SelectedValue & "','" & 0 & "')"
        SqlDataSource2.Insert()
        Dim contador As Integer
        contador = Label13.Text + 2
        For z = Val(Label21.Text) + 1 To DataList1.Items.Count - 1
            Dim id As Label = DataList1.Items(z).FindControl("Label14")
            SqlDataSource2.UpdateCommand = "update tt_cliente set orden='" & contador & "' where id='" & id.Text & "' "
            SqlDataSource2.Update()
            contador = contador + 1
        Next
        Response.Redirect("alta_cliente.aspx")
    End Sub

    Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Session("autorizado") = 0
        Response.Redirect("menu.aspx")
    End Sub


    Protected Sub DataList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DataList1.SelectedIndexChanged

    End Sub

    Private Sub DataList1_ItemCommand(source As Object, e As DataListCommandEventArgs) Handles DataList1.ItemCommand
        If e.CommandName = "captura" Then
            For x = 0 To DataList1.Items.Count - 1
                Dim c11 As Label = DataList1.Items(x).FindControl("Label14")
                Dim c21 As Label = DataList1.Items(x).FindControl("Label17")
                Dim c31 As Label = DataList1.Items(x).FindControl("Label15")
                Dim c41 As Label = DataList1.Items(x).FindControl("Label16")
                Dim c51 As Label = DataList1.Items(x).FindControl("Label18")
                Dim c61 As Label = DataList1.Items(x).FindControl("Label19")
                c11.BackColor = Nothing
                c21.BackColor = Nothing
                c31.BackColor = Nothing
                c41.BackColor = Nothing
                c51.BackColor = Nothing
                c61.BackColor = Nothing
            Next


            Dim id As Integer
            id = DataList1.DataKeys(e.Item.ItemIndex)
            Dim c1 As Label = DataList1.Items(e.Item.ItemIndex).FindControl("Label14")
            Dim c2 As Label = DataList1.Items(e.Item.ItemIndex).FindControl("Label17")
            Dim c3 As Label = DataList1.Items(e.Item.ItemIndex).FindControl("Label15")
            Dim c4 As Label = DataList1.Items(e.Item.ItemIndex).FindControl("Label16")
            Dim c5 As Label = DataList1.Items(e.Item.ItemIndex).FindControl("Label18")
            Dim c6 As Label = DataList1.Items(e.Item.ItemIndex).FindControl("Label19")


            c1.BackColor = Drawing.Color.GreenYellow
            c2.BackColor = Drawing.Color.GreenYellow
            c3.BackColor = Drawing.Color.GreenYellow
            c4.BackColor = Drawing.Color.GreenYellow
            c5.BackColor = Drawing.Color.GreenYellow
            c6.BackColor = Drawing.Color.GreenYellow

            Dim num As Integer
            num = e.Item.ItemIndex
            Dim orden As Label = DataList1.Items(e.Item.ItemIndex).FindControl("Label19")
            HiddenField1.Value = id
            Label13.Text = orden.Text
            Dim id_cambio As Label = DataList1.Items(num).FindControl("Label14")
            Label17.Text = id_cambio.Text
            Label21.Text = num
            Button2.Visible = True
            Button5.Visible = False
        End If

    End Sub

    Protected Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim fecha As Date
        Dim max As Integer
        fecha = txt_fecha.Text
        Dim d1 As SqlDataReader
        Dim orden_max As Integer
        SqlDataSource2.SelectCommand = "select max(orden) from tt_cliente"
        SqlDataSource2.DataSourceMode = SqlDataSourceMode.DataReader
        d1 = SqlDataSource2.Select(DataSourceSelectArguments.Empty)
        If d1.Read Then
            If IsDBNull(d1.GetValue(0)) Then
                orden_max = 0
            Else
                orden_max = d1.GetValue(0)
            End If

        Else
                orden_max = 0
        End If

        SqlDataSource2.InsertCommand = "insert into tt_cliente(cliente,telefono,direccion,num_casa,longitud,latitud,visitas,fecha,comentarios,orden,rentas) values('" & txt_nombre.Text & "', '" & txt_telefono.Text & "', '" & txt_direccion.Text & "','" & txt_casa.Text & "','" & txt_longitud.Text & "','" & txt_latitud.Text & "','" & DropDownList1.SelectedValue & "','" & fecha.ToString("yyyy-MM-dd") & "','" & txt_comentarios.Text & "','" & orden_max + 1 & "','" & DropDownList2.SelectedValue & "')"
        SqlDataSource2.Insert()
        Response.Redirect("alta_cliente.aspx")

    End Sub
End Class
