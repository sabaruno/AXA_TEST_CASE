1. Saya menggunakan infra local, jadi sesuaikan ConnectionStrings di appsettings.json (WEB API) dengan yang anda gunakan

Contoh :
"ConnectionStrings": {
    "DefaultConnection" : "Server=(localdb)\\Local;Database=AXA_TEST_CASE;Trusted_Connection=True;TrustServerCertificate=true"
} 

menjadi 

"ConnectionStrings": {
    "DefaultConnection" : "Server=NamaServer;Database=NamaDatabase;Trusted_Connection=True;TrustServerCertificate=true"
}


2. Untuk Run Web Dan API menggunakan cara berikut :
   - Klik kanan pada Solution AXA_TEST_CASE
   - lalu pilih properties
   - lalu pada common properties -> configure setup projects pilih Multiple statrup project
   - pada table paling kanan pilih start untuk WebAPI dan BlazorServer

