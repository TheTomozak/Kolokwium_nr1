using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium_nr1.DTOs.Requests
{
    public class AddPrescriptionRequest
    {
        [Required(ErrorMessage = "You must give Date")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "You must give DueDate")]
        public DateTime DueDate { get; set; }

        [Required(ErrorMessage = "You must give IdPatient")]
        public int IdPatient { get; set; }

        [Required(ErrorMessage = "You must give IdDoctor")]
        public int IdDoctor { get; set; }

        [Required(ErrorMessage = "You must give IdPrescription")]
        public int IdPrescription { get; set; }
    }
}
