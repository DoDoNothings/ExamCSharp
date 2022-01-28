SELECT Models.Name as "Model",
		Modifications.Name as "Modifications", 
		Colors.Name as "Colors",
		Colors.VendorID as "Vendor ID"
		from LineUP  
Join Models on LineUP.ModelID = Models.Id
Join Modifications on LineUP.ModifID = Modifications.Id
Join Colors on LineUP.ColorID = Colors.Id
where Colors.Name ='black'