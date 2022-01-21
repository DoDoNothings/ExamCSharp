using System;

namespace CarsBase.Entities
{
    [Serializable]
    /// <summary>
    /// Базовый класс для цветов, млдификаторов и моделей
    /// </summary>
    public abstract class BASE
    {
        /// <summary>
        /// Уникальный идентификатор базе данных
        /// </summary>
        public Guid ID { get; set; }

        /// <summary>
        /// Название 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Код по таблице производителя
        /// </summary>
        public string VendorId { get; set; }

        public BASE() { ID = Guid.NewGuid(); }

        public BASE(string _name, string _code)
        {
            ID = Guid.NewGuid();
            this.Name = _name;
            VendorId = _code;
        }
        public BASE(string _name)
        {
            this.Name = _name;
        }
    }
}

