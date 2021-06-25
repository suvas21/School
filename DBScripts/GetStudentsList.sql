SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE OR ALTER   PROCEDURE [dbo].[proc_GetEmloyeesList]  
(  
 @searchValue nvarchar(255),
 @rowCount INT = NULL ,
 @rowPerPage INT = NULL 
)  
AS  
BEGIN  
  SET NOCOUNT ON;

  SELECT 
   std.StudentId
  ,FirstName
  ,LastName
  ,Class
  ,s.SubjectName
  ,c.Marks
  ,COUNT(StudentId) OVER () AS TotalRecords
  FROM Students std
  INNER JOIN Course c on c.StudentId = std.StudentId
  INNER JOIN Subjects s on s.StudentId = c.StudentId
	
  ORDER BY Id DESC OFFSET @rowCount ROWS
	FETCH NEXT @rowPerPage ROWS ONLY;

END