
Create database LearningWebApp
USE [LearningWebApp]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[appointments](
    [AppointmentID] [int] IDENTITY(1,1) NOT NULL,
    [ReturnCode] [int] NOT NULL,
 CONSTRAINT [PK_appointments] PRIMARY KEY CLUSTERED
(
    [AppointmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


USE [LearningWebApp]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================

CREATE PROCEDURE [dbo].[CreateAppointment]
    -- Add the parameters for the stored procedure here
                @ClinicID int,
                @AppointmentDate varchar,
                @FirstName varchar,
                @LastName varchar,
                @PatientID int,
                @AppointmentStartTime varchar,
                @AppointmentEndTime varchar
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON;

    -- Insert statements for procedure here
    INSERT appointments VALUES(1)

    SELECT top 1 AppointmentID, ReturnCode, getdate() SubmittedTime
    FROM appointments
    order by appointmentID desc
END