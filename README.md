
# Warehouse System Demo

Bu demo temel anlamda bir depo altyapısının nasıl çalışması gerektiğine dair temel öğeleri barındırıyor.
Sistemin veritabanını yerel makinemde **Microsoft SQL Server Management Studio** ile tutup,
ASP.NET MVC nugget paketi ile birleştirdim. Böylece temel kullanıcı girişi sistemleri, kullanıcı yönetimi,
ürün yönetimi, güvenlik ve hızlı veri etkileşimi sistemlerini tasarlayabildim.


### Nasıl Çalıştırılır?
Gerekli Uygulamalar:
- Microsoft SQL Server Management Studio
- Visual Studio 2022 w/ASP.NET 

Öncelikle database dependency klasöründe bulunan veritabanı kopyalarını **Microsoft SQL Server Management Studio**'ya
kurmanız gerekiyor. Klasörde bulunan .mdf dosyalarını *"C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA"*
konumuna kopyaladıktan sonra database uygulamasının içinden kolaylıkla kurulumunu sağlayabilirsiniz.

Veritabanımızı kurduktan sonra sıra ASP.NET'in Model bölümüne database bağlantısını kurmaya geliyor. Bunun için aşağıdaki aşamaları sırasıyla izleyiniz.

1/4

![Database-Dependency](https://user-images.githubusercontent.com/73427323/211585739-906402f6-4bcf-471f-839e-86733a5d15d9.png)

2/4

![dependency png1 png](https://user-images.githubusercontent.com/73427323/211585904-4afcfa94-8636-4ee1-8eed-5fc52d27335d.png)

3/4

![dependency2](https://user-images.githubusercontent.com/73427323/211585913-547d9376-a47f-43e9-aa03-2cb164db9062.png)

Bu noktadan sonra başarıyla Model klasörüne veritabanınızın eklendiğini göreceksiniz. Fakat Controller'ın veritabanı entity'nizi tanıması için Web.Config dosyasında aşağıdaki gibi yazdığından emin olun.

4/4

![dependency3](https://user-images.githubusercontent.com/73427323/211586335-7c8adb96-4348-4446-8b59-d2648bb367df.png)

Tebrikler! Sisteme yerel veritabanınızı bağladınız ve artık uygulamayı çalıştırabilirsiniz.

### Nasıl Kullanılır?

Sisteme giriş yaptığınızda öncelikle karşınızda login sayfası belirecek. Burada admin@admin.com ve 12345 bigilerini kullanarak ve Captcha doğrulamasını geçerek giriş yapabilirsiniz. 

***(Not: Sistem oluşturulan kullanıcıların şifrelerini hashlediğinden dolayı veritabanında şifreleri görüntüleyemeyeceksiniz. Bu nedenle veritabanınızdan kullanıcılarınızın şifre sızdırımı gerçekleştirilemez.)***

![Screenshot_12](https://user-images.githubusercontent.com/73427323/211587269-4ec645f8-eb9e-4e23-a59a-07dec0f17233.png)

Giriş yaptıktan sonra aşağıdaki basit veritabanı table tasarımı önünüzde belirecek. Bu sayfa üzerinde sizlere bazı özelliklerden bahsetmek istiyorum.

![Screenshot_1](https://user-images.githubusercontent.com/73427323/211588061-d941f5c6-0b66-4ab5-8729-84d84aeac0c5.png)

Gördüğünüz üzere içinde pek de veri bulunmayan bir depomuz var. Öncelikle bu depoya ürün ekleyerek başlayalım. 

![Screenshot_2](https://user-images.githubusercontent.com/73427323/211588284-ac870022-b254-4acb-abb4-188ce160881c.png)

**Add Product** butonuna bastığımızda yukarıdaki ekran önümüze gelecek. Bu esnada istediğimiz özelliklerdeki ürünlerin veritabanında nasıl tutualacağını sisteme girmemiz gerekiyor. 

*(Not: Kategori bölümündeki ürünleri veritabanından kolaylıkla değiştirebilirsiniz. Projenin ilerisi için admin'in yeni kategori ekleyebileceği bir sayfa yapılabilir)*

Ürünü ekledikten sonra sistem bizi veritabanı sayfamıza yönlendirecek ve bize yeni eklediğimiz ürünü gösterecektir.

![after_add_prod](https://user-images.githubusercontent.com/73427323/211588864-2476d98b-35df-4c0c-be4e-1894fa600e60.png)

**Update Product** butonuna bastığımızda ürünün bilgileri formda otomatik dolu bir şekilde gelecek. Buradan istediğimiz veriyi değiştirerek ürünü kolaylıkla güncelleyebiliriz.

![update](https://user-images.githubusercontent.com/73427323/211589053-e04f46b1-aaf6-4da3-a4aa-3eec9393be8e.png)

Yukarıdaki gibi marka üzerinde bir değişiklik yaptığımızda sistem aşağıdaki gibi görünecektir:

![after_update](https://user-images.githubusercontent.com/73427323/211589131-bbd417e6-2a95-4740-a330-72e6741f7b3e.png)

Bir şeyler silmek istediğimiz zaman **Delete Product** butonunu kullanmamız gerekiyor. Burada ürünü silerken onun nasıl imha edileceği ve silinme nedeni gibi özelliklerini girmemiz gerekiyor.

![delete](https://user-images.githubusercontent.com/73427323/211589428-93f28ac5-8431-46cf-9ef9-86d91b753168.png)

Yukarıdaki bilgileri girdikten sonra sisteme geri döndüğümüzde sildiğimiz ürünü önümüzde göremeyeceğiz. Fakat **Deleted Items** kısmına ilerlersek burada silinen bütün ürünlerin geçmişini, kim tarafından ve hangi tarihte silindiğini otomatik olarak çekili bir şekilde görebiliriz.

![deleted-items-page](https://user-images.githubusercontent.com/73427323/211589704-15b51938-a99d-46c8-b53d-52a75fd001ce.png)

Şuna değinmek isterim ki **Add User** ve **Deleted Items** butonları sadece Admin yetkisi olan kişilerde görüntüleniyor. Bunun kontrolü de aşağıdaki gibi sağlanıyor:

![add-user_deleted-items_only-admin](https://user-images.githubusercontent.com/73427323/211589915-cc99fef5-68bf-4766-814d-8627e24076a1.png)

Ayrıca login kısmında bahsettiğim şifre hashleme de aşağıdaki gibi çalışıyor:

![hash](https://user-images.githubusercontent.com/73427323/211590053-ef512a0e-7d3a-43fc-a9f7-1d06363921b8.png)

## Future Works

Projenin geleceğinde eklemeyi düşündüğüm şeyler:
- Ürün azaldığında sisteme uyarı yazılması. (Örnek olarak bilgisayar sayımız 4 sayısının altına düştüğünde bir uyarı almamız)
- Arama Barı (Sistemde ürün sayısı arttıkça bulmak zor olabilir)
- Yenilikçi tasarım. (Sistemin back-end kısmına daha fazla yoğunlaştığım için tasarım anlamında bir takım eksiklikler barındırıyor.)
- Kategori Ekleme/Güncelleme.
- Yeni Captcha kullanımı.
- Bir domain'e yüklemek.





