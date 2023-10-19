# Reservation Service

There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text.

## Veritabanı Migrationları

Veritabanı Migrationları oluşturmak ve uygulamak için aşağıdaki komutları kullanabilirsiniz.

Migration oluşturma:
```sh
dotnet ef migrations add Init --context ReservationDbContext -o Migrations/ReservationDb
dotnet ef migrations script --context ReservationDbContext
dotnet ef database update --context ReservationDbContext

