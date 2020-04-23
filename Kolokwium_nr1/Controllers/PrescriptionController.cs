using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Kolokwium_nr1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kolokwium_nr1.Controllers
{
    [Route("api/prescriptions")]
    [ApiController]
    public class PrescriptionController : ControllerBase
    {
        private String ConString = "Data Source=db-mssql;Initial Catalog=s18969;Integrated Security=True";

        [HttpGet("{id}")]
        public IActionResult GetDateAboutConcretPrescription(int id)
        {
            var listMedicament = new List<Medicament>();

            using (var con = new SqlConnection(ConString))
            using (var com = new SqlCommand())
            {
                com.Connection = con;
                com.CommandText =
                    "SELECT * FROM Prescription inner  join Prescription_Medicament On Prescription.IdPrescription= Prescription_Medicament.IdPrescription " +
                    "inner join  Medicament On Prescription_Medicament.IdMedicament = Medicament.IdMedicament WHERE Prescription.IdPrescription=@IdPrescription";
                
                com.Parameters.AddWithValue("IdPrescription", id);


                

                con.Open();
                var dataReader = com.ExecuteReader();
                if (dataReader.Read())
                {

                    var prescription = new Prescription();
                    var medicament =new  Medicament();

                    if (dataReader["IdPatient"] != DBNull.Value)
                        prescription.IdPatient = int.Parse(dataReader["IdPatient"].ToString());

                    if (dataReader["Date"] != DBNull.Value)
                        prescription.Date = DateTime.Parse(dataReader["Date"].ToString());

                    if (dataReader["DueDate"] != DBNull.Value)
                        prescription.DueDate = DateTime.Parse(dataReader["DueDate"].ToString());

                    if (dataReader["IdDoctor"] != DBNull.Value)
                        prescription.IdDoctor = int.Parse(dataReader["IdDoctor"].ToString());

                    if (dataReader["IdPrescription"] != DBNull.Value)
                        prescription.IdPrescription = int.Parse(dataReader["IdPrescription"].ToString());
                    /////////////////////////////////////////////////////////////////////////////////////////////
                    if (dataReader["Description"] != DBNull.Value)
                        medicament.Description = dataReader["Description"].ToString();

                    if (dataReader["Details"] != DBNull.Value)
                        medicament.Details = dataReader["Details"].ToString();

                    if (dataReader["Dose"] != DBNull.Value)
                        medicament.Dose = int.Parse(dataReader["Dose"].ToString());

                    if (dataReader["IdMedicament"] != DBNull.Value)
                        medicament.IdMedicament = int.Parse(dataReader["IdMedicament"].ToString());

                    if (dataReader["Name"] != DBNull.Value)
                        medicament.Name = dataReader["Name"].ToString();

                    if (dataReader["Type"] != DBNull.Value)
                        medicament.Type = dataReader["Type"].ToString();

                    listMedicament.Add(medicament);
                    prescription.MedicamentList = listMedicament;

                    return Ok(prescription);


                }

            }

            return NotFound("Prescription not found");
        }

    }
}