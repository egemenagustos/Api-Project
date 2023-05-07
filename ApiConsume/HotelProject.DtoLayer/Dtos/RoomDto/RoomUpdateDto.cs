using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DtoLayer.Dtos.RoomDto
{
    public class RoomUpdateDto
    {
        [Required]
        public int Id { get; set; }

        [DisplayName("Oda Numarası")]
        [Required(ErrorMessage = "Lütfen {0} giriniz.")]
        public string RoomNumber { get; set; }

        [DisplayName("Oda Resmi")]
        [Required(ErrorMessage = "Lütfen {0} yükleyiniz.")]
        public string RoomCoverImage { get; set; }

        [DisplayName("Fiyat Bilgisi")]
        [Required(ErrorMessage = "Lütfen {0} giriniz.")]
        public int Price { get; set; }

        [DisplayName("Oda Başlığı")]
        [Required(ErrorMessage = "Lütfen {0} giriniz.")]
        public string Title { get; set; }

        [DisplayName("Yatak Sayısı")]
        [Required(ErrorMessage = "Lütfen {0} giriniz.")]
        public string BedCount { get; set; }

        [DisplayName("Banyo Sayısı")]
        [Required(ErrorMessage = "Lütfen {0} giriniz.")]
        public string BathCount { get; set; }

        [DisplayName("Wifi")]
        [Required(ErrorMessage = "Lütfen {0} bilgisi giriniz.")]
        public string Wifi { get; set; }

        [DisplayName("Açıklama")]
        [Required(ErrorMessage = "Lütfen {0} giriniz.")]
        public string Description { get; set; }
    }
}
