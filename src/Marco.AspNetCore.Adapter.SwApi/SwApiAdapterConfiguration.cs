using System.ComponentModel.DataAnnotations;

namespace Marco.AspNetCore.Adapter.SwApi
{
    public class SwApiAdapterConfiguration
    {
        [Required]
        public string SwApiUrlBase { get; set; }
    }
}