-- MySQL dump 10.13  Distrib 8.0.19, for Win64 (x86_64)
--
-- Host: localhost    Database: db_coffee_jam_delapan
-- ------------------------------------------------------
-- Server version	5.5.5-10.4.32-MariaDB

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `item_stock`
--

DROP TABLE IF EXISTS `medicine`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `medicine` (
  `id_medicine` int(11) NOT NULL AUTO_INCREMENT COMMENT 'id mandatory',
  `code` varchar(50) NOT NULL COMMENT 'kode obat',
  `name` varchar(100) NOT NULL COMMENT 'nama obat',
  `category` varchar(50) DEFAULT NULL COMMENT 'kategori obat',
  `measurement` varchar(50) DEFAULT NULL COMMENT 'satuan ukur',
  `quantity` int(11) DEFAULT 0 COMMENT 'stok terkini',
  `price` decimal(10,2) DEFAULT 0.00 COMMENT 'harga obat',
  `expired_date` date DEFAULT NULL COMMENT 'tanggal kedaluwarsa',
  `last_update` datetime DEFAULT NULL COMMENT 'terakhir diupdate',
  `is_deleted` varchar(5) DEFAULT 'false' COMMENT 'indikator terhapus atau tidak',
  PRIMARY KEY (`id_medicine`),
  UNIQUE KEY `medicine_unique` (`code`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='stok obat apotek';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `medicine`
--

LOCK TABLES `medicine` WRITE;
/*!40000 ALTER TABLE `medicine` DISABLE KEYS */;
/*!40000 ALTER TABLE `medicine` ENABLE KEYS */;
UNLOCK TABLES;
--;[--


-- Table structure for table `member`
--

DROP TABLE IF EXISTS `patient`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `patient` (
  `id_patient` int(11) NOT NULL AUTO_INCREMENT COMMENT 'id mandatory',
  `code` varchar(50) NOT NULL COMMENT 'kode pasien/pelanggan',
  `name` varchar(100) NOT NULL COMMENT 'nama pasien',
  `phone` varchar(20) DEFAULT NULL COMMENT 'nomor telepon pasien',
  `address` text DEFAULT NULL COMMENT 'alamat tempat tinggal',
  `last_update` datetime DEFAULT NULL COMMENT 'terakhir diupdate',
  `is_deleted` varchar(5) DEFAULT 'false' COMMENT 'indikator terhapus atau tidak',
  PRIMARY KEY (`id_patient`),
  UNIQUE KEY `patient_unique` (`code`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='data pasien apotek';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `patient`
--

LOCK TABLES `patient` WRITE;
/*!40000 ALTER TABLE `patient` DISABLE KEYS */;
/*!40000 ALTER TABLE `patient` ENABLE KEYS */;
UNLOCK TABLES;
-- Table structure for table `recipe`
--

DROP TABLE IF EXISTS `recipe`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `recipe` (
  `id_receipt` int(11) NOT NULL AUTO_INCREMENT COMMENT 'id mandatory',
  `code` varchar(5) NOT NULL COMMENT 'kode menu',
  `name` varchar(200) DEFAULT NULL COMMENT 'nama menu',
  `type` varchar(30) DEFAULT NULL COMMENT 'tipe menu (coffee, non-coffee, appetizer, main-course, dessert)',
  `id_item_a` int(11) DEFAULT NULL COMMENT 'referensi ke item',
  `id_item_b` int(11) DEFAULT NULL COMMENT 'referensi ke item',
  `id_item_c` int(11) DEFAULT NULL COMMENT 'referensi ke item',
  `id_item_d` int(11) DEFAULT NULL COMMENT 'referensi ke item',
  `qty_item_a` double DEFAULT NULL COMMENT 'jumlah untuk tiap item terpakai',
  `qty_item_b` double DEFAULT NULL COMMENT 'jumlah untuk tiap item terpakai',
  `qty_item_c` double DEFAULT NULL COMMENT 'jumlah untuk tiap item terpakai',
  `qty_item_d` double DEFAULT NULL COMMENT 'jumlah untuk tiap item terpakai',
  `recipe_instruction` varchar(1000) DEFAULT NULL COMMENT 'cara pembuatan',
  `saving_instruction` varchar(1000) DEFAULT NULL COMMENT 'cara penyimpanan',
  `last_update` datetime DEFAULT NULL COMMENT 'terakhir diupdate',
  `is_deleted` varchar(1) DEFAULT NULL COMMENT 'indikator terhapus atau tidak',
  PRIMARY KEY (`id_receipt`),
  UNIQUE KEY `receipt_unique` (`code`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='resep makanan dan minuman';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `recipe`
--

LOCK TABLES `recipe` WRITE;
/*!40000 ALTER TABLE `recipe` DISABLE KEYS */;
/*!40000 ALTER TABLE `recipe` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `transaction`
--

DROP TABLE IF EXISTS `transaction`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `transaction` (
  `id_transaction` int(11) NOT NULL AUTO_INCREMENT COMMENT 'id mandatory',
  `id_member` int(11) NOT NULL,
  `code` varchar(20) NOT NULL COMMENT 'kode transaksi',
  `n_menu` int(11) NOT NULL COMMENT 'jumlah menu yang dipesan',
  `transaction_date` datetime DEFAULT NULL COMMENT 'tgl transaksi',
  `subtotal` double DEFAULT NULL COMMENT 'jumlah harga makanan',
  `id_discount` int(11) DEFAULT NULL COMMENT 'reference ke daftar diskon',
  `discount` double DEFAULT NULL COMMENT 'jumlah yg didiskon',
  `tax_rate` double DEFAULT NULL COMMENT 'persen pajak',
  `tax` double DEFAULT NULL COMMENT 'jumlah pajak',
  `total` double DEFAULT NULL COMMENT 'jumlah yg harus dibayar',
  `paid` double DEFAULT NULL COMMENT 'jumlah dibayar',
  `change` double DEFAULT NULL COMMENT 'kembalian',
  PRIMARY KEY (`id_transaction`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='transaksi utama';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `transaction`
--

LOCK TABLES `transaction` WRITE;
/*!40000 ALTER TABLE `transaction` DISABLE KEYS */;
/*!40000 ALTER TABLE `transaction` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `transaction_details`
--

DROP TABLE IF EXISTS `transaction_details`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `transaction_details` (
  `id_detail` int(11) NOT NULL AUTO_INCREMENT COMMENT 'id mandatory',
  `id_transaction` int(11) NOT NULL,
  `id_recipe` int(11) NOT NULL,
  `quantity` int(11) DEFAULT NULL COMMENT 'jumlah menu dipesan',
  `price` double DEFAULT NULL COMMENT 'harga satuan',
  `total` double DEFAULT NULL COMMENT 'total harga',
  PRIMARY KEY (`id_detail`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='detail transaksi';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `transaction_details`
--

LOCK TABLES `transaction_details` WRITE;
/*!40000 ALTER TABLE `transaction_details` DISABLE KEYS */;
/*!40000 ALTER TABLE `transaction_details` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user`
--

DROP TABLE IF EXISTS `patient`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `patient` (
  `id_patient` int(11) NOT NULL AUTO_INCREMENT COMMENT 'id mandatory',
  `code` varchar(50) NOT NULL COMMENT 'kode pasien/pelanggan',
  `name` varchar(100) NOT NULL COMMENT 'nama pasien',
  `phone` varchar(20) DEFAULT NULL COMMENT 'nomor telepon pasien',
  `address` text DEFAULT NULL COMMENT 'alamat tempat tinggal',
  `last_update` datetime DEFAULT NULL COMMENT 'terakhir diupdate',
  `is_deleted` varchar(5) DEFAULT 'false' COMMENT 'indikator terhapus atau tidak',
  PRIMARY KEY (`id_patient`),
  UNIQUE KEY `patient_unique` (`code`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='data pasien apotek';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `patient`
--

LOCK TABLES `patient` WRITE;
/*!40000 ALTER TABLE `patient` DISABLE KEYS */;
/*!40000 ALTER TABLE `patient` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping routines for database 'db_coffee_jam_delapan'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-03-07 10:56:54
