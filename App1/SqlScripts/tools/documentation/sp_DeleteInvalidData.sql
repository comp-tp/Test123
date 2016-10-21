/****** Object:  StoredProcedure [dbo].[sp_DeleteInvalidData]    Script Date: 5/26/2014 6:30:52 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_DeleteInvalidData]

AS
BEGIN
--1.delete invalid parameters which is marked as 'CustomEntity' but the data exists in API_OBJECT_FIELDS table:
delete from [dbo].[API_PARAMETERS] where id in (select p.id from [dbo].[API_PARAMETERS] P,[dbo].[API_OBJECT_FIELDS] F 
where F.OBJECT_OR_PARAM_ID = P.ID and P.Data_type='CustomEntity')

--2. Sync Parameter Name to Field table
UPDATE   F
  SET F.Name = P.Parameter_name
  FROM [dbo].[API_OBJECT_FIELDS] F 
  INNER JOIN [dbo].[API_PARAMETERS] P
  ON F.OBJECT_OR_PARAM_ID = P.ID and F.Name <> P.Parameter_name
 
--3.delete invalid parameters which is marked as Primitive type but the data exists in API_OBJECTS table: 
delete from [dbo].[API_PARAMETERS] where id in 
(select P.ID from [dbo].[API_PARAMETERS] P,[dbo].[API_OBJECTS] O 
where O.PARENT_OBJECT_ID= P.ID and P.Data_type<>'CustomEntity')

-- 4. delete invalid objects
DELETE from [dbo].[API_OBJECTS] where PARAMETER_ID not in (select id from [dbo].[API_PARAMETERS])

-- 5. delete invalid fields which are not exist in objects and parameters tables
delete from  [dbo].[API_OBJECT_FIELDS] 
where (OBJECT_OR_PARAM_ID not in (select id from [dbo].[API_PARAMETERS])
and OBJECT_OR_PARAM_ID not in (select id from [dbo].[API_OBJECTS])
)

END

GO


