using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Builder;
using Core;

namespace PipeHolder
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Построитель модели
        /// </summary>
        private readonly HolderBuilder _builder = new HolderBuilder();

        /// <summary>
        /// Параметры модели
        /// </summary>
        private readonly HolderParameters _parameters = new HolderParameters();

        /// <summary>
        /// Словарь текстбокса со значением и параметра
        /// </summary>
        private Dictionary<ParametersType, TextBox> _valueTextBoxDictionary =
            new Dictionary<ParametersType, TextBox>();

        /// <summary>
        /// Словарь текстбокса с ограниченими и параметра
        /// </summary>
        private Dictionary<ParametersType, TextBox> _limitsTextBoxDictionary =
            new Dictionary<ParametersType, TextBox>();

        /// <summary>
        /// Словарь всплывающих подсказок и параметров
        /// </summary>
        private Dictionary<ParametersType, ToolTip> _toolTipsDictionary =
            new Dictionary<ParametersType, ToolTip>();

        /// <summary>
        /// Создает экземпляр класса <see cref="MainForm"/>
        /// </summary>
        public MainForm()
        {
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("es-US");

            InitializeComponent();
            SetStartValues();
            ShowCurrentValues();
            ShowCurrentLimits();
        }

        /// <summary>
        /// Метод для установки начальных значений параметров
        /// </summary>
        private void SetStartValues()
        {
            _valueTextBoxDictionary = new Dictionary<ParametersType, TextBox>
            {
                { ParametersType.Height, HeightTextBox },
                { ParametersType.ExternalDiameter, ExternalDiameterTextBox },
                { ParametersType.PipeDiameter, PipeDiameterTextBox },
                { ParametersType.HolderDiameter, HolderDiameterTextBox },
                { ParametersType.HoleDiameter, HoleDiameterTextBox }
            };

            _limitsTextBoxDictionary = new Dictionary<ParametersType, TextBox>
            {
                { ParametersType.Height, HeightLimitsTextBox },
                { ParametersType.ExternalDiameter, ExternalDiameterLimitsTextBox },
                { ParametersType.PipeDiameter, PipeDiameterLimitsTextBox },
                { ParametersType.HolderDiameter, HolderDiameterLimitsTextBox },
                { ParametersType.HoleDiameter, HoleDiameterLimitsTextBox }
            };

            _toolTipsDictionary = new Dictionary<ParametersType, ToolTip>
            {
                { ParametersType.Height, new ToolTip() },
                { ParametersType.ExternalDiameter, new ToolTip() },
                { ParametersType.PipeDiameter, new ToolTip() },
                { ParametersType.HolderDiameter, new ToolTip() },
                { ParametersType.HoleDiameter, new ToolTip() }
            };
        }

        /// <summary>
        /// Метод для отображения текущих значений
        /// </summary>
        private void ShowCurrentValues()
        {
            foreach (var parameterName in
                     Enum.GetValues(typeof(ParametersType)).Cast<ParametersType>())
            {
                _valueTextBoxDictionary[parameterName].Text =
                    _parameters[parameterName].Value.ToString();
            }
        }

        /// <summary>
        /// Метод для отображения текущих ограничений
        /// </summary>
        private void ShowCurrentLimits()
        {
            foreach (var parameterName in
                     Enum.GetValues(typeof(ParametersType)).Cast<ParametersType>())
            {
                _limitsTextBoxDictionary[parameterName].Text =
                    _parameters[parameterName].Limits;
            }
        }

        /// <summary>
        /// Обработчик события ввода значения в текстбокс
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_ChangeValue(object sender, EventArgs e)
        {
            var textBox = (TextBox)sender;
            var parameterName = _valueTextBoxDictionary.FirstOrDefault(
                keyValue => keyValue.Value == textBox).Key;
            var parameter = _parameters[parameterName];
            var toolTip = _toolTipsDictionary[parameterName];

            if (double.TryParse(textBox.Text, out var newValue))
            {
                try
                {
                    parameter.Value = newValue;
                    toolTip.SetToolTip(textBox, null);
                    textBox.BackColor = Color.White;
                    ShowCurrentLimits();
                }
                catch (ArgumentException exception)
                {
                    toolTip.SetToolTip(textBox, exception.Message);
                    textBox.BackColor = Color.LightCoral;
                }
            }
            else
            {
                toolTip.SetToolTip(textBox, "Необходимо ввести вещественное" +
                                            " число через точку");
                textBox.BackColor = Color.LightCoral;
            }

            BuildModelButton.Enabled = _parameters.IsValidData;
        }

        /// <summary>
        /// Построение модели
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BuildModelButton_Click(object sender, EventArgs e)
        {
            _builder.BuildHolder(_parameters);
        }

        /// <summary>
        /// Установка значений по умолчанию
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetDefaultButton_Click(object sender, EventArgs e)
        {
            _parameters.SetDefault();
            ShowCurrentValues();
            ShowCurrentLimits();
        }
    }
}
