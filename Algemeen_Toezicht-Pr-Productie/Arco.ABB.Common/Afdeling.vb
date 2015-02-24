
<Serializable()> _
Public Class Afdeling
    Public Property Naam As String
    Public Property StraatNr As String
    Public Property PostCode As String
    Public Property Gemeente As String
    Public Property Email As String
    Public Property Telefoon As String
    Public Property Fax As String
    Public Property LOCATIECODE As Integer
    Public Property NaamAfdelingshoofd As String
    Public Property AanspreekTitel As String
    Public Property NaamGouverneur As String
    Public Property CentraleAfdeling As Boolean

    Private Sub SetExtraData()
        Select Case Me.Naam

            Case "Afdeling Beleid Steden en Brussel en Vlaamse Rand"
                'NaamAfdelingshoofd = "Carolina Stevens"
                'AanspreekTitel = "Mevrouw"
                'NaamGouverneur = "Cathy Berx"
                CentraleAfdeling = False
            Case "Afdeling Lokale Financiën"
                'NaamAfdelingshoofd = "Johan Ide"
                'AanspreekTitel = "Mijnheer"
                'NaamGouverneur = "Liesbeth Homans"
                CentraleAfdeling = True
            Case "Afdeling Integratie en Inburgering"
                'NaamAfdelingshoofd = "Sami Souguir"
                'AanspreekTitel = "Algemeen directeur"
                'NaamGouverneur = "Liesbeth Homans"
                CentraleAfdeling = True
            Case "Afdeling HR en Organisatieontwikkeling"
                'NaamAfdelingshoofd = "Sandra Beckers"
                'AanspreekTitel = "Mevrouw"
                'NaamGouverneur = "Herman Reynders"
                CentraleAfdeling = False
            Case "Afdeling Beleidscoördinatie en kenniscentrum"
                'NaamAfdelingshoofd = "Riet Zegers"
                'NaamAfdelingshoofd = "Vicky Van den Berge"
                'AanspreekTitel = "Mevrouw"
                'NaamGouverneur = "André Denys"
                'NaamGouverneur = "Jan Briers"
                CentraleAfdeling = False
            Case "Afdeling Facility en ICT"
                'NaamAfdelingshoofd = "Piet Van Der Plas"
                'AanspreekTitel = "Mijnheer"
                'NaamGouverneur = "Liesbeth Homans"
                CentraleAfdeling = True
            Case "Afdeling Lokale Organisatie"
                'NaamAfdelingshoofd = "Jo Craeghs" 'todo : bugfixed, here was naamgouverneur
                'AanspreekTitel = "Mijnheer"
                'NaamGouverneur = "Liesbeth Homans"
                CentraleAfdeling = True
            Case "Afdeling Lokale Werking"
                'NaamAfdelingshoofd = "Nicole Pijpops"
                'AanspreekTitel = "Mevrouw"
                'NaamGouverneur = "Lodewijk De Witte"
                CentraleAfdeling = False
            Case "Afdeling Lokale Financiering en Personeel"
                'NaamAfdelingshoofd = "Bruno Vanmarcke"
                'AanspreekTitel = "Mijnheer"
                'NaamGouverneur = "Carl Decaluwé"
                CentraleAfdeling = False
        End Select
        Arco.Utils.Logging.LogError("Toon de naam van de afdeling:")
    End Sub

    Private Sub New()

    End Sub
    'Public Shared Function GetAfdeling(ByVal vsNaam As String, bestuur_locatie As Integer) As Afdeling
    Public Shared Function GetAfdeling(ByVal vsNaam As String) As Afdeling
        ' dbe: ophalen bestuur.
        Dim loAfdeling As Afdeling = New Afdeling
        If Not String.IsNullOrEmpty(vsNaam) Then
            vsNaam = vsNaam.Replace("(Role)", "").Trim
            'why like?
            ' Dim lsSQL As String = "SELECT naam,straatnr,postcode, gemeente, emailadres, telefoonnr, fax,LOCATIECODE, aanspreekTitel, NaamAfdelingshoofd, NaamGouverneur  FROM bb_afdeling where upper(naam) like upper('%" & vsNaam & "%')"
            Dim lsSQL As String = "SELECT  naam,telefoonnr  FROM bb_afdeling where locatiecode = 5 and upper(naam) like upper('%" & vsNaam & "%')"


            'Dim lsSQL As String = "SELECT naam,straatnr,postcode, gemeente, emailadres, telefoonnr, fax, LOCATIECODE, aanspreekTitel, NaamAfdelingshoofd, NaamGouverneur  FROM bb_afdeling where upper(naam) like upper('%" & vsNaam & "%') and locatiecode = "
            'lsSQL = lsSQL & "(select distinct bestuur_lokatie from BB_ADRESBESTUREN where bestuur_lokatie = '" & bestuur_locatie & "')"
            ' query om het juiste adres van de afdeling op te halen afhankelijk van de lokatie van het bestuur





            Using loQuery As Arco.Server.DataQuery = New Arco.Server.DataQuery
                loQuery.Query = lsSQL
                Try
                    loQuery.Connect()
                    Using loReader As Server.SafeDataReader = loQuery.ExecuteReader
                        If loReader.Read Then
                            loAfdeling.Naam = loReader.GetString(0)
                            'loAfdeling.StraatNr = loReader.GetString(1)
                            'loAfdeling.PostCode = loReader.GetString(2)
                            'loAfdeling.Gemeente = loReader.GetString(3)
                            'loAfdeling.Email = loReader.GetString(4)
                            'loAfdeling.Telefoon = loReader.GetString(5)
                            loAfdeling.Telefoon = loReader.GetString(1)
                            'loAfdeling.Fax = loReader.GetString(6)
                            'loAfdeling.LOCATIECODE = loReader.GetInt32(7)
                            'loAfdeling.AanspreekTitel = loReader.GetString(8)
                            'loAfdeling.NaamAfdelingshoofd = loReader.GetString(9)
                            'loAfdeling.NaamGouverneur = loReader.GetString(10)
                            loAfdeling.SetExtraData()
                        End If
                    End Using
                Catch ex As Exception
                    Arco.Utils.Logging.LogError("error GetAfdeling:", ex)
                End Try
            End Using
        End If


        Return loAfdeling
    End Function
    Public Shared Function GetAfdeling_AT(ByVal vsNaam As String, bestuur_locatie As Integer) As Afdeling

        ' dbe: ophalen bestuur.
        Dim loAfdeling As Afdeling = New Afdeling
        Arco.Utils.Logging.Log("werkt de nieuwe functie afdeling = " & loAfdeling.LOCATIECODE, "d:\arco\logging\algemeentoezicht.log")
        If Not String.IsNullOrEmpty(vsNaam) Then
            vsNaam = vsNaam.Replace("(Role)", "").Trim
            'bestuur_locatie = CInt("9")


            Arco.Utils.Logging.Log("de naam van de  afdeling = " & vsNaam & "locatiecode vanuit dossiers" & bestuur_locatie, "d:\arco\logging\algemeentoezicht.log")
            Dim lsSQL As String = "SELECT naam,straatnr,postcode, gemeente, emailadres, telefoonnr, fax, LOCATIECODE, aanspreekTitel, NaamAfdelingshoofd, NaamGouverneur  FROM bb_afdeling where upper(naam) like upper('%" & vsNaam & "%')  "
            'lsSQL = lsSQL & " and locatiecode = (select distinct bestuur_lokatie from BB_ADRESBESTUREN where bestuur_lokatie = 'bestuur_locatie')"
            lsSQL = lsSQL & " and locatiecode =" & bestuur_locatie

            ' query om het juiste adres van de afdeling op te halen afhankelijk van de lokatie van het bestuur

            Using loQuery As Arco.Server.DataQuery = New Arco.Server.DataQuery
                loQuery.Query = lsSQL
                Try
                    loQuery.Connect()
                    Using loReader As Server.SafeDataReader = loQuery.ExecuteReader
                        If loReader.Read Then
                            loAfdeling.Naam = loReader.GetString(0)
                            loAfdeling.StraatNr = loReader.GetString(1)
                            loAfdeling.PostCode = loReader.GetString(2)
                            loAfdeling.Gemeente = loReader.GetString(3)
                            loAfdeling.Email = loReader.GetString(4)
                            loAfdeling.Telefoon = loReader.GetString(5)
                            loAfdeling.Fax = loReader.GetString(6)
                            loAfdeling.LOCATIECODE = loReader.GetInt32(7)
                            loAfdeling.AanspreekTitel = loReader.GetString(8)
                            loAfdeling.NaamAfdelingshoofd = loReader.GetString(9)
                            loAfdeling.NaamGouverneur = loReader.GetString(10)
                            loAfdeling.SetExtraData()
                        End If
                    End Using
                Catch ex As Exception
                    Arco.Utils.Logging.LogError("error GetAfdeling:", ex)
                End Try
            End Using
        End If
        Arco.Utils.Logging.Log("De locatiecode van het bestuur = " & loAfdeling.LOCATIECODE, "d:\arco\logging\algemeentoezicht.log")
        Arco.Utils.Logging.Log("Wordt de naam gouverneur ingevul = " & loAfdeling.NaamGouverneur, "d:\arco\logging\algemeentoezicht.log")
        Arco.Utils.Logging.Log("Statuscode 5? = " & loAfdeling.LOCATIECODE, "d:\arco\logging\algemeentoezicht.log")
        Return loAfdeling
    End Function
End Class

