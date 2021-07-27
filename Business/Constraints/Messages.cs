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
        public static string ColorAdded = "Renk Başarı ile Eklendi";
        public static string ColorDeleted = "Renk Başarı ile Silindi";
        public static string ColorCantDeleted = "Renk Silinemedi... Böyle Birşey Artık Olmayabilir.";
        public static string ColorsListed = "Renkler Başarı ile Listelendi";
        public static string ColorNotFound = "Renk Bulunamadı";
        public static string ColorListed = "Renk Başarı ile Getirildi";
        public static string ColorUpdated = "Renk Başarı ile Güncellendi";
        public static string ColorCantUpdated = "Renk Güncellenemedi... Böyle Birşey Artık Olmayabilir.";
        // End of Color Manager Messages
        // Car Manager Messages
        public static string CarAdded = "Araba Başarı ile Eklendi";
        public static string CarDescInvalidLetterLenght = "Araç Açıklaması 2 Karakterden Büyük Olmalıdır.\n ";
        public static string CarPriceInvalidCost = "Araç Günlük Fiyatı 0 liradan den Fazla Olmalıdır.";
        public static string CarDeleted = "Araba Başarı ile Silindi";
        public static string CarCantDeleted = "Araba Silinemedi... Böyle Birşey Artık Olmayabilir.";
        public static string CarListed = "Araba Başarı ile Getirildi";
        public static string CarsListed = "Araba Başarı ile Listelendi";
        public static string CarListedByBrand = "Araba Başarı ile Listelendi";
        public static string CarListedByColor = "Araba Başarı ile Listelendi";
        public static string CarUpdated = "Araba Başarı ile Güncellendi";
        public static string CarCantUpdated = "Araba Güncellenemedi... Böyle Birşey Artık Olmayabilir.";
        public static string CarsListedDetailDto = "Arabalar Başarı ile Listelendi";
        // End of Car Manager Messages
        // User Manager Messages
        public static string UserAdded = "Kullanıcı Başarı ile Eklendi";
        public static string UserDeleted = "Kullanıcı Başarı ile Silindi";
        public static string UserCantDeledet =  "Kullanıcı Silinemedi... Böyle Birşey Artık Olmayabilir.";
        public static string UserUpdated = "Kullanıcı Başarı ile Güncellendi";
        public static string UserCantUpdated = "Kullanıcı Güncellenemedi... Böyle Birşey Artık Olmayabilir.";
        public static string UsersListed = "Kullanıcılar Başarı ile Listelendi";
        public static string UserListed = "Kullanıcı Başarı ile Getirildi";
        // End of User Manager Messages
        // Customer Manager Messages
        public static string CustomerAdded = "Müşteri Başarı ile Eklendi";
        public static string CustomerDeleted = "Müşteri Başarı ile Silindi";
        public static string CustomerCantDeledet = "Müşteri Silinemedi... Böyle Birşey Artık Olmayabilir.";
        public static string CustomerUpdated = "Müşteri Başarı ile Güncellendi";
        public static string CustomerCantUpdated = "Müşteri Güncellenemedi... Böyle Birşey Artık Olmayabilir.";
        public static string CustomersListed = "Müşteriler Başarı ile Listelendi";
        public static string CustomerListed = "Müşteri Başarı ile Getirildi";
        // End of Customer Manager Messages
        // Rental Manager Messages
        public static string RentalAdded = "Kiralama Başarı ile Eklendi";
        public static string RentalDeleted = "Kiralama Başarı ile Silindi";
        public static string RentalCantDeledet = "Kiralama Silinemedi... Böyle Birşey Artık Olmayabilir.";
        public static string RentalsListed = "Kiralamalar Başarı ile Listelendi";
        public static string RentalListed = "Kiralama Başarı ile Getirildi";
        public static string RentalUpdated = "Kiralama Başarı ile Güncellendi";
        public static string RentalCantUpdated = "Kiralama Güncellenemedi... Böyle Birşey Artık Olmayabilir.";
        public static string RentalProblem = "Araç Kiralanamadı... Araç yok";
        // End of Rental Manager Messages
        // Car Image Manager Messages
        public static string OverflowCarImageMessage = "Aracın 5 ten fazla Resmi olamaz";
        public static string CarImageAdded = "Araç Resmi Başarı İle Eklendi";
        public static string CarImageNotFound = "Resim Bulunamadı";
        public static string CarImageDeleted = "Araç Resmi Silindi";
        public static string CarImagesListed = "Araç Resimleri Listeleni";
        public static string CarImageListed = "Araç Resimi Getirildi";
        internal static string CarImageUpdated = "Araç Resmi Güncellendi";
    }
}
