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
  WHERE (ISNULL(@searchValue,'') 
	OR std.FirstName LIKE @searchValue
	OR std.LastName LIKE @searchValue
	OR std.Class LIKE @searchValue
	OR s.SubjectName LIKE @searchValue
)
  ORDER BY Id DESC OFFSET @rowCount ROWS
	FETCH NEXT @rowPerPage ROWS ONLY;

END