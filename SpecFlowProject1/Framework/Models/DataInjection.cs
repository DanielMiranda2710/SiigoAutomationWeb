namespace SpecFlowProject1.Framework.Models
{
    public class DataInjection
    {

        private const string siigoURL = "https://qastaging.siigo.com/#/login";
        private const string sigoPosURL = "https://pos.qa.siigo.com/auth/login";
        private string evidencesFilepath, jsonFilepath, fileNameJson;

        public DataInjection()
        {
            evidencesFilepath = @"C:\Users\Damicu\source\repos\SpecFlowProject1\SpecFlowProject1\StepDefinitions\Evidences\SiigoReport ";
            jsonFilepath = @"C:\Users\Damicu\source\repos\SpecFlowProject1\SpecFlowProject1\";
            fileNameJson = "secretData.json";
        }

        public string SiigoURL { get => siigoURL; }
        public string SiigoPosURL { get => sigoPosURL; }
        public string EvidencesFilepath { get => evidencesFilepath; set => evidencesFilepath = value; }
        public string JsonFilepath { get => jsonFilepath; set => jsonFilepath = value; }
        public string FileNameJson { get => fileNameJson; set => fileNameJson = value; }



    }
}
