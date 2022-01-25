using CarsBase.Entities.Colors;
using CarsBase.Entities.Models;
using CarsBase.Entities.Modifications;
using System;
using System.Collections.Generic;
using static System.Console;
using NLog;
using System.Xml.Serialization;
using System.IO;
using CarsBase.Entities;
using System.Linq;

namespace CarsBase
{
    [Serializable]

    public class LineUp : BASE
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        string fileName = "E:\\ExamCSharp\\CarsBase\\models.xml";

        public List<CarModel> Models { get; set; }

        public XmlSerializer xmlser = new XmlSerializer(typeof(List<CarModel>));

        public LineUp()
        {
            Models = new List<CarModel>();

            //// создание базы
          //  CreateLineUp(); 
           // SerialXML();

            Models = readBase();

            //// модели
            //AddModel(Models);
            CarModel model = new CarModel();
            //model.AddModification(Models);
            //model.ChangeModel(Models);
            //model.ChangeVendorModel(Models);
            //model.DeleteModel(Models);

            //////// модификации 
            CarModification modif = new CarModification();
            //modif.AddColor(Models, model.ChooseModel(Models));
            //modif.ChangeModification(Models, model.ChooseModel(Models));
            //modif.DeleteModification(Models, model.ChooseModel(Models));
            //modif.ChangeVendorModif(Models, model.ChooseModel(Models));

            ////// цвета 
            CarBodyColor colors = new CarBodyColor();
            //colors.ChangeColor(Models, model.ChooseModel(Models));
            //colors.ChangeColor(Models, model.ChooseModel(Models));
            //colors.DeleteColor(Models, model.ChooseModel(Models));
            //colors.ChangeVendor(Models, model.ChooseModel(Models));

            SeachColor();
            //Show();

            //SerialXML();
        }

        public void AddModel(List<CarModel> Models)
        {
            Write("\n\n ADD new model: ");
            Write("\n Enter name of new model: ");
            string name = ReadLine();
            Write(" Enter vendorCode of new model: ");
            string vendorCode = ReadLine();
            CarModel newModel = new CarModel(name, vendorCode);
            Models.Add(newModel);
            logger.Info("Add  model: " + name);
        }

        public void Show()
        {
            foreach (var j in Models)
            {
                WriteLine("!MODEL =>" + j.ID + " " + j.Name + " " + j.VendorId);
                foreach (var yy in j.Modifications)
                {
                    WriteLine("\t!MODIFICATOR =>" + yy.ID + " " + yy.Name + " " + yy.VendorId);
                    foreach (var p in yy._Colors)
                    {
                        WriteLine("\t\t!color =>" + p.ID + " " + p.Name + " " + p.VendorId);
                    }
                }
            }
        }

        public void CreateLineUp()
        {
            Write("Укажите количество моделей :");
            int countModel = Convert.ToInt32(Console.ReadLine());
            for (int j = 0; j < countModel; j++)
            {
                Write($"Введите название {j + 1} модели: ");
                string _nameModel = ReadLine();
                Write($"Введите код {j + 1} модели: ");
                string _codeModel = ReadLine();
                CarModel model = new CarModel(_nameModel, _codeModel);

                Write("\tУкажите количество модификаций этой модели :");
                int countModif = Convert.ToInt32(Console.ReadLine());
                for (int i = 0; i < countModif; i++)
                {
                    Write($"\tВведите название {i + 1} модификации модели: ");
                    string _nameModif = ReadLine();
                    Write($"\tВведите код {i + 1} модификации модели: ");
                    string _codeModif = ReadLine();
                    CarModification newModification = new CarModification(_nameModif, _codeModif);
                    Write($"\t\tУкажите количество цветов {i + 1} модификации :");
                    int countColor = Convert.ToInt32(Console.ReadLine());
                    for (int ii = 0; ii < countColor; ii++)
                    {
                        Write($"\t\tВведите название {ii + 1} цвета кузова: ");
                        string _nameColor = ReadLine();
                        Write($"\t\tВведите код  {ii + 1} цвета кузова: ");
                        string _codeColor = ReadLine();
                        CarBodyColor newColor = new CarBodyColor(_nameColor, _codeColor);
                        newModification._Colors.Add(newColor);
                        logger.Info("Создание цвета: " + _nameColor + " (" + _codeColor + ")");
                    }
                    model.Modifications.Add(newModification);
                    logger.Info("Добавление к модели: " + _nameModel + " (" + _codeModel + ") " +
                                " модификациии : " + _nameModif + " ( " + _codeModif + " )");
                }
                Models.Add(model);
                logger.Info("Добавление модели: " + _nameModel + " (" + _codeModel + ")");
            }
        }

        public void SeachColor()
        {
            allColor();
            Write($"\tEnter color : ");
            string color = ReadLine();
            StreamReader srdr = new StreamReader(fileName);
            List<CarModel> p = (List<CarModel>)xmlser.Deserialize(srdr);
            WriteLine($"All models in {color} color: ");
            int c = 0;
            foreach (var item in p)
            {
                if (item.Modifications.Exists(n => n._Colors.Exists(c => c.Name.Contains(color))) == true)
                {
                    c++;
                    foreach (var i in item.Modifications)
                    {
                        if (i._Colors.Exists(c => c.Name.Contains(color)))
                        {
                            foreach (var y in i._Colors)
                            {
                                if (y.Name.Contains(color))
                                {
                                    WriteLine($"{item.Name} ({item.VendorId}) -> {i.Name} ({i.VendorId}) -> {y.Name} ({y.VendorId})");
                                }
                            }
                        }
                    }
                }
            }
            if(c==0) WriteLine($"No models with {color} color");            
            srdr.Close();
        }

        public void SerialXML()
        {
            try
            {
                using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
                {
                    xmlser.Serialize(fs, Models);
                    fs.Close();
                }
            }
            catch (Exception e)
            {
                WriteLine("Exception: " + e.Message);
            }
        }

        public List<CarModel> readBase()
        {
            try
            {
                WriteLine("\t\tALL MODELS: ");
            StreamReader srdr = new StreamReader(fileName);
            List<CarModel> p = (List<CarModel>)xmlser.Deserialize(srdr);
            foreach (var item in p)
            {
                WriteLine($" {item.Name} {item.VendorId}");
                foreach (var i in item.Modifications)
                {
                    WriteLine($"\t {i.Name} {i.VendorId}");
                    foreach (var y in i._Colors)
                    {
                        WriteLine($"\t\t {y.Name} {y.VendorId}");
                    }
                }
            }
            srdr.Close();
            return p;
        }
             catch (Exception e)
            {
                WriteLine("Exception: " + e.Message);
            }
            return new List<CarModel>();
        }

        
        public void allColor()
        {
            try
            {
                WriteLine("\n\tALL COLORS in base :");
                StreamReader srdr = new StreamReader(fileName);
                List<CarModel> p = (List<CarModel>)xmlser.Deserialize(srdr);
                List<CarBodyColor> all = new List<CarBodyColor>();
                
                foreach (var item in p)
                {
                    foreach (var i in item.Modifications)
                    {
                        foreach (var y in i._Colors)
                        {
                            all.Add(y);
                        }
                    }
                }
            
               var allColors = all.GroupBy(x => x?.Name).Select(x => x.First()).ToList();
                foreach (var w in allColors)
                {
                    WriteLine($"{w.Name}");
                }
            }
            catch (Exception e)
            {
                WriteLine("Exception: " + e.Message);
            }

        }
    }


}




