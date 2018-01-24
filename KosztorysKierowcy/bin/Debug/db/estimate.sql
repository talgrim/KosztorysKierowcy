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
  PRIMARY KEY (`carid`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cars`
--

LOCK TABLES `cars` WRITE;
/*!40000 ALTER TABLE `cars` DISABLE KEYS */;
INSERT INTO `cars` VALUES (1,'Skoda',5),(2,'Opel',8);
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
  CONSTRAINT `debts_ibfk_1` FOREIGN KEY (`driverid`) REFERENCES `drivers` (`driverid`),
  CONSTRAINT `debts_ibfk_2` FOREIGN KEY (`passengerid`) REFERENCES `passengers` (`passengerid`)
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
-- Table structure for table `drivers`
--

DROP TABLE IF EXISTS `drivers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `drivers` (
  `driverid` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(50) NOT NULL,
  `surname` varchar(50) NOT NULL,
  PRIMARY KEY (`driverid`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `drivers`
--

LOCK TABLES `drivers` WRITE;
/*!40000 ALTER TABLE `drivers` DISABLE KEYS */;
INSERT INTO `drivers` VALUES (1,'Witold','DomaĹ„ski'),(2,'Maciej','Hyla');
/*!40000 ALTER TABLE `drivers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `owned`
--

DROP TABLE IF EXISTS `owned`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `owned` (
  `carid` int(11) NOT NULL,
  `driverid` int(11) NOT NULL,
  PRIMARY KEY (`carid`,`driverid`),
  KEY `driverid` (`driverid`),
  CONSTRAINT `owned_ibfk_1` FOREIGN KEY (`carid`) REFERENCES `cars` (`carid`),
  CONSTRAINT `owned_ibfk_2` FOREIGN KEY (`driverid`) REFERENCES `drivers` (`driverid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `owned`
--

LOCK TABLES `owned` WRITE;
/*!40000 ALTER TABLE `owned` DISABLE KEYS */;
INSERT INTO `owned` VALUES (1,1),(2,2);
/*!40000 ALTER TABLE `owned` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `passengers`
--

DROP TABLE IF EXISTS `passengers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `passengers` (
  `passengerid` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(50) NOT NULL,
  `surname` varchar(50) NOT NULL,
  PRIMARY KEY (`passengerid`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `passengers`
--

LOCK TABLES `passengers` WRITE;
/*!40000 ALTER TABLE `passengers` DISABLE KEYS */;
INSERT INTO `passengers` VALUES (1,'Witold','DomaĹ„ski'),(2,'Maciej','Hyla'),(3,'Adam','Strachanowski'),(4,'Dawid','Pasek');
/*!40000 ALTER TABLE `passengers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `passengerstotransit`
--

DROP TABLE IF EXISTS `passengerstotransit`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `passengerstotransit` (
  `transitid` int(11) NOT NULL,
  `passengerid` int(11) NOT NULL,
  PRIMARY KEY (`transitid`,`passengerid`),
  KEY `passengerid` (`passengerid`),
  CONSTRAINT `passengerstotransit_ibfk_1` FOREIGN KEY (`transitid`) REFERENCES `transits` (`transitid`),
  CONSTRAINT `passengerstotransit_ibfk_2` FOREIGN KEY (`passengerid`) REFERENCES `passengers` (`passengerid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `passengerstotransit`
--

LOCK TABLES `passengerstotransit` WRITE;
/*!40000 ALTER TABLE `passengerstotransit` DISABLE KEYS */;
/*!40000 ALTER TABLE `passengerstotransit` ENABLE KEYS */;
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
  `driverid` int(11) NOT NULL,
  `carid` int(11) NOT NULL,
  `routeid` int(11) NOT NULL,
  `driven` datetime NOT NULL,
  PRIMARY KEY (`transitid`),
  KEY `driverid` (`driverid`),
  KEY `carid` (`carid`),
  KEY `routeid` (`routeid`),
  CONSTRAINT `transits_ibfk_1` FOREIGN KEY (`driverid`) REFERENCES `drivers` (`driverid`),
  CONSTRAINT `transits_ibfk_2` FOREIGN KEY (`carid`) REFERENCES `cars` (`carid`),
  CONSTRAINT `transits_ibfk_3` FOREIGN KEY (`routeid`) REFERENCES `routes` (`routeid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `transits`
--

LOCK TABLES `transits` WRITE;
/*!40000 ALTER TABLE `transits` DISABLE KEYS */;
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

-- Dump completed on 2018-01-24 13:37:29

