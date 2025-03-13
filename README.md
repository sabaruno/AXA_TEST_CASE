Saya menggunakan infra local, jadi sesuaikan ConnectionStrings di appsettings.json (WEB API) dengan yang anda gunakan

Contoh :
"ConnectionStrings": {
    "DefaultConnection" : "Server=(localdb)\\Local;Database=AXA_TEST_CASE;Trusted_Connection=True;TrustServerCertificate=true"
} 

menjadi 

"ConnectionStrings": {
    "DefaultConnection" : "Server=NamaServer;Database=NamaDatabase;Trusted_Connection=True;TrustServerCertificate=true"
},
