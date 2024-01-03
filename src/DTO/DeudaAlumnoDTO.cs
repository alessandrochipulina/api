namespace Api.DTO
{
    public class DeudaAlumnoDTO
    {
        public string TYPE { get; set; }
        public string IDNUMBER { get; set; }
        public string VKORG { get; set; }
        public string VTWEG { get; set; }
        public string SPART { get; set; }
        public string CODCARRERA { get; set; }
        public string CODYEAR { get; set; }
        public string CODPERID { get; set; }
        public string CONCEPTO { get; set; }
        public int? CUOTA { get; set; }
    }
    public class rootDeudaSAP
    {
        public objectDeudaSAP[] Ent_inputSet { get; set; }
    }

    public class objectDeudaSAP
    {
        public string TYPE { get; set; }
        public string IDNUMBER { get; set; }
        public string VKORG { get; set; }
        public string VTWEG { get; set; }
        public string SPART { get; set; }
        public string CODCARRERA { get; set; }
        public string CODYEAR { get; set; }
        public string CODPERID { get; set; }
        public string CONCEPTO { get; set; }
        public int? CUOTA { get; set; }
    }
    //********
    public class EstadoCuentaAlumnoDTO
    {
        public string TYPE { get; set; }
        public string IDNUMBER { get; set; }
        public string VKORG { get; set; }
        public string VTWEG { get; set; }
        public string SPART { get; set; }
        public string CODCARRERA { get; set; }
        public string CODYEAR { get; set; }
        public string CODPERID { get; set; }
        public string REFERENCIA { get; set; }
        public string SOLO_VENCIDO { get; set; }
        public string SOLO_PAGOS { get; set; }
        //public rootEstadoCuentaSAP rootEstadoCuentaSAP { get; set; }
    }
    public class rootEstadoCuentaSAP
    {
        public objectEstadoCuentaSAP[] Ent_inputSet { get; set; }
    }
    public class objectEstadoCuentaSAP
    {
        public string TYPE { get; set; }
        public string IDNUMBER { get; set; }
        public string VKORG { get; set; }
        public string VTWEG { get; set; }
        public string SPART { get; set; }
        public string CODCARRERA { get; set; }
        public string CODYEAR { get; set; }
        public string CODPERID { get; set; }
        public string REFERENCIA { get; set; }
        public string SOLO_VENCIDO { get; set; }
        public string SOLO_PAGOS { get; set; }
    }

}
