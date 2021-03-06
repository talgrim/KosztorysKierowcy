-- MySQL dump 10.16  Distrib 10.1.28-MariaDB, for Win32 (AMD64)
--
-- Host: localhost    Database: estimate3
-- ------------------------------------------------------
-- Server version	10.1.28-MariaDB

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `cars`
--

DROP TABLE IF EXISTS `cars`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `cars` (
  `carid` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(50) CHARACTER SET utf8 COLLATE utf8_polish_ci NOT NULL,
  `consumption` int(11) NOT NULL,
  `ownerid` int(11) DEFAULT NULL,
  PRIMARY KEY (`carid`),
  KEY `ownerid` (`ownerid`),
  CONSTRAINT `cars_ibfk_1` FOREIGN KEY (`ownerid`) REFERENCES `persons` (`personid`) ON DELETE SET NULL
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cars`
--

LOCK TABLES `cars` WRITE;
/*!40000 ALTER TABLE `cars` DISABLE KEYS */;
INSERT INTO `cars` VALUES (1,'Skoda',5,1),(2,'Opel',8,2),(3,'Volkswagen Golf',6,5);
/*!40000 ALTER TABLE `cars` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `debtperson`
--

DROP TABLE IF EXISTS `debtperson`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `debtperson` (
  `personid` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(50) CHARACTER SET utf8 COLLATE utf8_polish_ci NOT NULL,
  `surname` varchar(50) CHARACTER SET utf8 COLLATE utf8_polish_ci NOT NULL,
  PRIMARY KEY (`personid`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `debtperson`
--

LOCK TABLES `debtperson` WRITE;
/*!40000 ALTER TABLE `debtperson` DISABLE KEYS */;
INSERT INTO `debtperson` VALUES (1,'Witold','DomaĹ„ski'),(2,'Maciej','Hyla'),(3,'Adam','Strachanowski'),(4,'Dawid','Pasek'),(5,'Dawid','Ĺ»ugaj');
/*!40000 ALTER TABLE `debtperson` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `debts`
--

DROP TABLE IF EXISTS `debts`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `debts` (
  `debtid` int(11) NOT NULL AUTO_INCREMENT,
  `creditorid` int(11) NOT NULL,
  `debtorid` int(11) NOT NULL,
  `date` datetime NOT NULL,
  `amount` double(10,2) NOT NULL,
  PRIMARY KEY (`debtid`),
  KEY `driverid` (`creditorid`),
  KEY `passengerid` (`debtorid`),
  CONSTRAINT `debts_ibfk_1` FOREIGN KEY (`creditorid`) REFERENCES `debtperson` (`personid`),
  CONSTRAINT `debts_ibfk_2` FOREIGN KEY (`debtorid`) REFERENCES `debtperson` (`personid`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `debts`
--

LOCK TABLES `debts` WRITE;
/*!40000 ALTER TABLE `debts` DISABLE KEYS */;
INSERT INTO `debts` VALUES (2,1,2,'2018-01-28 12:05:03',3.00),(3,1,2,'2018-01-28 12:09:54',1.94),(4,1,3,'2018-01-28 12:09:54',1.94),(5,1,4,'2018-01-28 12:09:54',1.94),(6,2,1,'2018-01-28 13:45:25',2.69),(7,2,3,'2018-01-28 13:45:25',2.69),(8,2,4,'2018-01-28 13:45:25',2.69),(9,2,5,'2018-01-28 13:45:25',2.69),(10,5,3,'2018-01-28 13:49:41',4.65);
/*!40000 ALTER TABLE `debts` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `passengerstotransit`
--

DROP TABLE IF EXISTS `passengerstotransit`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `passengerstotransit` (
  `transitid` int(11) NOT NULL,
  `passengerid` int(11) DEFAULT NULL,
  UNIQUE KEY `UNIQUE` (`transitid`,`passengerid`) USING BTREE,
  KEY `passengerid` (`passengerid`),
  CONSTRAINT `passengerstotransit_ibfk_1` FOREIGN KEY (`transitid`) REFERENCES `transits` (`transitid`),
  CONSTRAINT `passengerstotransit_ibfk_2` FOREIGN KEY (`passengerid`) REFERENCES `persons` (`personid`) ON DELETE SET NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `passengerstotransit`
--

LOCK TABLES `passengerstotransit` WRITE;
/*!40000 ALTER TABLE `passengerstotransit` DISABLE KEYS */;
INSERT INTO `passengerstotransit` VALUES (17,2),(18,2),(18,3),(18,4),(19,2),(19,3),(19,4),(20,2),(20,3),(20,4),(21,1),(21,3),(21,4),(21,5),(22,3);
/*!40000 ALTER TABLE `passengerstotransit` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `persons`
--

DROP TABLE IF EXISTS `persons`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `persons` (
  `personid` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(50) CHARACTER SET utf8 COLLATE utf8_polish_ci NOT NULL,
  `surname` varchar(50) CHARACTER SET utf8 COLLATE utf8_polish_ci NOT NULL,
  `driver` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`personid`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `persons`
--

LOCK TABLES `persons` WRITE;
/*!40000 ALTER TABLE `persons` DISABLE KEYS */;
INSERT INTO `persons` VALUES (1,'Witold','DomaĹ„ski',1),(2,'Maciej','Hyla',1),(3,'Adam','Strachanowski',0),(4,'Dawid','Pasek',0),(5,'Dawid','Zugaj',1);
/*!40000 ALTER TABLE `persons` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `routes`
--

DROP TABLE IF EXISTS `routes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `routes` (
  `routeid` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(100) CHARACTER SET utf8 COLLATE utf8_polish_ci NOT NULL,
  `distance` int(11) NOT NULL,
  PRIMARY KEY (`routeid`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `routes`
--

LOCK TABLES `routes` WRITE;
/*!40000 ALTER TABLE `routes` DISABLE KEYS */;
INSERT INTO `routes` VALUES (1,'Na studia, przez 88 z Simply',24),(2,'Na studia, przez A1 z Simply',31);
/*!40000 ALTER TABLE `routes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `transits`
--

DROP TABLE IF EXISTS `transits`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `transits` (
  `transitid` int(11) NOT NULL AUTO_INCREMENT,
  `driverid` int(11) DEFAULT NULL,
  `carid` int(11) DEFAULT NULL,
  `routeid` int(11) DEFAULT NULL,
  `driven` datetime NOT NULL,
  `cost` double(10,2) NOT NULL,
  PRIMARY KEY (`transitid`),
  KEY `driverid` (`driverid`),
  KEY `carid` (`carid`),
  KEY `routeid` (`routeid`),
  CONSTRAINT `transits_ibfk_1` FOREIGN KEY (`driverid`) REFERENCES `persons` (`personid`) ON DELETE SET NULL,
  CONSTRAINT `transits_ibfk_2` FOREIGN KEY (`carid`) REFERENCES `cars` (`carid`) ON DELETE SET NULL,
  CONSTRAINT `transits_ibfk_3` FOREIGN KEY (`routeid`) REFERENCES `routes` (`routeid`) ON DELETE SET NULL
) ENGINE=InnoDB AUTO_INCREMENT=23 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `transits`
--

LOCK TABLES `transits` WRITE;
/*!40000 ALTER TABLE `transits` DISABLE KEYS */;
INSERT INTO `transits` VALUES (17,1,1,1,'2018-01-28 12:05:03',3.00),(18,1,1,2,'2018-01-28 12:08:27',1.94),(19,1,1,2,'2018-01-28 12:09:12',1.94),(20,1,1,2,'2018-01-28 12:09:54',1.94),(21,2,2,1,'2018-01-28 13:45:25',2.69),(22,5,3,2,'2018-01-28 13:49:41',4.65);
/*!40000 ALTER TABLE `transits` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-02-04 18:54:05

