using WpfTreeBD.Core;

namespace WpfTreeBD.Data {
    public class ElectricalSystemRepository {
        public void AddOrUpdateElectricalSystem(ElectricalSystem electricalSystem)
        {
            using (var context = new ElectricalSystemContext())
            {
                var existingElectricalSystem = context.ElectricalSystems.Find(electricalSystem.SelfId);
                if (existingElectricalSystem == null)
                {
                    context.ElectricalSystems.Add(electricalSystem);
                }
                else
                {
                    context.Entry(existingElectricalSystem).CurrentValues.SetValues(electricalSystem);
                }
                context.SaveChanges();
            }
        }
        public ElectricalSystem GetElectricalSystemById(string id)
        {
            using (var context = new ElectricalSystemContext())
            {
                return context.ElectricalSystems.Find(id);
            }
        }
        public void AddOrUpdateElectricPanel(ElectricPanel electricPanel)
        {
            using (var context = new ElectricalSystemContext())
            {
                var existingElectricPanel = context.ElectricPanels.Find(electricPanel.SelfId);
                if (existingElectricPanel == null)
                {
                    context.ElectricPanels.Add(electricPanel);
                }
                else
                {
                    context.Entry(existingElectricPanel).CurrentValues.SetValues(electricPanel);
                }
                context.SaveChanges();
            }
        }
        public ElectricPanel GetElectricPanelById(string id)
        {
            using (var context = new ElectricalSystemContext())
            {
                return context.ElectricPanels.Find(id);
            }
        }
    }
}