
# Warehouse System Demo

Bu demo temel anlamda bir depo altyapısının nasıl çalışması gerektiğine dair temel öğeleri barındırıyor.
Sistemin veritabanını yerel makinemde **Microsoft SQL Server Management Studio** ile tutup,
ASP.NET MVC nugget paketi ile birleştirdim. Böylece temel kullanıcı girişi sistemleri, kullanıcı yönetimi,
ürün yönetimi, güvenlik ve hızlı veri etkileşimi sistemlerini tasarlayabildim.


### Nasıl Çalıştırılır?
Öncelikle database dependency klasöründe bulunan veritabanı kopyalarını **Microsoft SQL Server Management Studio**'ya
kurmanız gerekiyor. Klasörde bulunan .mdf dosyalarını *"C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA"*
konumuna kopyaladıktan sonra database uygulamasının içinden kolaylıkla kurulumunu sağlayabilirsiniz.

Veritabanımızı kurduktan sonra sıra ASP.NET'in Model bölümüne database bağlantısını kurmaya geliyor.

![DatabaseDependency](https://prnt.sc/mnlzNu14sDs9)
