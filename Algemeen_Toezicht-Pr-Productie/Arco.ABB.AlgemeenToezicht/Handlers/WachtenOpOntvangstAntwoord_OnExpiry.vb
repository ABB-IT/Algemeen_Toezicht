﻿Public Class WachtenOpOntvangstAntwoord_OnExpiry
    Inherits AlgemeenToezichtEventHandler

    Public Overrides Sub ExecuteCode(WFCurrentCase As Doma.Library.Routing.cCase)
        Dim lsaantaldagen As String = WFCurrentCase.GetProperty(Of String)("Herinnering na dagen")
        If Not String.IsNullOrEmpty(lsaantaldagen) Then            
            Dim ldduedate As DateTime = System.DateTime.Now.AddDays(Convert.ToInt32(lsaantaldagen))
            WFCurrentCase.Step_DueDate = ldduedate.ToString("yyyy-MM-dd HH:mm:ss")
            WFCurrentCase.SetProperty("initiële vervaltermijn", ldduedate)
        End If
     
    End Sub

    Public Overrides ReadOnly Property Name As String
        Get
            Return "WachtenOpOntvangstAntwoord_OnExpiry"
        End Get
    End Property
End Class
