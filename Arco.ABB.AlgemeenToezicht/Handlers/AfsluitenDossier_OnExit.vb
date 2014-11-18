Public Class AfsluitenDossier_OnExit
    Inherits AlgemeenToezichtEventHandler

    Public Overrides Sub ExecuteCode(WFCurrentCase As Doma.Library.Routing.cCase)

    End Sub

    Public Overrides ReadOnly Property Name As String
        Get
            Return "AfsluitenDossier_OnExit"
        End Get
    End Property
End Class
