IF EXISTS (SELECT * FROM sys.change_tracking_tables WHERE object_id = OBJECT_ID(N'[SalesLT].[Product]')) 
   ALTER TABLE [SalesLT].[Product] 
   DISABLE  CHANGE_TRACKING
GO
