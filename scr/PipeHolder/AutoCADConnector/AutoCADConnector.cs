using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.Runtime;
using PipeHolder;

namespace AutoCADConnector
{
    /// <summary>
    /// Класс для связи AutoCAD с плагином
    /// </summary>
    public class AutoCADConnector : IExtensionApplication
    {
        [CommandMethod("StartPlugin")]
        public static void StartPlugin()
        {
            Application.ShowModelessDialog(new MainForm());
        }

        /// <inheritdoc/>
        public void Initialize()
        {
        }

        /// <inheritdoc/>
        public void Terminate()
        {
        }
    }
}
