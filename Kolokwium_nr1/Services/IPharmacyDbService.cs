using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium_nr1.Services
{
    interface IPharmacyDbService
    {
        PharmacyExceptionHelper GetDateAboutConcretPrescription(int id);
    }
}
