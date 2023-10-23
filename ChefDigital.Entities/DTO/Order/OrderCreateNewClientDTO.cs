using ChefDigital.Entities.Entities;
using System.Data;
using System.Text.RegularExpressions;

namespace ChefDigital.Entities.DTO
{
    public class OrderCreateNewClientDTO
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }

        private string _telephone;
        public string Telephone
        {
            get
            {
                return _telephone;
            }

            set
            {
                if (ValidatePhone(value))
                {
                    _telephone = value;
                }
                else
                {
                    throw new ArgumentException("Número de telefone inválido!");
                }
            }
        }

        public string Email { get; set; }

        public string Street { get; set; }
        public int Number { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        private string _zipCode;
        public string ZipCode { get; set; }


        public List<OrderedItemDTO>? OrderedItems { get; set; }

        private bool ValidatePhone(string phone)
        {
            var phonePattern = @"^(\([0-9]{2}\))?[0-9]{4,5}-?[0-9]{4}$";
            return Regex.IsMatch(phone, phonePattern);
        }

        private bool ValidateZipCode(string zipCode)
        {
            var zipCodePattern = @"^\d{5}-\d{3}$";
            return Regex.IsMatch(zipCode, zipCodePattern);
        }

        public Entities.Client ToClient()
        {
            Entities.Client client = new Entities.Client()
            {
                FirstName = FirstName,
                Surname = Surname,
                Telephone = Telephone,
                Email = Email
            };
            return client;
        }

        public Entities.Address ToAddress()
        {
            Entities.Address address = new Entities.Address()
            {
                Street = this.Street,
                Number = this.Number,
                Neighborhood = this.Neighborhood,
                City = this.City,
                ZipCode = this.ZipCode
            };
            return address;
        }
       
        //public List<OrderedItem> ToOrderedItem()
        //{
        //    return OrderedItems?.Select(item => new OrderedItem(
        //        item.OrderId,
        //        item.Item,
        //        item.UnitValue,
        //        item.ItemQuantity
        //    )).ToList();
        //}

    }
}
