//using ChefDigital.Entities.Entities;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ChefDigital.Entities.DTO
//{
//    public class ClientDTO
//    {
//        public ClientDTO()
//        {
//            Addresses = new List<Address>();
//        }

//        [Required(ErrorMessage = "FisrtName é obrigatório")]
//        [MaxLength(100, ErrorMessage = "FisrtName deve ter no máximo 100 caracteres")]
//        public string FisrtName { get; set; }

//        [Required(ErrorMessage = "Surname é obrigatório")]
//        [MaxLength(100, ErrorMessage = "Surname deve ter no máximo 100 caracteres")]
//        public string Surname { get; set; }

//        [Required(ErrorMessage = "Telephone é obrigatório")]
//        [MaxLength(20, ErrorMessage = "Telephone deve ter no máximo 20 caracteres")]
//        public string Telephone { get; set; }

//        [Required(ErrorMessage = "Active é obrigatório")]
//        public bool Active { get; set; }

//        public virtual List<Address> Addresses { get; set; }


//        public Client ToClient()
//        {
//            Client clientNew = new Client()
//            {
//                FisrtName = this.FisrtName,
//                Surname = this.Surname,
//                Telephone = this.Telephone,
//                Active = this.Active,
//            };

//            //if (this.Addresses != null)
//            //{
//            //    Addresses = new List<Address>();
//            //    foreach (var addressDTO in this.Addresses)
//            //    {
//            //        Address address = new Address()
//            //        {
//            //            Street = addressDTO.Street,
//            //            Number = addressDTO.Number,
//            //            Neighborhood = addressDTO.Neighborhood,
//            //            City = addressDTO.City,
//            //            State = addressDTO.State,
//            //            ZipCode = addressDTO.ZipCode,
//            //            Country = addressDTO.Country
//            //        };

//            //        Addresses.Add(address);
//            //    }
//            //}

//            return clientNew;

//        }

//    }
//}
