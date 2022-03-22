Imports System.Data

Imports System.Data.SqlClient
Partial Class _Default
    Inherits System.Web.UI.Page
    Dim visitado As Integer

    Private Sub _Default_Load(sender As Object, e As EventArgs) Handles Me.Load



        If Session("autorizado") = 1 Or Session("autorizado") = 2 Then
            If Not Page.IsPostBack Then
                Dim mes As String
                mes = Date.Now.Month
                Label9.Text = mes

                Dim data13 As SqlDataReader
                Dim mes_lista As Integer


                SqlDataSource2.SelectCommand = "SELECT max(mes) FROM  tt_lista  "
                SqlDataSource2.DataSourceMode = SqlDataSourceMode.DataReader
                data13 = SqlDataSource2.Select(DataSourceSelectArguments.Empty)

                If data13.Read Then
                    If Not IsDBNull(data13.GetValue(0)) Then
                        mes_lista = data13.GetValue(0)
                        If mes_lista = mes Then
                            'Dim data12 As SqlDataReader
                            'SqlDataSource2.SelectCommand = "SELECT id FROM  dbo.tt_cliente where visitas=visitado  "
                            'SqlDataSource2.DataSourceMode = SqlDataSourceMode.DataReader
                            'data12 = SqlDataSource2.Select(DataSourceSelectArguments.Empty)
                            'While data12.Read
                            '    SqlDataSource2.UpdateCommand = "update tt_lista set activo=0  where id_cliente='" & data12.GetValue(0) & "'"
                            '    SqlDataSource2.Update()
                            'End While
                            If Session("autorizado") = 1 Then
                                Dim data As SqlDataReader
                                SqlDataSource2.SelectCommand = "SELECT dbo.tt_lista.Id, dbo.tt_cliente.Id AS Expr2, dbo.tt_cliente.cliente + ' - ' + dbo.tt_cliente.direccion + ' - ' + dbo.tt_cliente.num_casa AS Expr1, dbo.tt_cliente.telefono, dbo.tt_lista.orden, dbo.tt_lista.activo FROM dbo.tt_lista INNER JOIN dbo.tt_cliente ON dbo.tt_lista.id_cliente = dbo.tt_cliente.Id WHERE (dbo.tt_lista.activo = 1) AND (dbo.tt_lista.mes = @mes) and dbo.tt_lista.chofer=0  ORDER BY dbo.tt_lista.orden"
                                SqlDataSource2.DataSourceMode = SqlDataSourceMode.DataReader
                                data = SqlDataSource2.Select(DataSourceSelectArguments.Empty)
                                Dim i As New ListItem
                                Dim contador = 0
                                While data.Read
                                    i = New ListItem(data.GetValue(2), data.GetValue(1))

                                    ddl_cliente.Items.Add(i)
                                    contador = contador + 1
                                End While
                                Label14.Text = contador
                                Dim data1 As SqlDataReader
                                SqlDataSource2.SelectCommand = "SELECT *  FROM dbo.tt_rentas WHERE cliente=" & ddl_cliente.SelectedItem.Value & " And mes = " & mes
                                SqlDataSource2.DataSourceMode = SqlDataSourceMode.DataReader
                                data1 = SqlDataSource2.Select(DataSourceSelectArguments.Empty)
                                DataList1.DataSource = data1
                                DataList1.DataBind()
                                data1.Close()
                            Else
                                Dim data As SqlDataReader
                                SqlDataSource2.SelectCommand = "SELECT dbo.tt_lista.Id, dbo.tt_cliente.Id AS Expr2, dbo.tt_cliente.cliente + ' - ' + dbo.tt_cliente.direccion + ' - ' + dbo.tt_cliente.num_casa AS Expr1, dbo.tt_cliente.telefono, dbo.tt_lista.orden, dbo.tt_lista.activo FROM dbo.tt_lista INNER JOIN dbo.tt_cliente ON dbo.tt_lista.id_cliente = dbo.tt_cliente.Id WHERE (dbo.tt_lista.activo = 1) AND (dbo.tt_lista.mes = @mes) and dbo.tt_lista.chofer=1   ORDER BY dbo.tt_lista.orden"
                                SqlDataSource2.DataSourceMode = SqlDataSourceMode.DataReader
                                data = SqlDataSource2.Select(DataSourceSelectArguments.Empty)
                                Dim i As New ListItem
                                While data.Read
                                    i = New ListItem(data.GetValue(2), data.GetValue(1))

                                    ddl_cliente.Items.Add(i)

                                End While
                                Dim data1 As SqlDataReader
                                SqlDataSource2.SelectCommand = "SELECT *  FROM dbo.tt_rentas WHERE cliente=" & ddl_cliente.SelectedItem.Value & " And mes = " & mes
                                SqlDataSource2.DataSourceMode = SqlDataSourceMode.DataReader
                                data1 = SqlDataSource2.Select(DataSourceSelectArguments.Empty)
                                DataList1.DataSource = data1
                                DataList1.DataBind()
                                data1.Close()
                            End If

                            If ddl_cliente.Items.Count <> 0 Then
                                Dim visitas4 As Integer
                                Dim data4 As SqlDataReader
                                SqlDataSource2.SelectCommand = "SELECT visitas,visitado,comentarios FROM dbo.tt_cliente WHERE id=" & ddl_cliente.SelectedItem.Value
                                SqlDataSource2.DataSourceMode = SqlDataSourceMode.DataReader
                                data4 = SqlDataSource2.Select(DataSourceSelectArguments.Empty)
                                While data4.Read
                                    Label11.Text = data4.GetValue(0)
                                    Label13.Text = data4.GetValue(1)
                                    TextBox1.Text = data4.GetValue(2)
                                End While
                                data4.Close()
                            End If
                            txt_fecha.Text = Date.Now
                            Dim fecha As Date
                            fecha = txt_fecha.Text
                            Dim day As Date
                            day = "01/01/" & Date.Now.Year
                            Calendar1.SelectedDate = Date.Now

                            Dim semana As Integer

                            semana = DateDiff("ww", day.ToString("yyyy-MM-dd"), fecha.ToString("yyyy-MM-dd"))
                            Label7.Text = Val(semana)
                        Else
                            SqlDataSource2.DeleteCommand = "delete  tt_lista "
                            SqlDataSource2.Delete()
                            SqlDataSource2.UpdateCommand = "update tt_cliente set visitado=0 "
                            SqlDataSource2.Update()

                        End If
                    End If

                Else
                        Dim lit As New Literal()
                    lit.Text = "<script language='javascript'>window.alert('" & "No esta cargada ninguna lista para este mes" & "')</script>"
                    Page.Controls.Add(lit)
                End If


            End If
        Else
            Response.Redirect("login.aspx")
            End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim fecha As Date
        fecha = txt_fecha.Text
        Dim cantidad As Double
        cantidad = ddl_num.SelectedValue * 150
        SqlDataSource2.InsertCommand = "insert into tt_recoleccion(id_cliente,fecha,cantidad,debe) values('" & ddl_cliente.SelectedValue & "', '" & fecha.ToString("yyyy-MM-dd HH:mm:ss") & "', '" & ddl_num.SelectedValue & "', '" & cantidad & "')"
        SqlDataSource2.Insert()

        ' insertamos el costo de la recoleccion 
        fecha = Date.Now
        SqlDataSource2.InsertCommand = "insert into tt_rentas(fecha,mes,pagado,cliente,cantidad,tipo) values ('" & fecha.ToString("yyyy-MM-dd HH:mm:ss") & "','" & fecha.Month & "', '" & 0 & "', '" & ddl_cliente.SelectedValue & "', '" & cantidad & "', '" & 1 & "')"
        SqlDataSource2.Insert()



        SqlDataSource2.UpdateCommand = "update tt_cliente set visitado=visitado + 1  where id='" & ddl_cliente.SelectedValue & "'"
        SqlDataSource2.Update()

        '  Response.Redirect("captura.aspx")
    End Sub

    Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If Session("autorizado") = 1 Then
            Session("autorizado") = 1
            Response.Redirect("menu_captura.aspx")
        End If
        If Session("autorizado") = 2 Then
            Session("autorizado") = 2
            Response.Redirect("menu_captura.aspx")
        End If
    End Sub

    Protected Sub ddl_cliente_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_cliente.SelectedIndexChanged
        Dim mes As String
        mes = Date.Now.Month
        Label9.Text = mes
        Dim visitas As Integer
        Dim data As SqlDataReader
        SqlDataSource2.SelectCommand = "SELECT visitas,visitado,comentarios FROM dbo.tt_cliente WHERE id=" & ddl_cliente.SelectedItem.Value


        SqlDataSource2.DataSourceMode = SqlDataSourceMode.DataReader
        data = SqlDataSource2.Select(DataSourceSelectArguments.Empty)
        While data.Read
            Label11.Text = data.GetValue(0)
            Label13.Text = data.GetValue(1)
            TextBox1.Text = data.GetValue(2)
        End While


        Dim data1 As SqlDataReader
        SqlDataSource2.SelectCommand = "SELECT *  FROM dbo.tt_rentas WHERE cliente=" & ddl_cliente.SelectedItem.Value & " And mes = " & mes
        SqlDataSource2.DataSourceMode = SqlDataSourceMode.DataReader
        data1 = SqlDataSource2.Select(DataSourceSelectArguments.Empty)
        DataList1.DataSource = data1
        DataList1.DataBind()
        data1.Close()
    End Sub
End Class
