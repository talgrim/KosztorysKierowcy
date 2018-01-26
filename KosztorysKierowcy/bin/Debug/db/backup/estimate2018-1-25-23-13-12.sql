-- MySQL dump 10.16  Distrib 10.1.28-MariaDB, for Win32 (AMD64)
--
-- Host: localhost    Database: estimate
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
  `name` varchar(50) NOT NULL,
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
-- Table structure for table `debts`
--

DROP TABLE IF EXISTS `debts`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `debts` (
  `debtid` int(11) NOT NULL AUTO_INCREMENT,
  `driverid` int(11) NOT NULL,
  `passengerid` int(11) NOT NULL,
  `driven` datetime NOT NULL,
  `amount` int(11) NOT NULL,
  PRIMARY KEY (`debtid`),
  KEY `driverid` (`driverid`),
  KEY `passengerid` (`passengerid`),
  CONSTRAINT `debts_ibfk_1` FOREIGN KEY (`driverid`) REFERENCES `persons` (`personid`),
  CONSTRAINT `debts_ibfk_2` FOREIGN KEY (`passengerid`) REFERENCES `persons` (`personid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `debts`
--

LOCK TABLES `debts` WRITE;
/*!40000 ALTER TABLE `debts` DISABLE KEYS */;
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
INSERT INTO `passengerstotransit` VALUES (1,2),(1,3),(1,4),(2,2),(2,4),(3,2),(3,4),(4,1),(4,3),(5,1),(5,4),(6,4),(7,2),(7,3),(7,4),(8,2),(8,4),(9,2),(9,4),(10,3),(11,2),(12,1),(13,1),(13,2);
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
  `name` varchar(50) NOT NULL,
  `surname` varchar(50) NOT NULL,
  `driver` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`personid`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `persons`
--

LOCK TABLES `persons` WRITE;
/*!40000 ALTER TABLE `persons` DISABLE KEYS */;
INSERT INTO `persons` VALUES (1,'Witold','Domanski',1),(2,'Maciej','Hyla',1),(3,'Adam','Strachanowski',0),(4,'Dawid','Pasek',NULL),(5,'Dawid','Zugaj',1);
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
  `name` varchar(100) NOT NULL,
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
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `transits`
--

LOCK TABLES `transits` WRITE;
/*!40000 ALTER TABLE `transits` DISABLE KEYS */;
INSERT INTO `transits` VALUES (1,1,1,1,'2018-01-24 19:58:03',2.50),(2,1,1,1,'2018-01-24 19:58:05',2.50),(3,1,1,2,'2018-01-24 19:58:08',2.50),(4,2,2,2,'2018-01-24 19:58:12',2.50),(5,2,2,1,'2018-01-24 19:58:17',2.50),(6,2,2,1,'2018-01-24 19:58:19',2.50),(7,1,1,1,'2018-01-24 19:59:06',2.50),(8,1,1,1,'2018-01-24 20:00:52',2.50),(9,1,1,1,'2018-01-24 20:01:06',2.50),(10,1,1,1,'2018-01-24 20:18:26',2.50),(11,1,1,2,'2018-01-24 23:30:48',4.65),(12,2,2,2,'2018-01-24 23:31:13',7.44),(13,5,3,2,'2018-01-25 22:29:58',3.10);
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

-- Dump completed on 2018-01-25 23:13:12

