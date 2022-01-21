using CarsBase.Entities.Colors;
using CarsBase.Entities.Models;
using NLog;
using System;
using System.Collections.Generic;
using static System.Console;

namespace CarsBase.Entities.Modifications
{
    [Serializable]
    public class CarModification : BASE
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public List<CarBodyColor> _Colors { get; set; } = new List<CarBodyColor>();       
        
        public CarModification(string _name, string _code) : base(_name, _code) { }

        public CarModification() : base() { }

        public string ChooseModification(List<CarModel> Models, string nameModel)
        {
            WriteLine(" Choose modification : ");
            foreach (var item in Models.FindAll(x => x.Name == nameModel))
            {
                foreach (var i in item.Modifications)
                {
                    WriteLine("\t" + i.Name);
                }
            }
            Write(" Enter name of modification: ");
            string nameModif = ReadLine();
            return nameModif;
        }

        public void DeleteModification(List<CarModel> Models, string nameModel)
        {
            Write("\n\n DELETE modification: ");
            string nameModif = ChooseModification(Models, nameModel);
            Models.FindAll(x => x.Name == nameModel).
                   ForEach(m => m.Modifications.RemoveAll(n => n.Name == nameModif));
            logger.Info("Delete modification: " + nameModif);
        }

        public void ChangeModification(List<CarModel> Models, string nameModel)
        {
            Write("\n\n CHANGE modification: ");
            string nameModif = ChooseModification(Models, nameModel);
            Write(" Enter new name of model: ");
            string newNameModif = ReadLine();
            Models.FindAll(x => x.Name == nameModel).
                   ForEach(m => m.Modifications.FindAll(z => z.Name == nameModif).
                   ForEach(n => n.Name = newNameModif));
            logger.Info("Change name of modification: " + nameModif + " on " + newNameModif);
        }

        public void ChangeVendorModif(List<CarModel> Models, string nameModel)
        {
            Write("\n\n CHANGE vendor code of modification: ");
            string nameModif = ChooseModification(Models, nameModel);
            Write(" Enter new vendor code of model: ");
            string newNamevendor = ReadLine();
            Models.FindAll(x => x.Name == nameModel).
                   ForEach(m => m.Modifications.FindAll(z => z.Name == nameModif).
                   ForEach(n => n.VendorId = newNamevendor));
            logger.Info("Change vendor code of modification: " + nameModif + " - " + newNamevendor);
        }

        public void AddColor(List<CarModel> Models, string nameModel)
        {
            Write("\n\n ADD new color: ");
            string nameModif = ChooseModification(Models, nameModel);
            Write(" Enter name of new color: ");
           string name = ReadLine();
            Write(" Enter VendorCode of new color: ");
            string vendorCode = ReadLine();
            CarBodyColor newColor = new CarBodyColor(name, vendorCode);
            Models.FindAll(x => x.Name == nameModel).
                   ForEach(m => m.Modifications.FindAll(z => z.Name == nameModif).
                   ForEach(d => d._Colors.Add(newColor)));
            logger.Info("Add to modification: " + nameModif + " color " + name);
        }
    }
}