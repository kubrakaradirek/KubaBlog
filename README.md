Bu proje, Murat Yücedağ ile ASP.Net Core YouTube proje kampında 150 derslik bir süreç sonunda geliştirilmiştir. ASP.Net Core 6 MVC ile hazırlanmıştır. Proje geliştirilirken HTML5, CSS3, JS ve Bootstrap gibi teknolojiler kullanılmıştır. Ayrıca, Enttity Framework kullanılarak veritabanı işlemleri gerçekleştirilmiştir. Projede kullanılan eklentiler arasında DataTables, Google Chart, Sweet Alert ve Fluent Validation bulunmaktadır. API'lerle desteklenen proje, Entity Framework Code First yaklaşımıyla oluşturulmuştur ve veritabanı olarak MsSql kullanılmıştır. N-Tier Architecture tabanlı bir ASP.Net MVC Projesi olan projede, SOLID prensiplerine mümkün olduğunca uyulmuştur. Kullanıcı, Yazar ve Admin panellerine sahip kapsamlı bir blog sitesi geliştirilmiştir.

## N-Tier Architecture
-	Entity Layer
-	DataAccess Layer
-	Business Layer
-	Api  Layer
-	WebUI
  
### Proje içeriğinde 4 kısım bulunmaktadır

-	Admin Panel
  
-	Yazar Panel
  
-	Vitrin
  
## Admin Panel

1. Dashboard

2. Grafikler
 
3. Mesajlar

4. Kategoriler

5. Bloglar

6. Yorumlar

7. Yazarlar

8. Roller

9. Statik Rapor

10. Dinamik Rapor

11. Çıkış Yap

Admin bilgileri database'de Hash'lenerek tutulmaktadır.

1. Dashboard
  
Dashboardda Toplam Blog Sayısı, yeni mesaj sayısı,toplam yorumlar dinamik olarak gösterilmiştir. Tekirdağ hava durumu Weather API - OpenWeatherMap sitesinden api  kullanılarak çekilmiştir.

2. Grafikler

Grafik olarak Google Chart Grafik kullanımıştır. Kategori-Başlık Grafiği (Pie Chart) grafiği mevcuttur.

3. Mesajlar

İlk olarak iletişim Giden Kutusu,Gelen Kutusu ve yeni mesaj oluştur olarak ayrılmıştır.İletişim mesajlarını sadece yetkisi olan adminler taradından görülebilmektedir. İkinci olarak mesajlar kısmı Gmail benzeri bir mesajlaşma yapılabilmektedir.Buradan email ile yeni mesaj gönderilebilir ve gelen mesajlar giden mesajlar görüntülenebilir.

4. Kategoriler

Bu bölümde tüm kategoriler listelenmektedir.Kategoriler Aktif ve pasif yap butonlarından eş zamanlı olarak durumu güncellenebilir ve Kalıcı olarak silinebilir.Kategorilerin aktif pasif yapma durumu olduğundan güncellenme eklenmemiştir. Kategori sayfasından paging kulanılmıştır.

5. Bloglar

Yazılan tüm bloglar tarihleriyle beraber görülüür ve detaylar butonundan direkt bloğa ulaşılabilir. 

6. Yorumlar

Kullanıcıların yaptığı tüm yorumlar kullanıcı başlık puanlarıyla beraber listeleenir puanlar oranlarına göre yeşil sarı ve kırmızı renkte görünür ve bloğa git butonundan direkt bloğa gidilebilir.

7. Yazarlar

Yazar listesin butonundan tüm yazarlar listelenir.Yazarın ekleme silme güncelleme ve idsine göre getirme işlemleri gerçekleşir.

8. Roller

Identity ile oluşturulan rollen burda listelenir ekleme güncelleme silme işlemleri yapıalbilir.Yeni role ata butonundan olan yazarlar listesi açılır ve yeni rol atayabiliriz.Rol listesine dönebiliriz

9. Statik Rapor

Kayıtlı kategori idleri ve isimleri bilgisayara excel formatında indirilir

10. Dinamik Rapor

Dinamik olarak var olan tüm kateogri idleri ve isimleri excel formatında bilgisayar indirilir.

11. Çıkış Yap

Admin sistemden çıkış yapar ve ana sayfadaki login kısmına yönlendirilir

## Yazar Paneli

1. Dashboard

2. Profilim	

3. Bloglarım	

4. Yeni Blog	

5. Gelen Mesajlar

6. Giden Mesajlar

7. Bildirimler

8. Siteye Git

9. Çıkış yap

Yazar bilgileri database'de Hash'lenerek tutulmaktadır.

1. Dashboard
   
Bu bölümde, toplam blog sayısı, giriş yapan kullanıcının blog sayısı ve toplam kategori sayısı statik olarak çekilmiştir. Orta kısımda, eklenen son 10 blogun kategori ve tarihleri listelenmektedir. Her bir blogun detaylarına ulaşmak için "Detaylar" butonuna tıklanabilir. Ayrıca, yazar hakkında kısmında yazarın kullanıcı adı görüntülenirken, hemen altında ise kategorilerin durumu dinamik olarak çekilmiştir.

2. Profilim

Bu bölümde, giriş yapan yazarın profil bilgilerini güncellemesi sağlanmaktadır. Yazarın ID'sine göre, ad, soyad, kullanıcı adı, e-posta ve resim yolu bilgileri getirilmektedir. Kullanıcı, bu bilgileri istediği şekilde güncelleyebilir.

3. Bloglarım

Giriş yapan yazar kendi bloglarını görebilir. Durumunu aktif pasif yapabilir ve silme, güncelleme işlemi yapabilir.

4. Yeni Blog

Bu bölümde, blog kategorisi seçerek yeni blog ekleme işlemi gerçekleştirilir.

5. Gelen Mesajlar

Yazar, kendine ait gelen mesajları görebilir, yeni mesaj oluşturabilir ve mesajları açabilir.

6. Giden Mesajlar

Yazar, gönderdiği mesajları görebilir, yeni mesaj oluşturabilir ve mesajları açabilir.

7. Bildirimler

Kullanıcı, kendisine gelen günlük toplantı mesajlarını görebilir.

8. Siteye Git

Bu buton, kullanıcıyı blog sitesine yönlendirir.

9. Çıkış Yap
Bu kısımda çıkış yaparak otomatik olarak kullanıcı sayfasındaki giriş yap bölümüne yönlendirilirsiniz.

Kullanıcı yüzünde giriş yapan kullanıcı istediği bloğa yorum yapabilir.Son blogları kullanıcı arayüzünde güncellenir. Bize ulaşın kısmından mesaj iletebilir.Giriş yapmayan kullanıcı üye olabilir veya abone ol bülteninden email adresiyle abone olabilir.Yazar ve admin eklemelerine göre dinamik bir formatta tasarlanmıştır.

https://github.com/kubrakaradirek/KubaBlog/assets/133059827/25e64128-5170-4612-bde7-73eb117e4683








