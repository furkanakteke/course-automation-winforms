# Educational Institution (Course/Dershane) Management System

Bu proje, bir eğitim kurumunun veya dershanenin tüm operasyonel süreçlerini dijitalleştirmek amacıyla C# Windows Forms mimarisiyle geliştirilmiş, kapsamlı bir **Kurumsal Kaynak Planlama (ERP) ve Yönetim Bilgi Sistemi** uygulamasıdır.

İçerisinde 15'ten fazla dinamik arayüz (Form) barındıran bu sistem; ilişkisel veri tabanı modellemesi, çoklu nesne yönetimi ve gelişmiş iş mantığı (Business Logic) prensipleriyle tasarlanmıştır.

---

## 📊 Sistem Modülleri ve Mimari Kapsam

Uygulama, kurumsal bir işletmenin ihtiyaç duyduğu şu ana modülleri ve ilişkisel veri süreçlerini tamamen dinamik olarak yönetir:

* **Öğrenci & Veli Yönetim Modülü:** Öğrenci kayıt, güncelleme, veli bilgileri bağlama ve detaylı profil yönetimi.
* **Akademik Kadro (Öğretmen) Yönet Modülü:** Öğretmen branş tanımlamaları, maaş/hakediş takibi ve sınıf eşleştirmeleri.
* **Sınıf & Kurs Programı Planlama:** Derslik doluluk oranları, haftalık ders programı matrisleri ve şube yönetimleri.
* **Mali Takip & Muhasebe Modülü:** Taksitli ödeme planları oluşturma, tahsilat makbuzları ve kurum içi gelir-gider dengesi takibi.
* **Devamsızlık & Yoklama Sistemi:** Öğrenci devam durumlarının periyodik takibi ve raporlanması.

---

## 🧠 Teknik ve Mimari Kazanımlar

* **Çoklu Form ve Veri Aktarımı:** Formlar arası nesne ve referans transferleri (MDI Parent/Child mimarisi).
* **İlişkisel Veri Tabanı Tasarımı (RDBMS):** Bire-çok ($1:N$) ve çoka-çok ($M:N$) tablolar arası ilişkiler, Foreign Key bütünlüğü ve optimize edilmiş T-SQL sorgu mantığı.
* **Gelişmiş Veri Doğrulama (Validation):** Hatalı veri girişlerini (boş bırakma, yanlış formatta telefon/T.C. Kimlik no vb.) engelleyen kullanıcı arayüzü filtreleri.

---

## 🛠️ Teknolojiler

* **Dil:** C#
* **Arayüz:** .NET Windows Forms App (15+ Active Interfaces)
* **Veri Tabanı Altyapısı:** MS SQL Server / T-SQL Architecture
