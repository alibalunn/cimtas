<h1>Proje yükleme adımları</h1>

1 -> GitHub’dan projeyi klonlayınız:
	`git clone https://github.com/alibalunn/cimtas.git`

2 -> Proje klasörüne gidip bağımlılıkları yüklemek için aşağıdaki komutu çalıştırınız:
	`dotnet restore`

3 -> appsettings.json dosyasında, connection string'i kendi veritabanınıza göre güncelleyiniz.

4 -> Visual Studio ortamında projeyi açınız ve Package Manager Console’u açarak Persistence projesini seçiniz. (Proje onion architecture ile yapıldığı için veritabanı işlemleri Persistence katmanında yapıldı )

5 -> Aşağıdaki komutu kullanarak veritabanını oluşturunuz:
	`Update-Database`

Sistemde iki adet kullanıcı bulunmaktadır ->
(İlgili alanlara veritabanı üzerinden de erişilebilir.)
	Admin: username: `admin_admin` password: `adminpass1`
	User: username: `user_user` password: `userpass1`

Kullanıcı giriş durumuna dinamik şekilde layout güncellenmektedir. 
	Admin yetkili kullanıcılar tüm alanlara erişebilirken, 
	User yetkili kullanıcılar sadece ekleme ve listeleme alanına erişebilmektedir.

<h1>Ekran Görüntüleri</h1>


Veritabanı tasarımı

Not: Burada employees ile Leaves içerisinde table per hiarechi'ye benzer bir yaklaşım ile tasarladığım için iki tane foreign key gözükmektedir.
 <img width="841" height="716" alt="image" src="https://github.com/user-attachments/assets/8c061ef8-d797-4647-af6e-80f779d0da7c" />

Giriş Ekranı:

<img width="1876" height="837" alt="image" src="https://github.com/user-attachments/assets/8ec19187-fcad-4bd0-84c9-bf29402d1017" />

Dashboard saydası: 

<img width="1817" height="854" alt="image" src="https://github.com/user-attachments/assets/3bb91ea6-81e2-4aee-922f-b9398f54ecb8" />

İzin işlemleri sayfası: (kart görünümü):

<img width="1812" height="835" alt="image" src="https://github.com/user-attachments/assets/90dc6575-391d-48aa-aa16-99b746c55e5d" />

İzin işlemleri sayfası: (liste görünümü):

<img width="1795" height="826" alt="image" src="https://github.com/user-attachments/assets/4ae84cc7-9beb-4f2f-8a96-951579d36289" />

İzin ekleme ekranı:

<img width="1877" height="818" alt="image" src="https://github.com/user-attachments/assets/fb6afe1c-0d40-4869-bfe0-868cb2e9936f" />

İzin ayarları: 

<img width="1818" height="843" alt="image" src="https://github.com/user-attachments/assets/a5868b32-5aa5-4b45-a72b-62970b037dd7" />
