Imports System.Data
Imports System.Data.SqlClient
Partial Class _Default
    Inherits System.Web.UI.Page
    Dim visitado As Integer
    Private Sub _Default_Load(sender As Object, e As EventArgs) Handles Me.Load
        txt_fecha.Text = Date.Today
        If Not Page.IsPostBack Then
            If Session("autorizado") = 3 Then
                Label44.Text = 0
                Label46.Text = 0
                Label48.Text = 0
                TextBox1.Text = 0
                ddl_cliente.Items.Clear()
                Dim data As SqlDataReader
                SqlDataSource2.SelectCommand = "select * from tt_cliente order by orden"
                SqlDataSource2.DataSourceMode = SqlDataSourceMode.DataReader
                data = SqlDataSource2.Select(DataSourceSelectArguments.Empty)
                Dim i As New ListItem
                While data.Read
                    i = New ListItem(data.GetValue(1) + " - " + data.GetValue(3) + " - " + data.GetValue(4), data.GetValue(0))
                    ddl_cliente.Items.Add(i)
                End While
                Dim data1 As SqlDataReader
                SqlDataSource2.SelectCommand = "SELECT *  FROM dbo.tt_rentas WHERE cliente=" & ddl_cliente.SelectedItem.Value & " And pagado = " & 0
                SqlDataSource2.DataSourceMode = SqlDataSourceMode.DataReader
                data1 = SqlDataSource2.Select(DataSourceSelectArguments.Empty)
                DataList1.DataSource = data1
                DataList1.DataBind()
                data1.Close()
                Dim data3 As SqlDataReader
                SqlDataSource2.SelectCommand = "SELECT saldo,rentas FROM dbo.tt_cliente WHERE id=" & ddl_cliente.SelectedItem.Value
                SqlDataSource2.DataSourceMode = SqlDataSourceMode.DataReader
                data3 = SqlDataSource2.Select(DataSourceSelectArguments.Empty)
                If data3.Read Then
                    Label40.Text = data3.GetValue(0)
                    Label38.Text = data3.GetValue(1)
                End If
                data3.Close()
                Dim data33 As SqlDataReader
                SqlDataSource2.SelectCommand = "select distinct mes from tt_rentas WHERE cliente=" & ddl_cliente.SelectedItem.Value & " And pagado = " & 0
                SqlDataSource2.DataSourceMode = SqlDataSourceMode.DataReader
                data33 = SqlDataSource2.Select(DataSourceSelectArguments.Empty)
                Dim ii As New ListItem
                While data33.Read
                    ii = New ListItem(data33.GetValue(0))
                    DropDownList1.Items.Add(ii)
                End While
                data1.Close()
                ' para cargar deuda
                Dim cantidad As Integer = 0
                Dim rentas As Integer = 0
                For x = 0 To DataList1.Items.Count - 1
                    Dim mes As Label = DataList1.Items(x).FindControl("cantidadLabel0")
                    Dim cant As Label = DataList1.Items(x).FindControl("cantidadLabel")
                    Dim tipo As Label = DataList1.Items(x).FindControl("cantidadLabel1")
                    If mes.Text = DropDownList1.SelectedValue Then
                        If tipo.Text = 0 Then
                            rentas = rentas + cant.Text
                        Else
                            cantidad = cantidad + cant.Text
                        End If
                    End If
                Next
                Label44.Text = cantidad + rentas
                Label46.Text = rentas
                Label48.Text = cantidad                '-----------------------------------------------------------------------------------------------------------------------------------
                'Dim visitas As Integer
                '==============================================
                'Dim data4 As SqlDataReader
                'SqlDataSource2.SelectCommand = "SELECT *  FROM dbo.tt_rentas WHERE cliente='" & ddl_cliente.SelectedItem.Value & "' and pagado=0"
                'SqlDataSource2.DataSourceMode = SqlDataSourceMode.DataReader
                'data4 = SqlDataSource2.Select(DataSourceSelectArguments.Empty)
                'DataList2.DataSource = data4
                'DataList2.DataBind()
                'data4.Close()
                'Dim cantidad As Integer
                'cantidad = 0
                'For x = 0 To DataList2.Items.Count - 1
                '    Dim cant As Label = DataList2.Items(x).FindControl("cantidadLabel")
                '    cantidad = cantidad + cant.Text
                'Next
                'Label28.Text = cantidad * 100
                'Dim data6 As SqlDataReader
                'SqlDataSource2.SelectCommand = "SELECT *  FROM dbo.tt_rentas WHERE cliente='" & ddl_cliente.SelectedItem.Value & "' and pagado=1"
                'SqlDataSource2.DataSourceMode = SqlDataSourceMode.DataReader
                'data6 = SqlDataSource2.Select(DataSourceSelectArguments.Empty)
                'DataList3.DataSource = data6
                'DataList3.DataBind()
                'data6.Close()
                '=====================
            Else
                Response.Redirect("login.aspx")
            End If
            ' Label30.Text = (Val(Label28.Text) + Val(Label21.Text)) - Val(Label24.Text)
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'revisamos si es mayor  la cantidad abonada
        If TextBox1.Text <> 0 Or Label40.Text <> 0 Then
            Dim fecha As Date
            fecha = txt_fecha.Text
            Dim recibo As String
            recibo = TextBox1.Text
            Dim num As String
            Dim data33 As SqlDataReader
            SqlDataSource2.SelectCommand = "SELECT top 1 (id) FROM dbo.tt_rentas "
            SqlDataSource2.DataSourceMode = SqlDataSourceMode.DataReader
            data33 = SqlDataSource2.Select(DataSourceSelectArguments.Empty)
            If data33.Read Then
                num = data33.GetValue(0) + 1
            End If
            data33.Close()
            'si tiene saldo a favor o no
            Dim a, b, c As String
            Dim abono As String
            abono = TextBox1.Text
            If Label40.Text = 0 Then
                'se actualiza la tabla abomo con la cantidad de abonado 
                If (Val(TextBox1.Text) = Label44.Text) Then
                    SqlDataSource2.InsertCommand = "insert into tt_abonos(id_cliente,fecha,cantidad,renta,recoleccion) values('" & ddl_cliente.SelectedValue & "', '" & fecha.ToString("yyyy-MM-dd HH:mm:ss") & "', '" & Val(TextBox1.Text) & "', '" & Label46.Text & "', '" & Label48.Text & "')"
                    SqlDataSource2.Insert()
                    SqlDataSource2.UpdateCommand = "update tt_rentas set pagado='" & 1 & "', imprimir='" & 1 & "',cantidad_pagada=cantidad_pagada + cantidad, cantidad=0 where mes='" & DropDownList1.SelectedValue & "' and cliente='" & ddl_cliente.SelectedItem.Value & "'"
                    SqlDataSource2.Update()
                    SqlDataSource2.UpdateCommand = "update tt_cliente set saldo='" & 0 & "' where id='" & ddl_cliente.SelectedItem.Value & "'"
                    SqlDataSource2.Update()
                    a = "impresion_recibo.aspx?a=" + ddl_cliente.SelectedItem.Text + "&b=" + abono + "&c=" + Label46.Text + "&d=" + Label48.Text + "&e=" + DropDownList1.SelectedValue + "&f=" + num + "&g=" + ddl_cliente.SelectedValue
                    Dim script As String = " window.open('" + a + "','');"
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "popup", script, True)
                End If
                'si el abono es mayor se actualiza la tabla abonos con la cantidad de deuda y el resto se va a saldo a favor
                If (Val(TextBox1.Text) > Label44.Text) Then
                    Dim resto As Double
                    resto = (Val(TextBox1.Text)) - Val(Label44.Text)
                    SqlDataSource2.InsertCommand = "insert into tt_abonos(id_cliente,fecha,cantidad,renta,recoleccion) values('" & ddl_cliente.SelectedValue & "', '" & fecha.ToString("yyyy-MM-dd HH:mm:ss") & "', '" & Label44.Text & "', '" & Label46.Text & "', '" & Label48.Text & "')"
                    SqlDataSource2.Insert()
                    SqlDataSource2.UpdateCommand = "update tt_rentas set pagado='" & 1 & "', imprimir='" & 1 & "',cantidad_pagada= cantidad_pagada + cantidad, cantidad=0 where mes='" & DropDownList1.SelectedValue & "' and cliente='" & ddl_cliente.SelectedItem.Value & "'"
                    SqlDataSource2.Update()
                    SqlDataSource2.UpdateCommand = "update tt_cliente set saldo='" & resto & "' where id='" & ddl_cliente.SelectedItem.Value & "'"
                    SqlDataSource2.Update()
                    ' agrega el resto al envio por query en la literal h
                    a = "impresion_recibo.aspx?a=" + ddl_cliente.SelectedItem.Text + "&b=" + abono + "&c=" + Label46.Text + "&d=" + Label48.Text + "&e=" + DropDownList1.SelectedValue + "&f=" + num + "&g=" + ddl_cliente.SelectedValue
                    Dim script As String = " window.open('" + a + "','');"
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "popup", script, True)
                End If
                If (Val(TextBox1.Text) < Val(Label44.Text)) Then
                    Dim cantidad_pendiente As Double
                    cantidad_pendiente = Val(Label44.Text) - Val(TextBox1.Text)
                    SqlDataSource2.InsertCommand = "insert into tt_abonos(id_cliente,fecha,cantidad,renta,recoleccion) values('" & ddl_cliente.SelectedValue & "', '" & fecha.ToString("yyyy-MM-dd HH:mm:ss") & "', '" & TextBox1.Text & "', '" & Label46.Text & "', '" & Label48.Text & "')"
                    SqlDataSource2.Insert()
                    Dim renta(15, 15) As Integer
                    Dim contador As Integer
                    contador = 0


                    Dim data5 As SqlDataReader
                    SqlDataSource2.SelectCommand = "SELECT *  FROM dbo.tt_rentas WHERE cliente=" & ddl_cliente.SelectedItem.Value & " And pagado = " & 0 & " and tipo = " & 0
                    SqlDataSource2.DataSourceMode = SqlDataSourceMode.DataReader
                    data5 = SqlDataSource2.Select(DataSourceSelectArguments.Empty)
                    While data5.Read
                        renta(contador, 0) = data5.GetValue(0)
                        renta(contador, 1) = data5.GetValue(5)
                        contador += 1

                    End While

                    For x = 0 To contador
                        If Val(TextBox1.Text) > 0 Then
                            If renta(x, 1) > Val(TextBox1.Text) Then

                                SqlDataSource2.UpdateCommand = "update tt_rentas set cantidad_pagada= cantidad_pagada + '" & Val(TextBox1.Text) & "',cantidad= cantidad - '" & Val(TextBox1.Text) & "', imprimir='" & 1 & "'  where mes='" & DropDownList1.SelectedValue & "' and id='" & renta(x, 0) & "'"
                                SqlDataSource2.Update()
                                TextBox1.Text = 0
                            Else
                                SqlDataSource2.UpdateCommand = "update tt_rentas set pagado='" & 1 & "', imprimir='" & 1 & "', cantidad_pagada=cantidad_pagada + cantidad, cantidad=0 where mes='" & DropDownList1.SelectedValue & "' and id='" & renta(x, 0) & "'"
                                SqlDataSource2.Update()
                                TextBox1.Text -= renta(x, 1)
                            End If
                        End If
                    Next
                    If Val(TextBox1.Text) > 0 Then
                        Dim cobro(15, 15) As Integer
                        Dim contador1 As Integer
                        contador1 = 0
                        Dim data6 As SqlDataReader
                        SqlDataSource2.SelectCommand = "SELECT *  FROM dbo.tt_rentas WHERE cliente=" & ddl_cliente.SelectedItem.Value & " And pagado = " & 0 & " and tipo = " & 1
                        SqlDataSource2.DataSourceMode = SqlDataSourceMode.DataReader
                        data6 = SqlDataSource2.Select(DataSourceSelectArguments.Empty)
                        While data6.Read
                            cobro(contador1, 0) = data6.GetValue(0)
                            cobro(contador1, 1) = data6.GetValue(5)
                            contador1 += 1

                        End While
                        For x = 0 To contador1
                            If Val(TextBox1.Text) > 0 Then
                                If cobro(x, 1) > Val(TextBox1.Text) Then

                                    SqlDataSource2.UpdateCommand = "update tt_rentas set cantidad_pagada= cantidad_pagada + '" & Val(TextBox1.Text) & "',cantidad= cantidad - '" & Val(TextBox1.Text) & "', imprimir='" & 1 & "' where mes='" & DropDownList1.SelectedValue & "' and id='" & cobro(x, 0) & "'"
                                    SqlDataSource2.Update()
                                    TextBox1.Text = 0
                                Else
                                    SqlDataSource2.UpdateCommand = "update tt_rentas set pagado='" & 1 & "', imprimir='" & 1 & "', cantidad_pagada=cantidad_pagada + cantidad, cantidad=0 where mes='" & DropDownList1.SelectedValue & "' and id='" & cobro(x, 0) & "'"
                                    SqlDataSource2.Update()
                                    TextBox1.Text -= cobro(x, 1)
                                End If
                            End If
                        Next
                    End If
                    If Val(TextBox1.Text) > 0 Then
                        SqlDataSource2.UpdateCommand = "update tt_cliente set saldo= saldo +'" & Val(TextBox1.Text) & "' where id='" & ddl_cliente.SelectedItem.Value & "'"
                        SqlDataSource2.Update()
                    End If
                    'agrega el envio de los restos de las rentas y cobros en literales h e i
                    a = "impresion_recibo.aspx?a=" + ddl_cliente.SelectedItem.Text + "&b=" + abono + "&c=" + Label46.Text + "&d=" + Label48.Text + "&e=" + DropDownList1.SelectedValue + "&g=" + ddl_cliente.SelectedValue + "&f=" + num
                    Dim script As String = " window.open('" + a + "','');"
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "popup", script, True)
                    'Else
                    Dim lit As New Literal()
                    lit.Text = "<script language='javascript'>window.alert('" & "Debe cubrir el costo total de la deuda..." & "')</script>"
                    Page.Controls.Add(lit)
                End If

            Else

                If ((Val(Label40.Text) + Val(TextBox1.Text)) = Label44.Text) Then
                    Dim resto As Double
                    resto = (Val(Label40.Text) + Val(TextBox1.Text)) - Val(Label44.Text)
                    SqlDataSource2.InsertCommand = "insert into tt_abonos(id_cliente,fecha,cantidad,renta,recoleccion) values('" & ddl_cliente.SelectedValue & "', '" & fecha.ToString("yyyy-MM-dd HH:mm:ss") & "', '" & (Val(Label40.Text) + Val(TextBox1.Text)) & "', '" & Label46.Text & "', '" & Label48.Text & "')"
                    SqlDataSource2.Insert()
                    SqlDataSource2.UpdateCommand = "update tt_rentas set pagado='" & 1 & "', imprimir='" & 1 & "',cantidad_pagada=cantidad_pagada + cantidad, cantidad=0 where mes='" & DropDownList1.SelectedValue & "' and cliente='" & ddl_cliente.SelectedItem.Value & "'"
                    SqlDataSource2.Update()
                    SqlDataSource2.UpdateCommand = "update tt_cliente set saldo='" & resto & "' where id='" & ddl_cliente.SelectedItem.Value & "'"
                    SqlDataSource2.Update()
                    'Dim a, b, c As String
                    If Val(TextBox1.Text) <> 0 And Val(Label40.Text) = 0 Then
                        b = Val(TextBox1.Text)
                    ElseIf Val(TextBox1.Text) = 0 And Val(Label40.Text) <> 0 Then
                        b = Val(Label44.Text)
                    End If

                    a = "impresion_recibo.aspx?a=" + ddl_cliente.SelectedItem.Text + "&b=" + b + "&c=" + Label46.Text + "&d=" + Label48.Text + "&e=" + DropDownList1.SelectedValue + "&f=" + num + "&g=" + ddl_cliente.SelectedValue
                    Dim script As String = " window.open('" + a + "','');"
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "popup", script, True)
                End If
                If ((Val(Label40.Text) + Val(TextBox1.Text)) > Label44.Text) Then
                    Dim resto As Double
                    resto = (Val(Label40.Text) + Val(TextBox1.Text)) - Val(Label44.Text)
                    SqlDataSource2.InsertCommand = "insert into tt_abonos(id_cliente,fecha,cantidad,renta,recoleccion) values('" & ddl_cliente.SelectedValue & "', '" & fecha.ToString("yyyy-MM-dd HH:mm:ss") & "', '" & Label44.Text & "', '" & Label46.Text & "', '" & Label48.Text & "')"
                    SqlDataSource2.Insert()
                    SqlDataSource2.UpdateCommand = "update tt_rentas set pagado='" & 1 & "', imprimir='" & 1 & "' ,cantidad_pagada=cantidad_pagada + cantidad, cantidad=0  where mes='" & DropDownList1.SelectedValue & "' and cliente='" & ddl_cliente.SelectedItem.Value & "'"
                    SqlDataSource2.Update()
                    SqlDataSource2.UpdateCommand = "update tt_cliente set saldo='" & resto & "' where id='" & ddl_cliente.SelectedItem.Value & "'"
                    SqlDataSource2.Update()

                    'Dim a, b, c As String
                    If Val(TextBox1.Text) <> 0 And Val(Label40.Text) = 0 Then
                        b = Val(TextBox1.Text)
                    ElseIf Val(TextBox1.Text) = 0 And Val(Label40.Text) <> 0 Then
                        b = Val(Label44.Text)
                    End If
                    a = "impresion_recibo.aspx?a=" + ddl_cliente.SelectedItem.Text + "&b=" + b + "&c=" + Label46.Text + "&d=" + Label48.Text + "&e=" + DropDownList1.SelectedValue + "&f=" + num + "&g=" + ddl_cliente.SelectedValue
                    Dim script As String = " window.open('" + a + "','');"
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "popup", script, True)
                End If
                If ((Val(Label40.Text) + Val(TextBox1.Text)) < Val(Label44.Text)) Then
                    Dim cantidad_pendiente As Double
                    cantidad_pendiente = Val(Label44.Text) - (Val(Label40.Text) + Val(TextBox1.Text))
                    SqlDataSource2.InsertCommand = "insert into tt_abonos(id_cliente,fecha,cantidad,renta,recoleccion) values('" & ddl_cliente.SelectedValue & "', '" & fecha.ToString("yyyy-MM-dd HH:mm:ss") & "', '" & TextBox1.Text & "', '" & Label46.Text & "', '" & Label48.Text & "')"
                    SqlDataSource2.Insert()
                    Dim renta(15, 15) As Integer
                    Dim contador As Integer
                    contador = 0
                    Dim data5 As SqlDataReader
                    SqlDataSource2.SelectCommand = "SELECT *  FROM dbo.tt_rentas WHERE cliente=" & ddl_cliente.SelectedItem.Value & " And pagado = " & 0 & " and tipo = " & 0
                    SqlDataSource2.DataSourceMode = SqlDataSourceMode.DataReader
                    data5 = SqlDataSource2.Select(DataSourceSelectArguments.Empty)
                    While data5.Read
                        renta(contador, 0) = data5.GetValue(0)
                        renta(contador, 1) = data5.GetValue(5)
                        contador += 1
                    End While
                    For x = 0 To contador
                        If (Val(Label40.Text) + Val(TextBox1.Text)) > 0 Then
                            If renta(x, 1) > (Val(Label40.Text) + Val(TextBox1.Text)) Then
                                SqlDataSource2.UpdateCommand = "update tt_rentas set cantidad= cantidad - '" & (Val(Label40.Text) + Val(TextBox1.Text)) & "',cantidad_pagada= cantidad_pagada + '" & (Val(Label40.Text) + Val(TextBox1.Text)) & "' where mes='" & DropDownList1.SelectedValue & "' and id='" & renta(x, 0) & "'"
                                SqlDataSource2.Update()

                                SqlDataSource2.UpdateCommand = "update tt_cliente set saldo = 0 where cliente='" & ddl_cliente.SelectedItem.Value & "' "
                                SqlDataSource2.Update()
                                TextBox1.Text = 0
                                Label40.Text = 0
                            Else
                                SqlDataSource2.UpdateCommand = "update tt_rentas set pagado='" & 1 & "', imprimir='" & 1 & "',cantidad_pagada=cantidad_pagada + cantidad, cantidad= 0 where mes='" & DropDownList1.SelectedValue & "' and id='" & renta(x, 0) & "'"
                                SqlDataSource2.Update()
                                Dim diferencia As Integer
                                If (renta(x, 1) > Val(TextBox1.Text)) Then
                                    diferencia = renta(x, 1) - Val(TextBox1.Text)
                                    TextBox1.Text = 0
                                    SqlDataSource2.UpdateCommand = "update tt_cliente set saldo = saldo - '" & diferencia & "'  where id='" & ddl_cliente.SelectedItem.Value & "' "
                                    SqlDataSource2.Update()
                                    Label40.Text -= diferencia
                                Else
                                    TextBox1.Text -= renta(x, 1)
                                End If

                            End If
                        End If
                    Next
                    If (Val(Label40.Text) + Val(TextBox1.Text)) > 0 Then
                        Dim cobro(15, 15) As Integer
                        Dim contador1 As Integer
                        contador1 = 0
                        Dim data6 As SqlDataReader
                        SqlDataSource2.SelectCommand = "SELECT *  FROM dbo.tt_rentas WHERE cliente=" & ddl_cliente.SelectedItem.Value & " And pagado = " & 0 & " and tipo = " & 1
                        SqlDataSource2.DataSourceMode = SqlDataSourceMode.DataReader
                        data6 = SqlDataSource2.Select(DataSourceSelectArguments.Empty)
                        While data6.Read
                            cobro(contador1, 0) = data6.GetValue(0)
                            cobro(contador1, 1) = data6.GetValue(5)
                            contador1 += 1

                        End While
                        For x = 0 To contador1
                            If (Val(Label40.Text) + Val(TextBox1.Text)) > 0 Then
                                If cobro(x, 1) > Val(TextBox1.Text) + Val(Label40.Text) Then
                                    SqlDataSource2.UpdateCommand = "update tt_rentas set cantidad= cantidad - '" & Val(TextBox1.Text) & "',cantidad_pagada= cantidad_pagada + '" & Val(TextBox1.Text) & "' where mes='" & DropDownList1.SelectedValue & "' and id='" & cobro(x, 0) & "'"
                                    SqlDataSource2.Update()
                                    TextBox1.Text = 0
                                    Label40.Text = 0
                                Else
                                    SqlDataSource2.UpdateCommand = "update tt_rentas set pagado='" & 1 & "', imprimir='" & 1 & "', cantidad= 0,cantidad_pagada=cantidad_pagada + cantidad, where mes='" & DropDownList1.SelectedValue & "' and id='" & cobro(x, 0) & "'"
                                    SqlDataSource2.Update()
                                    Dim diferencia As Integer
                                    If (cobro(x, 1) > Val(TextBox1.Text)) Then
                                        diferencia = cobro(x, 1) - Val(TextBox1.Text)
                                        TextBox1.Text = 0
                                        SqlDataSource2.UpdateCommand = "update tt_cliente set saldo = saldo - '" & diferencia & "'  where id='" & ddl_cliente.SelectedItem.Value & "' "
                                        SqlDataSource2.Update()
                                        Label40.Text -= diferencia
                                    Else
                                        TextBox1.Text -= cobro(x, 1)
                                    End If
                                End If
                            End If
                        Next
                    End If
                    a = "impresion_recibo.aspx?a=" + ddl_cliente.SelectedItem.Text + "&b=" + TextBox1.Text + "&c=" + Label46.Text + "&d=" + Label48.Text + "&e=" + DropDownList1.SelectedValue + "&f=" + num + "&g=" + ddl_cliente.SelectedValue
                    Dim script As String = " window.open('" + a + "','');"
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "popup", script, True)
                    'Else


                End If
            End If
        Else

            ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('Ingresa Alguna cantidad para Abonar Por Favor... ');", True)
        End If

    End Sub
    Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click


        If Session("autorizado") = 3 Then
            Session("autorizado") = 3
            Response.Redirect("menu_cobro.aspx")
        End If
    End Sub
    Protected Sub ddl_cliente_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_cliente.SelectedIndexChanged
        DropDownList1.Items.Clear()

        Dim visitas As Integer
        Dim data As SqlDataReader
        Dim deuda, abono As Double
        deuda = 0
        abono = 0
        SqlDataSource2.SelectCommand = "SELECT *  FROM dbo.tt_rentas WHERE cliente=" & ddl_cliente.SelectedItem.Value & " And pagado = " & 0

        SqlDataSource2.DataSourceMode = SqlDataSourceMode.DataReader
        data = SqlDataSource2.Select(DataSourceSelectArguments.Empty)
        DataList1.DataSource = data
        DataList1.DataBind()
        data.Close()
        Dim data3 As SqlDataReader
        SqlDataSource2.SelectCommand = "SELECT saldo,rentas  FROM dbo.tt_cliente WHERE id=" & ddl_cliente.SelectedItem.Value
        SqlDataSource2.DataSourceMode = SqlDataSourceMode.DataReader
        data3 = SqlDataSource2.Select(DataSourceSelectArguments.Empty)
        If data3.Read Then
            Label40.Text = data3.GetValue(0)
            Label38.Text = data3.GetValue(1)
        End If
        data3.Close()
        Dim data1 As SqlDataReader
        SqlDataSource2.SelectCommand = "select distinct mes from tt_rentas WHERE cliente=" & ddl_cliente.SelectedItem.Value & " And pagado = " & 0
        SqlDataSource2.DataSourceMode = SqlDataSourceMode.DataReader
        data1 = SqlDataSource2.Select(DataSourceSelectArguments.Empty)
        Dim i As New ListItem
        While data1.Read
            i = New ListItem(data1.GetValue(0))
            DropDownList1.Items.Add(i)
        End While
        data1.Close()


        ' se buscan los costos de la deuda

        Label44.Text = 0
        Label46.Text = 0
        Label48.Text = 0
        TextBox1.Text = 0
        Dim cantidad As Integer = 0
        Dim rentas As Integer = 0
        For x = 0 To DataList1.Items.Count - 1
            Dim mes As Label = DataList1.Items(x).FindControl("cantidadLabel0")
            Dim cant As Label = DataList1.Items(x).FindControl("cantidadLabel")
            Dim tipo As Label = DataList1.Items(x).FindControl("cantidadLabel1")
            If mes.Text = DropDownList1.SelectedValue Then
                If tipo.Text = 0 Then
                    rentas = rentas + cant.Text
                Else
                    cantidad = cantidad + cant.Text
                End If

            End If

        Next
        Label44.Text = cantidad + rentas
        Label46.Text = rentas
        Label48.Text = cantidad


        'For x = 0 To DataList1.Items.Count - 1
        '    Dim deve As Label = DataList1.Items(x).FindControl("debeLabel")
        '    deuda = deuda + deve.Text
        'Next
        'Label21.Text = deuda
        'Label24.Text = abono
        'Label30.Text = deuda - abono
        'Label30.Text = (Val(Label28.Text) + Val(Label21.Text)) - Val(Label24.Text)
        'UpdatePanel1.Update()
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub



    Protected Sub Button4_Click(sender As Object, e As EventArgs)

    End Sub



    Protected Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        ' Response.Redirect("imprimir.aspx?a=" + ddl_cliente.SelectedItem.Text + "&b=" + TextBox1.Text)

    End Sub

    Protected Sub DropDownList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList1.SelectedIndexChanged
        Label44.Text = 0
        Label46.Text = 0
        Label48.Text = 0
        TextBox1.Text = 0
        Dim cantidad As Integer = 0
        Dim rentas As Integer = 0
        For x = 0 To DataList1.Items.Count - 1
            Dim mes As Label = DataList1.Items(x).FindControl("cantidadLabel0")
            Dim cant As Label = DataList1.Items(x).FindControl("cantidadLabel")
            Dim tipo As Label = DataList1.Items(x).FindControl("cantidadLabel1")
            If mes.Text = DropDownList1.SelectedValue Then
                If tipo.Text = 0 Then
                    rentas = rentas + cant.Text
                Else
                    cantidad = cantidad + cant.Text
                End If

            End If

        Next
        Label44.Text = cantidad + rentas
        Label46.Text = rentas
        Label48.Text = cantidad


    End Sub
End Class
