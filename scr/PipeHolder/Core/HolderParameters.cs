using System.Collections.Generic;
using System.Linq;

namespace Core
{
    /// <summary>
    /// Класс, хранящий параметры держателя трубы
    /// </summary>
    public class HolderParameters
    {
        /// <summary>
        /// Список параметров
        /// </summary>
        public List<Parameter> ParametersList { get; } = new List<Parameter>();

        /// <summary>
        /// Флаг, определяющий корректность введенных данных
        /// </summary>
        public bool IsValidData => ParametersList.All(parameter => parameter.IsValidData);

        /// <summary>
        /// Создает экземпляр класса <see cref="HolderParameters"/>
        /// </summary>
        public HolderParameters()
        {
            SetDefault();
        }

        /// <summary>
        /// Индексатор, позволяющий получать элементы списка по значению
        /// <see cref="ParametersType"/>
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Parameter this[ParametersType index]
        {
            get => ParametersList.First(parameter => parameter.Name == index);
            set
            {
                var oldParameter = ParametersList.First(
                    parameter => parameter.Name == index);
                var i = ParametersList.IndexOf(oldParameter);
                ParametersList[i] = value;
            }
        }

        /// <summary>
        /// Установка списка параметров со значениями по умолчанию
        /// </summary>
        public void SetDefault()
        {
            ParametersList.Clear();
            ParametersList.Add(new Parameter(ParametersType.Height, 15, 40, 25));
            ParametersList.Add(new Parameter(ParametersType.ExternalDiameter, 20, 30, 30));
            ParametersList.Add(new Parameter(ParametersType.PipeDiameter, 10, 27.5, 15));
            ParametersList.Add(new Parameter(ParametersType.HolderDiameter, 60, 90, 60));
            ParametersList.Add(new Parameter(ParametersType.HoleDiameter, 4, 7.5, 6));
        }

        /// <summary>
        /// Метод для изменения ограничений у зависимых параметров
        /// </summary>
        public void CheckDependencyValue()
        {
            var currentHolderDiameter = this[ParametersType.HolderDiameter].Value;

            var externalDiameter = this[ParametersType.ExternalDiameter];
            this[ParametersType.ExternalDiameter] = new Parameter(externalDiameter.Name,
                externalDiameter.Min, currentHolderDiameter / 2, externalDiameter.Value);

            var currentExternalDiameter = this[ParametersType.ExternalDiameter].Value;

            var pipeDiameter = this[ParametersType.PipeDiameter];
            this[ParametersType.PipeDiameter] = new Parameter(pipeDiameter.Name,
                pipeDiameter.Min, currentExternalDiameter - 2.5, pipeDiameter.Value);

            var holeDiameter = this[ParametersType.HoleDiameter];
            this[ParametersType.HoleDiameter] = new Parameter(holeDiameter.Name,
                holeDiameter.Min, (currentHolderDiameter - currentExternalDiameter) / 4,
                holeDiameter.Value);
        }
    }
}
