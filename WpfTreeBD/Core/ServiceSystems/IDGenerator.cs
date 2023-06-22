namespace WpfTreeBD.Core.ServiceSystems {
    public static class IdGenerator {
        private static int _counter = 0;
        
        public static string GenerateId() {
            return "ID" + _counter++;
        }
    }
}