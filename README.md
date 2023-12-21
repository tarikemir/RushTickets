RushTickets
--------------

Proje Açıklaması:
---------------------
RushTickets düzenlenen etkinlikleri görebilmeyi amaçlayan web uygulamasıdır.Kullanıcı başarılı giriş yaptıktan sonra biletleri görüntüleyebilir.

Projeye Eklediğimiz Özellikler:
-----------------------------
Kullanıcı Kayıt Ve Giriş işlemi Kullanıcı kayıt olabilir ve sonrasında giriş işlemlerini gerçekleştirebilir . Bilet Oluşturma *Admin kullanıcıya sunulması için bilet oluşturabilir. Bilet Sayfası *Kullanıcı başarılı giriş yaptıysa Ticket sayfasına yönlendirilir.

Projeye Eklediğimiz Özellikler(Detaylı):
------------------
Kullanıcı Kayıt Ve Giriş işlemi

Kullanıcı kayıt ve login işlemi için User Identity mekanizması kullanıldı.Register işlemi sonrasında toaster için NToastNotify paketi kullanılarak kayır işleminin başarılı gerçekleştiği mesajı iletilir.Ayrıca mail gönderim işlemi sağlanır.Kullanıcı kayıt için Microsoft.AspNetCore.Identity paketini kullandık.

Login işlemi için eğer yanlış bilgi girilmişse validasyon devreye girer balarılı ise Database de kaydolan kullanıcı bilgileri giriş yaptıktan sonra toaster ile bilgilendirme yapılır. Bilet Oluşturma

Bilet Ticket classı içerisinde Guid Id, Name, Description ve Price gibi özellikleri tanımladık.Sonrasında TicketController sınıfında Http Get/Set' i kullanarak yapmak istediğimiz kontrolleri ekledik views için CreateTicket ve Index'i eklediK.

Bilet Sayfası

Başarılı giriş yapıldıktan sonra ticket sayfasına yönlendirildi adminin kaydettiği db den alınan datalar Index ile ekranda gösterildi.

Görev Dağılımı:
-----
Tarık Emir Kaldırım:Identity Mechanism, Toaster Notifications ve Dependency Injection

Sude Nur Opan:Mail Authentication, Ticket page ve Interception Mechanism

Volkan İnce:Repository Pattern, Entity changes

İrem Demir:Interception Mechanism

Yakup Can Sıtacı:Fluent Validation

Yaşadığımız Problemler :
--
Application db context ve user identity context'in migration ve database'e eklenmesinde gecikmeler yaşadındı.Mail için domain oluşturup hosting kısmı için uygun site bulunamadı.
