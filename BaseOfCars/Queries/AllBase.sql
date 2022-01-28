SELECT Models.Name as "Model",
		Models.VendorID as "Vendor ID",
		Modifications.Name as "Modifications", 
		Modifications.VendorID as "Vendor ID",
		Colors.Name as "Colors",
		Colors.VendorID as "Vendor ID"
		from LineUP
Join Models on LineUP.ModelID = Models.Id
Join Modifications on LineUP.ModifID = Modifications.Id
Join Colors on LineUP.ColorID = Colors.Id