//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations.Schema;
//using System.Linq;
//using System.Text;
//using System.Text.Json.Serialization;
//using System.Threading.Tasks;

//namespace ChefDigital.Entities.Enums
//{
//    public class Notifies
//    {
//        public Notifies()
//        {
//            Notitycoes = new List<Notifies>();
//        }

//        [NotMapped]
//        [JsonIgnore]
//        public string NomePropriedade { get; set; }
//        [NotMapped]
//        [JsonIgnore]
//        public string Mensagem { get; set; }
//        [NotMapped]
//        [JsonIgnore]
//        public List<Notifies> Notitycoes { get; set; }


//        public bool ValidaPropriedadeString(string valor, string nomePropriedade)
//        {
//            if(string.IsNullOrWhiteSpace(valor) || string.IsNullOrWhiteSpace(nomePropriedade))
//            {
//                Notitycoes.Add(new Notifies
//                {
//                    Mensagem = "Campo obrigatorio",
//                    NomePropriedade = nomePropriedade
//                });
//                return false;
//            }

//            return true;
//        }
//        public bool ValidaPropriedadeInt(int valor, string nomePropriedade) 
//        {
//            if(valor < 1 || string.IsNullOrEmpty(nomePropriedade)) 
//            {
//                Notitycoes.Add(new Notifies
//                {
//                    Mensagem = "Campo obrigado",
//                    NomePropriedade = nomePropriedade,
//                });
//                return false;
//            }
//            return true;
//        }
//    }
//}
