using ChefDigital.Entities.Entities.Generics;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChefDigital.Entities.Entities
{
    public class Client : EntityBase
    {

        public Client()
        {
            SetDataAlteracao(DateTime.MinValue);
            Active = true;
        }

        [Required(ErrorMessage = "FisrtName é obrigatório")]
        [MaxLength(100, ErrorMessage = "FisrtName deve ter no máximo 100 caracteres")]
        public string FisrtName { get; set; }

        [Required(ErrorMessage = "Surname é obrigatório")]
        [MaxLength(100, ErrorMessage = "Surname deve ter no máximo 100 caracteres")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Telephone é obrigatório")]
        [MaxLength(20, ErrorMessage = "Telephone deve ter no máximo 20 caracteres")]
        public string Telephone { get; set; }

        [Required(ErrorMessage = "Active é obrigatório")]
        public bool Active { get; private set; }

        public void SetActiveFalse()
        {
            Active = false;
        }

        //public List<Address> Addresses { get; set; }
    }
}
