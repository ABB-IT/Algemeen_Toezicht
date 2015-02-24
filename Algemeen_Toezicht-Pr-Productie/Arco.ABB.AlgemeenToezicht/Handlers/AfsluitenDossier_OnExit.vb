Public Class AfsluitenDossier_OnExit
    Inherits AlgemeenToezichtEventHandler

    Public Overrides Sub ExecuteCode(WFCurrentCase As Doma.Library.Routing.cCase)
        WFCurrentCase.RejectComment = ""
        WFCurrentCase.RejectUser = ""
        Dim lsSamenvatting As String = WFCurrentCase.GetProperty(Of String)("lbSamenvattingDossier")
        Dim lsMarcode As String = WFCurrentCase.GetProperty(Of String)("Marcode")
        Dim lsHoofonderwerp As String = WFCurrentCase.GetProperty(Of String)("onderwerp")
        If lsHoofonderwerp.ToLower = "fiscaliteit" Then


            If String.IsNullOrEmpty(lsMarcode) Then
                WFCurrentCase.RejectComment = "U bent verplicht de Marcode aan te duiden!"
                WFCurrentCase.RejectUser = "Routing"
            End If
        Else

            If String.IsNullOrEmpty(lsMarcode) Then
                If String.IsNullOrEmpty(lsSamenvatting) Then
                    WFCurrentCase.RejectComment = "U bent verplicht het veld samenvatting in te geven!"
                    WFCurrentCase.RejectUser = "Routing"
                End If
            End If
        End If








    End Sub

    Public Overrides ReadOnly Property Name As String
        Get
            Return "AfsluitenDossier_OnExit"
        End Get
    End Property
End Class
