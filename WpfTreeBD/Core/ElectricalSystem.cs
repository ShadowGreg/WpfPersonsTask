using System;
using System.Collections.Generic;

namespace WpfTreeBD.Core {
    public class ElectricalSystem: BaseNode {
        /// <summary>
        /// Установленная мощность
        /// </summary>
        public double InstalledPower { get; set; }
        /// <summary>
        /// Расчётная мощность
        /// </summary>
        public double CalculatedPower { get; set; }
        /// <summary>
        /// Расчётный ток системы
        /// </summary>
        public double SystemCurrent { get; set; }
        /// <summary>
        /// Переопределение текста для UI
        /// </summary>
        /// <exception cref="Exception"></exception>
        public void ReSetUIText() {
            if (UIText == null) throw new Exception("Текст установлен");
            UIText = SelfName + " Pу=" + InstalledPower + " Pp=" + CalculatedPower + " Ip=" + SystemCurrent;
        }

        public ElectricalSystem(
            string selfName,
            List<string> childrenId,
            double installedPower, 
            double calculatedPower, 
            double systemCurrent): base(selfName,childrenId) {
            InstalledPower = installedPower;
            CalculatedPower = calculatedPower;
            SystemCurrent = systemCurrent;
        }
        
        public ElectricalSystem(
            string selfId, 
            string selfName,
            List<string> childrenId,
            double installedPower, 
            double calculatedPower, 
            double systemCurrent): base(selfId,selfName,childrenId) {
            InstalledPower = installedPower;
            CalculatedPower = calculatedPower;
            SystemCurrent = systemCurrent;
        }
    }
}