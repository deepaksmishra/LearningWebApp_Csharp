USE [LearningWebApp]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[LearningWebApp]
                @ClinicID int,
                @AppointmentDate varchar,
                @FirstName varchar,
                @LastName varchar,
                @PatientID int,
                @AppointmentStartTime varchar,
                @AppointmentEndTime varchar
AS
BEGIN
SET NOCOUNT ON;
INSERT appointments VALUES(1)
SELECT top 1 AppointmentID, ReturnCode, getdate() SubmittedTime
FROM appointments
order by appointmentID desc
END