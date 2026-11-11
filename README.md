# 3D Top Toplama Oyunu - Vize Projesi

## 1. Oyunun Kısa Açıklaması
Bu projeyi Unity oyun motoru ve C# kullanarak tek sahneli, 3D fizik tabanlı bir oyun olarak geliştirdim. Amacım WASD tuşlarıyla topu yönlendirip yeşil nesneleri toplayarak puan kazanmak (+10) ve kırmızı engellerden kaçmak (-5). 50 puana ulaştığımda bitiş alanına giderek oyunu tamamlıyorum ve sahne otomatik olarak başa dönüyor.

## 2. Scriptlerin Görevleri
* **PlayerController.cs:** Projedeki temel mekanikleri bu scriptle yönettim. Topun Rigidbody ile hareket etmesi, zıplaması, zemin kontrolü, nesnelere çarpma/toplama işlemleri, puan hesabı ve oyun bitince sahnenin yeniden yüklenmesi (`SceneManager`) bu kodun içinde çalışıyor.
* **CameraController.cs:** Kameranın oyuncuyu (topu) oyun boyunca pürüzsüz bir şekilde takip etmesini sağlayan sistemi bu script ile kurdum. Bu kodu ve takip mantığını oluştururken yapay zekadan destek aldım.

## 3. Seçilen Mekaniğin Algoritması: Zıplama Sistemi
Havada sınırsız zıplamayı engellemek için şöyle bir algoritma oluşturduö: Top "Zemin" etiketli objeye değdiğinde `OnCollisionEnter` ile `isGrounded` değişkenini `true` yaptım. Space tuşuna basıldığında, kod önce `isGrounded` true mu diye kontrol ediyor, öyleyse `AddForce` ile topu zıplatıyor. Zeminle temas kesildiğinde ise `OnCollisionExit` ile değişkeni `false` yapıp havada tekrar zıplamayı engelliyorum.

## 4. Karşılaştığım Hatalar ve Çözümleri
Geliştirme sürecinde ve kod yazarken yaşadığım bazı sorunlarda, hatanın kaynağını bulması için yapay zekadan yardım aldım. Sorunları tespit ettikten sonra çözümleri projeme şu şekilde uyguladım:

'Buzda Kayma Sorunu': Oyunu test ederken yön tuşunu bıraksam bile top durmuyor, buzda kayar gibi gitmeye devam ediyordu. Yapay zekanın da yönlendirmesiyle koddan Rigidbody'nin `drag` ve `angularDrag` değerlerini artırdım. Ayrıca Unity içinden "Physics Material (TopMateryali)" oluşturup objelere atayarak sürtünmeyi fiziksel olarak düzelttim.
'WASD Hareket Yönlerinin Karışması': Kodun ilk aşamalarında yön tuşlarına bastığımda top komut verdiğim yöne değil, ters veya alakasız yönlere gidiyordu. Sorunu bulmak için yapay zekadan destek aldım ve Input.GetAxis ile aldığım yatay ve dikey hareket verilerinin Vector3 içinde yanlış eksenlere yazıldığını fark ettim. X ve Z eksenlerindeki dizilimi ve eksi/artı değerlerini doğru eşleştirerek hareket kontrolünü tamamen düzelttim.

