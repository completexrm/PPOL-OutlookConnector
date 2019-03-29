using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PPOLLib
{
    public interface IApiWorker
    {


    }

       
    public class ApiWorker
    {
        public void TestUpload()
        {
            var svc = new PPOLService.PsnNoteAPIService();
            
        }
    }
}
