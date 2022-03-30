using System;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using Core;

namespace Builder
{
    /// <summary>
    /// Класс для построения модели держателя трубы
    /// </summary>
    public class HolderBuilder
    {
        /// <summary>
        /// Номер объекта
        /// </summary>
        private ObjectId _holderId;

        /// <summary>
        /// Удаление старого объекта из документа
        /// </summary>
        /// <param name="transaction"></param>
        private void ClearDocument(Transaction transaction)
        {
            var activeDocument = Application.DocumentManager.MdiActiveDocument;
            activeDocument.SendStringToExecute("._zoom e ", false, false, false);
            activeDocument.Editor.Regen();

            if (_holderId == new ObjectId())
            {
                return;
            }

            var holder = transaction.GetObject(_holderId, OpenMode.ForWrite);
            holder.Erase(true);
        }

        /// <summary>
        /// Построение держателя трубы
        /// </summary>
        /// <param name="parameters"></param>
        public void BuildHolder(HolderParameters parameters)
        {
            // Получение текущего документа и базы данных
            var activeDocument = Application.DocumentManager.MdiActiveDocument;
            var database = activeDocument.Database;

            // Блокирование документа
            using (var documentLock = activeDocument.LockDocument())
            {
                // Начало транзакции
                using (var transaction = database.TransactionManager.StartTransaction())
                {
                    ClearDocument(transaction);

                    var blockTable = transaction.GetObject(database.BlockTableId,
                        OpenMode.ForRead) as BlockTable;
                    var blockTableRecord = transaction.GetObject(blockTable[BlockTableRecord.ModelSpace],
                        OpenMode.ForWrite) as BlockTableRecord;

                    // Получение параметров
                    var height = parameters[ParametersType.Height].Value;
                    var externalDiameter = parameters[ParametersType.ExternalDiameter].Value;
                    var pipeDiameter = parameters[ParametersType.PipeDiameter].Value;
                    var holderDiameter = parameters[ParametersType.HolderDiameter].Value;
                    var holeDiameter = parameters[ParametersType.HoleDiameter].Value;

                    // Создание держателя
                    var holder = CreateHolder(holderDiameter, externalDiameter, height);

                    // Вырезание отверстия под трубу
                    SubtractPipeHole(holder, pipeDiameter, height);

                    // Вырезание отверстий для крепления
                    SubtractHolesInHolder(holder, holderDiameter, externalDiameter,
                        holeDiameter, height);

                    // Добавление нового объекта в таблицу
                    blockTableRecord.AppendEntity(holder);
                    transaction.AddNewlyCreatedDBObject(holder, true);

                    _holderId = holder.Id;

                    // Сохранение изменений в базе данных
                    transaction.Commit();
                }
            }
        }

        /// <summary>
        /// Создание держателя, состоящего из двух цилиндров
        /// </summary>
        /// <param name="holderDiameter"></param>
        /// <param name="externalDiameter"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        private Solid3d CreateHolder(double holderDiameter, double externalDiameter, double height)
        {
            // Создание основания держателя
            var rootHeight = height / 5.0;
            var holder = new Solid3d();
            holder.SetDatabaseDefaults();
            holder.CreateFrustum(rootHeight, holderDiameter,
                holderDiameter, holderDiameter);

            // Перемещение основания держателя вверх, чтобы объект находился выше плоскости XY
            holder.TransformBy(Matrix3d.Displacement(new Point3d(0, 0, rootHeight / 2.0) -
                                                     Point3d.Origin));

            // Создание держателя трубы
            var pipeHolder = new Solid3d();
            pipeHolder.SetDatabaseDefaults();
            pipeHolder.CreateFrustum(height, externalDiameter,
                externalDiameter, externalDiameter);

            // Перемещение держателя трубы вверх, чтобы объект находился выше плоскости XY
            pipeHolder.TransformBy(Matrix3d.Displacement(new Point3d(0, 0, height / 2.0) -
                                                         Point3d.Origin));

            // Объединение цилиндров
            holder.BooleanOperation(BooleanOperationType.BoolUnite, pipeHolder);

            return holder;
        }

        /// <summary>
        /// Вырезание отверстия под трубу
        /// </summary>
        /// <param name="holder"></param>
        /// <param name="pipeDiameter"></param>
        /// <param name="height"></param>
        private void SubtractPipeHole(Solid3d holder, double pipeDiameter, double height)
        {
            // Создание отверстия под трубу
            var pipeHole = new Solid3d();
            pipeHole.SetDatabaseDefaults();
            pipeHole.CreateFrustum(height, pipeDiameter,
                pipeDiameter, pipeDiameter);

            // Перемещение цилиндра вверх, чтобы объект находился выше плоскости XY
            pipeHole.TransformBy(Matrix3d.Displacement(new Point3d(0, 0, height / 2.0) -
                                                         Point3d.Origin));

            // Вырезание отверстия
            holder.BooleanOperation(BooleanOperationType.BoolSubtract, pipeHole);
        }

        /// <summary>
        /// Вырезание отверстий для крепления к стене
        /// </summary>
        /// <param name="holder"></param>
        /// <param name="holderDiameter"></param>
        /// <param name="externalDiameter"></param>
        /// <param name="holeDiameter"></param>
        /// <param name="height"></param>
        private void SubtractHolesInHolder(Solid3d holder, double holderDiameter,
            double externalDiameter, double holeDiameter, double height)
        {
            var holeHeight = height / 5.0;
            
            // Угол в 30 градусов
            var angle = 30 * Math.PI / 180;

            // Координаты центров отверстий
            var aX = externalDiameter + (holderDiameter - externalDiameter) / 2.0;
            var aY = 0;
            var bX = aX * Math.Sin(angle);
            var bY = aX * Math.Cos(angle);
            var cX = bX;
            var cY = -bY;

            SubtractHole(holder, holeDiameter, holeHeight, -aX, aY);
            SubtractHole(holder, holeDiameter, holeHeight, bX, bY);
            SubtractHole(holder, holeDiameter, holeHeight, cX, cY);
        }

        /// <summary>
        /// Вырезание одного отверстия для крепления
        /// </summary>
        /// <param name="holder"></param>
        /// <param name="holeDiameter"></param>
        /// <param name="holeHeight"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private void SubtractHole(Solid3d holder, double holeDiameter,
            double holeHeight, double x, double y)
        {
            var hole = new Solid3d();
            hole.SetDatabaseDefaults();
            hole.CreateFrustum(holeHeight, holeDiameter,
                holeDiameter, holeDiameter);

            // Перемещение отверстий по нужным координатам
            hole.TransformBy(Matrix3d.Displacement(new Point3d(x, y, holeHeight / 2.0) -
                                                    Point3d.Origin));

            // Вырезание отверстия
            holder.BooleanOperation(BooleanOperationType.BoolSubtract, hole);
        }
    }
}
