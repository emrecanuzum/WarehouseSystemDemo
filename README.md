
# Warehouse System Demo

Bu demo temel anlamda bir depo altyapısının nasıl çalışması gerektiğine dair temel öğeleri barındırıyor.
Sistemin veritabanını yerel makinemde **Microsoft SQL Server Management Studio** ile tutup,
ASP.NET MVC nugget paketi ile birleştirdim. Böylece temel kullanıcı girişi sistemleri, kullanıcı yönetimi,
ürün yönetimi, güvenlik ve hızlı veri etkileşimi sistemlerini tasarlayabildim.


### Nasıl Çalıştırılır?
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
