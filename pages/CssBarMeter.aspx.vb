Public Class CssBarMeter
    Inherits System.Web.UI.Page

    Protected _meterPercent As Integer
    Protected _meterPercent2 As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            _meterPercent = 50
            _meterPercent2 = _meterPercent - 10
            txtMeterPercent.Text = 50
        End If
    End Sub

    Protected Sub btnUpdateMeterPercent_Click(sender As Object, e As EventArgs) Handles btnUpdateMeterPercent.Click
        _meterPercent = CInt(txtMeterPercent.Text)
        _meterPercent2 = CInt(txtMeterPercent.Text) - 10
    End Sub
End Class