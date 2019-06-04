﻿Imports ZCRMSDK.CRM.Library.Api.Response
Imports ZCRMSDK.CRM.Library.CRUD
Imports ZCRMSDK.CRM.Library.Setup.RestClient

Module Main

    Public args As clArg

    Public Enum eModule
        accounts
        contacts
        salesorders
        invoices

    End Enum

    Sub Main(arg() As String)

        args = New clArg(arg)
        Try


            Dim conf As New Dictionary(Of String, String)
            With conf
                ' Config params from: https://help.zoho.com/portal/kb/articles/csharp-sdk-config

                .Add("client_id", "1000.8ETLN5A9356890756HRWXWZ69VJCBN")
                .Add("client_secret", "b477d8bac9a8ad722334582b3430fdca7dde44de4e")
                .Add("redirect_uri", "<provide_redirect_url_here>")
                .Add("access_type", "offline")
                .Add("persistence_handler_class", "ZCRMSDK.OAuth.ClientApp.ZohoOAuthDBPersistence, ZCRMSDK")
                .Add("oauth_tokens_file_path", "<provide_file_path_here>")
                .Add("mysql_username", "root")
                .Add("mysql_password", "")
                .Add("mysql_database", "zohooauth")
                .Add("mysql_server", "localhost")
                .Add("mysql_port", "3306")
                .Add("apiBaseUrl", "https://www.zohoapis.com ")
                .Add("photoUrl", "<provide_photo_url_here>")
                .Add("apiVersion", "v2")
                .Add("logFilePath", "<provide_log_file_path_here>")
                .Add("timeout", "")
                .Add("minLogLevel", "")
                .Add("domainSuffix", "com")
                .Add("currentUserEmail", " user@user.com ")

            End With

            ' Initialse the client
            ZCRMRestClient.Initialize(conf)

            Dim records As New List(Of ZCRMRecord)
            ' todo: read TOP 100 modified records from DB
            Dim rec As New ZCRMRecord(eModule.accounts.ToString)
            With rec
                ' todo: Set fields from record
                .SetFieldValue("Company", "Value")

            End With

            records.Add(rec)

            Dim moduleIns As ZCRMModule = ZCRMModule.GetInstance(eModule.accounts.ToString)
            Dim response As BulkAPIResponse(Of ZCRMRecord) = moduleIns.UpsertRecords(records)

            ' Process response
            Dim upsertedRecords As List(Of ZCRMRecord) = response.BulkData
            Dim entityResponses As List(Of EntityResponse) = response.BulkEntitiesResponse

            ' Iterate through responses
            For Each er In entityResponses

                ' todo: update the record in Priorty
                Dim e As String = er.Code

            Next

        Catch ex As Exception
            Console.WriteLine(ex.Message)
            args.Log(ex.Message)

        Finally
            args.wait()

        End Try

    End Sub

End Module