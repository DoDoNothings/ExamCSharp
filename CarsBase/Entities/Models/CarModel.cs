using CarsBase.Entities.Modifications;
using NLog;
using System;
using System.Collections.Generic;
using static System.Console;

namespace CarsBase.Entities.Models
{
    [Serializable]
    public class CarModel :BASE
    {
        public List<CarModification> Modifications { get; set; } = new List<CarModification>();

        private static Logger logger = LogManager.GetCurrentClassLogger();

        public CarModel(string _name, string _code) : base(_name, _code) { }

        public CarModel(string _name) : base(_name) { }

        public CarModel() : base() { }

        public string ChooseModel(List<CarModel> Models)
        {
            WriteLine(" Choose model :");
            foreach (var m in Models)
            {
                WriteLine($"\t" + m.Name);
            }
            Write(" Enter name of model: ");
            string nameModel = ReadLine();
            return nameModel;
        }

        public void DeleteModel(List<CarModel> Models)
        {
            Write("\n\n DELETE model: ");
            string nameModel = ChooseModel(Models);
            Models.RemoveAll(x => x.Name == nameModel);
            logger.Info("Delete model: " + nameModel);
        }

        public void ChangeModel(List<CarModel> Models)
        {
            Write("\n\n CHANGE model: ");
            string nameModel = ChooseModel(Models);
            Write(" Enter new name of model: ");
            string newNameModel = ReadLine();
            Models.FindAll(x => x.Name == nameModel).ForEach(s => s.Name = newNameModel);
            logger.Info("Change model: " + nameModel + " on " + newNameModel);
        }

        public void ChangeVendorModel(List<CarModel> Models)
        {
            Write("\n\n CHANGE vendor code of model: ");
            string nameModel = ChooseModel(Models);
            Write(" Enter new vendor code of model: ");
            string newNameVendor = ReadLine();
            Models.FindAll(x => x.Name == nameModel).ForEach(s => s.VendorId = newNameVendor);
            logger.Info("Change model: " + nameModel + " - " + newNameVendor);
        }

        public void AddModification(List<CarModel> Models)
        {
            Write("\n\n ADD new modification: ");
            string nameModel = ChooseModel(Models);
            Write(" Enter name of new modification: ");
            string name = ReadLine();
            Write(" Enter vendorCode of new modification: ");
            string vendorCode = ReadLine();
            CarModification newModif = new CarModification(name, vendorCode);
            Models.FindAll(x => x.Name == nameModel).
                   ForEach(m => m.Modifications.Add(newModif));
            logger.Info("Add to model: " + nameModel + " modification " + name);
        }
    }
}
