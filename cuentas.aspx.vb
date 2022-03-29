Imports System.Data
Imports System.Data.SqlClient
Partial Class _Default
    Inherits System.Web.UI.Page
    Dim visitado As Integer
    Private Sub _Default_Load(sender As Object, e As EventArgs) Handles Me.Load
        txt_fecha.Text = Date.Today
        If Not Page.IsPostBack Then
            If Session("autorizado") = 0 Then
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
                Label48.Text = cantidad
            Else
                Response.Redirect("login.aspx")
            End If
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'revisamos si es mayor  la cantidad abonada
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
        If (Val(Label40.Text) + Val(TextBox1.Text)) <= Val(Label44.Text) And Val(Label40.Text) <> 0 Then
            If Label40.Text > 0 Then
                If ((Val(Label40.Text) + Val(TextBox1.Text)) = Label44.Text) Then
                    Dim resto As Double
                    resto = (Val(Label40.Text) + Val(TextBox1.Text)) - Val(Label44.Text)
                    SqlDataSource2.InsertCommand = "insert into tt_abonos(id_cliente,fecha,cantidad,renta,recoleccion) values('" & ddl_cliente.SelectedValue & "', '" & fecha.ToString("yyyy-MM-dd HH:mm:ss") & "', '" & (Val(Label40.Text) + Val(TextBox1.Text)) & "', '" & Label46.Text & "', '" & Label48.Text & "')"
                    SqlDataSource2.Insert()
                    SqlDataSource2.UpdateCommand = "update tt_rentas set pagado='" & 1 & "' where mes='" & DropDownList1.SelectedValue & "' and cliente='" & ddl_cliente.SelectedItem.Value & "'"
                    SqlDataSource2.Update()
                    SqlDataSource2.UpdateCommand = "update tt_cliente set saldo='" & resto & "' where id='" & ddl_cliente.SelectedItem.Value & "'"
                    SqlDataSource2.Update()
                    Dim a, b, c As String
                    If Val(TextBox1.Text) <> 0 And Val(Label40.Text) = 0 Then
                        b = Val(TextBox1.Text)
                    ElseIf Val(TextBox1.Text) = 0 And Val(Label40.Text) <> 0 Then
                        b = Val(Label44.Text)
                    End If

                    a = "recibo.aspx?a=" + ddl_cliente.SelectedItem.Text + "&b=" + b + "&c=" + Label46.Text + "&d=" + Label48.Text + "&e=" + DropDownList1.SelectedValue + "&f=" + num
                    Dim script As String = " window.open('" + a + "','');"
                        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "popup", script, True)
                    End If
                    If ((Val(Label40.Text) + Val(TextBox1.Text)) > Label44.Text) Then
                    Dim resto As Double
                    resto = (Val(Label40.Text) + Val(TextBox1.Text)) - Val(Label44.Text)
                    SqlDataSource2.InsertCommand = "insert into tt_abonos(id_cliente,fecha,cantidad,renta,recoleccion) values('" & ddl_cliente.SelectedValue & "', '" & fecha.ToString("yyyy-MM-dd HH:mm:ss") & "', '" & Label44.Text & "', '" & Label46.Text & "', '" & Label48.Text & "')"
                    SqlDataSource2.Insert()
                    SqlDataSource2.UpdateCommand = "update tt_rentas set pagado='" & 1 & "' where mes='" & DropDownList1.SelectedValue & "' and cliente='" & ddl_cliente.SelectedItem.Value & "'"
                    SqlDataSource2.Update()
                    SqlDataSource2.UpdateCommand = "update tt_cliente set saldo='" & resto & "' where id='" & ddl_cliente.SelectedItem.Value & "'"
                    SqlDataSource2.Update()

                    Dim a, b, c As String
                    If Val(TextBox1.Text) <> 0 And Val(Label40.Text) = 0 Then
                        b = Val(TextBox1.Text)
                    ElseIf Val(TextBox1.Text) = 0 And Val(Label40.Text) <> 0 Then
                        b = Val(Label44.Text)
                    End If
                    a = "recibo.aspx?a=" + ddl_cliente.SelectedItem.Text + "&b=" + b + "&c=" + Label46.Text + "&d=" + Label48.Text + "&e=" + DropDownList1.SelectedValue + "&f=" + num
                    Dim script As String = " window.open('" + a + "','');"
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "popup", script, True)
                End If

            Else
                If (Val(TextBox1.Text) = Val(Label44.Text)) And (Val(Label40.Text) = 0) Then
                    Dim resto As Double
                    resto = Val(TextBox1.Text) - Val(Label44.Text)
                    SqlDataSource2.InsertCommand = "insert into tt_abonos(id_cliente,fecha,cantidad,renta,recoleccion) values('" & ddl_cliente.SelectedValue & "', '" & fecha.ToString("yyyy-MM-dd HH:mm:ss") & "', '" & TextBox1.Text & "', '" & Label46.Text & "', '" & Label48.Text & "')"
                    SqlDataSource2.Insert()
                    SqlDataSource2.UpdateCommand = "update tt_rentas set pagado='" & 1 & "' where mes='" & DropDownList1.SelectedValue & "' and cliente='" & ddl_cliente.SelectedItem.Value & "'"
                    SqlDataSource2.Update()
                    Dim a, b, c As String
                    If Val(TextBox1.Text) <> 0 And Val(Label40.Text) = 0 Then
                        b = Val(TextBox1.Text)
                    ElseIf Val(TextBox1.Text) = 0 And Val(Label40.Text) <> 0 Then
                        b = Val(Label44.Text)
                    End If
                    a = "recibo.aspx?a=" + ddl_cliente.SelectedItem.Text + "&b=" + b + "&c=" + Label46.Text + "&d=" + Label48.Text + "&e=" + DropDownList1.SelectedValue + "&f=" + num
                    Dim script As String = " window.open('" + a + "','');"
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "popup", script, True)
                End If
                If Val(TextBox1.Text) > Val(Label44.Text) Then
                    Dim resto As Double
                    resto = Val(TextBox1.Text) - Val(Label44.Text)
                    SqlDataSource2.InsertCommand = "insert into tt_abonos(id_cliente,fecha,cantidad,renta,recoleccion) values('" & ddl_cliente.SelectedValue & "', '" & fecha.ToString("yyyy-MM-dd HH:mm:ss") & "', '" & TextBox1.Text & "', '" & Label46.Text & "', '" & Label48.Text & "')"
                    SqlDataSource2.Insert()
                    SqlDataSource2.UpdateCommand = "update tt_rentas set pagado='" & 1 & "' where mes='" & DropDownList1.SelectedValue & "' and cliente='" & ddl_cliente.SelectedItem.Value & "'"
                    SqlDataSource2.Update()
                    SqlDataSource2.UpdateCommand = "update tt_cliente set saldo='" & resto & "' where id='" & ddl_cliente.SelectedItem.Value & "'"
                    SqlDataSource2.Update()
                    Dim a, b, c As String
                    If Val(TextBox1.Text) <> 0 And Val(Label40.Text) = 0 Then
                        b = Val(TextBox1.Text)
                    ElseIf Val(TextBox1.Text) = 0 And Val(Label40.Text) <> 0 Then
                        b = Val(Label44.Text)
                    End If
                    a = "recibo.aspx?a=" + ddl_cliente.SelectedItem.Text + "&b=" + b + "&c=" + Label46.Text + "&d=" + Label48.Text + "&e=" + DropDownList1.SelectedValue + "&f=" + num
                    Dim script As String = " window.open('" + a + "','');"
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "popup", script, True)
                End If
            End If
            If (Val(TextBox1.Text) + Val(Label40.Text)) < Val(Label44.Text) Then
                Dim lit As New Literal()
                lit.Text = "<script language='javascript'>window.alert('" & "Debe cubrir el costo total de la deuda..." & "')</script>"
                Page.Controls.Add(lit)

            End If

        Else

                If Label40.Text > 0 Then
                If ((Val(Label40.Text) + Val(TextBox1.Text)) = Label44.Text) Then
                    Dim resto As Double
                    resto = (Val(Label40.Text) + Val(TextBox1.Text)) - Val(Label44.Text)
                    SqlDataSource2.InsertCommand = "insert into tt_abonos(id_cliente,fecha,cantidad,renta,recoleccion) values('" & ddl_cliente.SelectedValue & "', '" & fecha.ToString("yyyy-MM-dd HH:mm:ss") & "', '" & (Val(Label40.Text) + Val(TextBox1.Text)) & "', '" & Label46.Text & "', '" & Label48.Text & "')"
                    SqlDataSource2.Insert()
                    SqlDataSource2.UpdateCommand = "update tt_rentas set pagado='" & 1 & "' where mes='" & DropDownList1.SelectedValue & "' and cliente='" & ddl_cliente.SelectedItem.Value & "'"
                    SqlDataSource2.Update()
                    SqlDataSource2.UpdateCommand = "update tt_cliente set saldo='" & resto & "' where id='" & ddl_cliente.SelectedItem.Value & "'"
                    SqlDataSource2.Update()
                    Dim a, b, c As String
                    If Val(TextBox1.Text) <> 0 And Val(Label40.Text) = 0 Then
                        b = Val(TextBox1.Text)
                    ElseIf Val(TextBox1.Text) = 0 And Val(Label40.Text) <> 0 Then
                        b = Val(Label44.Text)
                    End If
                    a = "recibo.aspx?a=" + ddl_cliente.SelectedItem.Text + "&b=" + b + "&c=" + Label46.Text + "&d=" + Label48.Text + "&e=" + DropDownList1.SelectedValue + "&f=" + num
                    Dim script As String = " window.open('" + a + "','');"
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "popup", script, True)
                End If
                If ((Val(Label40.Text) + Val(TextBox1.Text)) > Label44.Text) Then
                    Dim resto As Double
                    resto = (Val(Label40.Text) + Val(TextBox1.Text)) - Val(Label44.Text)
                    SqlDataSource2.InsertCommand = "insert into tt_abonos(id_cliente,fecha,cantidad,renta,recoleccion) values('" & ddl_cliente.SelectedValue & "', '" & fecha.ToString("yyyy-MM-dd HH:mm:ss") & "', '" & Label44.Text & "', '" & Label46.Text & "', '" & Label48.Text & "')"
                    SqlDataSource2.Insert()
                    SqlDataSource2.UpdateCommand = "update tt_rentas set pagado='" & 1 & "' where mes='" & DropDownList1.SelectedValue & "' and cliente='" & ddl_cliente.SelectedItem.Value & "'"
                    SqlDataSource2.Update()
                    SqlDataSource2.UpdateCommand = "update tt_cliente set saldo='" & resto & "' where id='" & ddl_cliente.SelectedItem.Value & "'"
                    SqlDataSource2.Update()
                    Dim a, b, c As String
                    If Val(TextBox1.Text) <> 0 And Val(Label40.Text) = 0 Then
                        b = Val(TextBox1.Text)
                    ElseIf Val(TextBox1.Text) = 0 And Val(Label40.Text) <> 0 Then
                        b = Val(Label44.Text)
                    End If
                    a = "recibo.aspx?a=" + ddl_cliente.SelectedItem.Text + "&b=" + b + "&c=" + Label46.Text + "&d=" + Label48.Text + "&e=" + DropDownList1.SelectedValue + "&f=" + num
                    Dim script As String = " window.open('" + a + "','');"
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "popup", script, True)
                End If

            Else
                If (Val(TextBox1.Text) >= Val(Label44.Text)) And (Label40.Text = 0) Then
                    Dim resto As Double
                    resto = Val(TextBox1.Text) - Val(Label44.Text)
                    SqlDataSource2.InsertCommand = "insert into tt_abonos(id_cliente,fecha,cantidad,renta,recoleccion) values('" & ddl_cliente.SelectedValue & "', '" & fecha.ToString("yyyy-MM-dd HH:mm:ss") & "', '" & TextBox1.Text & "', '" & Label46.Text & "', '" & Label48.Text & "')"
                    SqlDataSource2.Insert()
                    SqlDataSource2.UpdateCommand = "update tt_rentas set pagado='" & 1 & "' where mes='" & DropDownList1.SelectedValue & "' and cliente='" & ddl_cliente.SelectedItem.Value & "'"
                    SqlDataSource2.Update()
                    SqlDataSource2.UpdateCommand = "update tt_cliente set saldo='" & resto & "' where id='" & ddl_cliente.SelectedItem.Value & "'"
                    SqlDataSource2.Update()
                    Dim a, b, c As String
                    If Val(TextBox1.Text) <> 0 And Val(Label40.Text) = 0 Then
                        b = Val(TextBox1.Text)
                    ElseIf Val(TextBox1.Text) = 0 And Val(Label40.Text) <> 0 Then
                        b = Val(Label44.Text)
                    End If
                    Label44.Text = 0
                    Label46.Text = 0
                    Label48.Text = 0
                    a = "recibo.aspx?a=" + ddl_cliente.SelectedItem.Text + "&b=" + b + "&c=" + Label46.Text + "&d=" + Label48.Text + "&e=" + DropDownList1.SelectedValue + "&f=" + num
                    Dim script As String = " window.open('" + a + "','');"
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "popup", script, True)
                Else
                    Dim lit As New Literal()
                    lit.Text = "<script language='javascript'>window.alert('" & "Debe cubrir el costo total de la deuda..." & "')</script>"
                    Page.Controls.Add(lit)
                End If

            End If





        End If
        ' se regresa todo de nuevo
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

    End Sub
    Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Response.Redirect("menu_captura.aspx")
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

    'Protected Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
    '    'revisamos si es mayor  la cantidad abonada
    '    Dim fecha As Date
    '    fecha = txt_fecha.Text
    '    If (Val(Label40.Text) + Val(TextBox1.Text)) <= Val(Label44.Text) And Val(Label40.Text) <> 0 Then
    '        If Label40.Text > 0 Then
    '            If ((Val(Label40.Text) + Val(TextBox1.Text)) = Label44.Text) Then
    '                Dim resto As Double
    '                resto = (Val(Label40.Text) + Val(TextBox1.Text)) - Val(Label44.Text)
    '                SqlDataSource2.InsertCommand = "insert into tt_abonos(id_cliente,fecha,cantidad,renta,recoleccion) values('" & ddl_cliente.SelectedValue & "', '" & fecha.ToString("yyyy-MM-dd HH:mm:ss") & "', '" & (Val(Label40.Text) + Val(TextBox1.Text)) & "', '" & Label46.Text & "', '" & Label48.Text & "')"
    '                SqlDataSource2.Insert()
    '                SqlDataSource2.UpdateCommand = "update tt_rentas set pagado='" & 1 & "' where mes='" & DropDownList1.SelectedValue & "' and cliente='" & ddl_cliente.SelectedItem.Value & "'"
    '                SqlDataSource2.Update()
    '                SqlDataSource2.UpdateCommand = "update tt_cliente set saldo='" & resto & "' where id='" & ddl_cliente.SelectedItem.Value & "'"
    '                SqlDataSource2.Update()
    '                Dim a, b, c As String
    '                If Val(TextBox1.Text) <> 0 And Val(Label40.Text) = 0 Then
    '                    b = Val(TextBox1.Text)
    '                ElseIf Val(TextBox1.Text) = 0 And Val(Label40.Text) <> 0 Then
    '                    b = Val(Label44.Text)
    '                End If

    '                a = "recibo.aspx?a=" + ddl_cliente.SelectedItem.Text + "&b=" + b + "&c=" + Label46.Text + "&d=" + Label48.Text + "&e=" + DropDownList1.SelectedValue + "&f=" + num
    '                Dim script As String = " window.open('" + a + "','');"
    '                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "popup", script, True)
    '            End If
    '            If ((Val(Label40.Text) + Val(TextBox1.Text)) > Label44.Text) Then
    '                Dim resto As Double
    '                resto = (Val(Label40.Text) + Val(TextBox1.Text)) - Val(Label44.Text)
    '                SqlDataSource2.InsertCommand = "insert into tt_abonos(id_cliente,fecha,cantidad,renta,recoleccion) values('" & ddl_cliente.SelectedValue & "', '" & fecha.ToString("yyyy-MM-dd HH:mm:ss") & "', '" & Label44.Text & "', '" & Label46.Text & "', '" & Label48.Text & "')"
    '                SqlDataSource2.Insert()
    '                SqlDataSource2.UpdateCommand = "update tt_rentas set pagado='" & 1 & "' where mes='" & DropDownList1.SelectedValue & "' and cliente='" & ddl_cliente.SelectedItem.Value & "'"
    '                SqlDataSource2.Update()
    '                SqlDataSource2.UpdateCommand = "update tt_cliente set saldo='" & resto & "' where id='" & ddl_cliente.SelectedItem.Value & "'"
    '                SqlDataSource2.Update()

    '                Dim a, b, c As String
    '                If Val(TextBox1.Text) <> 0 And Val(Label40.Text) = 0 Then
    '                    b = Val(TextBox1.Text)
    '                ElseIf Val(TextBox1.Text) = 0 And Val(Label40.Text) <> 0 Then
    '                    b = Val(Label44.Text)
    '                End If
    '                a = "recibo.aspx?a=" + ddl_cliente.SelectedItem.Text + "&b=" + b + "&c=" + Label46.Text + "&d=" + Label48.Text + "&e=" + DropDownList1.SelectedValue + "&f=" + num
    '                Dim script As String = " window.open('" + a + "','');"
    '                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "popup", script, True)
    '            End If

    '        Else
    '            If (Val(TextBox1.Text) = Val(Label44.Text)) And (Val(Label40.Text) = 0) Then
    '                Dim resto As Double
    '                resto = Val(TextBox1.Text) - Val(Label44.Text)
    '                SqlDataSource2.InsertCommand = "insert into tt_abonos(id_cliente,fecha,cantidad,renta,recoleccion) values('" & ddl_cliente.SelectedValue & "', '" & fecha.ToString("yyyy-MM-dd HH:mm:ss") & "', '" & TextBox1.Text & "', '" & Label46.Text & "', '" & Label48.Text & "')"
    '                SqlDataSource2.Insert()
    '                SqlDataSource2.UpdateCommand = "update tt_rentas set pagado='" & 1 & "' where mes='" & DropDownList1.SelectedValue & "' and cliente='" & ddl_cliente.SelectedItem.Value & "'"
    '                SqlDataSource2.Update()
    '                Dim a, b, c As String
    '                If Val(TextBox1.Text) <> 0 And Val(Label40.Text) = 0 Then
    '                    b = Val(TextBox1.Text)
    '                ElseIf Val(TextBox1.Text) = 0 And Val(Label40.Text) <> 0 Then
    '                    b = Val(Label44.Text)
    '                End If
    '                a = "recibo.aspx?a=" + ddl_cliente.SelectedItem.Text + "&b=" + b + "&c=" + Label46.Text + "&d=" + Label48.Text + "&e=" + DropDownList1.SelectedValue + "&f=" + num
    '                Dim script As String = " window.open('" + a + "','');"
    '                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "popup", script, True)
    '            End If
    '            If Val(TextBox1.Text) > Val(Label44.Text) Then
    '                Dim resto As Double
    '                resto = Val(TextBox1.Text) - Val(Label44.Text)
    '                SqlDataSource2.InsertCommand = "insert into tt_abonos(id_cliente,fecha,cantidad,renta,recoleccion) values('" & ddl_cliente.SelectedValue & "', '" & fecha.ToString("yyyy-MM-dd HH:mm:ss") & "', '" & TextBox1.Text & "', '" & Label46.Text & "', '" & Label48.Text & "')"
    '                SqlDataSource2.Insert()
    '                SqlDataSource2.UpdateCommand = "update tt_rentas set pagado='" & 1 & "' where mes='" & DropDownList1.SelectedValue & "' and cliente='" & ddl_cliente.SelectedItem.Value & "'"
    '                SqlDataSource2.Update()
    '                SqlDataSource2.UpdateCommand = "update tt_cliente set saldo='" & resto & "' where id='" & ddl_cliente.SelectedItem.Value & "'"
    '                SqlDataSource2.Update()
    '                Dim a, b, c As String
    '                If Val(TextBox1.Text) <> 0 And Val(Label40.Text) = 0 Then
    '                    b = Val(TextBox1.Text)
    '                ElseIf Val(TextBox1.Text) = 0 And Val(Label40.Text) <> 0 Then
    '                    b = Val(Label44.Text)
    '                End If
    '                a = "recibo.aspx?a=" + ddl_cliente.SelectedItem.Text + "&b=" + b + "&c=" + Label46.Text + "&d=" + Label48.Text + "&e=" + DropDownList1.SelectedValue + "&f=" + num
    '                Dim script As String = " window.open('" + a + "','');"
    '                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "popup", script, True)
    '            End If
    '        End If
    '        If (Val(TextBox1.Text) + Val(Label40.Text)) < Val(Label44.Text) Then
    '            Dim lit As New Literal()
    '            lit.Text = "<script language='javascript'>window.alert('" & "Debe cubrir el costo total de la deuda..." & "')</script>"
    '            Page.Controls.Add(lit)

    '        End If

    '    Else

    '        If Label40.Text > 0 Then
    '            If ((Val(Label40.Text) + Val(TextBox1.Text)) = Label44.Text) Then
    '                Dim resto As Double
    '                resto = (Val(Label40.Text) + Val(TextBox1.Text)) - Val(Label44.Text)
    '                SqlDataSource2.InsertCommand = "insert into tt_abonos(id_cliente,fecha,cantidad,renta,recoleccion) values('" & ddl_cliente.SelectedValue & "', '" & fecha.ToString("yyyy-MM-dd HH:mm:ss") & "', '" & (Val(Label40.Text) + Val(TextBox1.Text)) & "', '" & Label46.Text & "', '" & Label48.Text & "')"
    '                SqlDataSource2.Insert()
    '                SqlDataSource2.UpdateCommand = "update tt_rentas set pagado='" & 1 & "' where mes='" & DropDownList1.SelectedValue & "' and cliente='" & ddl_cliente.SelectedItem.Value & "'"
    '                SqlDataSource2.Update()
    '                SqlDataSource2.UpdateCommand = "update tt_cliente set saldo='" & resto & "' where id='" & ddl_cliente.SelectedItem.Value & "'"
    '                SqlDataSource2.Update()
    '                Dim a, b, c As String
    '                If Val(TextBox1.Text) <> 0 And Val(Label40.Text) = 0 Then
    '                    b = Val(TextBox1.Text)
    '                ElseIf Val(TextBox1.Text) = 0 And Val(Label40.Text) <> 0 Then
    '                    b = Val(Label44.Text)
    '                End If
    '                a = "recibo.aspx?a=" + ddl_cliente.SelectedItem.Text + "&b=" + b + "&c=" + Label46.Text + "&d=" + Label48.Text + "&e=" + DropDownList1.SelectedValue + "&f=" + num
    '                Dim script As String = " window.open('" + a + "','');"
    '                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "popup", script, True)
    '            End If
    '            If ((Val(Label40.Text) + Val(TextBox1.Text)) > Label44.Text) Then
    '                Dim resto As Double
    '                resto = (Val(Label40.Text) + Val(TextBox1.Text)) - Val(Label44.Text)
    '                SqlDataSource2.InsertCommand = "insert into tt_abonos(id_cliente,fecha,cantidad,renta,recoleccion) values('" & ddl_cliente.SelectedValue & "', '" & fecha.ToString("yyyy-MM-dd HH:mm:ss") & "', '" & Label44.Text & "', '" & Label46.Text & "', '" & Label48.Text & "')"
    '                SqlDataSource2.Insert()
    '                SqlDataSource2.UpdateCommand = "update tt_rentas set pagado='" & 1 & "' where mes='" & DropDownList1.SelectedValue & "' and cliente='" & ddl_cliente.SelectedItem.Value & "'"
    '                SqlDataSource2.Update()
    '                SqlDataSource2.UpdateCommand = "update tt_cliente set saldo='" & resto & "' where id='" & ddl_cliente.SelectedItem.Value & "'"
    '                SqlDataSource2.Update()
    '                Dim a, b, c As String
    '                If Val(TextBox1.Text) <> 0 And Val(Label40.Text) = 0 Then
    '                    b = Val(TextBox1.Text)
    '                ElseIf Val(TextBox1.Text) = 0 And Val(Label40.Text) <> 0 Then
    '                    b = Val(Label44.Text)
    '                End If
    '                a = "recibo.aspx?a=" + ddl_cliente.SelectedItem.Text + "&b=" + b + "&c=" + Label46.Text + "&d=" + Label48.Text + "&e=" + DropDownList1.SelectedValue + "&f=" + num
    '                Dim script As String = " window.open('" + a + "','');"
    '                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "popup", script, True)
    '            End If

    '        Else
    '            If (Val(TextBox1.Text) >= Val(Label44.Text)) And (Label40.Text = 0) Then
    '                Dim resto As Double
    '                resto = Val(TextBox1.Text) - Val(Label44.Text)
    '                SqlDataSource2.InsertCommand = "insert into tt_abonos(id_cliente,fecha,cantidad,renta,recoleccion) values('" & ddl_cliente.SelectedValue & "', '" & fecha.ToString("yyyy-MM-dd HH:mm:ss") & "', '" & TextBox1.Text & "', '" & Label46.Text & "', '" & Label48.Text & "')"
    '                SqlDataSource2.Insert()
    '                SqlDataSource2.UpdateCommand = "update tt_rentas set pagado='" & 1 & "' where mes='" & DropDownList1.SelectedValue & "' and cliente='" & ddl_cliente.SelectedItem.Value & "'"
    '                SqlDataSource2.Update()
    '                SqlDataSource2.UpdateCommand = "update tt_cliente set saldo='" & resto & "' where id='" & ddl_cliente.SelectedItem.Value & "'"
    '                SqlDataSource2.Update()
    '                Dim a, b, c As String
    '                If Val(TextBox1.Text) <> 0 And Val(Label40.Text) = 0 Then
    '                    b = Val(TextBox1.Text)
    '                ElseIf Val(TextBox1.Text) = 0 And Val(Label40.Text) <> 0 Then
    '                    b = Val(Label44.Text)
    '                End If
    '                Label44.Text = 0
    '                Label46.Text = 0
    '                Label48.Text = 0
    '                a = "recibo.aspx?a=" + ddl_cliente.SelectedItem.Text + "&b=" + b + "&c=" + Label46.Text + "&d=" + Label48.Text + "&e=" + DropDownList1.SelectedValue + "&f=" + num
    '                Dim script As String = " window.open('" + a + "','');"
    '                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "popup", script, True)
    '            Else
    '                Dim lit As New Literal()
    '                lit.Text = "<script language='javascript'>window.alert('" & "Debe cubrir el costo total de la deuda..." & "')</script>"
    '                Page.Controls.Add(lit)
    '            End If

    '        End If





    '    End If
    'End Sub

    Protected Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click

    End Sub
End Class
