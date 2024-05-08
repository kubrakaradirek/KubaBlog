Bu proje, Murat Yücedağ ile ASP.Net Core YouTube proje kampında 150 derslik bir süreç sonunda geliştirilmiştir. ASP.Net Core 6 MVC ile hazırlanmıştır. Proje geliştirilirken HTML5, CSS3, JS ve Bootstrap gibi teknolojiler kullanılmıştır. Ayrıca, Enttity Framework kullanılarak veritabanı işlemleri gerçekleştirilmiştir. Projede kullanılan eklentiler arasında DataTables, Google Chart, Full Calendar, Sweet Alert ve Fluent Validation bulunmaktadır. API'lerle desteklenen proje, Entity Framework Code First yaklaşımıyla oluşturulmuştur ve veritabanı olarak MsSql kullanılmıştır. N-Tier Architecture tabanlı bir ASP.Net MVC Projesi olan projede, SOLID prensiplerine mümkün olduğunca uyulmuştur. Kullanıcı, Yazar ve Admin panellerine sahip kapsamlı bir blog sitesi geliştirilmiştir.
N-Tier Architecture
•	Entity Layer
•	DataAccess Layer
•	Business Layer
•	Api  Layer
•	WebUI
Proje içeriğinde 4 kısım bulunmaktadrır
•	Admin Panel
•	Yazar Panel
•	Vitrin
Admin Panel
Dashboard
I.	Grafikler
II.	Mesajlar
III.	Kategoriler
IV.	Bloglar
V.	Yorumlar
VI.	Yazarlar
VII.	Roller
VIII.	Statik Rapor
IX.	Dinamik Rapor
X.	Çıkış Yap
Admin bilgileri database'de Hash'lenerek tutulmaktadır.
I.	1.Dashboard
Dashboardda Toplam Blog Sayısı, yeni mesaj sayısı,toplam yorumlar dinamik olarak gösterilmiştir. Tekirdağ hava durumu Weather API - OpenWeatherMap sitesinden api  kullanılarak çekilmiştir.
II.	2.Grafikler
Grafik olarak Google Chart Grafik kullanımıştır. Kategori-Başlık Grafiği (Pie Chart) grafiği mevcuttur.
III.	3.Mesajlar
İlk olarak iletişim Giden Kutusu,Gelen Kutusu ve yeni mesaj oluştur olarak ayrılmıştır.İletişim mesajlarını sadece yetkisi olan adminler taradından görülebilmektedir. İkinci olarak mesajlar kısmı Gmail benzeri bir mesajlaşma yapılabilmektedir.Buradan email ile yeni mesaj gönderilebilir ve gelen mesajlar giden mesajlar görüntülenebilir.
IV.	4.Kategoriler
Bu bölümde tüm kategoriler listelenmektedir.Kategoriler Aktif ve pasif yap butonlarından eş zamanlı olarak durumu güncellenebilir ve Kalıcı olarak silinebilir.Kategorilerin aktif pasif yapma durumu olduğundan güncellenme eklenmemiştir. Kategori sayfasından paging kulanılmıştır.
V.	Bloglar
Yazılan tüm bloglar tarihleriyle beraber görülüür ve detaylar butonundan direkt bloğa ulaşılabilir. 
VI.	Yorumlar
Kullanıcıların yaptığı tüm yorumlar kullanıcı başlık puanlarıyla beraber listeleenir puanlar oranlarına göre yeşil sarı ve kırmızı renkte görünür ve bloğa git butonundan direkt bloğa gidilebilir.
VII.	Yazarlar
Yazar listesin butonundan tüm yazarlar listelenir.Yazarın ekleme silme güncelleme ve idsine göre getirme işlemleri gerçekleşir.
VIII.	Roller
Identity ile oluşturulan rollen burda listelenir ekleme güncelleme silme işlemleri yapıalbilir.Yeni role ata butonundan olan yazarlar listesi açılır ve yeni rol atayabiliriz.Rol listesine dönebiliriz
IX.	13.Statik Rapor
zamanki kayıtlı kategori idleri ve isimleri bilgisayara excel formatında indirilir
X.	14.Dinamik Rapor
Dinamik olarak var olan tüm kateogri idleri ve isimleri excel formatında bilgisayar indirilir.
XI.	14.Çıkış Yap
Admin sistemden çıkış yapar ve ana sayfadaki login kısmına yönlendirilir
Yazar Paneli
•	Dashboard
•	Profilim	
•	Bloglarım	
•	Yeni Blog	
•	Gelen Mesajlar
•	Giden Mesajlar
•	Bildirimler
•	Siteye Git
•	Ayarlar 
•	Çıkış yap
Yazar bilgileri database'de Hash'lenerek tutulmaktadır.
I.	Dashboard
Bu bölümde, toplam blog sayısı, giriş yapan kullanıcının blog sayısı ve toplam kategori sayısı statik olarak çekilmiştir. Orta kısımda, eklenen son 10 blogun kategori ve tarihleri listelenmektedir. Her bir blogun detaylarına ulaşmak için "Detaylar" butonuna tıklanabilir. Ayrıca, yazar hakkında kısmında yazarın kullanıcı adı görüntülenirken, hemen altında ise kategorilerin durumu dinamik olarak
II.	Profilim
Bu bölümde, giriş yapan yazarın profil bilgilerini güncellemesi sağlanmaktadır. Yazarın ID'sine göre, ad, soyad, kullanıcı adı, e-posta ve resim yolu bilgileri getirilmektedir. Kullanıcı, bu bilgileri istediği şekilde güncelleyebilir.
III.	Bloglarım
IV.	Giriş yapan yazar kendi bloglarını görebilir. Durumunu aktif pasif yapabilir ve silmegüncelleme işlemi yapabilir.
V.	Yeni Blog
Bu bölümde, blog kategorisi seçerek yeni blog ekleme işlemi gerçekleştirilir.
VI.	Gelen Mesajlar
Yazar, kendine ait gelen mesajları görebilir, yeni mesaj oluşturabilir ve mesajları açabilir.
VII.	Giden Mesajlar
Yazar, gönderdiği mesajları görebilir, yeni mesaj oluşturabilir ve mesajları açabilir.
VIII.	Bildirimler
Kullanıcı, kendisine gelen günlük toplantı mesajlarını görebilir.
IX.	Siteye Git
Bu buton, kullanıcıyı blog sitesine yönlendirir.
X.	Çıkış Yap
Bu kısımda çıkış yaparak otomatik olarak kullanıcı sayfasındaki giriş yap bölümüne yönlendirilirsiniz.
Kullanıcı yüzünde giriş yapan kullanıcı istediği bloğa yorum yapabilir.Son blogları kullanıcı arayüzünde güncellenir. Bize ulaşın kısmından mesaj iletebilir.Giriş yapmayan kullanıcı üye olabilir veya abone ol bülteninden email adresiyle abone olabilir.Yazar ve admin eklemelerine göre dinamik bir formatta tasarlanmıştır.


