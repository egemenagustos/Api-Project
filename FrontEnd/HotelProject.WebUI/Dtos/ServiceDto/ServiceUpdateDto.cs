using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HotelProject.WebUI.Dtos.ServiceDto
{
    public class ServiceUpdateDto
    {
        [Required]
        public int Id { get; set; }

        [DisplayName("Hizmet İkonu")]
        [Required(ErrorMessage = "{0} linki giriniz!")]
        public string Icon { get; set; }

        [DisplayName("Hizmet Başlığı")]
        [Required(ErrorMessage = "{0} giriniz!")]
        public string Title { get; set; }

        [DisplayName("Hizmet Açıklaması")]
        [Required(ErrorMessage = "{0} giriniz!")]
        [StringLength(100, ErrorMessage = "{0} en fazla 100 karakter olabilir!")]
        public string Description { get; set; }
    }
}
