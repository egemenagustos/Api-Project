using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DtoLayer.Dtos.RoomDto
{
    public class RoomAddDto
    {
        [DisplayName("Oda Numarası")]
        [Required(ErrorMessage = "Lütfen {0} giriniz.")]
        public string RoomNumber { get; set; }

        [DisplayName("Oda Resmi")]
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
        public string Wifi { get; set; }

        [DisplayName("Açıklama")]
        public string Description { get; set; }
    }
}
