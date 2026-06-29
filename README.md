# 🛒 ShopApp - E-Commerce Application

Angular ve .NET ile geliştirilmiş full-stack e-ticaret uygulaması.

## 🚀 Teknolojiler

**Backend**
- .NET 10 / ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- JWT Authentication
- Clean Architecture (Core, DataAccess, Business, API)

**Frontend**
- Angular 21
- TypeScript
- SCSS

## ✨ Özellikler

- Kullanıcı kayıt ve giriş (JWT)
- Ürün listeleme ve detay sayfası
- Kategori bazlı filtreleme
- Sepet yönetimi
- Sipariş oluşturma
- Stok takibi

## 🛠️ Kurulum

### Backend
```bash
cd ShopApp.API
dotnet restore
dotnet ef database update
dotnet run
```

### Frontend
```bash
cd ShopApp.Angular
npm install
npx ng serve
```

## 📡 API
Swagger UI: `http://localhost:5062/swagger`

## 🌐 Uygulama
`http://localhost:4200`