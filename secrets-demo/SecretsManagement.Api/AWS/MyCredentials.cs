namespace SecretsManagement.Api.AWS
{
    public class MyCredentials
    {
        public string EcsSubnetId { get; set; }
        public string CONNECTIONSTRINGS__DEFAULT { get; set; }
        public string EcsSecuritygroupId { get; set; }
        public string CONNECTIONSTRINGS__PROVIDER { get; set; }
        public string ABP__REDISCACHE__CONNECTIONSTRING { get; set; }
        public string RdsIdentifier { get; set; }
        public string DdbIdentifier { get; set; }
        public string CONNECTIONSTRINGS__CLIENTMONGOCONNECTIONSTRING { get; set; }
        public string CONNECTIONSTRINGS__TENANTMONGOCONNECTIONSTRING { get; set; }
    }
}
