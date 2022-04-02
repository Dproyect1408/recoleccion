Imports System.Data
Imports System.Data.SqlClient
Partial Class _Default
    Inherits System.Web.UI.Page
    Dim miDataTable As New DataTable
    Private Sub _Default_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("autorizado") = 0 Then
        Else
            Response.Redirect("login.aspx")
        End If
        If Not Page.IsPostBack Then
            Session("contador") = 0
            Session("contador1") = 0
            Dim lit As New Literal()
            lit.Text = "<script language='javascript'>window.alert('" & "Estas a punto de generar otras listas, ten cuidado porque se borrara la que ya esta en uso" & "')</script>"
            Page.Controls.Add(lit)
        End If
    End Sub
    Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Session("autorizado") = 0
        Response.Redirect("menu.aspx")
    End Sub
    Private Sub DataList1_ItemCommand(source As Object, e As DataListCommandEventArgs) Handles DataList1.ItemCommand
        If e.CommandName = "captura" Then
            Dim id As Integer
            id = DataList1.DataKeys(e.Item.ItemIndex)
            Dim cliente As Label = DataList1.Items(e.Item.ItemIndex).FindControl("clienteLabel")
            Dim cliente1 As Label = DataList1.Items(e.Item.ItemIndex).FindControl("telefonoLabel")
            Dim cliente2 As Label = DataList1.Items(e.Item.ItemIndex).FindControl("direccionLabel")
            Dim cliente3 As Label = DataList1.Items(e.Item.ItemIndex).FindControl("Num_casaLabel")
            If cliente.BackColor = Drawing.Color.GreenYellow Then
                cliente.BackColor = Drawing.Color.LightBlue
            Else
                cliente.BackColor = Drawing.Color.GreenYellow

            End If
            If cliente1.BackColor = Drawing.Color.GreenYellow Then
                cliente1.BackColor = Drawing.Color.LightBlue
            Else
                cliente1.BackColor = Drawing.Color.GreenYellow

            End If
            If cliente2.BackColor = Drawing.Color.GreenYellow Then
                cliente2.BackColor = Drawing.Color.LightBlue
            Else
                cliente2.BackColor = Drawing.Color.GreenYellow

            End If
            If cliente3.BackColor = Drawing.Color.GreenYellow Then
                cliente3.BackColor = Drawing.Color.LightBlue
            Else
                cliente3.BackColor = Drawing.Color.GreenYellow

            End If

            Dim data As SqlDataReader
                Dim fecha As Date
                fecha = Date.Now
                SqlDataSource2.SelectCommand = "SELECT id,cliente,telefono,direccion,num_casa,telefono FROM tt_cliente where id='" & id & "'"
                SqlDataSource2.DataSourceMode = SqlDataSourceMode.DataReader
                data = SqlDataSource2.Select(DataSourceSelectArguments.Empty)
                While data.Read
                    SqlDataSource3.InsertCommand = "insert into tt_lista([id_cliente],[orden],[activo],[fecha],recoleccion) values ('" & id & "','" & Session("contador") & "', '" & 1 & "', '" & fecha.ToString("yyyy-MM-dd") & "', '" & 0 & "')"
                    SqlDataSource3.Insert()
                    Session("contador") = Session("contador") + 1
                End While

                SqlDataSource2.SelectCommand = "SELECT dbo.tt_lista.Id, dbo.tt_cliente.cliente, dbo.tt_cliente.telefono, dbo.tt_cliente.direccion, dbo.tt_cliente.num_casa, dbo.tt_lista.orden FROM dbo.tt_lista INNER JOIN dbo.tt_cliente ON dbo.tt_lista.id_cliente = dbo.tt_cliente.Id ORDER BY dbo.tt_lista.orden asc"
                SqlDataSource2.DataSourceMode = SqlDataSourceMode.DataReader
                data = SqlDataSource2.Select(DataSourceSelectArguments.Empty)
                DataList2.DataSource = data
                DataList2.DataBind()

            End If
    End Sub
    Protected Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim data As SqlDataReader
        DataList2.Visible = True
        SqlDataSource2.DeleteCommand = "delete tt_lista"
        SqlDataSource2.Delete()
        SqlDataSource2.UpdateCommand = "update tt_cliente set visitado='" & 0 & "'"
        SqlDataSource2.Update()
        SqlDataSource2.SelectCommand = "SELECT id,cliente,telefono,direccion,num_casa,orden FROM tt_cliente ORDER BY [orden]"
        SqlDataSource2.DataSourceMode = SqlDataSourceMode.DataReader
        data = SqlDataSource2.Select(DataSourceSelectArguments.Empty)
        DataList1.DataSource = data
        DataList1.DataBind()
        data.Close()
        Dim fecha As Date
        fecha = Date.Now
        Dim data1 As SqlDataReader
        Dim renta As Double

        SqlDataSource2.SelectCommand = "SELECT id,rentas FROM tt_cliente  where rentas > 0 ORDER BY [orden]"
        SqlDataSource2.DataSourceMode = SqlDataSourceMode.DataReader
        data1 = SqlDataSource2.Select(DataSourceSelectArguments.Empty)
        DataList1.DataSource = data1
        If data1.Read Then
            renta = 0
            'se agrega costo de la renta
            renta = data1.GetValue(1) * 100
            SqlDataSource3.InsertCommand = "insert into tt_rentas(fecha,mes,pagado,cliente,cantidad,tipo,imprimir) values ('" & fecha.ToString("yyyy-MM-dd HH:mm:ss") & "','" & fecha.Month & "', '" & 0 & "', '" & data1.GetValue(0) & "', '" & renta & "', '" & 0 & "', '" & 0 & "')"
            SqlDataSource3.Insert()
        End If
        data1.Close()

    End Sub

    Protected Sub DataList2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DataList2.SelectedIndexChanged

    End Sub

    Private Sub DataList2_DeleteCommand(source As Object, e As DataListCommandEventArgs) Handles DataList2.DeleteCommand

    End Sub

    Private Sub DataList2_ItemCommand(source As Object, e As DataListCommandEventArgs) Handles DataList2.ItemCommand

        If e.CommandName = "borrar" Then
            Dim id As Integer
            Dim data As SqlDataReader
            id = DataList2.DataKeys(e.Item.ItemIndex)
            SqlDataSource2.DeleteCommand = "delete tt_lista  where id='" & id & "'"
            SqlDataSource2.Delete()
            SqlDataSource2.SelectCommand = "SELECT dbo.tt_lista.Id, dbo.tt_cliente.cliente, dbo.tt_cliente.telefono, dbo.tt_cliente.direccion, dbo.tt_cliente.num_casa, dbo.tt_lista.orden,  dbo.tt_lista.chofer FROM dbo.tt_lista INNER JOIN dbo.tt_cliente ON dbo.tt_lista.id_cliente = dbo.tt_cliente.Id  and dbo.tt_lista.chofer = 0 ORDER BY dbo.tt_lista.orden asc"
            SqlDataSource2.DataSourceMode = SqlDataSourceMode.DataReader
            data = SqlDataSource2.Select(DataSourceSelectArguments.Empty)
            DataList2.DataSource = data
            DataList2.DataBind()
            data.Close()

        End If
        If e.CommandName = "up" Then
            Dim id As Integer
            Dim orden, orden_ant As Integer
            orden = 0
            orden_ant = 0
            Dim data, data1, d1, d2 As SqlDataReader
            id = DataList2.DataKeys(e.Item.ItemIndex)
            'SqlDataSource2.DeleteCommand = "delete tt_lista  where id='" & id & "'"
            'SqlDataSource2.Delete()
            SqlDataSource2.SelectCommand = "select orden from tt_lista where id='" & id - 1 & "'"
            SqlDataSource2.DataSourceMode = SqlDataSourceMode.DataReader
            data1 = SqlDataSource2.Select(DataSourceSelectArguments.Empty)
            If data1.Read Then
                SqlDataSource2.SelectCommand = "select orden from tt_lista where id='" & id & "'"
                SqlDataSource2.DataSourceMode = SqlDataSourceMode.DataReader
                d1 = SqlDataSource2.Select(DataSourceSelectArguments.Empty)
                If d1.Read Then
                    orden = d1.GetValue(0)
                End If
                d1.Close()
                orden_ant = data1.GetValue(0)
                SqlDataSource2.UpdateCommand = "update tt_lista set orden='" & orden_ant & "' where id='" & id & "'"
                SqlDataSource2.Update()
                SqlDataSource2.UpdateCommand = "update tt_lista set orden='" & orden & "' where id='" & id - 1 & "'"
                SqlDataSource2.Update()
                SqlDataSource2.SelectCommand = "SELECT dbo.tt_lista.Id, dbo.tt_cliente.cliente, dbo.tt_cliente.telefono, dbo.tt_cliente.direccion, dbo.tt_cliente.num_casa, dbo.tt_lista.orden,  dbo.tt_lista.chofer FROM dbo.tt_lista INNER JOIN dbo.tt_cliente ON dbo.tt_lista.id_cliente = dbo.tt_cliente.Id  and dbo.tt_lista.chofer = 0 ORDER BY dbo.tt_lista.orden asc"
                SqlDataSource2.DataSourceMode = SqlDataSourceMode.DataReader
                data = SqlDataSource2.Select(DataSourceSelectArguments.Empty)
                DataList2.DataSource = data
                DataList2.DataBind()
                data.Close()

            End If



        End If
        If e.CommandName = "down" Then
            Dim id As Integer
            Dim data As SqlDataReader
            id = DataList2.DataKeys(e.Item.ItemIndex)
            SqlDataSource2.DeleteCommand = "delete tt_lista  where id='" & id & "'"
            SqlDataSource2.Delete()
            SqlDataSource2.SelectCommand = "SELECT dbo.tt_lista.Id, dbo.tt_cliente.cliente, dbo.tt_cliente.telefono, dbo.tt_cliente.direccion, dbo.tt_cliente.num_casa, dbo.tt_lista.orden FROM dbo.tt_lista INNER JOIN dbo.tt_cliente ON dbo.tt_lista.id_cliente = dbo.tt_cliente.Id ORDER BY dbo.tt_lista.orden asc"
            SqlDataSource2.DataSourceMode = SqlDataSourceMode.DataReader
            data = SqlDataSource2.Select(DataSourceSelectArguments.Empty)
            DataList2.DataSource = data
            DataList2.DataBind()
            data.Close()

        End If
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim fecha As Date
        fecha = Date.Now
        Dim mes As String
        mes = Date.Now.Month
        Dim fecha_inicial As Date
        Dim fe As String
        fe = "01/" & "01/" & Date.Now.Year
        fecha_inicial = fe
        Dim semana As String
        semana = DateDiff("ww", fecha_inicial, fecha.ToString("yyyy-MM-dd"))
        ' Dim fecha As Date
        fecha = Date.Today
        For x = 0 To DataList2.Items.Count - 1
            Dim cliente As Label = DataList2.Items(x).FindControl("clienteLabel2")
            Dim telefono As Label = DataList2.Items(x).FindControl("telefonoLabel1")
            Dim direccion As Label = DataList2.Items(x).FindControl("direccionLabel1")
            Dim casa As Label = DataList2.Items(x).FindControl("num_casaLabel1")
            Dim orden As Label = DataList2.Items(x).FindControl("ordenLabel")
            SqlDataSource3.InsertCommand = "insert into tt_lista_rom(cliente,telefono,direccion,numero,orden,fecha,tipo,chofer,mes,semana) values ('" & cliente.Text & "','" & telefono.Text & "', '" & direccion.Text & "', '" & casa.Text & "', '" & orden.Text & "', '" & fecha.ToString("yyyy-MM-dd") & "','" & 0 & "','" & 0 & "','" & mes & "','" & semana & "')"
            SqlDataSource3.Insert()

        Next

        For x = 0 To DataList3.Items.Count - 1
            Dim cliente As Label = DataList3.Items(x).FindControl("clienteLabel1")
            Dim telefono As Label = DataList3.Items(x).FindControl("telefonoLabel0")
            Dim direccion As Label = DataList3.Items(x).FindControl("direccionLabel0")
            Dim casa As Label = DataList3.Items(x).FindControl("num_casaLabel0")
            Dim orden As Label = DataList3.Items(x).FindControl("ordenLabel0")
            SqlDataSource3.InsertCommand = "insert into tt_lista_rom(cliente,telefono,direccion,numero,orden,fecha,tipo,chofer,mes,semana) values ('" & cliente.Text & "','" & telefono.Text & "', '" & direccion.Text & "', '" & casa.Text & "', '" & orden.Text & "', '" & fecha.ToString("yyyy-MM-dd") & "','" & 0 & "','" & 1 & "','" & mes & "','" & semana & "')"
            SqlDataSource3.Insert()

        Next

        Response.Write("<script> window.open('" + "imprimir.aspx" + "','_blank'); </script>")
        Response.Write("<script> window.open('" + "imprimir1.aspx" + "','_blank'); </script>")
    End Sub

    Protected Sub DataList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DataList1.SelectedIndexChanged

    End Sub

    Protected Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Dim fecha As Date
        fecha = Date.Now
        Dim mes As String
        mes = Date.Now.Month
        Dim fecha_inicial As Date
        Dim fe As String
        fe = "01/" & "01/" & Date.Now.Year
        fecha_inicial = fe
        Dim semana As String
        semana = DateDiff("ww", fecha_inicial, fecha.ToString("yyyy-MM-dd"))
        'SqlDataSource2.DeleteCommand = "delete tt_lista "
        'SqlDataSource2.Delete()
        For x = 0 To DataList1.Items.Count - 1
            Dim check As CheckBox = DataList1.Items(x).FindControl("CheckBox1")
            Dim check1 As CheckBox = DataList1.Items(x).FindControl("CheckBox2")
            Dim id As Label = DataList1.Items(x).FindControl("clienteLabel0")
            Dim cliente As Label = DataList1.Items(x).FindControl("clienteLabel")
            Dim telefono As Label = DataList1.Items(x).FindControl("telefonoLabel")
            Dim direccion As Label = DataList1.Items(x).FindControl("direccionLabel")
            Dim casa As Label = DataList1.Items(x).FindControl("num_casaLabel")
            If check.Checked = True And check1.Checked = True Then
                Dim lit As New Literal()
                lit.Text = "<script language='javascript'>window.alert('" & "Favor de revisar los registros, un cliente esta asignado a los dos choferes" & "')</script>"
                Page.Controls.Add(lit)
            Else
                If check.Checked = True Then
                    SqlDataSource3.InsertCommand = "insert into tt_lista([id_cliente],[orden],[activo],[fecha],recoleccion,chofer,mes,semana) values ('" & id.Text & "','" & Session("contador") & "', '" & 1 & "', '" & fecha.ToString("yyyy-MM-dd") & "', '" & 0 & "', '" & 0 & "', '" & mes & "','" & semana & "')"
                    SqlDataSource3.Insert()
                    Session("contador") = Session("contador") + 1
                End If
                If check1.Checked = True Then
                    SqlDataSource3.InsertCommand = "insert into tt_lista([id_cliente],[orden],[activo],[fecha],recoleccion,chofer,mes,semana) values ('" & id.Text & "','" & Session("contador1") & "', '" & 1 & "', '" & fecha.ToString("yyyy-MM-dd") & "', '" & 0 & "', '" & 1 & "', '" & mes & "','" & semana & "')"
                    SqlDataSource3.Insert()
                    Session("contador1") = Session("contador1") + 1
                End If
            End If

        Next
        Dim data As SqlDataReader
        SqlDataSource2.SelectCommand = "SELECT dbo.tt_lista.Id, dbo.tt_cliente.cliente, dbo.tt_cliente.telefono, dbo.tt_cliente.direccion, dbo.tt_cliente.num_casa, dbo.tt_lista.orden,  dbo.tt_lista.chofer FROM dbo.tt_lista INNER JOIN dbo.tt_cliente ON dbo.tt_lista.id_cliente = dbo.tt_cliente.Id  and dbo.tt_lista.chofer = 0 ORDER BY dbo.tt_lista.orden asc"
        SqlDataSource2.DataSourceMode = SqlDataSourceMode.DataReader
        Data = SqlDataSource2.Select(DataSourceSelectArguments.Empty)
        DataList2.DataSource = data
        DataList2.DataBind()

        Dim data1 As SqlDataReader
        SqlDataSource2.SelectCommand = "SELECT dbo.tt_lista.Id, dbo.tt_cliente.cliente, dbo.tt_cliente.telefono, dbo.tt_cliente.direccion, dbo.tt_cliente.num_casa, dbo.tt_lista.orden,  dbo.tt_lista.chofer FROM dbo.tt_lista INNER JOIN dbo.tt_cliente ON dbo.tt_lista.id_cliente = dbo.tt_cliente.Id  and dbo.tt_lista.chofer = 1 ORDER BY dbo.tt_lista.orden asc"
        SqlDataSource2.DataSourceMode = SqlDataSourceMode.DataReader
        data1 = SqlDataSource2.Select(DataSourceSelectArguments.Empty)
        DataList3.DataSource = data1
        DataList3.DataBind()

    End Sub



    Protected Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs)

    End Sub

    Protected Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs)

    End Sub

    Protected Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Dim a, b As Integer
        Dim porc As Double
        Dim lit As New Literal()
        lit.Text = "<script language='javascript'>window.alert('" & "Estas a punto de generar otras listas, ten cuidado porque se borrara la que ya esta en uso" & "')</script>"
        Page.Controls.Add(lit)
        a = DataList1.Items.Count
        porc = a * (TextBox1.Text / 100)
        b = Val(porc)
        For x = 0 To b - 1
            Dim check As CheckBox = DataList1.Items(x).FindControl("CheckBox1")
            check.Checked = True
            'Dim check1 As CheckBox = DataList1.Items(x).FindControl("CheckBox2")
        Next
        For y = b To DataList1.Items.Count - 1
            Dim check1 As CheckBox = DataList1.Items(y).FindControl("CheckBox2")
            check1.Checked = True

        Next
    End Sub
End Class
