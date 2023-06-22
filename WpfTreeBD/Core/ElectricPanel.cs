using System;
using System.Collections.Generic;

namespace WpfTreeBD.Core {
    public class ElectricPanel:ElectricalSystem {
        /// <summary>
        /// Коэффициент мощности
        /// </summary>
        public double Coefficient { get; set; }
        /// <summary>
        /// Переопределение текста для UI
        /// </summary>
        /// <exception cref="Exception"></exception>
        public void ReSetUIText() {
            if (UIText == null) throw new Exception("Текст установлен");
            UIText = SelfName + 
                     " Pу=" + InstalledPower +
                     " Pp=" + CalculatedPower +
                     " Ip=" + SystemCurrent +
                     " cosFi=" + Coefficient;
        }

        public ElectricPanel(double coefficient, string selfId, string selfName, List<string> childrenId,
            double installedPower, double calculatedPower, double systemCurrent): base(selfId, selfName, childrenId,
            installedPower, calculatedPower, systemCurrent) {
            Coefficient = coefficient;
        }
    }
}