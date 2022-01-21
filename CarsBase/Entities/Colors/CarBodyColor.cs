using CarsBase.Entities.Models;
using CarsBase.Entities.Modifications;
using NLog;
using System;
using System.Collections.Generic;
using static System.Console;

namespace CarsBase.Entities.Colors
{
    [Serializable]
    public class CarBodyColor: BASE
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public CarBodyColor(string _name, string _code) : base(_name, _code) { }

        public CarBodyColor() : base() { }

        string nameModif;

        public string ChooseColor(List<CarModel> Models, string nameModel)
        {
            CarModification modif = new CarModification();
             this.nameModif = modif.ChooseModification(Models, nameModel);
            WriteLine(" Choose color : ");
            foreach (var item in Models.FindAll(n => n.Name == nameModel))
            {
                    foreach (var j in item.Modifications.FindAll(d => d.Name == nameModif))
                    {
                        foreach (var i in j._Colors)
                        {
                            Console.WriteLine(i.Name);
                        }
                    }
            }
            Write(" Enter name of color: ");
            string NameColor = ReadLine();
            return NameColor;
        }

        public void DeleteColor(List<CarModel> Models, string nameModel)
        {
            Write("\n\n DELETE color: ");
            string nameColor = ChooseColor(Models, nameModel);
            Models.FindAll(x => x.Name == nameModel).
                ForEach(s => s.Modifications.FindAll(z => z.Name == this.nameModif).
                ForEach(d => d._Colors.RemoveAll(c => c.Name == nameColor)));
            logger.Info("Delete color: " + nameColor);
        }

        public void ChangeColor(List<CarModel> Models, string nameModel)
        {
            Write("\n\n CHANGE color: ");
            string nameColor = ChooseColor(Models, nameModel);
            Write(" Enter new name of model: ");
            string newNameColor = ReadLine();
            Models.FindAll(x => x.Name == nameModel).
                   ForEach(m => m.Modifications.FindAll(z => z.Name == this.nameModif).
                   ForEach(d => d._Colors.FindAll(c => c.Name == nameColor).
                   ForEach(f => f.Name = newNameColor)));
            logger.Info("Change name of color: " + nameColor + " on " + newNameColor);
        }

        public void ChangeVendor(List<CarModel> Models, string nameModel)
        {
            Write("\n\n CHANGE vendorCode of color: ");
            string nameColor = ChooseColor(Models, nameModel);
            Write(" Enter new vendor code of model: ");
            string newVendorColor = ReadLine();
            Models.FindAll(x => x.Name == nameModel).
                   ForEach(m => m.Modifications.FindAll(z => z.Name == this.nameModif).
                   ForEach(d => d._Colors.FindAll(c => c.Name == nameColor).
                   ForEach(f => f.VendorId = newVendorColor)));
            logger.Info("Change vendor of color: " + nameColor + " - " + newVendorColor);
        }
    }
}


