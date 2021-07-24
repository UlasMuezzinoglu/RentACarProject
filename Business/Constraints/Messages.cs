using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constraints
{
    public static class Messages
    {

        // Brand Manager Messages
        public static string BrandAdded = "Marka Başarı ile Eklendi";
        public static string BrandDeleted = "Marka Başarı ile Silindi";
        public static string BrandCantDeledet = "Marka Silinemedi... Böyle Birşey Artık Olmayabilir.";
        public static string BrandsListed = "Markalar Başarı ile Listelendi";
        public static string BrandListed = "Marka Başarı ile Getirildi";
        public static string BrandUpdated ="Marka Başarı ile Güncellendi";
        public static string BrandCantUpdated = "Marka Güncellenemedi... Böyle Birşey Artık Olmayabilir";
        // End of Brand Manager Messages
        // Color Manager Messages
        public static string ColorDeleted = "Renk Başarı ile Silindi";
        public static string ColorCantDeleted = "Renk Silinemedi... Böyle Birşey Artık Olmayabilir.";
        public static string ColorsListed = "Renkler Başarı ile Listelendi";
        public static string ColorListed = "Renk Başarı ile Getirildi";
        public static string ColorUpdated = "Renk Başarı ile Güncellendi";
        public static string ColorCantUpdated = "Renk Güncellenemedi... Böyle Birşey Artık Olmayabilir.";
        // End of Color Manager Messages
        // Car Manager Messages
        public static string CarAdded = "Araba Başarı ile Eklendi";
        public static string CarDescInvalidLetterLenght = "Araç Açıklaması 2 Karakterden Büyük Olmalıdır.\n ";
        public static string CarPriceInvalidCost = "Araç Günlük Fiyatı 0 liradan den Fazla Olmalıdır.";
        internal static string CarDeleted = "Araba Başarı ile Silindi";
        internal static string CarCantDeleted = "Araba Silinemedi... Böyle Birşey Artık Olmayabilir.";
        internal static string CarListed = "Araba Başarı ile Getirildi";
        internal static string CarsListed = "Araba Başarı ile Listelendi";
        internal static string CarListedByBrand = "Araba Başarı ile Listelendi";
        internal static string CarListedByColor = "Araba Başarı ile Listelendi";
        internal static string CarUpdated = "Araba Başarı ile Güncellendi";
        internal static string CarCantUpdated = "Araba Güncellenemedi... Böyle Birşey Artık Olmayabilir.";
        internal static string CarsListedDetailDto = "Arabalar Başarı ile Listelendi";

        // End of Car Manager Messages
    }
}
