using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
   public static class Messages
    {
        public static string CarAdded = "Araba Eklendi";
        public static string CarDeleted = "Araba Silindi";
        public static string CarUpdated = "Araba Güncellendi";
        public static string CarAddedError = "Araba ismi 2 karakterden küçük olamaz ve günlük fiyatı sıfırdan büyük olmalı";
        public static string CarListed = "Arabalar Listelendi";
        public static string BrandUpdated = "Marka Güncellendi";
        public static string BrandAdded = "Marka Eklendi";
        public static string BrandDeleted = "Marka Silindi";
        public static string BrandListed = "Markalar Listelendi";
        public static string ColorUpdated = "Renk Güncellendi";
        public static string ColorAdded = "Renk Eklendi";
        public static string ColorDeleted = "Renk Silindi";
        public static string ColorListed = "Renkler Listelendi";
        public static string UserAdded="Kullanıcı Eklendi";
        public static string UserDeleted = "Kullanıcı Slindi";
        public static string UserUpdated = "Kullanıcı Güncellendi";
        public static string UserListed= "Kullanıcılar Listelendi";
        public static string CustomerAdded = "Müşteri Eklendi";
        public static string CustomerDeleted = "Müşteri Silindi";
        public static string CustomerListed = "Müşteriler Listelendi";
        public static string CustomerUpdated = "Müşteri Güncellendi";
        public static string RentalAdded = "Kiralama Bilgisi Eklendi";
        public static string RentalDeleted = "Kiralama Bilgisi Silindi";
        public static string RentalUptated = "Kiralama Bilgisi Güncellendi";
        public static string RentalListed = "Kiralama Bilgisi Listelendi";
        public static string RentalAddedError = "Teslim Edilmemiş Araba Kiralanamaz";
        public static string CarImageAdded = "Araba Resmi Eklendi";
        public static string CarImageUpdated = "Araba Resmi Güncellendi";
        public static string CarImageDeleted = "Araba Resmi Silindi";
        public static string CarImageNameInvalid = "Araba Resmi Ismi Geçersiz";
        public static string CarImagesListed = "Araba Resmi Listelendi";
        public static string CarImageCountOfCarError = "Bir Arabanın En Fazla 5 Resmi Olabilir";
        internal static string AuthorizationDenied="Yetkiniz Yok";
        internal static string UserRegistered="Kayıt Olundu";
        internal static string UserNotFound="Kullanıcı Bulunamadı";
        internal static string PasswordError="Şifre Yanlış";
        internal static string SuccessfulLogin="Başarılı Giriş";
        internal static string UserAlreadyExists="Kullanıcı Zaten Var";
        internal static string AccessTokenCreated="Token Oluşturuldu";
    }
}
