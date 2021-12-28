INSERT INTO [dbo].[Car] ([Id], [CarRegNo], [CarMake], [CarModel], [Year], [ImageUrl], [PricePerDay]) VALUES (N'09759f9d-0fae-4647-b2d2-1f094456b034', N'YY9970', N'Honda', N'Civic', 2013, N'honda_civic.png', CAST(91.00 AS Decimal(18, 2)))
INSERT INTO [dbo].[Car] ([Id], [CarRegNo], [CarMake], [CarModel], [Year], [ImageUrl], [PricePerDay]) VALUES (N'19e844bc-d785-4522-b390-bdf201e9d2df', N'UV9989', N'Mitsubishi', N'Lancer', 2008, N'mitsubishi_lancer.png', CAST(88.50 AS Decimal(18, 2)))
INSERT INTO [dbo].[Car] ([Id], [CarRegNo], [CarMake], [CarModel], [Year], [ImageUrl], [PricePerDay]) VALUES (N'4a214fa9-5f05-4df8-9739-d49665e0dbd6', N'YZ9970', N'Mazda', N'Mazda 3', 2016, N'mazda_3.jpg', CAST(88.50 AS Decimal(18, 2)))
INSERT INTO [dbo].[Car] ([Id], [CarRegNo], [CarMake], [CarModel], [Year], [ImageUrl], [PricePerDay]) VALUES (N'55b0a1f5-4110-4741-b2de-3097b21c10da', N'ZZ9989', N'Toyota', N'Mark X', 2016, N'TOYOTA_MARK_X.jpg', CAST(91.00 AS Decimal(18, 2)))
INSERT INTO [dbo].[Car] ([Id], [CarRegNo], [CarMake], [CarModel], [Year], [ImageUrl], [PricePerDay]) VALUES (N'b4092c70-956e-4cde-9854-c391f26563a0', N'QQ9970', N'Nissan', N'Sky Line', 2012, N'nissan_skyline.jpg', CAST(95.00 AS Decimal(18, 2)))
INSERT INTO [dbo].[Car] ([Id], [CarRegNo], [CarMake], [CarModel], [Year], [ImageUrl], [PricePerDay]) VALUES (N'ea3e4f76-e2f8-4074-a839-6f11307a1f3c', N'ZY9967', N'Ford', N'Mustang', 2014, N'ford_mustang.jpg', CAST(100.00 AS Decimal(18, 2)))


INSERT INTO [dbo].[Driver] ([Id], [DriverName], [CarId]) VALUES (N'2e941e1c-0e7e-46f3-8cb3-04460e5751fe', N'Robert Nelson', N'19e844bc-d785-4522-b390-bdf201e9d2df')
INSERT INTO [dbo].[Driver] ([Id], [DriverName], [CarId]) VALUES (N'3d943a75-41a8-4829-9914-ed92ef4a21eb', N'Mark Stephen', N'ea3e4f76-e2f8-4074-a839-6f11307a1f3c')
INSERT INTO [dbo].[Driver] ([Id], [DriverName], [CarId]) VALUES (N'6cdad10c-e498-4877-a59c-e7d53fd4f8e1', N'John Smith', N'b4092c70-956e-4cde-9854-c391f26563a0')

INSERT INTO [dbo].[User] ([Id], [UserName]) VALUES (N'71ae5959-d68c-46da-a40f-1a7cca0211af', N'Sherlock Holmes')
INSERT INTO [dbo].[User] ([Id], [UserName]) VALUES (N'756a4b82-5ce6-4dd7-901e-55146dd5db59', N'George Watson')
INSERT INTO [dbo].[User] ([Id], [UserName]) VALUES (N'aceb2f53-cdaa-4145-94f7-aa6f62baf7a7', N'Frank Wilson')
INSERT INTO [dbo].[User] ([Id], [UserName]) VALUES (N'ebd5fc83-d146-4238-bba5-f0b7ea139fbb', N'Allan Warner')

INSERT INTO [dbo].[Booking] ([BookingId], [CarId], [UserId], [NumberOfDays]) VALUES (N'30b52459-0955-4f7b-b62d-6fa0085b4dab', N'55b0a1f5-4110-4741-b2de-3097b21c10da', N'aceb2f53-cdaa-4145-94f7-aa6f62baf7a7', 10)
INSERT INTO [dbo].[Booking] ([BookingId], [CarId], [UserId], [NumberOfDays]) VALUES (N'b6955885-2335-4cc8-bab6-742c9bacbeb1', N'b4092c70-956e-4cde-9854-c391f26563a0', N'ebd5fc83-d146-4238-bba5-f0b7ea139fbb', 15)
INSERT INTO [dbo].[Booking] ([BookingId], [CarId], [UserId], [NumberOfDays]) VALUES (N'dcfa7b32-8664-4936-9cdf-04245a234a4b', N'ea3e4f76-e2f8-4074-a839-6f11307a1f3c', N'756a4b82-5ce6-4dd7-901e-55146dd5db59', 1)
INSERT INTO [dbo].[Booking] ([BookingId], [CarId], [UserId], [NumberOfDays]) VALUES (N'de52fa88-2683-42ec-b1e5-3f6ce302a41b', N'09759f9d-0fae-4647-b2d2-1f094456b034', N'71ae5959-d68c-46da-a40f-1a7cca0211af', 5)


