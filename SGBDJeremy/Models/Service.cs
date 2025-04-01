namespace SGBDJeremy.Models
{
    public class Service
    {
        private int _id;
        private string _name;
        private string _description;
        private decimal _price;

        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public string Description
        {
            get => _description;
            set => _description = value;
        }

        public decimal Price
        {
            get => _price;
            set => _price = value;
        }

        //les methodes ne sont plus dans les classes
        //public void DisplayDescription()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
