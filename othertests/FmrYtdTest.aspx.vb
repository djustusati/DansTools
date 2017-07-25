Public Class FmrYtdTest
    Inherits System.Web.UI.Page

    Protected bl As BusinessLogic

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        bl = New BusinessLogic()
        bl.Initialize(1.25, 1, 0.25, 0.5, 0.5, 0.3, 0.3, 80, 0.45, 0.3, 0.25, 90, 90, 5.33, 5.75, 5.25, 45, 60)

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        lblReturnValue.Text = ""
        lblReturnValue.Text = bl.YTDOverallIndex(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text,
                           TextBox5.Text, TextBox6.Text, TextBox7.Text, TextBox8.Text,
                           TextBox9.Text, TextBox10.Text, TextBox11.Text)

    End Sub
End Class