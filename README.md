# Parking System

Parking System adalah aplikasi yang dibangun menggunakan .NET 5.0 untuk mengelola tempat parkir dengan berbagai fitur yang memudahkan pengguna dalam pengelolaan kendaraan yang masuk dan keluar.

## Prerequisites
- .NET 5.0 SDK

## Perintah
Berikut adalah daftar perintah yang tersedia dalam Parking System:

- `show_commands`: Menampilkan seluruh command yang dapat digunakan
- `create_parking_lot <jumlah_slot>`: Membuat tempat parkir dengan jumlah slot yang ditentukan.
- `park <nomor_registrasi> <warna> <jenis_kendaraan>`: Memarkir kendaraan dengan informasi yang diberikan.
- `leave <slot_number>`: Mengeluarkan kendaraan dari slot parkir yang ditentukan.
- `status`: Menampilkan seluruh informasi tentang kendaraan yang diparkir.
- `type_of_vehicles <jenis_kendaraan>`: Menampilkan jumlah kendaraan berdasarkan jenisnya.
- `registration_numbers_for_vehicles_with_odd_plate`: Menampilkan nomor registrasi kendaraan dengan plat ganjil.
- `registration_numbers_for_vehicles_with_even_plate`: Menampilkan nomor registrasi kendaraan dengan plat genap.
- `registration_numbers_for_vehicles_with_colour <warna>`: Menampilkan nomor registrasi kendaraan berdasarkan warna.
- `slot_numbers_for_vehicles_with_colour <warna>`: Menampilkan slot parkir kendaraan berdasarkan warna.
- `slot_number_for_registration_number <nomor_registrasi>`: Menampilkan nomor slot kendaraan berdasarkan nomor registrasi.
- `count_vehicles_by_color <warna>`: Menghitung jumlah kendaraan berdasarkan warna.
- `count_available_lots`: Menghitung jumlah slot parkir yang tersedia.
- `count_occupied_lots`: Menghitung jumlah slot parkir yang terisi.
- `count_even_plates`: Menghitung jumlah kendaraan dengan pelat genap.
- `count_odd_plates`: Menghitung jumlah kendaraan dengan pelat ganjil.
- `exit`: Keluar dari aplikasi.

## Fitur
- Pembuatan tempat parkir dengan jumlah slot yang dapat dikonfigurasi.
- Penyimpanan dan pengelolaan kendaraan yang masuk dan keluar.
- Pencarian kendaraan berdasarkan warna, nomor registrasi, dan jenis kendaraan.
- Menampilkan informasi tempat parkir secara real-time.
- Penghitungan jumlah kendaraan berdasarkan berbagai kategori.
