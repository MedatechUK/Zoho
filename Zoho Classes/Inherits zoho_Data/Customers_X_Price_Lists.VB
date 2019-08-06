
Imports System.Data.SqlClient
Imports Newtonsoft.Json

Public Class zoho_Module_Customers_X_Price_Lists : Inherits zoho_Module

    Public Overrides ReadOnly Property EndPoint As String
        Get
            Return "https://www.zohoapis.eu/crm/v2/Customers_X_Price_Lists"
        End Get

    End Property

    Public Overrides ReadOnly Property sqlView As String
        Get
            Return "zoho_Customers_X_Price_Lists"
        End Get
    End Property

    Public Overrides ReadOnly Property rowCount As Integer
        Get
            Return 100
        End Get
    End Property

    Public Overrides Function zoho_item(ByRef r As SqlDataReader) As zoho_Data
        Return New Customers_X_Price_Lists(r)

    End Function

End Class

Public Class Customers_X_Price_Lists : Inherits zoho_Data
    Public Property id As String
    Public Property Price_List_Priority As String
    Public Property Customer_Price_Lists As zoho_lookup
Public Property Customers As zoho_lookup
Public Property Owner As zoho_lookup
	Public Overrides Sub HandleResponse(ByRef cn As SqlConnection, ByRef resp As zoho_Response)

    End Sub

    Public Sub New(r As SqlDataReader)

        Customer_Price_Lists = New zoho_LookUp
        Customers = New zoho_LookUp
	Owner = New zoho_LookUp

        PopulateData(r)

    End Sub
End Class