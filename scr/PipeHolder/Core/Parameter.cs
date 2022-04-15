using System;

namespace Core
{
    /// <summary>
    /// Класс <see cref="Parameter"/> хранит данные о параметре держателя трубы
    /// </summary>
    public class Parameter : ICloneable
    {
        /// <summary>
        /// Текущее значение параметра
        /// </summary>
        private double _value;

        /// <summary>
        /// Название параметра
        /// </summary>
        public ParametersType Name { get; }

        /// <summary>
        /// Минимальное значение параметра
        /// </summary>
        public double Min { get; }

        /// <summary>
        /// Максимальное значение параметра
        /// </summary>
        public double Max { get; }

        /// <summary>
        /// Задает и возвращает текущее значение параметра,
        /// проверка на корректность введенных данных
        /// </summary>
        public double Value
        {
            get => _value;
            set
            {
                if (value < Min || value > Max)
                {
                    IsValidData = false;
                    ErrorDescription =
                        $"Значение должно быть от {Min} мм до {Max} мм";
                }
                else
                {
                    IsValidData = true;
                    ErrorDescription = "";
                }

                _value = value;
            }
        }

        /// <summary>
        /// Флаг, определяющий корректность введенных данных
        /// </summary>
        public bool IsValidData { get; private set; } = true;

        /// <summary>
        /// Ограничения для значения параметра
        /// </summary>
        public string Limits => $"({Min}-{Max} мм)";

        /// <summary>
        /// Описание ошибки
        /// </summary>
        public string ErrorDescription { get; private set; }

        /// <summary>
        /// Создает экземпляр класса <see cref="Parameter"/>
        /// </summary>
        /// <param name="name"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <param name="value"></param>
        public Parameter(ParametersType name, double min, double max, double value)
        {
            Name = name;
            Min = min;
            Max = max;
            Value = value;
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            var parameter = obj as Parameter;

            if (parameter == null)
            {
                return false;
            }

            if (parameter.Name == Name && parameter.Min == Min &&
                parameter.Max == Max && parameter.Value == Value)
            {
                return true;
            }

            return false;
        }

        /// <inheritdoc/>
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}